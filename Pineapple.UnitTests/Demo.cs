using System;
using Xunit;

namespace Pineapple.UnitTests
{
    public sealed class Demo
    {
        [Fact]
        public void SomewhatPassingTest()
        {
            Assert.Equal(3, 3);
        }
    }
}
