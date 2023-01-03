namespace Day13
{
    public class Comparator
    {
        public static bool CompareLists(IEnumerable<int> lhs, IEnumerable<int> rhs)
        {
            // RULE: lhs must be shorter or the same length
            if (rhs.Count() < lhs.Count())
            {
                return false;
            }

            
            // RULE: lhs must be lower than or equal to rhs
            for (int i = 0; i < lhs.Count(); i++)
            {
                if (!CompareInts(lhs.ElementAt(i), rhs.ElementAt(i)))
                {
                    return false;
                }
            }
            
            return true;
        }

        public static bool CompareInts(int lhs, int rhs)
        {
            return lhs <= rhs;
        }
    }
}