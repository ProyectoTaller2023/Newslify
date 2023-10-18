using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;
using Newslify.Keywords;
using Abp.Authorization.Users;
using Newslify.SavedNews;

namespace Newslify.ReadingLists
{
	public class ReadingList : Entity<int>
	{
		public string Name { get; set; }

		// Relations
        //public Guid UserId { get; set; }
		//public AbpUser<Guid> User { get; set; }

		public int? ParentListId { get; set; }
		public ReadingList? ParentReadingList { get; set; }

		public ICollection<Keyword> Keywords { get; set; }
		public ICollection<SavedNew> SavedNews { get; set; }
	}
}