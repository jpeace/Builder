using System;

namespace Builder.Exceptions
{
    public class BuilderException : Exception
    {
        public object DomainObject { get; set; }
        
        public BuilderException(object domainObject, string message) : base(message)
        {
            DomainObject = domainObject;
        }
    }
}