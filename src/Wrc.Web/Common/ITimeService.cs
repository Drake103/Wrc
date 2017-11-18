using System;

namespace Wrc.Web.Common
{
    public interface ITimeService
    {
        DateTime UtcNow { get; }
    }
}