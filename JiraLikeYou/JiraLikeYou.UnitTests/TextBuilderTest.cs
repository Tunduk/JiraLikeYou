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
            var pattern = "��������� �������� �������� = {countTickets}, ����������� �������� �������� = {daysInStatus}, " +
                          "��������� user �������� = {userEmail}, ����������� user �������� = {userName}, " +
                          "�������� ������������ ������ = {ticketKey}, ���������� ���� = {unknowField}";

            var expectedText = "��������� �������� �������� = 5, ����������� �������� �������� = ���������, " +
                               "��������� user �������� = test@email.test, ����������� user �������� = �����-�� �����, " +
                               "�������� ������������ ������ = ���������� �����, ���������� ���� = unknowField";

            // Act
            var factText = _textBuilder.Build(pattern);

            // Assert
            Assert.Equal(expectedText, factText);
        }
    }
}
