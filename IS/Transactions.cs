using IS.Classes;
using IS.GlobalClasses;
using System;
using System.Data;
using System.Windows.Forms;

namespace IS
{
    public partial class Transactions : Form
    {
        private static Transactions instance;

        //Ensures that only one instance of Login Form is instantiated.
        public static Transactions GetInstance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new Transactions();

                return instance;
            }
        }

        public Transactions()
        {
            InitializeComponent();
        }

        private void Transactions_Load(object sender, EventArgs e)
        {
            GetTransactions();
            GetTransactionTypes();
        }

        private void GetTransactionTypes()
        {
            DataTable dt = new DataTable();
            TransactionTypeMaintenance tm = new TransactionTypeMaintenance();
            dt = tm.GetTransactionTypes();

            cbxTransactionType.DataSource = dt;
            cbxTransactionType.ValueMember = "Id";
            cbxTransactionType.DisplayMember = "TransactionType";
        }

        private void GetTransactions()
        {
            DataTable dt = new DataTable();
            TransactionsMaintenance maint = new TransactionsMaintenance();
            dt = maint.GetTransactions();

            dgvTransactions.DataSource = dt;
            dgvTransactions.Columns[0].HeaderText = "ID";
            dgvTransactions.Columns[0].Visible = false;
            dgvTransactions.Columns[1].HeaderText = "Transaction Type";
            dgvTransactions.Columns[2].HeaderText = "Quantity";
            dgvTransactions.Columns[2].DefaultCellStyle.Format = "0.00##";
            dgvTransactions.Columns[3].HeaderText = "Item Code";
        }

        private void Clear()
        {
            txtId.Clear();
            cbxTransactionType.SelectedIndex = 0;
            txtQuantity.Clear();
            txtItemCode.Clear();
            txtSearch.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClassTransaction transaction = new ClassTransaction();
            TransactionsMaintenance maint = new TransactionsMaintenance();

            var transactiontype = cbxTransactionType.SelectedIndex.ToString();
            var quantity = txtQuantity.Text;
            var itemid = txtItemCode.Text;

            transaction.transactiontype = transactiontype;
            transaction.quantity = quantity;
            transaction.itemid = itemid;
            string message = maint.AddTransaction(transaction);

            if (message == "")
            {
                MessageBox.Show("Transaction successfully saved!");
                Clear();
            }
            else
            {
                MessageBox.Show(message);
            }
            GetTransactions();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}
