using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NetSpeedMonitor
{
    public class SpeedWindow : Form
    {
        private Timer _timer;
        private Label _label;

        private PerformanceCounter[] _down;
        private PerformanceCounter[] _up;

        private int _firstPositioned = 0;
        // Drag vars
        private bool _dragging = false;
        private Point _dragCursor;
        private Point _dragForm;

        public SpeedWindow()
        {
            InitializeForm();
            InitializeCounters();
            InitializeTimer();
        }

        private void InitializeForm()
        {
            
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            TopMost = true;
            Opacity = 0.92;
            BackColor = Color.FromArgb(30, 30, 30);
            Height = 40;
            Width = 0;
            _label = new Label
            {
                AutoSize = true,
                Width = 0,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(_label);

            MouseDown += DragStart;
            MouseMove += Dragging;
            MouseUp += DragEnd;

            _label.MouseDown += DragStart;
            _label.MouseMove += Dragging;
            _label.MouseUp += DragEnd;

            
            
        }

        // ============================
        // DRAG LOGIC
        // ============================

        private void DragStart(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _dragCursor = Cursor.Position;
            _dragForm = Location;
        }

        private void Dragging(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(_dragCursor));
                Point newPos = Point.Add(_dragForm, new Size(diff));

                // === KEEP ENTIRE BOX VISIBLE ON SCREEN ===
                var screen = Screen.PrimaryScreen.WorkingArea;

                if (newPos.X < screen.Left) newPos.X = screen.Left;
                if (newPos.Y < screen.Top) newPos.Y = screen.Top;
                if (newPos.X + Width > screen.Right) newPos.X = screen.Right - Width;
                if (newPos.Y + Height > screen.Bottom) newPos.Y = screen.Bottom - Height;

                Location = newPos;
            }
        }

        private void DragEnd(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // ============================

        private void InitializeCounters()
        {
            try
            {
                var cat = new PerformanceCounterCategory("Network Interface");
                var names = cat.GetInstanceNames();

                _down = names.Select(n =>
                    new PerformanceCounter("Network Interface", "Bytes Received/sec", n)
                ).ToArray();

                _up = names.Select(n =>
                    new PerformanceCounter("Network Interface", "Bytes Sent/sec", n)
                ).ToArray();
            }
            catch
            {
                _down = new PerformanceCounter[0];
                _up = new PerformanceCounter[0];
            }
        }

        private void InitializeTimer()
        {
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += (s, e) => UpdateText();
            _timer.Start();

            UpdateText();
        }

        private void UpdateText()
        {
            float down = 0, up = 0;

            try { down = _down.Sum(c => c.NextValue()); } catch { }
            try { up = _up.Sum(c => c.NextValue()); } catch { }

            string speed = $"↓ {Format(down)}\n↑ {Format(up)}";
            _label.Text = speed;

            // Add padding so text never touches edges
            this.Width = _label.Width;
            this.Height = _label.Height;

            if (_firstPositioned != 2)
            {
                PositionBottomRight();
                _firstPositioned += 1;
            }
        }
        private string Format(float b)
        {
            float K = 1024f, M = K * 1024f;
            if (b >= M) return $"{b / M:0.0} MB/s";
            if (b >= K) return $"{b / K:0.0} KB/s";
            return $"{b:0.0} B/s";
        }

        private void PositionBottomRight()
        {
            var screen = Screen.PrimaryScreen.WorkingArea;
            Left = screen.Right - Width;
            Top = screen.Bottom - Height;
        }

        public void ToggleVisible()
        {
            Visible = !Visible;
        }
    }
}
