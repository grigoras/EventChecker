using EventChecker.Domain.Models;
using EventChecker.Infrastructure.DbModels;
using EventChecker.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace EventChecker.Application.Services
{
    public class MatcherService
    {
        private readonly ILogger<MatcherService> _logger;

        private readonly IUserRepository _userRepository;
        private readonly IVisitRepository _visitRepository;
        private readonly ICookieRepository _cookieRepository;

        public MatcherService(ILogger<MatcherService> logger, IUserRepository userRepository, IVisitRepository visitRepository,
            ICookieRepository cookieRepository)
        {
            _logger=logger;
            _userRepository=userRepository;
            _visitRepository=visitRepository;
            _cookieRepository=cookieRepository;
        }

        public void Match(IEnumerable<EventModel> events)
        {
            foreach (var browserEvent in events)
            {
                var user = _userRepository.GetAll().FirstOrDefault(x => x.Email == browserEvent.Email);
                var cookie = _cookieRepository.GetAll().FirstOrDefault(x => x.Id == browserEvent.CookieId);
                var visit = _visitRepository.GetAll().FirstOrDefault(x => x.Id == browserEvent.VisitId);

                if (user is not null)
                {
                    if(cookie is null)
                    {
                        _cookieRepository.Add(new Infrastructure.DbModels.Cookie()
                        {
                            Id = browserEvent.CookieId,
                            Profile = user.Profile
                        });
                    }
                    if(visit is null)
                    {
                        _visitRepository.Add(new Infrastructure.DbModels.Visit()
                        {
                            Id = browserEvent.VisitId,
                            Profile = user.Profile
                        });
                    }
                }

                if (cookie is not null)
                {
                    if (user is null)
                    {
                        _userRepository.Add(new Infrastructure.DbModels.User()
                        {
                            Email = browserEvent.Email,
                            Profile = cookie.Profile
                        });
                    }
                    if (visit is null)
                    {
                        _visitRepository.Add(new Infrastructure.DbModels.Visit()
                        {
                            Id = browserEvent.VisitId,
                            Profile = cookie.Profile
                        });
                    }
                }

                if (visit is not null)
                {
                    if (cookie is null)
                    {
                        _cookieRepository.Add(new Infrastructure.DbModels.Cookie()
                        {
                            Id = browserEvent.CookieId,
                            Profile = visit.Profile
                        });
                    }
                    if (user is null)
                    {
                        _userRepository.Add(new Infrastructure.DbModels.User()
                        {
                            Email = browserEvent.Email,
                            Profile = visit.Profile
                        });
                    }
                }

                if(user is null && visit is null && cookie is null)
                {
                    Profile newProfile = new();

                    _userRepository.Add(new Infrastructure.DbModels.User()
                    {
                        Email = browserEvent.Email,
                        Profile = newProfile
                    });
                    _cookieRepository.Add(new Infrastructure.DbModels.Cookie()
                    {
                        Id = browserEvent.CookieId,
                        Profile = newProfile
                    });
                    _visitRepository.Add(new Infrastructure.DbModels.Visit()
                    {
                        Id = browserEvent.VisitId,
                        Profile = newProfile
                    });
                }
            }
        }
    }
}
