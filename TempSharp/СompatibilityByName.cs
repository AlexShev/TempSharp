namespace TempSharp
{
    public class СompatibilityByName
    {
        private static readonly int[,] _arr =
        {
            {5,8,3,8,3,9,7,7,9},
            {8,3,7,5,4,6,6,8,5},
            {3,7,3,5,7,6,2,5,6},
            {8,5,5,3,8,5,7,3,8},
            {3,4,7,8,9,9,8,3,8},
            {9,6,6,5,9,5,6,9,5},
            {7,6,2,7,8,6,4,2,9},
            {7,8,5,3,3,9,2,6,5},
            {9,5,6,8,8,5,9,5,6}
        };

        public int MyNamber { get; private set; }

        public СompatibilityByName(in string name)
        {
            var temp = 0;

            foreach (var c in name)
            {
                temp += ((char.ToLower(c) - 33) % 9);
            }

            MyNamber = DigitsSum(temp);

            if (MyNamber < 1 || MyNamber > 9)
                throw new System.Exception("Не возможно обработать слова - возможно только английские и русские буквы");
        }

        public int IsAPaer(in СompatibilityByName person) => _arr[MyNamber - 1, person.MyNamber - 1];

        private static int DigitsSum(int number)
        {
            while (number > 9)
            {
                int temp = 0;
                while (number > 0)
                {
                    temp +=( number % 10);
                    number /= 10;
                }
                number = temp;
            }

            return number;
        }
    }
}