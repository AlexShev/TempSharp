namespace TempSharp
{
    public class CupleMaker
    {
        public string FindPiar(Human first, Human[] dataBase, int maxAgeDiferent = 5) 
        {
            if (first == null)
            {
                return "Error 1";
            }

            Human temp = null;

            int prevscor = 0;


            foreach (var second in dataBase)
            {
                var a = System.Math.Abs(first.MyAge - second.MyAge);

                if (second == null || first.MyAge < 18 || second.MyAge < 18 || first.MyCity != second.MyCity ||
                first.MyGender == second.MyGender || System.Math.Abs(first.MyAge - second.MyAge) > maxAgeDiferent)
                    continue;

                int tempScore = ScoreIsPaerWithoutGenderAndLocalization(first, second);

                if (prevscor < tempScore)
                {
                    prevscor = tempScore;

                    temp = second;
                }
            }

            return temp == null ? "Sorry, try again later" : temp.ToString();
        }

        public int ScoreIsPaerWithoutGenderAndLocalization(Human first, Human second)
        {
            var result = first.MyCompatibilityByName.IsAPaer(second.MyCompatibilityByName);

            result += first.MyZodiacSign.IsAPaer(second.MyZodiacSign);

            return result * 5;
        }
    }
}