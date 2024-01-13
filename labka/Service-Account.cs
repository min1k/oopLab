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
        void CreateAccount(GameAccount account);
        void UpdateAccount(GameAccount account);
        void DeleteAccount(int accountId);
        void ReadAccount(int accountId);

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
            return _accountRepository.RGetAllAccounts();
        }



        public void CreateAccount(GameAccount account)
        {
            _accountRepository.RCreateAccount(account);
        }

        public void ReadAccount(int accountId)
        {
            _accountRepository.RReadAccount(accountId);
        }

        public void DeleteAccount(int accountId)
        {
            _accountRepository.RDeleteAccount(accountId);
        }



        public void UpdateAccount(GameAccount account)
        {
            _accountRepository.RUpdateAccount(account);
        }
    }

}
