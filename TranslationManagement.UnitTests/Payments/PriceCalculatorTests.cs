namespace TranslationManagement.UnitTests.Payments;

using Data;
using Mocks;
using Moq;
using NUnit.Framework;
using TranslationManagement.Payments;

public class PriceCalculatorTests
{
    private Mock<IUnitOfWork> mock;
    [SetUp]
    public void Setup()
    {
        mock = new UnitOfWorkMock();
    }

    [TestCase("", PriceType.PerCharacter, ExpectedResult=0.0)]
    [TestCase("TEST", PriceType.PerCharacter, ExpectedResult=0.04)]
    public decimal Test1(string content, PriceType type)
    {
        var sut = new PriceCalculator(mock.Object);
        return sut.Translation(type, content);
    }
}