using System;

namespace OpenElection.Shared.Networking
{
    [Serializable]
    public class MsgPacket
    {
        public OrganizationType Organization;
        public int MsgType;
        public object Msg;
    }
}