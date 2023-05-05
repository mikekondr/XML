using System.Data;

namespace task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || numAge.Value == 0 || comboProg.Text == "")
            {
                MessageBox.Show("Необхідно заповнити всі поля!", "Помилка", MessageBoxButtons.OK);
            }
            else
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells["colName"].Value = txtName.Text;
                dataGridView1.Rows[n].Cells["colAge"].Value = numAge.Value;
                dataGridView1.Rows[n].Cells["colProg"].Value = comboProg.Text;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Виберіть рядок для редагування", "Помилка", MessageBoxButtons.OK);
            }
            else
            {
                int n = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows[n].Cells["colName"].Value = txtName.Text;
                dataGridView1.Rows[n].Cells["colAge"].Value = numAge.Value;
                dataGridView1.Rows[n].Cells["colProg"].Value = comboProg.Text;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Виберіть рядок для видалення", "Помилка", MessageBoxButtons.OK);
            }
            else
            {
                int n = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows.RemoveAt(n);
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtName.Text = dataGridView1.CurrentRow.Cells["colName"].Value.ToString();
                numAge.Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colAge"].Value);
                comboProg.Text = dataGridView1.CurrentRow.Cells["colProg"].Value.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.TableName = "Employee";
                dt.Columns.Add("Name");
                dt.Columns.Add("Age");
                dt.Columns.Add("Programmer");
                ds.Tables.Add(dt);

                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    DataRow row = ds.Tables["Employee"].NewRow();
                    row["Name"] = r.Cells["colName"].Value;
                    row["Age"] = r.Cells["colAge"].Value;
                    row["Programmer"] = r.Cells["colProg"].Value;

                    ds.Tables["Employee"].Rows.Add(row);
                }

                ds.WriteXml("employees.xml");
                MessageBox.Show("XML файл успішно збережено!", "Виконано", MessageBoxButtons.OK);
            }
            catch
            {
                MessageBox.Show("Неможливо зберегти XML файл", "Помилка", MessageBoxButtons.OK);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                MessageBox.Show("Очистіть таблицю перед читанням файлу XML", "Увага", MessageBoxButtons.OK);
            }
            else
            {
                if (File.Exists("employees.xml"))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml("employees.xml");
                    foreach (DataRow item in ds.Tables["Employee"].Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["colName"].Value = item["Name"];
                        dataGridView1.Rows[n].Cells["colAge"].Value = item["Age"];
                        dataGridView1.Rows[n].Cells["colProg"].Value = item["Programmer"];
                    }
                }
                else
                {
                    MessageBox.Show("Файл не знайдено", "Помилка", MessageBoxButtons.OK);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
            }
        }
    }
}