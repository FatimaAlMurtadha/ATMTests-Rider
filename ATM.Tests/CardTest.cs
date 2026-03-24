namespace ATM.ATM.Tests;

using ATM;
using Xunit;

public class CardTest
{
    // initialization
    [Fact]

    public void Constructor_ShouldInitializePropertiesCorrectly()
    {
        // Arrange new account
        Account account = new Account(5000);
    
        // Act // cardNumber - PIN -N The new account 
        Card card = new Card("123456", "9999", account);
    
        // Assert
        Assert.Equal("123456", card.CardNumber); // CardNumber match ?
        Assert.Equal("9999", card.PinCode); // PinCode match?
        Assert.Equal(account, card.Account); // on the same account object?
        
    }

    // Match PIN
    [Fact]
    public void MatchesPin_WhereCorrectPin_ShouldReturnTrue()
    {
        // Arrange
        Account account = new Account(5000);
        Card card = new Card("123456", "9999", account);
        // Act
        bool result = card.MatchesPin("9999"); // The correct PIN // the method shouldd return true
        // Assert
        Assert.True(result);  // make sure that the return value is true
    }
// PIN Not match
    [Fact]
    public void MatchesPin_WhereIncorrectPin_ShouldReturnFalse()
    {
        // Arrange
        Account account = new Account(5000);
        Card card = new Card("123456", "9999", account);
        
        // Act
        bool result = card.MatchesPin("1234"); // wrong PIN

        // Assert
        Assert.False(result);
    }
    
    // A test of many values
    [Theory]
    [InlineData("9999", "9999", true)]
    [InlineData("9999", "0000", false)]
    [InlineData("9999", "", false)]
    [InlineData("9999", null, false)]
    public void MatchesPin_ShouldValidateVariousInputs(string actualPin, string inputPin, bool expected)
    {
        // Arrange
        Account account = new Account(5000);
        Card card = new Card("123456", actualPin, account);
        // Act
        bool result = card.MatchesPin(inputPin);
        
        // Assert
        Assert.Equal(expected, result);
    }
    
}