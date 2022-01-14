using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MoonJet
{
    public enum TypeCollisionMapMaison { Meteorite, Mun, Kit, Fuel };
    public class Obstacle : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _textureMeteorite;
        private Vector2 _positionMeteorite;
        public const int LARGEUR_METEORITE = 50;
        public const int HAUTEUR_METEORITE = 57;
        private Rectangle _rectangleMeteorite;

        private Texture2D _textureMun;
        private Vector2 _positionMun;
        public const int LARGEUR_MUN = 50;
        public const int HAUTEUR_MUN = 57;
        private Rectangle _rectangleMun;

        private Texture2D _textureKit;
        private Vector2 _positionKit;
        public const int LARGEUR_KIT = 50;
        public const int HAUTEUR_KIT = 57;
        private Rectangle _rectangleKit;

        private Texture2D _textureFuel;
        private Vector2 _positionFuel;
        public const int LARGEUR_FUEL = 50;
        public const int HAUTEUR_FUEL = 57;
        private Rectangle _rectangleFuel;

        private int _pasMeteorite;
        private int _pasKit;
        private int _pasMun;
        private int _pasFuel;
        public Random r = new Random();

        public Obstacle()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            _pasMeteorite = 100;
            _pasKit = 100;
            _pasMun = 100;
            _pasFuel = 100;
            _graphics.ApplyChanges();

            _positionMeteorite = new Vector2(r.Next(0, GraphicsDevice.Viewport.Width - LARGEUR_METEORITE), 0);
            _rectangleMeteorite = new Rectangle((int)_positionMeteorite.X, (int)_positionMeteorite.Y, LARGEUR_METEORITE, HAUTEUR_METEORITE);

            _positionMun = new Vector2(r.Next(0, GraphicsDevice.Viewport.Width - LARGEUR_MUN), 0);
            _rectangleMun = new Rectangle((int)_positionMun.X, (int)_positionMun.Y, LARGEUR_MUN, HAUTEUR_MUN);

            _positionKit = new Vector2(r.Next(0, GraphicsDevice.Viewport.Width - LARGEUR_KIT), 0);
            _rectangleKit = new Rectangle((int)_positionKit.X, (int)_positionKit.Y, LARGEUR_KIT, HAUTEUR_KIT);

            _positionFuel = new Vector2(r.Next(0, GraphicsDevice.Viewport.Width - LARGEUR_FUEL), 0);
            _rectangleFuel = new Rectangle((int)_positionFuel.X, (int)_positionFuel.Y, LARGEUR_FUEL, HAUTEUR_FUEL);

            base.Initialize();
        }

        protected override void LoadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {

            _positionMeteorite.X -= _pasMeteorite * deltaTime;
            _rectangleMeteorite = new Rectangle((int)_positionMeteorite.Y, (int)_positionMeteorite.X, LARGEUR_METEORITE, HAUTEUR_METEORITE);

            if (_rectangleMeteorite.Intersects(_rectanglePerso))
            {
                _positionMeteorite = new Vector2(r.Next(0, GraphicsDevice.Viewport.Width - LARGEUR_METEORITE), 0);

                _spriteBatch.Draw(_textureMeteorite, _positionMeteorite, Color.White);
            }
            _positionKit.X -= _pasKit * deltaTime;
            _rectangleKit = new Rectangle((int)_positionKit.Y, (int)_positionKit.X, LARGEUR_KIT, HAUTEUR_KIT);

            if (_rectangleKit.Intersects(_rectanglePerso))
            {
                _positionKit = new Vector2(r.Next(0, GraphicsDevice.Viewport.Width - LARGEUR_KIT), 0);

                _spriteBatch.Draw(_textureKit, _positionKit, Color.White);
            }
            _positionMun.X -= _pasMun * deltaTime;
            _rectangleMun = new Rectangle((int)_positionMun.Y, (int)_positionMun.X, LARGEUR_MUN, HAUTEUR_MUN);

            if (_rectangleMun.Intersects(_rectanglePerso))
            {
                _positionMun = new Vector2(r.Next(0, GraphicsDevice.Viewport.Width - LARGEUR_MUN), 0);

                _spriteBatch.Draw(_textureMun, _positionMun, Color.White);
            }
            _positionFuel.X -= _pasFuel * deltaTime;
            _rectangleFuel = new Rectangle((int)_positionFuel.Y, (int)_positionFuel.X, LARGEUR_FUEL, HAUTEUR_FUEL);

            if (_rectangleFuel.Intersects(_rectanglePerso))
            {
                _positionFuel = new Vector2(r.Next(0, GraphicsDevice.Viewport.Width - LARGEUR_FUEL), 0);

                _spriteBatch.Draw(_textureFuel, _positionFuel, Color.White);
            }

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(_textureMeteorite, _positionMeteorite, Color.White);
            _spriteBatch.Draw(_textureMun, _positionMun, Color.White);
            _spriteBatch.Draw(_textureKit, _positionKit, Color.White);
            _spriteBatch.Draw(_textureFuel, _positionFuel, Color.White);
            base.Draw(gameTime);
        }
    }
}
