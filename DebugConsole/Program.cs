using Azumo.BaseComponents;

namespace DebugConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = SimpleConfigurationFile.Read("key");
        }
    }
}
