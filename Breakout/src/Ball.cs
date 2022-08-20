using Microsoft.Xna.Framework;

namespace Breakout
{
    public class Ball : DrawableGameComponent
    {
        protected Vector2 _position;

        public Ball(Game game) : base(game)
        {
            // TODO initialize sprite and hitbox
        }

        public void Reset()
        {
            // Reset ball position to top of Paddle
        }

        // TODO move/bounce logic
        // TODO out-of-bound logic

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
