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
using static VovinamScoreManager.Program;

namespace VovinamScoreManager
{
    public partial class MngScore : Form
    {
        public MngScore()
        {
            InitializeComponent();
        }
        ClassAndScoreServices context = new ClassAndScoreServices();

        private void button6_Click(object sender, EventArgs e)
        {
            Home frm = new Home();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Score s = new Score();
            s.Student = new Student();
            if (cboClassSearch.SelectedValue != null)
            {

                s.Student.ClassId = (int?)cboClassSearch.SelectedValue;
            }
            else
            {
                s.Student.ClassId = 0;
            }
            s.Student.FullName = txtNameSearch.Text;


            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID", typeof(int));
            dt2.Columns.Add("Mã lớp", typeof(string));
            dt2.Columns.Add("Tên lớp", typeof(string));
            dt2.Columns.Add("Mã Học viên", typeof(string));
            dt2.Columns.Add("Tên học viên", typeof(string));
            dt2.Columns.Add("Điểm số", typeof(int));
            foreach (var item in context.GetLstScore(s))
            {
                dt2.Rows.Add(new object[] { item.Id, item.Student.Class.Code, item.Student.Class.Name, item.Student.Code, item.Student.FullName, item.Score1 });
            }
            dataGridView1.DataSource = dt2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (nmScore.Value == 0)
            {
                string message = "Vui Lòng nhập điểm số";
                MessageBox.Show(message);
            }
            else
            {
                Score s = new Score();
                s = context.GetScoreById(int.Parse(hidID.Text));
                s.Score1 = (int?)nmScore.Value;

                if (context.ModifyScore(s))
                {
                    string message = "Cập nhật điểm thành công";
                    MessageBox.Show(message);
                    List<Rank> lstRank = context.GetLstRank();
                    int rankId = lstRank.Where(x => x.LimitScore <= s.Score1 && s.Score1 <= x.MaxScore).Select(x => x.Id).FirstOrDefault();

                    StudentServices ser = new StudentServices();
                    ser.UpDateRankStudent(rankId, (int)s.StudentId);

                    button1_Click(null, null);
                }
                else
                {
                    string message = "Thao tác thất bại";
                    MessageBox.Show(message);
                }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            hidID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            Score c = context.GetScoreById(int.Parse(hidID.Text));
            txtName.Text = c.Student.FullName;
            txtCode.Text = c.Student.Code;
            if (c.Score1 != null)
            {
                nmScore.Value = (decimal)c.Score1;

            }
            txtClass.Text = c.Student.Class.Name;
        }

        private void MngScore_Load(object sender, EventArgs e)
        {
            Score s = new Score();
            s.Student = new Student();

            s.Student.ClassId = 0;



            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID", typeof(int));
            dt2.Columns.Add("Mã lớp", typeof(string));
            dt2.Columns.Add("Tên lớp", typeof(string));
            dt2.Columns.Add("Mã Học viên", typeof(string));
            dt2.Columns.Add("Tên học viên", typeof(string));
            dt2.Columns.Add("Điểm số", typeof(int));
            foreach (var item in context.GetLstScore(s))
            {
                dt2.Rows.Add(new object[] { item.Id, item.Student.Class.Code, item.Student.Class.Name, item.Student.Code, item.Student.FullName, item.Score1 });
            }
            dataGridView1.DataSource = dt2;

            Models.Class c1 = new Models.Class();
            c1.Name = "";
            cboClassSearch.DataSource = context.GetLstClasss(c1).Where(x => x.AccountId == ControlID.accountID).ToList();
            cboClassSearch.DisplayMember = "Name";
            cboClassSearch.ValueMember = "Id";

        }
    }
}
