using System.Data;

namespace task3
{
    public partial class MainForm : Form
    {
        private bool modified = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void AddItem(object sender, EventArgs e)
        {
            FormEdit frm = new FormEdit();
            frm.ShowDialog(this);

            if (frm.DialogResult == DialogResult.OK)
            {
                dataGridView1.Rows.Add(
                    frm.item.Active.ToString(),
                    frm.item.Name,
                    frm.item.Code,
                    frm.item.Unit,
                    frm.item.Vendor,
                    frm.item.Warranty.ToString()
                );
                Change_Mod(true);
            }
        }

        private void CopyItem(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                MessageBox.Show("Не обрано рядок для копіювання", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DataGridViewRow row = dataGridView1.CurrentRow;

                FormEdit frm = new FormEdit(
                    row.Cells["Active"].Value,
                    row.Cells["Code"].Value,
                    row.Cells["Description"].Value,
                    row.Cells["Unit"].Value,
                    row.Cells["Warranty"].Value,
                    row.Cells["Vendor"].Value
                );
                frm.ShowDialog(this);

                if (frm.DialogResult == DialogResult.OK)
                {
                    dataGridView1.Rows.Add(
                        frm.item.Active.ToString(),
                        frm.item.Name,
                        frm.item.Code,
                        frm.item.Unit,
                        frm.item.Vendor,
                        frm.item.Warranty.ToString()
                    );

                    Change_Mod(true);
                }
            }
        }

        private void EditItem(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                MessageBox.Show("Не обрано рядок для редагування", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DataGridViewRow row = dataGridView1.CurrentRow;

                FormEdit frm = new FormEdit(
                    row.Cells["Active"].Value,
                    row.Cells["Code"].Value,
                    row.Cells["Description"].Value,
                    row.Cells["Unit"].Value,
                    row.Cells["Warranty"].Value,
                    row.Cells["Vendor"].Value
                );
                frm.ShowDialog(this);

                if (frm.DialogResult == DialogResult.OK)
                {
                    row.SetValues(
                        frm.item.Active.ToString(),
                        frm.item.Name,
                        frm.item.Code,
                        frm.item.Unit,
                        frm.item.Vendor,
                        frm.item.Warranty.ToString()
                    );
                    Change_Mod(true);
                }
            }
        }

        private void RemoveItem(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DialogResult answer = MessageBox.Show("Буде видалено " + dataGridView1.SelectedRows.Count + " рядків!\n\n" +
                    "Справді продовжити?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (answer != DialogResult.Yes)
                    return;

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    dataGridView1.Rows.Remove(row);
            }
            else if (dataGridView1.CurrentRow != null)
            {
                DialogResult answer = MessageBox.Show("Ряжок " + dataGridView1.CurrentRow + " буде видалено!\n\n" +
                    "Справді продовжити?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if (answer != DialogResult.Yes)
                    return;
                
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
            else
            {
                MessageBox.Show("Не обрано рядки для видалення", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Change_Mod(true);
        }

        private void NewList(object sender, EventArgs e)
        {
            if (!CheckModified())
                return;

            dataGridView1.Rows.Clear();
        }

        private void OpenList(object sender, EventArgs e)
        {
            if (!CheckModified())
                return;

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml(openFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка читання файлу:\n" + ex.Message, "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ds.Tables.Count == 0 || !ds.Tables.Contains("Item"))
            {
                MessageBox.Show("Обраний файл не містить потрібних даних", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Change_Mod(false);
            dataGridView1.Rows.Clear();
            try
            {
                foreach (DataRow row in ds.Tables["Item"].Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    foreach (DataColumn col in ds.Tables["Item"].Columns)
                        dataGridView1.Rows[i].Cells[col.ColumnName].Value = ds.Tables["Item"].Rows[i][col];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка читання файлу:\n" + ex.Message, "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveList(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            EditItem(sender, e);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CheckModified())
                e.Cancel = true;
        }

        private bool SaveFile()
        {
            if (saveFileDialog1.ShowDialog(this) == DialogResult.Cancel)
                return false;

            string fileName = saveFileDialog1.FileName;

            DataSet ds = new DataSet();
            ds.DataSetName = "Items";

            DataTable dt = new DataTable();
            dt.TableName = "Item";

            foreach (DataGridViewColumn col in dataGridView1.Columns)
                dt.Columns.Add(col.Name);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataRow newRow = dt.NewRow();
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                    newRow[col.Name] = row.Cells[col.Name].Value;
                dt.Rows.Add(newRow);
            }

            ds.Tables.Add(dt);
            try
            {
                ds.WriteXml(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Запис файла не виконано. Помилка:\n" + ex.Message, "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Change_Mod(false);
            return true;
        }

        private bool CheckModified()
        {
            if (modified)
            {
                DialogResult res = MessageBox.Show("Зберегти зміни перед очищенням?", "Увага",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (res == DialogResult.Cancel)
                    return false;
                else if (res == DialogResult.Yes)
                    if (!SaveFile())
                        return false;
            }

            return true;
        }

        private void Change_Mod(bool mod)
        {
            modified = mod;
            this.Text = "Товари" + (modified ? " *" : "");
        }
    }
}