using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class Core
    {
        private static Game _game;
        private static SpriteBatch _spriteBatch;
        public static SpriteBatch spriteBatch
        {
            get { return _spriteBatch; }
        }

        public static void Initialize(Game game, SpriteBatch sb)
        {
            _game = game;
            _spriteBatch = sb;
        }
    }
}
