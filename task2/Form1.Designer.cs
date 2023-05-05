namespace task2
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
            lblName = new Label();
            txtName = new TextBox();
            lblAge = new Label();
            numAge = new NumericUpDown();
            lblProg = new Label();
            comboProg = new ComboBox();
            dataGridView1 = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colAge = new DataGridViewTextBoxColumn();
            colProg = new DataGridViewTextBoxColumn();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDel = new Button();
            btnOpen = new Button();
            btnClear = new Button();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)numAge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(10, 16);
            lblName.Name = "lblName";
            lblName.Size = new Size(31, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Ім'я:";
            // 
            // txtName
            // 
            txtName.Location = new Point(49, 14);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(170, 23);
            txtName.TabIndex = 1;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(224, 16);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(26, 15);
            lblAge.TabIndex = 2;
            lblAge.Text = "Вік:";
            // 
            // numAge
            // 
            numAge.Location = new Point(257, 15);
            numAge.Margin = new Padding(3, 2, 3, 2);
            numAge.Name = "numAge";
            numAge.Size = new Size(75, 23);
            numAge.TabIndex = 3;
            // 
            // lblProg
            // 
            lblProg.AutoSize = true;
            lblProg.Location = new Point(338, 16);
            lblProg.Name = "lblProg";
            lblProg.Size = new Size(74, 15);
            lblProg.TabIndex = 4;
            lblProg.Text = "Програміст:";
            // 
            // comboProg
            // 
            comboProg.Items.AddRange(new object[] { "True", "False" });
            comboProg.Location = new Point(424, 14);
            comboProg.Margin = new Padding(3, 2, 3, 2);
            comboProg.Name = "comboProg";
            comboProg.Size = new Size(86, 23);
            comboProg.TabIndex = 5;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colName, colAge, colProg });
            dataGridView1.Location = new Point(10, 72);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(499, 152);
            dataGridView1.TabIndex = 6;
            dataGridView1.MouseClick += dataGridView1_MouseClick;
            // 
            // colName
            // 
            colName.HeaderText = "Ім'я";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 200;
            // 
            // colAge
            // 
            colAge.HeaderText = "Вік";
            colAge.MinimumWidth = 6;
            colAge.Name = "colAge";
            colAge.ReadOnly = true;
            colAge.Width = 125;
            // 
            // colProg
            // 
            colProg.HeaderText = "Програміст";
            colProg.MinimumWidth = 6;
            colProg.Name = "colProg";
            colProg.ReadOnly = true;
            colProg.Width = 125;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(10, 46);
            btnAdd.Margin = new Padding(3, 2, 3, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(163, 22);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Додати";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(178, 46);
            btnEdit.Margin = new Padding(3, 2, 3, 2);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(163, 22);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "Редагувати";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDel
            // 
            btnDel.Location = new Point(346, 46);
            btnDel.Margin = new Padding(3, 2, 3, 2);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(163, 22);
            btnDel.TabIndex = 9;
            btnDel.Text = "Видалити";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(346, 229);
            btnOpen.Margin = new Padding(3, 2, 3, 2);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(163, 22);
            btnOpen.TabIndex = 12;
            btnOpen.Text = "Прочитати з XML";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(178, 229);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(163, 22);
            btnClear.TabIndex = 11;
            btnClear.Text = "Очистити";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(10, 229);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(163, 22);
            btnSave.TabIndex = 10;
            btnSave.Text = "Зберегти в XML";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 255);
            Controls.Add(comboProg);
            Controls.Add(btnOpen);
            Controls.Add(btnClear);
            Controls.Add(btnSave);
            Controls.Add(btnDel);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(lblProg);
            Controls.Add(numAge);
            Controls.Add(lblAge);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Співробітинки";
            ((System.ComponentModel.ISupportInitialize)numAge).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private Label lblAge;
        private NumericUpDown numAge;
        private Label lblProg;
        private ComboBox comboProg;
        private DataGridView dataGridView1;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDel;
        private Button btnOpen;
        private Button btnClear;
        private Button btnSave;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colAge;
        private DataGridViewTextBoxColumn colProg;
    }
}