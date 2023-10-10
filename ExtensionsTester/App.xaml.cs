using System.Windows;
using System.Windows.Media;

namespace ExtensionsTester
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() : base()
        {
            ResourceDictionary rd = new()
            {
                ["SomeR"] = new SolidColorBrush(Color.FromArgb(255, 0, 255, 255))
            };
            Resources.MergedDictionaries.Add(rd);
        }
    }
}