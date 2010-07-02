using System;
using System.Linq.Expressions;
using Builder.Util;

namespace Builder.Requirements
{
    public abstract class BaseBuildRequirement<TSubject, TValue> : IBuildRequirement
    {
        protected readonly TSubject Subject;
        protected readonly PropertyExpression<TSubject, TValue> PropertyExpression;

        protected BaseBuildRequirement(TSubject subject, Expression<Func<TSubject, TValue>> expression)
        {
            Subject = subject;
            PropertyExpression = new PropertyExpression<TSubject, TValue>(expression);
        }
        public abstract void Validate();
    }
}