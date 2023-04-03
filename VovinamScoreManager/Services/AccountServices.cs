using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VovinamScoreManager.Models;

namespace VovinamScoreManager.Services
{
    public class AccountServices
    {
        VOVINAM_SCORE_MNGContext context = new VOVINAM_SCORE_MNGContext();

        

        public  List<Account> GetLstAccount(int rule)
        {
            return context.Accounts.Where(x=>x.AccRule==0).ToList();    
        }



        public Account Login(string userName, string pass)
        {
            try
            {
                Account account = context.Accounts.Where(x => x.Username.Trim().ToLower().Equals(userName.Trim().ToLower()) == true && x.Password.Trim().ToLower().Equals(pass.Trim().ToLower()) == true).FirstOrDefault();
              // select * from ACCount where pass= "pass" and usserName = "userName"




                if (account != null)
                {
                    return account;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }

        }

        public Boolean SetUpAccountClass(int classId, int accountID)
        {
            try
            {
                Class st = context.Classes.Where(x => x.Id == classId).FirstOrDefault();
                st.AccountId = accountID;
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
