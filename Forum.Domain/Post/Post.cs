using ENode.Domain;
using Forum.Domain.Replies;
using Forum.Infrastructure;
using System;
using System.Collections.Generic;

namespace Forum.Domain.Post
{
    /// <summary>
    /// 帖子聚合根
    /// </summary>
    public class Post:AggregateRoot<string>
    {
        private string _subject;
        private string _body;
        private string _sectionId;
        private string _authorId;
        private ISet<string> _replyIds;
        private PostReplyStatisticInfo _replyStatisticInfo;

        public Post(string id, string subject, string body, string sectionId, string authorId):base(id)
        {
            Assert.IsNotNullOrWhiteSpace("帖子标题", subject);
            Assert.IsNotNullOrWhiteSpace("帖子内容", body);
            Assert.IsNotNullOrWhiteSpace("帖子所属板块", sectionId);
            Assert.IsNotNullOrWhiteSpace("帖子作者", authorId);
            if (subject.Length > 256)
            {
                throw new Exception("帖子标题长度不能超过256");
            }
            if (body.Length > 4000)
            {
                throw new Exception("帖子内容长度不能超过4000");
            }
            ApplyEvent(new PostCreatedEvent(subject, body, sectionId, authorId));
        }

        public void Update(string subject,string body)
        {
            Assert.IsNotNullOrWhiteSpace("帖子标题", subject);
            Assert.IsNotNullOrWhiteSpace("帖子内容", body);
            if (subject.Length > 256)
            {
                throw new Exception("帖子标题长度不能超过256");
            }
            if (body.Length > 4000)
            {
                throw new Exception("帖子内容长度不能超过4000");
            }
            ApplyEvent(new PostUpdateEvent(subject, body));
        }

        public void AcceptNewReply(Reply reply)
        {
            if (!_replyIds.Add(reply.Id)) return;

            if (_replyStatisticInfo == null)
            {
                ApplyEvent(new PostReplyStatisticInfoChangedEvent(new PostReplyStatisticInfo(
                    reply.Id,
                    reply
                    ))
            }
        }
    }
}
