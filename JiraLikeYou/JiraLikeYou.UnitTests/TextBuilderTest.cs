using System;
using JiraLikeYou.BLL.Models;
using JiraLikeYou.BLL.Services;
using Xunit;

namespace JiraLikeYou.UnitTests
{
    public class TextBuilderTest
    {
        private readonly ITextBuilder _textBuilder;
        private readonly Occasion occasion = new Occasion
        {
            CountTickets = 5,
            User = new User
            {
                Email = "test@email.test"
            }
        };

        public TextBuilderTest()
        {
            _textBuilder = new TextBuilder(occasion);
        }

        [Fact]
        public void BuildTest()
        {
            // Arrange
            var pattern = "Кол-во тикетов = {countTickets}, кол-во дней = {daysInStatus}, " +
                          "почта пользователя = {userEmail}, имя пользователя = {userName}, " +
                          "номер тикета = {ticketKey}, непонятное поле = {unknowField}";

            var expectedText = "Кол-во тикетов = 5, кол-во дней = несколько, " +
                               "почта пользователя = test@email.test, имя пользователя = какой-то чувак, " +
                               "номер тикета = непонятный тикет, непонятное поле = unknowField";

            // Act
            var factText = _textBuilder.Build(pattern);

            // Assert
            Assert.Equal(expectedText, factText);
        }
    }
}
