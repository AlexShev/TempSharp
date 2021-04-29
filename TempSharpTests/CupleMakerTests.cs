using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace TempSharp.Tests
{
    [TestClass()]
    public class CupleMakerTests
    {
        private CupleMaker cupleMaker = new CupleMaker();

        [TestMethod()]
        public void FindPiarTest_AllParamCorrect()
        {
            Assert.AreEqual(ReadStringTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\all_param_correct.txt"), 
                cupleMaker.FindPiar(ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\first_param.txt")[0], 
                                    ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\all_param_correct.txt")));
        }

        [TestMethod()]
        public void FindPiarTest_FirstNull()
        {
            Assert.AreEqual(ReadStringTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\Error.txt"),
                cupleMaker.FindPiar(null, 
                                    ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\all_param_correct.txt")));
        }

        [TestMethod()]
        public void FindPiarTest_DifferentName()
        {
            Assert.AreEqual(ReadStringTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\diferent_name.txt"),
                cupleMaker.FindPiar(ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\first_param.txt")[0],
                                    ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\diferent_name.txt")));
        }

        [TestMethod()]
        public void FindPiarTest_DifferentBirthday()
        {
            Assert.AreEqual(ReadStringTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\diferent_birthday.txt"),
                cupleMaker.FindPiar(ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\first_param.txt")[0],
                                    ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\diferent_birthday.txt")));
        }

        [TestMethod()]
        public void FindPiarTest_Different_5_Years_FirstOlder()
        {
            Human first = ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\first_param.txt")[0];
            Human[] dataBase = ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\5_years_first_older.txt");

            DateTime today = DateTime.Today.AddYears(-40).AddDays(1); // день рождения завтра
            first.MyBirthday = today;

            // партнёрша младше
            today = today.AddYears(6).AddDays(-1); // день рождения сегодня
            dataBase[0].MyBirthday = today;

            Assert.AreEqual(dataBase[0].ToString(), cupleMaker.FindPiar(first, dataBase));

            dataBase[0].MyBirthday = today.AddDays(1); // завтра
            Assert.AreEqual(ReadStringTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\5_years_first_older2.txt"),
                cupleMaker.FindPiar(first, dataBase));
        }

        [TestMethod()]
        public void FindPiarTest_Different_5_Years_SecondOlder()
        {
            Human first = ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\first_param.txt")[0];
            Human[] dataBase = ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\5_years_first_older.txt");

            DateTime today = DateTime.Today.AddYears(-40); // день рождения завтра
            first.MyBirthday = today;

            // партнёрша младше
            today = today.AddYears(-6).AddDays(1); // день рождения завтра
            dataBase[0].MyBirthday = today;

            Assert.AreEqual(dataBase[0].ToString(), cupleMaker.FindPiar(first, dataBase));

            dataBase[0].MyBirthday = today.AddDays(-1); // завтра
            Assert.AreEqual(ReadStringTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\5_years_first_older2.txt"),
                cupleMaker.FindPiar(first, dataBase));
        }

        [TestMethod()]
        public void FindPiarTest_18_YearsFirst()
        {
            Human first = ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\first_param.txt")[0];
            Human[] dataBase = ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\18_years1.txt");

            DateTime _18yers = DateTime.Today.AddYears(-18);
            first.MyBirthday = _18yers;

            Assert.AreEqual(ReadStringTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\18_years1.txt"),
                cupleMaker.FindPiar(first, dataBase));

            first.MyBirthday = _18yers.AddDays(1);

            Assert.AreEqual(ReadStringTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\18_years2.txt"),
                cupleMaker.FindPiar(first, dataBase));
        }

        [TestMethod()]
        public void FindPiarTest_DifferentGender()
        {
            Assert.AreEqual(ReadStringTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\diferent_gender1.txt"),
                cupleMaker.FindPiar(ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\first_param.txt")[0],
                                    ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\diferent_gender1.txt")));

            Assert.AreEqual(ReadStringTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\diferent_gender2.txt"),
                cupleMaker.FindPiar(ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\first_param.txt")[0],
                                    ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\diferent_gender2.txt")));
        }

        [TestMethod()]
        public void FindPiarTest_MaleGender()
        {
            Assert.AreEqual(ReadStringTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\male_gender.txt"),
                cupleMaker.FindPiar(ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\first_param.txt")[0],
                                    ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\male_gender.txt")));
        }

        [TestMethod()]
        public void FindPiarTest_DifferentCity()
        {
            Assert.AreEqual(ReadStringTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\diferent_city1.txt"),
                cupleMaker.FindPiar(ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\first_param.txt")[0],
                                    ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\diferent_city1.txt")));

            Assert.AreEqual(ReadStringTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\diferent_city2.txt"),
                cupleMaker.FindPiar(ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\first_param.txt")[0],
                                    ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\diferent_city2.txt")));
        }

        private Human[] ReadHumenTXT(string fileName)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(fileName, Encoding.Default);
            string line = sr.ReadLine();
            
            Human[] humans = new Human[int.Parse(line)];

            for (int i = 0; i < humans.Length; i++)
            {
                try
                {
                    humans[i] = new Human(sr.ReadLine());
                }
                catch (Exception) { }
            }

            sr.Close();

            return humans;
        }

        private string ReadStringTXT(string fileName)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(fileName, Encoding.Default);

            string line = sr.ReadLine();

            sr.Close();

            return line;
        }
    }
}