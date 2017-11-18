namespace Wrc.Web.Dtos
{
    public class PagingInfo
    {
        public const PagingInfo All = null;

        public PagingInfo(int start, int limit)
        {
            Limit = limit;
            Start = start;
        }

        public int Start { get; }
        public int Limit { get; }
    }
}