using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VovinamScoreManager.Models;

namespace VovinamScoreManager.Services
{
    public class ClassAndScoreServices
    {
        VOVINAM_SCORE_MNGContext context = new VOVINAM_SCORE_MNGContext();

        public List<Class> GetLstClasss(Class filter)
        {
            List<Class> Classs = context.Classes.ToList();
            // đã trả về 1 list toàn bộ class


            foreach (Class c in Classs)
            {
                c.Account = context.Accounts.Where(x => x.Id == c.AccountId).FirstOrDefault();
            }
            if (filter.Name.Trim().ToLower() != "")
            {
                Classs = Classs.Where(x => x.Name.ToLower().Contains(filter.Name)).ToList();
            }
            return Classs;
        }

        public Class GetClassById(int id)
        {
            try
            {
                Class Class = new Class();
                Class = context.Classes.Where(x => x.Id == id).FirstOrDefault();
                return Class;
            }
            catch
            {
                return null;
            }

        }
        public Boolean InsertClass(Class pro)
        {
            Class a = new Class();
            a.Name = pro.Name;
            a.Description = pro.Description;
            a.Code = pro.Code;
            a.AccountId = pro.AccountId;
            try
            {
                context.Classes.Add(a);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
          
        }
        public Boolean ModifyClass(Class pro)
        {
            Class a = context.Classes.Where(x => x.Id == pro.Id).FirstOrDefault();
            a.Name = pro.Name;
            a.Description = pro.Description;
            a.AccountId = pro.AccountId;
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

        public Boolean CheckDeleteClass(int ClassId)
        {
            try
            {
                Student st = context.Students.Where(x => x.ClassId == ClassId).FirstOrDefault();
                if (st != null)
                {
                    if (st.ClassId != null)
                    {
                        return false;
                    }
                }

            }
            catch
            {
            }
            return true;
        }
        public Boolean DeleteClass(List<int> lstID)
        {
            try
            {
                List<Class> lstClass = context.Classes.Where(x => lstID.Contains(x.Id)).ToList();
                foreach (var item in lstClass)
                {
                    context.Classes.Remove(item);
                }
                context.SaveChanges();
                return true;
            }
            catch
            {
            }
            return false;
        }




        public List<Score> GetLstScore(Score filter)
        {


            List<Score> Scores = context.Scores.ToList();
            foreach (var item in Scores)
            {
                item.Student = context.Students.Where(x => x.Id == item.StudentId).FirstOrDefault();
            }
            if (filter.Student.ClassId!=null && filter.Student.ClassId != 0)
            {
                Scores = Scores.Where(x => x.Student.ClassId == filter.Student.ClassId).ToList();
                if (filter.Student.FullName != "")
                {
                    Scores = Scores.Where(x => x.Student.FullName.ToLower().Contains(filter.Student.FullName.ToLower())).ToList();
                }
                
                return Scores;
            }
            else
            {
                return new List<Score>();
            }

            
        }

        public Score GetScoreById(int id)
        {
            try
            {
                Score Score = new Score();
                Score = context.Scores.Where(x => x.Id == id).FirstOrDefault();
                Score.Student = context.Students.Where(x => x.Id == Score.StudentId).FirstOrDefault();
                Score.Student.Class = context.Classes.Where(x => x.Id == Score.Student.ClassId).FirstOrDefault();
                return Score;
            }
            catch
            {
                return null;
            }

        }
        public Boolean InsertScore(Score pro)
        {
            Score a = new Score();
            a.StudentId = pro.StudentId;
            a.Score1 = pro.Score1;

            try
            {
                context.Scores.Add(a);
                context.SaveChanges();
                return true;
            }
            catch
            {
            }
            return false;
        }
        public Boolean ModifyScore(Score pro)
        {
            Score a = context.Scores.Where(x => x.Id == pro.Id).FirstOrDefault();
            a.Score1 = pro.Score1;
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



        public List<Rank> GetLstRank()
        {


            List<Rank> Ranks = context.Ranks.ToList();

            return Ranks;
        }

        public Rank GetRankById(int id)
        {
            try
            {
                Rank Rank = new Rank();
                Rank = context.Ranks.Where(x => x.Id == id).FirstOrDefault();
                return Rank;
            }
            catch
            {
                return null;
            }

        }
        public Boolean InsertRank(Rank pro)
        {
            Rank a = new Rank();
            a.Name = pro.Name;
            a.LimitScore = pro.LimitScore;
            a.MaxScore = pro.MaxScore;
            a.Image = pro.Image;
            try
            {
                context.Ranks.Add(a);
                context.SaveChanges();
                return true;
            }
            catch
            {
            }
            return false;
        }
        public Boolean ModifyRank(Rank pro)
        {
            Rank a = context.Ranks.Where(x => x.Id == pro.Id).FirstOrDefault();
            a.Name = pro.Name;
            a.LimitScore = pro.LimitScore;
            a.MaxScore = pro.MaxScore;
            a.Image = pro.Image;
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

        public Boolean CheckDeleteRank(int RankId)
        {
            try
            {
                Student st = context.Students.Where(x => x.RankId == RankId).FirstOrDefault();
                if (st != null)
                {
                    if (st.RankId != null)
                    {
                        return false;
                    }
                }

            }
            catch
            {
            }
            return true;
        }

        public Boolean CheckDeleteRankForMatching(int studentID)
        {
            try
            {
                Student st = context.Students.Where(x => x.Id == studentID).FirstOrDefault();
                if (st.RankId != null && st.RankId != 0)
                {
                    return false;
                }
            }
            catch
            {
            }
            return true;
        }
        public Boolean DeleteRank(List<int> lstID)
        {
            try
            {
                List<Rank> lstRank = context.Ranks.Where(x => lstID.Contains(x.Id)).ToList();
                foreach (var item in lstRank)
                {
                    context.Ranks.Remove(item);
                }
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
