// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

namespace NUnit.Framework.Internal.Filters
{
    [TestFixture("TestFilterTests+DummyFixture", false)]
    [TestFixture("Dummy", true)]
    public class TestNameFilterTests : TestFilterTests
    {
        private readonly TestFilter _filter;

        public TestNameFilterTests(string value, bool isRegex)
        {
            _filter = new TestNameFilter(value, isRegex);
        }

        [Test]
        public void IsNotEmpty()
        {
            Assert.That(_filter.IsEmpty, Is.False);
        }

        [Test]
        public void MatchTest()
        {
            Assert.That(_filter.Match(_dummyFixture));
            Assert.That(_filter.Match(_anotherFixture), Is.False);
        }

        [Test]
        public void PassTest()
        {
            Assert.That(_filter.Pass(_topLevelSuite));
            Assert.That(_filter.Pass(_dummyFixture));
            Assert.That(_filter.Pass(_dummyFixture.Tests[0]));

            Assert.That(_filter.Pass(_anotherFixture), Is.False);
        }

        public void ExplicitMatchTest()
        {
            Assert.That(_filter.IsExplicitMatch(_topLevelSuite));
            Assert.That(_filter.IsExplicitMatch(_dummyFixture));
            Assert.That(_filter.IsExplicitMatch(_dummyFixture.Tests[0]), Is.False);

            Assert.That(_filter.IsExplicitMatch(_anotherFixture), Is.False);
        }
    }
}
