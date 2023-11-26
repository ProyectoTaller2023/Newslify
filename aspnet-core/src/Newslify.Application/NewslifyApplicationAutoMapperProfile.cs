using AutoMapper;
using Newslify.Keywords;
using Newslify.Languages;
using Newslify.LogReadNews;
using Newslify.SavedNews;
using Newslify.ReadingLists;
using Newslify.Users;
using Volo.Abp.Identity;

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
        CreateMap<LogReadNew, LogReadNewDto>();
        CreateMap<ReadingList, ReadingListDto>().ReverseMap();
        CreateMap<IdentityUser, UserDto>();
        CreateMap<NewsDto, ArticleDto>().ReverseMap();
        CreateMap<NewsDto, SavedNew>().ReverseMap();
    }
}
