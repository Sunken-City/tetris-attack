using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tetris_Attack
{
	/// <summary>
	/// This is a game component that implements IUpdateable.
	/// </summary>
	public class CursorComponent : Microsoft.Xna.Framework.DrawableGameComponent
	{
		Texture2D cursorTexture;
		Sprite cursorSprite;
		SpriteBatch cursorBatch;
		TimeSpan timePerMove = TimeSpan.FromMilliseconds(500);
		TimeSpan timePerSwap = TimeSpan.FromMilliseconds(700);
		TimeSpan timePassed;
		Board board;
		Cursor cursor;
		private SoundEffect moveSound;
		private SoundEffectInstance moveSoundInstance;
		private SoundEffect swapSound;
		private SoundEffectInstance swapSoundInstance;

		public CursorComponent(Game game, Board b)
			: base(game)
		{
			board = b;
			cursor = board.cursor;
		}

		/// <summary>
		/// Allows the game component to perform any initialization it needs to before starting
		/// to run.  This is where it can query for any required services and load content.
		/// </summary>
		public override void Initialize()
		{
			base.Initialize();
			cursorSprite = new Sprite(cursorTexture, new Rectangle(139, 9, 38, 22), 2, false, 4);
			cursorSprite.AnimationInterval = TimeSpan.FromMilliseconds(500);
			cursorSprite.Scale = 3;
			cursor.setPosition(0, 0);
			cursorSprite.Position = new Vector2(0, 0);
			cursorSprite.Origin = new Vector2(4, 4);
			cursorSprite.Active = true;
			board.cursor = new Cursor();
			moveSoundInstance = moveSound.CreateInstance();
			swapSoundInstance = swapSound.CreateInstance();
		}

		protected override void LoadContent()
		{
			cursorTexture = Game.Content.Load<Texture2D>("Sprites/Totodile");
			moveSound = Game.Content.Load<SoundEffect>("Audio/Move");
			swapSound = Game.Content.Load<SoundEffect>("Audio/Swap");
			cursorBatch = new SpriteBatch(Game.GraphicsDevice);

			base.LoadContent();
		}

		/// <summary>
		/// Allows the game component to update itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public override void Update(GameTime gameTime)
		{
			cursorSprite.Update(gameTime);
			var ks = Keyboard.GetState();
			if ((timePassed += gameTime.ElapsedGameTime) > timePerMove && ks.IsKeyDown(Keys.Right))
			{
				timePassed = TimeSpan.Zero;
				cursor.Left += 1;
				updateSpriteX();
				if (cursor.Left > 4)
				{
					cursor.Left = 4;
					updateSpriteX();
				}
				else
					moveSoundInstance.Play();
			}
			else if ((timePassed += gameTime.ElapsedGameTime) > timePerMove && ks.IsKeyDown(Keys.Left))
			{
				timePassed = TimeSpan.Zero;
				cursor.Left -= 1;
				updateSpriteX();
				if (cursor.Left < 0)
				{
					cursor.Left = 0;
					updateSpriteX();
				}
				else
					moveSoundInstance.Play();
			}
			if ((timePassed += gameTime.ElapsedGameTime) > timePerMove && ks.IsKeyDown(Keys.Up))
			{
				timePassed = TimeSpan.Zero;
				cursor.Top -= 1;
				updateSpriteY();
				if (cursor.Top < 0)
				{
					cursor.Top = 0;
					updateSpriteY();
				}
				else
					moveSoundInstance.Play();
			}
			if ((timePassed += gameTime.ElapsedGameTime) > timePerMove && ks.IsKeyDown(Keys.Down))
			{
				timePassed = TimeSpan.Zero;
				cursor.Top += 1;
				updateSpriteY();
				if (cursor.Top > 8)
				{
					cursor.Top = 8;
					updateSpriteY();
				}
				else
					moveSoundInstance.Play();
			}
			if ((timePassed += gameTime.ElapsedGameTime) > timePerSwap && ks.IsKeyDown(Keys.Space))
			{
				timePassed = TimeSpan.Zero;
				int yCoord = (int)(8 - (cursor.Top));
				int xCoord = (int)(5 - (cursor.Left));
				cursor.SwapBlocks(
					board.BlockLists.ElementAt(xCoord),
					board.BlockLists.ElementAt(xCoord).ElementAt(yCoord),
					board.BlockLists.ElementAt(xCoord - 1),
					board.BlockLists.ElementAt(xCoord - 1).ElementAt(yCoord)
				);
				swapSoundInstance.Play();
				board.Update();
			}
			if ((timePassed += gameTime.ElapsedGameTime) > timePerSwap && (ks.IsKeyDown(Keys.LeftShift) || ks.IsKeyDown(Keys.RightShift)))
			{
				timePassed = TimeSpan.Zero;
				board.PushBlocks();
				board.Update();
			}

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			cursorBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);
			cursorSprite.Draw(gameTime, cursorBatch);
			cursorBatch.End();
			base.Draw(gameTime);
		}

		public void updateSpritePosition()
		{
			cursorSprite.Position.X = cursor.Left * 45;
			cursorSprite.Position.Y = cursor.Top * 45;
		}

		public void updateSpriteX()
		{
			cursorSprite.Position.X = cursor.Left * 45;
		}

		public void updateSpriteY()
		{
			cursorSprite.Position.Y = cursor.Top * 45;
		}
	}
}
