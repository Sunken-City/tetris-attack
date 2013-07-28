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
	public class BackgroundComponent: Microsoft.Xna.Framework.DrawableGameComponent
	{
		Texture2D backgroundTexture;
		Sprite[][] background = new Sprite[7][];
		SpriteBatch bgBatch;


		public BackgroundComponent(Game game)
			: base(game)
		{
			// TODO: Construct any child components here
		}

		/// <summary>
		/// Allows the game component to perform any initialization it needs to before starting
		/// to run.  This is where it can query for any required services and load content.
		/// </summary>
		public override void Initialize()
		{
			base.Initialize();
			for (int i = 0; i < 7; i++)
			{
				background[i] = new Sprite[10];
				for (int j = 0; j < 10; j++)
				{
					Sprite backgroundTile = new Sprite(backgroundTexture, new Rectangle(151, 72, 15, 15));
					backgroundTile.Scale = 3;
					backgroundTile.Position = new Vector2(i * 45 , j * 45);
					backgroundTile.Velocity = new Vector2(-1, 1);
					backgroundTile.Origin = new Vector2(15, 15);
					backgroundTile.ZLayer = 1f;
					background[i][j] = backgroundTile;
				}
			}
			
			

		}

		protected override void LoadContent()
		{
			backgroundTexture = Game.Content.Load<Texture2D>("Sprites/Totodile");
			bgBatch = new SpriteBatch(Game.GraphicsDevice);

			base.LoadContent();
		}

		/// <summary>
		/// Allows the game component to update itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public override void Update(GameTime gameTime)
		{
			for (int i = 0; i < 7; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					var tile = background[i][j];
					if ((tile.Position.X += tile.Velocity.X) < -30)
					{
						tile.Position.X = 285;
					}
					if ((tile.Position.Y += tile.Velocity.Y) > 450)
					{
						tile.Position.Y = 0;
					}
				}
			}
			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			bgBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);
			for (int i = 0; i < 7; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					background[i][j].Draw(gameTime, bgBatch);
				}
			}
			bgBatch.End();
			base.Draw(gameTime);
		}
	}
}
