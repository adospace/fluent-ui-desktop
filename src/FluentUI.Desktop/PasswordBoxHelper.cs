using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FluentUI.Desktop
{
    public class PasswordBoxHelper
    {
        public static bool GetCheckPasswordIsEmpty(DependencyObject obj)
        {
            return (bool)obj.GetValue(CheckPasswordIsEmptyProperty);
        }

        public static void SetCheckPasswordIsEmpty(DependencyObject obj, bool value)
        {
            obj.SetValue(CheckPasswordIsEmptyProperty, value);
        }

        // Using a DependencyProperty as the backing store for CheckPasswordIsEmpty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckPasswordIsEmptyProperty =
            DependencyProperty.RegisterAttached("CheckPasswordIsEmpty", typeof(bool), typeof(PasswordBoxHelper),
                new PropertyMetadata(false, new PropertyChangedCallback(OnCheckPasswordIsEmptyPropertyChangeCallback)));

        private static void OnCheckPasswordIsEmptyPropertyChangeCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is PasswordBox passwordBox))
            {
                throw new InvalidOperationException();
            }

            if ((bool)e.OldValue == true)
            {
                passwordBox.PasswordChanged -= PassWordBox_PasswordChanged;
            }

            if (!(bool)e.NewValue)
                return;

            SetIsPasswordEmpty(passwordBox, string.IsNullOrEmpty(passwordBox.Password));

            passwordBox.PasswordChanged += PassWordBox_PasswordChanged;
        }

        private static void PassWordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = (PasswordBox)sender;
            SetIsPasswordEmpty(passwordBox, string.IsNullOrEmpty(passwordBox.Password));
        }

        public static bool GetIsPasswordEmpty(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsPasswordEmptyProperty);
        }

        public static void SetIsPasswordEmpty(DependencyObject obj, bool value)
        {
            obj.SetValue(IsPasswordEmptyProperty, value);
        }

        // Using a DependencyProperty as the backing store for HasPasswordEmpty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPasswordEmptyProperty =
            DependencyProperty.RegisterAttached("IsPasswordEmpty", typeof(bool), typeof(PasswordBoxHelper), new PropertyMetadata(true));


    }
}
