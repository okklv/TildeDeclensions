using TildeDeclensions.Business.DeclensionRules;

namespace TildeDeclensions.Business.Tests.Rules
{
    public class AdjectiveComparativeRulesTests
    {
        #region Rule 001
        [Theory]
        [InlineData("lielāks")]
        [InlineData("mazāks")]
        [InlineData("vecāks")]
        public void Rule001_Evaluate_ShouldReturnTrue_WhenWordEndsWithAks(string word)
        {
            // Arrange
            var rule = new AdjectiveComparativeDeclensionRule001();
            // Act
            var result = rule.Evaluate(word);
            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("suns")]
        [InlineData("galds")]
        [InlineData("grāmata")]
        public void Rule001_Evaluate_ShouldReturnFalse_WhenWordDoesNotEndWithAks(string word)
        {
            // Arrange
            var rule = new AdjectiveComparativeDeclensionRule001();
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
            var rule = new AdjectiveComparativeDeclensionRule001();
            // Act
            var result = rule.Evaluate(word ?? "");
            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("LielĀKS")]
        [InlineData("MAZĀKS")]
        [InlineData("VecāKs")]
        public void Rule001_Evaluate_ShouldReturnTrue_WhenWordEndsWithAksInDifferentCasing(string word)
        {
            // Arrange
            var rule = new AdjectiveComparativeDeclensionRule001();
            // Act
            var result = rule.Evaluate(word);
            // Assert
            Assert.True(result);
        }
        #endregion
    }
}
