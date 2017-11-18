using System;

namespace Wrc.Web.Common
{
    public class TimeService : ITimeService
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}