
namespace Insight.WS.Client.Common
{
    public class Context
    {
        public readonly string Name;
        public readonly bool Status;

        public Context(string name, bool status)
        {
            Name = name;
            Status = status;
        }
    }
}
