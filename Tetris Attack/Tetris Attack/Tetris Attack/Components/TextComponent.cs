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
	public class TextComponent : Microsoft.Xna.Framework.DrawableGameComponent
	{
		Texture2D textTexture;
		Sprite[] score = new Sprite[6];
		Sprite[] secondsSprites = new Sprite[2];
		int seconds = 0;
		Sprite[] minutesSprites = new Sprite[2];
		int minutes = 0;
		SpriteBatch textBatch;
		Board board;
		TimeSpan timePerSecond = TimeSpan.FromMilliseconds(999);
		private TimeSpan timePassed;

		public TextComponent(Game game, Board b)
			: base(game)
		{
			board = b;
		}

		public override void Initialize()
		{
			base.Initialize();
			for (int i = 0; i < 6; i++)
			{
				score[i] = buildTextSprite(i, new Rectangle(77, 115, 7, 12), new Vector2(414 - (21 * i + 2 * i), 102));
			}

			for (int i = 0; i < 2; i++)
			{
				minutesSprites[i] = buildTextSprite(i, new Rectangle(77, 132, 7, 12), new Vector2(345 - (21 * i + 3 * i), 366));
				secondsSprites[i] = buildTextSprite(i, new Rectangle(77, 132, 7, 12), new Vector2(414 - (21 * i + 3 * i), 366));
			}

		}

		protected override void LoadContent()
		{
			textTexture = Game.Content.Load<Texture2D>("Sprites/Totodile");
			textBatch = new SpriteBatch(Game.GraphicsDevice);
			base.LoadContent();
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			for (int i = 0; i < 6; i++)
			{
				setDigit(board.score, i, score);
			}

			if ((timePassed += gameTime.ElapsedGameTime) > timePerSecond)
			{
				timePassed = TimeSpan.Zero;
				seconds += 1;
				if (seconds == 60 || seconds > 60)
				{
					minutes += 1;
					seconds = 0;
				}

				for (int i = 0; i < 2; i++)
				{
					setDigit(seconds, i, secondsSprites);
				}

				for (int i = 0; i < 2; i++)
				{
					setDigit(minutes, i, minutesSprites);
				}
			}
		}

		public override void Draw(GameTime gameTime)
		{
			textBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);

			for (int i = 0; i < 2; i++)
			{
				secondsSprites[i].Draw(gameTime, textBatch);
				minutesSprites[i].Draw(gameTime, textBatch);
			}

			for (int i = 0; i < 6; i++)
			{
				score[i].Draw(gameTime, textBatch);
			}

			textBatch.End();
			base.Draw(gameTime);
		}

		private void setDigit(int total, int i, Sprite[] sprites)
		{
			int digit = (total % (int)(Math.Pow(10, (i + 1))) / (int)(Math.Pow(10, i)));
			if (digit < 10)
			{
				sprites[i].SetFrame(digit);
			}
			else
			{
				sprites[i].SetFrame(11);
			}
		}

		private Sprite buildTextSprite(int i, Rectangle rectangle, Vector2 position)
		{
			Sprite textSprite = new Sprite(textTexture, rectangle, 11, true, 2);
			textSprite.Scale = 3;
			textSprite.Position = position;
			textSprite.Origin = new Vector2(0, 0);
			textSprite.Active = true;
			textSprite.SetFrame(0);
			return textSprite;
		}

	}
}
