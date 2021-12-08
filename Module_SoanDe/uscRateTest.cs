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

namespace Module_SoanDe
{
    public partial class uscRateTest : UserControl
    {
        private List<TestTaker> lstTakers = new List<TestTaker> ();
        private List<String> key = new List<String> ();
        private String TestID = "";

        public uscRateTest()
        {
            InitializeComponent();
        }

        private void btnLoadKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "XML Files|*.xml";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                String path = dlg.FileName;
                using (var xml = XmlReader.Create(path))
                {
                    xml.ReadToFollowing("Test");
                    xml.MoveToAttribute("ID");
                    TestID = xml.Value;
                    while (xml.ReadToFollowing("Option"))
                    {
                        key.Add(xml.ReadElementContentAsString());
                    }
                }
                lblStatusKey.Visible = true;
                btnLoadKey.Enabled = false;
            }
        }

        private void btnLoadWork_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                String[] files = Directory.GetFiles(dlg.SelectedPath);
                foreach (String path in files)
                {
                    using (var xml = XmlReader.Create(path))
                    {
                        TestTaker t = new TestTaker();
                        xml.ReadToFollowing("Test");
                        xml.ReadToFollowing("Name");
                        t.Name = xml.ReadElementContentAsString();
                        xml.ReadToFollowing("TestID");
                        xml.ReadElementContentAsString();
                        xml.ReadToFollowing("Time");
                        t.Time = xml.ReadElementContentAsString();
                        xml.ReadToFollowing("Answer");
                        while (xml.ReadToFollowing("Option"))
                        {
                            t.Answer.Add(xml.ReadElementContentAsString());
                        }
                        lstTakers.Add(t);
                    }
                }
                lblStatusWork.Visible = true;
                btnLoadWork.Enabled = false;
            }
        }

        private void btnSaveResult_Click(object sender, EventArgs e)
        {
            CalScore();
            Sort(lstTakers);
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text Files|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = File.CreateText(dlg.FileName);
                sw.WriteLine($"Đề {TestID}");
                foreach (TestTaker t in lstTakers)
                {
                    String text = $"{t.Name} - {t.Score} - {t.Time}";
                    sw.WriteLine(text);
                }
                sw.Close();
            }
            lblStatusKey.Visible = false;
            lblStatusWork.Visible = false;
            btnLoadWork.Enabled = true;
            btnLoadKey.Enabled = true;
        }

        private void Sort(List<TestTaker> lst)
        {
            for (int i = 0; i < lst.Count - 1; i++)
            {
                bool isSwap = false;
                for (int j = 0; j < lst.Count - i - 1; j++)
                {
                    if (lst[j].Score < lst[j + 1].Score)
                    {
                        TestTaker t = lst[j];
                        lst[j] = lst[j + 1];
                        lst[j + 1] = t;
                        isSwap = true;
                    }
                }
                if (isSwap == false)
                    break;
            }
        }

        private void CalScore()
        {
            foreach (TestTaker t in lstTakers)
            {
                int correct = 0;
                for (int i = 0; i < t.Answer.Count; i++)
                {
                    if (t.Answer[i] == key[i])
                        correct++;
                }
                t.CorrectNumber = correct;
            }
        }
    }
}
