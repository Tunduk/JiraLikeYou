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
            var pattern = "Известный корневой параметр = {countTickets}, неизвестный корневой параметр = {daysInStatus}, " +
                          "известный user параметр = {userEmail}, неизвестный user параметр = {userName}, " +
                          "параметр неизвестного тикета = {ticketKey}, непонятное поле = {unknowField}";

            var expectedText = "Известный корневой параметр = 5, неизвестный корневой параметр = несколько, " +
                               "известный user параметр = test@email.test, неизвестный user параметр = какой-то чувак, " +
                               "параметр неизвестного тикета = непонятный тикет, непонятное поле = unknowField";

            // Act
            var factText = _textBuilder.Build(pattern);

            // Assert
            Assert.Equal(expectedText, factText);
        }
    }
}
