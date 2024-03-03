namespace Lab4CSharp
{
    public class FloatMatrix
    {
        private float[,] FMArray;
        private uint n, m;
        private int codeError;
        private static int num_mf;

        public FloatMatrix()
        {
            n = 1;
            m = 1;
            FMArray = new float[n, m];
            codeError = 0;
            num_mf++;
        }

        // Constructor with 2 params
        public FloatMatrix(uint rows, uint columns)
        {
            n = rows;
            m = columns;
            FMArray = new float[n, m];
            codeError = 0;
            num_mf++;
        }

        // Constructor with 3 params
        public FloatMatrix(uint rows, uint columns, float initValue)
        {
            n = rows;
            m = columns;
            FMArray = new float[n, m];
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    FMArray[i, j] = initValue;
                }
            }
            codeError = 0;
            num_mf++;
        }

        // Destructor
        ~FloatMatrix()
        {
            Console.WriteLine("FloatMatrix destroyed");
        }

        // Input elements from keyboard
        public void InputMatrix()
        {
            Console.WriteLine("Enter matrix elements:");
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    Console.Write($"Enter element at position ({i + 1}, {j + 1}): ");
                    if (!float.TryParse(Console.ReadLine(), out FMArray[i, j]))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid float.");
                        j--; // Repeat the same column
                    }
                }
            }
        }

        public void DisplayMatrix()
        {
            Console.WriteLine("Matrix elements:");
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    Console.Write($"{FMArray[i, j]} \t");
                }
                Console.WriteLine();
            }
        }

        // Assign value to array
        public void AssignValue(float value)
        {
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    FMArray[i, j] = value;
                }
            }
        }

        // Static method which counts num of matrices
        public static int GetNumMatrices()
        {
            return num_mf;
        }

        // Prop for getting size of matrix (readonly)
        public Tuple<uint, uint> Dimensions
        {
            get { return new Tuple<uint, uint>(n, m); }
        }

        public int ErrorCode
        {
            get { return codeError; }
            set { codeError = value; }
        }

        // Indexator with 2 indexes
        public float this[uint i, uint j]
        {
            get
            {
                if (i < n && j < m)
                    return FMArray[i, j];
                else
                {
                    codeError = -1;
                    return 0; // Or throw an exception
                }
            }
            set
            {
                if (i < n && j < m)
                    FMArray[i, j] = value;
                else
                    codeError = -1;
            }
        }

        // indexator with single index
        public float this[int k]
        {
            get
            {
                if (k >= 0 && k < n * m)
                    return FMArray[k / m, k % m];
                else
                {
                    codeError = -1;
                    return 0; // Or throw an exception
                }
            }
            set
            {
                if (k >= 0 && k < n * m)
                    FMArray[k / m, k % m] = value;
                else
                    codeError = -1;
            }
        }

        // Overload operations ++ and --
        public static FloatMatrix operator ++(FloatMatrix matrix)
        {
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    matrix.FMArray[i, j]++;
                }
            }
            return matrix;
        }

        public static FloatMatrix operator --(FloatMatrix matrix)
        {
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    matrix.FMArray[i, j]--;
                }
            }
            return matrix;
        }

        public static bool operator true(FloatMatrix matrix)
        {
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    if (matrix.FMArray[i, j] == 0)
                        return false;
                }
            }
            return matrix.n != 0 && matrix.m != 0;
        }

        public static bool operator false(FloatMatrix matrix)
        {
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    if (matrix.FMArray[i, j] != 0)
                        return false;
                }
            }
            return matrix.n == 0 || matrix.m == 0;
        }

        // Overload unary operations
        public static FloatMatrix operator !(FloatMatrix matrix)
        {
            return new FloatMatrix(matrix.n, matrix.m, matrix.n == 0 || matrix.m == 0 ? 1 : 0);
        }

        public static FloatMatrix operator ~(FloatMatrix matrix)
        {
            FloatMatrix result = new FloatMatrix(matrix.n, matrix.m);
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = ~BitConverter.SingleToInt32Bits(matrix.FMArray[i, j]);
                }
            }
            return result;
        }

        // Ariphmethic operations with 2 matrices
        public static FloatMatrix operator +(FloatMatrix matrix1, FloatMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                matrix1.codeError = -1;
                return matrix1;
            }

            FloatMatrix result = new FloatMatrix(matrix1.n, matrix1.m);
            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return result;
        }

        public static FloatMatrix operator -(FloatMatrix matrix1, FloatMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                matrix1.codeError = -1;
                return matrix1;
            }

            FloatMatrix result = new FloatMatrix(matrix1.n, matrix1.m);
            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }
            return result;
        }

        public static FloatMatrix operator *(FloatMatrix matrix1, FloatMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                matrix1.codeError = -1;
                return matrix1;
            }

            FloatMatrix result = new FloatMatrix(matrix1.n, matrix1.m);
            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    result[i, j] = matrix1[i, j] * matrix2[i, j];
                }
            }
            return result;
        }

        public static FloatMatrix operator /(FloatMatrix matrix1, FloatMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                matrix1.codeError = -1;
                return matrix1;
            }

            FloatMatrix result = new FloatMatrix(matrix1.n, matrix1.m);
            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    result[i, j] = matrix1[i, j] / matrix2[i, j];
                }
            }
            return result;
        }

        public static FloatMatrix operator %(FloatMatrix matrix1, FloatMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                matrix1.codeError = -1;
                return matrix1;
            }

            FloatMatrix result = new FloatMatrix(matrix1.n, matrix1.m);
            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    result[i, j] = matrix1[i, j] % matrix2[i, j];
                }
            }
            return result;
        }

        // Ariphmethic operations with matrix and scalar
        public static FloatMatrix operator +(FloatMatrix matrix, float scalar)
        {
            FloatMatrix result = new FloatMatrix(matrix.n, matrix.m);
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] + scalar;
                }
            }
            return result;
        }

        public static FloatMatrix operator -(FloatMatrix matrix, float scalar)
        {
            FloatMatrix result = new FloatMatrix(matrix.n, matrix.m);
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] - scalar;
                }
            }
            return result;
        }

        public static FloatMatrix operator *(FloatMatrix matrix, float scalar)
        {
            FloatMatrix result = new FloatMatrix(matrix.n, matrix.m);
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] * scalar;
                }
            }
            return result;
        }

        public static FloatMatrix operator /(FloatMatrix matrix, float scalar)
        {
            FloatMatrix result = new FloatMatrix(matrix.n, matrix.m);
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] / scalar;
                }
            }
            return result;
        }

        public static FloatMatrix operator %(FloatMatrix matrix, float scalar)
        {
            FloatMatrix result = new FloatMatrix(matrix.n, matrix.m);
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] % scalar;
                }
            }
            return result;
        }

        // Overload binary operations
        public static FloatMatrix operator |(FloatMatrix matrix1, FloatMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                matrix1.codeError = -1;
                return matrix1;
            }

            FloatMatrix result = new FloatMatrix(matrix1.n, matrix1.m);
            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    int int1 = BitConverter.SingleToInt32Bits(matrix1[i, j]);
                    int int2 = BitConverter.SingleToInt32Bits(matrix2[i, j]);
                    result[i, j] = BitConverter.Int32BitsToSingle(int1 | int2);
                }
            }
            return result;
        }

        public static FloatMatrix operator |(FloatMatrix matrix, float scalar)
        {
            FloatMatrix result = new FloatMatrix(matrix.n, matrix.m);
            int scalarInt = BitConverter.SingleToInt32Bits(scalar);
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    int int1 = BitConverter.SingleToInt32Bits(matrix[i, j]);
                    result[i, j] = BitConverter.Int32BitsToSingle(int1 | scalarInt);
                }
            }
            return result;
        }

        public static FloatMatrix operator ^(FloatMatrix matrix1, FloatMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                matrix1.codeError = -1;
                return matrix1;
            }

            FloatMatrix result = new FloatMatrix(matrix1.n, matrix1.m);
            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    int int1 = BitConverter.SingleToInt32Bits(matrix1[i, j]);
                    int int2 = BitConverter.SingleToInt32Bits(matrix2[i, j]);
                    result[i, j] = BitConverter.Int32BitsToSingle(int1 ^ int2);
                }
            }
            return result;
        }

        public static FloatMatrix operator ^(FloatMatrix matrix, float scalar)
        {
            FloatMatrix result = new FloatMatrix(matrix.n, matrix.m);
            int scalarInt = BitConverter.SingleToInt32Bits(scalar);
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    int int1 = BitConverter.SingleToInt32Bits(matrix[i, j]);
                    result[i, j] = BitConverter.Int32BitsToSingle(int1 ^ scalarInt);
                }
            }
            return result;
        }

        public static FloatMatrix operator &(FloatMatrix matrix1, FloatMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                matrix1.codeError = -1;
                return matrix1;
            }

            FloatMatrix result = new FloatMatrix(matrix1.n, matrix1.m);
            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    int int1 = BitConverter.SingleToInt32Bits(matrix1[i, j]);
                    int int2 = BitConverter.SingleToInt32Bits(matrix2[i, j]);
                    result[i, j] = BitConverter.Int32BitsToSingle(int1 & int2);
                }
            }
            return result;
        }

        public static FloatMatrix operator &(FloatMatrix matrix, float scalar)
        {
            FloatMatrix result = new FloatMatrix(matrix.n, matrix.m);
            int scalarInt = BitConverter.SingleToInt32Bits(scalar);
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    int int1 = BitConverter.SingleToInt32Bits(matrix[i, j]);
                    result[i, j] = BitConverter.Int32BitsToSingle(int1 & scalarInt);
                }
            }
            return result;
        }

        public static FloatMatrix operator >>(FloatMatrix matrix, int shift)
        {
            FloatMatrix result = new FloatMatrix(matrix.n, matrix.m);
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    int int1 = BitConverter.SingleToInt32Bits(matrix[i, j]);
                    result[i, j] = BitConverter.Int32BitsToSingle(int1 >> shift);
                }
            }
            return result;
        }

        // public static FloatMatrix operator >>(FloatMatrix matrix, ushort shift)
        // {
        //     FloatMatrix result = new FloatMatrix(matrix.n, matrix.m);
        //     for (uint i = 0; i < matrix.n; i++)
        //     {
        //         for (uint j = 0; j < matrix.m; j++)
        //         {
        //             int int1 = BitConverter.SingleToInt32Bits(matrix[i, j]);
        //             result[i, j] = BitConverter.Int32BitsToSingle(int1 >> shift);
        //         }
        //     }
        //     return result;
        // }

        public static FloatMatrix operator <<(FloatMatrix matrix1, int shift)
        {
            FloatMatrix result = new FloatMatrix(matrix1.n, matrix1.m);
            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    int int1 = BitConverter.SingleToInt32Bits(matrix1[i, j]);
                    result[i, j] = BitConverter.Int32BitsToSingle(int1 << shift);
                }
            }
            return result;
        }

        // public static FloatMatrix operator <<(FloatMatrix matrix1, ushort shift)
        // {
        //     FloatMatrix result = new FloatMatrix(matrix1.n, matrix1.m);
        //     for (uint i = 0; i < matrix1.n; i++)
        //     {
        //         for (uint j = 0; j < matrix1.m; j++)
        //         {
        //             int int1 = BitConverter.SingleToInt32Bits(matrix1[i, j]);
        //             result[i, j] = BitConverter.Int32BitsToSingle(int1 << shift);
        //         }
        //     }
        //     return result;
        // }

        // Overload equation operations
        public static bool operator ==(FloatMatrix matrix1, FloatMatrix matrix2)
        {
            if (ReferenceEquals(matrix1, matrix2))
                return true;

            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
                return false;

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    if (matrix1[i, j] != matrix2[i, j])
                        return false;
                }
            }

            return true;
        }

        public static bool operator !=(FloatMatrix matrix1, FloatMatrix matrix2)
        {
            return !(matrix1 == matrix2);
        }

        public static bool operator >(FloatMatrix matrix1, FloatMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                matrix1.codeError = -1;
                return false;
            }

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    if (matrix1[i, j] <= matrix2[i, j])
                        return false;
                }
            }

            return true;
        }

        public static bool operator >=(FloatMatrix matrix1, FloatMatrix matrix2)
        {
            return matrix1 == matrix2 || matrix1 > matrix2;
        }

        public static bool operator <(FloatMatrix matrix1, FloatMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                matrix1.codeError = -1;
                return false;
            }

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    if (matrix1[i, j] >= matrix2[i, j])
                        return false;
                }
            }

            return true;
        }

        public static bool operator <=(FloatMatrix matrix1, FloatMatrix matrix2)
        {
            return matrix1 == matrix2 || matrix1 < matrix2;
        }
    }
}