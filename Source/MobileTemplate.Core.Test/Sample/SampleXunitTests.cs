using Xunit;

namespace MobileTemplate.Core.Test.Sample
{
    public class SampleXunitTests
    {
        [Fact]
        public void PassedTest()
        {
            Assert.True(true);
        }

        [Fact(Skip = "Skip this Test")]
        public void SkippedTest()
        {
            Assert.False(true, "We were supposed to skip this!");
        }
    }
}
