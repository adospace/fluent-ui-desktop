using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FluentUI.Desktop.DemoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/FluentUI.Desktop;component/Styles/Light/Controls.xaml", UriKind.Absolute)
            });
            //Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //{
            //    Source = new Uri("pack://application:,,,/FluentUI.Desktop;component/Styles/Dark/Controls.xaml", UriKind.Absolute)
            //});
        }
    }
}
