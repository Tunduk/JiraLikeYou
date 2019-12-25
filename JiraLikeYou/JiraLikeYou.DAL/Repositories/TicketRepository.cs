using System;
using System.Linq;
using JiraLikeYou.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace JiraLikeYou.DAL.Repositories
{
    public interface ITicketRepository
    {
        Ticket Get(long id);

        void Create(Ticket ticket);
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

        public void Create(Ticket ticket)
        {
            ticket.CreateDate = DateTime.Now;
            _dataContext.Add(ticket);
            _dataContext.SaveChanges();
        }
    }
}
