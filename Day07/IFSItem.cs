namespace Day07
{
    internal interface IFSItem
    {
        string GetName();
        FSDirectory GetParentDirectory();
        int TabulateSizeWithThreshold(int threshold, ref int counter);
        int GetSize();
        int GetSizeAndAddToListIfAtLeastThreshold(int threshold, List<FSDirectory> list);
    }
}
