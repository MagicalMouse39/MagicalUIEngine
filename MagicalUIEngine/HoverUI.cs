using MagicalUIEngine.Components;
using MagicalUIEngine.Relations;
using MagicalUIEngine.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicalUIEngine
{
    public class HoverUI : Form
    {
        public class RenderEventArgs : EventArgs
        {
            public Graphics Graphics;

            public RenderEventArgs(Graphics graphics) => this.Graphics = graphics;
        }
        public delegate EventHandler RenderEventHandler(object sender, RenderEventArgs args);
        public event RenderEventHandler Render;
        protected void OnRender(RenderEventArgs args) => this.Render?.Invoke(this, args);

        public const int GWL_EXSTYLE = -20;
        internal const int WS_EX_LAYERED = 524288;
        internal const int WS_EX_TRANSPARENT = 32;
        internal const int LWA_ALPHA = 2;
        internal const int LWA_COLORKEY = 1;
        internal IntPtr OriginalWindowStyle;
        internal IntPtr PassthruWindowStyle;
        private List<Shape> Shapes;
        private List<Action> RenderDelegates;

        protected BufferedPanel canvas;

        private void SetWindowPassthru(bool passthrough)
        {
            if (passthrough)
                Interoperator.SetWindowLong(this.Handle, -20, PassthruWindowStyle);
            else
                Interoperator.SetWindowLong(this.Handle, -20, OriginalWindowStyle);
        }

        public string GetPathToFileInAssembly(string relativePath)
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), relativePath);
        }

        private bool IsApplicationIdle()
        {
            Interoperator.NativeMessage message;
            return Interoperator.PeekMessage(out message, IntPtr.Zero, 0U, 0U, 0U) == 0;
        }

        private void HandleApplicationIdle(object sender, EventArgs e)
        {
            while (this.IsApplicationIdle())
            {
                TopMost = true;
                this.canvas.BringToFront();
                this.canvas.Invalidate();
                Thread.Sleep(8);
            }
        }

        public bool BackgroundKeyDown(Keys key)
        {
            return Interoperator.GetAsyncKeyState(key) != 0;
        }

        private void CanvasRender(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            this.OnRender(new RenderEventArgs(g));

            foreach (Shape s in this.Shapes)
            {
                if (s.GetType() == typeof(Shapes.Rectangle))
                {
                    Shapes.Rectangle rect = s as Shapes.Rectangle;
                    g.FillRectangle(rect.BackBrush, rect.X, rect.Y, rect.Width, rect.Height);
                    g.DrawRectangle(new Pen(rect.BorderBrush) { Width = rect.BorderThickness }, rect.X, rect.Y, rect.Width, rect.Height);
                }

                if (s.GetType() == typeof(Shapes.Circle))
                {
                    Shapes.Circle circ = s as Shapes.Circle;
                    g.FillEllipse(circ.BackBrush, circ.X, circ.Y, circ.Radius, circ.Radius);
                    g.DrawEllipse(new Pen(circ.BorderBrush) { Width = circ.BorderThickness }, circ.X, circ.Y, circ.Radius, circ.Radius);
                }

                if (s.GetType() == typeof(Shapes.Ellipse))
                {
                    Shapes.Ellipse ell = s as Shapes.Ellipse;
                    g.FillEllipse(ell.BackBrush, ell.X, ell.Y, ell.Width, ell.Height);
                    g.DrawEllipse(new Pen(ell.BorderBrush) { Width = ell.BorderThickness }, ell.X, ell.Y, ell.Width, ell.Height);
                }
            }
        }

        public void AddShape(Shape shape) => this.Shapes.Add(shape);

        public void OpenSubform(Form f)
        {
            this.IsMdiContainer = true;
            f.MdiParent = this;
            f.Show();
        }

        public HoverUI()
        {
            this.Shapes = new List<Shape>();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.TopMost = true;
            this.AllowTransparency = true;
            this.BackColor = Color.FromArgb(196, 255, 226);
            this.TransparencyKey = Color.FromArgb(196, 255, 226);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.OriginalWindowStyle = (IntPtr)((long)Interoperator.GetWindowLong(this.Handle, -20));
            this.PassthruWindowStyle = (IntPtr)((long)(uint)((int)Interoperator.GetWindowLong(this.Handle, -20) | 524288 | 32));
            this.SetWindowPassthru(true);

            this.canvas = new BufferedPanel();
            this.canvas.Dock = DockStyle.Fill;
            this.canvas.BackColor = Color.Transparent;
            this.canvas.BringToFront();
            this.canvas.Paint += CanvasRender;
            this.Controls.Add(this.canvas);
        }

        public void Run()
        {
            Application.EnableVisualStyles();
            Application.Idle += this.HandleApplicationIdle;
            Application.Run(this);
        }
    }
}
