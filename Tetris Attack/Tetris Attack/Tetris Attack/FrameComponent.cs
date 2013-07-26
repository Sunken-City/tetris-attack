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
	public class FrameComponent : Microsoft.Xna.Framework.DrawableGameComponent
	{
		Texture2D frameTexture;
		Sprite frame;
		SpriteBatch frameBatch;

		public FrameComponent(Game game)
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
			frame = new Sprite(frameTexture, new Rectangle(10, 10, 63, 143));
			frame.Scale = 3;
			frame.Position = new Vector2(180, 0);

		}

		protected override void LoadContent()
		{
			frameTexture = Game.Content.Load<Texture2D>("Sprites/Totodile");
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
			frameBatch.Begin();
			frame.Draw(gameTime, frameBatch);
			frameBatch.End();
			base.Draw(gameTime);
		}
	}
}
