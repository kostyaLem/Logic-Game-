using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightmareV2
{
    public class TupleComparer : IEqualityComparer<Tuple<int, int, int>>
    {
        public bool Equals(Tuple<int, int, int> x, Tuple<int, int, int> y)
        {
            return (x.Item1 == y.Item1 && x.Item2 == y.Item2 && x.Item3 == y.Item3) ? true : false;
        }

        public int GetHashCode(Tuple<int, int, int> obj)
        {
            return obj.GetHashCode();
        }
    }
}
