using System;
using System.Collections.Generic;
using System.Text;
using JiraLikeYou.BLL.Models;

namespace JiraLikeYou.BLL.Services
{
    public interface ITextBuilder
    {
        string Build(string pattern);
    }

    public class TextBuilder : ITextBuilder
    {
        private string daysInStatus = "несколько";
        private string countTickets = "несколько";
        private string createDate = "не понял дату";
        private string userEmail = "почта непонятного чувака";
        private string userName = "какой-то чувак";
        private string ticketKey = "непонятный тикет";
        private string ticketName = "непонятный тикет";
        private string ticketStatus = "непонятный статус";
        private string ticketPriority = "непонятный приоритет";
        private string ticketCreateDate = "даита тикета";

        public TextBuilder(Occasion occasion)
        {
            daysInStatus = occasion.DaysInStatus?.ToString() ?? daysInStatus;
            countTickets = occasion.CountTickets?.ToString() ?? countTickets;
            createDate = occasion.CreateDate.ToString() ?? createDate;
            userEmail = occasion.User?.Email ?? userEmail;
            userName = occasion.User?.Name ?? userName;
            ticketKey = occasion.Ticket?.Key ?? ticketKey;
            ticketName = occasion.Ticket?.Name ?? ticketName;
            ticketStatus = occasion.Ticket?.Status ?? ticketStatus;
            ticketPriority = occasion.Ticket?.Priority ?? ticketPriority;
            ticketCreateDate = occasion.Ticket?.CreateDate.ToString() ?? ticketCreateDate;
        }

        public string Build(string pattern)
        {
            return $"{pattern}";
        }
    }
}
