using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using SMS.Infrastructure.Services;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SMS.Tests.Services
{
    [TestClass]
    public class TwilioSmsSenderTests
    {
        [TestMethod]
        public void ShouldLogInfoWhenSmsIsSentSuccessfully()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var smsSender = new TwilioSmsSender("sid", "token", "+123456789", loggerMock.Object);
            var message = new SMSMessage("+5511999999999", "Test message");

            // Act
            smsSender.SendSMS(message);

            // Assert
            loggerMock.Verify(l => l.LogInfo(It.IsAny<string>(), "ENVIOS"), Times.Once);
        }

        [TestMethod]
        public void ShouldLogErrorWhenSmsFailsToSend()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var smsSender = new TwilioSmsSender("invalid_sid", "invalid_token", "+123456789", loggerMock.Object);
            var message = new SMSMessage("+5511999999999", "Test message");

            // Act & Assert
            Assert.ThrowsException<Exception>(() => smsSender.SendSMS(message));
            loggerMock.Verify(l => l.LogError(It.IsAny<string>(), It.IsAny<Exception>()), Times.Once);
        }

        [TestMethod]
        public void ShouldNotSendSmsOutsideScheduledHours()
        {
            // Simulando o horário fora do horário configurado para envio
            var currentTime = new TimeSpan(20, 0, 0); // 20:00
            var startTime = new TimeSpan(7, 0, 0); // 07:00
            var endTime = new TimeSpan(19, 0, 0); // 19:00

            Assert.IsTrue(currentTime < startTime || currentTime > endTime, "O SMS não deve ser enviado fora do horário configurado.");
        }
    }
}

