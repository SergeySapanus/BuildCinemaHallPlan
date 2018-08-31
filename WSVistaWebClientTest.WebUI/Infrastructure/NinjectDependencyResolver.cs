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

            var mock = new Mock<IOrderRepository>();
            mock.Setup(m => m.Orders).Returns(new List<Order>
            {
                new Order {OrderId = 1L, OrderDate = DateTime.Today, Tickets = new List<Ticket>()},
                new Order {OrderId = 2L, OrderDate = DateTime.Today.AddDays(-1), Tickets = new List<Ticket>
                {
                    new Ticket
                    {
                        AreaNumber = _randomizer.Value.Next(),
                        ColumnIndex = _randomizer.Value.Next(),
                        RowIndex = _randomizer.Value.Next()
                    },
                    new Ticket
                    {
                        AreaNumber = _randomizer.Value.Next(),
                        ColumnIndex = _randomizer.Value.Next(),
                        RowIndex = _randomizer.Value.Next()
                    }
                }},
                new Order {OrderId = 3L, OrderDate = DateTime.Today.AddDays(1), Tickets = new List<Ticket>
                {
                    new Ticket
                    {
                        AreaNumber = _randomizer.Value.Next(),
                        ColumnIndex = _randomizer.Value.Next(),
                        RowIndex = _randomizer.Value.Next()
                    }
                }}
            });

            _kernel.Bind<IOrderRepository>().ToConstant(mock.Object);

            #endregion mock


        }
    }
}