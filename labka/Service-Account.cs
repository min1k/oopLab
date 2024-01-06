using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labka
{
    public interface IGameAccountService
    {
        List<GameAccount> GetAllAccounts();
        GameAccount GetAccountById(int accountId);
        void CreateAccount(GameAccount account);
        void UpdateAccount(GameAccount account);
        void DeleteAccount(int accountId);
    }


    public class GameAccountService : IGameAccountService
    {
        private readonly IGameAccountRepository _accountRepository;

        public GameAccountService(IGameAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public List<GameAccount> GetAllAccounts()
        {
            return _accountRepository.GetAllAccounts();
        }

        public GameAccount GetAccountById(int accountId)
        {
            return _accountRepository.GetAccountById(accountId);
        }

        public void CreateAccount(GameAccount account)
        {
            _accountRepository.CreateAccount(account);
        }

        public void UpdateAccount(GameAccount account)
        {
            _accountRepository.UpdateAccount(account);
        }

        public void DeleteAccount(int accountId)
        {
            _accountRepository.DeleteAccount(accountId);
        }
    }
 
}
