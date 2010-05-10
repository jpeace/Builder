using System;
using Builder.Exceptions;

namespace Builder.Requirements
{
    public class PositiveNumberField<TSubject> : BaseBuildRequirement<TSubject, int>
    {
        public PositiveNumberField(TSubject subject, Func<TSubject, int> expression)
            : base(subject, expression)
        {
        }

        public override void Validate()
        {
            var num = FieldSpecifier.Field;
            if (num <= 0)
            {
                throw new BuilderException(FieldSpecifier.Subject, String.Format("Positive number field is {0}", num));
            }
        }
    }
}