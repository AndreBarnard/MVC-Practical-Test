using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalTest.Controllers;

namespace PracticalTest.Tests.Controllers
{
    [TestClass]
    public class PascalTrianglesControllerTest
    {
        [TestMethod]
        public void TestpascalFirstRow()
        {
            PascalTrianglesController controller = new PascalTrianglesController();

            Assert.AreEqual(1,controller.pascal(0, 0));

        }

        [TestMethod]
        public void TestpascalSecondRow()
        {
            PascalTrianglesController controller = new PascalTrianglesController();

            Assert.AreEqual(2, controller.pascal(2, 1));
        }

        [TestMethod]
        public void TestpascalThirdRow()
        {
            PascalTrianglesController controller = new PascalTrianglesController();

            Assert.AreEqual(3, controller.pascal(3, 2));
        }

        [TestMethod]
        public void TestpascalSixRow()
        {
            PascalTrianglesController controller = new PascalTrianglesController();

            Assert.AreEqual(15, controller.pascal(6, 2));
        }

        [TestMethod]
        public void TestpascalAgtRow()
        {
            PascalTrianglesController controller = new PascalTrianglesController();

            Assert.AreEqual(70, controller.pascal(8, 4));
        }
    }
}
