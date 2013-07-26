using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Tetris_Attack
{
	public class BlockComponent : Microsoft.Xna.Framework.DrawableGameComponent
	{
		public BlockTypes Type { get; set; }
		public BlockStates State { get; set; }
		public int Top { get; set; }
		public int Left { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
		Texture2D blockTexture;
		private SpriteBatch blockBatch;
		private List<LinkedList<Sprite>> blockLists = new List<LinkedList<Sprite>>();

		public BlockComponent(Game game)
			: base(game)
		{

		}

		protected override void LoadContent()
		{
			blockBatch = new SpriteBatch(Game.GraphicsDevice);
			blockTexture = Game.Content.Load<Texture2D>("Sprites/Blocks");
			base.LoadContent();
		}

		public override void Initialize()
		{
			block = new Sprite(blockTexture, this.getBlockTexture());
			base.Initialize();
		}

		public override void Update(GameTime gameTime)
		{
			// TODO: Add your update code here

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			blockBatch.Begin(SpriteSortMode.FrontToBack, null);
			block.Draw(gameTime, blockBatch);
			blockBatch.End();
			base.Draw(gameTime);
		}

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
