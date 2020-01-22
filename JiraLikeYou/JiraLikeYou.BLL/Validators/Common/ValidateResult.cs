using System.Collections.Generic;
using System.Linq;

namespace JiraLikeYou.BLL.Validators.Common
{
    public sealed class ValidateResult
    {
        public bool IsValid { get; }
        public IEnumerable<string> Errors { get; }
        public ValidateResult(IEnumerable<string> errors)
        {
            Errors = errors;
            IsValid = Errors.Any();
        }
    }
}