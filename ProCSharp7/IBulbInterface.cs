using System;
namespace MS_01
{
    public interface IBulbInterface
    {
        void TurnOn();
        void TurnOff();
        bool IsOn { get; }
    }
}
