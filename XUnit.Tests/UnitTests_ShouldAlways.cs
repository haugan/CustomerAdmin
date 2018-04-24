using Xunit;

namespace XUnit.Tests
{
    public class UnitTests_ShouldAlways
    {
        private readonly int a = 1;
        private readonly int b = 2;

        [Fact]
        public void Pass()
        {
            Assert.Equal(a, a);
        }

        [Fact]
        public void Fail()
        {
            Assert.Equal(a, b);
        }
    }
}
