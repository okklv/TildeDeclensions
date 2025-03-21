using Moq;
using TildeDeclensions.Business.DeclensionRules;
using TildeDeclensions.Business.DeclensionServices;
using TildeDeclensions.Business.DTOs;

namespace TildeDeclensions.Business.Tests.Handlers
{
    public class FirstDeclensionHandlerTests
    {
        [Fact]
        public void Handle_ShouldProcessWord_WhenRulesPass()
        {
            // Arrange
            var mockRule = new Mock<IRule>();
            mockRule.Setup(r => r.Evaluate(It.IsAny<string>())).Returns(true);

            var handler = new FirstDeclensionHandler(new List<IRule> { mockRule.Object });

            // Act
            var result = handler.Handle("amats") as MaleInflectionData;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("amats", result?.MaleSingularRow.Nominative);
            Assert.Equal("amati", result?.MalePluralRow.Nominative);
        }

        [Fact]
        public void Handle_ShouldThrowUndeterminedDeclensionException_WhenNoRuleMatches()
        {
            // Arrange
            var mockRule = new Mock<IRule>();
            mockRule.Setup(r => r.Evaluate(It.IsAny<string>())).Returns(false);

            var handler = new FirstDeclensionHandler(new List<IRule> { mockRule.Object });

            // Act & Assert
            Assert.Throws<UndeterminedDeclensionException>(() => handler.Handle("unknown"));
        }

        [Fact]
        public void Handle_ShouldUseNextHandler_WhenRulesFail()
        {
            // Arrange
            var mockRule = new Mock<IRule>();
            mockRule.Setup(r => r.Evaluate(It.IsAny<string>())).Returns(false);

            var handler = new FirstDeclensionHandler(new List<IRule> { mockRule.Object });

            var nextHandlerMock = new Mock<IDeclensionHandler>();
            handler.SetNext(nextHandlerMock.Object);

            // Act
            var result = handler.Handle("amats");

            // Assert
            nextHandlerMock.Verify(x => x.Handle("amats"), Times.Once);
        }

        [Theory]
        [InlineData("amats", "amats", "amata", "amatam", "amatu", "ar amatu", "amatā", "amats!")]
        [InlineData("zābaks", "zābaks", "zābaka", "zābakam", "zābaku", "ar zābaku", "zābakā", "zābaks!")]
        public void GetSingularRow_ShouldReturnCorrectForms(string word, string expectedNominative, string expectedGenitive, string expectedDative, string expectedAccusative, string expectedInstrumental, string expectedLocative, string expectedVocative)
        {
            // Arrange
            var handler = new FirstDeclensionHandler(new List<IRule>());

            // Act
            var result = handler.GetSingularRow(word);

            // Assert
            Assert.Equal(expectedNominative, result.Nominative);
            Assert.Equal(expectedGenitive, result.Genitive);
            Assert.Equal(expectedDative, result.Dative);
            Assert.Equal(expectedAccusative, result.Accusative);
            Assert.Equal(expectedInstrumental, result.Instrumental);
            Assert.Equal(expectedLocative, result.Locative);
            Assert.Equal(expectedVocative, result.Vocative);
        }

        [Theory]
        [InlineData("amats", "amati", "amatu", "amatiem", "amatus", "ar amatiem", "amatos", "amati!")]
        [InlineData("zābaks", "zābaki", "zābaku", "zābakiem", "zābakus", "ar zābakiem", "zābakos", "zābaki!")]
        public void GetPluralRow_ShouldReturnCorrectForms(string word, string expectedNominative, string expectedGenitive, string expectedDative, string expectedAccusative, string expectedInstrumental, string expectedLocative, string expectedVocative)
        {
            // Arrange
            var handler = new FirstDeclensionHandler(new List<IRule>());

            // Act
            var result = handler.GetPluralRow(word);

            // Assert
            Assert.Equal(expectedNominative, result.Nominative);
            Assert.Equal(expectedGenitive, result.Genitive);
            Assert.Equal(expectedDative, result.Dative);
            Assert.Equal(expectedAccusative, result.Accusative);
            Assert.Equal(expectedInstrumental, result.Instrumental);
            Assert.Equal(expectedLocative, result.Locative);
            Assert.Equal(expectedVocative, result.Vocative);
        }
    }
}
