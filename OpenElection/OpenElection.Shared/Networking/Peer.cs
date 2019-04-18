using System.Collections.Generic;
using System.Threading.Tasks;
using MaY;
using OpenElection.Shared.Networking.Messages;

namespace OpenElection.Shared
{
    public class Peer : PeerBase
    {
        private readonly Queue<IBlock> blockChain = new Queue<IBlock>();
        private readonly Dictionary<PacketType, object> nextBlockToCreate = new Dictionary<PacketType, object>();

        /// <summary>
        /// Add vote to queue for applying
        /// </summary>
        /// <param name="vote">Vote to create</param>
        public void ApplyVote(Vote vote)
        {
            nextBlockToCreate.Add(PacketType.VOTE, vote);
        }

        /// <summary>
        /// Add post to queue for applying
        /// </summary>
        /// <param name="post">Post to create</param>
        public void ApplyPost(Post post)
        {
            nextBlockToCreate.Add(PacketType.POST, post);
        }

        protected override async Task OnClientDataReceived(IPeerProxy client, byte[] data, int bytesRead)
        {
            PeerPacketHeader packetHeader =  data.DeserializePeerPacketHeader();
            switch ((PacketType) packetHeader.Type)
            {
                case PacketType.SYSTEM:
                {
                    HandleSystemPacket(client, data);
                }
                    break;
                case PacketType.POST:
                {
                   HandlePostPacket(client, data);
                }
                    break;
                case PacketType.VOTE:
                {
                    PeerPacket<Vote> votePacket = data.DeserializePeerPacket<Vote>();
                    nextBlockToCreate.Add(PacketType.VOTE, votePacket.Payload);
                    /*
                    Vote vote = votePacket.Payload;
                    switch (vote.Ogranization)
                    {
                        case OrganizationType.Union:
                            break;
                        case OrganizationType.Company:
                            HandleCompanyVote(vote);
                            break;
                        case OrganizationType.Village:
                            HandleVillageVote(vote);
                            break;
                        case OrganizationType.City:
                            HandleCityVote(vote);
                            break;
                        case OrganizationType.Government:
                            HandleCountryVote(vote);
                            break;
                        case OrganizationType.Country:
                            HandleCountryVote(vote);
                            break;
                        case OrganizationType.Anonymous:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                      }
                      blockInProcess = Block<SHA512Hasher>.CreateBlock(vote);
                      */
                    }
                    break;
            }
        }

        private void HandlePostPacket(IPeerProxy client, byte[] data)
        {
            PeerPacket<Post> postPacket = data.DeserializePeerPacket<Post>();
            nextBlockToCreate.Add(PacketType.POST, postPacket.Payload);
        }

        private void HandleSystemPacket(IPeerProxy client, byte[] data)
        {
            PeerPacket<Networking.Messages.System> systemPacket = data.DeserializePeerPacket<Networking.Messages.System>();
            Networking.Messages.System systemInfo = systemPacket.Payload;
            SystemType systemEvent = systemInfo.SystemEvent;
            switch (systemEvent)
            {
                case SystemType.CREATE_NEW_BLOCK:
                    break;
                case SystemType.FIND_BLOCK:
                    break;
                case SystemType.READ_BLOCK:
                    break;
            }
        }

        private bool isBlockAccepted()
        {
            return true;
        }

        private void HandleCompanyVote(Vote vote)
        {
            CompanyVoteType companyVoteType = (CompanyVoteType) vote.Type;
        }

        private static void HandleCityVote(Vote vote)
        {
            CityVoteType cityVoteType = (CityVoteType) vote.Type;
        }

        private static void HandleVillageVote(Vote vote)
        {
            VillageVoteType villageVoteType = (VillageVoteType) vote.Type;
        }

        private static void HandleCountryVote(Vote vote)
        {
            CountryVoteType countryVoteType = (CountryVoteType) vote.Type;
        }
    }
}