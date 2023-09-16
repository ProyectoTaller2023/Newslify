using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;


namespace Newslify.Languages
{
    public class Language: Entity<int>
    {
        private LanguageIntCodeType internationalCode;

        public string Name { get; set; }
        public LanguageIntCodeType InternationalCode { get => internationalCode; set => internationalCode = value; }
    }
}
