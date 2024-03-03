namespace Lab4CSharp
{
    public class VectorFloat
    {
        protected float[] FArray; // array
        protected uint n; // vector size
        protected int codeError; 
        protected static uint num_vec; // number of vectors

        public VectorFloat()
        {
            FArray = new float[1];
            n = 1;
            codeError = 0;
            num_vec++;
        }

        public VectorFloat(uint size)
        {
            FArray = new float[size];
            n = size;
            codeError = 0;
            num_vec++;
        }

        public VectorFloat(uint size, short initValue)
        {
            FArray = new float[size];
            n = size;
            codeError = 0;
            for (int i = 0; i < size; i++)
            {
                FArray[i] = initValue;
            }
            num_vec++;
        }

        ~VectorFloat()
        {
            Console.WriteLine("Vector destroyed");
        }

        // Methods
        public void InputData()
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter element {i + 1}: ");
                string input = Console.ReadLine();
                if (float.TryParse(input, out float value))
                {
                    FArray[i] = value;
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter a valid float value.");
                    i--;
                }
            }
        }

        public string OutputData()
        {
            string outputData = "Vector elements:";
            for (int i = 0; i < n; i++)
            {
                outputData += $" {FArray[i]}";
            }
            return outputData;
        }

        public void AssignValueAsParam(float value)
        {
            for (int i = 0; i < n; i++)
            {
                FArray[i] = value;
            }
        }

        public static uint GetNumVectorsOfType()
        {
            return num_vec;
        }

        public uint Size => n;

        public int CodeError
        {
            get { return codeError; }
            set { codeError = value; }
        }

        // Indexator
        public float this[int index]
        {
            get
            {
                if (index < 0 || index >= n)
                {
                    codeError = 1;
                    return 0;
                }
                else
                {
                    return FArray[index];
                }
            }
            set
            {
                if (index < 0 || index >= n)
                {
                    codeError = 1;
                }
                else
                {
                    FArray[index] = value;
                }
            }
        }

        // Unary Operations
        public static VectorFloat operator ++(VectorFloat vector)
        {
            for (int i = 0; i < vector.n; i++)
            {
                vector.FArray[i]++;
            }
            return vector;
        }

        public static VectorFloat operator --(VectorFloat vector)
        {
            for (int i = 0; i < vector.n; i++)
            {
                vector.FArray[i]--;
            }
            return vector;
        }

        public static bool operator true(VectorFloat vector)
        {
            return vector.n != 0 && !vector.FArray.All(element => element == 0);
        }

        public static bool operator false(VectorFloat vector)
        {
            return vector.n == 0 || vector.FArray.All(element => element == 0);
        }

        public static bool operator !(VectorFloat vector)
        {
            return vector.Size != 0;
        }

        public static VectorFloat operator ~(VectorFloat vector)
        {
            for (int i = 0; i < vector.n; i++)
            {
                vector.FArray[i] = ~Convert.ToInt32(vector.FArray[i]);
            }
            return vector;
        }

        // Binary Arithmetic Operations
        public static VectorFloat operator +(VectorFloat vector1, VectorFloat vector2)
        {
            if (vector1.n != vector2.n)
            {
                throw new ArgumentException("Vector dimensions must be the same for addition.");
            }

            VectorFloat result = new VectorFloat(vector1.n);
            for (int i = 0; i < vector1.n; i++)
            {
                result.FArray[i] = vector1.FArray[i] + vector2.FArray[i];
            }
            return result;
        }

        public static VectorFloat operator -(VectorFloat vector1, VectorFloat vector2)
        {
            if (vector1.n != vector2.n)
            {
                throw new ArgumentException("Vector dimensions must be the same for addition.");
            }

            VectorFloat result = new VectorFloat(vector1.n);
            for (int i = 0; i < vector1.n; i++)
            {
                result.FArray[i] = vector1.FArray[i] - vector2.FArray[i];
            }
            return result;
        }

        public static VectorFloat operator *(VectorFloat vector1, VectorFloat vector2)
        {
            if (vector1.n != vector2.n)
            {
                throw new ArgumentException("Vector dimensions must be the same for addition.");
            }

            VectorFloat result = new VectorFloat(vector1.n);
            for (int i = 0; i < vector1.n; i++)
            {
                result.FArray[i] = vector1.FArray[i] * vector2.FArray[i];
            }
            return result;
        }

        public static VectorFloat operator /(VectorFloat vector1, VectorFloat vector2)
        {
            if (vector1.n != vector2.n)
            {
                throw new ArgumentException("Vector dimensions must be the same for addition.");
            }

            VectorFloat result = new VectorFloat(vector1.n);
            for (int i = 0; i < vector1.n; i++)
            {
                result.FArray[i] = vector1.FArray[i] / vector2.FArray[i];
            }
            return result;
        }

        public static VectorFloat operator %(VectorFloat vector1, VectorFloat vector2)
        {
            if (vector1.n != vector2.n)
            {
                throw new ArgumentException("Vector dimensions must be the same for addition.");
            }

            VectorFloat result = new VectorFloat(vector1.n);
            for (int i = 0; i < vector1.n; i++)
            {
                result.FArray[i] = vector1.FArray[i] % vector2.FArray[i];
            }
            return result;
        }


        public static VectorFloat operator +(VectorFloat vector, float scalar)
        {
            VectorFloat result = new VectorFloat(vector.n);
            for (int i = 0; i < vector.n; i++)
            {
                result.FArray[i] = vector.FArray[i] + scalar;
            }
            return result;
        }

        public static VectorFloat operator -(VectorFloat vector, float scalar)
        {
            VectorFloat result = new VectorFloat(vector.n);
            for (int i = 0; i < vector.n; i++)
            {
                result.FArray[i] = vector.FArray[i] - scalar;
            }
            return result;
        }

        public static VectorFloat operator *(VectorFloat vector, float scalar)
        {
            VectorFloat result = new VectorFloat(vector.n);
            for (int i = 0; i < vector.n; i++)
            {
                result.FArray[i] = vector.FArray[i] * scalar;
            }
            return result;
        }
        
        public static VectorFloat operator /(VectorFloat vector, float scalar)
        {
            VectorFloat result = new VectorFloat(vector.n);
            for (int i = 0; i < vector.n; i++)
            {
                result.FArray[i] = vector.FArray[i] / scalar;
            }
            return result;
        }
        
        public static VectorFloat operator %(VectorFloat vector, float scalar)
        {
            VectorFloat result = new VectorFloat(vector.n);
            for (int i = 0; i < vector.n; i++)
            {
                result.FArray[i] = vector.FArray[i] % scalar;
            }
            return result;
        }

        // Bitwise Binary Operations
        public static VectorFloat operator |(VectorFloat vector1, VectorFloat vector2)
        {
            if (vector1.n != vector2.n)
            {
                throw new ArgumentException("Vector dimensions must be the same for bitwise OR.");
            }

            VectorFloat result = new VectorFloat(vector1.n);
            for (int i = 0; i < vector1.n; i++)
            {
                result.FArray[i] = (byte)vector1.FArray[i] | (byte)vector2.FArray[i];
            }
            return result;
        }

        public static VectorFloat operator |(VectorFloat vector, byte scalar)
        {
            VectorFloat result = new VectorFloat(vector.n);
            for (int i = 0; i < vector.n; i++)
            {
                result.FArray[i] = (byte)vector.FArray[i] | scalar;
            }
            return result;
        }

        public static VectorFloat operator ^(VectorFloat vector, byte scalar)
        {
            VectorFloat result = new VectorFloat(vector.n);
            for (int i = 0; i < vector.n; i++)
            {
                result.FArray[i] = (byte)vector.FArray[i] ^ scalar;
            }
            return result;
        }

        public static VectorFloat operator &(VectorFloat vector1, VectorFloat vector2)
        {
            if (vector1.n != vector2.n)
            {
                throw new ArgumentException("Vector dimensions must be the same for bitwise AND.");
            }

            VectorFloat result = new VectorFloat(vector1.n);
            for (int i = 0; i < vector1.n; i++)
            {
                result.FArray[i] = (byte)vector1.FArray[i] & (byte)vector2.FArray[i];
            }
            return result;
        }

        public static VectorFloat operator &(VectorFloat vector, byte scalar)
        {
            VectorFloat result = new VectorFloat(vector.n);
            for (int i = 0; i < vector.n; i++)
            {
                result.FArray[i] = (byte)vector.FArray[i] & scalar;
            }
            return result;
        }

        // public static VectorFloat operator >>(VectorFloat vector1, VectorFloat vector2)
        // {
        //     if (vector1.n != vector2.n)
        //     {
        //         throw new ArgumentException("Vector dimensions must be the same for bitwise right shift.");
        //     }

        //     VectorFloat result = new VectorFloat(vector1.n);
        //     for (int i = 0; i < vector1.n; i++)
        //     {
        //         result.FArray[i] = (byte)vector1.FArray[i] >> (int)vector2.FArray[i];
        //     }
        //     return result;
        // }

        // public static VectorFloat operator >>(VectorFloat vector, uint scalar)
        // {
        //     VectorFloat result = new VectorFloat(vector.n);
        //     for (int i = 0; i < vector.n; i++)
        //     {
        //         result.FArray[i] = (byte)vector.FArray[i] >> (int)scalar;
        //     }
        //     return result;
        // }

        // public static VectorFloat operator <<(VectorFloat vector1, VectorFloat vector2)
        // {
        //     if (vector1.n != vector2.n)
        //     {
        //         throw new ArgumentException("Vector dimensions must be the same for bitwise left shift.");
        //     }

        //     VectorFloat result = new VectorFloat(vector1.n);
        //     for (int i = 0; i < vector1.n; i++)
        //     {
        //         result.FArray[i] = (byte)vector1.FArray[i] << (int)vector2.FArray[i];
        //     }
        //     return result;
        // }

        // public static VectorFloat operator <<(VectorFloat vector, uint scalar)
        // {
        //     VectorFloat result = new VectorFloat(vector.n);
        //     for (int i = 0; i < vector.n; i++)
        //     {
        //         result.FArray[i] = (byte)vector.FArray[i] << (int)scalar;
        //     }
        //     return result;
        // }
    }
}
