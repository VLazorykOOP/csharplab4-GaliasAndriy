namespace Lab4CSharp
{
    public class Trapeze
    {
        private double a, b, h;
        private string color = "";

        public Trapeze(double a, double b, double h, string color)
        {
            this.a = a;
            this.b = b;
            this.h = h;
            this.color = color;
        }

        public Trapeze(double a, double b, double h)
        {
            this.a = a;
            this.b = b;
            this.h = h;
        }

        // Getter/Setter functions
        public double Basis_A
        {
            get { return a; }
            set { a = value; }
        }

        public double Basis_B
        {
            get { return b; }
            set { b = value; }
        }

        public double Height_H
        {
            get { return h; }
            set { h = value; }
        }

        public string GetColor()
        {
            return color;
        }
        public void SetColor(string value)
        {
            color = value;
        }

        // Call class props by index
        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return a;
                    case 1:
                        return b;
                    case 2:
                        return h;
                    default:
                        throw new IndexOutOfRangeException("Invalid index. Must be 0, 1, 2, or 3.");
                }
            }
            set
            {
                if (index == 0)
                    a = value;
                else if (index == 1)
                    b = value;
                else if (index == 2)
                    h = value;
                else
                    throw new IndexOutOfRangeException("Invalid index. Valid indices are 0, 1, and 2.");
            }
        }

        // operation overload
        public static Trapeze operator ++(Trapeze trapeze)
        {
            trapeze.a++;
            trapeze.b++;
            trapeze.h++;
            return trapeze;
        }

        public static Trapeze operator --(Trapeze trapeze)
        {
            trapeze.a--;
            trapeze.b--;
            trapeze.h--;
            return trapeze;
        }

        public static bool operator true(Trapeze trapeze)
        {
            // true if all params > 0 and not null
            return trapeze != null && trapeze.a > 0 && trapeze.b > 0 && trapeze.h > 0;
        }

        public static bool operator false(Trapeze trapeze)
        {
            return trapeze == null || !(trapeze.a > 0 && trapeze.b > 0 && trapeze.h > 0);
        }

        public static Trapeze operator *(Trapeze trapeze, int scalar)
        {
            trapeze.a *= scalar;
            trapeze.b *= scalar;
            trapeze.h *= scalar;
            return trapeze;
        }

        // object to string
        public static implicit operator string(Trapeze trapeze)
        {
            return $"[a: {trapeze.a}, b: {trapeze.b}, h: {trapeze.h}, color: {trapeze.color}]";
        }

        public double CalculatePerimeter()
        {
            return a + b + 2 * Math.Sqrt(Math.Pow((b - a) / 2, 2) + h * h);
        }

        public double CalculateArea()
        {
            return 0.5 * (a + b) * h;
        }

        public bool IsSquare
        {
            get { return a == b; }
        }

        public static explicit operator Trapeze(string str)
        {
            //"SideA,SideB,Color"
            string[] parts = str.Split(',');
            if (parts.Length != 3)
                throw new FormatException("Invalid format for Trapeze string conversion.");
            double a, b, h;
            if (!double.TryParse(parts[0], out a) || !double.TryParse(parts[1], out b) || !double.TryParse(parts[2], out h))
                throw new FormatException("Invalid format for Trapeze string conversion.");
            return new Trapeze(a, b, h);
        }
    }
}