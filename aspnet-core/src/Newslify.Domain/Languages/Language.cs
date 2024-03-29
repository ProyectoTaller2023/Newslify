﻿using System.Collections.Generic;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace Newslify.Languages
{
    public class Language: Entity<int>
    {
        private LanguageIntCodeType internationalCode;

        public string Name { get; set; }
        public LanguageIntCodeType InternationalCode { get => internationalCode; set => internationalCode = value; }
        public ICollection<IdentityUser> Users { get; set; }
    }
}
