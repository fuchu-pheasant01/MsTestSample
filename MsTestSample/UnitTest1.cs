using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace MsTestSample
{
    [TestClass]
    public class UnitTest1
    {
        [AssemblyInitialize]
        [TestCategory("category1")]
        public static void AssemblyBefore(TestContext context)
        {
            Console.WriteLine("AssemblyInitializeが呼ばれました");
        }

        [AssemblyCleanup]
        [TestCategory("category1")]
        public static void AssemblyAfter()
        {
            Console.WriteLine("AssemblyCleanupが呼ばれました");
        }

        [ClassInitialize]
        [TestCategory("category1")]
        public static void ClassBefore(TestContext context)
        {
            Console.WriteLine("ClassInitializeが呼ばれました");
        }

        [ClassCleanup]
        [TestCategory("category1")]
        public static void ClasAfter()
        {
            Console.WriteLine("ClassCleanupが呼ばれました");
        }

        [TestInitialize]
        [TestCategory("category1")]
        public void Before()
        {
            Console.WriteLine("TestInitializeが呼ばれました");
        }

        [TestCleanup]
        [TestCategory("category1")]
        public void After()
        {
            Console.WriteLine("TestCleanupが呼ばれました");
        }

        [DataTestMethod][TestCategory("category1")]
        [DataRow(5)][DataRow(1)]
        public void TestEqual(int su)
        {
            var sc = new SampleClass();
            try
            {
                Assert.AreEqual(500, sc.Kingaku(su), "一致しませんでした");
            } catch (AssertFailedException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        [TestMethod("IsTrueで判定")][TestCategory("category1")]
        public void TestIsTrue()
        {
            var sc = new SampleClass();
            Assert.IsTrue(500 == sc.Kingaku(5), "一致しませんでした");
        }

        [TestMethod]
        [TestCategory("category1")]
        public void TestIsNull()
        {
            string str = null;
            Assert.IsNull(str, "Nullではありません");
        }

        [TestMethod]
        [TestCategory("category1")]
        public void TestThrows()
        {
            var sc = new SampleClass();
            Assert.ThrowsException<System.Exception>(() => sc.ThrowUp(), "エラーは発生しませんでした");
        }

        [TestMethod]
        [TestCategory("category1")]
        public void TestSetup()
        {
            var sc = new Mock<ISampleClass>();
            sc.Setup(x => x.Kingaku(1)).Returns(500);
            var kei = sc.Object.Kingaku(1);
            //System.Diagnostics.Debug.WriteLine(sc.Object.kingaku(1));
            Assert.AreEqual(500, kei, "一致しませんでした");
        }

        [TestMethod]
        [TestCategory("category1")]
        public void TestSetupGet()
        {
            var sc = new Mock<ISampleClass>();
            sc.SetupGet(x => x.Shohin).Returns("りんご");
            var name = sc.Object.Shohin;
            Assert.AreEqual("りんご", name, "一致しませんでした");
        }

        [TestMethod]
        [TestCategory("category1")]
        public void TestSetupSet()
        {
            var sc = new Mock<ISampleClass>();
            sc.SetupProperty(x => x.Shohin);
            sc.Object.Shohin = "りんご";
            var name = sc.Object.Shohin;
            Assert.AreEqual("りんご", name, "一致しませんでした");
        }

        [TestMethod][TestCategory("category1")]
        public void TestSetupThrows()
        {
            var sc = new Mock<ISampleClass>();
            sc.Setup(m => m.ThrowUp()).Throws<System.Exception>();
            Assert.ThrowsException<System.Exception>(() => sc.Object.ThrowUp());
        }
    }
}
