using ENode.Domain;
using Forum.Infrastructure;
using System;

namespace Forum.Domain.Accounts
{
    /// <summary>
    /// 账号聚合根
    /// </summary>
    public class Account:AggregateRoot<string>
    {
        private string _name;
        private string _password;

        public string Name { get => _name; }
        public string Password { get => _password; }

        public Account(string id, string name, string password):base(id)
        {
            Assert.IsNotNullOrWhiteSpace("账户", name);
            Assert.IsNotNullOrWhiteSpace("密码", password);
            if (name.Length > 128)
            {
                throw new Exception("账号长度不能超过128");
            }
            if (password.Length > 128)
            {
                throw new Exception("密码长度不能超过128");
            }
            ApplyEvent(new NewAccountRegisterEvent(name, password));
        }

        private void Handle(NewAccountRegisterEvent evnt)
        {
            _name = evnt.Name;
            _password = evnt.Password;
        }
    }
}
