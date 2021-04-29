using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace TempSharp.Tests
{
    [TestClass()]
    public class CupleMakerTests
    {
        private CupleMaker cupleMaker = new CupleMaker();
        private Human first = new Human("Chan;Dominic;male;13.09.1961;London;7(073)031-37-27");

        [TestMethod()]
        public void FindPiarTest_AllParamCorrect()
        {
            Human[] dataBase = ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests1\\all_param_correct.txt");

            Assert.AreEqual("Hannula;Venla;female;31.01.1966;London;7(515)001-43-55", cupleMaker.FindPiar(first, dataBase));
        }

        [TestMethod()]
        public void FindPiarTest_FirstNull()
        {
            Human[] dataBase = ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests1\\all_param_correct.txt");

            Assert.AreEqual("Error 1", cupleMaker.FindPiar(null, dataBase));
        }

        [TestMethod()]
        public void FindPiarTest_DifferentName()
        {
            Human[] dataBase = ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests1\\diferent_name.txt");

            Assert.AreEqual("Hannula;Ad;female;31.01.1966;London;7(515)001-43-55", cupleMaker.FindPiar(first, dataBase));
        }

        [TestMethod()]
        public void FindPiarTest_DifferentBirthday()
        {
            Human[] dataBase = ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests1\\diferent_birthday.txt");

            Assert.AreEqual("Hannula;Ad;female;01.05.1966;London;7(515)001-43-55", cupleMaker.FindPiar(first, dataBase));
        }

        [TestMethod()]
        public void FindPiarTest_Different_5_Years_FirstOlder()
        {
            DateTime today = DateTime.Today.AddYears(-40).AddDays(1); // день рождения завтра

            first = new Human($"Chan;Dominic;male;{today.ToShortDateString()};London;7(073)031-37-27");

            // партнёрша младше
            today = today.AddYears(6).AddDays(-1); // день рождения сегодня

            Human[] dataBase = { new Human($"Hannula;Ad;female;{today.ToShortDateString()};London;7(515)001-43-55") };
            Assert.AreEqual($"Hannula;Ad;female;{today.ToShortDateString()};London;7(515)001-43-55", cupleMaker.FindPiar(first, dataBase));

            today = today.AddDays(1); // завтра

            dataBase[0] = new Human($"Hannula;Ad;female;{today.ToShortDateString()};London;7(515)001-43-55");
            Assert.AreEqual("Sorry, try again later", cupleMaker.FindPiar(first, dataBase));
        }

        [TestMethod()]
        public void FindPiarTest_Different_5_Years_SecondOlder()
        {
            // партнёрша старше

            DateTime today = DateTime.Today.AddYears(-40); // день рождения сегодня

            first = new Human($"Chan;Dominic;male;{today.ToShortDateString()};London;7(073)031-37-27");

            // партнёрша младше
            today = today.AddYears(-6).AddDays(1); // день рождения завтра

            Human[] dataBase = { new Human($"Hannula;Ad;female;{today.ToShortDateString()};London;7(515)001-43-55") };

            Assert.AreEqual($"Hannula;Ad;female;{today.ToShortDateString()};London;7(515)001-43-55", cupleMaker.FindPiar(first, dataBase));

            today = today.AddDays(-1); // сегодня

            dataBase[0] = new Human($"Hannula;Ad;female;{today.ToShortDateString()};London;7(515)001-43-55");
            Assert.AreEqual("Sorry, try again later", cupleMaker.FindPiar(first, dataBase));

        }

        [TestMethod()]
        public void FindPiarTest_18_Years()
        {
            DateTime today = DateTime.Today;
            today = today.AddYears(-18);

            first = new Human("Chan;Dominic;male;28.04.2001;London;7(073)031-37-27");
            
            Human[] dataBase = { new Human($"Hannula;Ad;female;{today.ToShortDateString()};London;7(515)001-43-55") };
            Assert.AreEqual($"Hannula;Ad;female;{today.ToShortDateString()};London;7(515)001-43-55", cupleMaker.FindPiar(first, dataBase));

            today = today.AddDays(1);

            dataBase[0] = new Human($"Hannula;Ad;female;{today.ToShortDateString()};London;7(515)001-43-55");
            Assert.AreEqual("Sorry, try again later", cupleMaker.FindPiar(first, dataBase));
        }

        [TestMethod()]
        public void FindPiarTest_DifferentGender()
        {
            Human[] dataBase = ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests1\\diferent_gender1.txt");

            Assert.AreEqual("Hannula;Ad;female;01.05.1966;London;7(515)001-43-55", cupleMaker.FindPiar(first, dataBase));

            dataBase = ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests1\\diferent_gender2.txt");

            Assert.AreEqual("Hannula;Ad;female;01.05.1966;London;7(515)001-43-55", cupleMaker.FindPiar(first, dataBase));
        }

        [TestMethod()]
        public void FindPiarTest_MaleGender()
        {
            Human[] dataBase = ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests1\\male_gender.txt");

            Assert.AreEqual("Sorry, try again later", cupleMaker.FindPiar(first, dataBase));
        }

        [TestMethod()]
        public void FindPiarTest_DifferentCity()
        {
            Human[] dataBase = ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests1\\diferent_city1.txt");

            Assert.AreEqual("Hannula;Ad;female;01.05.1966;London;7(515)001-43-55", cupleMaker.FindPiar(first, dataBase));

            dataBase = ReadHumenTXT("C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests1\\diferent_city1.txt");

            Assert.AreEqual("Hannula;Ad;female;01.05.1966;London;7(515)001-43-55", cupleMaker.FindPiar(first, dataBase));
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
    }
}