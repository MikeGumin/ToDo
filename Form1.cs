namespace ToDo
{
    public partial class Form1 : Form
    {
        List<ToDoList> list = new List<ToDoList>();
        public Form1()
        {
            InitializeComponent();
        }
        //добавление списка дел в combo box
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string namelist = Microsoft.VisualBasic.Interaction.InputBox("Указать название списка", "Добавить новый список дел");

            if (!string.IsNullOrEmpty(namelist))
            {
                list.Add(new ToDoList { Name = namelist });
                updateComboBox();
            }
            else
                MessageBox.Show("Введите название списка");
        }

        private void btnShowTasks_Click(object sender, EventArgs e)
        {
            if (comboLst.SelectedItem is ToDoList chooseList)
            {
                if (chooseList.Items.Count > 0)
                {
                    var confirm = MessageBox.Show($"Показать одну задачи из списка '{chooseList}'?", "Подтвердить", MessageBoxButtons.YesNo);

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
                MessageBox.Show("Создайте список дел");
        }
        private void btnDeleteList_Click(object sender, EventArgs e)
        {
            if (comboLst.SelectedItem is ToDoList chooseList)
            {
                var confirm = MessageBox.Show($"Удалить список '{chooseList}'?", "Подтвердить", MessageBoxButtons.YesNo);
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
                string newName = Microsoft.VisualBasic.Interaction.InputBox("Введите новое имя списка", "Редактировать список", chooseList.Name);

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
                string task = Microsoft.VisualBasic.Interaction.InputBox("Указать название задачи", "Добавить новую задачу");
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
                string newTask = Microsoft.VisualBasic.Interaction.InputBox("Введите новое название для задачи", "Редактировать задачу", Task.Title);

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
                var confirm = MessageBox.Show($"Удалить задачу '{task.Title}'?", "Подтвердить", MessageBoxButtons.YesNo);

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
