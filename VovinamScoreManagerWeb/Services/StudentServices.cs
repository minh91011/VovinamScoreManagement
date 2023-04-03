using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VovinamScoreManagerWeb.Models;

namespace VovinamScoreManagerWeb.Services
{
    public class StudentServices
    {
        VOVINAM_SCORE_MNGContext context = new VOVINAM_SCORE_MNGContext();

        public List<Student> GetLstStudents(Student filter)
        {
            List<Student> Students = context.Students.ToList();
            foreach (var item in Students)
            {
                item.Class = context.Classes.Where(x => x.Id == item.ClassId).FirstOrDefault();
                item.Rank = context.Ranks.Where(x => x.Id == item.RankId).FirstOrDefault();
            }
            if (filter.ClassId != null && filter.ClassId != 0)
            {
                Students = Students.Where(x => x.ClassId == filter.ClassId).ToList();
                if (filter.FullName.Trim().ToLower() != "")
                {
                    Students = Students.Where(x => x.FullName.ToLower().Contains(filter.FullName)).ToList();


                }
                return Students;
            }
            if (filter.ClassId == 0)
            {
                return Students;
            }

            return new List<Student>();

        }

        public Student GetStudentById(int id)
        {
            try
            {
                Student Student = new Student();
                Student = context.Students.Where(x => x.Id == id).FirstOrDefault();
                Student.Class = context.Classes.Where(x => x.Id == Student.ClassId).FirstOrDefault();
                return Student;
            }
            catch
            {
                return null;
            }

        }
        public Boolean InsertStudent(Student pro)
        {
            Student a = new Student();
            a.FullName = pro.FullName;
            a.Code = pro.Code;
            a.Address = pro.Address;
            a.Phone = pro.Phone;
            try
            {
                context.Students.Add(a);
                context.SaveChanges();
                return true;
            }
            catch
            {
            }
            return false;
        }
        public Boolean ModifyStudent(Student pro)
        {
            Student a = context.Students.Where(x => x.Id == pro.Id).FirstOrDefault();
            a.FullName = pro.FullName;
            a.Address = pro.Address;
            a.Phone = pro.Phone;
            if (pro.ClassId != null)
            {
                a.ClassId = pro.ClassId;
            }
            if (pro.RankId != null)
            {
                a.RankId = pro.RankId;
            }
            try
            {
                context.SaveChanges();
                return true;
            }
            catch
            {
            }
            return false;
        }

        public Boolean UpDateRankStudent(int rankId, int studentID)
        {
            Student a = context.Students.Where(x => x.Id == studentID).FirstOrDefault();

            a.RankId = rankId;

            try
            {
                context.SaveChanges();
                return true;
            }
            catch
            {
            }
            return false;
        }



        public Boolean CheckDeleteStudent(int studentId)
        {
            try
            {
                Student st = context.Students.Where(x => x.Id == studentId).FirstOrDefault();
                if (st.ClassId != null)
                {
                    return false;
                }
            }
            catch
            {
            }
            return true;
        }

        public Boolean DeleteStudent(List<int> lstID)
        {
            try
            {
                List<Student> lstStudent = context.Students.Where(x => lstID.Contains(x.Id)).ToList();
                foreach (var item in lstStudent)
                {
                    context.Students.Remove(item);
                }
                context.SaveChanges();
                return true;
            }
            catch
            {
            }
            return false;
        }



        public Boolean SetUpStudentClass(int classId, int studentId)
        {
            try
            {
                Student st = context.Students.Where(x => x.Id == studentId).FirstOrDefault();
                st.ClassId = classId;

                Score s = new Score();
                s.StudentId = studentId;
                s.Score1 = null;
                Score s2 = context.Scores.Where(x => x.StudentId == studentId).FirstOrDefault();

                if (s2 != null)
                {
                    context.Scores.Remove(s2);
                }

                context.Scores.Add(s);
                context.SaveChanges();
                return true;
            }
            catch
            {
            }
            return false;
        }

        public Boolean CheckSetUpStudentClass(int classId, int studentId)
        {
            try
            {
                Student st = context.Students.Where(x => x.Id == studentId).FirstOrDefault();
                if (st.ClassId != null || st.ClassId != 0)
                {
                    return true;
                }

                return false;
            }
            catch
            {

            }
            return false;
        }


        public Boolean deleteMatching(int studentId)
        {
            try
            {
                Student st = context.Students.Where(x => x.Id == studentId).FirstOrDefault();
                st.ClassId = null;
                context.SaveChanges();
                return true;
            }
            catch
            {
            }
            return false;
        }



    }
}
