﻿using System;
using System.Collections.Generic;
using System.Linq;
using JiraLikeYou.DAL.Entities;
using JiraLikeYou.DAL.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace JiraLikeYou.DAL.Repositories
{
    public interface IOccasionRepository
    {
        IEnumerable<Occasion> Get();

        Occasion GetLast();

        Occasion Get(long id);

        void Create(Occasion occasion);
    }

    public class OccasionRepository : IOccasionRepository
    {
        private readonly DataContext _dataContext;

        public OccasionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Occasion> Get()
        {
            return _dataContext.Occasions
                .Include(x => x.User)
                .Include(x => x.Ticket)
                .Include(x => x.Ticket.Status)
                .Include(x => x.Ticket.Priority)
                .AsEnumerable();
        }

        public Occasion GetLast()
        {
            return _dataContext.Occasions
                .Include(x => x.User)
                .Include(x => x.Ticket)
                .Include(x => x.Ticket.Status)
                .Include(x => x.Ticket.Priority)
                .FirstOrDefault(p => p.Id == _dataContext.Occasions.Max(x => x.Id));
        }

        public Occasion Get(long id)
        {
            return _dataContext.Occasions
                .Include(x => x.User)
                .Include(x => x.Ticket)
                .Include(x => x.Ticket.Status)
                .Include(x => x.Ticket.Priority)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Create(Occasion occasion)
        {
            occasion.CreateDate = DateTime.Now;
            _dataContext.Occasions.Add(occasion);
            _dataContext.SaveChanges();
        }
    }
}
