namespace Lab4CSharp
{
    public class TasksUsage
    {
        public static void Task1()
        {
            Trapeze[] trapezes = new Trapeze[]
            {
                new Trapeze(10.5, 7, 5, "cyan"),
                new Trapeze(7, 5, 3, "mojo_green"),
                new Trapeze(5, 5, 5, "black"),
            };

            Logger.PrintAllTrapezes(trapezes);
            
            Trapeze trapezeFromString = (Trapeze)"6, 7, 4"; // without color option
            Logger.PrintTrapezeFromString(trapezeFromString);
        }

        public static void Task2()
        {
            
        }

        public static void Task3()
        {

        }
    }
}