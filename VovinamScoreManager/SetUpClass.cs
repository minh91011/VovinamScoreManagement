using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using VovinamScoreManager.Models;
using VovinamScoreManager.Services;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace VovinamScoreManager
{
    public partial class SetUpClass : Form
    {
        public SetUpClass()
        {
            InitializeComponent();
        }
        StudentServices context = new StudentServices();
        ClassAndScoreServices context2 = new ClassAndScoreServices();
        private void SetUpClass_Load(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID HV", typeof(int));
            dt2.Columns.Add("Mã Học viên", typeof(string));
            dt2.Columns.Add("Họ tên", typeof(string));
            dt2.Columns.Add("Địa chỉ", typeof(string));
            dt2.Columns.Add("Số điện thoại", typeof(string));
            Student c = new Student();
            c.FullName = "";
            c.ClassId = 0;
            foreach (var item in context.GetLstStudents(c))
            {
                dt2.Rows.Add(new object[] { item.Id, item.Code, item.FullName, item.Address, item.Phone });
            }
            dataGridView1.DataSource = dt2;

            DataTable dt3 = new DataTable();
            dt3.Columns.Add("ID lớp", typeof(int));
            dt3.Columns.Add("Mã lớp", typeof(string));
            dt3.Columns.Add("Tên lớp", typeof(string));
            dt3.Columns.Add("Mô tả", typeof(string));
            dt3.Columns.Add("Giáo viên", typeof(string));
            Models.Class c1 = new Models.Class();
            c1.Name = "";
            foreach (var item in context2.GetLstClasss(c1))
            {
                dt3.Rows.Add(new object[] { item.Id, item.Code, item.Name, item.Description, item.Account.FullName });
            }
            dataGridView2.DataSource = dt3;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //thêm
                if (hidClass.Text != "0" && HidStu.Text != "0")
                {
                    // check trùng
                    if (context.CheckSetUpStudentClass(int.Parse(hidClass.Text), int.Parse(HidStu.Text)))
                    {
                        DialogResult dialogResult = MessageBox.Show("Học viên đã được xếp lớp , bạn có muốn đổi lớp cho học viên", "Cảnh báo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (context.SetUpStudentClass(int.Parse(hidClass.Text), int.Parse(HidStu.Text)))
                            {

                            }
                            else
                            {

                            }
                            string message = "Thao tác thành công";
                            MessageBox.Show(message);
                        }
                        else if (dialogResult == DialogResult.No)
                        {

                        }
                    }
                    else
                    {
                        if (context.SetUpStudentClass(int.Parse(hidClass.Text), int.Parse(HidStu.Text)))
                        {
                            string message = "Thao tác thành công";
                            MessageBox.Show(message);
                        }
                        else
                        {
                            string message = "Thao tác thất bại";
                            MessageBox.Show(message);
                        }
                    }

                }
                else
                {
                    string message = "Vui Lòng chọn lớp và học viên";
                    MessageBox.Show(message);
                }

            }
            catch
            {
                string message = "Vui Lòng chọn lớp và học viên";
                MessageBox.Show(message);
            }

         //   dataGridView2_CellClick(null, null);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.Id = int.Parse(HidStu.Text);
            s.ClassId = 0;
            //xóa
            if (context2.CheckDeleteRankForMatching(int.Parse(HidStu.Text)))
            {
                if (context.deleteMatching(int.Parse(HidStu.Text)))
                {
                    string message = "Thao tác thành công";
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
                string message = "Học viên đã được xếp lớp và đã có bậc không thể xóa";
                MessageBox.Show(message);
            }
          //  dataGridView2_CellClick(null, null);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Home frm = new Home();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            HidStu.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            hidClass.Text = dataGridView2.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID HV", typeof(int));
            dt2.Columns.Add("Mã Học viên", typeof(string));
            dt2.Columns.Add("Họ tên", typeof(string));
            dt2.Columns.Add("Địa chỉ", typeof(string));
            dt2.Columns.Add("Số điện thoại", typeof(string));
            Student c = new Student();
            c.FullName = "";
            c.ClassId = int.Parse(hidClass.Text);
            foreach (var item in context.GetLstStudents(c))
            {
                dt2.Rows.Add(new object[] { item.Id, item.Code, item.FullName, item.Address, item.Phone });
            }
            dataGridView3.DataSource = dt2;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            HidStu.Text = dataGridView3.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
        }
    }
}
