using System;
using System.Text.Json;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System.Threading.Tasks;

public class HandlerNewsAPI : INewsAPI
{
    NewsApiClient newsApiClient;

    public HandlerNewsAPI()
    {
      newsApiClient = new NewsApiClient("10a2a9fc820944829819bd5ab8d705e0"); // deberia estar en una variable de entorno
    }

    public async Task<string> getNews(string LanguageIntCode, int? amountNews)
    {
        var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
        {
            Q = "news", // Filtro poco especifico para que devuelva noticias en general (necesario ya que sin filtro lo rechaza la API)
            SortBy = SortBys.Popularity,
            Language = GetLanguage(LanguageIntCode), // Reveer como hacer para setearle distintos lenguajes
            From = GetDateMonthAgoFromNow(), // deberia obtener un DateTime un mes atras cada vez
            Page = 1,
            PageSize = amountNews ?? 20
        }) ;

        if (articlesResponse.Status == Statuses.Ok)
        {
            return JsonSerializer.Serialize(articlesResponse.Articles);
        }

        throw new Exception("La solicitud de la API no fue exitosa. Status: " + articlesResponse.Status);
    }

    // un metodo que devuelva una fecha  de 1 mes hcia atras desde el dia actual
    private DateTime GetDateMonthAgoFromNow()
    {
        DateTime date = DateTime.Now;
        date = date.AddMonths(-1);
        return date;
    }

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
