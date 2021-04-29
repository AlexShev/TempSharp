using System;

namespace TempSharp
{
    public class Human
    {
        public string SurName { get; private set; }
        public string FirstName { get; private set; }
        public DateTime MyBirthday { get; set; }
        public Gender MyGender { get; private set; }
        public string MyCity { get; private set; }
        public string MyPhoneNumber { get; private set; }
        public ZodiacSign MyZodiacSign { get; private set; }
        public СompatibilityByName MyCompatibilityByName { get; private set; }
        public int MyAge
        {
            get
            {
                DateTime today = DateTime.Today;

                int age = today.Year - MyBirthday.Year;

                if (MyBirthday > today.AddYears(-age))
                    age--;

                if (age < 0 || age > 100)
                {
                    throw new System.Exception("Not a live");
                }

                return age;
            }
        }

        public Human(string param)
        {
            var temp = param.Split(";");

            SetParam(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5]);
        }

        public Human(string secondName, string firstName, string sex, string myBirthday, string myCity, string myPhoneNumber)
        {
            SetParam(secondName, firstName, sex, myBirthday, myCity, myPhoneNumber);
        }

        private void SetParam(string secondName, string firstName, string sex, string myBirthday, string myCity, string myPhoneNumber) 
        {
            SurName = StandartView.WordEr(secondName);
            FirstName = StandartView.WordEr(firstName);
            MyCity = StandartView.WordEr(myCity);
            MyGender = GenderSeter.StringToGender(sex);
            MyBirthday = StandartView.ConverteStringToDate(myBirthday);
            MyPhoneNumber = StandartView.IsPhoneNumber(myPhoneNumber);
            MyZodiacSign = new ZodiacSign(MyBirthday);
            MyCompatibilityByName = new СompatibilityByName(FirstName);
        }

        public override string ToString()
        {
            return SurName + ";" + FirstName + ";" + MyGender + ";" + MyBirthday.ToShortDateString() + ";" + MyCity + ";" + MyPhoneNumber;
        }
    }
}