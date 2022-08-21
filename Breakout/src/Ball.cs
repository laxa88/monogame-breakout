using System;
using System.Collections.Generic;
using System.Diagnostics;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Breakout
{
    public enum BallState
    {
        Init,
        Active,
    }

    public class Ball : GameObject
    {
        private Stage _stage;
        private Paddle _paddle;
        private List<Block> _blocks;

        private float _initialSpeed;

        protected Texture2D _texture;
        protected Rectangle _drawRect;
        private Vector2 _direction;
        private float _speed;
        private BallState _state;

        public Rectangle hitbox
        {
            get
            {
                return new Rectangle(
                    (int)_position.X,
                    (int)_position.Y,
                    _drawRect.Width,
                    _drawRect.Height
                );
            }
        }

        public Vector2 center
        {
            get
            {
                return new Vector2(
                    _position.X + _drawRect.Width / 2,
                    _position.Y + _drawRect.Height / 2
                );
            }
        }

        public event EventHandler BallExitedBottom;

        public Ball(Game game, SpriteBatch spriteBatch) : base(game, spriteBatch) { }

        public void Initialize(Stage stage, Paddle paddle, List<Block> blocks, int w, int h)
        {
            _stage = stage;
            _paddle = paddle;
            _blocks = blocks;

            _drawRect = new Rectangle(0, 0, w, h);
            _initialSpeed = 0.4f;

            LoadContent();

            Reset();
        }

        override protected void LoadContent()
        {
            _texture = this.Game.Content.Load<Texture2D>(Constants.IMG_BALL);
            Sound.LoadSoundEffect(Constants.SFX_BOUNCE);
            Sound.LoadSoundEffect(Constants.SFX_EXPLOSION);
        }

        public void Update(GameTime gameTime, KeyboardState kstate)
        {
            switch (_state)
            {
                case BallState.Active:
                    Vector2 velocity = new Vector2(
                        _direction.X * _speed * gameTime.ElapsedGameTime.Milliseconds,
                        _direction.Y * _speed * gameTime.ElapsedGameTime.Milliseconds
                    );
                    _position += velocity;

                    if (_position.X < 0)
                    {
                        Sound.PlaySfx(Constants.SFX_BOUNCE);
                        _direction.X = Math.Abs(_direction.X);
                    }

                    if (_position.X > _stage.width - hitbox.Width)
                    {
                        Sound.PlaySfx(Constants.SFX_BOUNCE);
                        _direction.X = -Math.Abs(_direction.X);
                    }

                    if (_position.Y < 0)
                    {
                        Sound.PlaySfx(Constants.SFX_BOUNCE);
                        _direction.Y = Math.Abs(_direction.Y);
                    }

                    if (_direction.Y > 0 && this.hitbox.Intersects(_paddle.hitbox))
                    {
                        Sound.PlaySfx(Constants.SFX_BOUNCE);
                        _direction.Y = -Math.Abs(_direction.Y);
                        SetNewDirection();
                    }

                    for (int i = _blocks.Count - 1; i >= 0; i--)
                    {
                        Block block = _blocks[i];

                        Rectangle? possibleIntersection = Collision.Intersects(
                            this.hitbox,
                            block.hitbox
                        );

                        if (possibleIntersection == null)
                        {
                            continue;
                        }

                        Rectangle intersection = possibleIntersection ?? Rectangle.Empty;

                        Vector2 to = block.center - this.center;
                        Vector2 to_signum = new Vector2(Math.Sign(to.X), Math.Sign(to.Y));
                        if (intersection.Height < intersection.Width)
                        {
                            _position.Y -= to_signum.Y * intersection.Height;
                            _direction.Y = -to_signum.Y * Math.Abs(_direction.Y);
                        }
                        else
                        {
                            _position.X -= to_signum.X * intersection.Width;
                            _direction.X = -to_signum.X * Math.Abs(_direction.X);
                        }

                        Sound.PlaySfx(Constants.SFX_BOUNCE);
                        block.Hurt();

                        if (!block.Enabled)
                        {
                            _blocks.RemoveAt(i);
                        }
                    }

                    if (_position.Y > _stage.height + 40)
                    {
                        Sound.PlaySfx(Constants.SFX_EXPLOSION);
                        BallExitedBottom(this, EventArgs.Empty);
                    }

                    break;

                case BallState.Init:
                default:
                    _position = new Vector2(
                        _paddle.position.X + _paddle.width / 2 - hitbox.Width / 2,
                        _paddle.position.Y - hitbox.Height
                    );

                    if (kstate.IsKeyDown(Keys.Space))
                    {
                        _state = BallState.Active;
                    }
                    break;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(_texture, this.hitbox, null, Color.White);
        }

        /// <summary>
        /// Sets new ball trajectory based on paddle collision point
        /// </summary>
        private void SetNewDirection()
        {
            Vector2 vec = Vector2.Normalize(this.center - _paddle.center);
            _direction = Vector2.Normalize(new Vector2(vec.X, _direction.Y));
        }

        /// <summary>
        /// Reset the state of the ball (stick to paddle)
        /// </summary>
        public void Reset()
        {
            _state = BallState.Init;

            // angle fixed at north-east
            _direction = Vector2.Normalize(new Vector2(1, -1));

            _speed = _initialSpeed;
        }
    }
}
