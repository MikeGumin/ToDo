namespace ToDo
{
    public partial class Form1 : Form
    {
        List<ToDoList> list = new List<ToDoList>();
        public Form1()
        {
            InitializeComponent();
        }
        //���������� ������ ��� � combo box
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string namelist = Microsoft.VisualBasic.Interaction.InputBox("������� �������� ������", "�������� ����� ������ ���");

            if (!string.IsNullOrEmpty(namelist))
            {
                list.Add(new ToDoList { Name = namelist });
                updateComboBox();
            }
            else
                MessageBox.Show("������� �������� ������");
        }

        private void btnShowTasks_Click(object sender, EventArgs e)
        {
            if (comboLst.SelectedItem is ToDoList chooseList)
            {
                if (chooseList.Items.Count > 0)
                {
                    var confirm = MessageBox.Show($"�������� ���� ������ �� ������ '{chooseList}'?", "�����������", MessageBoxButtons.YesNo);

                    if (confirm == DialogResult.Yes)
                    {
                        var firstTask = chooseList.Items[0];
                        listBoxTasks.DataSource = null;
                        listBoxTasks.DataSource = new List<ToDoItem> { firstTask };
                    }
                    else
                        updateListBox(chooseList);
                }
                else
                    updateListBox(chooseList);
            }
            else
                MessageBox.Show("�������� ������ ���");
        }
        private void btnDeleteList_Click(object sender, EventArgs e)
        {
            if (comboLst.SelectedItem is ToDoList chooseList)
            {
                var confirm = MessageBox.Show($"������� ������ '{chooseList}'?", "�����������", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    list.Remove(chooseList);
                    updateComboBox();
                    listBoxTasks.DataSource = null;
                }
            }
        }
        private void btnEditLlist_Click(object sender, EventArgs e)
        {
            if (comboLst.SelectedItem is ToDoList chooseList)
            {
                string newName = Microsoft.VisualBasic.Interaction.InputBox("������� ����� ��� ������", "������������� ������", chooseList.Name);

                if (!string.IsNullOrEmpty(newName))
                {
                    chooseList.Name = newName;
                    updateComboBox();
                }
            }
        }
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            var chooseList = comboLst.SelectedItem as ToDoList;

            if (chooseList != null)
            {
                string task = Microsoft.VisualBasic.Interaction.InputBox("������� �������� ������", "�������� ����� ������");
                if (!string.IsNullOrEmpty(task))
                {
                    chooseList.Items.Add(new ToDoItem { Title = task });
                    updateListBox(chooseList);
                }
            }
        }
        private void btnEditTask_Click(object sender, EventArgs e)
        {
            if (comboLst.SelectedItem is ToDoList list && listBoxTasks.SelectedItem is ToDoItem Task)
            {
                string newTask = Microsoft.VisualBasic.Interaction.InputBox("������� ����� �������� ��� ������", "������������� ������", Task.Title);

                if (!string.IsNullOrEmpty(newTask))
                {
                    Task.Title = newTask;
                    updateListBox(list);
                }
            }
        }
        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (comboLst.SelectedItem is ToDoList list && listBoxTasks.SelectedItem is ToDoItem task)
            {
                var confirm = MessageBox.Show($"������� ������ '{task.Title}'?", "�����������", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    list.Items.Remove(task);
                    updateListBox(list);
                }
            }
        }
        private void btnMarkCompleted_Click(object sender, EventArgs e)
        {
            if (comboLst.SelectedItem is ToDoList list && listBoxTasks.SelectedItem is ToDoItem task)
            {
                task.IsCompleted = true;
                updateListBox(list);
            }
        }
        private void updateListBox(ToDoList list)
        {
            listBoxTasks.DataSource = null;
            listBoxTasks.DataSource = list.Items;
        }
        private void updateComboBox()
        {
            comboLst.DataSource = null;
            comboLst.DataSource = list;
            comboLst.DisplayMember = "Name";
        }
    }
}
