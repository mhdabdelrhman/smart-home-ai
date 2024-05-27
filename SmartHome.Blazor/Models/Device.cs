namespace SmartHome.Blazor.Models
{
    public class Device
    {
        public bool IsOn { get; set; }

        public int Power { get;}

        public Device(int power,bool isOn = false)
        {
            IsOn = isOn;
            Power = power;
        }
    }
}
