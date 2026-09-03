using System.Diagnostics;

namespace FishDex.Testing
{
    public class UnitTest1
    {
        [Fact]
        public void PassingTest()
        {
            Debug.Assert(true);
        }
        [Fact]
        public void FailingTest()
        {
            Debug.Assert(false);
        }
    }
}
