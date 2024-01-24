using Newslify.Languages;

public class User
{
     public Language Language { get; set; }
     public int LanguageId { get; set; } = UserConsts.LanguagePropertyDefaultValue;
}
