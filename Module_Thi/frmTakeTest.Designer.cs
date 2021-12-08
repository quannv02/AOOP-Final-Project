namespace Module_Thi
{
    partial class frmTakeTest
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.cbConsider = new System.Windows.Forms.CheckBox();
            this.lbOption = new System.Windows.Forms.ListBox();
            this.txtOption = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer = new Module_Thi.uscTimer();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.lbQuiz = new System.Windows.Forms.ListBox();
            this.btnHideTimer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.cbConsider);
            this.splitContainer.Panel1.Controls.Add(this.lbOption);
            this.splitContainer.Panel1.Controls.Add(this.txtOption);
            this.splitContainer.Panel1.Controls.Add(this.label2);
            this.splitContainer.Panel1.Controls.Add(this.txtQuestion);
            this.splitContainer.Panel1.Controls.Add(this.label1);
            this.splitContainer.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.btnHideTimer);
            this.splitContainer.Panel2.Controls.Add(this.timer);
            this.splitContainer.Panel2.Controls.Add(this.btnSubmit);
            this.splitContainer.Panel2.Controls.Add(this.btnBack);
            this.splitContainer.Panel2.Controls.Add(this.BtnNext);
            this.splitContainer.Panel2.Controls.Add(this.lbQuiz);
            this.splitContainer.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer.Size = new System.Drawing.Size(790, 466);
            this.splitContainer.SplitterDistance = 568;
            this.splitContainer.TabIndex = 2;
            // 
            // cbConsider
            // 
            this.cbConsider.AutoSize = true;
            this.cbConsider.Location = new System.Drawing.Point(100, 416);
            this.cbConsider.Name = "cbConsider";
            this.cbConsider.Size = new System.Drawing.Size(108, 24);
            this.cbConsider.TabIndex = 3;
            this.cbConsider.Text = "Cần xem lại";
            this.cbConsider.UseVisualStyleBackColor = true;
            this.cbConsider.CheckedChanged += new System.EventHandler(this.cbConsider_CheckedChanged);
            // 
            // lbOption
            // 
            this.lbOption.FormattingEnabled = true;
            this.lbOption.ItemHeight = 20;
            this.lbOption.Location = new System.Drawing.Point(100, 266);
            this.lbOption.Name = "lbOption";
            this.lbOption.ScrollAlwaysVisible = true;
            this.lbOption.Size = new System.Drawing.Size(414, 144);
            this.lbOption.TabIndex = 2;
            this.lbOption.SelectedIndexChanged += new System.EventHandler(this.lbOption_SelectedIndexChanged);
            // 
            // txtOption
            // 
            this.txtOption.Location = new System.Drawing.Point(100, 159);
            this.txtOption.Multiline = true;
            this.txtOption.Name = "txtOption";
            this.txtOption.ReadOnly = true;
            this.txtOption.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOption.Size = new System.Drawing.Size(414, 89);
            this.txtOption.TabIndex = 1;
            this.txtOption.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(33, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Đáp án";
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(100, 33);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.ReadOnly = true;
            this.txtQuestion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQuestion.Size = new System.Drawing.Size(414, 110);
            this.txtQuestion.TabIndex = 0;
            this.txtQuestion.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(33, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Câu hỏi";
            // 
            // timer
            // 
            this.timer._mm = 0;
            this.timer._ss = 0;
            this.timer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.timer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.timer.Location = new System.Drawing.Point(0, 385);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(218, 52);
            this.timer.TabIndex = 4;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSubmit.Location = new System.Drawing.Point(0, 437);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(218, 29);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Hoàn thành";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBack.Location = new System.Drawing.Point(0, 331);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(218, 29);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Quay lại";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnNext.Location = new System.Drawing.Point(0, 302);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(218, 29);
            this.BtnNext.TabIndex = 1;
            this.BtnNext.Text = "Tiếp theo";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // lbQuiz
            // 
            this.lbQuiz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbQuiz.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbQuiz.FormattingEnabled = true;
            this.lbQuiz.ItemHeight = 20;
            this.lbQuiz.Location = new System.Drawing.Point(0, 0);
            this.lbQuiz.Name = "lbQuiz";
            this.lbQuiz.ScrollAlwaysVisible = true;
            this.lbQuiz.Size = new System.Drawing.Size(218, 302);
            this.lbQuiz.TabIndex = 0;
            this.lbQuiz.SelectedIndexChanged += new System.EventHandler(this.lbQuiz_SelectedIndexChanged);
            // 
            // btnHideTimer
            // 
            this.btnHideTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHideTimer.Location = new System.Drawing.Point(0, 360);
            this.btnHideTimer.Name = "btnHideTimer";
            this.btnHideTimer.Size = new System.Drawing.Size(218, 25);
            this.btnHideTimer.TabIndex = 5;
            this.btnHideTimer.Text = "Ẩn đồng hồ";
            this.btnHideTimer.UseVisualStyleBackColor = true;
            this.btnHideTimer.Click += new System.EventHandler(this.btnHideTimer_Click);
            // 
            // frmTakeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 466);
            this.Controls.Add(this.splitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(808, 513);
            this.MinimumSize = new System.Drawing.Size(808, 513);
            this.Name = "frmTakeTest";
            this.Text = "Làm bài thi";
            this.Load += new System.EventHandler(this.frmTakeTest_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox lbQuiz;
        private SplitContainer splitContainer;
        private Button btnSubmit;
        private Button btnBack;
        private Button BtnNext;
        private ListBox lbOption;
        private TextBox txtOption;
        private Label label2;
        private TextBox txtQuestion;
        private Label label1;
        private CheckBox cbConsider;
        private uscTimer timer;
        private Button btnHideTimer;
    }
}