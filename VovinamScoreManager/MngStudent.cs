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
    public partial class MngStudent : Form
    {
        static int state;
        StudentServices context = new StudentServices();
        public MngStudent()
        {
            InitializeComponent();
            hidID.Hide();
            txtCode.Enabled = false;
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            txtPhone.Enabled = false;
            state = 1;
            hidID.Text = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            txtName.Enabled = true;
            txtAddress.Enabled = true;
            txtPhone.Enabled = true;
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtCode.Text = "HE" + r.Next(100000).ToString();
            state = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            txtAddress.Enabled = true;
            txtPhone.Enabled = true;
            state = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (state == -1)
            {
                if (txtName.Text.Trim().Equals("") == false )
                {
                    Student cl = new Student();
                    cl.FullName = txtName.Text;

                    cl.Code = txtCode.Text;
                    cl.Address = txtAddress.Text;
                    cl.Phone = txtPhone.Text;
                    
                    if (context.InsertStudent(cl))
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
                    Student cl = context.GetStudentById(int.Parse(hidID.Text));
                    cl.Address = txtAddress.Text;
                    cl.FullName = txtName.Text;
                    cl.Phone = txtPhone.Text;
                    cl.Code = txtCode.Text;
                    if (context.ModifyStudent(cl))
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
            txtAddress.Enabled = false;
            txtCode.Enabled = false;
            txtPhone.Enabled = false;
            txtName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtCode.Text = "";
            state = 1;

            MngStudent_Load(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            txtPhone.Enabled = false;
            txtCode.Enabled = false;
            state = 1;
            hidID.Text = "0";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (hidID.Text != "0")
            {
                List<int> l = new List<int>();
                l.Add(int.Parse(hidID.Text));
                if (context.CheckDeleteStudent(l[0]))
                {
                    if (context.DeleteStudent(l))
                    {
                        string message = "Xóa thông tin thành công";
                        MessageBox.Show(message);
                        MngStudent_Load(null, null);
                    }
                    else
                    {
                        string message = "Thao tác thất bại";
                        MessageBox.Show(message);
                    }
                }
                else
                {
                    string message = "Học viên này đã được xếp vào lớp học";
                    MessageBox.Show(message);
                }

            }
            else
            {
                string message = "Vui Lòng chọn bản ghi cần xóa";
                MessageBox.Show(message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Home frm = new Home();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        private void MngStudent_Load(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID HV", typeof(int));
            dt2.Columns.Add("Mã Học viên", typeof(string));
            dt2.Columns.Add("Họ tên", typeof(string));
            dt2.Columns.Add("Địa chỉ", typeof(string));
            dt2.Columns.Add("Số điện thoại", typeof(string));
            Student c = new Student();
            c.FullName = "";
            c.ClassId = -1;
            foreach (var item in context.GetLstStudents(c))
            {
                dt2.Rows.Add(new object[] { item.Id, item.Code, item.FullName, item.Address, item.Phone });
            }
            dataGridView1.DataSource = dt2;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            hidID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            Student c = context.GetStudentById(int.Parse(hidID.Text));
            txtName.Text = c.FullName;
            txtCode.Text = c.Code;
            txtAddress.Text = c.Address;
            txtPhone.Text = c.Phone;
        }
    }
}
