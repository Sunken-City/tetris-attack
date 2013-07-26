using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Tetris_Attack
{
	/// <summary>
	/// This is a game component that implements IUpdateable.
	/// </summary>
	public class BoardComponent : Microsoft.Xna.Framework.DrawableGameComponent
	{
		SpriteBatch boardBatch;
		Board board;

		public BoardComponent(Game game)
			: base(game)
		{

		}

		protected override void LoadContent()
		{
			boardBatch = new SpriteBatch(Game.GraphicsDevice);

			base.LoadContent();
		}

		public void blockFall(int numBlocks)
		{
			
		}

		public void blockSwap()
		{

		}

		/// <summary>
		/// Allows the game component to perform any initialization it needs to before starting
		/// to run.  This is where it can query for any required services and load content.
		/// </summary>
		public override void Initialize()
		{
			board = Board.BuildNewBoard();

			base.Initialize();
		}

		/// <summary>
		/// Allows the game component to update itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public override void Update(GameTime gameTime)
		{
			// TODO: Add your update code here

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			boardBatch.Begin(SpriteSortMode.FrontToBack, null);
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					board.BlockLists.ElementAt(i).ElementAt(j).Draw(gameTime, boardBatch);
				}
			}
			boardBatch.End();
			base.Draw(gameTime);
		}
	}
}
