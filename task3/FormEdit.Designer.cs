namespace task3
{
    partial class FormEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblCode = new Label();
            txtCode = new TextBox();
            lblName = new Label();
            lblActive = new Label();
            lblUnit = new Label();
            lblWarranty = new Label();
            lblVendor = new Label();
            txtName = new TextBox();
            txtVendor = new TextBox();
            numWarranty = new NumericUpDown();
            chkActive = new CheckBox();
            btnOk = new Button();
            btnCancel = new Button();
            comboUnit = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numWarranty).BeginInit();
            SuspendLayout();
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Location = new Point(13, 22);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(56, 15);
            lblCode.TabIndex = 0;
            lblCode.Text = "Артикул:";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(113, 19);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(183, 23);
            txtCode.TabIndex = 1;
            txtCode.Tag = "";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(13, 51);
            lblName.Name = "lblName";
            lblName.Size = new Size(92, 15);
            lblName.TabIndex = 2;
            lblName.Text = "Найменування:";
            // 
            // lblActive
            // 
            lblActive.AutoSize = true;
            lblActive.Location = new Point(13, 167);
            lblActive.Name = "lblActive";
            lblActive.Size = new Size(64, 15);
            lblActive.TabIndex = 3;
            lblActive.Text = "Актуальне";
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Location = new Point(13, 80);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(66, 15);
            lblUnit.TabIndex = 4;
            lblUnit.Text = "Од.виміру:";
            // 
            // lblWarranty
            // 
            lblWarranty.AutoSize = true;
            lblWarranty.Location = new Point(13, 109);
            lblWarranty.Name = "lblWarranty";
            lblWarranty.Size = new Size(86, 15);
            lblWarranty.TabIndex = 5;
            lblWarranty.Text = "Гарантіяя, міс:";
            // 
            // lblVendor
            // 
            lblVendor.AutoSize = true;
            lblVendor.Location = new Point(13, 138);
            lblVendor.Name = "lblVendor";
            lblVendor.Size = new Size(65, 15);
            lblVendor.TabIndex = 6;
            lblVendor.Text = "Виробник:";
            // 
            // txtName
            // 
            txtName.Location = new Point(113, 48);
            txtName.Name = "txtName";
            txtName.Size = new Size(183, 23);
            txtName.TabIndex = 2;
            // 
            // txtVendor
            // 
            txtVendor.Location = new Point(113, 135);
            txtVendor.Name = "txtVendor";
            txtVendor.Size = new Size(183, 23);
            txtVendor.TabIndex = 5;
            // 
            // numWarranty
            // 
            numWarranty.Location = new Point(113, 107);
            numWarranty.Name = "numWarranty";
            numWarranty.Size = new Size(183, 23);
            numWarranty.TabIndex = 4;
            numWarranty.TextAlign = HorizontalAlignment.Right;
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Location = new Point(113, 168);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(15, 14);
            chkActive.TabIndex = 6;
            chkActive.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(76, 200);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 7;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(157, 200);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Відмінити";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // comboUnit
            // 
            comboUnit.FormattingEnabled = true;
            comboUnit.Items.AddRange(new object[] { "шт", "пак", "компл", "л", "г", "кг" });
            comboUnit.Location = new Point(113, 77);
            comboUnit.Name = "comboUnit";
            comboUnit.Size = new Size(183, 23);
            comboUnit.TabIndex = 3;
            // 
            // FormEdit
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(308, 235);
            ControlBox = false;
            Controls.Add(comboUnit);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(chkActive);
            Controls.Add(numWarranty);
            Controls.Add(txtVendor);
            Controls.Add(txtName);
            Controls.Add(lblVendor);
            Controls.Add(lblWarranty);
            Controls.Add(lblUnit);
            Controls.Add(lblActive);
            Controls.Add(lblName);
            Controls.Add(txtCode);
            Controls.Add(lblCode);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormEdit";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Картка товара";
            TopMost = true;
            Shown += FormEdit_Shown;
            ((System.ComponentModel.ISupportInitialize)numWarranty).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCode;
        private TextBox txtCode;
        private Label lblName;
        private Label lblActive;
        private Label lblUnit;
        private Label lblWarranty;
        private Label lblVendor;
        private TextBox txtName;
        private TextBox txtVendor;
        private NumericUpDown numWarranty;
        private CheckBox chkActive;
        private Button btnOk;
        private Button btnCancel;
        private ComboBox comboUnit;
    }
}