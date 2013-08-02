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

		/// <summary>
		/// Allows the game component to perform any initialization it needs to before starting
		/// to run.  This is where it can query for any required services and load content.
		/// </summary>
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

		protected override void LoadContent()
		{
			textTexture = Game.Content.Load<Texture2D>("Sprites/Totodile");
			textBatch = new SpriteBatch(Game.GraphicsDevice);
			base.LoadContent();
		}

		/// <summary>
		/// Allows the game component to update itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			int currentScore = board.score;
			int scoreDigit;
			for (int i = 0; i < 6; i++)
			{
				scoreDigit = (currentScore % (int)(Math.Pow(10, (i + 1))) / (int)(Math.Pow(10, i)));
				if (scoreDigit < 10)
				{
					score[i].SetFrame(scoreDigit);
				}
				else
				{
					score[i].SetFrame(11);
				}
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

				int timeDigit;

				for (int i = 0; i < 2; i++)
				{
					timeDigit = (seconds % (int)(Math.Pow(10, (i + 1))) / (int)(Math.Pow(10, i)));
					if (timeDigit < 10)
					{ 
						secondsSprites[i].SetFrame(timeDigit);
					}
					else
					{
						secondsSprites[i].SetFrame(11);
					}
				}

				for (int i = 0; i < 2; i++)
				{
					timeDigit = (minutes % (int)(Math.Pow(10, (i + 1))) / (int)(Math.Pow(10, i)));
					if (timeDigit < 10)
					{
						minutesSprites[i].SetFrame(timeDigit);
					}
					else
					{
						minutesSprites[i].SetFrame(11);
					}
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
	}
}
