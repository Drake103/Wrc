namespace Wrc.Web.Models.Api
{
    public class GetReplayListRequest : IPagedRequest
    {
        private const int DefaultPageSize = 20;

        public int Start { get; set; } = 0;

        public int Limit { get; set; } = DefaultPageSize;

        public string SearchText { get; set; }
    }
}