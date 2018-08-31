using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using Ninject;
using WSVistaWebClientTest.Domain.Abstract;
using WSVistaWebClientTest.Domain.Entities;

namespace WSVistaWebClientTest.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;
        private readonly Lazy<Random> _randomizer = new Lazy<Random>();

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;

            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            #region mock

            Ticket CreateTicket()
            {
                return new Ticket
                {
                    AreaNumber = _randomizer.Value.Next(1, 10),
                    ColumnIndex = _randomizer.Value.Next(1, 50),
                    RowIndex = _randomizer.Value.Next(1, 50)
                };
            }

            var mock = new Mock<IOrderRepository>();
            mock.Setup(m => m.Orders).Returns(new List<Order>
            {
                new Order {OrderId = 1L, OrderNumber = Guid.NewGuid().ToString(), OrderDate = DateTime.Today, Tickets = new List<Ticket>
                {
                    CreateTicket()
                }},
                new Order {OrderId = 2L, OrderNumber = Guid.NewGuid().ToString(), OrderDate = DateTime.Today.AddDays(-1), Tickets = new List<Ticket>
                {
                    CreateTicket(), CreateTicket(), CreateTicket(), CreateTicket(), CreateTicket(), CreateTicket(), CreateTicket()
                }},
                new Order {OrderId = 3L, OrderNumber = Guid.NewGuid().ToString(), OrderDate = DateTime.Today.AddDays(1), Tickets = new List<Ticket>
                {
                    CreateTicket(), CreateTicket()
                }},
                new Order {OrderId = 4L, OrderNumber = Guid.NewGuid().ToString(), OrderDate = DateTime.Today.AddDays(1), Tickets = new List<Ticket>
                {
                    CreateTicket(), CreateTicket()
                }},
                new Order {OrderId = 5L, OrderNumber = Guid.NewGuid().ToString(), OrderDate = DateTime.Today.AddDays(1), Tickets = new List<Ticket>
                {
                    CreateTicket(), CreateTicket()
                }}
            });

            _kernel.Bind<IOrderRepository>().ToConstant(mock.Object);

            #endregion mock


        }
    }
}