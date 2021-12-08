namespace Module_Thi
{
    partial class uscTimer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mm1Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.mm2Label = new System.Windows.Forms.Label();
            this.ss1Label = new System.Windows.Forms.Label();
            this.ss2Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mm1Label
            // 
            this.mm1Label.AutoSize = true;
            this.mm1Label.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mm1Label.Location = new System.Drawing.Point(54, 13);
            this.mm1Label.Name = "mm1Label";
            this.mm1Label.Size = new System.Drawing.Size(21, 25);
            this.mm1Label.TabIndex = 0;
            this.mm1Label.Text = "x";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(99, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = ":";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // mm2Label
            // 
            this.mm2Label.AutoSize = true;
            this.mm2Label.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mm2Label.Location = new System.Drawing.Point(72, 13);
            this.mm2Label.Name = "mm2Label";
            this.mm2Label.Size = new System.Drawing.Size(21, 25);
            this.mm2Label.TabIndex = 0;
            this.mm2Label.Text = "x";
            // 
            // ss1Label
            // 
            this.ss1Label.AutoSize = true;
            this.ss1Label.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ss1Label.Location = new System.Drawing.Point(122, 13);
            this.ss1Label.Name = "ss1Label";
            this.ss1Label.Size = new System.Drawing.Size(21, 25);
            this.ss1Label.TabIndex = 0;
            this.ss1Label.Text = "x";
            // 
            // ss2Label
            // 
            this.ss2Label.AutoSize = true;
            this.ss2Label.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ss2Label.Location = new System.Drawing.Point(140, 13);
            this.ss2Label.Name = "ss2Label";
            this.ss2Label.Size = new System.Drawing.Size(21, 25);
            this.ss2Label.TabIndex = 0;
            this.ss2Label.Text = "x";
            // 
            // uscTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ss2Label);
            this.Controls.Add(this.ss1Label);
            this.Controls.Add(this.mm2Label);
            this.Controls.Add(this.mm1Label);
            this.Name = "uscTimer";
            this.Size = new System.Drawing.Size(185, 59);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label mm1Label;
        private Label label1;
        private System.Windows.Forms.Timer timer;
        private Label mm2Label;
        private Label ss1Label;
        private Label ss2Label;
    }
}
