namespace TempSharp
{
    class Program
    {
        static void Main()
        {
            //            Runer runer = new Runer();

            //            runer.Run();

            CupleMaker cupleMaker = new CupleMaker();

            Human[] human = { new Human("Hannula;Ad;female;01.05.1975;London;7(515)001-43-55") };

            cupleMaker.FindPiar(new Human("Chan;Dominic;male;29.04.1981;London;7(073)031-37-27"),human);
        }
    }
}