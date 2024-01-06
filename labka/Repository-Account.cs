using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labka
{
    public interface IGameAccountRepository
    {
        List<GameAccount> GetAllAccounts();
        GameAccount GetAccountById(int accountId);
        void CreateAccount(GameAccount account);
        void UpdateAccount(GameAccount account);
        void DeleteAccount(int accountId);
    }


    public class GameAccountRepository : IGameAccountRepository
    {
        private readonly DbContext _dbContext;

        public GameAccountRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<GameAccount> GetAllAccounts()
        {
            return _dbContext.GameAccounts;
        }

        public GameAccount GetAccountById(int accountId)
        {
            return _dbContext.GameAccounts.FirstOrDefault(a => a.Id == accountId);
        }

        public void CreateAccount(GameAccount account)
        {
            _dbContext.GameAccounts.Add(account);
        }

        public void UpdateAccount(GameAccount account)
        {
            
        }

        public void DeleteAccount(int accountId)
        {
            var account = _dbContext.GameAccounts.FirstOrDefault(a => a.Id == accountId);
            if (account != null)
            {
                _dbContext.GameAccounts.Remove(account);
            }
        }
    }
}
