using System;
using System.Linq.Expressions;
using Builder.Requirements;

namespace Builder
{
    public interface IBuildValidator<T>
    {
        IBuildValidator<T> When(Func<T, bool> condition);
        IBuildValidator<T> Require(Expression<Func<T, object>> expression);
        IBuildValidator<T> IsPositive(Expression<Func<T, int>> expression);
        void AddRequirement(IBuildRequirement requirement);
        void Validate();
        FieldRequirement<T> Field(Expression<Func<T, object>> expression);
    }
}