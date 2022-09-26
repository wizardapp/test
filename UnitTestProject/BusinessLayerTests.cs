using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessClassLibrary;
using System.Threading.Tasks;
using SimpleInjector;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class BusinessLayerTests
    {
        private Container container;
        public BusinessLayerTests()
        {
            container = new SimpleInjector.Container();
            container.Options.ResolveUnregisteredConcreteTypes = true;
            var lifestyle = Lifestyle.Singleton;
            container.Register<IService, DataAccess>(lifestyle);            
        }

        [TestMethod]
        public void OrderFilterbyStatus_InProgress_Status_ReturnsTrue()
        {
            var BL = container.GetInstance<BusinessLayer>();

            // Arrange
            List <Content> contentList = new List<Content>() {
             new Content()
             {
                 Id = 0,
                 Status = "IN_PROGRESS",
                 MerchantOrderNo = ""
             },
             new Content()
             {
                 Id = 0,
                 Status = "NEW",
                 MerchantOrderNo = ""
             }};

            // Act
            var result =  BL.OrderFilterbyStatus(contentList, "IN_PROGRESS");            
            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void OrderFilterbyStatus_InProgress_Status_ReturnsFalse()
        {
            var BL = container.GetInstance<BusinessLayer>();

            // Arrange
            List<Content> contentList = new List<Content>() {
             new Content()
             {
                 Id = 0,
                 Status = "NEW",
                 MerchantOrderNo = ""
             },
             new Content()
             {
                 Id = 0,
                 Status = "NEW",
                 MerchantOrderNo = ""
             }};


            // Act
            var result = BL.OrderFilterbyStatus(contentList, "IN_PROGRESS");
            // Assert
            Assert.IsTrue(result.Count < 1);
        }
    }    
}
