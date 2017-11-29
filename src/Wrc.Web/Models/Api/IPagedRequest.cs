namespace Wrc.Web.Models.Api
{
    public interface IPagedRequest
    {
        int Start { get; set; }

        int Limit { get; set; }
    }
}