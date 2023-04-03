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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace VovinamScoreManager
{
    public partial class MngRank : Form
    {
        ClassAndScoreServices context = new ClassAndScoreServices();
        static int state;
        public MngRank()
        {
            InitializeComponent();
            hidID.Hide();
            nmFrom.Enabled = false;
            txtName.Enabled = false;
            txtImage.Enabled = false;
            nmTo.Enabled = false;
            state = 1;
            hidID.Text = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            nmFrom.Enabled = true;
            nmTo.Enabled = true;
            txtName.Text = "";
            txtImage.Text = "";
            txtImage.Enabled = true;
            nmFrom.Value = 0;
            nmTo.Value = 0;
            state = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            txtImage.Enabled = true;
            nmFrom.Enabled = true;
            nmTo.Enabled = true;
            state = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // state =-1 là insert
            if (state == -1)
            {
                if (txtName.Text.Trim().Equals("") == false && nmFrom.Value != 0 && nmTo.Value != 0)
                {
                    if (nmFrom.Value >= nmTo.Value)
                    {
                        string message = "Vui Lòng điền điểm từ phải nhỏ hơn điểm đến";
                        MessageBox.Show(message);
                    }
                    else
                    {
                        Rank cl = new Rank();
                        cl.Name = txtName.Text;
                        cl.LimitScore = (int?)nmFrom.Value;
                        cl.MaxScore = (int?)nmTo.Value;
                        cl.Image = txtImage.Text;
                        if (context.InsertRank(cl))
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
                    Rank cl = context.GetRankById(int.Parse(hidID.Text));

                    cl.Name = txtName.Text;
                    cl.LimitScore = (int?)nmFrom.Value;
                    cl.MaxScore = (int?)nmTo.Value;
                    cl.Image = txtImage.Text;
                    if (context.ModifyRank(cl))
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
            nmFrom.Enabled = false;
            nmTo.Enabled = false;
            txtName.Text = "";
            txtImage.Enabled = false;
            txtImage.Text = "";
            nmFrom.Value = 0;
            nmTo.Value = 0;

            state = 1;

            MngRank_Load(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtName.Enabled = false;
            txtImage.Enabled = false;
            nmFrom.Enabled = false;
            nmTo.Enabled = false;
            state = 1;
            hidID.Text = "0";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (hidID.Text != "0")
            {
                List<int> l = new List<int>();
                l.Add(int.Parse(hidID.Text));
                if (context.CheckDeleteRank(l[0]))
                {
                    if (context.DeleteRank(l))
                    {
                        string message = "Xóa thông tin thành công";
                        MessageBox.Show(message);
                        MngRank_Load(null, null);
                    }
                    else
                    {
                        string message = "Thao tác thất bại";
                        MessageBox.Show(message);
                    }
                }
                else
                {
                    string message = "Đã có học viên mang cấp bậc này , không thể xóa";
                    MessageBox.Show(message);
                }

            }
            else
            {
                string message = "Vui Lòng chọn bản ghi cần xóa";
                MessageBox.Show(message);
            }

        }

        private void MngRank_Load(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID ", typeof(int));
            dt2.Columns.Add("Tên ", typeof(string));
            dt2.Columns.Add("Điểm từ", typeof(int));
            dt2.Columns.Add("Điểm đến", typeof(int));
            Models.Class c = new Models.Class();
            c.Name = "";
            foreach (var item in context.GetLstRank())
            {
                dt2.Rows.Add(new object[] { item.Id, item.Name, item.LimitScore, item.MaxScore });
            }
            dataGridView1.DataSource = dt2;
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
            hidID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            Rank c = context.GetRankById(int.Parse(hidID.Text));
            txtName.Text = c.Name;
            txtImage.Text = c.Image;
            nmFrom.Value = (decimal)c.LimitScore;
            nmTo.Value = (decimal)c.MaxScore;
            string im = c.Image;
            pictureBox1.ImageLocation = im;
        }
    }
}
