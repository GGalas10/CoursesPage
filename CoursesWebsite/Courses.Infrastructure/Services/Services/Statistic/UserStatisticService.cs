using Courses.Core.Repositories;
using Courses.Infrastructure.DTO.Statistic;
using Courses.Infrastructure.Services.Interfaces.Statistic;

namespace Courses.Infrastructure.Services.Services.Statistic
{
    public class UserStatisticService : IUserStatisticService
    {
        private readonly IUserStatisticRepository _statisticRepository;
        public UserStatisticService(IUserStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }
        public async Task<List<CoursesViewInAdminPanel>> GetNewestCourses(Guid UserId, int HowMuch)
        {
            var userCourses = await _statisticRepository.GetUserNewestCourses(UserId);
            if (userCourses.Count() <= 0)
            {
                var lista = new List<CoursesViewInAdminPanel>
                {
                    new CoursesViewInAdminPanel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Kurs testowy",
                    },
                    new CoursesViewInAdminPanel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Kurs Algorytmiki",
                    },
                    new CoursesViewInAdminPanel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Kurs Tańca",
                    }
                };
                return lista;
            }
            userCourses = userCourses.OrderByDescending(x=>x.CreatedAt).Take(HowMuch).ToList();
            return CoursesViewInAdminPanel.GetFromUserList(userCourses);
        }

        public async Task<UserSattlementDTO> GetUserSattlement(Guid UserId)
        {
            var repoResult = await _statisticRepository.GetUserSattlement(UserId);
            var userSattlementDTO = new UserSattlementDTO();
            foreach(var oneCourese in repoResult)
            {
                userSattlementDTO.HowMuchSell++;
                userSattlementDTO.HowMuchEarned += oneCourese.Course.Price;
            }
            return userSattlementDTO;
        }
    }
}
