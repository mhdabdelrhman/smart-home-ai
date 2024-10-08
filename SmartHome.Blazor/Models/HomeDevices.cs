﻿namespace SmartHome.Blazor.Models
{
    public class HomeDevices
    {
        public Device TV { get; }

        public Device Heater { get; }

        public Device Refrigerator { get; }

        public Device KitchenLight { get; }

        public Device BedroomLight { get; }

        public Device SittingRoomLight { get; }

        public HomeDevices()
        {
            TV = new Device(110, icon: "fas fa-tv");
            Heater = new Device(500, icon: "fas fa-fire");
            Refrigerator = new Device(300, icon: "fas fa-snowflake");
            KitchenLight = new Device(40, icon: "fas fa-lightbulb");
            BedroomLight = new Device(10, icon: "fas fa-bed");
            SittingRoomLight = new Device(80, icon: "fas fa-couch");
        }

        public Dictionary<string, Device> Devices => new Dictionary<string, Device> {
            {"TV",TV },
            {"Heater",Heater },
            {"Refrigerator",Refrigerator },
            {"Kitchen Light",KitchenLight },
            {"Bedroom Light",BedroomLight },
            {"Sitting Room Light",SittingRoomLight },
        };
    }
}
