using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_NGA
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        Bill_GUI bill_gui;
        Product_GUI product_gui;
        Category_GUI category_gui;
        Account__GUI account_gui;
        Customer_GUI customer_gui;
        Login_GUI login_gui;
        ChangePass_GUI change_password_gui;
        Report_GUI report_gui;
        private void Form1_Load(object sender, EventArgs e)
        {
            btnAccount.Visible = false;        
            btnBills.Visible = false;
            btnCategory.Visible = false;
            btnCustomer.Visible = false;
            btnReport.Visible = false;
            btnLogout.Visible = false;
            btnPass.Visible = false;
            btnProduct.Visible = false;
            pn1.Visible = false;
            pn2.Visible = false;
            pn3.Visible = false;
            pn4.Visible = false;
            pn5.Visible = false;
            pn6.Visible = false;
            pn7.Visible = false;
            pn8.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            pnform.Controls.Clear();
            login_gui = new Login_GUI();
            login_gui.ShowDialog();
            change_password_gui = new ChangePass_GUI();
            change_password_gui.account = login_gui.account;
            if (login_gui.loginCheck == true)
            {
                btnLogin.Visible = false;

            }

            if (login_gui.auth == "Nhân viên")
            {
                btnAccount.Visible = false;
                btnBills.Visible = true;
                btnCategory.Visible = false;
                btnCustomer.Visible = true;
                btnReport.Visible = false;
                btnLogout.Visible = true;
                btnPass.Visible = true;
                btnProduct.Visible = false;
                pn1.Visible = true;
                pn2.Visible = true;
                pn3.Visible = true;
                pn4.Visible = true;
                pn5.Visible = false;
                pn6.Visible = false;
                pn7.Visible = false;
                pn8.Visible = false;
            }

            else
            {
                btnAccount.Visible = true;
                btnBills.Visible = true;
                btnCategory.Visible = true;
                btnCustomer.Visible = true;
                btnReport.Visible = true;
                btnLogout.Visible = true;
                btnPass.Visible = true;
                btnProduct.Visible = true;
                pn1.Visible = true;
                pn2.Visible = true;
                pn3.Visible = true;
                pn4.Visible = true;
                pn5.Visible = true;
                pn6.Visible = true;
                pn7.Visible = true;
            }
        }

        private void OpenChildForm(Form childform, object btnSender)
        {
            childform.Refresh();
            childform.TopLevel = false;
            childform.Dock = DockStyle.Fill;
            this.pnform.Controls.Add(childform);
            childform.BringToFront();
            childform.Show();
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            bill_gui = new Bill_GUI();
            pnform.Controls.Clear();
            OpenChildForm(bill_gui, sender);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            customer_gui = new Customer_GUI();
            pnform.Controls.Clear();
            OpenChildForm(customer_gui, sender);
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            pnform.Controls.Clear();
            OpenChildForm(change_password_gui, sender);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            category_gui = new Category_GUI();
            pnform.Controls.Clear();
            OpenChildForm(category_gui, sender);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            product_gui = new Product_GUI();
            pnform.Controls.Clear();
            OpenChildForm(product_gui, sender);
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            account_gui = new Account__GUI();
            pnform.Controls.Clear();
            OpenChildForm(account_gui, sender);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            report_gui = new Report_GUI();
            pnform.Controls.Clear();
            OpenChildForm(report_gui, sender);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            pnform.Controls.Clear();
            btnLogin.Visible = true;
            btnAccount.Visible = false;
            btnBills.Visible = false;
            btnCategory.Visible = false;
            btnCustomer.Visible = false;
            btnReport.Visible = false;
            btnLogout.Visible = false;
            btnPass.Visible = false;
            btnProduct.Visible = false;
            pn1.Visible = false;
            pn2.Visible = false;
            pn3.Visible = false;
            pn4.Visible = false;
            pn5.Visible = false;
            pn6.Visible = false;
            pn7.Visible = false;
            pn8.Visible = false;
        }
    }
}
