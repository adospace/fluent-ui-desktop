using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace FluentUI.Desktop.Converters
{
    public class GetNegativeMarginForTreeViewItem : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var treeViewItem = (TreeViewItem)value;            
            var treeViewItemLevel = GetTreeViewItemLevel(treeViewItem);

            return new Thickness(-12.0 * treeViewItemLevel, 0, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        
        private static int GetTreeViewItemLevel(TreeViewItem item)
        {
            return (ItemsControl.ItemsControlFromItemContainer(item) is TreeViewItem parent) ? GetTreeViewItemLevel(parent) + 1 : 0;
        }
    }

    public class GetPositiveMarginForTreeViewItem : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var treeViewItem = (TreeViewItem)value;
            var treeViewItemLevel = GetTreeViewItemLevel(treeViewItem);

            return new Thickness(2.0 + 12.0 * treeViewItemLevel, 0, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static int GetTreeViewItemLevel(TreeViewItem item)
        {
            return (ItemsControl.ItemsControlFromItemContainer(item) is TreeViewItem parent) ? GetTreeViewItemLevel(parent) + 1 : 0;
        }
    }
}
