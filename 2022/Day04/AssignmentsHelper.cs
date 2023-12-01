namespace Day04
{
    internal class AssignmentsHelper
    {
        public static bool NestingExists(int min1, int max1, int min2, int max2)
        {
            if (min1 == min2 || max1 == max2) return true;
            else if (min1 < min2) return max1 >= max2;
            else return max2 >= max1;
        }

        public static bool OverlappingExists(int min1, int max1, int min2, int max2)
        {
            if (min1 <= min2 && max1 >= min2) return true;
            else if (min2 <= min1 && max2 >= min1) return true;
            else return false;
        }
    }
}
