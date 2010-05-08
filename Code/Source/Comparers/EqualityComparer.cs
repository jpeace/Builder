namespace Builder.Comparers
{
    public class EqualityComparer : IComparer
    {
        private readonly object _subject;
        private readonly object _toCompareTo;

        public EqualityComparer(object subject, object toCompareTo)
        {
            _subject = subject;
            _toCompareTo = toCompareTo;
        }

        public bool Compare()
        {
            if (_subject == null || _toCompareTo == null)
            {
                return false;
            }
            return _subject.Equals(_toCompareTo);
        }
    }
}