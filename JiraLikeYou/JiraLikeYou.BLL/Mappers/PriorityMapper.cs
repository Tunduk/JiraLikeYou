using JiraLikeYou.BLL.Models.Priority;
using JiraLikeYou.DAL.Entities;

namespace JiraLikeYou.BLL.Mappers
{
    public interface IPriorityMapper
    {
        Priority MapFromCreateModel(PriorityCreateModel createModel);
        Priority MapFromUpdateModel(PriorityUpdateModel updateModel);
        PriorityModel MapFromEntity(Priority priority);
    }

    public sealed class PriorityMapper : IPriorityMapper
    {
        public Priority MapFromUpdateModel(PriorityUpdateModel updateModel)
        {
            return new Priority
            {
                Id = updateModel.Id,
                Name = updateModel.Name
            };
        }

        public PriorityModel MapFromEntity(Priority priority)
        {
            if(priority == null)
                return null;
            
            return new PriorityModel
            {
                Id = priority.Id,
                Name = priority.Name
            };
        }

        public Priority MapFromCreateModel(PriorityCreateModel createModel)
        {
            return new Priority
            {
                Name = createModel.Name
            };
        }
    }
}