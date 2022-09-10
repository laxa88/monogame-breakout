using System;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout
{
    public class Lives : GameObject
    {
        private SpriteFont _font;
        private int _lives;
        public event EventHandler onGameOver;

        public Lives(Game game, SpriteBatch spriteBatch) : base(game, spriteBatch) { }

        override public void Initialize()
        {
            base.Initialize();
            LoadContent();
            Reset();
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

        public void Reset()
        {
            _lives = 2;
        }

        public void LoseLife()
        {
            _lives -= 1;

            if (_lives < 0)
            {
                onGameOver(this, EventArgs.Empty);
            }
        }
    }
}
