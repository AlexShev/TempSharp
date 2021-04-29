using System;
using System.Collections.Generic;

namespace TempSharp
{
    public enum Gender
    {
        female,
        masculine
    }

    public class GenderSeter
    {
        public static Gender StringToGender(string sex) =>
            (sex == "female") ? Gender.female : (sex == "male") ? Gender.masculine : throw new Exception("Пол не определён");
    }
}