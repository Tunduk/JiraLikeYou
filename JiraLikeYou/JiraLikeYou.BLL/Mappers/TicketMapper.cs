using System;
using JiraLikeYou.BLL.Models;

namespace JiraLikeYou.BLL.Mappers
{
    public class TicketMapper
    {
        public Ticket ToBll(DAL.Entities.Ticket dal)
        {
            return dal == null ? null : new Ticket
            {
                Id = dal.Id,
                Key = dal.Key,
                Name = dal.Name,
                Status = dal.Status,
                Priority = dal.Priority,
                UserEmail = dal.UserEmail,
                CreateDate = dal.CreateDate
            };
        }

        public DAL.Entities.Ticket ToDal(Ticket bll)
        {
            return bll == null ? null : new DAL.Entities.Ticket
            {
                Key = bll.Key,
                Name = bll.Name,
                Status = bll.Status,
                UserEmail = bll.UserEmail,
                Priority = bll.Priority
            };
        }
    }
}
