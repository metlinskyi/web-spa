namespace TranslationManagement.UnitTests.Mocks;

using Data;
using Data.Management;
using Moq;
using System;
using System.Linq;
using TranslationManagement.Payments;

internal class UnitOfWorkMock :  Mock<IUnitOfWork> 
{
    public UnitOfWorkMock()
    {
        this.Setup(x => x.RepositoryFor<PriceRecord>().Get())
            .Returns(new[]{new PriceRecord(Guid.NewGuid(), PriceType.PerCharacter, 0.01m)}.AsQueryable());
    }
}