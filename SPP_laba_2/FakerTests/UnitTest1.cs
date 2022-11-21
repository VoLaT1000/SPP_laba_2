using SPP_laba_2;

namespace FakerTests
{
    [TestClass]
    public class UnitTest1
    {
        private Faker faker = new Faker();
        [TestMethod]
        public void TestMethod1()
        {
            var test = faker.Create<Default>();
            Assert.IsTrue(test._int != 0);
            Assert.IsTrue(test._double != 0);
            Assert.IsTrue(test._long != 0);
            Assert.IsTrue(test._string != "");
        }
        [TestMethod]
        public void TestMethod2()
        {
            var test = faker.Create<ClassList>();
            Assert.IsTrue(test._list.Any());
            foreach (var item in test._list)
            {
                Assert.IsTrue(item != 0);
            }
        }
        [TestMethod]
        public void TestMethod3()
        {
            var test = faker.Create<ClassA>();
            Assert.IsTrue(test.classB != null);
            Assert.IsTrue(test.classB.classA == null);
        }
        [TestMethod]
        public void TestMethod4()
        {
            var test = faker.Create<ClassWithPrivateConstructor>();
            Assert.IsTrue(test != null);
        }
    }
}