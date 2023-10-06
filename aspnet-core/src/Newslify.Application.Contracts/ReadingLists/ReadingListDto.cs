using System;
using Volo.Abp.Application.Dtos;

namespace Newslify.ReadingLists
{
    public class ReadingListDto : EntityDto<int>
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public int? ParentListId { get; set; }
        public int ChildrenReadingListId { get; set; }
    }
}