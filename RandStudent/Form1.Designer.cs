namespace RandStudent
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MyNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CheckTimer = new System.Windows.Forms.Timer(this.components);
            this.LbStudentName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MyNotifyIcon
            // 
            this.MyNotifyIcon.Text = "RandStudent";
            this.MyNotifyIcon.Visible = true;
            this.MyNotifyIcon.Click += new System.EventHandler(this.MyNotifyIcon_Click);
            // 
            // MyContextMenuStrip
            // 
            this.MyContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MyContextMenuStrip.Name = "MyContextMenuStrip";
            this.MyContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MyContextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // CheckTimer
            // 
            this.CheckTimer.Enabled = true;
            this.CheckTimer.Interval = 60000;
            this.CheckTimer.Tick += new System.EventHandler(this.CheckTimer_Tick);
            // 
            // LbStudentName
            // 
            this.LbStudentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LbStudentName.Location = new System.Drawing.Point(8, 6);
            this.LbStudentName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LbStudentName.Name = "LbStudentName";
            this.LbStudentName.Size = new System.Drawing.Size(362, 62);
            this.LbStudentName.TabIndex = 1;
            this.LbStudentName.Text = "Ivan Sushytskyi+";
            this.LbStudentName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 74);
            this.Controls.Add(this.LbStudentName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "RandStudent";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon MyNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip MyContextMenuStrip;
        private System.Windows.Forms.Timer CheckTimer;
        private System.Windows.Forms.Label LbStudentName;
    }
}

