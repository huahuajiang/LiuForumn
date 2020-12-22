using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Domain.Post
{
    public class PostCreatedEvent:DomainEvent<string>
    {
        public string Subject { get; private set; }
        public string Body { get; private set; }
        public string SectionId { get; private set; }
        public string AuthorId { get; private set; }

        private PostCreatedEvent() { }
        public PostCreatedEvent(string subject,string body,string sectionId,string authorId)
        {
            Subject = subject;
            Body = body;
            SectionId = sectionId;
            AuthorId = authorId;
        }
    }
}
