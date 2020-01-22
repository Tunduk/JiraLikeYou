using System;
using System.Linq;
using JiraLikeYou.DAL.Entities;
using JiraLikeYou.DAL.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace JiraLikeYou.DAL.Repositories
{
    public interface ITicketRepository
    {
        Ticket Get(long id);

        Ticket Create(Ticket ticket);
    }

    public class TicketRepository : ITicketRepository
    {
        private readonly DataContext _dataContext;

        public TicketRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Ticket Get(long id)
        {
            return _dataContext.Tickets.SingleOrDefault(x => x.Id == id);
        }

        public Ticket Create(Ticket ticket)
        {

            ticket.CreateDate = DateTime.Now;
            var createdTicket = _dataContext.Add(ticket);
            _dataContext.SaveChanges();
            return createdTicket.Entity;
        }
    }
}
