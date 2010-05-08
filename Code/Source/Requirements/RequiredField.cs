using System;
using Builder.Exceptions;

namespace Builder.Requirements
{
    internal class RequiredField<T> : IBuildRequirement
    {
        private readonly FieldSpecifier<T, object> _fieldSpecifier;
        
        public RequiredField(T subject, Func<T, object> expression)
        {
            _fieldSpecifier = new FieldSpecifier<T, object>
                                  {
                                      Subject = subject, 
                                      Expression = expression
                                  };
        }

        public void Validate()
        {
            var property = _fieldSpecifier.Field;

            if (property == null)
            {
                throw new BuilderException(_fieldSpecifier.Subject, "Required field was null.");
            }

            var type = property.GetType();

            if (type == typeof(string))
            {
                var s = property as string;
                if (string.IsNullOrEmpty(s))
                {
                    throw new BuilderException(_fieldSpecifier.Subject, String.Format("Required field missing: {0}", property));
                }
            }
        }
    }
}