using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labka
{
    public interface IGameAccountRepository
    {
        List<GameAccount> RGetAllAccounts();
        void RCreateAccount(GameAccount account);
        void RReadAccount(int accountId);
        void RDeleteAccount(int accountId);
    }


    public class GameAccountRepository : IGameAccountRepository
    {
        private readonly DbContext _dbContext;
        private static int AccountId = 0;

        public GameAccountRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<GameAccount> RGetAllAccounts()
        {
            return _dbContext.GameAccounts;
        }


        public void RCreateAccount(GameAccount account)
        {
            account.Id = ++AccountId;
            _dbContext.GameAccounts.Add(account);
        }

        public void RReadAccount(int accountId)
        {
            //для знаходження 
            var account = _dbContext.GameAccounts.FirstOrDefault(a => a.Id == accountId);
            if (account != null)
            {
                Console.WriteLine($"Account Id: {account.Id}, Username: {account.UserName}, Rating:{account.CurentRating}");
            }
            else
            {
                // Обліковий запис не знайдено, виконайте відповідні дії
                Console.WriteLine($"Акаунт з Id {account.Id} не знайдено .");
            }
        }

        public void RDeleteAccount(int accountId)
        {
            var account = _dbContext.GameAccounts.FirstOrDefault(a => a.Id == accountId);
            if (account != null)
            {
                _dbContext.GameAccounts.Remove(account);
            }
        }
    }
}
