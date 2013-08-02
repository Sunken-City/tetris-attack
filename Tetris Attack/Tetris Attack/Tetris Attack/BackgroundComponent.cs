using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris_Attack
{
	/// <summary>
	/// This is a game component that implements IUpdateable.
	/// </summary>
	public class BackgroundComponent : Microsoft.Xna.Framework.DrawableGameComponent
	{
		Texture2D backgroundTexture;
		Sprite[][] background = new Sprite[8][];
		SpriteBatch bgBatch;
		private string path;


		public BackgroundComponent(Game game, string theme)
			: base(game)
		{
			loadTheme(theme);
		}

		public void loadTheme(string name)
		{
			if (name == "Totodile")
				path = "Sprites/Totodile";
			else if (name == "Pikachu")
				path = "Sprites/Pikachu";
			else if (name == "Cyndaquil")
				path = "Sprites/Cyndaquil";
			else if (name == "Chikorita")
				path = "Sprites/Chikorita";
			else if (name == "Marill")
				path = "Sprites/Marill";
		}

		/// <summary>
		/// Allows the game component to perform any initialization it needs to before starting
		/// to run.  This is where it can query for any required services and load content.
		/// </summary>
		public override void Initialize()
		{
			base.Initialize();
			for (int i = 0; i < 8; i++)
			{
				background[i] = new Sprite[11];
				for (int j = 0; j < 11; j++)
				{
					Sprite backgroundTile = new Sprite(backgroundTexture, new Rectangle(151, 72, 15, 15));
					backgroundTile.Scale = 3;
					backgroundTile.Position = new Vector2(i * 45 - 45, j * 45 + 45);
					backgroundTile.Velocity = new Vector2(-1, 1);
					backgroundTile.Origin = new Vector2(0, 45);
					backgroundTile.ZLayer = 1f;
					background[i][j] = backgroundTile;
				}
			}
		}

		protected override void LoadContent()
		{
			backgroundTexture = Game.Content.Load<Texture2D>(path);
			bgBatch = new SpriteBatch(Game.GraphicsDevice);

			base.LoadContent();
		}

		/// <summary>
		/// Allows the game component to update itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public override void Update(GameTime gameTime)
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 11; j++)
				{
					var tile = background[i][j];
					if ((tile.Position.X += tile.Velocity.X) < -89)
					{
						tile.Position.X = 270;
					}
					if ((tile.Position.Y += tile.Velocity.Y) > 539)
					{
						tile.Position.Y = 45;
					}
				}
			}
			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			bgBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 11; j++)
				{
					background[i][j].Draw(gameTime, bgBatch);
				}
			}
			bgBatch.End();
			base.Draw(gameTime);
		}
	}
}
