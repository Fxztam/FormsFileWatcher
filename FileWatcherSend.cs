using System;
/**
 * Demo : Sends 'Action' and 'EOwatch' to FormsFileWatcher.
 * Friedhold Matz - 04.11.2017
 *
 */
 
namespace FileWrite
{
    class Program
    {
        static void Main(string[] args)
        {

            // --- sending a action from C# to Oracle Forms       
            string ACTION2FORMS = "C#2FORMS|Hello OracleForms|P2";
            System.IO.File.WriteAllText(@"C:\Users\fmatz\AppData\Local\Temp\formswatch\forms\Action2Forms.watch", ACTION2FORMS);

            // .. consuming the action ..
            System.Threading.Thread.Sleep(2000);

            // --- sending 'End of Watching..' from C# to Oracle Forms  
            string[] EOWATCHING = { "Watcher finished from C# ", DateTime.Now.ToString(), "FINISHED." };
            System.IO.File.WriteAllLines(@"C:\Users\fmatz\AppData\Local\Temp\formswatch\forms\EOwatchService.watch", EOWATCHING);

            // console end.
            Console.WriteLine("\n--- EO Watching. <enter> ---");
            Console.ReadKey();
        }
    }
}
