using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Newslify.Keywords
{
    public class Keyword : Entity<int>
    {
        public string KeyWord { get; set; }
    }
}