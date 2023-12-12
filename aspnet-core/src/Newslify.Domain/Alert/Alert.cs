using Volo.Abp.Domain.Entities;
using Newslify.Notifications;
using System.Collections.Generic;
using Volo.Abp.Identity;
using System;

namespace Newslify.Alerts
{
    public class Alert: Entity<int>
    {
        // Parameterless constructor
        public Alert() { }
        public Alert(string topic, IdentityUser user) {
            this.topic = topic;
            this.User = user;
            this.active = true;
            this.createdAt = DateTime.Now;
        }
        public bool active { get; set; }
        public string topic { get; set; }
        public DateTime createdAt { get; set; }
        public IdentityUser User { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}