namespace Lab4CSharp
{
    // relies on Single Responsibility
    class Logger 
    {
        public static void PrintTrapeze(Trapeze trapeze)
        {
            string trapezeAsString = trapeze;
            Console.WriteLine($"\u001b[32mTrapeze as string:\u001b[0m {trapezeAsString}");

            double roundedPerimeter = Math.Round(trapeze.CalculatePerimeter(), 2);

            Console.WriteLine($"Perimeter: {roundedPerimeter}");
            Console.WriteLine($"Area: {trapeze.CalculateArea()}");
            Console.WriteLine($"Is Square: {trapeze.IsSquare}");
            Console.WriteLine($"Color: {trapeze.GetColor()}");
            Console.WriteLine($"Get Class props by index: a: {trapeze[0]}, b: {trapeze[1]}, h: {trapeze[2]}");
            trapeze++;
            Console.WriteLine($"\u001b[33mOverload++ |\u001b[0m a: {trapeze[0]}, b: {trapeze[1]}, h: {trapeze[2]}");
            trapeze--;
            Console.WriteLine($"\u001b[35mOverload-- |\u001b[0m a: {trapeze[0]}, b: {trapeze[1]}, h: {trapeze[2]}");
            trapeze *= 4;
            Console.WriteLine($"\u001b[36mScalar * |\u001b[0m a: {trapeze[0]}, b: {trapeze[1]}, h: {trapeze[2]}");

            Console.WriteLine();
        }

        public static void PrintAllTrapezes(Trapeze[] trapezes)
        {
            foreach (var trapeze in trapezes)
            {
                PrintTrapeze(trapeze);
            }
        }

        public static void PrintTrapezeFromString(Trapeze trap)
        {
            Console.WriteLine("Printing trapeze from string.");
            Console.WriteLine($"a: {trap[0]}, b: {trap[1]}, h: {trap[2]}");
        }
    }
}