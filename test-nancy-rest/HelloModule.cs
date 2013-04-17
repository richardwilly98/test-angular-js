using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using Nancy.ModelBinding;

namespace Test.Nancy.Rest
{
    public class HelloModule : NancyModule
    {
        private static Dictionary<int, Order> _orders = new Dictionary<int, Order>();

        static HelloModule()
        {
            _orders.Add(1, new Order { Id = 1, Name = "Order-1", Date = DateTime.Now });
            _orders.Add(2, new Order { Id = 2, Name = "Order-2", Date = DateTime.Now.AddYears(-10) });
        }

        public HelloModule()
            : base("/orders")
        {
            Get["/{id}"] = parameter => { return GetOrder(parameter.id); };
            Get["/find/{name}"] = parameter => { return FindOrdersByName(parameter.name); };
            Post["/"] = parameter =>
            {
                try
                {
                    var order = this.Bind<Order>();
                    Console.WriteLine(order);
                    CreateOrder(ref order);
                    return Response.AsJson(order, HttpStatusCode.Created);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    throw;
                }
            };
        }

        private Order GetOrder(int id)
        {
            if (_orders.ContainsKey(id))
            {
                return _orders[id];
            }
            else
                return null;
        }

        private int CreateOrder(ref Order order)
        {
            int id = GetNextId();
            order.Id = id;
            _orders[id] = order;
            return id;
        }

        private List<Order> FindOrdersByName(string name)
        {
            List<Order> orders = new List<Order>();
            foreach (var order in _orders.Values)
            {
                if (order.Name.Contains(name))
                {
                    orders.Add(order);
                }
            }
            return orders;
        }

        private int GetNextId(int id = 0)
        {
            id = Math.Max(id, _orders.Count);
            if (_orders.ContainsKey(id))
            {
                return GetNextId(id+1);
            }
            else
            {
                return id;
            }
        }
    }

}
