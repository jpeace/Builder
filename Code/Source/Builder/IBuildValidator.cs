using System;
using Builder.Requirements;

namespace Builder
{
    public interface IBuildValidator<T>
    {
        IBuildValidator<T> When(Func<T, bool> condition);
        IBuildValidator<T> Require(Func<T, object> expression);
        IBuildValidator<T> IsPositive(Func<T, int> expression);
        void AddRequirement(IBuildRequirement requirement);
        void Validate();
        FieldRequirement<T> Field(Func<T, object> expression);
    }
}