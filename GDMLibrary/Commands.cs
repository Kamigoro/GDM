/// <summary>
/// This code has been written by Piette Dylan, @Kamigoro on Github
/// Feel free to use it, make comments, contact me or anything.
/// dylan-piette@hotmail.fr
/// </summary>

namespace GDM
{
    public static class Commands
    {
        public static class SignalType
        {
            public const string VOLTAGE = "volt";
            public const string CURRENT = "curr";
            public const string RESISTANCE = "res";
            public const string FOURWIRERESISTANCE = "fres";
            public const string PERIOD = "per";
            public const string CONTINUITY = "con";
            public const string DIODE = "diod";
            public const string THERMOCOUPLE = "temp:tco";
            public const string CAPACITANCE = "cap";

        }

        public static class Function
        {
            public const string DC = "dc";
            public const string AC = "ac";
            public const string DCAC = "dcac";
        }

        public static class Rate
        {
            public const string SLOW = "s";
            public const string MEDIUM = "m";
            public const string FAST = "f";
        }


    }
}