using Builder.Exceptions;
using NUnit.Framework;

namespace Builder.Tests.Requirements.Conditional
{
    [TestFixture]
    public class When_Validating_Conditional_Field
    {
        [Test]
        public void Throws_If_Condition_Is_True_And_Requirement_Is_Not_Met()
        {
            Exception<BuilderException>.ShouldBeThrownBy(() => new DummyObjectBuilder()
                                                        .WithIsRequiredStringRequired(true)
                                                        .WithRequiredString(string.Empty).Build());
        }
        [Test]
        public void Does_Not_Throw_If_Condition_Is_True_And_Requirement_Is_Met()
        {
            var dummyObject = new DummyObjectBuilder().WithIsRequiredStringRequired(true).WithRequiredString("Test").Build();
            dummyObject.RequiredString.ShouldEqual("Test");
        }
        [Test]
        public void Does_Not_Throw_If_Condition_Is_False_And_Requirement_Is_Not_Met()
        {
            var dummyObject = new DummyObjectBuilder().WithIsRequiredStringRequired(false).WithRequiredString(string.Empty).Build();
            dummyObject.RequiredString.ShouldEqual(string.Empty);
        }
        [Test]
        public void Does_Not_Throw_If_Condition_Is_False_And_Requirement_Is_Met()
        {
            var dummyObject = new DummyObjectBuilder().WithIsRequiredStringRequired(false).WithRequiredString("Test").Build();
            dummyObject.RequiredString.ShouldEqual("Test");
        }
    }
}