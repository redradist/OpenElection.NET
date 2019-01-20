namespace OpenElection.Shared.Organizations
{
    public class Goverment : Union
    {
        public Goverment()
        {
            Type = OrganizationType.Goverment;
        }

        public override string Name { get; set; }
        public override OrganizationType Type { get; protected set; }
    }
}
