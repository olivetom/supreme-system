using System;
namespace MS_01
{
    

    public class SmppManager : ISmppManager
    {
        //private string sourceAddress;
        //private SmppClient smppClient;

        public SmppManager()
        {
            //smppClient = new SmppClient();
            //smppClient.Start();
        }

        public void SendMessage(string recipient, string message, string senderName)
        {
            //send message using third party library
        }
    }

    //public void SendSMS()
    //{
    //    SmppManager smppManager = new SmppManager();

    //    smppManager.SendMessage("+14257025134", "mensaje desde azul", "Mauricio");

    //}


    public interface ISmppManager
    {
        void SendMessage(string recipient, string message, string senderName);
    }

    class SmppManagerDemo
    {
        public ISmppManager SmppManager { get; private set; }

        public static void SmppManagerDemoMain()
        {
            //The dependency injection will be done using Ninject
            SmppManager smppManager = new SmppManager();
        }
        
    }
}
