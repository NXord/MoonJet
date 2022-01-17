using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Sprites;

namespace MoonJet
{
    public enum TypeCollisionMapMaison { Meteorite, Mun, Kit, Fuel };
    public class Meteorite : Game
    {
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        private AnimatedSprite _Meteorite;
        private Texture2D _textureMeteorite;
        private Vector2 _positionMeteorite;
        public const int LARGEUR_METEORITE = 50;
        public const int HAUTEUR_METEORITE = 57;
        private Rectangle _rectangleMeteorite;
        private TypeAnimation _animation;
        private Vector2 _scale;
        private int _pasMeteorite;
        public Random r = new Random();
        private Game1 _game1;
        public TypeAnimation Animation
        {
            get
            {
                return this._animation;
            }

            set
            {
                this._animation = value;
            }
        }
        public AnimatedSprite meteorite
        {
            get
            {
                return this._Meteorite;
            }

            set
            {
                this._Meteorite = value;
            }
        }

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

            _positionMeteorite = new Vector2(r.Next(0, GraphicsDevice.Viewport.Height - HAUTEUR_METEORITE), 0);
            _rectangleMeteorite = new Rectangle((int)_positionMeteorite.X, (int)_positionMeteorite.Y, LARGEUR_METEORITE, HAUTEUR_METEORITE);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _textureMeteorite = Content.Load<Texture2D>("Meteor");
        }
        protected override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _positionMeteorite.X -= _pasMeteorite * deltaTime;
            _rectangleMeteorite = new Rectangle((int)_positionMeteorite.Y, (int)_positionMeteorite.X, LARGEUR_METEORITE, HAUTEUR_METEORITE);

            if (_rectangleMeteorite.Intersects(_game1._rectanglePerso))
            {
                _positionMeteorite = new Vector2(r.Next(0, GraphicsDevice.Viewport.Height - HAUTEUR_METEORITE), 0);

                _spriteBatch.Draw(_textureMeteorite, _positionMeteorite, Color.White);
            }


            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(_textureMeteorite, _positionMeteorite, Color.White);
            _spriteBatch.Draw(meteorite, _positionMeteorite, 0, _scale);
            _spriteBatch.Begin();
            base.Draw(gameTime);
        }
    }
}
