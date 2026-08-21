using System;

namespace Backend
{
    public class Time
    {
        private int _hour;
        private int _minute;
        private int _second;
        private int _millisecond;

        public Time()
        {
            _hour = 0;
            _minute = 0;
            _second = 0;
            _millisecond = 0;
        }

        public Time(int hour)
        {
            ValidateHour(hour);
            _hour = hour;
        }

        public Time(int hour, int minute)
        {
            ValidateHour(hour);
            ValidateMinute(minute);
            _hour = hour;
            _minute = minute;
        }

        public Time(int hour, int minute, int second)
        {
            ValidateHour(hour);
            ValidateMinute(minute);
            ValidateSecond(second);
            _hour = hour;
            _minute = minute;
            _second = second;
        }

        public Time(int hour, int minute, int second, int millisecond)
        {
            ValidateHour(hour);
            ValidateMinute(minute);
            ValidateSecond(second);
            ValidateMillisecond(millisecond);
            _hour = hour;
            _minute = minute;
            _second = second;
            _millisecond = millisecond;
        }

        private void ValidateHour(int hour)
        {
            if (hour < 0 || hour > 23)
                throw new ArgumentException($"The hour: {hour}, is not valid.");
        }

        private void ValidateMinute(int minute)
        {
            if (minute < 0 || minute > 59)
                throw new ArgumentException($"The minute: {minute}, is not valid.");
        }

        private void ValidateSecond(int second)
        {
            if (second < 0 || second > 59)
                throw new ArgumentException($"The second: {second}, is not valid.");
        }

        private void ValidateMillisecond(int millisecond)
        {
            if (millisecond < 0 || millisecond > 999)
                throw new ArgumentException($"The millisecond: {millisecond}, is not valid.");
        }

        public int GetHour() => _hour;
        public int GetMinute() => _minute;
        public int GetSecond() => _second;
        public int GetMillisecond() => _millisecond;

        public int ToMilliseconds()
        {
            return (_hour * 3600000) + (_minute * 60000) + (_second * 1000) + _millisecond;
        }

        public int ToSeconds()
        {
            return ToMilliseconds() / 1000;
        }

        public int ToMinutes()
        {
            return ToMilliseconds() / 60000;
        }

        public bool IsOtherDay(Time other)
        {
            long totalMs = (long)this.ToMilliseconds() + other.ToMilliseconds();
            return totalMs >= 86400000L;
        }

        public Time Add(Time other)
        {
            long totalMs = (long)this.ToMilliseconds() + other.ToMilliseconds();
            long msPerDay = 86400000L;

            totalMs %= msPerDay;
            if (totalMs < 0) totalMs += msPerDay;

            int hours = (int)(totalMs / 3600000);
            totalMs %= 3600000;
            int minutes = (int)(totalMs / 60000);
            totalMs %= 60000;
            int seconds = (int)(totalMs / 1000);
            int milliseconds = (int)(totalMs % 1000);

            return new Time(hours, minutes, seconds, milliseconds);
        }

        public override string ToString()
        {
            int displayHour = _hour % 12;
            if (displayHour == 0 && _hour == 0) displayHour = 0;
            else if (displayHour == 0) displayHour = 12;

            string period = _hour >= 12 ? "PM" : "AM";

            return $"{displayHour:00}:{_minute:00}:{_second:00}.{_millisecond:000} {period}";
        }
    }
}