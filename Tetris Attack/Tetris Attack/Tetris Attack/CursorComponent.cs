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
	public class CursorComponent : Microsoft.Xna.Framework.DrawableGameComponent
	{
		Texture2D cursorTexture;
		Sprite cursor;
		SpriteBatch cursorBatch;
		TimeSpan timePerMove = TimeSpan.FromMilliseconds(400);
		TimeSpan timePerSwap = TimeSpan.FromMilliseconds(700);
		TimeSpan timePassed;
		Cursor gameCursor;
		Board board;

		public CursorComponent(Game game, Board b)
			: base(game)
		{
			board = b;
		}

		/// <summary>
		/// Allows the game component to perform any initialization it needs to before starting
		/// to run.  This is where it can query for any required services and load content.
		/// </summary>
		public override void Initialize()
		{
			base.Initialize();
			cursor = new Sprite(cursorTexture, new Rectangle(139, 35, 38, 22));
			cursor.Scale = 3;
			cursor.Position = new Vector2(0, 0);
			cursor.Origin = new Vector2(4, 4);
			gameCursor = new Cursor();
		}

		protected override void LoadContent()
		{
			cursorTexture = Game.Content.Load<Texture2D>("Sprites/Totodile");
			cursorBatch = new SpriteBatch(Game.GraphicsDevice);

			base.LoadContent();
		}

		/// <summary>
		/// Allows the game component to update itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public override void Update(GameTime gameTime)
		{
			var ks = Keyboard.GetState();
			if ((timePassed += gameTime.ElapsedGameTime) > timePerMove && ks.IsKeyDown(Keys.Right))
			{
				timePassed = TimeSpan.Zero;
				cursor.Position.X += 45;
			}
			else if ((timePassed += gameTime.ElapsedGameTime) > timePerMove && ks.IsKeyDown(Keys.Left))
			{
				timePassed = TimeSpan.Zero;
				cursor.Position.X -= 45;
			}
			if ((timePassed += gameTime.ElapsedGameTime) > timePerMove && ks.IsKeyDown(Keys.Up))
			{
				timePassed = TimeSpan.Zero;
				cursor.Position.Y -= 45;
			}
			if ((timePassed += gameTime.ElapsedGameTime) > timePerMove && ks.IsKeyDown(Keys.Down))
			{
				timePassed = TimeSpan.Zero;
				cursor.Position.Y += 45;
			}
			if ((timePassed += gameTime.ElapsedGameTime) > timePerSwap && ks.IsKeyDown(Keys.Space))
			{
				timePassed = TimeSpan.Zero;
				gameCursor.Top = (int)(8 - (cursor.Position.Y / 45));
				gameCursor.Left = (int)(5 - cursor.Position.X / 45);
				gameCursor.SwapBlocks(
					board.BlockLists.ElementAt(gameCursor.Left),
					board.BlockLists.ElementAt(gameCursor.Left).ElementAt(gameCursor.Top), 
					board.BlockLists.ElementAt(gameCursor.Left - 1), 
					board.BlockLists.ElementAt(gameCursor.Left - 1).ElementAt(gameCursor.Top)
				);
				board.Update();
			}
			if (cursor.Position.X > 224)
				cursor.Position.X = 180;
			if (cursor.Position.X < 0)
				cursor.Position.X = 0;
			if (cursor.Position.Y > 404)
				cursor.Position.Y = 360;
			if (cursor.Position.Y < 0)
				cursor.Position.Y = 0;
			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			cursorBatch.Begin(SpriteSortMode.FrontToBack, null);
			cursor.Draw(gameTime, cursorBatch);
			cursorBatch.End();
			base.Draw(gameTime);
		}
	}
}
