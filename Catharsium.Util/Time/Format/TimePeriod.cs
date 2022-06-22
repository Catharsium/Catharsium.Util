using System;

namespace Catharsium.Util.Time.Format
{
    public class TimePeriod
    {
        public int Years { get; set; }

        private int weeks;
        public int Weeks
        {
            get {
                return this.weeks;
            }
            set {
                this.Years += value / 52;
                this.weeks = value % 52;
            }
        }

        private int days;
        public int Days
        {
            get {
                return this.days;
            }
            set {
                this.Weeks += value / 7;
                this.days = value % 7;
            }
        }

        private int hours;
        public int Hours
        {
            get {
                return this.hours;
            }
            set {
                this.Days += value / 24;
                this.hours = value % 24;
            }
        }

        private int minutes;
        public int Minutes
        {
            get {
                return this.minutes;
            }
            set {
                this.Hours += value / 60;
                this.minutes = value % 60;
            }
        }

        private int seconds;
        public int Seconds
        {
            get {
                return this.seconds;
            }
            set {
                this.Minutes += value / 60;
                this.seconds = value % 60;
            }
        }


        public TimePeriod() { }


        public TimePeriod(int years, int weeks, int days, int hours, int minutes, int seconds)
        {
            this.Years = years;
            this.Weeks = weeks;
            this.Days = days;
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }


        public static TimePeriod operator +(TimePeriod a, TimePeriod b)
            => new(
                a.Years + b.Years,
                a.Weeks + b.Weeks,
                a.Days + b.Days,
                a.Hours + b.Hours,
                a.Minutes + b.Minutes,
                a.Seconds + b.Seconds);


        public TimeSpan ToTimeSpan()
        {
            return new TimeSpan(this.Years * 365 + this.Weeks * 7 + this.Days, this.Hours, this.Minutes, this.Seconds);
        }


        public override string ToString()
        {
            return $"{this.Years}y {this.Weeks}w {this.Days}d {this.Hours}h {this.Minutes}m {this.Seconds}s";
        }
    }
}