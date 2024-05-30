using Part2_ST10228343;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            ShowMainMenu();
        }
    }

    static void ShowMainMenu()
    {
        Console.Beep();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        // make screen bigger to see message
        string InitWelcomeMessage = @"


██╗    ██╗███████╗██╗      ██████╗ ██████╗ ███╗   ███╗███████╗    ████████╗ ██████╗     ████████╗██╗  ██╗███████╗                   
██║    ██║██╔════╝██║     ██╔════╝██╔═══██╗████╗ ████║██╔════╝    ╚══██╔══╝██╔═══██╗    ╚══██╔══╝██║  ██║██╔════╝                   
██║ █╗ ██║█████╗  ██║     ██║     ██║   ██║██╔████╔██║█████╗         ██║   ██║   ██║       ██║   ███████║█████╗                     
██║███╗██║██╔══╝  ██║     ██║     ██║   ██║██║╚██╔╝██║██╔══╝         ██║   ██║   ██║       ██║   ██╔══██║██╔══╝                     
╚███╔███╔╝███████╗███████╗╚██████╗╚██████╔╝██║ ╚═╝ ██║███████╗       ██║   ╚██████╔╝       ██║   ██║  ██║███████╗                   
 ╚══╝╚══╝ ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝       ╚═╝    ╚═════╝        ╚═╝   ╚═╝  ╚═╝╚══════╝                   
██████╗ ███████╗ ██████╗██╗██████╗ ███████╗     
██╔══██╗██╔════╝██╔════╝██║██╔══██╗██╔════╝   
██████╔╝█████╗  ██║     ██║██████╔╝█████╗      
██╔══██╗██╔══╝  ██║     ██║██╔═══╝ ██╔══╝      
██║  ██║███████╗╚██████╗██║██║     ███████╗    
╚═╝  ╚═╝╚══════╝ ╚═════╝╚═╝╚═╝     ╚══════╝
                                                                                                                                    

";
        Console.WriteLine(InitWelcomeMessage);
        Console.WriteLine("===================================");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("1. Add a new recipe");
        Console.WriteLine("2. View existing recipes");
        Console.WriteLine("3. Delete a recipe");
        Console.WriteLine("4. Clear all recipes");
        Console.WriteLine("5. Exit");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("===================================");

        Console.Write("Enter your choice: ");
        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                RecipeHandler.AddRecipe();
                break;
            case "2":
                RecipeHandler.ViewRecipes();
                break;
            case "3":
                RecipeHandler.DeleteRecipe();
                break;
            case "4":
                RecipeHandler.ClearAllRecipes();
                break;
            case "5":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
}
