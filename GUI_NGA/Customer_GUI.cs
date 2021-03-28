using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_NGA;
using BUS_NGA;

namespace GUI_NGA
{
    public partial class Customer_GUI : Form
    {
        public Customer_GUI()
        {
            InitializeComponent();
        }

        Customer_BUS customer_bus = new Customer_BUS();
        String id;

        private void Customer_GUI_Load(object sender, EventArgs e)
        {
            DataTable tb = customer_bus.GetAllCustomer();

            dgv.DataSource = tb;
            dgv.Columns["id"].HeaderText = "Mã khách hàng";
            dgv.Columns["name"].HeaderText = "Tên khách hàng";
            dgv.Columns["gender"].HeaderText = "Giới tính";
            dgv.Columns["phone"].HeaderText = "Điện thoại";
            dgv.Columns["address"].HeaderText = "Địa chỉ";

            foreach (DataGridViewColumn c in dgv.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Corobel", 13F, GraphicsUnit.Pixel);
                c.HeaderCell.Style.Font = new Font("Corobel", 10F);
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            DataTable addCBSearch = new DataTable();
            addCBSearch.Columns.Add("DisplayMember");
            addCBSearch.Columns.Add("ValueMember");

            addCBSearch.Rows.Add("Mã số", "id");
            addCBSearch.Rows.Add("Họ tên", "name");
            addCBSearch.Rows.Add("Giới tính", "gender");
            addCBSearch.Rows.Add("Địa chỉ", "address");

            cbSearch.Items.Clear();
            cbSearch.DataSource = addCBSearch;
            cbSearch.DisplayMember = "DisplayMember";
            cbSearch.ValueMember = "ValueMember";

            DataTable addCBGender = new DataTable();
            addCBGender.Columns.Add("DisplayMember");
            addCBGender.Columns.Add("ValueMember");

            addCBGender.Rows.Add("Nam", "Nam");
            addCBGender.Rows.Add("Nữ", "Nữ");
            addCBGender.Rows.Add("Khác", "Khác");

            cbGender.Items.Clear();
            cbGender.DataSource = addCBGender;
            cbGender.DisplayMember = "DisplayMember";
            cbGender.ValueMember = "ValueMember";
        }

        private void Clear()
        {
            txtID.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Text = "Chỉ nhập số";
            txtPhone.ForeColor = Color.Gray;
            cbGender.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPhone.Text) && !string.IsNullOrEmpty(txtAddress.Text))
            {
                if (customer_bus.GetCustomerByID(txtID.Text).Rows.Count == 0)
                {
                    Customer_DTO customer_dto = new Customer_DTO(txtID.Text, txtName.Text, cbGender.SelectedValue.ToString(), int.Parse(txtPhone.Text), txtAddress.Text);

                    if (customer_bus.AddNewCustomer(customer_dto))
                    {
                        MessageBox.Show("Thêm thành công");
                        dgv.DataSource = customer_bus.GetAllCustomer();
                        Clear();
                    }

                    else
                    {
                        MessageBox.Show("Thêm không thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Mã danh mục " + txtID.Text + " đã có trong cơ sở dữ liệu vui lòng chọn mã khác");
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPhone.Text) && !string.IsNullOrEmpty(txtAddress.Text))
            {
                String idNew = txtID.Text;
                if (idNew == id)
                {
                    Customer_DTO customer_dto = new Customer_DTO(txtID.Text, txtName.Text, cbGender.SelectedValue.ToString(), int.Parse(txtPhone.Text), txtAddress.Text);

                    if (customer_bus.UpdateCustomer(customer_dto))
                    {
                        MessageBox.Show("Sửa thành công");
                        dgv.DataSource = customer_bus.GetAllCustomer();
                        Clear();
                    }

                    else
                    {
                        MessageBox.Show("Sừa không thành công");
                    }
                }
                else
                    MessageBox.Show("Không thể thay đổi mã");
            }
            else
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá danh mục có mã " + txtID.Text + " không", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    if (customer_bus.DeleteCustomer(txtID.Text))
                    {
                        MessageBox.Show("Xoá thành công");
                        dgv.DataSource = customer_bus.GetAllCustomer();
                        Clear();
                    }

                    else
                    {
                        MessageBox.Show("Xoá không thành công");
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn danh mục cần xoá");
            }
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            txtID.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            cbGender.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            txtPhone.ForeColor = Color.Black;
            txtPhone.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            txtAddress.Text = dgv.CurrentRow.Cells[4].Value.ToString();
            id = dgv.CurrentRow.Cells[0].Value.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(customer_bus.GetAllCustomer());
            DV.RowFilter = "" + cbSearch.SelectedValue + " like '%" + txtSearch.Text + "%'";
            dgv.DataSource = DV;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhone_Enter(object sender, EventArgs e)
        {
            if (txtPhone.Text == "Chỉ nhập số")
            {
                txtPhone.Clear();
                txtPhone.ForeColor = Color.Black;
            }
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                txtPhone.Text = "Chỉ nhập số";
                txtPhone.ForeColor = Color.Gray;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtPhone_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtPhone_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                txtPhone.Text = "Chỉ nhập số";
                txtPhone.ForeColor = Color.Gray;
            }
        }

        private void txtPhone_Enter_1(object sender, EventArgs e)
        {
            if (txtPhone.Text == "Chỉ nhập số")
            {
                txtPhone.Clear();
                txtPhone.ForeColor = Color.Black;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExportExcel excel = new ExportExcel();
            DataTable dt = (DataTable)(dgv.DataSource);
            excel.Export(dt, "san pham", "DANH SÁCH KHÁCH HÀNG");
        }
    }
}
