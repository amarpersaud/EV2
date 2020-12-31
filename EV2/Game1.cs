using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.CExtended;


namespace EV2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont dfont;
        private InputHelper ih = new InputHelper();
        private FrameCounter fc = new FrameCounter();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            dfont = Content.Load<SpriteFont>("fonts/basicfont");
        }

        protected override void Update(GameTime gameTime)
        {
            ih.Update();

            if (ih.ExitRequested)
            {
                Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            fc.Update(deltaTime);

            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _spriteBatch.DrawString(dfont, $"Avg {fc.AverageFramesPerSecond.ToString("f2")} Current {fc.CurrentFramesPerSecond.ToString("f2")}", new Vector2(20, 20), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
