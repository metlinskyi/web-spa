using External.ThirdParty.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TranslationManagement.Api.Notifications;

namespace TranslationManagement.UnitTests.Notifications;

using Data.Management;
using Mocks;

public class JobNotificationTests
{
    private Mock<INotificationService> notificationServiceMock;
    private LoggerMock<INotification<JobRecrod>> loggerMock;
    [SetUp]
    public void Setup()
    {
        notificationServiceMock = new Mock<INotificationService>();
        loggerMock = new LoggerMock<INotification<JobRecrod>>();
    }

    [TestCase(new[]{3,3,3,1}, ExpectedResult = true)]
    [TestCase(new[]{3,3,0}, ExpectedResult = false)]
    public async Task<bool> SendNotificationCases(int[] sequense)
    {
        int index = 0;
        notificationServiceMock
            .Setup(x=>x.SendNotification(It.IsAny<string>()))
            .Returns(async()=> {
                await Task.Delay(TimeSpan.FromSeconds(1));
                int response = sequense[index++];
                return response switch
                {
                    0 => throw new ApplicationException("Oops, properly unreliable service"),
                    1 => true,
                    _ => false,
                };
            });

        var sut = new JobNotification(notificationServiceMock.Object,loggerMock.Object);

        try
        {
            await sut.Send(new JobRecrod(Guid.NewGuid()){ Status = JobStatus.New});
            notificationServiceMock.Verify(x=>x.SendNotification(It.IsAny<string>()),  Times.Exactly(sequense.Length));
            return true;
        }
        catch(ApplicationException)
        {
            return false;
        }

        Assert.Fail();
    }
}