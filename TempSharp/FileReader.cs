using System;
using System.Text;

namespace TempSharp
{
    public static class FileReader
    {
        public static void ReadHumenTXT(string fileName, ref Human first, ref Human[] dataBase)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(fileName, Encoding.Default);

            first = null;
            
            try
            {
                first = new Human(sr.ReadLine());
            }
            catch (Exception) { }

            dataBase = new Human[int.Parse(sr.ReadLine())];

            for (int i = 0; i < dataBase.Length; i++)
            {
                try
                {
                    dataBase[i] = new Human(sr.ReadLine());
                }
                catch (Exception) { }
            }

            sr.Close();
        }

        public static string ReadStringTXT(string fileName)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(fileName, Encoding.Default);

            string line = sr.ReadLine();

            sr.Close();

            return line;
        }
    }
}
