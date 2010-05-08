using System;
using Builder.Comparers;
using Builder.Exceptions;

namespace Builder.Requirements
{
    public class FieldRequirement<T> : IBuildRequirement
    {
        readonly FieldSpecifier<T, object> _fieldSpecifier;

        private EqualityComparer _equality;

        public FieldRequirement(T subject, Func<T, object> expression)
        {
            _fieldSpecifier = new FieldSpecifier<T, object>
                                  {
                                      Subject = subject, 
                                      Expression = expression
                                  };
        }

        public FieldRequirement<T> IsEqualTo(object compare)
        {
            _equality = new EqualityComparer(_fieldSpecifier.Subject, compare);
            return this;
        }

        public FieldRequirement<T> IsEqualTo(Func<T,object> expression)
        {
            var compare = _fieldSpecifier.Field;
            _equality = new EqualityComparer(_fieldSpecifier.Subject, compare);
            return this;
        }

        public void Validate()
        {
            if (_equality != null)
            {
                if (!_equality.Compare())
                {
                    throw new BuilderException(_fieldSpecifier.Subject, "The two objects compared were not equal.");
                }
            }
            else
            {
                throw new BuilderException(_fieldSpecifier.Subject, "No equality relationship specified.");
            }
        }
    }
}