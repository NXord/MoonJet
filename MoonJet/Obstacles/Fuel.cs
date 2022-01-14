using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MoonJet
{
    public class Fuel : Game
    {
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        private Texture2D _textureFuel;
        private Vector2 _positionFuel;
        public const int LARGEUR_FUEL = 50;
        public const int HAUTEUR_FUEL = 57;
        private Rectangle _rectangleFuel;
        private int _pasFuel;
        private float _chronoFuel;
        private float _chroneFuelApp;
        public Random r = new Random();

        public Fuel()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            _pasFuel = 100;

            _positionFuel = new Vector2(r.Next(0, GraphicsDevice.Viewport.Width - LARGEUR_FUEL), 0);
            _rectangleFuel = new Rectangle((int)_positionFuel.X, (int)_positionFuel.Y, LARGEUR_FUEL, HAUTEUR_FUEL);

            base.Initialize();
        }
        protected override void LoadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _positionFuel.X -= _pasFuel * deltaTime;
            _rectangleFuel = new Rectangle((int)_positionFuel.Y, (int)_positionFuel.X, LARGEUR_FUEL, HAUTEUR_FUEL);

            if (_rectangleFuel.Intersects(_rectanglePerso))
            {
                _positionFuel = new Vector2(r.Next(0, GraphicsDevice.Viewport.Width - LARGEUR_FUEL), 0);

                _spriteBatch.Draw(_textureFuel, _positionFuel, Color.White);
            }

            if (_chronoFuel >= 10 || _chroneFuelApp > 0)
            {
                _positionFuel = new Vector2(r.Next(0, GraphicsDevice.Viewport.Width - LARGEUR_FUEL), 0);
                _chroneFuelApp += deltaTime;
            }
            if (_chronoFuel >= 10)
                _chronoFuel = 0;

            if (_chroneFuelApp > 2)
            {
                _chroneFuelApp = 0;
                _positionFuel = new Vector2(r.Next(0, GraphicsDevice.Viewport.Width - LARGEUR_FUEL), 0);
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(_textureFuel, _positionFuel, Color.White);
            base.Draw(gameTime);
        }
    }
}
