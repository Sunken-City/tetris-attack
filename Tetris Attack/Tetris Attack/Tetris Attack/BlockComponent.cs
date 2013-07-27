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
		Texture2D blockTexture;
		private SpriteBatch blockBatch;
		Sprite[][] blocks = new Sprite[6][];
		public Board board;

		public BlockComponent(Game game, Board b)
			: base(game)
		{
			board = b;
			for (int i = 0; i < 6; i++)
			{
				blocks[i] = new Sprite[9];
			}
		}

		protected override void LoadContent()
		{
			blockBatch = new SpriteBatch(Game.GraphicsDevice);
			blockTexture = Game.Content.Load<Texture2D>("Sprites/Blocks");
			base.LoadContent();
		}

		public override void Initialize()
		{
			base.Initialize();
			//for (int i = 0; i < 6; i++)
			//{
			//    blocks[i] = new Sprite[9];
			//    for (int j = 0; j < 9; j++)
			//    {
			//        Sprite block = new Sprite(blockTexture, new Rectangle(151, 72, 15, 15));
			//        block.Scale = 3;
			//        block.Position = new Vector2(i * 45, j * 45);
			//        blocks[i][j] = block;
			//    }
			//}
		}

		public override void Update(GameTime gameTime)
		{
			for (int i = 5; i > -1; i--)
			{
				for (int j = 0; j < board.BlockLists.ElementAt(i).Count; j++)
				{
					var block = board.BlockLists.ElementAt(i).ElementAt(j);
					Sprite newBlock = new Sprite(blockTexture, block.getBlockTexture());
					newBlock.Scale = 3;
					newBlock.Position = new Vector2(225 - (i * 45), 360 - (j * 45));
					blocks[i][j] = newBlock;
				}
			}

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			blockBatch.Begin(SpriteSortMode.FrontToBack, null);
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < board.BlockLists.ElementAt(i).Count; j++)
				{
					blocks[i][j].Draw(gameTime, blockBatch);
				}
			}
			blockBatch.End();
			base.Draw(gameTime);
		}

	}
}
