using StinkySteak.Rootdash.Data.Customer;

namespace StinkySteak.Rootdash.Manager
{
    public interface ICustomerManager
    {
        CustomerData Get(int id);
        CustomerData Get(string hash);
    }
}