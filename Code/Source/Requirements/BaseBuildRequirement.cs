using System;

namespace Builder.Requirements
{
    public abstract class BaseBuildRequirement<TSubject, TField> : IBuildRequirement
    {
        protected readonly FieldSpecifier<TSubject, TField> FieldSpecifier;

        protected BaseBuildRequirement(TSubject subject, Func<TSubject, TField> expression)
        {
            FieldSpecifier = new FieldSpecifier<TSubject, TField>
                                    {
                                        Subject = subject,
                                        Expression = expression
                                    };
        }
        public abstract void Validate();
    }
}