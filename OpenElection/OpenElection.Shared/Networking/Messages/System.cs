using System;
using System.Collections.Generic;
using System.Text;

namespace OpenElection.Shared.Networking.Messages
{
    enum SystemType
    {
        CREATE_NEW_BLOCK,
        FIND_BLOCK,
        READ_BLOCK,
    }

    class System
    {
        public SystemType SystemEvent { get; }

        public System(SystemType systemEvent)
        {
            SystemEvent = systemEvent;
        }
    }
}
