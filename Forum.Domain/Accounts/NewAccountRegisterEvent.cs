using ENode.Eventing;

namespace Forum.Domain.Accounts
{
    public class NewAccountRegisterEvent:DomainEvent<string>
    {
        public string Name { get; private set; }

        public string Password { get; private set; }

        private NewAccountRegisterEvent() { }

        public NewAccountRegisterEvent(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
