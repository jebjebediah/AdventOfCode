namespace Day07
{
    internal class FSFile : IFSItem
    {
        private string _name;
        private int _size;
        private FSDirectory _parent;

        public FSFile(string name, int size, FSDirectory parent)
        {
            _name = name;
            _size = size;
            _parent = parent;
        }

        public string GetName()
        {
            return _name;
        }

        public FSDirectory GetParentDirectory()
        {
            return _parent;
        }

        public int GetSize()
        {
            return _size;
        }

        public int GetSizeAndAddToListIfAtLeastThreshold(int threshold, List<FSDirectory> list)
        {
            return GetSize();
        }
        
        public int TabulateSizeWithThreshold(int threshold, ref int counter)
        {
            return GetSize();
        }
    }
}
