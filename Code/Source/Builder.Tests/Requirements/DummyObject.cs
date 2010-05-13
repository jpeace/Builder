namespace Builder.Tests.Requirements
{
    public class DummyObject
    {
        public string RequiredString { get; set; }
        public DummyObject ChildProperty { get; set; }
    }
    public class DummyConditionalObject
    {
        protected DummyConditionalObject()
        {
            
        }
        public string RequiredString { get; set; }
        public bool IsRequiredStringRequired { get; set; }
        public DummyObject ChildProperty { get; set; }
    }
}