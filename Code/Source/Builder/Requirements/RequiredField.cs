using System;
using System.Linq.Expressions;
using Builder.Exceptions;

namespace Builder.Requirements
{
    public class RequiredField<TSubject> : BaseBuildRequirement<TSubject, object>
    {
        public RequiredField(TSubject subject, Expression<Func<TSubject, object>> expression)
            : base(subject, expression)
        {
        }

        public override void Validate()
        {
            var property = PropertyExpression.GetValue(Subject);

            if (property == null)
            {
                throw new BuilderException(Subject, "Required field was null.");
            }

            var type = property.GetType();

            if (type == typeof(string))
            {
                var s = property as string;
                if (string.IsNullOrEmpty(s))
                {
                    throw new BuilderException(Subject, String.Format("Required field missing: {0}", property));
                }
            }
        }
    }
}