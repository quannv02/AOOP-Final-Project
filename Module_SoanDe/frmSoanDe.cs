using Module_SoanDe.Entities;
using System.ComponentModel;
using System.Xml;

namespace Module_SoanDe
{
    public partial class frmSoanDe : Form
    {
        //Tab 1
        private int count = 0;
        private int sortTopic = 0;
        private int sortQuiz = 0;
        private bool isAddingTopic = false;
        private bool isAddingQuiz = false;
        private bool isAddingOption = false;

        private Dictionary<int, Quiz> lstQuiz = new Dictionary<int, Quiz>();

        private BindingList<Quiz> lstDisplayingQuiz = new BindingList<Quiz>();
        private BindingList<String> lstTopicForListBox = new BindingList<String>() { "Tất cả chủ đề" };
        private BindingList<String> lstTopic = new BindingList<string>();
        private BindingList<Option> lstOption = new BindingList<Option>();

        //Tab 2
        private int sortTest = 0;
        private int sortQuizForTest = 0;
        private int sortTopicFiler = 0;
        private bool isAddingTest = false;
        private bool isAddingTestWBase = false;
        private bool isAddingOptionQT = false;

        private BindingList<String> lstTopicFilter = new BindingList<String>() { "Tất cả chủ đề" };
        private BindingList<Test> lstTest = new BindingList<Test>();
        private BindingList<Quiz> lstQuizForTest = new BindingList<Quiz>();
        private BindingList<Option> lstOptionQT = new BindingList<Option>();
        private BindingList<Quiz> lstQuizOfTest = new BindingList<Quiz>();

        public frmSoanDe()
        {
            InitializeComponent();
        }

        private void frmSoanDe_Load(object sender, EventArgs e)
        {
            lbTopic.DataSource = lstTopicForListBox;
            lbQuiz.DataSource = lstDisplayingQuiz;
            lbOption.DataSource = lstOption;
            cbbTopic.DataSource = lstTopic;
            cbbTopic.SelectedIndex = -1;

            lbTest.DataSource = lstTest;
            lbTestDetail.DataSource = lstQuizOfTest;
            lbQuizForTest.DataSource = lstQuizForTest;
            lbOptionQT.DataSource = lstOptionQT;
            cbbTopicFilter.DataSource = lstTopicFilter;
            cbbTopicFilter.SelectedIndex = -1;
        }

        //Tab 1

        private void lbQuiz_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstOption.Clear();
            if (lbQuiz.SelectedIndex != -1)
            {
                int index = lbQuiz.SelectedIndex;
                for (int i = 0; i < lstTopic.Count; i++)
                {
                    if (lstTopic[i] == lstDisplayingQuiz[index].Topic)
                        cbbTopic.SelectedIndex = i;
                }
                txtQuestion.Text = lstDisplayingQuiz[index].Question;
                foreach (var item in lstDisplayingQuiz[index].Answers)
                    lstOption.Add(item);
            }
            else
            {
                cbbTopic.SelectedIndex = -1;
                txtQuestion.Text = String.Empty;
                txtOption.Text = String.Empty;
            }
        }

