namespace Day03
{
    internal class BagHandler
    {

        public static int ProcessBag(string bag)
        {
            char commonItem = FindCommonItem(bag);

            return PriorityHelper.GetItemPriority(commonItem);
        }

        private static char FindCommonItem(string bag)
        {
            string compartment1 = bag.Substring(0, bag.Length / 2);
            string compartment2 = bag.Substring(bag.Length / 2);

            var commonChar = compartment1.Where(c => compartment2.Contains(c)).First();

            return commonChar;
        }

        public static int FindCommonItemPriority(string bag1, string bag2, string bag3)
        {
            char commonChar = bag1.Where(c => bag2.Contains(c) && bag3.Contains(c)).First();

            return PriorityHelper.GetItemPriority(commonChar);
        }
    }
}
