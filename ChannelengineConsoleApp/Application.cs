using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BusinessClassLibrary;
using SimpleInjector;

namespace ChannelengineConsoleApp
{
    public class Application
    {
        SimpleInjector.Container container = new SimpleInjector.Container();

        public Application()
        {
            container = new SimpleInjector.Container();
            container.Options.ResolveUnregisteredConcreteTypes = true;
            var lifestyle = Lifestyle.Singleton;
            container.Register<IService, DataAccess>(lifestyle);
        }

        public void Test()
        {
            var BL = container.GetInstance<BusinessLayer>();
            List<Content> contentList = new List<Content>() {
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

            Content expect = new Content()
            {
                Id = 0,
                Status = "IN_PROGRESS",
                MerchantOrderNo = ""
            };

            // Act
            var result = BL.OrderFilterbyStatus(contentList, "IN_PROGRESS");

            bool flag = result.Contains(expect);
        }

        public async Task ViewOrders()
        {
            var container = new SimpleInjector.Container();
            container.Options.ResolveUnregisteredConcreteTypes = true;
            var lifestyle = Lifestyle.Singleton;
            container.Register<IService, DataAccess>(lifestyle);
            var BL = container.GetInstance<BusinessLayer>();            

            try
            {
                Console.WriteLine("\t\t   Best Selling Order List  ");
                Console.WriteLine("\t\t===========================");
                OrderView value = await BL.GetAllOrder();
                if (value != null)
                {
                    var orderList = BL.BestSellingOrdersView(value);
                    foreach (var order in orderList)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("\t" + "Gtin : " + order.Gtin + "\t\t");
                        Console.WriteLine("\t" + "Merchant ProductNo : " + order.MerchantProductNo + "\t\t");
                        Console.WriteLine("\t" + "Product Name : " + order.ProductName + "\t\t");
                        Console.WriteLine("\t" + "Total Quantity : " + order.TotalQuantity + "\t\t");
                        Console.WriteLine("====================== ++++ ========================");
                    }
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }       
    }
}
