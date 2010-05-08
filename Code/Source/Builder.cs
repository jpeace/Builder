using System;

namespace Builder
{
    public abstract class Builder<T>
    {
        protected readonly T Subject;
        private readonly BuildValidator<T> _buildValidator;

        protected Builder(T subject)
        {
            Subject = subject;
            _buildValidator = new BuildValidator<T>(subject);
        }

        public void SetBuildRequirements(Action<BuildValidator<T>> requirements)
        {
            requirements(_buildValidator);
        }

        public T Build()
        {
            _buildValidator.Validate();
            return Subject;
        }
    }
}