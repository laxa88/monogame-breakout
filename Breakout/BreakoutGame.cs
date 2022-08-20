using System;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Breakout
{
    public class BreakoutGame : Game
    {
        // Engine

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private RenderTarget2D _renderBuffer;
        private Rectangle _renderRectangle;

        // Game

        private Stage _stage;
        private Block[] _blocks;
        private Paddle _paddle;
        private Ball _ball;

        public BreakoutGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            // Note: Doesn't work if you set in constructor
            Window.Title = "My Pong Game";

            Sound.Initialize(this);
            // Sound.LoadSoundEffect(Constants.SFX_ROUND_END);

            Music.Initialize(this);
            // Music.LoadMusic(Constants.BGM);
            // Music.PlayMusic(Constants.BGM, true);

            _graphics.PreferredBackBufferWidth = 600;
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _renderBuffer = new RenderTarget2D(GraphicsDevice, 600, 800);

            // Add callbacks

            Window.ClientSizeChanged += OnWindowSizeChange;
            OnWindowSizeChange(null, null);

            // TODO: start game
        }

        private void InitializeStage()
        {
            // TODO
            // initialize stage
            // initialize blocks
            // initialize paddle
            // initialize ball
        }

        private void OnWindowSizeChange(object sender, EventArgs e)
        {
            var width = Window.ClientBounds.Width;
            var height = Window.ClientBounds.Height;

            if (height < width / (float)_renderBuffer.Width * _renderBuffer.Height)
            {
                width = (int)(height / (float)_renderBuffer.Height * _renderBuffer.Width);
            }
            else
            {
                height = (int)(width / (float)_renderBuffer.Width * _renderBuffer.Height);
            }

            var x = (Window.ClientBounds.Width - width) / 2;
            var y = (Window.ClientBounds.Height - height) / 2;
            _renderRectangle = new Rectangle(x, y, width, height);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (
                GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape)
            )
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Target buffer screen (original resolution)
            GraphicsDevice.SetRenderTarget(_renderBuffer);
            GraphicsDevice.Clear(Color.Black);

            // Draw everything game-related on this buffer screen.
            _spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointClamp);
            // TODO: draw GameObjects here
            _spriteBatch.End();

            // Target main window, reset background colour
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw the buffer screen onto the main window,
            // resized with PointClamp to create pixel-perfect effect.
            _spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointClamp);
            _spriteBatch.Draw(_renderBuffer, _renderRectangle, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
