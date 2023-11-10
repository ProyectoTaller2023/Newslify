using System;
using System.Collections.Generic;
using System.Text;

namespace Newslify
{
    /// Este dto representa la respuesta de la api de noticias. Por otro lado NewsDto representa una noticia "manipulada" segun lo que necesitemos
    public class ArticleDto
    {
        public string Author { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string UrlToImage { get; set; }

        public DateTime? PublishedAt { get; set; }

        public string Content { get; set; }
    }
}