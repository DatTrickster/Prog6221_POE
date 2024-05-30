using Part2_ST10228343;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Main program loop, continually shows the main menu
        while (true)
        {
            ShowMainMenu();
        }
    }

    static void ShowMainMenu()
    {
        // Sound a beep and clear the console screen
        Console.Beep();
        Console.Clear();

        // Set the console text color to DarkCyan
        Console.ForegroundColor = ConsoleColor.DarkCyan;

        // Initialize and display a welcome message in ASCII art style
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

        // Display the main menu options
        Console.WriteLine("===================================");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("1. Add a new recipe");
        Console.WriteLine("2. View existing recipes");
        Console.WriteLine("3. Delete a recipe");
        Console.WriteLine("4. Clear all recipes");
        Console.WriteLine("5. Exit");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("===================================");

        // Prompt the user for their choice
        Console.Write("Enter your choice: ");
        string? choice = Console.ReadLine();

        // Execute the corresponding action based on the user's choice
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
                // Inform the user of an invalid choice
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
}
