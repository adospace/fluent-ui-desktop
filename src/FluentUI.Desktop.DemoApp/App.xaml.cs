using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FluentUI.Desktop.DemoApp
{
    public enum Theme
    { 
        Light,

        Dark
    }

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            SetTheme(Theme.Light);
        }

        public static void SetTheme(Theme theme)
        { 
            Application.Current.Resources.MergedDictionaries.Clear();
            AddResourceMergedDictionary($"Brushes.{theme}");
            AddResourceMergedDictionary("Controls");            
        }

        private static void AddResourceMergedDictionary(string name)
            => Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri($"pack://application:,,,/FluentUI.Desktop;component/Styles/{name}.xaml", UriKind.Absolute)
            });
    }
}
