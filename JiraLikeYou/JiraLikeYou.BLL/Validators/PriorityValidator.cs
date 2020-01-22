using System.Collections.Generic;
using JiraLikeYou.BLL.Models.Priority;
using JiraLikeYou.BLL.Validators.Common;

namespace JiraLikeYou.BLL.Validators
{
    public interface IPriorityValidator
    {
        ValidateResult ValidateCreate(PriorityCreateModel createModel);
        ValidateResult ValidateUpdate(PriorityUpdateModel updateModel);
    }
    public sealed class PriorityValidator : IPriorityValidator
    {
        public ValidateResult ValidateCreate(PriorityCreateModel createModel)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(createModel.Name))
            {
                errors.Add("Not valid priority name");
            }

            return new ValidateResult(errors);
        }

        public ValidateResult ValidateUpdate(PriorityUpdateModel updateModel)
        {
            var errors = new List<string>();

            if (updateModel.Id == 0)
            {
                errors.Add("Not valid priority id");
            }

            if (string.IsNullOrWhiteSpace(updateModel.Name))
            {
                errors.Add("Not valid priority name");
            }
            
            return new ValidateResult(errors);
        }
    }
}