using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace Newslify.LogReadNews
{
    public class LogReadNew : Entity<int>
    {
        public string Url { get; set; }
        public DateTime DateRead { get; set; }
        public Guid userId { get; set; }
    }
}