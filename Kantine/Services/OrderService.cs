using System;
using Kantine.Model;

namespace Kantine.Services
{
    public class OrderService
    {
        static OrderService _instance;

        public static OrderService instance
        {
            get
            {
                _instance ??= new OrderService();

                return _instance;
            }
        }

        public readonly Order Order1 = new Order
        {
            Antal = 2,
            Item = "Pizza",
            Pris = 20
        };

        public readonly Order Order2 = new Order
        {
            Antal = 2,
            Item = "Pølsehorn",
            Pris = 30
        };

        public readonly Order Order3 = new Order
        {
            Antal = 1,
            Item = "Cola",
            Pris = 15
        };

        public readonly Order Order4 = new Order
        {
            Antal = 1,
            Item = "Kaffe",
            Pris = 10
        };

        public readonly Order Order5 = new Order
        {
            Antal = 3,
            Item = "Pringles",
            Pris = 20
        };

        public List<Order> GetOrders()
        {
            return new List<Order>
            {
                Order1, Order2, Order3, Order4, Order5
            };
        }
    }
}

