namespace Module_SoanDe
{
    partial class uscRateTest
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
            this.btnLoadKey = new System.Windows.Forms.Button();
            this.btnLoadWork = new System.Windows.Forms.Button();
            this.btnSaveResult = new System.Windows.Forms.Button();
            this.lblStatusKey = new System.Windows.Forms.Label();
            this.lblStatusWork = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoadKey
            // 
            this.btnLoadKey.Location = new System.Drawing.Point(388, 190);
            this.btnLoadKey.Name = "btnLoadKey";
            this.btnLoadKey.Size = new System.Drawing.Size(94, 29);
            this.btnLoadKey.TabIndex = 0;
            this.btnLoadKey.Text = "Tải đáp án";
            this.btnLoadKey.UseVisualStyleBackColor = true;
            this.btnLoadKey.Click += new System.EventHandler(this.btnLoadKey_Click);
            // 
            // btnLoadWork
            // 
            this.btnLoadWork.Location = new System.Drawing.Point(388, 243);
            this.btnLoadWork.Name = "btnLoadWork";
            this.btnLoadWork.Size = new System.Drawing.Size(94, 29);
            this.btnLoadWork.TabIndex = 0;
            this.btnLoadWork.Text = "Tải bài làm";
            this.btnLoadWork.UseVisualStyleBackColor = true;
            this.btnLoadWork.Click += new System.EventHandler(this.btnLoadWork_Click);
            // 
            // btnSaveResult
            // 
            this.btnSaveResult.Location = new System.Drawing.Point(388, 296);
            this.btnSaveResult.Name = "btnSaveResult";
            this.btnSaveResult.Size = new System.Drawing.Size(94, 29);
            this.btnSaveResult.TabIndex = 0;
            this.btnSaveResult.Text = "Chấm bài";
            this.btnSaveResult.UseVisualStyleBackColor = true;
            this.btnSaveResult.Click += new System.EventHandler(this.btnSaveResult_Click);
            // 
            // lblStatusKey
            // 
            this.lblStatusKey.AutoSize = true;
            this.lblStatusKey.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lblStatusKey.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblStatusKey.Location = new System.Drawing.Point(510, 194);
            this.lblStatusKey.Name = "lblStatusKey";
            this.lblStatusKey.Size = new System.Drawing.Size(107, 20);
            this.lblStatusKey.TabIndex = 1;
            this.lblStatusKey.Text = "Tải thành công";
            this.lblStatusKey.Visible = false;
            // 
            // lblStatusWork
            // 
            this.lblStatusWork.AutoSize = true;
            this.lblStatusWork.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lblStatusWork.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblStatusWork.Location = new System.Drawing.Point(510, 247);
            this.lblStatusWork.Name = "lblStatusWork";
            this.lblStatusWork.Size = new System.Drawing.Size(107, 20);
            this.lblStatusWork.TabIndex = 1;
            this.lblStatusWork.Text = "Tải thành công";
            this.lblStatusWork.Visible = false;
            // 
            // uscRateTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblStatusWork);
            this.Controls.Add(this.lblStatusKey);
            this.Controls.Add(this.btnSaveResult);
            this.Controls.Add(this.btnLoadWork);
            this.Controls.Add(this.btnLoadKey);
            this.Name = "uscRateTest";
            this.Size = new System.Drawing.Size(1077, 540);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnLoadKey;
        private Button btnLoadWork;
        private Button btnSaveResult;
        private Label lblStatusKey;
        private Label lblStatusWork;
    }
}
