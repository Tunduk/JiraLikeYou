using System.Collections.Generic;
using JiraLikeYou.BLL.Models.Status;
using JiraLikeYou.BLL.Validators.Common;

namespace JiraLikeYou.BLL.Validators
{
    public interface IStatusValidator
    {
        ValidateResult ValidateCreate(StatusCreateModel createModel);
        ValidateResult ValidateUpdate(StatusUpdateModel updateModel);
    }
    public sealed class StatusValidator : IStatusValidator
    {
        public ValidateResult ValidateCreate(StatusCreateModel createModel)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(createModel.Name))
            {
                errors.Add("Not valid status name");
            }

            if (createModel.Syscode == 0)
            {
                errors.Add("Not valid status syscode");
            }

            return new ValidateResult(errors);
        }

        public ValidateResult ValidateUpdate(StatusUpdateModel updateModel)
        {
            var errors = new List<string>();

            if(updateModel.Id == 0)
            {
                errors.Add("Not valid status id");
            }

            if (string.IsNullOrWhiteSpace(updateModel.Name))
            {
                errors.Add("Not valid status name");
            }

            if (updateModel.Syscode == 0)
            {
                errors.Add("Not valid status syscode");
            }

            return new ValidateResult(errors);
        }
    }
}