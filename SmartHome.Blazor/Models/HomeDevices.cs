namespace SmartHome.Blazor.Models
{
    public class HomeDevices
    {
        public Device TV { get; }

        public Device Heater { get; }

        public Device Refrigerator { get; }

        public Device kitchenLight { get; }

        public Device BedroomLight { get; }

        public Device SittingRoomLight { get; }

        public HomeDevices()
        {
            TV = new Device(110);
            Heater = new Device(500);
            Refrigerator = new Device(300, true);
            kitchenLight = new Device(40);
            BedroomLight = new Device(10);
            SittingRoomLight = new Device(80);
        }
    }
}
