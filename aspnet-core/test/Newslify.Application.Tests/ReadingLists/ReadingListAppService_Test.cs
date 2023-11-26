using Newslify.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Uow;
using Xunit;

namespace Newslify.ReadingLists
{
    public class ReadingListAppService_Test : NewslifyApplicationTestBase
    {
        private readonly IReadingListsAppService _ReadingListAppService;
        private readonly IDbContextProvider<NewslifyDbContext> _dbContextProvider;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ReadingListAppService_Test()
        {
            _ReadingListAppService = GetRequiredService<IReadingListsAppService>();
            _dbContextProvider = GetRequiredService<IDbContextProvider<NewslifyDbContext>>();
            _unitOfWorkManager = GetRequiredService<IUnitOfWorkManager>();
        }

        [Fact]
        public async Task Should_Get_All_ReadingLists()
        {

            //Act
            var ReadingLists = await _ReadingListAppService.GetReadingListsAsync();

            //Assert
            ReadingLists.ShouldNotBeNull();
            ReadingLists.Count.ShouldBeGreaterThan(1);
        }

        [Fact]
        public async Task Should_Create_ReadingList()
        {
            //Arrange            
            var input = new CreateReadingListDto { Name = "nueva reading list" };

            //Act
            var newReadingList = await _ReadingListAppService.PostReadingListAsync(input);

            //Assert
            // Se verifican los datos devueltos por el servicio
            newReadingList.ShouldNotBeNull();
            newReadingList.Id.ShouldBePositive();
            // se verifican los datos persistidos por el servicio
            using (var uow = _unitOfWorkManager.Begin())
            {
                var dbContext = await _dbContextProvider.GetDbContextAsync();
                dbContext.ReadingLists.FirstOrDefault(t => t.Id == newReadingList.Id).ShouldNotBeNull();
                dbContext.ReadingLists.FirstOrDefault(t => t.Id == newReadingList.Id).Name.ShouldBe(input.Name);
            }
        }

        [Fact]
        public async Task Should_Update_ReadingList()
        {
            //Arrange            
            var input = new UpdateReadingListDto { Name = "nueva reading list", Id = 1 };

            //Act
            var newReadingList = await _ReadingListAppService.PutReadingListAsync(input);

            //Assert
            // Se verifican los datos devueltos por el servicio
            newReadingList.ShouldNotBeNull();
            newReadingList.Id.ShouldBePositive();
            // se verifican los datos persistidos por el servicio
            using (var uow = _unitOfWorkManager.Begin())
            {
                var dbContext = await _dbContextProvider.GetDbContextAsync();
                dbContext.ReadingLists.FirstOrDefault(t => t.Id == newReadingList.Id).ShouldNotBeNull();
                dbContext.ReadingLists.FirstOrDefault(t => t.Id == newReadingList.Id).Name.ShouldBe(input.Name);
            }
        }

    }

}