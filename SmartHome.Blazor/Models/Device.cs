namespace SmartHome.Blazor.Models
{
    public class Device
    {
        public bool IsOn { get; set; }

        public int Power { get; }

        public string? Icon { get; }

        public Device(int power, bool isOn = false, string icon = null)
        {
            IsOn = isOn;
            Power = power;
            Icon = icon;
        }
    }
}
