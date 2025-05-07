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
        }

        //добавление списка дел в combo box
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string namelist = Microsoft.VisualBasic.Interaction.InputBox("Указать название списка", "Добавить новый список дел");

            if (!string.IsNullOrEmpty(namelist))
            {
                DataBase.AddList(namelist);
                updateComboBox();
            }
            else
                MessageBox.Show("Введите название списка");
        }
        // Дает выбор увидеть первую задачу из списка или все задачи из списка дел
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
        //Удаляет список дел из ComboBox
        private void btnDeleteList_Click(object sender, EventArgs e)
        {
            if (comboLst.SelectedItem is ToDoList chooseList)
            {
                var confirm = MessageBox.Show($"Удалить список '{chooseList}'?", "Подтвердить", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    DataBase.DeleteList(chooseList.Id);
                    updateComboBox();
                }
            }
        }
        //редактирует название списка дел
        private void btnEditLlist_Click(object sender, EventArgs e)
        {
            if (comboLst.SelectedItem is ToDoList chooseList)
            {
                string newName = Microsoft.VisualBasic.Interaction.InputBox("Введите новое имя списка", "Редактировать список", chooseList.Name);

                if (!string.IsNullOrEmpty(newName))
                {
                    DataBase.UpdateListName(chooseList.Id, newName);
                    updateComboBox();
                }
            }
        }
        //Добавляет новую задачу в перечень задач выбранного списка дел
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            var chooseList = comboLst.SelectedItem as ToDoList;

            if (chooseList != null)
            {
                string taskName = Microsoft.VisualBasic.Interaction.InputBox("Указать название задачи", "Добавить новую задачу");

                if (!string.IsNullOrEmpty(taskName))
                {
                    DataBase.AddTask(chooseList.Id, taskName);
                    updateListBox(chooseList);
                }
            }
        }
        //Редактирует именование выбранной задачи
        private void btnEditTask_Click(object sender, EventArgs e)
        {
            if (comboLst.SelectedItem is ToDoList list && listBoxTasks.SelectedItem is ToDoItem Task)
            {
                string newTask = Microsoft.VisualBasic.Interaction.InputBox("Введите новое название для задачи", "Редактировать задачу", Task.Title);

                if (!string.IsNullOrEmpty(newTask))
                {
                    DataBase.UpdateTaskName(Task.Id, newTask, Task.IsCompleted);
                    updateListBox(list);
                }
            }
        }
        //Удаляет выбранную задачу из перечня
        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (comboLst.SelectedItem is ToDoList list && listBoxTasks.SelectedItem is ToDoItem task)
            {
                var confirm = MessageBox.Show($"Удалить задачу '{task.Title}'?", "Подтвердить", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    DataBase.DeleteTasks(task.Id);
                    updateListBox(list);
                }
            }
        }
        //Меняет маркер выполнения задачи на противоположный
        private void btnMarkCompleted_Click(object sender, EventArgs e)
        {
            if (comboLst.SelectedItem is ToDoList list && listBoxTasks.SelectedItem is ToDoItem task)
            {
                DataBase.UpdateTaskName(task.Id, task.Title, !task.IsCompleted);
                updateListBox(list);
            }
        }
        //Обновляет список задач в listBox
        private void updateListBox(ToDoList list)
        {
            listBoxTasks.DataSource = null;
            listBoxTasks.DataSource = DataBase.GetTaskForList(list.Id);
        }
        //Обновляем списко дел в ComboBox
        private void updateComboBox()
        {
            comboLst.DataSource = null;
            list = DataBase.GetAllLists();
            comboLst.DataSource = list;
            comboLst.DisplayMember = "Name";
        }
    }
}
