namespace Day03
{
    internal class PriorityHelper
    {
        private const int AsciiLowerStart = 96;
        private const int AsciiUpperStart = 64;
        private const int LowerPriorityStart = 0;
        private const int UpperPriorityStart = 26;

        public static int GetItemPriority(char item)
        {
            int asciiValue = (int)item;

            if (asciiValue > AsciiLowerStart)
            {
                return GetLowerCaseValue(item);
            }
            else
            {
                return GetUpperCaseValue(item);
            }
        }

        private static int GetLowerCaseValue(char item)
        {
            return item - AsciiLowerStart + LowerPriorityStart;
        }

        private static int GetUpperCaseValue(char item)
        {
            return item - AsciiUpperStart + UpperPriorityStart;
        }
    }
}
