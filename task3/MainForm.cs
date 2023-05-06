using System.Data;
using System.Linq.Expressions;
using System.Security.Cryptography;

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
                dataGridView1.Rows.Add(new string[]
                {
                    frm.item.Active.ToString(),
                    frm.item.Name,
                    frm.item.Code,
                    frm.item.Unit,
                    frm.item.Vendor,
                    frm.item.Warranty.ToString(),
                });
                modified = true;
            }
        }

        private void CopyItem(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                MessageBox.Show("Не обрано рядок для редагування", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DataGridViewRow row = dataGridView1.Rows[dataGridView1.Rows.Add()];

                FormEdit frm = new FormEdit();
                frm.item.Active = Convert.ToBoolean(row.Cells["Active"].Value);
                frm.item.Code = "" + row.Cells["Code"].Value;
                frm.item.Name = "" + row.Cells["Description"].Value;
                frm.item.Unit = "" + row.Cells["Unit"].Value;
                frm.item.Warranty = Convert.ToDecimal(row.Cells["Warranty"].Value);
                frm.item.Vendor = "" + row.Cells["Vendor"].Value;
                frm.ShowDialog(this);

                if (frm.DialogResult == DialogResult.OK)
                {
                    row.Cells["Active"].Value = frm.item.Active;
                    row.Cells["Code"].Value = frm.item.Code;
                    row.Cells["Description"].Value = frm.item.Name;
                    row.Cells["Unit"].Value = frm.item.Unit;
                    row.Cells["Warranty"].Value = frm.item.Warranty;
                    row.Cells["Vendor"].Value = frm.item.Vendor;

                    modified = true;
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

                FormEdit frm = new FormEdit();
                frm.item.Active = Convert.ToBoolean(row.Cells["Active"].Value);
                frm.item.Code = "" + row.Cells["Code"].Value;
                frm.item.Name = "" + row.Cells["Description"].Value;
                frm.item.Unit = "" + row.Cells["Unit"].Value;
                frm.item.Warranty = Convert.ToDecimal(row.Cells["Warranty"].Value);
                frm.item.Vendor = "" + row.Cells["Vendor"].Value;
                frm.ShowDialog(this);

                if (frm.DialogResult == DialogResult.OK)
                {
                    row.Cells["Active"].Value = frm.item.Active;
                    row.Cells["Code"].Value = frm.item.Code;
                    row.Cells["Description"].Value = frm.item.Name;
                    row.Cells["Unit"].Value = frm.item.Unit;
                    row.Cells["Warranty"].Value = frm.item.Warranty;
                    row.Cells["Vendor"].Value = frm.item.Vendor;

                    modified = true;
                }
            }
        }

        private void RemoveItem(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    dataGridView1.Rows.Remove(row);
            }
            else if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
            else
            {
                MessageBox.Show("Не обрано рядки для видалення", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            modified = true;
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

            modified = false;
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

            modified = false;
            return true;
        }

        private void Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CheckModified())
                e.Cancel = true;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            modified = true;
        }
    }
}