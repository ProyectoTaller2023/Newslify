using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Newslify
{
    public class CreateReadingListDto
    {
        [Required]
        public string Name { get; set; }

        public int? Id { get; set; }

        public int? ParentId { get; set; }
    }
}

