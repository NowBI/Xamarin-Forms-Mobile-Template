using Xunit;

namespace MobileTemplate.iOS.Test.Sample
{
    public class SampleXunitiOSTests
    {
        [Fact]
        public void PassediOSTest()
        {
            Assert.True(true);
        }

        [Fact(Skip = "Skip this Test")]
        public void SkippediOSTest()
        {
            Assert.False(true, "We were supposed to skip this!");
        }
    }
}
