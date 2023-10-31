using Examples.Models.Models;

namespace Examples.Mocks;

public static class MockOrdersService
{
    public static List<Order> GetOrdersFromDatabase()
    {
        return new List<Order>
        {
            new Order
            {
                OrderId = 1,
                Product = "Product 1",
                Quantity = 2
            },
            new Order
            {
                OrderId = 1,
                Product = "Product 66",
                Quantity = 3
            },
            new Order
            {
                OrderId = 1,
                Product = "Product 100",
                Quantity = 10
            }
        };
    }

    public static List<Custommer> GetCustommersFromDatabase()
    {
        return new List<Custommer>
        {
            new Custommer
            {
                CustommerId = 1,
                UserName = "John Doe",
                Email = "jd@dummy.com"
            },
            new Custommer
            {
                CustommerId = 2,
                UserName = "Ivan Petrov",
                Email = "ip@dummy.com"
            },
            new Custommer
            {
                CustommerId = 3,
                UserName = "Hai Shang",
                Email = "hs@dummy.com"
            }
        };
    }
}
