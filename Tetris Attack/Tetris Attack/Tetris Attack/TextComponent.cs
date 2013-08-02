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
		SpriteBatch textBatch;
		Board board;

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
				Sprite blueSprite = new Sprite(textTexture, new Rectangle(77, 115, 7, 12), 10, true, 2);
				blueSprite.Scale = 3;
				blueSprite.Position = new Vector2(414 - (21 * i + 2 * i), 102);
				blueSprite.Origin = new Vector2(0, 0);
				blueSprite.Active = true;
				blueSprite.SetFrame(0);
				score[i] = blueSprite;
			}
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
			}
		}

		public override void Draw(GameTime gameTime)
		{
			textBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);
			for (int i = 0; i < 6; i++)
			{
				score[i].Draw(gameTime, textBatch);
			}
			textBatch.End();
			base.Draw(gameTime);
		}
	}
}
