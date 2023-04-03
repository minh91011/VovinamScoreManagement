using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VovinamScoreManagerWeb.Models;

namespace VovinamScoreManagerWeb.Services
{
    public class AccountServices
    {
        VOVINAM_SCORE_MNGContext context = new VOVINAM_SCORE_MNGContext();

        public Boolean Register(Account account)
        {
            Account a = new Account();
            a.AccRule = account.AccRule;
            a.Username = account.Username;
            a.FullName  = account.FullName ;
            a.Password = account.Password;
            a.Address = account.Address;
            a.Phone = account.Phone;
            try
            {
                context.Accounts.Add(a);
                context.SaveChanges();
                return true;
            }
            catch
            {
            }
            return false;
        }

        public  List<Account> GetLstAccount(int rule)
        {
            return context.Accounts.Where(x=>x.AccRule==0).ToList();    
        }

        public Boolean ValidateRegister(Account account)
        {

            try
            {
                List<Account> lstCheck = new List<Account>();
                if (!account.Username.Trim().Equals(""))
                {
                    lstCheck = context.Accounts.Where(x => x.Username.Trim().ToLower() == account.Username.Trim().ToLower()).ToList();
                }
                if (!account.Phone.Trim().Equals(""))
                {
                    lstCheck = context.Accounts.Where(x => x.Phone.Trim().ToLower() == account.Phone.Trim().ToLower()).ToList();
                }
                if (lstCheck.Count == 0)
                {
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }

        public Account Login(string userName, string pass)
        {
            try
            {
                Account account = context.Accounts.Where(x => x.Username.Trim().ToLower().Equals(userName.Trim().ToLower()) == true && x.Password.Trim().ToLower().Equals(pass.Trim().ToLower()) == true).FirstOrDefault();
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
