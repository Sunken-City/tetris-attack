using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TetrisAttackServer
{
	public class Cursor
	{
		public int Top { get; set; }
		public int Left { get; set; }

		public void SwapBlocks(LinkedList<Block> leftBlockList, Block leftBlock, LinkedList<Block> rightBlockList, Block rightBlock)
		{
			leftBlockList.AddBefore(leftBlockList.Find(leftBlock), rightBlock);
			leftBlockList.Remove(leftBlockList.Find(leftBlock));

			rightBlockList.AddBefore(rightBlockList.Find(rightBlock), leftBlock);
			rightBlockList.Remove(rightBlock);
		}
	}
}
