using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MoonJet
{
    public enum TypeCollisionMapMaison { Meteorite, Mun, Kit, Fuel };
    public class Meteorite : Game
    {
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        private Texture2D _textureMeteorite;
        private Vector2 _positionMeteorite;
        public const int LARGEUR_METEORITE = 50;
        public const int HAUTEUR_METEORITE = 57;
        private Rectangle _rectangleMeteorite;

        private int _pasMeteorite;
        public Random r = new Random();

        public Meteorite()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            _pasMeteorite = 100;
            _graphics.ApplyChanges();

            _positionMeteorite = new Vector2(r.Next(0, GraphicsDevice.Viewport.Width - LARGEUR_METEORITE), 0);
            _rectangleMeteorite = new Rectangle((int)_positionMeteorite.X, (int)_positionMeteorite.Y, LARGEUR_METEORITE, HAUTEUR_METEORITE);

            base.Initialize();
        }

        protected override void LoadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _positionMeteorite.X -= _pasMeteorite * deltaTime;
            _rectangleMeteorite = new Rectangle((int)_positionMeteorite.Y, (int)_positionMeteorite.X, LARGEUR_METEORITE, HAUTEUR_METEORITE);

            if (_rectangleMeteorite.Intersects(Game1._rectanglePerso))
            {
                _positionMeteorite = new Vector2(r.Next(0, GraphicsDevice.Viewport.Width - LARGEUR_METEORITE), 0);

                _spriteBatch.Draw(_textureMeteorite, _positionMeteorite, Color.White);
            }


            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(_textureMeteorite, _positionMeteorite, Color.White);

            base.Draw(gameTime);
        }
    }
}
