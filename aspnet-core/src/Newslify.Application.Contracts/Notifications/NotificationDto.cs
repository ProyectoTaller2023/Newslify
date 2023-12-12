using Newslify.Alerts;
using Newslify.Users;
using System;
using Volo.Abp.Application.Dtos;

namespace Newslify.Notifications
{
    public class NotificationDto : EntityDto<int>
    {
        public bool Active { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public UserDto User { get; set; }
        public AlertDto Alert { get; set; }
        public int AlertId { get; set; }
    }
}
