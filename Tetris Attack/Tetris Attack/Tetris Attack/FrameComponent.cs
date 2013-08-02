using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Xml.Linq;

namespace Tetris_Attack
{
	/// <summary>
	/// This is a game component that implements IUpdateable.
	/// </summary>
	public class FrameComponent : Microsoft.Xna.Framework.DrawableGameComponent
	{
		Texture2D frameTexture;
		Sprite frame;
		Sprite pokemon;
		SpriteBatch frameBatch;
		string path;

		public FrameComponent(Game game, string theme)
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
			frame = new Sprite(frameTexture, new Rectangle(10, 10, 63, 143));
			frame.Scale = 3;
			frame.Position = new Vector2(270, 0);
			frame.ZLayer = 1f;
			pokemon = new Sprite(frameTexture, new Rectangle(198, 55, 34, 34));
			pokemon.Scale = 3;
			pokemon.Position = new Vector2(315, 237);
			frame.ZLayer = 0f;
			pokemon.Active = true;
		}

		protected override void LoadContent()
		{
			frameTexture = Game.Content.Load<Texture2D>(path);
			frameBatch = new SpriteBatch(Game.GraphicsDevice);

			base.LoadContent();
		}

		/// <summary>
		/// Allows the game component to update itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public override void Update(GameTime gameTime)
		{

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			frameBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);
			frame.Draw(gameTime, frameBatch);
			pokemon.Draw(gameTime, frameBatch);
			frameBatch.End();
			base.Draw(gameTime);
		}
	}
}
