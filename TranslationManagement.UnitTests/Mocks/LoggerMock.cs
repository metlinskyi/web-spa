namespace TranslationManagement.UnitTests.Mocks;

using Moq;
using Microsoft.Extensions.Logging;

internal class LoggerMock<T> :  Mock<ILogger<T>> 
{
    public LoggerMock()
    {
    }
}