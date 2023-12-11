using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.Domain.Entities;
using Newslify.Alerts;

namespace Newslify.Notifications
{
    public class Notification: Entity<int>
    {
        public bool Active { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public IdentityUser User { get; set; }
        public Alert Alert { get; set; }
        public int AlertId { get; set; }
    }
}
