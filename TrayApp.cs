using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NetSpeedMonitor
{
    internal class TrayApp : ApplicationContext
    {
        private readonly NotifyIcon _icon;
        private readonly SpeedWindow _speedWindow;

        public TrayApp()
        {
            _icon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true,
                Text = "Net Speed Monitor"
            };

            _speedWindow = new SpeedWindow();
            _speedWindow.Show();

            var menu = new ContextMenuStrip();
            menu.Items.Add("Exit", null, (s, e) => Exit());
            _icon.ContextMenuStrip = menu;

            _icon.DoubleClick += (s, e) => _speedWindow.ToggleVisible();
        }

        private void Exit()
        {
            _speedWindow?.Close();
            _icon.Visible = false;
            Application.Exit();
        }
    }
}
