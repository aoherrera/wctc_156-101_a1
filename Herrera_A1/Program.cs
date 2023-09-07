namespace Herrera_A1
{
    public class Program
    {
        public static void Main()
        {
            FileManager fileManager = new FileManager();

            string filename = "tickets.csv";

            //menu
            string menu;
            do
            {
                Console.WriteLine("1. Read data from file.");
                Console.WriteLine("2. Write data to file.");
                Console.WriteLine("3. Exit\n");
                menu = Console.ReadLine();

                if (menu == "1")
                {
                    fileManager.Read(filename);
                }
                else if (menu == "2")
                {
                    fileManager.Write(filename);
                }
            } while (menu != "3");
        }
    }
}