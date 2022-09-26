using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessClassLibrary
{    
    public class BusinessLayer
    {
        private IService _service;

        public BusinessLayer(IService service)
        {
            _service = service;
        }
     
        public List<Content> OrderFilterbyStatus(IEnumerable<Content> value, string status)
        {
            if (value != null)
            {
                List<Content> filterContent = (from C in value
                                     where (C.Status == status)
                                     select C).ToList();
                return filterContent;
            }
            return null;
        }

        public IEnumerable<Order> GetBestSellingOrders(IEnumerable<Content> content)
        {
            List<Order> orders = new List<Order>();
            foreach (var value in content.ToList())
            {
                foreach (var line in value.Lines)
                {
                    Order order = new Order();
                    order.Gtin = line.Gtin;
                    order.ProductName = line.Description;
                    order.TotalQuantity = line.Quantity;
                    order.MerchantProductNo = line.MerchantProductNo;
                    if (orders.Count == 0)
                    {
                        orders.Add(order);
                    }
                    else
                    {
                        if (orders.Any(t => t.MerchantProductNo.Equals(order.MerchantProductNo)))
                        {
                            (from t in orders
                             where t.MerchantProductNo.Equals(order.MerchantProductNo)
                             select t)
                            .ToList().ForEach(u => u.TotalQuantity += order.TotalQuantity);
                        }
                        else
                        {
                            orders.Add(order);
                        }
                    }
                }
            }
            return orders;
        }

        public IEnumerable<Order> BestSellingOrdersView(OrderView value)
        {
            IEnumerable<Order> orders;            
            var filterContent = OrderFilterbyStatus(value.Content, "IN_PROGRESS");
            orders = GetBestSellingOrders(filterContent);

            if(orders != null )
            {
                return orders.OrderByDescending(t => t.TotalQuantity);
            }
            else
            {
                return orders;
            }
        }

        public void PrintLine()
        {
            _service.PrintALine();
        }

        public async Task<OrderView> GetAllOrder()
        {
            var value = await _service.GetAllOrder();
            if(value != null)
            {
                return value;
            }
            else
            {
                return null;
            }        
        }

        public async Task<Product> GetProduct(string productId)
        {
            try
            {
                if (!String.IsNullOrEmpty((productId)))
                {
                    var product = await _service.GetProduct(productId);
                    if (product != null)
                        return product;
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            return null;
        }
    }
}
