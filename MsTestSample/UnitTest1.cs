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
            Console.WriteLine("AssemblyInitialize���Ă΂�܂���");
        }

        [AssemblyCleanup]
        [TestCategory("category1")]
        public static void AssemblyAfter()
        {
            Console.WriteLine("AssemblyCleanup���Ă΂�܂���");
        }

        [ClassInitialize]
        [TestCategory("category1")]
        public static void ClassBefore(TestContext context)
        {
            Console.WriteLine("ClassInitialize���Ă΂�܂���");
        }

        [ClassCleanup]
        [TestCategory("category1")]
        public static void ClasAfter()
        {
            Console.WriteLine("ClassCleanup���Ă΂�܂���");
        }

        [TestInitialize]
        [TestCategory("category1")]
        public void Before()
        {
            Console.WriteLine("TestInitialize���Ă΂�܂���");
        }

        [TestCleanup]
        [TestCategory("category1")]
        public void After()
        {
            Console.WriteLine("TestCleanup���Ă΂�܂���");
        }

        [DataTestMethod][TestCategory("category1")]
        [DataRow(5)][DataRow(1)]
        public void TestEqual(int su)
        {
            var sc = new SampleClass();
            try
            {
                Assert.AreEqual(500, sc.Kingaku(su), "��v���܂���ł���");
            } catch (AssertFailedException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        [TestMethod("IsTrue�Ŕ���")][TestCategory("category1")]
        public void TestIsTrue()
        {
            var sc = new SampleClass();
            Assert.IsTrue(500 == sc.Kingaku(5), "��v���܂���ł���");
        }

        [TestMethod]
        [TestCategory("category1")]
        public void TestIsNull()
        {
            string str = null;
            Assert.IsNull(str, "Null�ł͂���܂���");
        }

        [TestMethod]
        [TestCategory("category1")]
        public void TestThrows()
        {
            var sc = new SampleClass();
            Assert.ThrowsException<System.Exception>(() => sc.ThrowUp(), "�G���[�͔������܂���ł���");
        }

        [TestMethod]
        [TestCategory("category1")]
        public void TestSetup()
        {
            var sc = new Mock<ISampleClass>();
            sc.Setup(x => x.Kingaku(1)).Returns(500);
            var kei = sc.Object.Kingaku(1);
            //System.Diagnostics.Debug.WriteLine(sc.Object.kingaku(1));
            Assert.AreEqual(500, kei, "��v���܂���ł���");
        }

        [TestMethod]
        [TestCategory("category1")]
        public void TestSetupGet()
        {
            var sc = new Mock<ISampleClass>();
            sc.SetupGet(x => x.Shohin).Returns("���");
            var name = sc.Object.Shohin;
            Assert.AreEqual("���", name, "��v���܂���ł���");
        }

        [TestMethod]
        [TestCategory("category1")]
        public void TestSetupSet()
        {
            var sc = new Mock<ISampleClass>();
            sc.SetupProperty(x => x.Shohin);
            sc.Object.Shohin = "���";
            var name = sc.Object.Shohin;
            Assert.AreEqual("���", name, "��v���܂���ł���");
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
