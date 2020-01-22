using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using JiraLikeYou.BLL.Models;

namespace JiraLikeYou.BLL.Services
{
    public interface ITextBuilder
    {
        string Build(string pattern);

        IEnumerable<string> GetFieldCodes();
    }

    public class TextBuilder : ITextBuilder
    {
        public string daysInStatus = "несколько";
        public string countTickets = "несколько";
        public string createDate = "не понял дату";
        public string userEmail = "почта какого-то чувака";
        public string userName = "какой-то чувак";
        public string ticketKey = "непонятный тикет";
        public string ticketName = "непонятный тикет";
        public string ticketStatus = "непонятный статус";
        public string ticketPriority = "непонятный приоритет";
        public string ticketCreateDate = "дата тикета";

        public TextBuilder(Occasion occasion)
        {
            daysInStatus = occasion.DaysInStatus?.ToString() ?? daysInStatus;
            countTickets = occasion.CountTickets?.ToString() ?? countTickets;
            createDate = occasion.CreateDate.ToString() ?? createDate;
            userEmail = occasion.User?.Email ?? userEmail;
            userName = occasion.User?.Name ?? userName;
            ticketKey = occasion.Ticket?.Key ?? ticketKey;
            ticketName = occasion.Ticket?.Name ?? ticketName;
            ticketStatus = occasion.Ticket?.Status.Name ?? ticketStatus;
            ticketPriority = occasion.Ticket?.Priority.Name ?? ticketPriority;
            ticketCreateDate = occasion.Ticket?.CreateDate.ToString() ?? ticketCreateDate;
        }

        public string Build(string pattern)
        {
            Regex regex = new Regex("{(?<keyWord>[^}]+)}");
            var text = regex.Replace(pattern, ReplaceKeyWords);

            return text;
        }

        //https://stackoverflow.com/questions/53422907/how-to-use-variable-inside-interpolated-string
        private string ReplaceKeyWords(Match m)
        {
            var keyWord = m.Groups["keyWord"].Value;
            var prop = GetType().GetField(keyWord);
            var value = prop?.GetValue(this).ToString();
            
            return value ?? keyWord;
        }

        public IEnumerable<string> GetFieldCodes()
        {
            var props = typeof(TextBuilder).GetFields();
            return props.Select(x => x.Name);
        }
    }
}
