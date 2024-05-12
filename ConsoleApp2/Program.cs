using System;
using System.Collections.Generic;

namespace SmartHomeEventHandlingSystem
{
    // Event argument classes
    public class MotionDetectedEventArgs : EventArgs
    {
        public int SensorId { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class DoorOpenedEventArgs : EventArgs
    {
        public int SensorId { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class TemperatureChangedEventArgs : EventArgs
    {
        public int SensorId { get; set; }
        public DateTime Timestamp { get; set; }
        public float NewTemperature { get; set; }
    }

    // Event delegates
    public delegate void MotionDetectedEventHandler(object sender, MotionDetectedEventArgs args);
    public delegate void DoorOpenedEventHandler(object sender, DoorOpenedEventArgs args);
    public delegate void TemperatureChangedEventHandler(object sender, TemperatureChangedEventArgs args);

    // Smart home devices
    public class MotionSensor
    {
        public event MotionDetectedEventHandler MotionDetected;

        public void DetectMotion(int sensorId)
        {
            Console.WriteLine($"Motion detected by sensor {sensorId}");
            MotionDetected?.Invoke(this, new MotionDetectedEventArgs { SensorId = sensorId, Timestamp = DateTime.Now });
        }
    }

    public class DoorSensor
    {
        public event DoorOpenedEventHandler DoorOpened;

        public void OpenDoor(int sensorId)
        {
            Console.WriteLine($"Door opened by sensor {sensorId}");
            DoorOpened?.Invoke(this, new DoorOpenedEventArgs { SensorId = sensorId, Timestamp = DateTime.Now });
        }
    }

    public class Thermostat
    {
        public event TemperatureChangedEventHandler TemperatureChanged;

        public void SetTemperature(int sensorId, float newTemperature)
        {
            Console.WriteLine($"Temperature changed by sensor {sensorId} to {newTemperature}°C");
            TemperatureChanged?.Invoke(this, new TemperatureChangedEventArgs { SensorId = sensorId, Timestamp = DateTime.Now, NewTemperature = newTemperature });
        }
    }

    // Central event hub
    public class EventHub
    {
        private MotionSensor motionSensor;
        private DoorSensor doorSensor;
        private Thermostat thermostat;

        public EventHub()
        {
            motionSensor = new MotionSensor();
            doorSensor = new DoorSensor();
            thermostat = new Thermostat();
        }

        public void SimulateEvents()
        {
            // Simulate motion detected event
            motionSensor.MotionDetected += (sender, args) => Console.WriteLine($"Motion detected at {args.Timestamp}");

            // Simulate door opened event
            doorSensor.DoorOpened += (sender, args) => Console.WriteLine($"Door opened at {args.Timestamp}");

            // Simulate temperature changed event
            thermostat.TemperatureChanged += (sender, args) => Console.WriteLine($"Temperature changed to {args.NewTemperature}°C at {args.Timestamp}");

            motionSensor.DetectMotion(1);
            doorSensor.OpenDoor(2);
            thermostat.SetTemperature(3, 25.5f);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EventHub eventHub = new EventHub();
            eventHub.SimulateEvents();
        }
    }
}
