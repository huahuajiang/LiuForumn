using ENode.Domain;
using Forum.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Domain.Replies
{
    public class Reply:AggregateRoot<string>
    {
        private string _postId;
        private string _parentId;
        private string _authorId;
        private string _body;
        private DateTime _createdOn;

        public string GetAuthorId()
        {
            return _authorId;
        }

        public DateTime GetCreateTime()
        {
            return _createdOn;
        }

        public Reply(string id,string postId,Reply parent,string authorId,string body) : base(id)
        {
            Assert.IsNotNullOrWhiteSpace("杯回复的帖子", postId);
            Assert.IsNotNullOrWhiteSpace("回复作者", authorId);
            Assert.IsNotNullOrWhiteSpace("回复内容", body);
            if (body.Length > 4000)
            {
                throw new Exception("回复内容长度不能超过4000");
            }
            if (parent != null && id == parent.Id)
            {
                throw new ArgumentException(string.Format("回复的parentId不能是当前回复的Id:{0}", id));
            }
            //ApplyEvent()
        }
    }
}
