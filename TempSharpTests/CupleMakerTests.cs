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
            Human first = null; Human[] database = null;

            string file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\all_param_correct.txt";

            FileReader.ReadHumenTXT(file, ref first, ref database);

            file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\all_param_correct.txt";

            Assert.AreEqual(FileReader.ReadStringTXT(file), cupleMaker.FindPiar(first, database));
        }

        [TestMethod()]
        public void FindPiarTest_FirstNull()
        {
            Human first = null; Human[] database = null;

            string file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\first_null.txt";

            FileReader.ReadHumenTXT(file, ref first, ref database);

            file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\first_null.txt";

            Assert.AreEqual(FileReader.ReadStringTXT(file), cupleMaker.FindPiar(first, database));
        }

        [TestMethod()]
        public void FindPiarTest_DifferentName()
        {
            Human first = null; Human[] database = null;

            string file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\diferent_name.txt";

            FileReader.ReadHumenTXT(file, ref first, ref database);

            file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\diferent_name.txt";

            Assert.AreEqual(FileReader.ReadStringTXT(file), cupleMaker.FindPiar(first, database));
        }

        [TestMethod()]
        public void FindPiarTest_DifferentBirthday()
        {
            Human first = null; Human[] database = null;

            string file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\diferent_birthday.txt";

            FileReader.ReadHumenTXT(file, ref first, ref database);

            file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\diferent_birthday.txt";

            Assert.AreEqual(FileReader.ReadStringTXT(file), cupleMaker.FindPiar(first, database));
        }

        [TestMethod()]
        public void FindPiarTest_Different_5_Years_FirstOlder()
        {
            Human first = null; Human[] database = null;
            string file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\5_years_first_older.txt";

            FileReader.ReadHumenTXT(file, ref first, ref database);

            DateTime today = DateTime.Today.AddYears(-40).AddDays(1); // день рождения завтра
            first.MyBirthday = today;

            // партнёрша младше
            today = today.AddYears(6).AddDays(-1); // день рождения сегодня
            database[0].MyBirthday = today;

            Assert.AreEqual(database[0].ToString(), cupleMaker.FindPiar(first, database));

            database[0].MyBirthday = today.AddDays(1); // завтра

            file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\5_years_first_older2.txt";

            Assert.AreEqual(FileReader.ReadStringTXT(file), cupleMaker.FindPiar(first, database));
        }

        [TestMethod()]
        public void FindPiarTest_Different_5_Years_SecondOlder()
        {
            Human first = null; Human[] database = null;
            string file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\5_years_first_older.txt";

            FileReader.ReadHumenTXT(file, ref first, ref database);

            DateTime today = DateTime.Today.AddYears(-40); // день рождения завтра
            first.MyBirthday = today;

            // партнёрша младше
            today = today.AddYears(-6).AddDays(1); // день рождения завтра
            database[0].MyBirthday = today;

            Assert.AreEqual(database[0].ToString(), cupleMaker.FindPiar(first, database));

            database[0].MyBirthday = today.AddDays(-1); // завтра
            file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\5_years_first_older2.txt";

            Assert.AreEqual(FileReader.ReadStringTXT(file), cupleMaker.FindPiar(first, database));
        }

        [TestMethod()]
        public void FindPiarTest_18_YearsFirst()
        {
            Human first = null; Human[] database = null;

            string file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\18_years1.txt";

            FileReader.ReadHumenTXT(file, ref first, ref database);

            DateTime _18yers = DateTime.Today.AddYears(-18);
            first.MyBirthday = _18yers;

            file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\18_years1.txt";

            Assert.AreEqual(FileReader.ReadStringTXT(file), cupleMaker.FindPiar(first, database));

            first.MyBirthday = _18yers.AddDays(1);

            file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\18_years2.txt";

            Assert.AreEqual(FileReader.ReadStringTXT(file), cupleMaker.FindPiar(first, database));
        }

        [TestMethod()]
        public void FindPiarTest_DifferentGender()
        {
            Human first = null; Human[] database = null;

            string file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\diferent_gender1.txt";

            FileReader.ReadHumenTXT(file, ref first, ref database);

            file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\diferent_gender1.txt";

            Assert.AreEqual(FileReader.ReadStringTXT(file), cupleMaker.FindPiar(first, database));

            /////////////////////////////////////////////////////
            
            file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\diferent_gender2.txt";

            FileReader.ReadHumenTXT(file, ref first, ref database);

            file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\diferent_gender2.txt";

            Assert.AreEqual(FileReader.ReadStringTXT(file), cupleMaker.FindPiar(first, database));
        }

        [TestMethod()]
        public void FindPiarTest_MaleGender()
        {
            Human first = null; Human[] database = null;

            string file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\male_gender.txt";

            FileReader.ReadHumenTXT(file, ref first, ref database);

            file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\male_gender.txt";

            Assert.AreEqual(FileReader.ReadStringTXT(file), cupleMaker.FindPiar(first, database));
        }

        [TestMethod()]
        public void FindPiarTest_DifferentCity()
        {
            Human first = null; Human[] database = null;

            string file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\diferent_city1.txt";

            FileReader.ReadHumenTXT(file, ref first, ref database);

            file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\diferent_city1.txt";

            Assert.AreEqual(FileReader.ReadStringTXT(file), cupleMaker.FindPiar(first, database));

            file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\input\\diferent_city2.txt";

            FileReader.ReadHumenTXT(file, ref first, ref database);

            file = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharpTests\\output\\diferent_city2.txt";

            Assert.AreEqual(FileReader.ReadStringTXT(file), cupleMaker.FindPiar(first, database));

        }
    }
}