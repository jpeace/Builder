using System;

namespace Builder
{
    internal class FieldSpecifier<TSubject,TPropertyType>
    {
        public TSubject Subject { get; set; }
        public Func<TSubject, TPropertyType> Expression { get; set; }

        public TPropertyType Field
        {
            get
            {
                return Expression(Subject);
            }
        }
    }
}