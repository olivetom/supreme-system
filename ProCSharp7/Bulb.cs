using System;
namespace MS_01
{
    class Bulb : IBulbInterface
    {

        //Class Variables
        private static int TotalBulbCount; // default = 0;

        //Instance Variables
        private bool isOn; // default = false;

        //Constructor
        public Bulb() => TotalBulbCount++;
        
        ~Bulb()
        {
            TotalBulbCount--;
        }

        //Class Method
        public static int BulbCount => TotalBulbCount;

        //Instance Method
        public virtual void TurnOn()
        {
            isOn = true;
        }

        //Instance Method
        public virtual void TurnOff()
        {
            isOn = false;
        }
        //Instance Method
        public virtual bool IsOn
        {
            get
            {
                return isOn;
            }
        }
    }

    class BulbDemo
    {
        public static void BulbDemoMain()
        {
            _ = new Bulb();
            Bulb b = new Bulb();
            Console.WriteLine("bulb is on return : {0}, BulbCount: {1} ", b.IsOn, Bulb.BulbCount);
            b.TurnOn();
            
            Console.WriteLine("bulb is on return : " + b.IsOn);
        }
    }

}