using MediatR;
using System;

namespace core.Types
{
    public abstract class Event : INotification
    {
        public DateTime DateTime { get; private set; }

        protected Event()
        {
            DateTime = DateTime.Now;
        }
    }
}