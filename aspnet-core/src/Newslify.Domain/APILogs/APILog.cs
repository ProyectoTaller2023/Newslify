using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace Newslify.APILogs
{
    public class APILog : Entity<int>
    {
        public string Search { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ErrorCode { get; set; }

        // relaciones
        public IdentityUser User { get; set; }

        public APILog()
        {
           this.StartTime= DateTime.Now;
        }
    }


}