using TetrisAttackServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{


	/// <summary>
	///This is a test class for BoardTest and is intended
	///to contain all BoardTest Unit Tests
	///</summary>
	[TestClass()]
	public class BoardTest
	{
		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		/// <summary>
		///A test for IsLoseConditionMet
		///</summary>
		[TestMethod()]
		public void LoseConditionIsNotMet()
		{
			Board target = new Board();
			bool actual = target.IsLoseConditionMet();

			Assert.IsFalse(actual);
		}

		/// <summary>
		///A test for IsLoseConditionMet
		///</summary>
		[TestMethod()]
		public void LoseConditionIsMet()
		{
			var blockLists = new System.Collections.Generic.List<System.Collections.Generic.LinkedList<Block>>();

			for (int counter = 0; counter < 6; counter++)
			{
				var linkedList = new System.Collections.Generic.LinkedList<Block>();

				for (int listCounter = 0; listCounter < 14; listCounter++)
				{
					linkedList.AddFirst(new Block());
				}
					
				blockLists.Add(linkedList);
			}
				
			Board target = new Board()
			{
				BlockLists = blockLists
			};

			bool actual = target.IsLoseConditionMet();

			Assert.IsTrue(actual);
		}

		/// <summary>
		///A test for PushBlocks
		///</summary>
		[TestMethod()]
		public void PushBlocksTest()
		{
			int numberOfBlocksInTheList = 10;
			var blockLists = new System.Collections.Generic.List<System.Collections.Generic.LinkedList<Block>>();

			for (int counter = 0; counter < 6; counter++)
			{
				var linkedList = new System.Collections.Generic.LinkedList<Block>();

				for (int listCounter = 0; listCounter < numberOfBlocksInTheList; listCounter++)
				{
					linkedList.AddFirst(new Block());
				}

				blockLists.Add(linkedList);
			}

			Board target = new Board()
			{
				BlockLists = blockLists
			};

			target.PushBlocks();

			Assert.AreEqual(++numberOfBlocksInTheList, target.BlockLists[0].Count);
		}

		/// <summary>
		///A test for BuildNewBoard
		///</summary>
		[TestMethod()]
		public void BuildNewBoardTest()
		{			
			Board actual = Board.BuildNewBoard();

			Assert.IsNotNull(actual);
			Assert.AreNotEqual(actual.BlockLists[0].First.Value.Type, actual.BlockLists[1].First.Value.Type);
			Assert.AreNotEqual(actual.BlockLists[0].Last.Value.Type, actual.BlockLists[1].Last.Value.Type);
			Assert.AreNotEqual(6, actual.BlockLists.Count);
		}
	}
}
