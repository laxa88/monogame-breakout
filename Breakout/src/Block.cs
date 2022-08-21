using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout
{
    public enum BlockType
    {
        Weak,
        Normal,
        Strong,
    }

    public class Block : GameObject
    {
        protected Texture2D _texture;
        protected Rectangle _drawRect;

        int _positionIndex;
        BlockType _blockType;
        int _health;

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

        private BlockType GetBlockType(int blockType)
        {
            switch (blockType)
            {
                case 3:
                    return BlockType.Strong;
                case 2:
                    return BlockType.Normal;
                case 1:
                default:
                    return BlockType.Weak;
            }
        }

        private Color GetColorByHealth()
        {
            switch (_health)
            {
                case 1:
                    return Color.Red;
                case 2:
                    return Color.Yellow;
                case 3:
                default:
                    return Color.Green;
            }
        }

        public Block(Game game, SpriteBatch spriteBatch, int blockType, int positionIndex)
            : base(game, spriteBatch)
        {
            _blockType = GetBlockType(blockType);
            _positionIndex = positionIndex;
        }

        public override void Initialize()
        {
            switch (_blockType)
            {
                case BlockType.Strong:
                    _health = 3;
                    break;
                case BlockType.Normal:
                    _health = 2;
                    break;
                case BlockType.Weak:
                default:
                    _health = 1;
                    break;
            }

            _texture = new Texture2D(GraphicsDevice, 1, 1);
            var data = new Color[1];
            data[0] = Color.White;
            _texture.SetData(data);

            int indexX = _positionIndex % Constants.BLOCK_COLUMNS;
            int indexY = _positionIndex / Constants.BLOCK_COLUMNS;
            int w = Constants.GAME_WIDTH / Constants.BLOCK_COLUMNS - Constants.BLOCK_PADDING / 2;
            int h = Constants.GAME_HEIGHT / Constants.BLOCK_ROWS - Constants.BLOCK_PADDING / 2;

            _position = new Vector2(
                Constants.BLOCK_PADDING / 2 + indexX * (w + Constants.BLOCK_PADDING / 2),
                Constants.BLOCK_PADDING / 2 + indexY * (h + Constants.BLOCK_PADDING / 2)
            );
            _drawRect = new Rectangle(0, 0, w, h);

            Activate();
        }

        public override void Draw(GameTime gameTime)
        {
            if (Enabled)
            {
                _spriteBatch.Draw(_texture, this.hitbox, null, GetColorByHealth());
            }
        }

        public void Hurt()
        {
            _health -= 1;

            if (_health <= 0)
            {
                Deactivate();
            }
        }
    }
}
