using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Breakout
{
    public class Paddle : GameObject
    {
        private Stage _stage;
        private Vector2 _initialPosition;

        protected Texture2D _texture;
        protected Rectangle _drawRect;
        private float _speed;
        private float _direction;

        public int width
        {
            get { return _drawRect.Width; }
        }

        public int height
        {
            get { return _drawRect.Height; }
        }

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

        public Paddle(Game game, SpriteBatch spriteBatch) : base(game, spriteBatch) { }

        public void Initialize(Stage stage, int x, int y, int w, int h)
        {
            _stage = stage;

            _texture = new Texture2D(GraphicsDevice, 1, 1);
            var data = new Color[1];
            data[0] = Color.White;
            _texture.SetData(data);

            _drawRect = new Rectangle(0, 0, w, h);
            _initialPosition = new Vector2(x, y);
            _speed = 0.5f;
            _direction = 0f;

            Reset();
        }

        public void MoveLeft()
        {
            _direction = -1f;
        }

        public void MoveRight()
        {
            _direction = 1f;
        }

        public void StopMoving()
        {
            _direction = 0f;
        }

        public void Reset()
        {
            _position = _initialPosition;
            _direction = 0f;
        }

        public void Update(GameTime gameTime, KeyboardState kstate)
        {
            if (kstate.IsKeyDown(Keys.Left))
            {
                MoveLeft();
            }
            else if (kstate.IsKeyDown(Keys.Right))
            {
                MoveRight();
            }
            else
            {
                StopMoving();
            }

            _position.X += _speed * _direction * gameTime.ElapsedGameTime.Milliseconds;

            if (_position.X < 0)
            {
                _position.X = 0;
            }
            if (_position.X > _stage.width - _drawRect.Width)
            {
                _position.X = _stage.width - _drawRect.Width;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(_texture, this.hitbox, null, Color.White);
        }
    }
}
