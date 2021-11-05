using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FluentUI.Desktop
{
    public class TreeViewHelper
    {
        #region ShowCheckBoxes Property
        public static readonly DependencyProperty ShowCheckBoxesProperty =
            DependencyProperty.RegisterAttached("ShowCheckBoxes", typeof(bool), typeof(TreeViewHelper));

        public static void SetShowCheckBoxes(UIElement element, bool value)
        {
            element.SetValue(ShowCheckBoxesProperty, value);
        }
        public static bool GetShowCheckBoxes(UIElement element)
        {
            return (bool)element.GetValue(ShowCheckBoxesProperty);
        }
        #endregion

        #region IsItemChecked Property

        public static readonly DependencyProperty IsItemCheckedProperty =
            DependencyProperty.RegisterAttached("IsItemChecked", typeof(bool), typeof(TreeViewHelper));

        public static void SetIsItemChecked(UIElement element, bool value)
        {
            element.SetValue(IsItemCheckedProperty, value);
        }
        public static bool GetIsItemChecked(UIElement element)
        {
            return (bool)element.GetValue(IsItemCheckedProperty);
        }

        #endregion
    }
}
