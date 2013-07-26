using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Tetris_Attack
{
	public class Sprite
	{
		public Texture2D Texture { get; private set; }
		public Vector2 Position;
		public Vector2 Velocity;
		public Vector2 Origin;
		public bool Active = true;
		public float Scale = 1;
		public float Rotation;
		public float ZLayer;

		public int TotalFrames { get; private set; }
		public int FrameWidth { get { return _rects == null ? Texture.Width : _rects[0].Width; } }
		public TimeSpan AnimationInterval;

		private Rectangle[] _rects;
		private System.TimeSpan _animElapsed;
		private int _currentFrame;
		private Color color = Color.White;


		public Sprite(Texture2D texture, Rectangle? firstRect = null, int frames = 1, bool horizontal = true, int space = 0)
		{
			Texture = texture;
			TotalFrames = frames;
			if (firstRect != null)
			{
				_rects = new Rectangle[frames];
				Rectangle first = (Rectangle)firstRect;
				for (int i = 0; i < frames; i++)
					_rects[i] = new Rectangle(first.Left + (horizontal ? (first.Width + space) * i : 0),
					   first.Top + (horizontal ? 0 : (first.Height + space) * i), first.Width, first.Height);
			}
		}

		public virtual void Update(GameTime gameTime)
		{
			if (Active)
			{
				if (TotalFrames > 1 && (_animElapsed += gameTime.ElapsedGameTime) > AnimationInterval)
				{
					if (++_currentFrame == TotalFrames)
						_currentFrame = 0;
					_animElapsed -= AnimationInterval;
				}
				Position += Velocity;
			}
		}

		public virtual void Draw(GameTime gameTime, SpriteBatch batch)
		{
			if (Active)
			{
				batch.Draw(Texture, Position, _rects == null ? null : (Rectangle?)_rects[_currentFrame],
				   color, Rotation, Origin, Scale, SpriteEffects.None, ZLayer);
			}
		}
	}
}
