using System;

namespace RationalNumbers
{
    public class RationalNum : IComparable, IEquatable<RationalNum>
    {
        public int Integer { get; set; }
        public int Natural { get; set; }

        public RationalNum() : this(1, 1)
        {
        }
        public RationalNum(int i, int n)
        {
            Integer = i;
            Natural = n;
        }



        public static RationalNum operator +(RationalNum r1, RationalNum r2)
        {
            RationalNum r = new RationalNum();
            r.Integer = r1.Integer * r2.Natural + r2.Integer * r1.Natural;
            r.Natural = r1.Natural * r2.Natural;
            return r;
        }

        public static RationalNum operator -(RationalNum r1, RationalNum r2)
        {
            RationalNum r = new RationalNum();
            r.Integer = r1.Integer * r2.Natural - r2.Integer * r1.Natural;
            r.Natural = r1.Natural * r2.Natural;
            return r;
        }

        public static RationalNum operator *(RationalNum r1, RationalNum r2)
        {
            RationalNum r = new RationalNum();
            r.Integer = r1.Integer * r2.Integer;
            r.Natural = r1.Natural * r2.Natural;
            return r;
        }

        public static RationalNum operator /(RationalNum r1, RationalNum r2)
        {
            RationalNum r = new RationalNum();
            r.Integer = r1.Integer * r2.Natural;
            r.Natural = r1.Natural * r2.Integer;
            return r;
        }

        public static bool operator >(RationalNum r1, RationalNum r2) => ((double)r1.Integer / r2.Natural) > ((double)r2.Integer / r2.Natural);
        public static bool operator <(RationalNum r1, RationalNum r2) => ((double)r1.Integer / r2.Natural) < ((double)r2.Integer / r2.Natural);
        public static bool operator >=(RationalNum r1, RationalNum r2) => ((double)r1.Integer / r2.Natural) >= ((double)r2.Integer / r2.Natural);
        public static bool operator <=(RationalNum r1, RationalNum r2) => ((double)r1.Integer / r2.Natural) <= ((double)r2.Integer / r2.Natural);
        public static bool operator ==(RationalNum r1, RationalNum r2) => ((double)r1.Integer / r1.Natural).Equals((double)r2.Integer / r2.Natural);
        public static bool operator !=(RationalNum r1, RationalNum r2) => !((double)r1.Integer / r1.Natural).Equals((double)r2.Integer / r2.Natural);
        public static bool operator !=(RationalNum r1, int r2) => !((double)r1.Integer / r1.Natural).Equals(r2);
        public static bool operator ==(RationalNum r1, int r2) => ((double)r1.Integer / r1.Natural).Equals(r2);


        public override bool Equals(object obj) => (double)((RationalNum)obj).Integer / ((RationalNum)obj).Natural == (double)this.Integer / this.Natural;
        public override int GetHashCode() => this.GetHashCode();

        public static implicit operator int(RationalNum r) => (int)(r.Integer / r.Natural);
        public static implicit operator double(RationalNum r) => (double)r.Integer / r.Natural;

        bool IEquatable<RationalNum>.Equals(RationalNum other) => (this.Integer == other.Integer && this.Natural == other.Natural);
        int IComparable.CompareTo(object obj)
        {
            if ((this.Integer / this.Natural) > ((RationalNum)obj).Integer / ((RationalNum)obj).Natural)
            {
                return 1;
            }
            if ((this.Integer / this.Natural) < ((RationalNum)obj).Integer / ((RationalNum)obj).Natural)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public string RNumStr()
        {
            return $"{(double)Integer / Natural}";
        }
        public string FractionStr()
        {
            return $"{Integer}/{Natural}";
        }
        public string ShowFull()
        {
            return "Number: " + RNumStr() + "\nFraction: " + FractionStr() + "\n";
        }

        public static RationalNum GetFractionFromStr(string str)
        {
            RationalNum r = new RationalNum();

            try
            {
                string[] array = str.Split('/');

                r.Integer = int.Parse(array[0]);
                r.Natural = int.Parse(array[1]);
            }
            catch
            {
                r.Integer = int.Parse(str);
                r.Natural = 1;
            }

            return r;
        }

        public static RationalNum GetNumberFromStr(double a)
        {
            RationalNum r = new RationalNum();

            int count = -1;
            if (a % 10 == 0)
            {
                r.Integer = (int)a;
                r.Natural = 1;
            }
            else
            {
                for (int i = 0; (float)a % 10 != 0 || Math.Abs(a) < 1; i++)
                {
                    a *= 10;
                    count++;
                }
                a /= 10;
                r.Integer = (int)a;
                r.Natural = (int)Math.Pow(10, count);

            }
            return r;
        }

    }
}
