using System;
using System.Collections.Generic;
using System.Text;

namespace Newslify
{
    // Representa una noticia "manipulada" segun lo que necesitemos (inicialmente es igual a ArticleDto que devuelve la API)
    public class NewsDto
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