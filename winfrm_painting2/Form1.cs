﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winfrm_painting2
{
    public partial class Form1 : Form
    {
        #region Document

        protected Collection<SimsState> m_states = new Collection<SimsState>();
        protected Collection<SimsAffect> m_affects = new Collection<SimsAffect>();

        #endregion

        protected SimsState m_selectedState = null;

        protected int runRound = 0;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Init
            m_states.Add(new SimsState("工作", 300, 100, 50));
            m_states.Add(new SimsState("錢", 600, 100, 50));
            m_states.Add(new SimsState("消費", 600, 400, 50));
            m_states.Add(new SimsState("GDP", 300, 400, 50));
            m_states.Add(new SimsState("機器", 100, 250, 50));

            m_affects.Add(new SimsAffect(m_states[0], m_states[1], +1.0f));
            m_affects.Add(new SimsAffect(m_states[1], m_states[2], +1.0f));
            m_affects.Add(new SimsAffect(m_states[2], m_states[3], +1.0f));
            m_affects.Add(new SimsAffect(m_states[3], m_states[0], +0.5f));
            m_affects.Add(new SimsAffect(m_states[3], m_states[4], +0.5f));
            m_affects.Add(new SimsAffect(m_states[4], m_states[0], -1.25f));

            m_selectedState = m_states[2];
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // draw here
            foreach (var c in m_states)
                c.Draw(e.Graphics);

            foreach (var c in m_affects)
                c.Draw(e.Graphics);

            if(m_selectedState != null)
                m_selectedState.DrawFocus(e.Graphics);

        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            // draw background
            //e.Graphics.DrawLine(Pens.DarkGray, 0, 0, e.ClipRectangle.Width, e.ClipRectangle.Height);
            //e.Graphics.DrawLine(Pens.DarkGray, e.ClipRectangle.Width, 0, 0, e.ClipRectangle.Height);

            //Pen pen = new Pen(Color.DarkGray, 8);
            //pen.StartCap = LineCap.SquareAnchor; //  .Round; // LineCap.RoundAnchor;
            //pen.EndCap = LineCap.ArrowAnchor; // .Triangle; // LineCap.ArrowAnchor;
            //e.Graphics.DrawLine(pen, 120, 35, 400, 35);

            //using (Pen p = new Pen(Color.Black))
            //using (GraphicsPath capPath = new GraphicsPath())
            //{
            //    // A triangle
            //    capPath.AddLine(-20, 0, 20, 0);
            //    capPath.AddLine(-20, 0, 0, 20);
            //    capPath.AddLine(0, 20, 20, 0);

            //    p.CustomEndCap = new System.Drawing.Drawing2D.CustomLineCap(null, capPath);

            //    e.Graphics.DrawLine(p, 0, 50, 600, 50);
            //    e.Graphics.DrawLine(Pens.DeepPink, 0, 60, 600, 60);
            //}
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if(this.timer1.Enabled)
            {
                this.timer1.Enabled = false;
            }            
            else
            {
                this.runRound = 0;
                this.timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.runRound++;
            lblRunRound.Text = this.runRound.ToString("N0");

            foreach (var c in m_affects)
                c.RunOnce();

            foreach (var c in m_states)
                c.TriggerRegister();

            this.Invalidate();
        }

        private void btnRunStep_Click(object sender, EventArgs e)
        {
            // trigger event
            timer1_Tick(null, null);
        }

        private void btnAddEntity_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //Debug.Print("ON : Form1_MouseClick");

            //this.m_selectedState = null;
            //foreach (var c in m_states)
            //{
            //    if (c.HitTest(e.Location))
            //    {
            //        this.m_selectedState = c;
            //        break;
            //    }
            //}

            //// 重繪畫面
            //this.Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Debug.Print("ON : Form1_MouseMove");

            this.m_selectedState = null;
            if(e.Button == MouseButtons.Left)
            {
                //this.m_selectedState = null;
                foreach (var c in m_states)
                {
                    if (c.HitTest(e.Location))
                    {
                        this.m_selectedState = c;
                        c.SetPosition(e.Location);
                        break;
                    }
                }

                // 重繪畫面
                this.Invalidate();
            }
        }

    }
}
