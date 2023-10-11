using AutoMapper;
using Newslify.Keywords;
using Newslify.Languages;
using Newslify.LogReadNews;
using Newslify.SavedNews;
using Newslify.ReadingLists;

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
        CreateMap<Keyword, KeywordDto>();
        CreateMap<LogReadNew, LogReadNewDto>();
        CreateMap<ReadingList, ReadingListDto>();
    }
}
