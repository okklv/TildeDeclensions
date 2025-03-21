using Moq;
using TildeDeclensions.Business.DeclensionRules;
using TildeDeclensions.Business.DeclensionServices;
using TildeDeclensions.Business.DTOs;

namespace TildeDeclensions.Business.Tests.Handlers
{
    public class AdjectiveComparativeDeclensionHandlerTests
    {
        [Fact]
        public void Process_ShouldReturnCorrectInflections()
        {
            // Arrange
            string word = "Lielāks";

            var expectedMaleSingular = new InflectionRow("Lielāks", "Lielāka", "Lielākam", "Lielāku", "ar Lielāku", "Lielākā", "Lielāks!");
            var expectedMalePlural = new InflectionRow("Lielāki", "Lielāku", "Lielākiem", "Lielākus", "ar Lielākiem", "Lielākos", "Lielāki!");
            var expectedFemaleSingular = new InflectionRow("Lielāka", "Lielākas", "Lielākai", "Lielāku", "ar Lielāku", "Lielākā", "Lielāka!");
            var expectedFemalePlural = new InflectionRow("Lielākas", "Lielāku", "Lielākām", "Lielākas", "ar Lielākām", "Lielākās", "Lielākas!");

            var mockFirstDeclensionService = new Mock<INounDeclensionService>();
            mockFirstDeclensionService.Setup(s => s.GetSingularRow(word)).Returns(expectedMaleSingular);
            mockFirstDeclensionService.Setup(s => s.GetPluralRow(word)).Returns(expectedMalePlural);

            var mockFourthDeclensionService = new Mock<INounDeclensionService>();
            mockFourthDeclensionService.Setup(s => s.GetSingularRow(word)).Returns(expectedFemaleSingular);
            mockFourthDeclensionService.Setup(s => s.GetPluralRow(word)).Returns(expectedFemalePlural);

            var handler = new AdjectiveComparativeDeclensionHandler(
                new List<IRule>(),
                mockFirstDeclensionService.Object,
                mockFourthDeclensionService.Object
            );

            // Act
            var result = handler.Handle(word) as AdjectiveInflectionData;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMaleSingular, result.MaleSingularRow);
            Assert.Equal(expectedMalePlural, result.MalePluralRow);
            Assert.Equal(expectedFemaleSingular, result.FemaleSingularRow);
            Assert.Equal(expectedFemalePlural, result.FemalePluralRow);
        }

        [Fact]
        public void Handle_ShouldThrowUndeterminedDeclensionException_WhenNoRulesApply()
        {
            // Arrange
            var mockRule = new Mock<IRule>();
            mockRule.Setup(r => r.Evaluate(It.IsAny<string>())).Returns(false);

            var mockFirstDeclensionService = new Mock<INounDeclensionService>();
            var mockFourthDeclensionService = new Mock<INounDeclensionService>();

            var handler = new AdjectiveComparativeDeclensionHandler(
                new List<IRule> { mockRule.Object },
                mockFirstDeclensionService.Object,
                mockFourthDeclensionService.Object
            );

            // Act & Assert
            Assert.Throws<UndeterminedDeclensionException>(() => handler.Handle("UnknownAdjective"));
        }

        [Fact]
        public void Handle_ShouldUseNextHandler_WhenRulesFail()
        {
            // Arrange
            var mockRule = new Mock<IRule>();
            mockRule.Setup(r => r.Evaluate(It.IsAny<string>())).Returns(false);

            var mockFirstDeclensionService = new Mock<INounDeclensionService>();
            var mockFourthDeclensionService = new Mock<INounDeclensionService>();

            var handler = new AdjectiveComparativeDeclensionHandler(
                new List<IRule> { mockRule.Object },
                mockFirstDeclensionService.Object,
                mockFourthDeclensionService.Object
            );

            var nextHandlerMock = new Mock<IDeclensionHandler>();
            handler.SetNext(nextHandlerMock.Object);

            // Act
            handler.Handle("Lielāks");

            // Assert
            nextHandlerMock.Verify(x => x.Handle("Lielāks"), Times.Once);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Handle_ShouldThrowArgumentNullException_WhenWordIsNullOrEmpty(string word)
        {
            // Arrange
            var mockFirstDeclensionService = new Mock<INounDeclensionService>();
            var mockFourthDeclensionService = new Mock<INounDeclensionService>();

            var handler = new AdjectiveComparativeDeclensionHandler(
                new List<IRule>(),
                mockFirstDeclensionService.Object,
                mockFourthDeclensionService.Object
            );

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => handler.Handle(word));
        }
    }
}
