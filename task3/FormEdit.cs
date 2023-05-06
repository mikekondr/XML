﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace task3
{
    public partial class FormEdit : Form
    {
        public Item item = new Item();

        public FormEdit()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            item.Active = chkActive.Checked;
            item.Name = txtName.Text;
            item.Code = txtCode.Text;
            item.Warranty = numWarranty.Value;
            item.Vendor = txtVendor.Text;
            item.Unit = comboUnit.Text;

            Close();
        }

        private void FormEdit_Shown(object sender, EventArgs e)
        {
            txtName.Text = item.Name;
            txtCode.Text = item.Code;
            txtVendor.Text = item.Vendor;
            numWarranty.Value = item.Warranty;
            chkActive.Checked = item.Active;
            comboUnit.Text = item.Unit;
        }
    }
}
