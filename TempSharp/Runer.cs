using System;

namespace TempSharp
{
	public class Runer
    {
        public void Run() 
        {
			Human first = null;

			SetHuman(ref first);

			int dataBaseSize = int.Parse(Console.ReadLine());

            Human[] dataBase = new Human [dataBaseSize];

			for (int i = 0; i < dataBaseSize; i++)
            {
				SetHuman(ref dataBase[i]);
            }

			CupleMaker cupleMaker = new CupleMaker();

			Console.WriteLine(cupleMaker.FindPiar(first, dataBase));
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