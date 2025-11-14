using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Cellular_Automaton
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D whitePixelTexture;
        public static TileMap tileMap;
        public static Point point = Point.Zero;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            whitePixelTexture = new Texture2D(GraphicsDevice, 1, 1);
            whitePixelTexture.SetData(new Color[] { Color.White });
            Game1.tileMap = new TileMap(70, 50, whitePixelTexture);
            foreach (Tile t in TileMap.Tiles)
            {
                Components.Add(t);
            }
            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void Update(GameTime gameTime)
        {
            foreach (Tile t in TileMap.Tiles)
            {
                t.Update(gameTime);
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState ms = Mouse.GetState();
            Game1.point = ms.Position;
            if (ms.LeftButton == ButtonState.Pressed)
            {
                tileMap.ChangeType(ms.Position, Tile.TileType.ALIVE);
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            tileMap.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
