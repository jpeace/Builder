using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Builder.Util
{
    public class PropertyExpression<TSubject> : PropertyExpression<TSubject, object>
    {
        public PropertyExpression(Expression<Func<TSubject, object>> propertyExpression) : base(propertyExpression)
        {
        }
    }

    public class PropertyExpression<TSubject, TValue>
    {
        private readonly Expression<Func<TSubject, TValue>> _propertyExpression;
        private readonly PropertyInfo[] _propertyChain;
        private readonly object[] _customAttributes;

        public PropertyExpression(Expression<Func<TSubject, TValue>> propertyExpression)
        {
            _propertyExpression = propertyExpression;

            var chain = new List<PropertyInfo>();
            var memberExpression = MemberExpression;

            while (memberExpression != null)
            {
                chain.Add((PropertyInfo)memberExpression.Member);
                memberExpression = memberExpression.Expression as MemberExpression;
            }
            _customAttributes = chain.First().GetCustomAttributes(false);
            chain.Reverse();
            _propertyChain = chain.ToArray();
        }

        public TValue GetValue(TSubject target)
        {
            return (TValue) BuildValue(target);
        }

        public void SetValue(TSubject target, TValue value)
        {
            if (_propertyChain.Length > 0)
            {
                _propertyChain.Last().SetValue(target, value, BindingFlags.Instance, null, null, null);
            }
        }

        public string Name
        {
            get
            {
                return string.Join(".", _propertyChain.Select(p => p.Name).ToArray());
            }
        }

        public bool HasAttribute<TAttribute>() where TAttribute : Attribute
        {
            return _customAttributes.Any(a => a.GetType() == typeof (TAttribute));
        }

        private object BuildValue(object target)
        {
            foreach (var propertyInfo in _propertyChain)
            {
                target = propertyInfo.GetValue(target, null);
                if (target == null)
                {
                    return null;
                }
            }
            return target;
        }

        private MemberExpression MemberExpression
        {
            get
            {
                if (_propertyExpression == null)
                {
                    throw new ArgumentException("Property expression is null.");
                }

                var memberExpression = _propertyExpression.Body as MemberExpression;
                if (memberExpression == null)
                {
                    var convertExpression = _propertyExpression.Body as UnaryExpression;
                    if (convertExpression != null)
                    {
                        memberExpression = convertExpression.Operand as MemberExpression;
                    }

                    if (memberExpression == null)
                    {
                        throw new ArgumentException("Property expression does not represent member access.");
                    }
                }

                return memberExpression;
            }
        }
    }
}