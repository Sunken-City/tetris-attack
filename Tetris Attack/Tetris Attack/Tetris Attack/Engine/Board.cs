using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris_Attack
{
	public class Board
	{
		private const int MaxListLength = 10;
		private const int maxNumberOfLists = 6;
		private static Random randomNumberGenerator = new Random((int)DateTime.Now.Ticks);
		public bool inDanger { get; set; }
		public bool active { get; set; }
		public int score = 0;
		public Cursor cursor = new Cursor();

		public static Board BuildNewBoard()
		{
			var blockLists = new System.Collections.Generic.List<System.Collections.Generic.LinkedList<Block>>();

			for (int counter = 0; counter < maxNumberOfLists; counter++)
			{
				var linkedList = new System.Collections.Generic.LinkedList<Block>();

				int numberOfBlocksInTheList = randomNumberGenerator.Next(3, 6);

				for (int listCounter = 0; listCounter < numberOfBlocksInTheList; listCounter++)
				{
					var block = GetNewRandomBlock();
					linkedList.AddFirst(block);
				}

				for (int listCounter = numberOfBlocksInTheList; listCounter < 9; listCounter++)
				{
					var block = new Block();
					linkedList.AddLast(block);
				}

					blockLists.Add(linkedList);
			}

			Board board = new Board()
			{
				BlockLists = blockLists,
				inDanger = false,
				active = true
			};

			return board;
		}

		private static Block GetNewRandomBlock()
		{
			return new Block(randomNumberGenerator.Next((int)BlockTypes.Star, (int)BlockTypes.UpsideDownTriangle + 1));
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
				var newBlockToBeAdded = GetNewRandomBlock();
				if (blockList.Last.Value.Type == BlockTypes.Empty)
				{
					blockList.RemoveLast();
					blockList.AddFirst(newBlockToBeAdded);
				}
				else
				{
					//Lose
				}
			}
			Update();
		}

		public bool IsLoseConditionMet()
		{
			return (from blockList in blockLists
					select blockList.Count > MaxListLength).Any();
		}

		public void Update()
		{
			//First, check for vertical clearings.
			for (int i = 0; i < 6; i++)
			{
				int lastBlockType = (int)blockLists.ElementAt(i).ElementAt(0).Type;
				int blockCounter = 1;
				for (int j = 1; j < 9; j++)
				{
					if (lastBlockType != 0 && lastBlockType == (int)blockLists.ElementAt(i).ElementAt(j).Type)
					{
						blockCounter++;
					}
					else
					{
						if (blockCounter > 2)
						{
							removeVertical(i, j - 1, blockCounter - 1);
							score = score + (10 * blockCounter);
						}
						blockCounter = 1;
						lastBlockType = (int)blockLists.ElementAt(i).ElementAt(j).Type;
					}
					if (j == 8 && blockCounter > 2)
					{
						removeVertical(i, j, blockCounter - 1);
						score = score + (10 * blockCounter);
					}
				}
			}
			//Now, check horizontally.
			for (int i = 0; i < 9; i++)
			{
				int lastBlockType = (int)blockLists.ElementAt(0).ElementAt(i).Type;
				int blockCounter = 1;
				for (int j = 1; j < 6; j++)
				{
					if (lastBlockType != 0 && lastBlockType == (int)blockLists.ElementAt(j).ElementAt(i).Type)
					{
						blockCounter++;
					}
					else
					{
						if (blockCounter > 2)
						{
							removeHorizontal(i, j - 1, blockCounter - 1);
							score = score + (10 * blockCounter);
						}
						blockCounter = 1;
						lastBlockType = (int)blockLists.ElementAt(j).ElementAt(i).Type;
					}
					if (j == 5 && blockCounter > 2)
					{
						removeHorizontal(i, j, blockCounter - 1);
						score = score + (10 * blockCounter);
					}
				}
			}
			checkForDanger();
		}

		private void checkForDanger()
		{
			inDanger = false;
			for (int i = 0; i < 6; i++)
			{
				if (blockLists.ElementAt(i).ElementAt(6).Type != (BlockTypes)0)
				{
					inDanger = true;
					break;
				}
			}
		}

		public void removeVertical(int firstIndex, int secondIndex, int iterations)
		{
			if (iterations != 0)
			{
				removeVertical(firstIndex, secondIndex, iterations - 1);
			}
			blockLists.ElementAt(firstIndex).Remove(blockLists.ElementAt(firstIndex).ElementAt(secondIndex - iterations));
			blockLists.ElementAt(firstIndex).AddLast(new Block());
		}

		public void removeHorizontal(int firstIndex, int secondIndex, int iterations)
		{
			if (iterations != 0)
			{
				removeHorizontal(firstIndex, secondIndex, iterations - 1);
			}
			blockLists.ElementAt(secondIndex - iterations).Remove(blockLists.ElementAt(secondIndex - iterations).ElementAt(firstIndex));
			blockLists.ElementAt(secondIndex - iterations).AddLast(new Block());
		}

	}
}
