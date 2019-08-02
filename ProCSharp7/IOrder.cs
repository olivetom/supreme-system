using System;
namespace MS_01
{
    public interface IOrder
    {
        DateTime Purchased { get; }
        decimal Cost { get; }
        void AddOrder(IOrder order);
        
    }

    public class SampleOrder : IOrder
    {
        private DateTime dateTime;
        private readonly decimal Total;

        public SampleOrder(DateTime dateTime, decimal v)
        {
            this.dateTime = dateTime;
            this.Total = v;
        }

        
        
       

        DateTime IOrder.Purchased => throw new NotImplementedException();

        decimal IOrder.Cost => throw new NotImplementedException();

        public void AddOrder(IOrder order)
        {
            throw new NotImplementedException();
        }
    }
}
