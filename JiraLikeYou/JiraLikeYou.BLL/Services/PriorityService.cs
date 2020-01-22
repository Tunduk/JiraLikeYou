using JiraLikeYou.BLL.Mappers;
using JiraLikeYou.BLL.Validators;
using JiraLikeYou.DAL;
using JiraLikeYou.DAL.Repositories;

namespace JiraLikeYou.BLL.Services
{
    public interface IPriorityService
    {

    }
    public class PriorityService : IPriorityService
    {
        private readonly IPriorityRepository _priorityRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPriorityValidator _priorityValidator;
        private readonly IPriorityMapper _priorityMapper;
        public PriorityService(IPriorityRepository priorityRepository, IUnitOfWork unitOfWork, IPriorityValidator priorityValidator, IPriorityMapper priorityMapper)
        {
            _priorityRepository = priorityRepository;
            _unitOfWork = unitOfWork;
            _priorityValidator = priorityValidator;
            _priorityMapper = priorityMapper;
        }
    }
}