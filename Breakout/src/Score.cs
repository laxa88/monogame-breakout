using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout
{
    public class Score : GameObject
    {
        private SpriteFont _font;
        private int _score;
        private int _hiscore;

        public Score(Game game, SpriteBatch spriteBatch) : base(game, spriteBatch) { }

        override public void Initialize()
        {
            base.Initialize();

            _score = 0;
            _hiscore = 0;

            LoadContent();
        }

        override protected void LoadContent()
        {
            _font = this.Game.Content.Load<SpriteFont>("score");
        }

        public override void Draw(GameTime gameTime)
        {
            string scoreStr = $"{_score}".PadLeft(10, '0');
            string leftStr = $"Score: {scoreStr}";

            string hiscoreStr = $"{_hiscore}".PadLeft(10, '0');
            string rightStr = $"Hi-score: {hiscoreStr}";
            Vector2 rect = _font.MeasureString(rightStr);

            _spriteBatch.DrawString(_font, leftStr, new Vector2(10, 10), Color.White);
            _spriteBatch.DrawString(
                _font,
                rightStr,
                new Vector2(Constants.GAME_WIDTH - 10 - rect.X, 10),
                Color.White
            );
        }
    }
}
