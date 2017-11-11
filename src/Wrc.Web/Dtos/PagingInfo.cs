namespace Wrc.Web.Dtos
{
    public class PagingInfo
    {
        public const PagingInfo All = null;

        public PagingInfo(int startIndex, int pageSize)
        {
            PageSize = pageSize;
            StartIndex = startIndex;
        }

        public int StartIndex { get; }
        public int PageSize { get; }
    }
}