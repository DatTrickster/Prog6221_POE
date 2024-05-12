using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketManager
{
    class Program
    {
        static Dictionary<int, string> tickets = new Dictionary<int, string>();
        static Queue<int> ticketQueue = new Queue<int>();
        static Stack<Action> undoStack = new Stack<Action>();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Create Ticket");
                Console.WriteLine("2. Process Ticket");
                Console.WriteLine("3. Undo Action");
                Console.WriteLine("4. View Tickets");
                Console.WriteLine("5. Search Ticket");
                Console.WriteLine("6. Modify Ticket");
                Console.WriteLine("7. Sort Tickets");
                Console.WriteLine("8. Display Sorted Tickets");
                Console.WriteLine("9. Exit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateTicket();
                        break;
                    case "2":
                        ProcessTicket();
                        break;
                    case "3":
                        UndoAction();
                        break;
                    case "4":
                        ViewTickets();
                        break;
                    case "5":
                        SearchTicket();
                        break;
                    case "6":
                        ModifyTicket();
                        break;
                    case "7":
                        SortTickets();
                        break;
                    case "8":
                        DisplaySortedTickets();
                        break;
                    case "9":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void CreateTicket()
        {
            Console.Write("Enter ticket description: ");
            string description = Console.ReadLine();

            int ticketNumber = GenerateTicketNumber();

            tickets.Add(ticketNumber, description);
            ticketQueue.Enqueue(ticketNumber);

            undoStack.Push(() =>
            {
                tickets.Remove(ticketNumber);
                ticketQueue.Dequeue();
            });

            Console.WriteLine($"Ticket created. Ticket number: {ticketNumber}");
        }

        static void ProcessTicket()
        {
            if (ticketQueue.Count == 0)
            {
                Console.WriteLine("No tickets to process.");
                return;
            }

            int ticketNumber = ticketQueue.Dequeue();

            undoStack.Push(() => ticketQueue.Enqueue(ticketNumber));

            Console.WriteLine($"Ticket {ticketNumber} processed.");
        }

        static void UndoAction()
        {
            if (undoStack.Count == 0)
            {
                Console.WriteLine("No actions to undo.");
                return;
            }

            Action undoAction = undoStack.Pop();
            undoAction();

            Console.WriteLine("Last action undone.");
        }

        static void ViewTickets()
        {
            if (tickets.Count == 0)
            {
                Console.WriteLine("No tickets to display.");
                return;
            }

            Console.WriteLine("Tickets:");
            foreach (var ticket in tickets)
            {
                Console.WriteLine($"Ticket Number: {ticket.Key}, Description: {ticket.Value}");
            }
        }

        static void SearchTicket()
        {
            Console.Write("Enter ticket number to search: ");
            int ticketNumber = int.Parse(Console.ReadLine());

            if (tickets.ContainsKey(ticketNumber))
            {
                Console.WriteLine($"Ticket Number: {ticketNumber}, Description: {tickets[ticketNumber]}");
            }
            else
            {
                Console.WriteLine("Ticket not found.");
            }
        }

        static void ModifyTicket()
        {
            Console.Write("Enter ticket number to modify: ");
            int ticketNumber = int.Parse(Console.ReadLine());

            if (tickets.ContainsKey(ticketNumber))
            {
                Console.Write("Enter new description: ");
                string newDescription = Console.ReadLine();
                tickets[ticketNumber] = newDescription;

                Console.WriteLine($"Ticket {ticketNumber} modified.");
            }
            else
            {
                Console.WriteLine("Ticket not found.");
            }
        }

        static void SortTickets()
        {
            Console.WriteLine("Sort by:");
            Console.WriteLine("1. Ticket Number");
            Console.WriteLine("2. Description");
            Console.Write("Select an option: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    tickets = tickets.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                    Console.WriteLine("Tickets sorted by ticket number.");
                    break;
                case "2":
                    tickets = tickets.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                    Console.WriteLine("Tickets sorted by description.");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        static void DisplaySortedTickets()
        {
            if (tickets.Count == 0)
            {
                Console.WriteLine("No tickets to display.");
                return;
            }

            ViewTickets();
        }

        static int GenerateTicketNumber()
        {
            // Simple implementation, replace with your own logic for generating unique ticket numbers
            return tickets.Count + 1;
        }
    }
}
