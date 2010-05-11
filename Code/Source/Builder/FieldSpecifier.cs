using System;

namespace Builder
{
    public class FieldSpecifier<TSubject,TPropertyType>
    {
        public FieldSpecifier(TSubject subject, Func<TSubject, TPropertyType> expression)
        {
            Subject = subject;
            Expression = expression;
        }

        public TSubject Subject { get; private set; }
        public Func<TSubject, TPropertyType> Expression { get; private set; }

        public TPropertyType Field
        {
            get
            {
                return Expression(Subject);
            }
        }
    }
}