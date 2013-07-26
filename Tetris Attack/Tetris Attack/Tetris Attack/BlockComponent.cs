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
	public class BlockComponent : Microsoft.Xna.Framework.DrawableGameComponent
	{
		Texture2D blockTexture;
		SpriteBatch blockBatch;

		public BlockComponent(Game game)
			: base(game)
		{
			// TODO: Construct any child components here
		}

		protected override void LoadContent()
		{
			blockTexture = Game.Content.Load<Texture2D>("Sprites/Blocks");
			blockBatch = new SpriteBatch(Game.GraphicsDevice);

			base.LoadContent();
		}

		public Rectangle getBlockTexture(int blockType)
		{
			Rectangle rect;
			if (blockType == 1)
			{
				rect = new Rectangle(9,10,15,15);
			}
			else if (blockType == 2)
			{
				rect = new Rectangle(30, 10, 15, 15);
			}
			else if (blockType == 3)
			{
				rect = new Rectangle(51, 10, 15, 15);
			}
			else if (blockType == 4)
			{
				rect = new Rectangle(72, 10, 15, 15);
			}
			else if (blockType == 5)
			{
				rect = new Rectangle(93, 10, 15, 15);
			}
			else if (blockType == 6)
			{
				rect = new Rectangle(114, 10, 15, 15);
			}
			else
			{
				rect = new Rectangle(135, 10, 15, 15);
			}

			return rect;
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
			// TODO: Add your initialization code here

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
	}
}
