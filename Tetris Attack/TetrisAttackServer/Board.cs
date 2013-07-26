using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TetrisAttackServer
{
	public class Board
	{
		private const int MaxListLength = 13;
		private const int maxNumberOfLists = 6;
		private static Random randomNumberGenerator = new Random((int)DateTime.Now.Ticks);

		public static Board BuildNewBoard()
		{
			int numberOfBlocksInTheList = 3;
			var blockLists = new System.Collections.Generic.List<System.Collections.Generic.LinkedList<Block>>();

			for (int counter = 0; counter < maxNumberOfLists; counter++)
			{
				var linkedList = new System.Collections.Generic.LinkedList<Block>();

				for (int listCounter = 0; listCounter < numberOfBlocksInTheList; listCounter++)
				{
					var block = GetNewRandomBlock();
					linkedList.AddFirst(block);
				}

				blockLists.Add(linkedList);
			}

			Board board = new Board()
			{
				BlockLists = blockLists
			};

			return board;
		}

		private static Block GetNewRandomBlock()
		{
			return new Block()
			{
				State = BlockStates.AtRest,
				Type = (BlockTypes)randomNumberGenerator.Next((int)BlockTypes.Star, (int)BlockTypes.UpsideDownTriangle)
			};
		}

		public int Top { get; set; }
		public int Left { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
		public int Capacity { get; set; }

		// 6 lists - 13 blocks in each list
		private List<LinkedList<Block>> blockLists = new List<LinkedList<Block>>();
		public List<LinkedList<Block>> BlockLists
		{
			get { return blockLists; }
			set { blockLists = value; }
		}

		public void PushBlocks()
		{
			foreach (var blockList in blockLists)
			{
				var newBlockToBeAdded = new Block();
				blockList.AddBefore(blockList.First, newBlockToBeAdded);
			}
		}

		public bool IsLoseConditionMet()
		{
			return (from blockList in blockLists
					select blockList.Count > MaxListLength).Any();
		}
	}
}
