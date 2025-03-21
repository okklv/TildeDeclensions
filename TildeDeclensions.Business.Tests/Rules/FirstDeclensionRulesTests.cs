using TildeDeclensions.Business.DeclensionRules;

namespace TildeDeclensions.Business.Tests.Rules
{
    public class FirstDeclensionRulesTests
    {

        #region Rule 001
        [Theory]
        [InlineData("amats")]
        [InlineData("galds")]
        [InlineData("koks")]
        public void Rule001_Evaluate_ShouldReturnTrue_WhenWordEndsWithS(string word)
        {
            // Arrange
            var rule = new FirstDeclensionRule001();
            // Act
            var result = rule.Evaluate(word);
            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("bumba")]
        [InlineData("rīsi")]
        [InlineData("grāmata")]
        public void Rule001_Evaluate_ShouldReturnFalse_WhenWordDoesNotEndWithS(string word)
        {
            // Arrange
            var rule = new FirstDeclensionRule001();
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
            var rule = new FirstDeclensionRule001();
            // Act
            var result = rule.Evaluate(word ?? "");
            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("LielS")]
        [InlineData("MazS")]
        [InlineData("VecS")]
        public void Rule001_Evaluate_ShouldReturnTrue_WhenWordEndsWithSInDifferentCasing(string word)
        {
            // Arrange
            var rule = new FirstDeclensionRule001();
            // Act
            var result = rule.Evaluate(word);
            // Assert
            Assert.True(result);
        }

        #endregion

        #region Rule 002
        [Theory]
        [InlineData("lielāks")]
        [InlineData("mazāks")]
        [InlineData("vecāks")]
        public void Rule002_Evaluate_ShouldReturnFalse_WhenWordEndsWithAks(string word)
        {
            // Arrange
            var rule = new FirstDeclensionRule002();
            // Act
            var result = rule.Evaluate(word);
            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("amats")]
        [InlineData("galds")]
        [InlineData("koks")]
        public void Rule002_Evaluate_ShouldReturnTrue_WhenWordEndsWithS(string word)
        {
            // Arrange
            var rule = new FirstDeclensionRule001();
            // Act
            var result = rule.Evaluate(word);
            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Rule002_Evaluate_ShouldReturnFalse_WhenWordIsNullOrEmpty(string word)
        {
            // Arrange
            var rule = new FirstDeclensionRule001();
            // Act
            var result = rule.Evaluate(word ?? "");
            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("LielS")]
        [InlineData("MazS")]
        [InlineData("VecS")]
        public void Rule002_Evaluate_ShouldReturnTrue_WhenWordEndsWithSInDifferentCasing(string word)
        {
            // Arrange
            var rule = new FirstDeclensionRule002();
            // Act
            var result = rule.Evaluate(word);
            // Assert
            Assert.True(result);
        }
        #endregion
    }
}