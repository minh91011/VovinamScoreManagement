using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VovinamScoreManager.Models;
using VovinamScoreManager.Services;

namespace VovinamScoreManager
{
    public partial class MngClass : Form
    {
        ClassAndScoreServices context = new ClassAndScoreServices();
        AccountServices context2 = new AccountServices();
        static int state;
        public MngClass()
        {
            InitializeComponent();
            hidID.Hide();
            txtDes.Enabled = false;
            txtName.Enabled = false;
            cboGv.Enabled = false;
            txtCode.Enabled = false;
            state = 1;
            hidID.Text = "0";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Home frm = new Home();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        //thêm mới
        private void button3_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            txtName.Enabled = true;
            txtDes.Enabled = true;
            cboGv.Enabled = true;
            txtName.Text = "";
            txtDes.Text = "";
            cboGv.Text = "";
            txtCode.Text = "FU" + r.Next(100000).ToString();
            state = -1;
        }

        private void MngClass_Load(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID lớp", typeof(int));
            dt2.Columns.Add("Mã lớp", typeof(string));
            dt2.Columns.Add("Tên lớp", typeof(string));
            dt2.Columns.Add("Mô tả", typeof(string));
            dt2.Columns.Add("Giáo viên", typeof(string));
            Models.Class c = new Models.Class();
            c.Name = "";
            foreach (var item in context.GetLstClasss(c))
            {
                dt2.Rows.Add(new object[] { item.Id, item.Code, item.Name, item.Description, item.Account.FullName });
            }
            dataGridView1.DataSource = dt2;

            cboGv.DataSource = context2.GetLstAccount(0);
            cboGv.DisplayMember = "FULLNAME";
            cboGv.ValueMember = "ID";
        }



        private void button2_Click(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            txtDes.Enabled = true;
            state = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // state =-1 là insert
            if (state == -1)
            {
                if (txtName.Text.Trim().Equals("") == false && cboGv.SelectedValue != null)
                {
                    Models.Class cl = new Models.Class();
                    cl.Description = txtDes.Text;
                    cl.Name = txtName.Text;
                    cl.AccountId = (int?)cboGv.SelectedValue;
                    cl.Code = txtCode.Text;

                    if (context.InsertClass(cl))
                    {
                        string message = "Thêm mới thông tin thành công";
                        MessageBox.Show(message);
                    }
                    else
                    {
                        string message = "Thao tác thất bại";
                        MessageBox.Show(message);
                    }
                }
                else
                {
                    string message = "Vui Lòng điền đầy đủ thông tin";
                    MessageBox.Show(message);
                }

            }
            else if (state == 0)
            {
                if (txtName.Text.Trim().Equals("") == false)
                {
                    Models.Class cl = context.GetClassById(int.Parse(hidID.Text));
                    cl.Description = txtDes.Text;
                    cl.Name = txtName.Text;
                    cl.AccountId = (int?)cboGv.SelectedValue;
                    cl.Code = txtCode.Text;
                    if (context.ModifyClass(cl))
                    {
                        string message = "Thay đổi thông tin thành công";
                        MessageBox.Show(message);
                    }
                    else
                    {
                        string message = "Thao tác thất bại";
                        MessageBox.Show(message);
                    }
                }
                else
                {
                    string message = "Vui Lòng điền đầy đủ thông tin";
                    MessageBox.Show(message);
                }
            }

            txtName.Enabled = false;
            txtDes.Enabled = false;
            cboGv.Enabled = false;
            txtName.Text = "";
            txtDes.Text = "";
            cboGv.Text = "";
            txtCode.Text = "";
            state = 1;

            MngClass_Load(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtName.Enabled = false;
            txtDes.Enabled = false;
            cboGv.Enabled = false;
            state = 1;
            hidID.Text = "0";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (hidID.Text != "0")
            {
                List<int> l = new List<int>();
                l.Add(int.Parse(hidID.Text));
                if (context.CheckDeleteClass(l[0]))
                {
                    if (context.DeleteClass(l))
                    {
                        string message = "Xóa thông tin thành công";
                        MessageBox.Show(message);
                        MngClass_Load(null, null);
                    }
                    else
                    {
                        string message = "Thao tác thất bại";
                        MessageBox.Show(message);
                    }
                }
                else
                {
                    string message = "Lớp học đã có học viên";
                    MessageBox.Show(message);
                }

            }
            else
            {
                string message = "Vui Lòng chọn bản ghi cần xóa";
                MessageBox.Show(message);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            hidID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            Models.Class c = context.GetClassById(int.Parse(hidID.Text));
            txtName.Text = c.Name;
            txtDes.Text = c.Description;
            txtCode.Text = c.Code;
            cboGv.SelectedValue = c.AccountId;
        }
    }
}
