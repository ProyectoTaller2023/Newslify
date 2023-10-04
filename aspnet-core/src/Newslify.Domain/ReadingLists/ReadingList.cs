using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace Newslify.ReadingLists
{
	public class ReadingList : Entity<int>
	{
		public string Name { get; set; }
		public int ChildrenReadingListId { get; set; }
		public ICollection<ReadingList>? ChildrenReadingList { get; set; }
		public Guid UserId { get; set; }
		public IdentityUser User { get; set; }
		public int? ParentListId { get; set; }
		public ReadingList? ParentReadingList { get; set; }
	}
}