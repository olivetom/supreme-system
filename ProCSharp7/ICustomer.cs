using System;
using System.Collections.Generic;
using System.Linq;

namespace MS_01
{
    public interface ICustomer
    {
        IEnumerable<IOrder> PreviousOrders { get; }

        DateTime DateJoined { get; }
        DateTime? LastOrder { get; }
        string Name { get; }
        IDictionary<DateTime, string> Reminders { get; }
        void AddOrder(IOrder order);

        // Version 1:
        //public decimal ComputeLoyaltyDiscount()
        //{
        //    DateTime TwoYearsAgo = DateTime.Now.AddYears(-2);
        //    if ((DateJoined < TwoYearsAgo) && (PreviousOrders.Count() > 10))
        //    {
        //        return 0.10m;
        //    }
        //    return 0;
        //}
    }

    public class SampleCustomer : ICustomer
    {
        public IEnumerable<IOrder> PreviousOrders => throw new NotImplementedException();

        public DateTime DateJoined => throw new NotImplementedException();

        public DateTime? LastOrder => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public IDictionary<DateTime, string> Reminders => throw new NotImplementedException();

        public SampleCustomer(string v, DateTime dateTime) { }

        // Version 1:
        public decimal ComputeLoyaltyDiscount()
        {
            DateTime TwoYearsAgo = DateTime.Now.AddYears(-2);
            if ((DateJoined < TwoYearsAgo) && (PreviousOrders.Count() > 10))
            {
                return 0.10m;
            }
            return 0;
        }

        public void AddOrder(IOrder order)
        { }
    }
}
