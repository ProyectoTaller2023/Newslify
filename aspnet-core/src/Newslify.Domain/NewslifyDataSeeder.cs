using System;
using System.Threading.Tasks;
using Newslify.Languages;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Newslify
{
    public class NewslifyDataSeederContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Language, int> _languageRepository;

        public NewslifyDataSeederContributor(IRepository<Language, int> languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _languageRepository.GetCountAsync() > 0)
            {
                return;
            }

            await _languageRepository.InsertAsync(
                new Language
                {
                    Name = "English",
                    InternationalCode = LanguageIntCodeType.EN
                },
                autoSave: true
            );

            await _languageRepository.InsertAsync(
                    new Language
                    {
                        Name = "Spanish",
                        InternationalCode = LanguageIntCodeType.ES
                    },
                    autoSave: true
                );

            await _languageRepository.InsertAsync(
                new Language
                {
                    Name = "Portuguese",
                    InternationalCode = LanguageIntCodeType.PT
                },
                autoSave: true
            );

            await _languageRepository.InsertAsync(
                new Language
                {
                    Name = "Italian",
                    InternationalCode = LanguageIntCodeType.IT
                },
                autoSave: true
            );

            await _languageRepository.InsertAsync(
                new Language
                {
                    Name = "French",
                    InternationalCode = LanguageIntCodeType.FR
                },
                autoSave: true
            );

            await _languageRepository.InsertAsync(
                new Language
                {
                    Name = "Deutch",
                    InternationalCode = LanguageIntCodeType.DE
                },
                autoSave: true
            );

            await _languageRepository.InsertAsync(
                new Language
                {
                    Name = "Russian",
                    InternationalCode = LanguageIntCodeType.RU
                },
                autoSave: true
            );

            await _languageRepository.InsertAsync(
                new Language
                {
                    Name = "Japanese",
                    InternationalCode = LanguageIntCodeType.JA
                },
                autoSave: true
            );
        }
    }
}


