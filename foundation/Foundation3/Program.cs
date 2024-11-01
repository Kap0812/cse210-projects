using System;
using System.Collections.Generic;

namespace FitnessCenter
{
    // Base class
    public abstract class Activity
    {
        private DateTime _date;
        private int _minutes;

        public Activity(DateTime date, int minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        public virtual double GetDistance() => 0;
        public virtual double GetSpeed() => 0;
        public virtual double GetPace() => 0;

        public string GetSummary()
        {
            return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min) - " +
                   $"Distance: {GetDistance():0.0} {GetDistanceUnit()}, " +
                   $"Speed: {GetSpeed():0.0} {GetSpeedUnit()}, " +
                   $"Pace: {GetPace():0.0} min per {GetDistanceUnit()}";
        }

        protected abstract string GetDistanceUnit();
        protected abstract string GetSpeedUnit();
    }

    // Derived class for Running
    public class Running : Activity
    {
        private double _distance; // in miles

        public Running(DateTime date, int minutes, double distance) : base(date, minutes)
        {
            _distance = distance;
        }

        public override double GetDistance() => _distance;
        public override double GetSpeed() => (GetDistance() / base.GetDistance()) * 60;
        public override double GetPace() => base.GetDistance() / GetDistance();

        protected override string GetDistanceUnit() => "miles";
        protected override string GetSpeedUnit() => "mph";
    }

    // Derived class for Cycling
    public class Cycling : Activity
    {
        private double _speed; // in mph

        public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
        {
            _speed = speed;
        }

        public override double GetDistance() => (_speed * base.GetDistance()) / 60; // miles
        public override double GetSpeed() => _speed;
        public override double GetPace() => 60 / _speed;

        protected override string GetDistanceUnit() => "miles";
        protected override string GetSpeedUnit() => "mph";
    }

    // Derived class for Swimming
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
        {
            _laps = laps;
        }

        public override double GetDistance() => (_laps * 50) / 1000.0; // in km
        public override double GetSpeed() => (GetDistance() / base.GetDistance()) * 60; // kph
        public override double GetPace() => base.GetDistance() / GetDistance();

        protected override string GetDistanceUnit() => "km";
        protected override string GetSpeedUnit() => "kph";
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to hold activities
            List<Activity> activities = new List<Activity>
            {
                new Running(new DateTime(2022, 11, 3), 30, 3.0),
                new Cycling(new DateTime(2022, 11, 4), 45, 15.0),
                new Swimming(new DateTime(2022, 11, 5), 30, 20)
            };

            // Display summaries for each activity
            foreach (var activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
