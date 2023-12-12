using AutoMapper;
using Newslify.Keywords;
using Newslify.Languages;
using Newslify.SavedNews;
using Newslify.ReadingLists;
using Newslify.Users;
using Volo.Abp.Identity;
using Newslify.Notifications;
using Newslify.Alerts;

namespace Newslify; 

public class NewslifyApplicationAutoMapperProfile : Profile
{
    public NewslifyApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Language, LanguageDto>();
        CreateMap<SavedNew, SavedNewDto>();
        CreateMap<SavedNewDto, SavedNew>();
        CreateMap<Keyword, KeywordDto>().ReverseMap();
        CreateMap<ReadingList, ReadingListDto>().ReverseMap();
        CreateMap<IdentityUser, UserDto>();
        CreateMap<NewsDto, ArticleDto>().ReverseMap();
        CreateMap<NewsDto, SavedNew>().ReverseMap();
        CreateMap<AlertDto, Alert>().ReverseMap();
        CreateMap<NotificationDto, Notification>().ReverseMap();
    }
}
