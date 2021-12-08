using System.ComponentModel;
using System.Xml;

namespace Module_Thi
{
    public partial class frmTakeTest : Form
    {
        private String _testID = "";
        private String _name = "";
        private BindingList<Quiz> _lstQuiz = new BindingList<Quiz>();
        private BindingList<String> lstOption = new BindingList<String>();

        private bool isDoing = false;

        public String TestID 
        {
            get { return _testID; }
            set { _testID = value; }
        }

        public String UserName
        {
            get { return _name; }
            set { _name = value; }
        }

        public BindingList<Quiz> lstQuiz
        {
            get { return _lstQuiz; }
            set { _lstQuiz = value; }
        }

        public uscTimer Timer
        {
            get { return timer; }
        }

        public frmTakeTest()
        {
            InitializeComponent();
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            lbQuiz.DataSource = lstQuiz;
            lbQuiz.SelectedIndex = -1;
            lbOption.DataSource = lstOption;
            lbOption.SelectedIndex = -1;
            txtQuestion.Text = String.Empty;
            txtOption.Text = String.Empty;
            lstOption.Clear();
            timer.uscTimer_Exit += new uscTimer.uscTimer_ExitHandle(uscTimer_TimeUp);
        }

        private void uscTimer_TimeUp()
        {
            MessageBox.Show("Hết thời gian làm bài!", "Thong bao");
            SaveResult();
        }

        private void lbQuiz_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbQuiz.SelectedIndex;
            if (index != -1)
            {
                if (isDoing == true)
                    isDoing = false;
                else
                {
                    txtQuestion.Text = lstQuiz[index].Question;
                    lstOption.Clear();
                    foreach (String s in lstQuiz[index].Option)
                        lstOption.Add(s);
                    lbOption.SelectedIndex = lstQuiz[index].Selected;
                    if (lbOption.SelectedIndex != -1)
                        txtOption.Text = lstOption[lbOption.SelectedIndex];
                    else txtOption.Text = String.Empty;
                    cbConsider.Checked = lstQuiz[index].Consider;
                }
            }
        }

        private void lbOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbQuiz.SelectedIndex != -1)
            {
                if (lbOption.SelectedIndex != -1)
                {
                    isDoing = true;
                    Quiz q = new Quiz();
                    q.ID = lstQuiz[lbQuiz.SelectedIndex].ID;
                    q.Question = lstQuiz[lbQuiz.SelectedIndex].Question;
                    foreach (String s in lstQuiz[lbQuiz.SelectedIndex].Option)
                        q.Option.Add(s);
                    q.Done = true;
                    q.Selected = lbOption.SelectedIndex;
                    q.Consider = lstQuiz[lbQuiz.SelectedIndex].Consider;
                    lstQuiz[lbQuiz.SelectedIndex] = q;
                    txtOption.Text = lstOption[lbOption.SelectedIndex];
                }
            }
        }

        private void cbConsider_CheckedChanged(object sender, EventArgs e)
        {
            if (lbQuiz.SelectedIndex != -1)
            {
                isDoing = true;
                Quiz q = new Quiz();
                q.ID = lstQuiz[lbQuiz.SelectedIndex].ID;
                q.Question = lstQuiz[lbQuiz.SelectedIndex].Question;
                foreach (String s in lstQuiz[lbQuiz.SelectedIndex].Option)
                    q.Option.Add(s);
                q.Done = lstQuiz[lbQuiz.SelectedIndex].Done;
                q.Selected = lstQuiz[lbQuiz.SelectedIndex].Selected;
                q.Consider = cbConsider.Checked;
                lstQuiz[lbQuiz.SelectedIndex] = q;
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (lbQuiz.SelectedIndex != lstQuiz.Count - 1)
                lbQuiz.SelectedIndex = lbQuiz.SelectedIndex + 1;
            else lbQuiz.SelectedIndex = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lbQuiz.SelectedIndex != 0)
                lbQuiz.SelectedIndex = lbQuiz.SelectedIndex - 1;
            else lbQuiz.SelectedIndex = lstQuiz.Count - 1;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveResult();
        }

        private void btnHideTimer_Click(object sender, EventArgs e)
        {
            if (timer.Visible == true)
            {
                timer.Visible = false;
                btnHideTimer.Text = "Hiện đồng hồ";
            }
            else
            { 
                timer.Visible = true;
                btnHideTimer.Text = "Ẩn đồng hồ";
            }
        }

        private void SaveResult()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "XML Files|*.xml";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (var xml = XmlWriter.Create(dlg.FileName, new XmlWriterSettings { Indent = true }))
                {
                    xml.WriteStartElement("Test");

                    xml.WriteStartElement("Name");
                    xml.WriteValue(UserName);
                    xml.WriteEndElement();

                    xml.WriteStartElement("TestID");
                    xml.WriteValue(TestID);
                    xml.WriteEndElement();

                    xml.WriteStartElement("Time");
                    xml.WriteValue(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                    xml.WriteEndElement();

                    xml.WriteStartElement("Answer");
                    for (int i = 0; i < lstQuiz.Count; i++)
                    {
                        xml.WriteStartElement("Option");
                        xml.WriteValue(lstQuiz[i].Selected);
                        xml.WriteEndElement();
                    }
                    xml.WriteEndElement();
                    xml.WriteEndElement();
                }
                this.Hide();
                frmEnd frm = new frmEnd();
                frm.Show();
            }
        }
    }
}