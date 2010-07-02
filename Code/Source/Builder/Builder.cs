using System;
using System.Linq.Expressions;
using System.Reflection;
using Builder.Util;

namespace Builder
{
    public abstract class Builder<TSubject>
        where TSubject : class
    {
        protected readonly TSubject Subject;
        private readonly BuildValidator<TSubject> _buildValidator;

        protected Builder()
        {
            var subjectType = typeof (TSubject);
            var ctors = subjectType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
            Subject = (TSubject) ctors[0].Invoke(null);

            _buildValidator = new BuildValidator<TSubject>(Subject); //TODO: Consolidate these new operations (DRY violation)
        }

        protected Builder(TSubject subject)
        {
            Subject = subject;
            _buildValidator = new BuildValidator<TSubject>(Subject);
        }

        public void SetBuildRequirements(Action<BuildValidator<TSubject>> requirements)
        {
            requirements(_buildValidator);
        }

        protected void SetSubjectProperty<TField>(Expression<Func<TSubject, object>> expression, TField value)
        {
            var propertyExpression = new PropertyExpression<TSubject>(expression);
            propertyExpression.SetValue(Subject, value);
        }

        public TSubject Build()
        {
            _buildValidator.Validate();
            return Subject;
        }
    }
}