using System;
using NUnit.Framework;

namespace NUnit_dynamic_null_test
{
    [TestFixture]
    public class DynamicNullTest
    {
        private dynamic _someClass;

        [SetUp]
        public void SetUp()
        {
            _someClass = CreateSomeClass();
        }

        [Test]
        public void Some_thing_Is_null()
        {
            Assert.That(_someClass.SomeThing, Is.Null);  //Microsoft.CSharp.RuntimeBinder.RuntimeBinderException
        }

        [Test]
        public void Some_thing_Is_not_null()
        {
            Assert.That(_someClass.SomeThing, Is.Not.Null);  //Microsoft.CSharp.RuntimeBinder.RuntimeBinderException
        }

        [Test]
        public void Some_thing_Is_equal_to_null()
        {
            Assert.That(_someClass.SomeThing, Is.EqualTo(null)); //Microsoft.CSharp.RuntimeBinder.RuntimeBinderException
        }

        [Test]
        public void Some_thing_Is_not_equal_to_null()
        {
            Assert.That(_someClass.SomeThing, Is.Not.EqualTo(null)); //Microsoft.CSharp.RuntimeBinder.RuntimeBinderException
        }

        [Test]
        public void Some_thing_Assert_null()
        {
            Assert.Null(_someClass.SomeThing); //Ok
        }

        [Test]
        public void Some_thing_casted_to_reference_type_Is_null()
        {
            Assert.That((object)_someClass.SomeThing, Is.Null);  //Ok
            Assert.That((string)_someClass.SomeThing, Is.Null);  //Ok
            Assert.That((Exception)_someClass.SomeThing, Is.Null);  //Ok
        }

        private static dynamic CreateSomeClass()
        {
            return new SomeClass();
        }

        private class SomeClass
        {
            public string SomeThing { get; set; }
        }
    }
}