        private void lbOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbOption.SelectedIndex != -1)
            {
                int index = lbOption.SelectedIndex;
                txtOption.Text = lstOption[index].Content;
                if (lstOption[index].IsTrue == true)
                    btnSelectKey.Enabled = false;
            }
        }

        private void lbTopic_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstDisplayingQuiz.Clear();
            if (lbTopic.SelectedIndex > 0)
            {
                String topic = lstTopicForListBox[lbTopic.SelectedIndex];
                foreach (var item in lstQuiz)
                {
                    if (item.Value.Topic == topic)
                        lstDisplayingQuiz.Add(item.Value);
                }
                txtTopicName.Text = topic;
                lblCount.Text = $"Chủ đề này có {lstDisplayingQuiz.Count} câu hỏi.";
            }
            else if (lbTopic.SelectedIndex == 0)
            {
                foreach (var item in lstQuiz)
                {
                    lstDisplayingQuiz.Add(item.Value);
                }
                txtTopicName.Text = $"Có tổng cộng {lstTopic.Count} chủ đề.";
                lblCount.Text = $"Kho có tổng cộng {lstQuiz.Count} câu hỏi.";
            }
            else
            {
                txtTopicName.Text = String.Empty;
                lblCount.Text = String.Empty;
            }
            sortQuiz = 0;
            SortQuiz(lstDisplayingQuiz, sortQuiz);
            lbQuiz.SelectedIndex = -1;
            if (lstDisplayingQuiz.Count > 0)
            {
                EnableQuizList(true);
            }
            else
            {
                EnableQuizList(false);
                if (lstTopic.Count > 0)
                    btnAddQuiz.Enabled = true;
            }
        }

        private void btnListTopic_Click(object sender, EventArgs e)
        {
            if (sortTopic == 0)
            {
                sortTopic = 1;
                SortTopic(lstTopicForListBox, sortTopic);
            }
            else
            {
                sortTopic = 0;
                SortTopic(lstTopicForListBox, sortTopic);
            }
            cbbTopic.SelectedIndex = -1;
        }

        private void btnSaveTopic_Click(object sender, EventArgs e)
        {
            if (txtTopicName.Text == String.Empty)
                MessageBox.Show("Không thể để trống tên chủ đề!", "Thong bao", MessageBoxButtons.OK);
            else
            {
                if (isAddingTopic == true)
                {
                    lstTopicForListBox.Add(txtTopicName.Text);
                    lstTopic.Add(txtTopicName.Text);
                    lstTopicFilter.Add(txtTopicName.Text);
                    isAddingTopic = false;
                }
                else
                {
                    String oldName = lstTopicForListBox[lbTopic.SelectedIndex];
                    String newName = txtTopicName.Text;
                    lstTopicForListBox[lbTopic.SelectedIndex] = newName;
                    lstTopic[lstTopic.IndexOf(oldName)] = newName;
                    lstTopicFilter[lstTopicFilter.IndexOf(oldName)] = newName;

                    List<int> editID = new List<int>();
                    foreach (var item in lstQuiz)
                    {
                        if (item.Value.Topic == oldName)
                            editID.Add(item.Key);
                    }
                    foreach (var item in editID)
                    {
                        lstQuiz[item].Topic = newName;
                    }
                }
                sortTopic = 0;
                sortTopicFiler = 0;
                SortTopic(lstTopicForListBox, sortTopic);
                SortTopic(lstTopic, sortTopic);
                SortTopic(lstTopicFilter, sortTopicFiler);
                EnableTopicList(true);
                EnableQuizList(true);
                EnableTopicDetail(false);
                cbbTopic.SelectedIndex = -1;
                if (lstDisplayingQuiz.Count == 0)
                {
                    btnEditQuiz.Enabled = false;
                    btnDeleteQuiz.Enabled = false;
                }
            }
        }

        private void btnAddTopic_Click(object sender, EventArgs e)
        {
            EnableTopicDetail(true);
            EnableQuizList(false);
            EnableTopicList(false);
            isAddingTopic = true;
            txtTopicName.Text = String.Empty;
            lbTopic.SelectedIndex = -1;
            lbQuiz.SelectedIndex = -1;
        }

        private void btnEditTopic_Click(object sender, EventArgs e)
        {
            if (lbTopic.SelectedIndex != -1)
            {
                EnableTopicDetail(true);
                EnableQuizList(false);
                EnableTopicList(false);
            }
            else
            {
                MessageBox.Show("Chọn chủ đề muốn sửa!", "Thong bao");
            }
        }

        private void btnDeleteTopic_Click(object sender, EventArgs e)
        {
            if (lbTopic.SelectedIndex > 0)
            {
                String caption = "Xóa chủ đề này sẽ xóa tất cả câu hỏi thuộc đề này có trong kho câu hỏi.";
                DialogResult dlg = MessageBox.Show(caption, "Thong bao", MessageBoxButtons.OKCancel);
                if (dlg == DialogResult.OK)
                {
                    List<int> deleteID = new List<int>();
                    foreach (var item in lstDisplayingQuiz)
                        deleteID.Add(item.ID);
                    foreach (var item in deleteID)
                        lstQuiz.Remove(item);
                    lstTopic.Remove(lstTopicForListBox[lbTopic.SelectedIndex]);
                    lstTopicFilter.Remove(lstTopicForListBox[lbTopic.SelectedIndex]);
                    lstTopicForListBox.RemoveAt(lbTopic.SelectedIndex);
                    if (lstTopic.Count == 0)
                    {
                        btnDeleteTopic.Enabled = false;
                        btnEditTopic.Enabled = false;
                        EnableQuizList(false);
                    }
                    if (lstDisplayingQuiz.Count == 0)
                    {
                        btnEditQuiz.Enabled = false;
                        btnDeleteQuiz.Enabled = false;
                    }
                    cbbTopic.SelectedIndex = -1;
                }
            }
            else if (lbTopic.SelectedIndex == 0)
            {
                MessageBox.Show("Đây không phải chủ đề!", "Thong bao");
            }
            else
            {
                MessageBox.Show("Chọn chủ đề muốn xóa!", "Thong bao");
            }
        }

        private void btnCancelTopicDetail_Click(object sender, EventArgs e)
        {
            if (isAddingTopic == true)
            {
                txtTopicName.Text = string.Empty;
            }
            else
            {
                txtTopicName.Text = lstTopicForListBox[lbTopic.SelectedIndex];
            }
            EnableTopicDetail(false);
            EnableQuizList(true);
            EnableTopicList(true);
            if (lstTopic.Count < 1)
            {
                btnEditTopic.Enabled = false;
                btnDeleteTopic.Enabled = false;
                EnableQuizList(false);
            }
            else
            {
                if (lstDisplayingQuiz.Count < 1)
                {
                    btnEditQuiz.Enabled = false;
                    btnDeleteQuiz.Enabled = false;
                }
            }
        }

        private void btnListQuiz_Click(object sender, EventArgs e)
        {
            if (sortQuiz == 0)
            {
                sortQuiz = 1;
                SortQuiz(lstDisplayingQuiz, sortQuiz);
            }
            else
            {
                sortQuiz = 0;
                SortQuiz(lstDisplayingQuiz, sortQuiz);
            }
        }

        private void btnAddQuiz_Click(object sender, EventArgs e)
        {
            EnableQuizList(false);
            EnableTopicList(false);
            EnableQuizDetail(true);
            lbTopic.SelectedIndex = -1;
            lbQuiz.SelectedIndex = -1;
            cbbTopic.Enabled = true;
            txtQuestion.Enabled = true;
            btnAddOption.Enabled = true;
            isAddingQuiz = true;
            lstOption.Clear();
        }

        private void btnEditQuiz_Click(object sender, EventArgs e)
        {
            if (lbQuiz.SelectedIndex != -1)
            {
                int index = lbQuiz.SelectedIndex;
                EnableQuizList(false);
                EnableTopicList(false);
                EnableQuizDetail(true);
                btnAddOption.Enabled = true;
                btnEditOption.Enabled = true;
                btnDeleteOption.Enabled = true;
                btnSelectKey.Enabled = true;
                cbbTopic.Enabled = true;
                txtQuestion.Enabled = true;
                lbOption.Enabled = true;
                lstOption.Clear();
                foreach (var item in lstDisplayingQuiz[index].Answers)
                    lstOption.Add(item);
                for (int i = 0; i < lstTopic.Count; i++)
                {
                    if (lstTopic[i] == lstDisplayingQuiz[index].Topic)
                    {
                        cbbTopic.SelectedIndex = i;
                        break;
                    }
                }
                txtQuestion.Text = lstDisplayingQuiz[index].Question;
            }
            else
            {
                MessageBox.Show("Chọn câu hỏi muốn sửa!", "Thong bao");
            }
        }

        private void btnDeleteQuiz_Click(object sender, EventArgs e)
        {
            if (lbQuiz.SelectedIndex != -1)
            {
                DialogResult dlg = MessageBox.Show("Bạn chắc chắn muốn xóa câu hỏi này khỏi kho?", "Thong bao", MessageBoxButtons.OKCancel);
                if (dlg == DialogResult.OK)
                {
                    int index = lbQuiz.SelectedIndex;
                    int deleteID = lstDisplayingQuiz[index].ID;
                    lstDisplayingQuiz.RemoveAt(index);
                    lstQuiz.Remove(deleteID);
                    if (lstDisplayingQuiz.Count == 0)
                    {
                        btnEditQuiz.Enabled = false;
                        btnDeleteQuiz.Enabled = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Chọn câu hỏi muốn xóa!", "Thong bao");
            }
        }

        private void btnSaveQuiz_Click(object sender, EventArgs e)
        {
            bool flag = false;
            foreach (var item in lstOption)
            {
                if (item.IsTrue == true)
                { 
                    flag = true;
                    break;
                }
            }
            if (cbbTopic.SelectedIndex == -1 || flag == false ||
                txtQuestion.Text == string.Empty || lstOption.Count < 2)
            {
                MessageBox.Show("Câu hỏi phải có ít nhất 2 đáp án. Không thể để trống chủ đề, câu hỏi và không chọn đáp áp đúng", "Thong bao");
            }
            else
            {
                if (isAddingQuiz == true)
                {
                    Quiz q = new Quiz();
                    q.ID = count;
                    count++;
                    q.Question = txtQuestion.Text;
                    q.Topic = lstTopic[cbbTopic.SelectedIndex];
                    foreach (var item in lstOption)
                        q.Answers.Add(item);
                    lstQuiz.Add(q.ID, q);
                    lbTopic.SelectedIndex = 0;
                    isAddingQuiz = false;
                }
                else
                {
                    int index = lbQuiz.SelectedIndex;
                    Quiz tmp = new Quiz();
                    tmp.ID = lstDisplayingQuiz[index].ID;
                    tmp.Question = txtQuestion.Text;
                    tmp.Topic = lstTopic[cbbTopic.SelectedIndex];
                    foreach (var item in lstOption)
                        tmp.Answers.Add(item);
                    lstDisplayingQuiz[index] = tmp;
                    lstQuiz[lstDisplayingQuiz[index].ID] = lstDisplayingQuiz[index];
                }
                sortQuiz = 0;
                SortQuiz(lstDisplayingQuiz, sortQuiz);
                EnableQuizDetail(false);
                EnableQuizList(true);
                EnableTopicList(true);
                btnAddOption.Enabled = false;
                btnEditOption.Enabled = false;
                btnDeleteOption.Enabled = false;
                btnSelectKey.Enabled = false;
                btnSaveOption.Enabled = false;
                btnCancelQuizDetailOption.Enabled = false;
            }
        }

        private void btnCancelQuizDetail_Click(object sender, EventArgs e)
        {
            if (isAddingQuiz == true)
            {
                cbbTopic.SelectedIndex = -1;
                txtQuestion.Text = string.Empty;
                txtOption.Text = string.Empty;
                lstOption.Clear();
            }
            else
            {
                int index = lbQuiz.SelectedIndex;
                for (int i = 1; i < lstTopicForListBox.Count; i++)
                {
                    if (lstTopicForListBox[i] == lstDisplayingQuiz[index].Topic)
                    {
                        cbbTopic.SelectedIndex = i;
                        break;
                    }
                }
                txtQuestion.Text = lstDisplayingQuiz[index].Question;
                lstOption.Clear();
                foreach (var item in lstDisplayingQuiz[index].Answers)
                    lstOption.Add(item);
            }
            EnableQuizDetail(false);
            EnableQuizList(true);
            EnableTopicList(true);
            if (lstDisplayingQuiz.Count == 0)
            {
                btnEditQuiz.Enabled = false;
                btnDeleteQuiz.Enabled = false;
            }
        }

        private void btnAddOption_Click(object sender, EventArgs e)
        {
            txtOption.Text = string.Empty;
            txtOption.Enabled = true;
            btnAddOption.Enabled = false;
            btnEditOption.Enabled = false;
            btnSelectKey.Enabled = false;
            btnDeleteOption.Enabled = false;
            btnSaveOption.Enabled = true;
            btnCancelQuizDetailOption.Enabled = true;
            btnSaveQuiz.Enabled = false;
            btnCancelQuizDetail.Enabled = false;
            isAddingOption = true;
            lbOption.SelectedIndex = -1;
        }

        private void btnEditOption_Click(object sender, EventArgs e)
        {
            if (lbOption.SelectedIndex != -1)
            {
                btnAddOption.Enabled = false;
                btnEditOption.Enabled = false;
                btnSelectKey.Enabled = false;
                btnDeleteOption.Enabled = false;
                btnSaveOption.Enabled = true;
                btnCancelQuizDetailOption.Enabled = true;
                txtOption.Text = lstOption[lbOption.SelectedIndex].Content;
                txtOption.Enabled = true;
            }
            else
            {
                MessageBox.Show("Chọn đáp án muốn sửa!", "Thong bao");
            }
        }

        private void btnSaveOption_Click(object sender, EventArgs e)
        {
            if (txtOption.Text == String.Empty)
                MessageBox.Show("Không thể đế trống đáp án!", "Thong bao");
            else
            {
                if (isAddingOption == true)
                {
                    Option newOp = new Option();
                    newOp.Content = txtOption.Text;
                    lstOption.Add(newOp);
                    lbOption.SelectedIndex = lstOption.Count - 1;
                    isAddingOption = false;
                }
                else
                {
                    Option newOp = new Option();
                    newOp.Content = txtOption.Text;
                    newOp.IsTrue = lstOption[lbOption.SelectedIndex].IsTrue;
                    lstOption[lbOption.SelectedIndex] = newOp;
                }
                btnSaveOption.Enabled = false;
                btnCancelQuizDetailOption.Enabled = false;
                btnAddOption.Enabled = true;
                btnEditOption.Enabled = true;
                btnDeleteOption.Enabled = true;
                btnSelectKey.Enabled = true;
                txtOption.Enabled = false;
                btnSaveQuiz.Enabled = true;
                btnCancelQuizDetail.Enabled = true;
            }
        }

        private void btnDeleteOption_Click(object sender, EventArgs e)
        {
            if (lbOption.SelectedIndex != -1)
            {
                lstOption.RemoveAt(lbOption.SelectedIndex);
                if (lstOption.Count == 0)
                {
                    btnEditOption.Enabled = false;
                    btnDeleteOption.Enabled = false;
                    btnSelectKey.Enabled = false;
                    txtOption.Text = String.Empty;
                }
            }
            else
                MessageBox.Show("Chọn đáp án muốn xóa!", "Thong bao");
        }

        private void btnCancelQuizDetailOption_Click(object sender, EventArgs e)
        {
            if (isAddingOption == true)
            {
                txtOption.Text = String.Empty;
            }
            else
            {
                int index = lbOption.SelectedIndex;
                txtOption.Text = lstOption[index].Content;
            }
            btnSaveOption.Enabled = false;
            btnCancelQuizDetailOption.Enabled = false;
            btnAddOption.Enabled = true;
            txtOption.Enabled = false;
            btnSaveQuiz.Enabled = true;
            btnCancelQuizDetail.Enabled = true;
            if (lstOption.Count > 0)
            {
                btnEditOption.Enabled = true;
                btnDeleteOption.Enabled = true;
                btnSelectKey.Enabled = true;
            }
        }

        private void btnSelectKey_Click(object sender, EventArgs e)
        {
            if (lbOption.SelectedIndex != -1)
            {
                CheckAllOptionFalse();
                Option tmp = new Option();
                tmp.Content = lstOption[lbOption.SelectedIndex].Content;
                tmp.IsTrue = true;
                lstOption[lbOption.SelectedIndex] = tmp;
                btnSelectKey.Enabled = false;
            }
            else
                MessageBox.Show("Chọn đáp án đúng!", "Thong bao");
        }

        private void SortTopic(BindingList<String> lst, int criteria)
        {
            for (int i = 0; i < lst.Count - 1; i++)
            {
                int selected = i;
                for (int j = i + 1; j < lst.Count; j++)
                {
                    switch (criteria)
                    {
                        case 0:
                            if (String.Compare(lst[j], lst[selected]) < 0)
                                selected = j;
                            break;
                        case 1:
                            if (String.Compare(lst[j], lst[selected]) > 0)
                                selected = j;
                            break;
                        default:
                            break;
                    }
                }
                if (selected != i)
                {
                    String tmp = lst[selected];
                    lst[selected] = lst[i];
                    lst[i] = tmp;
                }
            }
            bool flag = false;
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i] == "Tất cả chủ đề")
                {
                    flag = true;
                    lst.RemoveAt(i);
                }
            }
            if (flag == true)
                lst.Insert(0, "Tất cả chủ đề");
            cbbTopic.SelectedIndex = -1;
        }

        private void SortQuiz(BindingList<Quiz> lst, int criteria)
        {
            for (int i = 0; i < lst.Count - 1; i++)
            {
                int selected = i;
                for (int j = i + 1; j < lst.Count; j++)
                {
                    switch (criteria)
                    {
                        case 0:
                            if (String.Compare(lst[j].Question, lst[selected].Question) < 0)
                                selected = j;
                            break;
                        case 1:
                            if (String.Compare(lst[j].Question, lst[selected].Question) > 0)
                                selected = j;
                            break;
                        default:
                            break;
                    }
                }
                if (selected != i)
                {
                    Quiz tmp = lst[selected];
                    lst[selected] = lst[i];
                    lst[i] = tmp;
                }
            }
        }

        private void EnableTopicList(bool b)
        {
            btnAddTopic.Enabled = b;
            btnEditTopic.Enabled = b;
            btnDeleteTopic.Enabled = b;
            btnListTopic.Enabled = b;
            lbTopic.Enabled = b;
        }

        private void EnableQuizList(bool b)
        {
            btnAddQuiz.Enabled = b;
            btnEditQuiz.Enabled = b;
            btnDeleteQuiz.Enabled = b;
            btnListQuiz.Enabled = b;
            lbQuiz.Enabled = b;
        }

        private void EnableQuizDetail(bool b)
        {
            btnSaveQuiz.Enabled = b;
            btnCancelQuizDetail.Enabled = b;
            cbbTopic.Enabled = b;
            txtQuestion.Enabled = b;
            lbOption.Enabled = b;
        }

        private void EnableTopicDetail(bool b)
        {
            btnSaveTopic.Enabled = b;
            btnCancelTopicDetail.Enabled = b;
            txtTopicName.Enabled = b;
        }

        private void CheckAllOptionFalse()
        {
            for (int i = 0; i < lstOption.Count; i++)
            {
                Option tmp = new Option();
                tmp.Content = lstOption[i].Content;
                tmp.IsTrue = false;
                lstOption[i] = tmp;
            }
        }

        private void btnLoadQuiz_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "XML files|*.xml";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                String path = dlg.FileName;
                LoadQuiz(path);
                sortTopic = 0;
                SortTopic(lstTopic, sortTopic);
                foreach (var item in lstTopic)
                    lstTopicForListBox.Add(item);
                foreach (var item in lstTopic)
                    lstTopicFilter.Add(item);
                lbTopic.SelectedIndex = -1;
                if (lstTopic.Count > 0)
                {
                    btnEditTopic.Enabled = true;
                    btnDeleteTopic.Enabled = true;
                    btnAddQuiz.Enabled = true;
                }
                else
                {
                    btnEditTopic.Enabled = false;
                    btnDeleteTopic.Enabled = false;
                }
                if (lstDisplayingQuiz.Count > 0)
                {
                    EnableQuizList(true);
                }
            }
        }

        private void LoadQuiz(String path)
        {
            using (var xml = XmlReader.Create(path))
            {
                xml.ReadToFollowing("QuizStorage");
                while (xml.ReadToFollowing("Quiz"))
                {
                    Quiz q = new Quiz();
                    xml.ReadToFollowing("Topic");
                    q.Topic = xml.ReadElementContentAsString();

                    if (lstTopic.Contains(q.Topic) == false)
                        lstTopic.Add(q.Topic);

                    xml.ReadToFollowing("Question");
                    q.Question = xml.ReadElementContentAsString();
                    xml.ReadToFollowing("Answer");
                    xml.MoveToAttribute("count");

                    int n = int.Parse(xml.Value);
                    for (int i = 0; i < n; i++)
                    {
                        Option op = new Option();
                        xml.ReadToFollowing("Option");
                        xml.ReadToFollowing("Content");
                        op.Content = xml.ReadElementContentAsString();
                        xml.ReadToFollowing("IsTrue");
                        if (xml.ReadElementContentAsString() == "true")
                            op.IsTrue = true;
                        q.Answers.Add(op);
                    }
                    q.ID = count;
                    count++;
                    lstQuiz.Add(q.ID, q);
                }
            }
        }

        // End tab1

        // Tab 2

        private void btnListQuizForAdding_Click(object sender, EventArgs e)
        {
            if (sortQuizForTest == 0)
            {
                sortQuizForTest = 1;
                SortQuiz(lstQuizForTest, sortQuizForTest);
            }
            else
            {
                sortQuizForTest = 0;
                SortQuiz(lstQuizForTest, sortQuizForTest);
            }
        }

        private void cbbTopicFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstQuizForTest.Clear();
            if (cbbTopicFilter.SelectedIndex > 0)
            {
                String topic = lstTopicFilter[cbbTopicFilter.SelectedIndex];
                foreach (var item in lstQuiz)
                {
                    if (item.Value.Topic == topic)
                        lstQuizForTest.Add(item.Value);
                }
            }
            else if (cbbTopicFilter.SelectedIndex == 0)
            {
                foreach (var item in lstQuiz)
                    lstQuizForTest.Add(item.Value);
            }
            sortQuizForTest = 0;
            SortQuiz(lstQuizForTest, sortQuizForTest);
        }

        private void lbQuizForTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbViewQuizOption.Items.Clear();
            if (lbQuizForTest.SelectedIndex != -1)
            {
                int index = lbQuizForTest.SelectedIndex;
                txtViewQuizTopic.Text = lstQuizForTest[index].Topic;
                txtViewQuizQuestion.Text = lstQuizForTest[index].Question;
                foreach (var item in lstQuizForTest[index].Answers)
                    lbViewQuizOption.Items.Add(item);
            }
            else
            {
                txtViewQuizTopic.Text = String.Empty;
                txtViewQuizQuestion.Text = String.Empty;
            }
        }

        private void btnListTest_Click(object sender, EventArgs e)
        {
            if (sortTest == 0)
            {
                sortTest = 1;
                SortTest(lstTest, sortTest);
            }
            else
            {
                sortTest = 0;
                SortTest(lstTest, sortTest);
            }
        }

        private void btnAddTest_Click(object sender, EventArgs e)
        {
            EnableTestDetail(true);
            EnableTestList(false);
            btnAddQuizToTest.Enabled = true;
            isAddingTest = true;
            lbTest.SelectedIndex = -1;
            txtTestName.Text = String.Empty;
            txtQuizNumber.Text = String.Empty;
        }

        private void btnAddTestWithBase_Click(object sender, EventArgs e)
        {
            EnableTestDetail(true);
            EnableTestList(false);
            btnAddQuizToTest.Enabled = true;
            isAddingTestWBase = true;
        }

        private void btnDeleteTest_Click(object sender, EventArgs e)
        {
            if (lbQuizForTest.SelectedIndex != -1)
            {
                DialogResult dlg = MessageBox.Show("Bạn chắc chắn muốn xóa đề thi này? ", "Thong bao", MessageBoxButtons.OKCancel);
                if (dlg == DialogResult.OK)
                    lstTest.RemoveAt(lbTest.SelectedIndex);
            }
            else
                MessageBox.Show("Chọn đề muốn xóa", "Thong bao");
        }

        private void lbTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstQuizOfTest.Clear();
            if (lbTest.SelectedIndex != -1)
            {
                foreach (var item in lstTest[lbTest.SelectedIndex].lstTestQuiz)
                    lstQuizOfTest.Add(item);
                txtTestName.Text = lstTest[lbTest.SelectedIndex].Name;
                txtQuizNumber.Text = lstTest[lbTest.SelectedIndex].lstTestQuiz.Count.ToString();
            }
        }

        private void btnAddQuizToTest_Click(object sender, EventArgs e)
        {
            if (lbQuizForTest.SelectedIndex != -1)
            {
                lstQuizOfTest.Add(lstQuizForTest[lbQuizForTest.SelectedIndex]);
            }
            else
                MessageBox.Show("Chọn câu hỏi muốn thêm vào", "Thong bao");
        }

        private void EnableTestDetail(bool b)
        {
            btnRandomGenerate.Enabled = b;
            btnAddQuizToTest.Enabled = b;
            txtTestName.Enabled = b;
            txtQuizNumber.Enabled = b;
            btnDeleteQuizFromTest.Enabled = b;
            btnEditQuizFromTest.Enabled = b;
            btnSaveTest.Enabled = b;
            btnCancelTest.Enabled = b;
            btnGoDown.Enabled = b;
            btnGoUp.Enabled = b;
        }

        private void EnableTestList(bool b)
        {
            btnAddTest.Enabled = b;
            btnAddTestWithBase.Enabled = b;
            btnDeleteTest.Enabled = b;
            lbTest.Enabled = b;
            btnListTest.Enabled = b;
            btnEditTest.Enabled = b;
        }

        private void btnLoadTest_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "XML files|*.xml";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                String path = dlg.FileName;
                LoadTest(path);
                sortTest = 0;
                SortTest(lstTest, sortTest);
                if (lstTest.Count > 0)
                    EnableTestList(true);
                else
                {
                    btnDeleteTest.Enabled = false;
                    btnAddTestWithBase.Enabled = false;
                }
            }
        }

        private void LoadTest(string path)
        {
            using (var xml = XmlReader.Create(path))
            {
                xml.ReadToFollowing("TestStorage");
                while (xml.ReadToFollowing("Test"))
                {
                    Test t = new Test();
                    xml.MoveToAttribute("name");
                    t.Name = xml.Value;
                    xml.ReadToFollowing("CountQuiz");
                    int n = int.Parse(xml.ReadElementContentAsString());
                    for (int i = 0; i < n; i++)
                    {
                        Quiz q = new Quiz();
                        xml.ReadToFollowing("Topic");
                        q.Topic = xml.ReadElementContentAsString();

                        xml.ReadToFollowing("Question");
                        q.Question = xml.ReadElementContentAsString();

                        xml.ReadToFollowing("Answer");
                        xml.MoveToAttribute("count");

                        int nO = int.Parse(xml.Value);
                        for (int j = 0; j < nO; j++)
                        {
                            Option op = new Option();
                            xml.ReadToFollowing("Option");
                            xml.ReadToFollowing("Content");
                            op.Content = xml.ReadElementContentAsString();
                            xml.ReadToFollowing("IsTrue");
                            if (xml.ReadElementContentAsString() == "true")
                                op.IsTrue = true;
                            q.Answers.Add(op);
                        }
                        t.lstTestQuiz.Add(q);
                    }
                    lstTest.Add(t);
                }
            }
        }

        private void SortTest(BindingList<Test> lst, int criteria)
        {
            for (int i = 0; i < lst.Count - 1; i++)
            {
                int selected = i;
                for (int j = i + 1; j < lst.Count; j++)
                {
                    switch (criteria)
                    {
                        case 0:
                            if (String.Compare(lst[j].Name, lst[selected].Name) < 0)
                                selected = j;
                            break;
                        case 1:
                            if (String.Compare(lst[j].Name, lst[selected].Name) > 0)
                                selected = j;
                            break;
                        default:
                            break;
                    }
                }
                if (selected != i)
                {
                    Test tmp = lst[selected];
                    lst[selected] = lst[i];
                    lst[i] = tmp;
                }
            }
        }

        private void lbTestDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstOptionQT.Clear();
            int index = lbTestDetail.SelectedIndex;
            if (index != -1)
            {
                txtTopicQT.Text = lstQuizOfTest[index].Topic;
                txtQuestionQT.Text = lstQuizOfTest[index].Question;
                foreach (var item in lstQuizOfTest[index].Answers)
                    lstOptionQT.Add(item);
            }
            else
            {
                txtOptionQT.Text = String.Empty;
                txtTopicQT.Text = String.Empty;
                txtQuestionQT.Text = String.Empty;
            }
        }

        private void btnEditQuizFromTest_Click(object sender, EventArgs e)
        {
            if (lbTestDetail.SelectedIndex != -1)
            {
                int index = lbTestDetail.SelectedIndex;
                EnableTestDetail(false);
                EnableTestList(false);
                EnableQuizOfTest(true);
                btnAddOptionQT.Enabled = true;
                btnEditOptionQT.Enabled = true;
                btnDeleteOptionQT.Enabled = true;
                btnSelectKeyQT.Enabled = true;
                lstOptionQT.Clear();
                foreach (var item in lstQuizOfTest[index].Answers)
                    lstOptionQT.Add(item);
            }
            else
            {
                MessageBox.Show("Chọn câu hỏi muốn sửa!", "Thong bao");
            }
        }

        private void EnableQuizOfTest(bool b)
        {
            btnSaveQuizFromTest.Enabled = b;
            btnCancelQuizFromTest.Enabled = b;
            txtTopicQT.Enabled = b;
            txtQuestionQT.Enabled = b;
            lbOptionQT.Enabled = b;
        }

        private void btnDeleteQuizFromTest_Click(object sender, EventArgs e)
        {
            if (lbTestDetail.SelectedIndex != -1)
            {
                lstQuizOfTest.RemoveAt(lbTestDetail.SelectedIndex);
            }
        }

        private void btnCancelQuizFromTest_Click(object sender, EventArgs e)
        {
            EnableQuizOfTest(false);
            EnableTestDetail(true);
            EnableTestList(true);
            lbTestDetail.SelectedIndex = lbTestDetail.SelectedIndex;
        }

        private void btnAddOptionQT_Click(object sender, EventArgs e)
        {
            txtOptionQT.Text = string.Empty;
            txtOptionQT.Enabled = true;
            btnAddOptionQT.Enabled = false;
            btnEditOptionQT.Enabled = false;
            btnSelectKeyQT.Enabled = false;
            btnDeleteOptionQT.Enabled = false;
            btnSaveOptionQT.Enabled = true;
            btnCancelOptionQT.Enabled = true;
            btnSaveQuizFromTest.Enabled = false;
            btnCancelQuizFromTest.Enabled = false;
            isAddingOptionQT = true;
            lbOptionQT.SelectedIndex = -1;
        }

        private void btnEditOptionQT_Click(object sender, EventArgs e)
        {
            if (lbOptionQT.SelectedIndex != -1)
            {
                btnAddOptionQT.Enabled = false;
                btnEditOptionQT.Enabled = false;
                btnSelectKeyQT.Enabled = false;
                btnDeleteOptionQT.Enabled = false;
                btnSaveOptionQT.Enabled = true;
                btnCancelOptionQT.Enabled = true;
                txtOptionQT.Text = lstOptionQT[lbOptionQT.SelectedIndex].Content;
                txtOptionQT.Enabled = true;
            }
            else
            {
                MessageBox.Show("Chọn đáp án muốn sửa!", "Thong bao");
            }
        }

        private void btnSaveOptionQT_Click(object sender, EventArgs e)
        {
            if (txtOptionQT.Text == String.Empty)
                MessageBox.Show("Không thể đế trống đáp án!", "Thong bao");
            else
            {
                if (isAddingOptionQT == true)
                {
                    Option newOp = new Option();
                    newOp.Content = txtOptionQT.Text;
                    lstOptionQT.Add(newOp);
                    lbOptionQT.SelectedIndex = lstOptionQT.Count - 1;
                    isAddingOptionQT = false;
                }
                else
                {
                    Option newOp = new Option();
                    newOp.Content = txtOptionQT.Text;
                    newOp.IsTrue = lstOptionQT[lbOptionQT.SelectedIndex].IsTrue;
                    lstOptionQT[lbOptionQT.SelectedIndex] = newOp;
                }
                btnSaveOptionQT.Enabled = false;
                btnCancelOptionQT.Enabled = false;
                btnAddOptionQT.Enabled = true;
                btnEditOptionQT.Enabled = true;
                btnDeleteOptionQT.Enabled = true;
                btnSelectKeyQT.Enabled = true;
                txtOptionQT.Enabled = false;
                btnSaveQuizFromTest.Enabled = true;
                btnCancelQuizFromTest.Enabled = true;
            }
        }

        private void btnCancelOptionQT_Click(object sender, EventArgs e)
        {
            if (isAddingOptionQT == true)
            {
                txtOptionQT.Text = String.Empty;
            }
            else
            {
                int index = lbOptionQT.SelectedIndex;
                txtOptionQT.Text = lstOptionQT[index].Content;
            }
            btnSaveOptionQT.Enabled = false;
            btnCancelOptionQT.Enabled = false;
            btnAddOptionQT.Enabled = true;
            txtOptionQT.Enabled = false;
            btnSaveQuizFromTest.Enabled = true;
            btnCancelQuizFromTest.Enabled = true;
            if (lstOptionQT.Count > 0)
            {
                btnEditOptionQT.Enabled = true;
                btnDeleteOptionQT.Enabled = true;
                btnSelectKeyQT.Enabled = true;
            }
        }

        private void btnDeleteOptionQT_Click(object sender, EventArgs e)
        {
            if (lbOptionQT.SelectedIndex != -1)
            {
                lstOptionQT.RemoveAt(lbOptionQT.SelectedIndex);
                if (lstOptionQT.Count == 0)
                {
                    btnEditOptionQT.Enabled = false;
                    btnDeleteOptionQT.Enabled = false;
                    btnSelectKeyQT.Enabled = false;
                    txtOptionQT.Text = String.Empty;
                }
            }
            else
                MessageBox.Show("Chọn đáp án muốn xóa!", "Thong bao");
        }

        private void btnSelectKeyQT_Click(object sender, EventArgs e)
        {
            if (lbOptionQT.SelectedIndex != -1)
            {
                CheckAllOptionQTFalse();
                Option tmp = new Option();
                tmp.Content = lstOptionQT[lbOptionQT.SelectedIndex].Content;
                tmp.IsTrue = true;
                lstOptionQT[lbOptionQT.SelectedIndex] = tmp;
                btnSelectKeyQT.Enabled = false;
            }
            else
                MessageBox.Show("Chọn đáp án đúng!", "Thong bao");
        }

        private void CheckAllOptionQTFalse()
        {
            for (int i = 0; i < lstOptionQT.Count; i++)
            {
                Option tmp = new Option();
                tmp.Content = lstOptionQT[i].Content;
                tmp.IsTrue = false;
                lstOptionQT[i] = tmp;
            }
        }

        private void btnEditTest_Click(object sender, EventArgs e)
        {
            if (lbTest.SelectedIndex != -1)
            {
                EnableTestDetail(true);
                EnableTestList(false);
                btnAddQuizToTest.Enabled = true;
            }
            else MessageBox.Show("Chọn đề muốn sửa!", "Thong bao");
        }

        private void btnSaveTest_Click(object sender, EventArgs e)
        {
            if (isAddingTest == true || isAddingTestWBase == true)
            {
                if (txtTestName.Text == String.Empty || lstQuizOfTest.Count == 0)
                    MessageBox.Show("Đề phải có tên và có câu hỏi!", "Thong bao");
                else
                {
                    EnableTestDetail(false);
                    EnableTestList(true);
                    Test t = new Test();
                    t.Name = txtTestName.Text;
                    foreach (var item in lstQuizOfTest)
                        t.lstTestQuiz.Add(item);
                    lstTest.Add(t);
                }
            }
            else
            {
                if (txtTestName.Text == String.Empty || lstQuizOfTest.Count == 0)
                    MessageBox.Show("Đề phải có tên và có câu hỏi!", "Thong bao");
                else
                {
                    EnableTestDetail(false);
                    EnableTestList(true);
                    Test t = new Test();
                    t.Name = txtTestName.Text;
                    foreach (var item in lstQuizOfTest)
                        t.lstTestQuiz.Add(item);
                    lstTest[lbTest.SelectedIndex] = t;
                }
            }
        }

        private void btnCancelTest_Click(object sender, EventArgs e)
        {
            EnableTestDetail(false);
            EnableTestList(true);
            lstQuizOfTest.Clear();
            if (isAddingTest == true)
            {
                isAddingTest = false;
            }
            else if (isAddingTestWBase == true)
            {
                foreach (var item in lstTest[lbTest.SelectedIndex].lstTestQuiz)
                    lstQuizOfTest.Add(item);
            }
            else
            {
                foreach (var item in lstTest[lbTest.SelectedIndex].lstTestQuiz)
                    lstQuizOfTest.Add(item);
            }
            if (lstTest.Count == 0)
            {
                btnEditTest.Enabled = false;
                btnDeleteTest.Enabled = false;
                btnAddTestWithBase.Enabled = false;
            }
        }

        private void btnGoUp_Click(object sender, EventArgs e)
        {
            int index = lbTestDetail.SelectedIndex;
            if (index != -1)
            {
                if (index == 0)
                    MessageBox.Show("Đã ở vị trí đầu!", "Thong bao");
                else
                {
                    Quiz tmp = lstQuizOfTest[index - 1];
                    lstQuizOfTest[index - 1] = lstQuizOfTest[index];
                    lstQuizOfTest[index] = tmp;
                    lbTestDetail.SelectedIndex = index - 1;
                }
            }
            else MessageBox.Show("Chọn câu hỏi muốn thay đổi vị trí!", "Thong bao");
        }

        private void btnGoDown_Click(object sender, EventArgs e)
        {
            int index = lbTestDetail.SelectedIndex;
            if (index != -1)
            {
                if (index == lstQuizOfTest.Count - 1)
                    MessageBox.Show("Đã ở vị trí cuối!", "Thong bao");
                else
                {
                    Quiz tmp = lstQuizOfTest[index + 1];
                    lstQuizOfTest[index + 1] = lstQuizOfTest[index];
                    lstQuizOfTest[index] = tmp;
                    lbTestDetail.SelectedIndex = index + 1;
                }
            }
            else MessageBox.Show("Chọn câu hỏi muốn thay đổi vị trí!", "Thong bao");
        }

        private void btnRandomGenerate_Click(object sender, EventArgs e)
        {
            if (txtQuizNumber.Text != String.Empty)
            {
                if (int.TryParse(txtQuizNumber.Text, out int n))
                {
                    lstQuizOfTest.Clear();
                    Random r = new Random();
                    for (int i = 0; i < n; i++)
                    {
                        lstQuizOfTest.Add(lstQuizForTest[r.Next(lstQuizForTest.Count)]);
                    }
                }
                else MessageBox.Show("Nhập số nguyên", "Thong bao");
            }
            else MessageBox.Show("Nhập số lượng câu hỏi", "Thong bao");
        }

        private void btnSaveQuizFromTest_Click(object sender, EventArgs e)
        {
            bool flag = false;
            foreach (var item in lstOptionQT)
            {
                if (item.IsTrue == true)
                {
                    flag = true;
                    break;
                }
            }
            if (flag == false || txtQuestionQT.Text == string.Empty || lstOptionQT.Count < 2)
            {
                MessageBox.Show("Câu hỏi phải có ít nhất 2 đáp án. Không thể để trống chủ đề, câu hỏi và không chọn đáp áp đúng", "Thong bao");
            }
            else
            {
                Quiz q = new Quiz();
                q.Topic = txtTopicQT.Text;
                q.Question = txtQuestionQT.Text;
                foreach (var item in lstOptionQT)
                    q.Answers.Add(item);
                lstQuizOfTest[lbTestDetail.SelectedIndex] = q;
                EnableTestDetail(false);
                btnAddOptionQT.Enabled = false;
                btnEditOptionQT.Enabled = false;
                btnDeleteOptionQT.Enabled = false;
                btnSelectKeyQT.Enabled = false;
                btnSaveOptionQT.Enabled = false;
                btnCancelOptionQT.Enabled = false;
                btnSaveQuizFromTest.Enabled = false;
                btnCancelQuizFromTest.Enabled = false;
                EnableTestList(true);
            }
        }

        private void btnPublishTest_Click(object sender, EventArgs e)
        {
            int index = lbTest.SelectedIndex;
            if (lbTest.SelectedIndex != -1)
            { 
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "XML Files|*.xml";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    using (var xml = XmlWriter.Create(dlg.FileName, new XmlWriterSettings { Indent = true }))
                    {
                        xml.WriteStartElement("Test");
                        xml.WriteAttributeString("ID", lstTest[index].Name);
                        foreach (var item in lstTest[index].lstTestQuiz)
                        {
                            xml.WriteStartElement("Quiz");

                            xml.WriteStartElement("Question");
                            xml.WriteValue(item.Question);
                            xml.WriteEndElement();

                            xml.WriteStartElement("Answer");
                            xml.WriteAttributeString("count", item.Answers.Count.ToString());
                            foreach (var op in item.Answers)
                            {
                                xml.WriteStartElement("Option");
                                xml.WriteValue(op.Content);
                                xml.WriteEndElement();
                            }
                            xml.WriteEndElement();
                            xml.WriteEndElement();
                        }
                        xml.WriteEndElement();
                    }
                }
            }
        }

        private void btnPublishKey_Click(object sender, EventArgs e)
        {
            int index = lbTest.SelectedIndex;
            if (lbTest.SelectedIndex != -1)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "XML Files|*.xml";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    using (var xml = XmlWriter.Create(dlg.FileName, new XmlWriterSettings { Indent = true }))
                    {
                        xml.WriteStartElement("Test");
                        xml.WriteAttributeString("ID", lstTest[index].Name);
                        foreach (var item in lstTest[index].lstTestQuiz)
                        {
                            xml.WriteStartElement("Option");
                            int key = -1;
                            for (int i = 0; i < item.Answers.Count; i++)
                            {
                                if (item.Answers[i].IsTrue == true)
                                { 
                                    key = i;
                                    break;
                                }
                            }
                            xml.WriteValue(key);
                            xml.WriteEndElement();
                        }
                        xml.WriteEndElement();
                    }
                }
            }
        }

        private void btnSaveQuizStorage_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "XML Files|*.xml";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (var xml = XmlWriter.Create(dlg.FileName, new XmlWriterSettings { Indent = true }))
                {
                    xml.WriteStartElement("QuizStorage");

                    foreach (var item in lstQuiz)
                    {
                        xml.WriteStartElement("Quiz");

                        xml.WriteStartElement("Topic");
                        xml.WriteValue(item.Value.Topic);
                        xml.WriteEndElement();

                        xml.WriteStartElement("Question");
                        xml.WriteValue(item.Value.Question);
                        xml.WriteEndElement();

                        xml.WriteStartElement("Answer");
                        xml.WriteAttributeString("count", item.Value.Answers.Count.ToString());
                        foreach (var op in item.Value.Answers)
                        {
                            xml.WriteStartElement("Option");

                            xml.WriteStartElement("Content");
                            xml.WriteValue(op.Content);
                            xml.WriteEndElement();

                            xml.WriteStartElement("IsTrue");
                            xml.WriteValue(op.IsTrue);
                            xml.WriteEndElement();

                            xml.WriteEndElement();
                        }
                        xml.WriteEndElement();
                        xml.WriteEndElement();
                    }
                    xml.WriteEndElement();
                }
            }
        }

        private void btnSaveTestStorage_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "XML Files|*.xml";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (var xml = XmlWriter.Create(dlg.FileName, new XmlWriterSettings { Indent = true }))
                {
                    xml.WriteStartElement("TestStorage");
                    for (int i = 0; i < lstTest.Count; i++)
                    {
                        xml.WriteStartElement("Test");
                        xml.WriteAttributeString("name", lstTest[i].Name);

                        xml.WriteStartElement("CountQuiz");
                        xml.WriteValue(lstTest[i].lstTestQuiz.Count.ToString());
                        xml.WriteEndElement();

                        foreach (var item in lstTest[i].lstTestQuiz)
                        {
                            xml.WriteStartElement("Quiz");

                            xml.WriteStartElement("Topic");
                            xml.WriteValue(item.Topic);
                            xml.WriteEndElement();

                            xml.WriteStartElement("Question");
                            xml.WriteValue(item.Question);
                            xml.WriteEndElement();

                            xml.WriteStartElement("Answer");
                            xml.WriteAttributeString("count", item.Answers.Count.ToString());
                            foreach (var op in item.Answers)
                            {
                                xml.WriteStartElement("Option");

                                xml.WriteStartElement("Content");
                                xml.WriteValue(op.Content);
                                xml.WriteEndElement();

                                xml.WriteStartElement("IsTrue");
                                xml.WriteValue(op.IsTrue);
                                xml.WriteEndElement();

                                xml.WriteEndElement();
                            }
                            xml.WriteEndElement();
                            xml.WriteEndElement();
                        }
                        xml.WriteEndElement();
                    }
                    xml.WriteEndElement();
                }
            }
        }
    }
}