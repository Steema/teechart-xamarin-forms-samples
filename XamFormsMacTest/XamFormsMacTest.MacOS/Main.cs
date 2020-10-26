using AppKit;

namespace XamFormsMacTest.MacOS
{
    static class MainClass
    {
        static void Main(string[] args)
        {
            NSApplication.Init();
            Steema.TeeChart.TChart.Init();
            NSApplication.SharedApplication.Delegate = new AppDelegate(); // Added line
            NSApplication.Main(args);
        }
    }
}
