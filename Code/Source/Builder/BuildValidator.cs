using System;
using System.Collections.Generic;
using Builder.Requirements;

namespace Builder
{
    public class BuildValidator<T>
    {
        private readonly T _subject;
        private readonly List<IBuildRequirement> _buildRequirements;

        public BuildValidator(T subject)
        {
            _subject = subject;
            _buildRequirements = new List<IBuildRequirement>();
        }

        public void Require(Func<T, object> expression)
        {
            AddRequirement(new RequiredField<T>(_subject, expression));
        }

        public void IsPositive(Func<T, int> expression)
        {
            AddRequirement(new PositiveNumberField<T>(_subject, expression));    
        }

        public FieldRequirement<T> Field(Func<T, object> expression)
        {
            var requirement = new FieldRequirement<T>(_subject, expression);
            AddRequirement(requirement);
            return requirement;
        }

        public void AddRequirement(IBuildRequirement requirement)
        {
            if (requirement != null)
            {
                _buildRequirements.Add(requirement);
            }
        }

        public void Validate()
        {
            foreach (var requirement in _buildRequirements)
            {
                requirement.Validate();
            }
        }
    }
}