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
        public ReadingList()
        {
            // Constructor sin parámetros
            this.Keywords = new List<Keyword>();
            this.SavedNews = new List<SavedNew>();
        }

        public ReadingList()
        {
            this.Keywords = new List<Keyword>();
            this.SavedNews = new List<SavedNew>();
            this.ReadingLists = new List<ReadingList>();
        }

        public string Name { get; set; }

        // Relations
        //public Guid UserId { get; set; }
        public IdentityUser User { get; set; }

        public ICollection<Keyword> Keywords { get; set; }
        public ICollection<SavedNew> SavedNews { get; set; }

        public ICollection<ReadingList> ReadingLists{ get; set; }
        

        // la entidad deberia tener un metodo para agregar una palabra clave a la lista de keywords
        // la entidad deberia tener un metodo para agregar una noticia a la lista de noticias
    }

}