using JiraLikeYou.BLL.Models.Status;
using JiraLikeYou.DAL.Entities;

namespace JiraLikeYou.BLL.Mappers
{
    public interface IStatusMapper
    {
        Status MapFromCreateModel(StatusCreateModel createModel);
        Status MapFromUpdateModel(StatusUpdateModel updateModel);
        StatusModel MapFromEntity(Status status);
    }

    public sealed class StatusMapper : IStatusMapper
    {
        public Status MapFromUpdateModel(StatusUpdateModel updateModel)
        {
            return new Status
            {
                Id = updateModel.Id,
                Name = updateModel.Name
            };
        }

        public StatusModel MapFromEntity(Status status)
        {
            return new StatusModel
            {
                Id = status.Id,
                Name = status.Name
            };
        }

        public Status MapFromCreateModel(StatusCreateModel createModel)
        {
            return new Status
            {
                Name = createModel.Name
            };
        }
    }
}