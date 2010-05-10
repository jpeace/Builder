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
    }
}