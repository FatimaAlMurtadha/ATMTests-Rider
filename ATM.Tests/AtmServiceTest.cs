namespace ATM.ATM.Tests;
using ATM;
using Xunit;

public class AtmServiceTest
{
    [Fact]
    public void InsertCard_ShouldSetCardAndResetAuthentication()
    {
        // Arrange
        AtmService atm = new AtmService(10000);
        Account account = new Account(5000);
        Card card = new Card("1234", "9999", account);
        
        // act
        atm.InsertCard(card);
        
        // Assert
        Assert.True(atm.HasCardInserted);
        Assert.False(atm.IsAuthenticated);
    }

    [Fact]
    public void EjectCard_ShouldRemoveCardAndResetAuthentication()
    {
        AtmService atm = new AtmService(10000);
        Account account = new Account(5000);
        Card card = new Card("1234", "9999", account);
        atm.InsertCard(card);

        atm.EjectCard();

        Assert.False(atm.HasCardInserted);
        Assert.False(atm.IsAuthenticated);
    }

    [Fact]
    public void EnterPin_WithoutCard_ShouldReturnFalse()
    {
        AtmService atm = new AtmService(10000);
        
        bool result = atm.EnterPin("9999");
        
        Assert.False(result);
    }
}