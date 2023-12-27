using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenIddict.Abstractions.OpenIddictConstants;
using Statuses = NewsAPI.Constants.Statuses;

namespace Newslify
{
public class HandlerNewsAPI : INewsAPI
{
    public async Task<ICollection<ArticleDto>> getNews(string LanguageIntCode, int? amountNews, string? query, DateTime? dateFrom)
    {

       NewsApiClient newsApiClient = new NewsApiClient("10a2a9fc820944829819bd5ab8d705e0"); // deberia estar en una variable de entorno
       
       ICollection<ArticleDto> responseList = new List<ArticleDto>();

        var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
        {
            Q = query ?? "news", // Si no te pasan nada, aplica "news", un filtro poco especifico para que devuelva noticias en general 
            SortBy = SortBys.Popularity,
            Language = GetLanguage(LanguageIntCode),
            From = GetDateToSearchFrom(dateFrom),
            Page = 1,
            PageSize = amountNews ?? 20
        }) ;

     
        if (articlesResponse.Status == Statuses.Ok)
        {
                articlesResponse.Articles.ForEach(t => responseList.Add(new ArticleDto
                {
                    Author = t.Author,
                    Title = t.Title,
                    Description = t.Description,
                    Url = t.Url,
                    PublishedAt = t.PublishedAt,
                    UrlToImage = t.UrlToImage,
                    Content = t.Content
                }));

                return responseList;
        }

        throw new Exception("La solicitud de la API no fue exitosa. Status: " + articlesResponse.Status);
    }

        private DateTime GetDateToSearchFrom(DateTime? date)
        {
            DateTime dateMonthAgo = DateTime.Now.AddMonths(-1);

            if (date == null || date < dateMonthAgo)
            {
                return dateMonthAgo;
            }

            DateTime yesterday = DateTime.Now.AddDays(-1);

            return (date <= yesterday) ? date.Value : yesterday;
        }

        // Analiza los case segun los valores del data seeder de la db. LanguageIntCode seria el languageId del usuario.
        private NewsAPI.Constants.Languages GetLanguage(string LanguageIntCode)
    {
        switch (LanguageIntCode)
        {
            case "1":
                return NewsAPI.Constants.Languages.EN;
            case "2":
                return NewsAPI.Constants.Languages.ES;
            case "3":
                return NewsAPI.Constants.Languages.PT;
            case "4":
                return NewsAPI.Constants.Languages.IT;
            case "5":
                return NewsAPI.Constants.Languages.FR;
            case "6":
                return NewsAPI.Constants.Languages.DE;
            case "7":
                return NewsAPI.Constants.Languages.RU;
            case "8":
                return NewsAPI.Constants.Languages.JP;
            default:
                return NewsAPI.Constants.Languages.EN;
        }
    }
}
}
