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
            // Create vectors
            VectorFloat vector1 = new VectorFloat(3);
            VectorFloat vector2 = new VectorFloat(3, 2);
            VectorFloat scalarVector = new VectorFloat(3, 5);

            // Input data for vector1
            Console.WriteLine("Enter values for vector1:");
            vector1.InputData();
            Console.WriteLine();

            // Display vectors
            Console.WriteLine($"Vector1: {vector1.OutputData()}");
            Console.WriteLine($"Vector2: {vector2.OutputData()}");

            // Display scalarVector
            Console.WriteLine($"Scalar Vector: {scalarVector.OutputData()}");

            // Unary Operations
            Console.WriteLine("\nUnary Operations:");
            Console.WriteLine($"++vector1: {(++vector1).OutputData()}");
            Console.WriteLine($"--vector1: {(--vector1).OutputData()}");
            Console.WriteLine($"Vector1++: {vector1++.OutputData()}");
            Console.WriteLine($"Vector1--: {vector1--.OutputData()}");

            // Logical Operations
            Console.WriteLine("\nLogical Operations:");
            Console.WriteLine($"!Vector1: {!vector1}");
            Console.WriteLine($"!vector2: {!vector2}");

            // Bitwise NOT
            Console.WriteLine("\nBitwise NOT:");
            Console.WriteLine($"~vector1: {(~vector1).OutputData()}");

            // Binary Arithmetic Operations
            Console.WriteLine($"Current state of vector1 {vector1.OutputData()}");
            Console.WriteLine("\nBinary Arithmetic Operations:");
            VectorFloat sum = vector1 + vector2;
            VectorFloat substraction = vector1 - vector2;
            VectorFloat multiply = vector1 * vector2;
            VectorFloat division = vector1 / vector2;
            VectorFloat remain = vector1 % vector2;

            Console.WriteLine($"Sum: {sum.OutputData()}");
            Console.WriteLine($"Substraction: {substraction.OutputData()}");
            Console.WriteLine($"Product: {multiply.OutputData()}");
            Console.WriteLine($"Division: {division.OutputData()}");
            Console.WriteLine($"Remain %: {remain.OutputData()}");

            Console.WriteLine($"vector1 + scalarVector: {(vector1 + scalarVector).OutputData()}");
            Console.WriteLine($"vector1 - scalarVector: {(vector1 - scalarVector).OutputData()}");
            Console.WriteLine($"vector1 * scalarVector: {(vector1 * scalarVector).OutputData()}");
            Console.WriteLine($"vector1 / scalarVector: {(vector1 / scalarVector).OutputData()}");
            Console.WriteLine($"vector1 % scalarVector: {(vector1 % scalarVector).OutputData()}");

            // Bitwise Binary Operations
            Console.WriteLine("\nBitwise Binary Operations:");
            Console.WriteLine($"vector1 | vector2: {(vector1 | vector2).OutputData()}");
            Console.WriteLine($"vector1 | 5: {(vector1 | 5).OutputData()}");

            // Properties
            Console.WriteLine("\nProperties:");
            Console.WriteLine($"Number of vectors of type VectorFloat: {VectorFloat.GetNumVectorsOfType()}");
            Console.WriteLine($"Vector1 Size: {vector1.Size}");
            Console.WriteLine($"Vector1 CodeError: {vector1.CodeError}");
        }

        public static void Task3()
        {
            // Create matrices
            FloatMatrix matrix1 = new FloatMatrix(2, 2, 2.5f);
            FloatMatrix matrix2 = new FloatMatrix(2, 2, 1.5f);

            // Display matrices
            Console.WriteLine("Matrix 1:");
            matrix1.DisplayMatrix();
            Console.WriteLine();

            Console.WriteLine("Matrix 2:");
            matrix2.DisplayMatrix();
            Console.WriteLine();

            // Perform operations
            FloatMatrix resultSum = matrix1 + matrix2;
            FloatMatrix resultSubtract = matrix1 - matrix2;
            FloatMatrix resultMultiply = matrix1 * matrix2;
            FloatMatrix resultDivide = matrix1 / matrix2;

            // Display results
            Console.WriteLine("Result of Addition:");
            resultSum.DisplayMatrix();
            Console.WriteLine();

            Console.WriteLine("Result of Subtraction:");
            resultSubtract.DisplayMatrix();
            Console.WriteLine();

            Console.WriteLine("Result of Multiplication:");
            resultMultiply.DisplayMatrix();
            Console.WriteLine();

            Console.WriteLine("Result of Division:");
            resultDivide.DisplayMatrix();
            Console.WriteLine();

            // Test other operations
            FloatMatrix negationMatrix = !matrix1;
            Console.WriteLine("Negation of Matrix 1:");
            negationMatrix.DisplayMatrix();
            Console.WriteLine();

            FloatMatrix bitwiseNotMatrix = ~matrix1;
            Console.WriteLine("Bitwise NOT of Matrix 1:");
            bitwiseNotMatrix.DisplayMatrix();
            Console.WriteLine();

            // Test comparison operations
            Console.WriteLine("Matrix 1 == Matrix 2: " + (matrix1 == matrix2));
            Console.WriteLine("Matrix 1 != Matrix 2: " + (matrix1 != matrix2));
            Console.WriteLine("Matrix 1 > Matrix 2: " + (matrix1 > matrix2));
            Console.WriteLine("Matrix 1 >= Matrix 2: " + (matrix1 >= matrix2));
            Console.WriteLine("Matrix 1 < Matrix 2: " + (matrix1 < matrix2));
            Console.WriteLine("Matrix 1 <= Matrix 2: " + (matrix1 <= matrix2));

            // Display the number of matrices created
            Console.WriteLine("Number of matrices created: " + FloatMatrix.GetNumMatrices());
        }
    }
}