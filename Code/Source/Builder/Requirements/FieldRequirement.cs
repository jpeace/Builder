using System;
using Builder.Comparers;
using Builder.Exceptions;

namespace Builder.Requirements
{
    public class FieldRequirement<TSubject> : BaseBuildRequirement<TSubject, object>
    {
        private EqualityComparer _equality;
        public FieldRequirement(TSubject subject, Func<TSubject, object> expression)
            : base(subject, expression)
        {
        }

        public FieldRequirement<TSubject> IsEqualTo(object compare)
        {
            _equality = new EqualityComparer(FieldSpecifier.Subject, compare);
            return this;
        }

        public FieldRequirement<TSubject> IsEqualTo(Func<TSubject, object> expression)
        {
            var compare = expression(FieldSpecifier.Subject);
            _equality = new EqualityComparer(FieldSpecifier.Subject, compare);
            return this;
        }

        public override void Validate()
        {
            if (_equality != null)
            {
                if (!_equality.Compare())
                {
                    throw new BuilderException(FieldSpecifier.Subject, "The two objects compared were not equal.");
                }
            }
            else
            {
                throw new BuilderException(FieldSpecifier.Subject, "No equality relationship specified.");
            }
        }
    }
}