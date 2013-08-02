using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Tetris_Attack
{
	public class TetrisAttack : Microsoft.Xna.Framework.Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		public Board board;
		public readonly FrameComponent frameComponent;
		public readonly BackgroundComponent backgroundComponent;
		public readonly BlockComponent blockComponent;
		public readonly CursorComponent cursorComponent;
		public readonly TextComponent textComponent;

		public string themeName = "Pikachu";

		TimeSpan timePerPush = TimeSpan.FromMilliseconds(10000);
		TimeSpan timePassed;

		Song chill;
		Song fever;

		private bool dangerToggle = false;

		public TetrisAttack()
		{
			graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferHeight = 405;
			graphics.PreferredBackBufferWidth = 459;
			Content.RootDirectory = "Content";
			board = Board.BuildNewBoard();
			Components.Add(backgroundComponent = new BackgroundComponent(this, themeName));
			Components.Add(frameComponent = new FrameComponent(this, themeName));
			Components.Add(blockComponent = new BlockComponent(this, board));
			Components.Add(cursorComponent = new CursorComponent(this, board));
			Components.Add(textComponent = new TextComponent(this, board));
		}

		protected override void Initialize()
		{
			base.Initialize();
			MediaPlayer.IsRepeating = true;
			MediaPlayer.Play(chill);
		}

		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
			chill = Content.Load<Song>("Audio/Music/Mahogany Gym");
			fever = Content.Load<Song>("Audio/Music/Danger (Gym Battle)");
		}

		protected override void UnloadContent()
		{

		}

		protected override void Update(GameTime gameTime)
		{
			// Allows the game to exit
			var ks = Keyboard.GetState();
			if (ks.IsKeyDown(Keys.Escape))
				this.Exit();

			if ((timePassed += gameTime.ElapsedGameTime) > timePerPush)
			{
				timePassed = TimeSpan.Zero;
				board.PushBlocks();
			}

			if (dangerToggled())
			{
				if (dangerToggle)
				{
					MediaPlayer.Play(fever);
				}
				else
				{
					MediaPlayer.Play(chill);
				}				
			}


			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			base.Draw(gameTime);
		}

		private bool dangerToggled()
		{
			if (board.inDanger != dangerToggle)
			{
				dangerToggle = board.inDanger;
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
