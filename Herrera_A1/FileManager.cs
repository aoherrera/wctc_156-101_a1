namespace Herrera_A1
{
	public class FileManager
	{
        public void Write(string file)
        {
            if (!File.Exists(file))
            {
                StreamWriter sw_header = new StreamWriter(file, true);
                sw_header.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");
                sw_header.Close();
            }

            StreamWriter sw = new StreamWriter(file, true);
            var ticketWatchers = new List<string>();

            Console.WriteLine("Enter the ticket ID:");
            var ticketID = Console.ReadLine();

            Console.WriteLine("Enter the ticket status:");
            var ticketStatus = Console.ReadLine();

            Console.WriteLine("Enter the ticket summary:");
            var ticketSummary = Console.ReadLine();

            Console.WriteLine("Enter the ticket priority:");
            var ticketPriority = Console.ReadLine();

            Console.WriteLine("Enter the name of the ticket submitter:");
            var ticketSubmitter = Console.ReadLine();

            Console.WriteLine("Enter the name of the individual the ticket is assigned to:");
            var ticketAssignedTo = Console.ReadLine();

            Console.WriteLine("Enter the name of an individual watching this ticket:");
            var ticketWatcher = Console.ReadLine();
            ticketWatchers.Add(ticketWatcher);

            string anotherWatcher;
            do
            {
                Console.WriteLine($"Would you like to add another watcher to ticket {ticketID} (Y/N)?");
                anotherWatcher = Console.ReadLine().ToUpper();
                if (anotherWatcher == "Y")
                {
                    Console.WriteLine("Enter the name of an individual watching this ticket:");
                    ticketWatcher = Console.ReadLine();
                    ticketWatchers.Add(ticketWatcher);

                }
                else if (anotherWatcher == "N")
                {
                    break;
                }
                else
                {
                        Console.WriteLine("Please enter either 'Y' for yes or 'N' for no.");
                }
            } while (anotherWatcher != "N");

            if (ticketWatchers.Count() != 1)
            {
                ticketWatcher = null;
                for (int i = 0; i < ticketWatchers.Count(); i++)
                {
                    if (i != ticketWatchers.Count()-1)
                    {
                        ticketWatcher += ticketWatchers[i] + "|";
                    }
                    else
                    {
                        ticketWatcher += ticketWatchers[i];
                    }
                }
            }

            sw.WriteLine($"{ticketID},{ticketStatus},{ticketSummary},{ticketPriority}," +
                $"{ticketSubmitter},{ticketAssignedTo},{ticketWatcher}");

            sw.Close();
        }

        public void Read(string file)
        {
            if (File.Exists(file))
            {
                StreamReader sr = new StreamReader(file);
                //StreamReader reads one line at a time.
                sr.ReadLine();
                while (sr.EndOfStream != true)
                {
                    var line = sr.ReadLine();
                    Console.WriteLine($"{line}");
                }
                Console.WriteLine("\n");

            }
            else
            {
                Console.WriteLine("File does not exist.\n");
            }
        }
    }
}
