using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Domain.Post
{
    public class PostReplyStatisticInfoChangedEvent:DomainEvent<string>
    {
        public PostReplyStatisticInfo StatisticInfo { get; private set; }
        public PostReplyStatisticInfoChangedEvent() { }

        public PostReplyStatisticInfoChangedEvent(PostReplyStatisticInfo statisticInfo)
        {
            StatisticInfo = statisticInfo;
        }
    }
}
