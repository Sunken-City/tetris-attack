using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TetrisAttackServer
{
	public class SpriteDetails
	{
		private string spriteName = string.Empty;
		public string SpriteName
		{
			get { return spriteName; }
			set { spriteName = value; }
		}

		public int RectangleHeight { get; set; }
		public int RectangleWidth { get; set; }
		public int RectangleX { get; set; }
		public int RectangleY { get; set; }
	}
}
