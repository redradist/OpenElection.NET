using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OpenElection.Shared.Networking.Messages
{
    [Serializable]
    public class Vote
    {
        public OrganizationType Ogranization { get; }
        public int Type { get; }
        public int Result { get; }
    }
}
