using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Builder.Requirements;

namespace Builder
{
    public class BuildValidator<T> : IBuildValidator<T>, IBuildRequirement
    {
        private readonly T _subject;
        private readonly List<IBuildRequirement> _buildRequirements;
        public Func<T, bool> ExecutionCondition { get; set; }

        public BuildValidator(T subject)
        {
            _subject = subject;
            _buildRequirements = new List<IBuildRequirement>();
        }

        public IBuildValidator<T> When(Func<T, bool> condition)
        {
            var conditionalBuilder = new BuildValidator<T>(_subject)
                                         {
                                             ExecutionCondition = condition
                                         };
            AddRequirement(conditionalBuilder);
            return conditionalBuilder;
        }

        public IBuildValidator<T> Require(Expression<Func<T, object>> expression)
        {
            AddRequirement(new RequiredField<T>(_subject, expression));
            return this;
        }

        public IBuildValidator<T> IsPositive(Expression<Func<T, int>> expression)
        {
            AddRequirement(new PositiveNumberField<T>(_subject, expression));
            return this;
        }

        public FieldRequirement<T> Field(Expression<Func<T, object>> expression)
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
            if (ExecutionCondition != null && !ExecutionCondition(_subject))
            {
                return;
            }

            foreach (var requirement in _buildRequirements)
            {
                requirement.Validate();
            }
        }
    }
}