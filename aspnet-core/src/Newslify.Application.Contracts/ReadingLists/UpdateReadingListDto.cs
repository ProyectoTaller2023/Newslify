using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Newslify
{
    public class UpdateReadingListDto
    {
        [Required]
        public int Id { get; set; }

        public string? Name { get; set; }
        public int? ParentId { get; set; }
        public string? Keyword { get; set; }
        public NewsDto? News { get; set; }
    }
}

