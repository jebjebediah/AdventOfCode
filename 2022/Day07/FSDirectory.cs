namespace Day07
{
    internal class FSDirectory : IFSItem
    {
        private string _name;
        private FSDirectory _parent;
        private List<IFSItem> _children;

        public FSDirectory(string name, FSDirectory parent)
        {
            _name = name;
            _parent = parent;
            _children = new List<IFSItem>();
        }

        public string GetName()
        {
            return _name;
        }

        public FSDirectory GetParentDirectory()
        {
            return _parent;
        }

        public T GetChildItemByName<T>(string name) where T : IFSItem
        {
            IFSItem matchingItem = _children.Where(c => c.GetName() == name).Single();
            if (matchingItem is T)
            {
                return (T)matchingItem;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public int GetSize()
        {
            return _children.Sum(c => c.GetSize());
        }

        public int GetSizeAndAddToListIfAtLeastThreshold(int threshold, List<FSDirectory> list)
        {
            int size = _children.Sum(c => c.GetSizeAndAddToListIfAtLeastThreshold(threshold, list));
            if (size > threshold)
            {
                list.Add(this);
            }

            return size;
        }

        public void AddChild(IFSItem child)
        {
            _children.Add(child);
        }

        public int TabulateSizeWithThreshold(int threshold, ref int counter)
        {
            int size = 0;

            foreach (IFSItem child in _children)
            {
                int childSize = child.TabulateSizeWithThreshold(threshold, ref counter);
                size += childSize;
            }

            if (size < threshold) counter += size;
            return size;
        }
    }
}
