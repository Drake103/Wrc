namespace Wrc.Web.Domain.Replays
{
    public class AccountInfo
    {
        public AccountInfo(int eugenUserId, string name)
        {
            EugenUserId = eugenUserId;
            Name = name;
        }

        public int EugenUserId { get; }
        public string Name { get; }
    }
}