using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FluentUI.Desktop
{
    public class FluentSplitButton : Button
    {
        static FluentSplitButton()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(FluentSplitButton), new FrameworkPropertyMetadata(typeof(FluentSplitButton)));
        }

        public ContextMenu Menu
        {
            get { return (ContextMenu)GetValue(MenuProperty); }
            set { SetValue(MenuProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Menu.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MenuProperty =
            DependencyProperty.Register("Menu", typeof(ContextMenu), typeof(FluentSplitButton), new PropertyMetadata(null));

        public bool ShowSplit
        {
            get { return (bool)GetValue(ShowSplitProperty); }
            set { SetValue(ShowSplitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowSplit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowSplitProperty =
            DependencyProperty.Register("ShowSplit", typeof(bool), typeof(FluentSplitButton), new PropertyMetadata(true));

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("PART_ArrowDown") is FrameworkElement downArrowPart)
            {
                downArrowPart.PreviewMouseDown += DownArrowPart_PreviewMouseDown;
            }

            PreviewMouseLeftButtonDown += SplitButton_PreviewMouseLeftButtonDown;
        }

        private void DownArrowPart_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ShowSplit)
            {
                ShowContextMenu();
                e.Handled = true;
            }
        }

        private void SplitButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!ShowSplit)
            {
                ShowContextMenu();
                e.Handled = true;
            }
        }

        private void ShowContextMenu()
        {
            var menu = Menu;
            if (menu != null)
            {
                menu.PlacementTarget = this;
                menu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                menu.IsOpen = true;
            }
        }
    }

}
