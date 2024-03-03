namespace Lab4CSharp;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("1. Trapeze");
        Console.WriteLine("2. ");
        Console.WriteLine("3. ");

        try
        {
            Console.Write("Choose a task 1-3: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    TasksUsage.Task1();
                    break;
                case 2:
                    TasksUsage.Task2();
                    break;
                case 3:
                    TasksUsage.Task3();
                    break;
                default:
                    Console.WriteLine("Task not found.");
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}