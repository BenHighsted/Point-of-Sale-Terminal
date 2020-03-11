using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointOfSaleTerminalLibrary;

namespace PointOfSaleUnitTests
{
	[TestClass]
	public class BaseTests
	{
        //Methods to test valid inputs
		[TestMethod]
		public void TestBaseCase1()
		{
			App runCode = new App();
			runCode.ScanItems("A,B,C,D,A,B,A");
			Assert.AreEqual(13.25M, runCode.ReturnResult());
		}
		[TestMethod]
		public void TestBaseCase2()
		{
			App runCode = new App();
			runCode.ScanItems("C,C,C,C,C,C,C");
			Assert.AreEqual(6.00M, runCode.ReturnResult());
		}
		[TestMethod]
		public void TestBaseCase3()
		{
			App runCode = new App();
			runCode.ScanItems("A,B,C,D");
			Assert.AreEqual(7.25M, runCode.ReturnResult());
		}
		//Methods to test bad inputs
		[TestMethod]
		public void TestNoInput()
		{
			App runCode = new App();
			runCode.ScanItems("");
			Assert.AreEqual(0M, runCode.ReturnResult());
		}
		[TestMethod]
		public void TestInvalidInput()
		{
			App runCode = new App();
			runCode.ScanItems("E, F, G");
			Assert.AreEqual(0M, runCode.ReturnResult());
		}
	}
}
