using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Content;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using System;

namespace MoonJet
{
    public enum TypeAnimation {walk,decolage,vol,back,idle, explosion, meteorite };

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private AnimatedSprite _perso;
        private TypeAnimation _animationPerso;
        private TypeAnimation _animationPet;
        private Vector2 _positionPerso;
        public const int TAILLE_FENETRE= 800;
        private Vector2 _scale;
        private Vector2 _taillePerso;
        public const int HAUTEUR_PERSO = 27;
        public const int LARGEUR_PERSO = 15;
        public const int GROSSISEMENT = 4;
        public Rectangle _rectanglePerso;
        public const int SOL = TAILLE_FENETRE - 100;

        private AnimatedSprite _pet;
        private Vector2 _taillePet;
        private Vector2 _positionPet;
        public const int TAILLE_PET = 40;

        private AnimatedSprite _meteorite;
        private Texture2D _textureMeteorite;
        private Vector2 _positionMeteorite;
        public const int LARGEUR_METEORITE = 50;
        public const int HAUTEUR_METEORITE = 57;
        private Rectangle _rectangleMeteorite;
        private TypeAnimation _animationMeteor;
        private int _pasMeteorite;
        public Random r = new Random();


        public TypeAnimation AnimationPerso
        {
            get
            {
                return this._animationPerso;
            }

            set
            {
                this._animationPerso = value;
            }
        }
        public TypeAnimation AnimationPet
        {
            get
            {
                return this._animationPet;
            }

            set
            {
                this._animationPet = value;
            }
        }
        public TypeAnimation AnimationMeteor
        {
            get
            {
                return this._animationMeteor;
            }

            set
            {
                this._animationMeteor = value;
            }
        }



        public AnimatedSprite Perso
        {
            get
            {
                return this._perso;
            }

            set
            {
                this._perso = value;
            }
        }
        public AnimatedSprite Pet
        {
            get
            {
                return this._pet;
            }

            set
            {
                this._pet = value;
            }
        }
        public AnimatedSprite Meteorite
        {
            get
            {
                return this._meteorite;
            }

            set
            {
                this._meteorite = value;
            }
        }



        public SpriteBatch SpriteBatch
        {
            get
            {
                return this._spriteBatch;
            }

            set
            {
                this._spriteBatch = value;
            }
        }

        public Vector2 Scale
        {
            get
            {
                return this._scale;
            }

            set
            {
                this._scale = value;
            }
        }
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            
            _graphics.PreferredBackBufferWidth = TAILLE_FENETRE*2;
            _graphics.PreferredBackBufferHeight = TAILLE_FENETRE;
            _graphics.ApplyChanges();
            Scale = new Vector2(GROSSISEMENT,GROSSISEMENT);
            _taillePerso = new Vector2(LARGEUR_PERSO * Scale.X , HAUTEUR_PERSO * Scale.Y);
            _positionPerso = new Vector2(_taillePerso.X-LARGEUR_PERSO, GraphicsDevice.Viewport.Height - _taillePerso.Y) ;
            _rectanglePerso = new Rectangle((int)_positionPerso.X, (int)_positionPerso.Y, (int)_taillePerso.X, (int)_taillePerso.Y);
            _taillePet = new Vector2(TAILLE_PET * Scale.X, TAILLE_PET * Scale.Y);
            _positionPet = new Vector2(200, 200);

            _pasMeteorite = 100;
            _graphics.ApplyChanges();

            _positionMeteorite = new Vector2(GraphicsDevice.Viewport.Width, r.Next(0, GraphicsDevice.Viewport.Height - HAUTEUR_METEORITE));
            _rectangleMeteorite = new Rectangle((int)_positionMeteorite.X, (int)_positionMeteorite.Y, LARGEUR_METEORITE, HAUTEUR_METEORITE);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            SpriteSheet animationPerso = Content.Load<SpriteSheet>("Perso.sf", new JsonContentLoader());
            SpriteSheet animationPet = Content.Load<SpriteSheet>("Pet.sf", new JsonContentLoader());
            SpriteSheet animationMeteor = Content.Load<SpriteSheet>("Meteor.sf", new JsonContentLoader());

            Perso = new AnimatedSprite(animationPerso);
            Pet = new AnimatedSprite(animationPet);
            Meteorite = new AnimatedSprite(animationMeteor);


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            float walkSpeed = (float)gameTime.ElapsedGameTime.TotalSeconds * 100;
            int fallSpeed = 5;
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            AnimationPet = TypeAnimation.idle;

            KeyboardState keyboardState = Keyboard.GetState();

            AnimationPerso = TypeAnimation.walk;

            Vector2 deplacement = new Vector2(0, 0);

            if (_positionPerso.Y<SOL&&!(keyboardState.IsKeyDown(Keys.Up)))
            {
                _positionPerso.Y += fallSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                AnimationPerso = TypeAnimation.vol;
                _positionPerso.Y = _positionPerso.Y - walkSpeed;
            }
            
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                _positionPerso.X = _positionPerso.X + walkSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                _positionPerso.X = _positionPerso.X - walkSpeed;
            }
            _rectanglePerso = new Rectangle((int)_positionPerso.X, (int)_positionPerso.Y, (int)_taillePerso.X, (int)_taillePerso.Y);


            AnimationMeteor = TypeAnimation.meteorite;

            _positionMeteorite.X -= walkSpeed;
            _rectangleMeteorite = new Rectangle((int)_positionMeteorite.X, (int)_positionMeteorite.Y, LARGEUR_METEORITE, HAUTEUR_METEORITE);

            if (_positionMeteorite.X<0)
            {
                _positionMeteorite = new Vector2(GraphicsDevice.Viewport.Width, r.Next(0, GraphicsDevice.Viewport.Height - HAUTEUR_METEORITE));

            }
            if (_rectangleMeteorite.Intersects(_rectanglePerso))
            {
                _positionMeteorite = new Vector2(GraphicsDevice.Viewport.Width, r.Next(0, GraphicsDevice.Viewport.Height - HAUTEUR_METEORITE));
                AnimationMeteor = TypeAnimation.explosion;
            }


            Perso.Play(AnimationPerso.ToString());
            Pet.Play(AnimationPet.ToString());
            Meteorite.Play(AnimationMeteor.ToString());
            Perso.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            Pet.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            Meteorite.Update((float)gameTime.ElapsedGameTime.TotalSeconds);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            SpriteBatch.Begin();
            SpriteBatch.Draw(Perso, _positionPerso, 0, Scale);
            SpriteBatch.Draw(Pet, _positionPet);
            SpriteBatch.Draw(Meteorite, _positionMeteorite);
            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
