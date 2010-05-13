using Builder.Tests.Requirements;
using NUnit.Framework;

namespace Builder.Tests
{
    [TestFixture]
    public class When_Specifying_A_Field
    {
        [Test]
        public void The_Proper_Field_Is_Returned()
        {
            var stub = new DummyObject
                           {
                               RequiredString = "Hello, World!"
                           };
            var specifier = new FieldSpecifier<DummyObject, string>(stub, o => o.RequiredString);
            specifier.Field.ShouldBeTheSameAs(stub.RequiredString);
        }
        [Test]
        public void Blah()
        {
            var x = new DummyObjectBuilder()
                    .WithIsRequiredStringRequired(true)
                    .WithRequiredString("blah").Build();
        }
    }

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