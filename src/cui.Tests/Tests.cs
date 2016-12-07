using NUnit.Framework;
using Should;

namespace cui.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Should_be_true()
        {
            true.ShouldBeTrue();
        }
    }
}
