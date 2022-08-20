using Microsoft.Xna.Framework;

namespace Breakout
{
    public enum BlockType
    {
        Weak,
        Normal,
        Strong,
    }

    public class Block : DrawableGameComponent
    {
        protected Vector2 _position;
        BlockType _blockType;
        int _health;

        public Block(Game game, int x, int y, int w, int h) : base(game)
        {
            _position = new Vector2(x, y);
        }

        public void Initialize(BlockType blockType)
        {
            switch (blockType)
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
        }

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
