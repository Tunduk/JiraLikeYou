using System;
using System.Collections.Generic;
using System.Text;
using JiraLikeYou.BLL.Models;
using JiraLikeYou.DAL.Repositories;
using Microsoft.EntityFrameworkCore.Migrations;
using IHistoryRepository = JiraLikeYou.DAL.Repositories.IHistoryRepository;

namespace JiraLikeYou.BLL.Services
{
    public interface IHistoryService
    {
        IEnumerable<History> GetHistory();
    }

    public class HistoryService
    {
        private readonly IHistoryRepository _historyRepository;

        public HistoryService(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        public IEnumerable<History> GetHistory()
        {
            foreach (var history in _historyRepository.Get())
            {
                yield return new History
                {
                    CreateDate = history.CreateDate,
                    AvatarLink = history.AvatarLink,
                    Text = history.DefaultText
                };
            }
        } 
    }
}
