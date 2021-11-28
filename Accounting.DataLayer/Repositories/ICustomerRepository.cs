using System.Collections.Generic;
using Accounting.ViewModels.Customers;

namespace Accounting.DataLayer.Repositories
{
    public interface ICustomerRepository
    {
        List<Customers> GetAllCustomers();

        IEnumerable<Customers> GetCustomersByFilter(string parameter);

        List<ListCustomerViewModel> GetNameCustomers(string filter= "");

        Customers GetCustomerById(int customerId);

        bool InsertCustomer(Customers customer);

        bool UpdateCustomer(Customers customer);

        bool DeleteCustomer(Customers customer);

        bool DeleteCustomer(int customerId);

        int GEtCustomerIdbyName(string name);

        string GetNameCustomerById(int Id);

    }
}
