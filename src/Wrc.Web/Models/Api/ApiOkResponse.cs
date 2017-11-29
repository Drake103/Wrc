namespace Wrc.Web.Models.Api
{
    public class ApiOkResponse : ApiResponse
    {
        public ApiOkResponse(object result)
            : base(200)
        {
            Result = result;
        }

        public object Result { get; }
    }
}