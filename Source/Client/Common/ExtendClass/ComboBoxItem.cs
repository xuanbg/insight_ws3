
namespace Insight.WS.Client.Common
{
    public class ComboBoxItem
    {

        private readonly int _Index;
        private readonly string _Name;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="index"></param>
        /// <param name="name"></param>
        public ComboBoxItem(int index, string name)
        {
            _Index = index;
            _Name = name;
        }

        /// <summary>
        /// 重写ToString()方法，返回Name值
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _Name;
        }

        /// <summary>
        /// 重写GetHashCode()，返回Index值
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _Index;
        }
    }
}
