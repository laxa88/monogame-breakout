using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout
{
    public class Lives : GameObject
    {
        private SpriteFont _font;
        private int _lives;

        public Lives(Game game, SpriteBatch spriteBatch) : base(game, spriteBatch) { }

        override public void Initialize()
        {
            base.Initialize();

            _lives = 0;

            LoadContent();
        }

        override protected void LoadContent()
        {
            _font = this.Game.Content.Load<SpriteFont>("score");
        }

        public override void Draw(GameTime gameTime)
        {
            string str = _lives >= 0 ? $"Lives: {_lives}" : "Game over";

            Vector2 rect = _font.MeasureString(str);

            _spriteBatch.DrawString(
                _font,
                str,
                new Vector2(10, Constants.GAME_HEIGHT - rect.Y - 10),
                Color.White
            );
        }

        public void SetLives(int lives)
        {
            _lives = lives;
        }

        /// <summary>
        /// Deducts a life. Returns a boolean whether the game is over.
        /// </summary>
        public bool LoseLife()
        {
            _lives -= 1;

            return _lives < 0;
        }
    }
}
