using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class Sprite : Component
    {
        protected Texture2D _texture;
        protected Rectangle _drawRect;

        protected void SetTexture(Texture2D tex)
        {
            _texture = tex;
        }

        override public void Update()
        {
            // TODO: animation
        }

        override public void Draw()
        {
            Core.spriteBatch.Draw(_texture, _drawRect, null, Color.White);
        }
    }
}
