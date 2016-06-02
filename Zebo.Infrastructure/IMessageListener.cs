using System;

namespace Zebo.Infrastructure
{
    public interface IMessageListener
    {
        string Key { get; }
        void ProcessMessage(string message);
    }
}
