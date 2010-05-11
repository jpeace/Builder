using Builder.Exceptions;
using Builder.Requirements;
using NUnit.Framework;

namespace Builder.Tests.Requirements.Required
{
    [TestFixture]
    public class When_Validating_Required_Fields
    {
        [Test]
        public void Empty_Strings_Are_Considered_Invalid()
        {
            var obj = new DummyObject();
            var requiredField = new RequiredField<DummyObject>(obj, o => o.RequiredString);

            Exception<BuilderException>
                .ShouldBeThrownBy(requiredField.Validate);
        }
        [Test]
        public void Non_Empty_Strings_Are_Considered_Valid()
        {
            var obj = new DummyObject
                          {
                              RequiredString = "Requirement Met"
                          };
            var requiredField = new RequiredField<DummyObject>(obj, o => o.RequiredString);

            requiredField.Validate(); // no exception expected
        }
        [Test]
        public void Null_Values_Are_Considered_Invalid()
        {
            var obj = new DummyObject();
            var requiredField = new RequiredField<DummyObject>(obj, o => o.ChildProperty);

            Exception<BuilderException>
                .ShouldBeThrownBy(requiredField.Validate);
        }
        [Test]
        public void Non_Null_Values_Are_Considered_Valid()
        {
            var obj = new DummyObject
                            {
                               ChildProperty = new DummyObject()
                            };
            var requiredField = new RequiredField<DummyObject>(obj, o => o.ChildProperty);

            requiredField.Validate(); // no exception expected
        }
    }
}