using NUnit.Framework;

namespace Breakout.Tests
{
    [TestFixture]
    public class Tests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Code here will be run once before all tests.
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Code here will be run once after all tests.
        }

        [SetUp]
        public void SetUp()
        {
            // Code here will be run once before every test.
        }

        [TearDown]
        public void TearDown()
        {
            // Code here will be run once after every test.
        }

        [Test]
        public void FunctionBeingTested1_Condition_ExpectedResult()
        {
            // Write some test code.
            // e.g. Assert.AreEqual(expectedValue, actualValue);
            Assert.Pass();
        }

        [Test]
        [Repeat(100)]
        public void FunctionBeingTested2_Condition_ExpectedResult()
        {
            // Tests can also be repeated N times.
            // Here, this test will be repeated 100 times.

            // Write some test code.
            // e.g. Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(1, 1);
        }
    }
}
