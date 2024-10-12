namespace TranslationManagement.UnitTests.Payments;

using System;
using Data;
using Mocks;
using Moq;
using NUnit.Framework;
using TranslationManagement.Data.Management;
using TranslationManagement.Middleware;
using TranslationManagement.Payments;

public class PriceCalculatorTests
{
    private Mock<IStandaloneScope>? mock;
    [SetUp]
    public void Setup()
    {
        mock = new Mock<IStandaloneScope>();
        mock.Setup(x => x.UseFor<IRepository<PriceRecord>, PriceRecord[]>(It.IsAny<Func<IRepository<PriceRecord>, PriceRecord[]>>()))
            .Returns([new PriceRecord(Guid.NewGuid(), PriceType.PerCharacter, 0.01m)]);
    }

    [TestCase("", PriceType.PerCharacter, ExpectedResult=0.0)]
    [TestCase("TEST", PriceType.PerCharacter, ExpectedResult=0.04)]
    public decimal Test1(string content, PriceType type)
    {
        var sut = new PriceCalculator(
            new LoggerMock<PriceCalculator>().Object, 
            mock?.Object);

        return sut.Translation(type, content);
    }
}