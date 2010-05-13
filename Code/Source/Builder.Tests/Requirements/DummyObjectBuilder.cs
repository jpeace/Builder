namespace Builder.Tests.Requirements
{
    public class DummyObjectBuilder : Builder<DummyConditionalObject>
    {
        public DummyObjectBuilder()
        {
            SetBuildRequirements(x => x
                                    .When(y => y.IsRequiredStringRequired)
                                    .Require(y => y.RequiredString));
        }
        public DummyObjectBuilder WithRequiredString(string propertyValue)
        {
            SetSubjectProperty(x => x.RequiredString, propertyValue);
            return this;
        }
        public DummyObjectBuilder WithIsRequiredStringRequired(bool isRequiredStringRequired)
        {
            SetSubjectProperty(x => x.IsRequiredStringRequired, isRequiredStringRequired);
            return this;
        }
    }
}