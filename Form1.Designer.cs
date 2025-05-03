namespace ToDo
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            comboLst = new ComboBox();
            btnAdd = new Button();
            listBoxTasks = new ListBox();
            btnAddTask = new Button();
            btnShowTasks = new Button();
            label1 = new Label();
            btnDeleteList = new Button();
            btnEditTask = new Button();
            btnDeleteTask = new Button();
            btnMarkCompleted = new Button();
            label3 = new Label();
            btnEditLlist = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btnEditLlist).BeginInit();
            SuspendLayout();
            // 
            // comboLst
            // 
            comboLst.FormattingEnabled = true;
            comboLst.Location = new Point(204, 32);
            comboLst.Name = "comboLst";
            comboLst.Size = new Size(364, 28);
            comboLst.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(202, 330);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(194, 29);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Добавить список";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // listBoxTasks
            // 
            listBoxTasks.FormattingEnabled = true;
            listBoxTasks.Location = new Point(202, 71);
            listBoxTasks.Name = "listBoxTasks";
            listBoxTasks.Size = new Size(366, 104);
            listBoxTasks.TabIndex = 3;
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(202, 214);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(189, 29);
            btnAddTask.TabIndex = 5;
            btnAddTask.Text = "Добавить задачу";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // btnShowTasks
            // 
            btnShowTasks.Location = new Point(402, 330);
            btnShowTasks.Name = "btnShowTasks";
            btnShowTasks.Size = new Size(166, 29);
            btnShowTasks.TabIndex = 6;
            btnShowTasks.Text = "Показать задачи";
            btnShowTasks.UseVisualStyleBackColor = true;
            btnShowTasks.Click += btnShowTasks_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(202, 307);
            label1.Name = "label1";
            label1.Size = new Size(168, 20);
            label1.TabIndex = 7;
            label1.Text = "Работа со списком дел";
            // 
            // btnDeleteList
            // 
            btnDeleteList.Location = new Point(204, 365);
            btnDeleteList.Name = "btnDeleteList";
            btnDeleteList.Size = new Size(364, 29);
            btnDeleteList.TabIndex = 8;
            btnDeleteList.Text = "Удалить список";
            btnDeleteList.UseVisualStyleBackColor = true;
            btnDeleteList.Click += btnDeleteList_Click;
            // 
            // btnEditTask
            // 
            btnEditTask.Location = new Point(202, 249);
            btnEditTask.Name = "btnEditTask";
            btnEditTask.Size = new Size(189, 29);
            btnEditTask.TabIndex = 10;
            btnEditTask.Text = "Редактировать задачу";
            btnEditTask.UseVisualStyleBackColor = true;
            btnEditTask.Click += btnEditTask_Click;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.Location = new Point(397, 214);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(171, 29);
            btnDeleteTask.TabIndex = 11;
            btnDeleteTask.Text = "Удалить Задачу";
            btnDeleteTask.UseVisualStyleBackColor = true;
            btnDeleteTask.Click += btnDeleteTask_Click;
            // 
            // btnMarkCompleted
            // 
            btnMarkCompleted.Location = new Point(397, 249);
            btnMarkCompleted.Name = "btnMarkCompleted";
            btnMarkCompleted.Size = new Size(171, 29);
            btnMarkCompleted.TabIndex = 12;
            btnMarkCompleted.Text = "Задача выполнена";
            btnMarkCompleted.UseVisualStyleBackColor = true;
            btnMarkCompleted.Click += btnMarkCompleted_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(204, 188);
            label3.Name = "label3";
            label3.Size = new Size(183, 20);
            label3.TabIndex = 14;
            label3.Text = "Работа со списком задач";
            // 
            // btnEditLlist
            // 
            btnEditLlist.Anchor = AnchorStyles.None;
            btnEditLlist.BackColor = SystemColors.ButtonHighlight;
            btnEditLlist.Image = (Image)resources.GetObject("btnEditLlist.Image");
            btnEditLlist.Location = new Point(574, 32);
            btnEditLlist.Name = "btnEditLlist";
            btnEditLlist.Size = new Size(28, 28);
            btnEditLlist.SizeMode = PictureBoxSizeMode.Zoom;
            btnEditLlist.TabIndex = 15;
            btnEditLlist.TabStop = false;
            btnEditLlist.Click += btnEditLlist_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEditLlist);
            Controls.Add(label3);
            Controls.Add(btnMarkCompleted);
            Controls.Add(btnDeleteTask);
            Controls.Add(btnEditTask);
            Controls.Add(btnDeleteList);
            Controls.Add(label1);
            Controls.Add(btnShowTasks);
            Controls.Add(btnAddTask);
            Controls.Add(listBoxTasks);
            Controls.Add(btnAdd);
            Controls.Add(comboLst);
            Name = "Form1";
            Text = "To Do List";
            ((System.ComponentModel.ISupportInitialize)btnEditLlist).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboLst;
        private Button btnAdd;
        private ListBox listBoxTasks;
        private Button btnAddTask;
        private Button btnShowTasks;
        private Label label1;
        private Button btnDeleteList;
        private Button btnEditTask;
        private Button btnDeleteTask;
        private Button btnMarkCompleted;
        private Label label3;
        private PictureBox btnEditLlist;
    }
}
