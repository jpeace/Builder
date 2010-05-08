using System;
using Builder.Exceptions;

namespace Builder.Requirements
{
    class PositiveNumberField<T> : IBuildRequirement
    {
        private readonly FieldSpecifier<T, int> _fieldSpecifier;

        public PositiveNumberField(T subject, Func<T, int> expression)
        {
            _fieldSpecifier = new FieldSpecifier<T, int>
                                  {
                                      Subject = subject, 
                                      Expression = expression
                                  };
        }

        public void Validate()
        {
            var num = _fieldSpecifier.Field;
            if (num <= 0)
            {
                throw new BuilderException(_fieldSpecifier.Subject, String.Format("Positive number field is {0}", num));
            }
        }
    }
}