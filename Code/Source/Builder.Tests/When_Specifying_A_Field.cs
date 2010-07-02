using Builder.Tests.Requirements;
using Builder.Util;
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
            var specifier = new PropertyExpression<DummyObject, string>(o => o.RequiredString);
            specifier.GetValue(stub).ShouldBeTheSameAs(stub.RequiredString);
        }
    }
}