using System;
using System.Threading.Tasks;

public interface INewsAPI
{
     Task<string> getNews(string LanguageIntCode, int? amountNews);
}
