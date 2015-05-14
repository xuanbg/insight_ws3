
namespace Insight.WS.Client.Common
{
    public class ComboBoxItem
    {
        private readonly int _Index;
        private readonly string _Name;

        public ComboBoxItem(int index, string name)
        {
            _Index = index;
            _Name = name;
        }
        public override string ToString()
        {
            return _Name;
        }
        public override int GetHashCode()
        {
            return _Index;
        }
    }
}
