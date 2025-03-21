using TildeDeclensions.Business.DeclensionRules;

namespace TildeDeclensions.Business.Tests.Rules
{
    public class FourthDeclensionRulesTests
    {
        [Theory]
        [InlineData("bumba")]
        [InlineData("grāmata")]
        [InlineData("dziesma")]
        public void Rule001_Evaluate_ShouldReturnTrue_WhenWordEndsWithA(string word)
        {
            // Arrange
            var rule = new FourthDeclensionRule001();
            // Act
            var result = rule.Evaluate(word);
            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("suns")]
        [InlineData("koks")]
        [InlineData("galds")]
        public void Rule001_Evaluate_ShouldReturnFalse_WhenWordDoesNotEndWithA(string word)
        {
            // Arrange
            var rule = new FourthDeclensionRule001();
            // Act
            var result = rule.Evaluate(word);
            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Rule001_Evaluate_ShouldReturnFalse_WhenWordIsNullOrEmpty(string word)
        {
            // Arrange
            var rule = new FourthDeclensionRule001();
            // Act
            var result = rule.Evaluate(word ?? "");
            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("LielA")]
        [InlineData("MazA")]
        [InlineData("VecA")]
        public void Rule001_Evaluate_ShouldReturnTrue_WhenWordEndsWithAInDifferentCasing(string word)
        {
            // Arrange
            var rule = new FourthDeclensionRule001();
            // Act
            var result = rule.Evaluate(word);
            // Assert
            Assert.True(result);
        }
    }
}
