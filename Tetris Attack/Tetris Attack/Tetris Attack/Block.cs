using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TetrisAttackServer
{
	public class Block
	{
		public BlockTypes Type { get; set; }
		public BlockStates State { get; set; }
		public int Top { get; set; }
		public int Left{ get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
		public SpriteDetails SpriteInformation { get; set; }

		public bool IsLockedState()
		{
			return State == BlockStates.ClearingInProgress;
		}
	}
}
