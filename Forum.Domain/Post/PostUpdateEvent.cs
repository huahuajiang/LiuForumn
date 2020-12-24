using ENode.Eventing;

namespace Forum.Domain.Post
{
    /// <summary>
    /// 表示帖子已修改的领域事件
    /// </summary>
    public class PostUpdateEvent:DomainEvent<string>
    {
        public string Subject { get; private set; }
        public string Body { get; private set; }

        private PostUpdateEvent() { }
        public PostUpdateEvent(string subject,string body)
        {
            Subject = subject;
            Body = body;
        }
    }
}
