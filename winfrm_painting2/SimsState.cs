using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace winfrm_painting2
{
    public class SimsState
    {
        #region properties
        protected string name = @"_name";
        protected float value = 1000.0f;
        protected float delta = 1.0f;
        protected float nextDelta = 0.0f;
        #endregion

        #region visual
        protected int cx = 0;
        protected int cy = 0;
        protected int r = 50;
        protected Pen pen = new Pen(Color.BlueViolet, 3);
        protected Font font = SystemFonts.DialogFont;
        protected Brush brush = Brushes.BlueViolet;
        protected Pen focusPen = new Pen(Color.YellowGreen, 3);
        #endregion

        //public int CX { get { return this.cx; }}
        //public int CY { get { return this.cy; }}
        public PointF Location { get { return new PointF(this.cx, this.cy); } }

        public String Name { get { return this.name; }}

        public SimsState(string _name, int _cx, int _cy, int _r)
        {
            name = _name;
            cx = _cx;
            cy = _cy;
            r = _r;

            // init. 設定成虛線
            focusPen.DashStyle = DashStyle.Dash;
        }

        public void Draw(Graphics g)
        {
            float x = cx - r;
            float y = cy - r;
            float w = r + r;
            float h = r + r;

            g.DrawEllipse(this.pen, x, y, w, h);
 
            // show name
            SizeF sz = g.MeasureString(this.name, this.font);
            x = cx - sz.Width / 2;
            y = cy - sz.Height * 1.5f;
            g.DrawString(this.name, this.font, this.brush, x, y);

            // show value 
            string value_str = this.value.ToString("N2");
            sz = g.MeasureString(value_str, this.font);
            x = cx - sz.Width / 2;
            y = cy; // +sz.Height; // *1.5f;
            g.DrawString(value_str, this.font, this.brush, x, y);

            // show delta
            //string delta_str = string.Format("({0:N2}/{1:N2})", this.delta, this.nextDelta);
            string delta_str = string.Format("({0:N2})", this.delta);
            sz = g.MeasureString(delta_str, this.font);
            x = cx - sz.Width / 2;
            y = cy + sz.Height; // *1.5f;
            g.DrawString(delta_str, this.font, this.brush, x, y);

        }

        public void DrawFocus(Graphics g)
        {
            float x = cx - r - 6;
            float y = cy - r - 6;
            float w = r + r + 12;
            float h = r + r + 12;
           
            g.DrawEllipse(this.focusPen, x, y, w, h);


            //Graphics buttonGraphics = Button3.CreateGraphics();
            //Pen myPen = new Pen(Color.ForestGreen, 4.0F);
            //myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;

            //Rectangle theRectangle = Button3.ClientRectangle;
            //theRectangle.Inflate(-2, -2);
            //buttonGraphics.DrawRectangle(myPen, theRectangle);
            //buttonGraphics.Dispose();
            //myPen.Dispose();
            
        }

        public bool HitTest(Point pos)
        {
            int dr = (int)Math.Sqrt(Math.Pow(pos.X - this.cx, 2) + Math.Pow(pos.Y - this.cy, 2));
            return (dr < r);
        }

        public void SetPosition(Point pos)
        {
            this.cx = pos.X;
            this.cy = pos.Y;
        } 

        public void RunOnce(SimsAffect affect)
        {
            this.nextDelta += affect.affectVolumn * affect.A.delta;

            //Debug.Print(@"{0:-8} → {1:N0} \ {2:N0} \ {3:N0}", this.name, this.value, this.delta, this.nextDelta);
        }

        public void TriggerRegister()
        {
            this.delta = this.nextDelta;
            this.value += this.delta;
            this.nextDelta = 0;

            //Debug.Print(@"Trigger : {0:-8} → {1:N0} \ {2:N0} \ {3:N0}", this.name, this.value, this.delta, this.nextDelta);
        }

        public PointF CalcCircleBoundPos(SimsState B)
        {
            return CalcHelper.CalcCircleBoundPos(this.cx, this.cy, this.r, B.cx, B.cy);
        }
    }

    public class SimsAffect
    {
        #region properties
        public SimsState A;
        public SimsState B;
        public float affectVolumn;
        #endregion

        #region visual
        protected Pen pen;
        protected Font font = SystemFonts.DialogFont;
        protected Brush brush = Brushes.BlueViolet;
        #endregion

        public SimsAffect(SimsState _A, SimsState _B, float _volum)
        {
            A = _A;
            B = _B;
            affectVolumn = _volum;

            //# Init. this.pen
            this.pen = new Pen(Color.OrangeRed, 3);
            GraphicsPath capPath = new GraphicsPath();
            capPath.AddLines(new Point[] { new Point(-3, -4), new Point(0, 0), new Point(3, -4)});
            this.pen.StartCap = LineCap.SquareAnchor;
            //this.pen.EndCap = LineCap.ArrowAnchor;
            this.pen.CustomEndCap = new CustomLineCap(null, capPath);
        }

        public void Draw(Graphics g)
        {
            //Debug.Print(A.Name);

            PointF Ap = A.CalcCircleBoundPos(B);

            PointF Bp = B.CalcCircleBoundPos(A);

            //g.DrawLine(this.pen, A.Location, B.Location);
            g.DrawLine(this.pen, Ap, Bp);

            // show value 
            string volumn_str = this.affectVolumn.ToString("N2");
            SizeF sz = g.MeasureString(volumn_str, this.font);
            float x = (A.Location.X + B.Location.X) / 2.0f;
            float y = (A.Location.Y + B.Location.Y) / 2.0f;            
            g.DrawString(volumn_str, this.font, this.brush, x, y);
        }

        public void RunOnce()
        {
            B.RunOnce(this);
        }
    }


    public class CalcHelper
    {
        public static PointF CalcCircleBoundPos(float cx, float cy, float r, float cx2, float cy2)
        {
            float H = cy2 - cy;
            float W = cx2 - cx;
            float R = (float)Math.Sqrt(H * H + W * W);
            float rate = r / R;

            float w = W * rate;
            float h = H * rate;

            return new PointF(cx + w, cy + h);
        }

    }
}
