using IS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IS
{
    public partial class Items : Form
    {
        private static Items instance;

        //Ensures that only one instance of Login Form is instantiated.
        public static Items GetInstance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new Items();

                return instance;
            }
        }

        public Items()
        {
            InitializeComponent();
        }

        private void Items_Load(object sender, EventArgs e)
        {
            GetItems();
        }

        private void GetItems()
        {
            DataTable dt = new DataTable();
            ItemsMaintenance maint = new ItemsMaintenance();
            dt = maint.GetItems();

            dgvItems.DataSource = dt;
            dgvItems.Columns[0].HeaderText = "ID";
            dgvItems.Columns[0].Visible = false;
            dgvItems.Columns[1].HeaderText = "Item Code";
            dgvItems.Columns[2].HeaderText = "Item Description";
            dgvItems.Columns[3].HeaderText = "Unit Price";
            dgvItems.Columns[3].DefaultCellStyle.Format = "0.00##";
            dgvItems.Columns[4].HeaderText = "SRP";
            dgvItems.Columns[4].DefaultCellStyle.Format = "0.00##";
        }

        private void Clear()
        {
            txtId.Clear();
            txtItemCode.Clear();
            txtItemDescription.Clear();
            txtUnitPrice.Clear();
            txtSRP.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                MessageBox.Show(txtItemCode.Text, "Demo App - Message!");
            }
            else
            {
                ClassItem item = new ClassItem();
                ItemsMaintenance maint = new ItemsMaintenance();

                var itemcode = txtItemCode.Text;
                var itemdescription = txtItemDescription.Text;
                var unitprice = txtUnitPrice.Text;
                var srp = txtSRP.Text;

                item.itemcode = itemcode;
                item.itemdescription = itemdescription;
                item.unitprice = unitprice;
                item.srp = srp;
                string message = maint.AddItem(item);

                if (message == "")
                {
                    MessageBox.Show("Item successfully saved!");
                    Clear();
                }
                else
                {
                    MessageBox.Show(message);
                }
            }
            GetItems();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ClassItem item = new ClassItem();
            ItemsMaintenance maint = new ItemsMaintenance();

            var id = txtId.Text;
            var itemcode = txtItemCode.Text;
            var itemdescription = txtItemDescription.Text;
            var unitprice = txtUnitPrice.Text;
            var srp = txtSRP.Text;

            item.id = id;
            item.itemcode = itemcode;
            item.itemdescription = itemdescription;
            item.unitprice = unitprice;
            item.srp = srp;
            string message = maint.UpdateItem(item);
            if (message == "")
            {
                MessageBox.Show("Item successfully saved!");
                Clear();
            }
            else
            {
                MessageBox.Show(message);
            }
            GetItems();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ClassItem item = new ClassItem();
            ItemsMaintenance maint = new ItemsMaintenance();

            var id = txtId.Text;
            item.id = id;
            string message = maint.DeleteItem(item);
            if (message == "")
            {
                MessageBox.Show("Item successfully deleted!");
                Clear();
            }
            else
            {
                MessageBox.Show(message);
            }
            GetItems();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = this.dgvItems.CurrentRow.Cells[0].Value.ToString();
            txtItemCode.Text = this.dgvItems.CurrentRow.Cells[1].Value.ToString();
            txtItemDescription.Text = this.dgvItems.CurrentRow.Cells[2].Value.ToString();
            txtUnitPrice.Text = this.dgvItems.CurrentRow.Cells[3].Value.ToString();
            txtSRP.Text = this.dgvItems.CurrentRow.Cells[4].Value.ToString();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            var id = txtId.Text;
            if (id != "")
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtSRP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetItems();
        }

        private void txtItemCode_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemCode.Text))
            {
                e.Cancel = true;
                txtItemCode.Focus();
                eprItemCode.SetError(txtItemCode, "Item Code should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                eprItemCode.SetError(txtItemCode, "");
            }
        }

        private void btnAdd_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemCode.Text))
            {
                e.Cancel = true;
                txtItemCode.Focus();
                eprItemCode.SetError(txtItemCode, "Item Code should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                eprItemCode.SetError(txtItemCode, "");
            }
        }
    }
}
