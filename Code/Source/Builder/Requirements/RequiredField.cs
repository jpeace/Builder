using System;
using Builder.Exceptions;

namespace Builder.Requirements
{
    public class RequiredField<TSubject> : BaseBuildRequirement<TSubject, object>
    {
        public RequiredField(TSubject subject, Func<TSubject, object> expression)
            : base(subject, expression)
        {
        }

        public override void Validate()
        {
            var property = FieldSpecifier.Field;

            if (property == null)
            {
                throw new BuilderException(FieldSpecifier.Subject, "Required field was null.");
            }

            var type = property.GetType();

            if (type == typeof(string))
            {
                var s = property as string;
                if (string.IsNullOrEmpty(s))
                {
                    throw new BuilderException(FieldSpecifier.Subject, String.Format("Required field missing: {0}", property));
                }
            }
        }
    }
}