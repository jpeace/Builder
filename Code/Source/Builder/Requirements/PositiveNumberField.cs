using System;
using System.Linq.Expressions;
using Builder.Exceptions;

namespace Builder.Requirements
{
    public class PositiveNumberField<TSubject> : BaseBuildRequirement<TSubject, int>
    {
        public PositiveNumberField(TSubject subject, Expression<Func<TSubject, int>> expression)
            : base(subject, expression)
        {
        }

        public override void Validate()
        {
            var num = PropertyExpression.GetValue(Subject);
            if (num <= 0)
            {
                throw new BuilderException(Subject, String.Format("Positive number field is {0}", num));
            }
        }
    }
}