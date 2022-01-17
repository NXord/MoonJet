using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Sprites;

namespace MoonJet
{
    public class Kit : Game
    {
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        private AnimatedSprite _kit;
        private Texture2D _textureKit;
        private Vector2 _positionKit;
        public const int LARGEUR_KIT = 50;
        public const int HAUTEUR_KIT = 57;
        private Rectangle _rectangleKit;
        private TypeAnimation _animation;
        private float _chronoKit;
        private float _chroneKitApp;
        private Vector2 _scale;
        private int _pasKit;
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
        public AnimatedSprite kit
        {
            get
            {
                return this._kit;
            }

            set
            {
                this._kit = value;
            }
        }
        public Kit()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            _pasKit = 100;

            _positionKit = new Vector2(r.Next(0, GraphicsDevice.Viewport.Width - LARGEUR_KIT), 0);
            _rectangleKit = new Rectangle((int)_positionKit.X, (int)_positionKit.Y, LARGEUR_KIT, HAUTEUR_KIT);

            base.Initialize();
        }
        protected override void LoadContent()
        {
            _textureKit = Content.Load<Texture2D>("Kit");
        }
        protected override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _positionKit.X -= _pasKit * deltaTime;
            _rectangleKit = new Rectangle((int)_positionKit.Y, (int)_positionKit.X, LARGEUR_KIT, HAUTEUR_KIT);

            if (_rectangleKit.Intersects(_game1._rectanglePerso))
            {
                _positionKit = new Vector2(r.Next(0, GraphicsDevice.Viewport.Width - LARGEUR_KIT), 0);

                _spriteBatch.Draw(_textureKit, _positionKit, Color.White);
            }
            if (_chronoKit >= 10 || _chroneKitApp > 0)
            {
                _positionKit = new Vector2(r.Next(0, GraphicsDevice.Viewport.Width - LARGEUR_KIT), 0);
                _chroneKitApp += deltaTime;
            }
            if (_chronoKit >= 10)
                _chronoKit = 0;

            if (_chroneKitApp > 2)
            {
                _chroneKitApp = 0;
                _positionKit = new Vector2(r.Next(0, GraphicsDevice.Viewport.Width - LARGEUR_KIT), 0);
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(_textureKit, _positionKit, Color.White);
            _spriteBatch.Draw(kit, _positionKit, 0, _scale);
            base.Draw(gameTime);
        }
    }
}
