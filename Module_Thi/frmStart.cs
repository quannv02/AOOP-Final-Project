using Module_SoanDe.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Module_Thi
{
    public partial class frmStart : Form
    {
        frmTakeTest frm = new frmTakeTest();

        public frmStart()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "XML files|*.xml";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                String path = dlg.FileName;
                using (var xml = XmlReader.Create(path))
                {
                    xml.ReadToFollowing("Test");
                    xml.MoveToAttribute("ID");
                    frm.TestID = xml.Value;
                    int count = 1;
                    while (xml.ReadToFollowing("Quiz"))
                    {
                        Quiz q = new Quiz();
                        q.ID = count;
                        xml.ReadToFollowing("Question");
                        q.Question = xml.ReadElementContentAsString();
                        xml.ReadToFollowing("Answer");
                        xml.MoveToAttribute("count");
                        int n = int.Parse(xml.Value);
                        for (int i = 0; i < n; i++)
                        {
                            xml.ReadToFollowing("Option");
                            q.Option.Add(xml.ReadElementContentAsString());
                        }
                        frm.lstQuiz.Add(q);
                        count = count + 1;
                    }
                }
            }
            if (frm.lstQuiz.Count > 0)
                lblStatus.Text = "Tải xong";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtName.Text == String.Empty)
                MessageBox.Show("Nhập họ tên!", "Thong bao");
            else
            {
                if (frm.lstQuiz.Count == 0)
                    MessageBox.Show("Đề không hợp lệ!", "Thong bao");
                else
                {
                    frm.UserName = txtName.Text;
                    int time = frm.lstQuiz.Count * 15;
                    int m = time / 60;
                    int s = time % 60;
                    DialogResult dlg = MessageBox.Show($"Bắt đầu làm bài!\nThời gian làm bài: {m} phút {s} giây.", "Thong bao", MessageBoxButtons.OKCancel);
                    if (dlg == DialogResult.OK)
                    {
                        this.Hide();
                        frm.Show();
                        frm.Timer._mm = m;
                        frm.Timer._ss = s;
                        frm.Timer.Start();
                    }
                }
            }
        }
    }
}
