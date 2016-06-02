using Zebo.Presentation.Services.Common;

namespace Zebo.Presentation.Common
{
    public static class MessageProcessor
    {
        public static void ProcessMessage(string message)
        {
            new Message(message).PublishEvent(EventTopicNames.MessageReceivedEvent);
        }
    }
}
