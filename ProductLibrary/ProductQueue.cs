using System;
using System.Messaging;

namespace ProductLibrary
{
    public class ProductQueue
    {
        private const string QueuePath = @".\private$\ProductQueue";

        public ProductQueue()
        {
            if (!MessageQueue.Exists(QueuePath))
            {
                MessageQueue.Create(QueuePath);
            }
        }

        public void SendMessage(ProductDetails productDetails)
        {
            using (MessageQueue messageQueue = new MessageQueue(QueuePath))
            {
                messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(ProductDetails) });
                messageQueue.Send(productDetails);
            }
        }

        public ProductDetails ReceiveMessage()
        {
            using (MessageQueue messageQueue = new MessageQueue(QueuePath))
            {
                messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(ProductDetails) });
                Message message = messageQueue.Receive();
                return (ProductDetails)message.Body;
            }
        }
        public bool IsProductInQueue(string name)
        {
            using (MessageQueue messageQueue = new MessageQueue(QueuePath))
            {
                messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(ProductDetails) });
                foreach (Message message in messageQueue.GetAllMessages())
                {
                    ProductDetails registrationDetails = (ProductDetails)message.Body;
                    if (registrationDetails.Name == name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
