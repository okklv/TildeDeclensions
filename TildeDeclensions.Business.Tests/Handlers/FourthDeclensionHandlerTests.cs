using Moq;
using TildeDeclensions.Business.DeclensionRules;
using TildeDeclensions.Business.DeclensionServices;
using TildeDeclensions.Business.DTOs;

namespace TildeDeclensions.Business.Tests.Handlers
{
    public class FourthDeclensionHandlerTests
    {
        [Fact]
        public void Handle_ShouldProcessWord_WhenRulesPass()
        {
            // Arrange
            var mockRule = new Mock<IRule>();
            mockRule.Setup(r => r.Evaluate(It.IsAny<string>())).Returns(true);

            var handler = new FourthDeclensionHandler(new List<IRule> { mockRule.Object });

            // Act
            var result = handler.Handle("Māja") as FemaleInflectionData;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Māja", result.FemaleSingularRow.Nominative);
        }

        [Fact]
        public void Handle_ShouldThrowUndeterminedDeclensionException_WhenNoHandlerCanProcess()
        {
            // Arrange
            var mockRule = new Mock<IRule>();
            mockRule.Setup(r => r.Evaluate(It.IsAny<string>())).Returns(false);

            var handler = new FourthDeclensionHandler(new List<IRule> { mockRule.Object });

            // Act & Assert
            Assert.Throws<UndeterminedDeclensionException>(() => handler.Handle("UnknownWord"));
        }

        [Theory]
        [InlineData("Māja", "Mājas", "Mājai", "Māju", "ar Māju", "Mājā", "Māja!")]
        [InlineData("Aka", "Akas", "Akai", "Aku", "ar Aku", "Akā", "Aka!")]
        public void GetSingularRow_ShouldReturnCorrectForms(
            string word, string expectedGenitive, string expectedDative,
            string expectedAccusative, string expectedInstrumental,
            string expectedLocative, string expectedVocative)
        {
            // Arrange
            var handler = new FourthDeclensionHandler(new List<IRule>());

            // Act
            var singularRow = handler.GetSingularRow(word);

            // Assert
            Assert.Equal(word, singularRow.Nominative);
            Assert.Equal(expectedGenitive, singularRow.Genitive);
            Assert.Equal(expectedDative, singularRow.Dative);
            Assert.Equal(expectedAccusative, singularRow.Accusative);
            Assert.Equal(expectedInstrumental, singularRow.Instrumental);
            Assert.Equal(expectedLocative, singularRow.Locative);
            Assert.Equal(expectedVocative, singularRow.Vocative);
        }

        [Theory]
        [InlineData("Māja", "Mājas", "Māju", "Mājām", "Mājas", "ar Mājām", "Mājās", "Mājas!")]
        [InlineData("Aka", "Akas", "Aku", "Akām", "Akas", "ar Akām", "Akās", "Akas!")]
        public void GetPluralRow_ShouldReturnCorrectForms(
            string word, string expectedNominative, string expectedGenitive,
            string expectedDative, string expectedAccusative, string expectedInstrumental,
            string expectedLocative, string expectedVocative)
        {
            // Arrange
            var handler = new FourthDeclensionHandler(new List<IRule>());

            // Act
            var pluralRow = handler.GetPluralRow(word);

            // Assert
            Assert.Equal(expectedNominative, pluralRow.Nominative);
            Assert.Equal(expectedGenitive, pluralRow.Genitive);
            Assert.Equal(expectedDative, pluralRow.Dative);
            Assert.Equal(expectedAccusative, pluralRow.Accusative);
            Assert.Equal(expectedInstrumental, pluralRow.Instrumental);
            Assert.Equal(expectedLocative, pluralRow.Locative);
            Assert.Equal(expectedVocative, pluralRow.Vocative);
        }

        [Fact]
        public void Handle_ShouldUseNextHandler_WhenRulesFail()
        {
            // Arrange
            var mockRule = new Mock<IRule>();
            mockRule.Setup(r => r.Evaluate(It.IsAny<string>())).Returns(false);
            var handler = new FourthDeclensionHandler(new List<IRule> { mockRule.Object });

            var nextHandlerMock = new Mock<IDeclensionHandler>();
            handler.SetNext(nextHandlerMock.Object);

            // Act
            var result = handler.Handle("Aka");

            // Assert
            nextHandlerMock.Verify(x => x.Handle("Aka"), Times.Once);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Handle_ShouldThrowArgumentNullException_WhenWordIsNullOrEmpty(string word)
        {
            // Arrange
            var handler = new FourthDeclensionHandler(new List<IRule>());

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => handler.Handle(word));
        }
    }
}
