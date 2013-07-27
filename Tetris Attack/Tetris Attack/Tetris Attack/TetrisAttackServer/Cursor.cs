using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris_Attack
{
	public class Cursor
	{
		public int Top { get; set; }
		public int Left { get; set; }

		public void SwapBlocks(LinkedList<Block> leftBlockList, Block leftBlock, LinkedList<Block> rightBlockList, Block rightBlock)
		{
			leftBlockList.AddBefore(leftBlockList.Find(leftBlock), rightBlock);
			leftBlockList.Remove(leftBlockList.Find(leftBlock));
			blocksFall(leftBlockList);

			rightBlockList.AddBefore(rightBlockList.Find(rightBlock), leftBlock);
			rightBlockList.Remove(rightBlock);
			blocksFall(rightBlockList);
		}

		public void blocksFall(LinkedList<Block> blockList)
		{
			for (int i = 0; i < 9; i++)
			{
				var block = blockList.ElementAt(i);
				if (block.Type == BlockTypes.Empty)
				{
					blockList.Remove(block);
					blockList.AddLast(block);
				}
			}
		}
	}
}
