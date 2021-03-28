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
    public partial class Account__GUI : Form
    {
        Account_BUS account_bus = new Account_BUS();
        String id;

        public Account__GUI()
        {
            InitializeComponent();
        }

        private void Account__GUI_Load(object sender, EventArgs e)
        {
            DataTable tb = account_bus.GetAllAccount();

            dgv.DataSource = tb;
            dgv.Columns["user_name"].HeaderText = "Tài khoản";
            dgv.Columns["password"].Visible = false;
            dgv.Columns["name"].HeaderText = "Họ tên";
            dgv.Columns["auth"].HeaderText = "Quyền";
            dgv.Columns["gender"].HeaderText = "Gới tính";
            dgv.Columns["phone"].HeaderText = "Điện thoại";
            dgv.Columns["address"].HeaderText = "Địa chỉ";

            foreach (DataGridViewColumn c in dgv.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Corobel", 13F, GraphicsUnit.Pixel);
                c.HeaderCell.Style.Font = new Font("Corobel", 10F);
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            DataTable addCBAuth = new DataTable();
            addCBAuth.Columns.Add("DisplayMember");
            addCBAuth.Columns.Add("ValueMember");

            addCBAuth.Rows.Add("Nhân viên", "Nhân viên");
            addCBAuth.Rows.Add("Admin", "Admin");

            cbAuth.Items.Clear();
            cbAuth.DataSource = addCBAuth;
            cbAuth.DisplayMember = "DisplayMember";
            cbAuth.ValueMember = "ValueMember";

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

            DataTable addCBSearch = new DataTable();
            addCBSearch.Columns.Add("DisplayMember");
            addCBSearch.Columns.Add("ValueMember");

            addCBSearch.Rows.Add("Tài khoản", "user_name");
            addCBSearch.Rows.Add("Địa chỉ", "address");
            addCBSearch.Rows.Add("Họ tên", "name");
            addCBSearch.Rows.Add("Giới tính", "gender");

            cbSearch.Items.Clear();
            cbSearch.DataSource = addCBSearch;
            cbSearch.DisplayMember = "DisplayMember";
            cbSearch.ValueMember = "ValueMember";
        }

        private void Clear()
        {
            txtUserName.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Text = "Chỉ nhập số";
            txtPhone.ForeColor = Color.Gray;
            cbAuth.SelectedIndex = 0;
            cbGender.SelectedIndex = 0;
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            txtUserName.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            cbAuth.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            txtName.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            cbGender.Text = dgv.CurrentRow.Cells[4].Value.ToString();
            txtPhone.ForeColor = Color.Black;
            txtPhone.Text = dgv.CurrentRow.Cells[5].Value.ToString();
            txtAddress.Text = dgv.CurrentRow.Cells[6].Value.ToString();
            id = dgv.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text))
            {
                if (MessageBox.Show("Bạn có chắc chắn reset mật khẩu mặc định cho tài khoản " + txtUserName.Text + " không", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Account_DTO account_dto = new Account_DTO(txtUserName.Text, txtUserName.Text, "", "", "", 0, "");

                    if (account_bus.ChangePassword(account_dto))
                    {
                        MessageBox.Show("Cập nhật thành công");
                        dgv.DataSource = account_bus.GetAllAccount();
                        Clear();
                    }

                    else
                    {
                        MessageBox.Show("Cập nhật không thành công");
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn danh mục cần cập nhật");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPhone.Text) && !string.IsNullOrEmpty(txtAddress.Text))
            {
                if (account_bus.GetAccountByUserName(txtUserName.Text).Rows.Count == 0)
                {
                    Account_DTO account_dto = new Account_DTO(txtUserName.Text, txtUserName.Text, cbAuth.SelectedValue.ToString(), txtName.Text, cbGender.SelectedValue.ToString(), int.Parse(txtPhone.Text), txtAddress.Text);

                    if (account_bus.AddNewAccount(account_dto))
                    {
                        MessageBox.Show("Thêm thành công");
                        dgv.DataSource = account_bus.GetAllAccount();
                        Clear();
                    }

                    else
                    {
                        MessageBox.Show("Thêm không thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản " + txtUserName.Text + " đã có trong cơ sở dữ liệu vui lòng chọn tài khoản khác");
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPhone.Text) && !string.IsNullOrEmpty(txtAddress.Text))
            {
                String idNew = txtUserName.Text;
                if (idNew == id)
                {
                    Account_DTO account_dto = new Account_DTO(txtUserName.Text, "", cbAuth.SelectedValue.ToString(), txtName.Text, cbGender.SelectedValue.ToString(), int.Parse(txtPhone.Text), txtAddress.Text);

                    if (account_bus.UpdateAccount(account_dto))
                    {
                        MessageBox.Show("Sửa thành công");
                        dgv.DataSource = account_bus.GetAllAccount();
                        Clear();
                    }

                    else
                    {
                        MessageBox.Show("Sừa không thành công");
                    }
                }
                else
                    MessageBox.Show("Không thể thay đổi tài khoản");
            }
            else
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text))
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá nhân viên có mã " + txtUserName.Text + " không", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    if (account_bus.DeleteAccount(txtUserName.Text))
                    {
                        MessageBox.Show("Xoá thành công");
                        dgv.DataSource = account_bus.GetAllAccount();
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
                MessageBox.Show("Hãy chọn tài khoản cần xoá");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(account_bus.GetAllAccount());
            DV.RowFilter = "" + cbSearch.SelectedValue + " like '%" + txtSearch.Text + "%'";
            dgv.DataSource = DV;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
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
    }
}
