using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FluentUI.Desktop
{
    public class WindowChromeButton : Button
    {

        public WindowChromeButtonMode Mode { get; set; }

        protected override void OnClick()
        {
            var parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                switch (Mode)
                {
                    case WindowChromeButtonMode.Close:
                        SystemCommands.CloseWindow(parentWindow);
                        break;
                    case WindowChromeButtonMode.Minimize:
                        SystemCommands.MinimizeWindow(parentWindow);
                        break;
                    case WindowChromeButtonMode.Maximize:
                        SystemCommands.MaximizeWindow(parentWindow);
                        break;
                    case WindowChromeButtonMode.Restore:
                        SystemCommands.RestoreWindow(parentWindow);
                        break;
                }
            }
            base.OnClick();
        }

        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            base.OnPreviewMouseMove(e);
        }
    }

}
