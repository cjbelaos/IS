using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IS
{
    public partial class MainMenu : Form
    {
        private static MainMenu instance;
        public MainMenu()
        {
            InitializeComponent();
        }
        public static MainMenu GetInstance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new MainMenu();
                }

                return instance;
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            this.Hide();
            Items.GetInstance.Show();
        }

        private void btnTransations_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transactions.GetInstance.Show();
        }
    }
}
