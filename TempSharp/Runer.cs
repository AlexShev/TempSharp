using System;
using System.Text;

namespace TempSharp
{
	public class Runer
    {
        public void Run() 
        {
            string fileName = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharp\\input\\all_param_correct.txt";

            System.IO.StreamReader sr = new System.IO.StreamReader(fileName, Encoding.Default);

            Human first = null;
            try {
                first = new Human(sr.ReadLine());
            }
            catch (Exception) { }

            Human[] dataBase = new Human[int.Parse(sr.ReadLine())];

            for (int i = 0; i < dataBase.Length; i++)
            {
                try {
                    dataBase[i] = new Human(sr.ReadLine());
                }
                catch (Exception) { }
            }

            sr.Close();

            CupleMaker cupleMaker = new CupleMaker();

            fileName = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharp\\output\\all_param_correct.txt";

            using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(fileName)) 
            {
                streamWriter.WriteLine(cupleMaker.FindPiar(first, dataBase));
            }
        }

		private Human ReadHuman()
		{
			var data = Console.ReadLine().Split(";");

			return new Human(secondName: data[0], firstName: data[1], sex: data[2],
				myBirthday: data[3], myCity: data[4], myPhoneNumber: data[5]);
		}

        private void SetHuman(ref Human human)
        {
            try
			{
                human = ReadHuman();
			}
            catch (Exception) { }
		}
    }
}