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
    public partial class ViewRank : Form
    {
        public ViewRank()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            
            if (cboClassSearch.SelectedValue != null)
            {

                s.ClassId = (int?)cboClassSearch.SelectedValue;
            }
            else
            {
                s.ClassId = 0;
            }
            s.FullName = txtNameSearch.Text;


            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID", typeof(int));
            dt2.Columns.Add("Mã lớp", typeof(string));
            dt2.Columns.Add("Tên lớp", typeof(string));
            dt2.Columns.Add("Mã Học viên", typeof(string));
            dt2.Columns.Add("Tên học viên", typeof(string));
            dt2.Columns.Add("Cấp bậc", typeof(string));
            foreach (var item in context.GetLstStudents(s))
            {
                dt2.Rows.Add(new object[] { item.Id, item.Class.Code, item.Class.Name, item.Code, item.FullName, item.Rank.Name });
            }
            dtgridCart.DataSource = dt2;

        }
        StudentServices context = new StudentServices();
        ClassAndScoreServices context2 = new ClassAndScoreServices();
        private void ViewRank_Load(object sender, EventArgs e)
        {
            Student s = new Student();
            s.ClassId = 0;

            s.FullName = txtNameSearch.Text;

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID", typeof(int));
            dt2.Columns.Add("Mã lớp", typeof(string));
            dt2.Columns.Add("Tên lớp", typeof(string));
            dt2.Columns.Add("Mã Học viên", typeof(string));
            dt2.Columns.Add("Tên học viên", typeof(string));
            dt2.Columns.Add("Cấp bậc", typeof(string));
            foreach (var item in context.GetLstStudents(s))
            {
                dt2.Rows.Add(new object[] { item.Id, item.Class?.Code, item.Class?.Name, item.Code, item.FullName, item.Rank?.Name });
            }
            dtgridCart.DataSource = dt2;

            Models.Class c1 = new Models.Class();
            c1.Name = "";
            cboClassSearch.DataSource = context2.GetLstClasss(c1).Where(x => x.AccountId == ControlID.accountID).ToList();
            cboClassSearch.DisplayMember = "Name";
            cboClassSearch.ValueMember = "Id";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home frm = new Home();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }
    }
}
