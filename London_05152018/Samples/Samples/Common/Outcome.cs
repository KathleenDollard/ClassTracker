using System;

namespace KadGen.Functional.Common
{
    // This is included for comparison with the Outcome struct. 
    // Simpler, but less powerful
    public enum OutcomeEnumDoNotUse
    {
        Fail = 0,
        PartialSuccess = 1,
        Success = 2
    }

    public struct Outcome : IEquatable<Outcome>, IComparable<Outcome>
    // can be a class if you want to extend
    {
        public int Value { get; }

        private Outcome(int value)
            => Value = value;

        public static Outcome Fail = new Outcome(0);
        public static Outcome PartialSuccess = new Outcome(1);
        public static Outcome Success = new Outcome(2);

        #region overloaded operators
        // Almost everything uses Comparison!
        // I choose semantics that an outcome can be less than success or more than fail
        // That this happens to be the numeric order, is an implementation detail. You could 
        // use a switch for other rules.
        public static int Comparison(Outcome x1, Outcome x2)
        => (x1.Value < x2.Value)
            ? -1
            : (x1.Value == x2.Value)
               ? 0
               : 1;

        public static bool operator ==(Outcome x1, Outcome x2)
        => Comparison(x1, x2) == 0;

        public static bool operator !=(Outcome x1, Outcome x2)
        => Comparison(x1, x2) != 0;

        public override bool Equals(object obj)
        => (obj is Outcome outcome)
            ? Comparison(this, outcome) == 0
            : false;

        public bool Equals(Outcome other) => this == other;

        // This impleemntationis just what the generate GetHashCode fixer 
        // producedand uses a prime, which is good for hashes
        public override int GetHashCode()
        => -1937169414 + Value.GetHashCode();

        public static bool operator <(Outcome x1, Outcome x2)
        {
            return Comparison(x1, x2) < 0;
        }

        public static bool operator >(Outcome x1, Outcome x2)
        => Comparison(x1, x2) > 0;

        public static bool operator <=(Outcome x1, Outcome x2)
       => Comparison(x1, x2) <= 0;

        public static bool operator >=(Outcome x1, Outcome x2)
        => Comparison(x1, x2) >= 0;

        public int CompareTo(Outcome other)
        => Comparison(this, other);

        // For comparison with ternary
        public static int Comparison2(Outcome x1, Outcome x2)
        {
            if (x1.Value < x2.Value)
            {
                return -1;
            }
            else if (x1.Value == x2.Value)
            {
                return 0;
            }
            else if (x1.Value > x2.Value)
            {
                return 1;
            }
            return 0;
        }

        #endregion
    }
}
