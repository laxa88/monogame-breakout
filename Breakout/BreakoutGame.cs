using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;

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
        private List<Block> _blocks;
        private Paddle _paddle;
        private Ball _ball;
        private Score _score;

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
            Window.Title = "My Breakout Game";

            Sound.Initialize(this);
            // Sound.LoadSoundEffect(Constants.SFX_ROUND_END);

            Music.Initialize(this);
            Music.LoadMusic(Constants.BGM);
            Music.PlayMusic(Constants.BGM, true);

            _graphics.PreferredBackBufferWidth = Constants.WINDOW_WIDTH;
            _graphics.PreferredBackBufferHeight = Constants.WINDOW_HEIGHT;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _renderBuffer = new RenderTarget2D(
                GraphicsDevice,
                Constants.GAME_WIDTH,
                Constants.GAME_HEIGHT
            );

            _score = new Score(this, _spriteBatch);
            _score.Initialize();

            _stage = new Stage(this, _spriteBatch, Constants.GAME_WIDTH, Constants.GAME_HEIGHT);
            _stage.Initialize();

            _paddle = new Paddle(this, _spriteBatch);
            _paddle.Initialize(
                _stage,
                _stage.width / 2 - Constants.PADDLE_WIDTH / 2,
                _stage.height - 60,
                Constants.PADDLE_WIDTH,
                Constants.PADDLE_HEIGHT
            );

            _blocks = new List<Block>();
            using (StreamReader r = new StreamReader("Breakout/Content/stage_01.json"))
            {
                string json = r.ReadToEnd();
                JsonConvert
                    .DeserializeObject<List<int>>(json)
                    .Select((x, i) => new { item = x, index = i })
                    .ToList()
                    .ForEach(obj =>
                    {
                        if (obj.item != 0)
                        {
                            Block block = new Block(this, _spriteBatch, obj.item, obj.index);
                            block.Initialize();
                            _blocks.Add(block);
                        }
                    });
            }

            _ball = new Ball(this, _spriteBatch);
            _ball.Initialize(
                _stage,
                _paddle,
                _blocks,
                _score,
                Constants.BALL_SIZE,
                Constants.BALL_SIZE
            );
            _ball.BallExitedBottom += OnPlayerLoseBall;

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
            var kstate = Keyboard.GetState();

            if (
                GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || kstate.IsKeyDown(Keys.Escape)
            )
                Exit();

            _paddle.Update(gameTime, kstate);
            _ball.Update(gameTime, kstate);

            // TODO check win condition (when blocks list is empty)
            // TODO check lose condition (when lives is zero)

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Target buffer screen (original resolution)
            GraphicsDevice.SetRenderTarget(_renderBuffer);
            GraphicsDevice.Clear(Color.Black);

            // Draw everything game-related on this buffer screen.
            _spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointClamp);
            _stage.Draw(gameTime);
            _paddle.Draw(gameTime);
            _blocks.ForEach(
                (Block block) =>
                {
                    block.Draw(gameTime);
                }
            );
            _ball.Draw(gameTime);
            _score.Draw(gameTime);
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

        protected void OnPlayerLoseBall(object sender, EventArgs e)
        {
            // TODO
            // - check remaining balls
            // - if zero, lose a life
            _ball.Reset();
        }
    }
}
