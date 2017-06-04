using AutoMoq;
using Common;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanRepository.Tests.Common
{

    [TestFixture]
    public class CredentialManagerTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CredentialManagerTests_GetAppSetting_Key_No_Error()
        {
            //  Assign 
            var mocker = new AutoMoqer();
            mocker.GetMock<ICredentialsManager>()
                  .Setup(p => p.GetAppSetting("Domain"))
                  .Returns("US");

            // Act
            var config = mocker.Create<ICredentialsManager>();
            var domain = config.GetAppSetting("Domain");

            // Assert
            Assert.AreEqual(domain, "US");

        }

        [Test]
        public void CredentialManagerTests_Return_Domain_Property_No_Error()
        {
            //  Assign 
            var mocker = new Mock<CredentialsManager>();
            mocker.Setup(m => m.Domain).Returns("US");
            // Act
            var domain = mocker.Object.Domain;

            // Assert
            Assert.AreEqual(domain, "US");

        }

    }
}
