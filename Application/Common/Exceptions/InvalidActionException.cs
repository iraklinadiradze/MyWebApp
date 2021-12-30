using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public class InvalidActionException : Exception
    {
        public long? Key { get; }
        public ModuleEnum EntityId { get; }

        public InvalidActionException(string operation, ModuleEnum entityId, long? key)
            : base(operation)
        {
            Key = key;
            EntityId = entityId;
        }
    }

}
