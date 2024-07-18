using Moq;

namespace TranslationManagement.UnitTests.Mocks;

using Microsoft.Extensions.Logging;

internal class LoggerMock<T> :  Mock<ILogger<T>> 
{
    public LoggerMock()
    {
    }
}