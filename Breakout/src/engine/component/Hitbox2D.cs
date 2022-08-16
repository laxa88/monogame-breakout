using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class Hitbox2D : Component
    {
        static Texture2D _debugTexture;
        static Rectangle _debugRect;
        static Color _debugColor;
        static int _debugLineWidth;

        protected Rectangle _hitbox;
        public Rectangle hitbox
        {
            get { return _hitbox; }
        }

        public Hitbox2D(int x, int y, int w, int h)
        {
            _debugRect = new Rectangle();
            _debugColor = Color.Red;
            _debugLineWidth = 1;

            _hitbox = new Rectangle(x, y, w, h);
        }

        public void SetHitbox(int x, int y, int w, int h)
        {
            _hitbox = new Rectangle(x, y, w, h);
        }

        public bool IsIntersect(Hitbox2D other)
        {
            return (
                _parent.position.X + _hitbox.X
                    < other._parent.position.X + other.hitbox.X + other.hitbox.Width
                && _parent.position.X + _hitbox.X + _hitbox.Width
                    > other._parent.position.X + other.hitbox.X
                && _parent.position.Y + _hitbox.Y
                    < other._parent.position.Y + other.hitbox.Y + other.hitbox.Height
                && _parent.position.Y + _hitbox.Y + _hitbox.Height
                    > other._parent.position.Y + other.hitbox.Y
            );
        }

        public void SetDebugColor(Color c)
        {
            _debugColor = c;
        }

        public void DebugDraw()
        {
            if (_debugTexture == null)
            {
                _debugTexture = new Texture2D(Core.spriteBatch.GraphicsDevice, 1, 1);
                _debugTexture.SetData<Color>(new Color[] { Color.Red });
            }

            Rectangle rect = new Rectangle(
                (int)_parent.position.X + hitbox.X,
                (int)_parent.position.Y + hitbox.Y,
                hitbox.Width,
                hitbox.Height
            );

            if (
                _debugRect.X != rect.X
                || _debugRect.Y != rect.Y
                || _debugRect.Width != rect.Width
                || _debugRect.Height != rect.Height
            )
            {
                Core.spriteBatch.Draw(
                    _debugTexture,
                    new Rectangle(
                        _debugRect.X,
                        _debugRect.Y,
                        _debugLineWidth,
                        _debugRect.Height + _debugLineWidth
                    ),
                    _debugColor
                );
                Core.spriteBatch.Draw(
                    _debugTexture,
                    new Rectangle(
                        _debugRect.X,
                        _debugRect.Y,
                        _debugRect.Width + _debugLineWidth,
                        _debugLineWidth
                    ),
                    _debugColor
                );
                Core.spriteBatch.Draw(
                    _debugTexture,
                    new Rectangle(
                        _debugRect.X + _debugRect.Width,
                        _debugRect.Y,
                        _debugLineWidth,
                        _debugRect.Height + _debugLineWidth
                    ),
                    _debugColor
                );
                Core.spriteBatch.Draw(
                    _debugTexture,
                    new Rectangle(
                        _debugRect.X,
                        _debugRect.Y + _debugRect.Height,
                        _debugRect.Width + _debugLineWidth,
                        _debugLineWidth
                    ),
                    _debugColor
                );
            }

            Core.spriteBatch.Draw(_debugTexture, rect, null, Color.White);
        }
    }
}
