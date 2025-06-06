namespace ToDo
{
    public partial class Form1 : Form
    {
        List<ToDoList> list = new List<ToDoList>();
        public Form1()
        {
            SQLitePCL.Batteries.Init();
            InitializeComponent();
            updateComboBox();
            if (comboLst.SelectedItem is ToDoList chooseList) updateListBox(chooseList);

            comboLst.SelectedIndexChanged += ComboBoxProjects_SelectedIndexChanged;
        }
        //���������� ������ ��� � combo box
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string namelist = Microsoft.VisualBasic.Interaction.InputBox("������� �������� ������", "�������� ����� ������ ���");

            if (!string.IsNullOrEmpty(namelist))
            {
                DataBase.AddList(namelist);
                updateComboBox();
            }
            else
                MessageBox.Show("������� �������� ������");
        }
        // ���� ����� ������� ������ ������ �� ������ ��� ��� ������ �� ������ ���
        private void btnShowTasks_Click(object sender, EventArgs e)
        {
            if (comboLst.SelectedItem is ToDoList chooseList)
            {
                if (chooseList.Items.Count > 0)
                {
                    var confirm = MessageBox.Show($"�������� ���� ������ �� ������ '{chooseList}'?", "�����������", MessageBoxButtons.YesNo);

                    if (confirm == DialogResult.Yes)
                    {
                        if (listBoxTasks.SelectedItem is ToDoItem task)
                        {
                            listBoxTasks.DataSource = null;
                            listBoxTasks.DataSource = new List<ToDoItem> { task };
                        }
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
        //������� ������ ��� �� ComboBox
        private void btnDeleteList_Click(object sender, EventArgs e)
        {
            if (comboLst.SelectedItem is ToDoList chooseList)
            {
                var confirm = MessageBox.Show($"������� ������ '{chooseList}'?", "�����������", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    DataBase.DeleteList(chooseList.Id);
                    updateComboBox();
                }
            }
        }
        //����������� �������� ������ ���
        private void btnEditLlist_Click(object sender, EventArgs e)
        {
            if (comboLst.SelectedItem is ToDoList chooseList)
            {
                string newName = Microsoft.VisualBasic.Interaction.InputBox("������� ����� ��� ������", "������������� ������", chooseList.Name);

                if (!string.IsNullOrEmpty(newName))
                {
                    DataBase.UpdateListName(chooseList.Id, newName);
                    updateComboBox();
                }
            }
        }
        //��������� ����� ������ � �������� ����� ���������� ������ ���
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            var chooseList = comboLst.SelectedItem as ToDoList;

            if (chooseList != null)
            {
                string taskName = Microsoft.VisualBasic.Interaction.InputBox("������� �������� ������", "�������� ����� ������");

                if (!string.IsNullOrEmpty(taskName))
                {
                    DataBase.AddTask(chooseList.Id, taskName);
                    updateListBox(chooseList);
                }
            }
        }
        //����������� ���������� ��������� ������
        private void btnEditTask_Click(object sender, EventArgs e)
        {
            if (comboLst.SelectedItem is ToDoList list && listBoxTasks.SelectedItem is ToDoItem Task)
            {
                string newTask = Microsoft.VisualBasic.Interaction.InputBox("������� ����� �������� ��� ������", "������������� ������", Task.Title);

                if (!string.IsNullOrEmpty(newTask))
                {
                    DataBase.UpdateTaskName(Task.Id, newTask, Task.IsCompleted);
                    updateListBox(list);
                }
            }
        }
        //������� ��������� ������ �� �������
        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (comboLst.SelectedItem is ToDoList list && listBoxTasks.SelectedItem is ToDoItem task)
            {
                var confirm = MessageBox.Show($"������� ������ '{task.Title}'?", "�����������", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    DataBase.DeleteTasks(task.Id);
                    updateListBox(list);
                }
            }
        }
        //������ ������ ���������� ������ �� ���������������
        private void btnMarkCompleted_Click(object sender, EventArgs e)
        {
            if (comboLst.SelectedItem is ToDoList list && listBoxTasks.SelectedItem is ToDoItem task)
            {
                DataBase.UpdateTaskName(task.Id, task.Title, !task.IsCompleted);
                updateListBox(list);
            }
        }
        //����-���������� ListBox ����� ����� ������ ��� � ComboBox
        private void ComboBoxProjects_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboLst.SelectedItem is ToDoList chooseList)
            {
                updateListBox(chooseList);
            }
        }
        //��������� ������ ����� � listBox
        private void updateListBox(ToDoList list)
        {
            listBoxTasks.DataSource = null;
            listBoxTasks.DataSource = DataBase.GetTaskForList(list.Id);
        }
        //��������� ������ ��� � ComboBox
        private void updateComboBox()
        {
            comboLst.DataSource = null;
            list = DataBase.GetAllLists();
            comboLst.DataSource = list;
            comboLst.DisplayMember = "Name";
        }
    }
}
