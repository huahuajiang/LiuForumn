using ECommon.Components;
using System;
using System.Threading.Tasks;

namespace Forum.Domain.Accounts
{
    /// <summary>
    /// 注册账号领域服务，封装账号注册时关于账号名唯一的业务规则
    /// </summary>
    [Component]
    public class RegisterAccountService
    {
        private readonly IAccountIndexRepository _accountIndexRepository;

        public RegisterAccountService(IAccountIndexRepository accountIndexRepository)
        {
            _accountIndexRepository = accountIndexRepository;
        }

        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task RegisterAccount(Account account)
        {
            var accountIndex=await _accountIndexRepository.FingByAccountName(account.Name);
            if (accountIndex == null)
            {
                await _accountIndexRepository.Add(new AccountIndex(account.Id, account.Name));
            }
            else
            {
                throw new DuplicateWaitObjectException(account.Name);
            }
        }
    }
}
