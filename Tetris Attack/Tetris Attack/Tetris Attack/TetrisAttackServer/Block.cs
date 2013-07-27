using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Tetris_Attack
{
	public class Block
	{
		public BlockTypes Type { get; set; }
		public BlockStates State { get; set; }
		public int Top { get; set; }
		public int Left{ get; set; }
		public int Height { get; set; }
		public int Width { get; set; }

		public bool IsLockedState()
		{
			return State == BlockStates.ClearingInProgress;
		}

		public Rectangle getBlockTexture()
		{
			Rectangle rect;
			if (this.Type == BlockTypes.Star)
			{
				rect = new Rectangle(9, 10, 15, 15);
			}
			else if (this.Type == BlockTypes.Square)
			{
				rect = new Rectangle(30, 10, 15, 15);
			}
			else if (this.Type == BlockTypes.Triangle)
			{
				rect = new Rectangle(51, 10, 15, 15);
			}
			else if (this.Type == BlockTypes.Diamond)
			{
				rect = new Rectangle(72, 10, 15, 15);
			}
			else if (this.Type == BlockTypes.UpsideDownTriangle)
			{
				rect = new Rectangle(93, 10, 15, 15);
			}
			else
			{
				rect = new Rectangle(135, 10, 15, 15);
			}
			return rect;
		}
	}
}
