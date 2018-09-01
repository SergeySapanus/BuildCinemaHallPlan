using System;
using WSVistaWebClientTest.Domain.Abstract;
using WSVistaWebClientTest.Domain.Entities;

namespace WSVistaWebClientTest.Domain.Concrete
{
    public class PlanProcessor : IPlanProcessor
    {
        private readonly string _api;

        public PlanProcessor(string api)
        {
            _api = api;
        }

        public Plan GetPlan()
        {
            if (string.IsNullOrWhiteSpace(_api))
                throw new ArgumentException(nameof(_api));

            return new Plan();
        }
    }
}