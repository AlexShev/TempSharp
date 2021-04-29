using System;

namespace TempSharp
{
    public class ZodiacSign
    {
        public enum ZodiacSigns
        {
            aries,
            taurus,
            twins,
            cancer,
            leo,
            virgo,
            libra,
            scorpio,
            sagittarius,
            capricorn,
            aquarius,
            pisces,
        }

        public ZodiacSigns MyZodiacSign { get; }

        public ZodiacSign(in DateTime birthday)
        {
            var year = birthday.Year;

            if ((new DateTime(year, 12, 23) <= birthday) || (birthday <= new DateTime(year, 1, 20)))
            {
                MyZodiacSign = ZodiacSigns.capricorn;
            }
            else if (birthday <= new DateTime(year, 2, 19))
            {
                MyZodiacSign = ZodiacSigns.aquarius;
            }
            else if (birthday <= new DateTime(year, 3, 20))
            {
                MyZodiacSign = ZodiacSigns.pisces;
            }
            else if (birthday <= new DateTime(year, 4, 20))
            {
                MyZodiacSign = ZodiacSigns.aries;
            }
            else if (birthday <= new DateTime(year, 5, 21))
            {
                MyZodiacSign = ZodiacSigns.taurus;
            }
            else if (birthday <= new DateTime(year, 6, 21))
            {
                MyZodiacSign = ZodiacSigns.twins;
            }
            else if (birthday <= new DateTime(year, 7, 22))
            {
                MyZodiacSign = ZodiacSigns.cancer;
            }
            else if (birthday <= new DateTime(year, 8, 21))
            {
                MyZodiacSign = ZodiacSigns.leo;
            }
            else if (birthday <= new DateTime(year, 9, 23))
            {
                MyZodiacSign = ZodiacSigns.virgo;
            }
            else if (birthday <= new DateTime(year, 10, 23))
            {
                MyZodiacSign = ZodiacSigns.libra;
            }
            else if (birthday <= new DateTime(year, 11, 22))
            {
                MyZodiacSign = ZodiacSigns.scorpio;
            }
            else if (birthday <= new DateTime(year, 12, 22))
            {
                MyZodiacSign = ZodiacSigns.sagittarius;
            }
        }

        public int IsAPaer(in ZodiacSign zodiacSignPaer)
        {
            var temp = Math.Abs(MyZodiacSign - zodiacSignPaer.MyZodiacSign);

            temp = (temp <= 6) ? temp : 12 - temp;

            if (temp == 0 || temp == 6)
            {
                return 3;
            }
            else if (temp == 2)
            {
                return 7;
            }
            else if (temp == 4)
            {
                return 11;
            }

            return 0;
        }

        public override string ToString() => MyZodiacSign.ToString();
    }
}