using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessClassLibrary
{
    public interface IService
    {
        Task<OrderView> GetAllOrder();

        Task<Product> GetProduct(string productId);

        void PrintALine();
    }
}
