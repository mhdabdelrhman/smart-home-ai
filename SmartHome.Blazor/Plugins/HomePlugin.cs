using Microsoft.SemanticKernel;
using SmartHome.Blazor.Models;
using System.ComponentModel;

namespace SmartHome.Blazor.Plugins;

public class HomePlugin
{
    private readonly HomeDevices _devices;

    public HomePlugin(HomeDevices devices)
    {
        _devices = devices;
    }

    [KernelFunction("GetTVState")]
    [Description("Gets the state of the TV.")]
    public string GetTVState() => _devices.TV.IsOn ? "on" : "off";

    [KernelFunction("GetTVPower")]
    [Description("Gets the power of the TV in Watt.")]
    public string GetTVPower() => $"{_devices.TV.Power} Watt";

    [KernelFunction("ChangeTVState")]
    [Description("Changes the state of the TV.")]
    public string ChangeTVState(bool newState)
    {
        _devices.TV.IsOn = newState;
        return GetTVState();
    }

    [KernelFunction("GetHeaterState")]
    [Description("Gets the state of the Heater.")]
    public string GetHeaterState() => _devices.Heater.IsOn ? "on" : "off";

    [KernelFunction("GetHeaterPower")]
    [Description("Gets the power of the Heater in Watt.")]
    public string GetHeaterPower() => $"{_devices.Heater.Power} Watt";

    [KernelFunction("ChangeHeaterState")]
    [Description("Changes the state of the Heater.")]
    public string ChangeHeaterState(bool newState)
    {
        _devices.Heater.IsOn = newState;
        return GetHeaterState();
    }

    [KernelFunction("GetRefrigeratorState")]
    [Description("Gets the state of the Refrigerator.")]
    public string GetRefrigeratorState() => _devices.Refrigerator.IsOn ? "on" : "off";

    [KernelFunction("GetRefrigeratorPower")]
    [Description("Gets the power of the Refrigerator in Watt.")]
    public string GetRefrigeratorPower() => $"{_devices.Refrigerator.Power} Watt";

    [KernelFunction("ChangeRefrigeratorState")]
    [Description("Changes the state of the Refrigerator.")]
    public string ChangeRefrigeratorState(bool newState)
    {
        _devices.Refrigerator.IsOn = newState;
        return GetRefrigeratorState();
    }

    [KernelFunction("GetKitchenLightState")]
    [Description("Gets the state of the Kitchen Light.")]
    public string GetKitchenLightState() => _devices.kitchenLight.IsOn ? "on" : "off";

    [KernelFunction("GetKitchenLightPower")]
    [Description("Gets the power of the Kitchen Light in Watt.")]
    public string GetKitchenLightPower() => $"{_devices.kitchenLight.Power} Watt";

    [KernelFunction("ChangeKitchenLightState")]
    [Description("Changes the state of the Kitchen Light.")]
    public string ChangeKitchenLightState(bool newState)
    {
        _devices.kitchenLight.IsOn = newState;
        return GetKitchenLightState();
    }

    [KernelFunction("GetBedroomLightState")]
    [Description("Gets the state of the Bedroom Light.")]
    public string GetBedroomLightState() => _devices.BedroomLight.IsOn ? "on" : "off";

    [KernelFunction("GetBedroomLightPower")]
    [Description("Gets the power of the Bedroom Light in Watt.")]
    public string GetBedroomLightPower() => $"{_devices.BedroomLight.Power} Watt";

    [KernelFunction("ChangeBedroomLightState")]
    [Description("Changes the state of the Bedroom Light.")]
    public string ChangeBedroomLightState(bool newState)
    {
        _devices.BedroomLight.IsOn = newState;
        return GetBedroomLightState();
    }

    [KernelFunction("GetSittingRoomLightState")]
    [Description("Gets the state of the Sitting Room Light.")]
    public string GetSittingRoomLightState() => _devices.SittingRoomLight.IsOn ? "on" : "off";

    [KernelFunction("GetSittingRoomLightPower")]
    [Description("Gets the power of the Sitting Room Light in Watt.")]
    public string GetSittingRoomLightPower() => $"{_devices.SittingRoomLight.Power} Watt";

    [KernelFunction("ChangeSittingRoomLightState")]
    [Description("Changes the state of the Sitting Room Light.")]
    public string ChangeSittingRoomLightState(bool newState)
    {
        _devices.SittingRoomLight.IsOn = newState;
        return GetSittingRoomLightState();
    }
}

