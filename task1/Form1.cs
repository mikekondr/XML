using System.Xml;

namespace task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadEmployees();
        }

        public void LoadEmployees()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("employees.xml");

            foreach (XmlNode node in doc.DocumentElement)
            {
                string name = node.Attributes[0].Value;
                int age = int.Parse(node["Age"].InnerText);
                bool programmer = bool.Parse(node["Programmer"].InnerText);

                listBox1.Items.Add(new Employee(name, age, programmer));
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
                propertyGrid1.SelectedObject = listBox1.SelectedItem;
        }
    }
}