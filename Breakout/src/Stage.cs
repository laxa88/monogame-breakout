using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout
{
    public class Stage : GameObject
    {
        private RenderTarget2D _renderTarget;
        private Texture2D _texture;

        public int width
        {
            get { return _renderTarget.Width; }
        }

        public int height
        {
            get { return _renderTarget.Height; }
        }

        public Stage(Game game, SpriteBatch spriteBatch, int width, int height)
            : base(game, spriteBatch)
        {
            _renderTarget = new RenderTarget2D(GraphicsDevice, width, height);
        }

        public override void Initialize()
        {
            _texture = new Texture2D(GraphicsDevice, 1, 1);
            var data = new Color[1];
            data[0] = Color.White;
            _texture.SetData(data);

            // TODO: draw stage background?
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(
                _renderTarget,
                new Rectangle(0, 0, _renderTarget.Width, _renderTarget.Height),
                Color.White
            );
        }
    }
}
