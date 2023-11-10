using System;
using System.Threading.Tasks;
using Newslify;
using System.Collections.Generic;

public interface INewsAPI
{
     Task<ICollection<ArticleDto>> getNews(string LanguageIntCode, int? amountNews, string? query);
}
