using Moq;
using TildeDeclensions.Business.DeclensionRules;
using TildeDeclensions.Business.DeclensionServices;
using TildeDeclensions.Business.DTOs;

namespace TildeDeclensions.Business.Tests.Handlers
{
    public class BaseDeclensionHandlerTests
    {
        private class TestDeclensionHandler : BaseDeclensionHandler
        {
            public TestDeclensionHandler(IEnumerable<IRule> rules) : base(rules) { }

            protected override InflectionData Process(string word)
            {
                return new MaleInflectionData()
                {
                    MaleSingularRow = new(word, word, word, word, word, word, word),
                    MalePluralRow = new(word, word, word, word, word, word, word)
                };
            }
        }

        [Fact]
        public void Handle_ShouldProcessWord_WhenRulesPass()
        {
            // Arrange
            var mockRule = new Mock<IRule>();
            mockRule.Setup(r => r.Evaluate(It.IsAny<string>())).Returns(true);

            var handler = new TestDeclensionHandler(new List<IRule> { mockRule.Object });

            // Act
            var result = handler.Handle("TestWord") as MaleInflectionData;

            // Assert
            Assert.Equal("TestWord", result?.MaleSingularRow.Nominative); // Process should lowercase the word
        }

        [Fact]
        public void Handle_ShouldThrowUndeterminedDeclensionException_WhenNoHandlerCanProcess()
        {
            // Arrange
            var mockRule = new Mock<IRule>();
            mockRule.Setup(r => r.Evaluate(It.IsAny<string>())).Returns(false);

            var handler = new TestDeclensionHandler(new List<IRule> { mockRule.Object });

            // Act & Assert
            Assert.Throws<UndeterminedDeclensionException>(() => handler.Handle("UnknownWord"));
        }

        [Fact]
        public void Handle_ShouldUseNextHandler_WhenRulesFail()
        {
            // Arrange
            var mockRule = new Mock<IRule>();
            mockRule.Setup(r => r.Evaluate(It.IsAny<string>())).Returns(false);
            var handler = new TestDeclensionHandler(new List<IRule> { mockRule.Object });

            var nextHandlerMock = new Mock<IDeclensionHandler>();
            handler.SetNext(nextHandlerMock.Object);

            // Act
            var result = handler.Handle("TestWord");

            // Assert
            nextHandlerMock.Verify(x => x.Handle("TestWord"), Times.Once);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Handle_ShouldThrowArgumentNullException_WhenWordIsNullOrEmpty(string word)
        {
            // Arrange
            var handler = new TestDeclensionHandler(new List<IRule>());

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => handler.Handle(word));
        }
    }
}
