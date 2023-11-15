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
        }

        public ReadingList(string UserId, string Name, string? ParentListId)
            {
                if (Guid.TryParse(UserId, out Guid UserIdGuid))
                {
                    this.UserId = UserIdGuid;
                }
                else
                {
                    throw new ArgumentException("El valor de UserId no es un Guid válido.");
                }

                this.Name = Name;

                if (int.TryParse(ParentListId, out int ParentListInteger))
                {
                    this.ParentListId = ParentListInteger;
                }
                else
                {
                    this.ParentListId = null; // Opcionalmente puedes asignar null en caso de conversión fallida.
                }
            }

        public string Name { get; set; }

        // Relations
        public Guid UserId { get; set; }
        public IdentityUser User { get; set; }

		public int? ParentListId { get; set; }
		public ReadingList? ParentReadingList { get; set; }

		public ICollection<Keyword> Keywords { get; set; }
		public ICollection<SavedNew> SavedNews { get; set; }

        // la entidad deberia tener un metodo para agregar una palabra clave a la lista de keywords
        // la entidad deberia tener un metodo para agregar una noticia a la lista de noticias

    }

}