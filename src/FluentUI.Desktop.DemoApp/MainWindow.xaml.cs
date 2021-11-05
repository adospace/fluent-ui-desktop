using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FluentUI.Desktop.DemoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selectedItem = e.NewValue as TreeViewItem;
            if (selectedItem != null && selectedItem.Tag is string pageTypeName)
            {
                pageContainer.Content = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance($"FluentUI.Desktop.DemoApp.Pages.{pageTypeName}");
            }
        }

        private void OnSetLightTheme(object sender, RoutedEventArgs e)
        {
            App.SetTheme(Theme.Light);
        }

        private void OnSetDarkTheme(object sender, RoutedEventArgs e)
        {
            App.SetTheme(Theme.Dark);
        }
    }
}
