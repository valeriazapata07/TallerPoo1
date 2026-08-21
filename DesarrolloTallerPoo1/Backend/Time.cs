using System;

namespace Backend
{
    public class Time
    {
        private int _hour;
        private int _minute;
        private int _second;
        private int _millisecond;

        public Time() { _hour = 0; _minute = 0; _second = 0; _millisecond = 0; }
        public Time(int hour) { ValidateHour(hour); _hour = hour; }
        public Time(int hour, int minute) { ValidateHour(hour); ValidateMinute(minute); _hour = hour; _minute = minute; }
        public Time(int hour, int minute, int second) { ValidateHour(hour); ValidateMinute(minute); ValidateSecond(second); _hour = hour; _minute = minute; _second = second; }
        public Time(int hour, int minute, int second, int millisecond) { ValidateHour(hour); ValidateMinute(minute); ValidateSecond(second); ValidateMillisecond(millisecond); _hour = hour; _minute = minute; _second = second; _millisecond = millisecond; }

        public int ToMilliseconds() => (_hour * 3600000) + (_minute * 60000) + (_second * 1000) + _millisecond;
        public int ToSeconds() => (_hour * 3600) + (_minute * 60) + _second + (_millisecond / 1000);
        public int ToMinutes() => (_hour * 60) + _minute + (_second / 60);

        public Time Add(Time other)
        {
            int totalMs = this.ToMilliseconds() + other.ToMilliseconds();
            int msPerDay = 86400000;
            totalMs %= msPerDay;

            int hours = totalMs / 3600000;
            totalMs %= 3600000;
            int minutes = totalMs / 60000;
            totalMs %= 60000;
            int seconds = totalMs / 1000;
            int milliseconds = totalMs % 1000;

            return new Time(hours, minutes, seconds, milliseconds);
        }

        public override string ToString()
        {
            string period = _hour >= 12 ? "PM" : "AM";
            int displayHour = _hour % 12;
            return $"{displayHour:D2}:{_minute:D2}:{_second:D2}.{_millisecond:D3} {period}";
        }

        private void ValidateHour(int h) { if (h < 0 || h > 23) throw new ArgumentException($"The hour: {h}, is not valid."); }
        private void ValidateMinute(int m) { if (m < 0 || m > 59) throw new ArgumentException($"The minute: {m}, is not valid."); }
        private void ValidateSecond(int s) { if (s < 0 || s > 59) throw new ArgumentException($"The second: {s}, is not valid."); }
        private void ValidateMillisecond(int ms) { if (ms < 0 || ms > 999) throw new ArgumentException($"The millisecond: {ms}, is not valid."); }
    }
}