using System;

namespace OpenElection.Shared.Networking
{
    [AttributeUsage( AttributeTargets.Class )]
    public class PacketTypeAttribute : Attribute
    {
        public PacketType PacketType { get; }

        public PacketTypeAttribute(PacketType packetType)
        {
            PacketType = packetType;
        }
    }
}