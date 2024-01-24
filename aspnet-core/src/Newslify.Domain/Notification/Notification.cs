using System;
using Volo.Abp.Identity;
using Volo.Abp.Domain.Entities;
using Newslify.Alerts;

namespace Newslify.Notifications
{
    public class Notification: Entity<int>
    {
        public bool Active { get; set; } = true;
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public IdentityUser User { get; set; }
        public Alert Alert { get; set; }
        public int AlertId { get; set; }
    }
}
