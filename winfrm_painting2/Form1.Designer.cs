﻿namespace winfrm_painting2
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnAddEntity = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblRunRound = new System.Windows.Forms.Label();
            this.btnRunStep = new System.Windows.Forms.Button();
            this.propViewer = new System.Windows.Forms.PropertyGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.SuspendLayout();
            // 
            // btnAddEntity
            // 
            this.btnAddEntity.Location = new System.Drawing.Point(12, 12);
            this.btnAddEntity.Name = "btnAddEntity";
            this.btnAddEntity.Size = new System.Drawing.Size(74, 31);
            this.btnAddEntity.TabIndex = 0;
            this.btnAddEntity.Text = "Add Entity";
            this.btnAddEntity.UseVisualStyleBackColor = true;
            this.btnAddEntity.Click += new System.EventHandler(this.btnAddEntity_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 49);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(74, 31);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblRunRound
            // 
            this.lblRunRound.AutoSize = true;
            this.lblRunRound.Location = new System.Drawing.Point(12, 83);
            this.lblRunRound.Name = "lblRunRound";
            this.lblRunRound.Size = new System.Drawing.Size(52, 12);
            this.lblRunRound.TabIndex = 2;
            this.lblRunRound.Text = "run round";
            // 
            // btnRunStep
            // 
            this.btnRunStep.Location = new System.Drawing.Point(14, 130);
            this.btnRunStep.Name = "btnRunStep";
            this.btnRunStep.Size = new System.Drawing.Size(74, 31);
            this.btnRunStep.TabIndex = 3;
            this.btnRunStep.Text = "Run Step";
            this.btnRunStep.UseVisualStyleBackColor = true;
            this.btnRunStep.Click += new System.EventHandler(this.btnRunStep_Click);
            // 
            // propViewer
            // 
            this.propViewer.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.propViewer.Dock = System.Windows.Forms.DockStyle.Right;
            this.propViewer.Location = new System.Drawing.Point(613, 0);
            this.propViewer.Name = "propViewer";
            this.propViewer.Size = new System.Drawing.Size(180, 402);
            this.propViewer.TabIndex = 4;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(603, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 402);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 402);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.propViewer);
            this.Controls.Add(this.btnRunStep);
            this.Controls.Add(this.lblRunRound);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnAddEntity);
            this.Name = "Form1";
            this.Text = "System Model - Prototype";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddEntity;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblRunRound;
        private System.Windows.Forms.Button btnRunStep;
        private System.Windows.Forms.PropertyGrid propViewer;
        private System.Windows.Forms.Splitter splitter1;
    }
}

