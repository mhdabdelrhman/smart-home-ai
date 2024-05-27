using Microsoft.AspNetCore.Components;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.PromptTemplates.Handlebars;
using SmartHome.Blazor.Models;
using System.Text;

namespace SmartHome.Blazor.Pages;

public partial class Index : ComponentBase
{
    [Inject] Kernel Kernel { get; set; } = default!;

    [Inject] EmailInbox EmailInbox { get; set; } = default!;

    [Inject] HomeDevices HomeDevices { get; set; } = default!;

    [Inject] IConfiguration Configuration { get; set; } = default!;

    StringBuilder ChatHistoryLog { get; set; } = new(string.Empty);

    string UserMessage { get; set; } = string.Empty;

    bool Processing { get; set; } = false;

    KernelFunction Prompt = default!;

    ChatHistory chatMessages = new();

    protected override async Task OnInitializedAsync()
    {
        await LoadPromptsAsync();
    }

    private Task LoadPromptsAsync()
    {
        var chat = """
            name: Chat
            template: |
              <message role="system">You are a helpful assistant managing my home devices, including TV, Heater, Refrigerator, Kitchen Light, Bedroom Light, and Sitting Room Light, each with its own power consumption</message>              

              {{#each messages}}
                <message role="{{Role}}">{{~Content~}}</message>
              {{/each}}
            template_format: handlebars
            description: A function that uses the chat history to respond to the user.
            input_variables:
              - name: messages
                description: The history of the chat.
                is_required: true
            """;
        Prompt = Kernel.CreateFunctionFromPromptYaml(
            chat,
            promptTemplateFactory: new HandlebarsPromptTemplateFactory()
        );

        return Task.CompletedTask;
    }

    private async Task HandleSubmitMessage()
    {
        if (UserMessage == string.Empty)
            return;

        Processing = true;
        try
        {
            var text = UserMessage;
            UserMessage = string.Empty;

            AppendChat(text, true);
            var result = await AskAIAsync(text);
            if (!string.IsNullOrEmpty(result))
                AppendChat(result, false);
            else
                AppendChat("No Suggestions!!!", false);
        }
        finally
        {
            Processing = false;
            UserMessage = string.Empty;
        }
    }

    private async Task<string?> AskAIAsync(string input)
    {
        chatMessages.AddUserMessage(input);

        OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
        {
            ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
        };

        var result = Kernel.InvokeStreamingAsync<StreamingChatMessageContent>(
            Prompt,
            arguments: new(openAIPromptExecutionSettings) {
            { "messages", chatMessages }
            });

        // Print the chat completions
        ChatMessageContent? chatMessageContent = null;
        await foreach (var content in result)
        {
            if (chatMessageContent == null)
            {
                chatMessageContent = new ChatMessageContent(
                    content.Role ?? AuthorRole.Assistant,
                    content.ModelId!,
                    content.Content!,
                    content.InnerContent,
                    content.Encoding,
                    content.Metadata);
            }
            else
            {
                chatMessageContent.Content += content;
            }
        }
        if (chatMessageContent != null)
        {
            chatMessages.AddMessage(chatMessageContent.Role, chatMessageContent.Content!);
        }

        var model = Configuration["model"];

        return chatMessageContent?.Content?.Replace(model!, "");
    }

    private void AppendChat(string text, bool isUser)
    {
        var chat = $"""            
            <div class="mt-2 d-flex justify-content-start {(isUser ? "flex-row-reverse" : "")}">
                <i class="fas {(isUser ? "fa-user m-2 text-success" : "fa-robot m-2 text-primary")}"></i>    
                <div class="chat {(isUser ? "bg-light" : "bg-secondary text-white")}">                                
                    {text}
                </div>
            </div>
            """;
        ChatHistoryLog.AppendLine(chat);
    }
}
