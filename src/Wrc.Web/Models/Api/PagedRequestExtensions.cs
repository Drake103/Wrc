using Wrc.Web.Dtos;

namespace Wrc.Web.Models.Api
{
    public static class PagedRequestExtensions
    {
        public static PagingInfo ToPagingInfo(this IPagedRequest pagedRequest)
        {
            return new PagingInfo(pagedRequest.Start, pagedRequest.Limit);
        }
    }
}