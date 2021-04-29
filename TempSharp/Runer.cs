namespace TempSharp
{
	public class Runer
    {
        public void Run() 
        {
            string fileName = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharp\\input\\all_param_correct.txt";

            Human first = null; Human[] dataBase = null;

            FileReader.ReadHumenTXT(fileName, ref first, ref dataBase);

            CupleMaker cupleMaker = new CupleMaker();

            fileName = "C:\\Users\\Alex\\source\\repos\\TempSharp\\TempSharp\\output\\all_param_correct.txt";

            using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(fileName)) 
            {
                streamWriter.WriteLine(cupleMaker.FindPiar(first, dataBase));
            }
        }
    }
}