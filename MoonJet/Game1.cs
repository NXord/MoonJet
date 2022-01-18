using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Content;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using System;
using System.Threading;

namespace MoonJet
{
    public enum TypeAnimation {walk,decolage,vol,back,idle, explosion, meteorite,full,mid,low };

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private AnimatedSprite _perso;
        private TypeAnimation _animationPerso;
        private TypeAnimation _animationPet;
        private Vector2 _positionPerso;
        public const int HAUTEURFENTRE = 827;
        public const int LARGEURFENTRE = 1168;
        private Vector2 _scale;
        private Vector2 _taillePerso;
        public const int HAUTEUR_PERSO = 27;
        public const int LARGEUR_PERSO = 15;
        public const int GROSSISEMENT = 4;
        public Rectangle _rectanglePerso;
        public static int sol;

        private AnimatedSprite _pet;
        private Vector2 _taillePet;
        private Vector2 _positionPet;
        public const int TAILLE_PET = 40;
        private Rectangle _rPet;

        private AnimatedSprite _meteorite;
        private Vector2[] _positionMeteorite;
        public const int LARGEUR_METEORITE = 50;
        public const int HAUTEUR_METEORITE = 57;
        private Rectangle _rectangleMeteorite;
        private TypeAnimation _animationMeteor;
        private int _pasMeteorite;
        public Random r = new Random();

        private Texture2D _fond;
        private Vector2 _positionFond;

        public const int LARGEUR_coeur = 400;
        public const int HAUTEUR_coeur = 475;

        private Texture2D _textureCoeur;
        private Vector2 _posCoeur;
        public const int HAUTEUR_COEUR = 32;
        private float _chronoCoeur;
        private float _chronoCoeurApp;
        public int posCoeurX;
        public int posCoeurY;
        private Rectangle _rCoeur;

        private AnimatedSprite _life;
        private Vector2 _poslife;
        private TypeAnimation _animationLife;
        private int _countLife;



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
        public TypeAnimation AnimationLife
        {
            get
            {
                return this._animationLife;
            }

            set
            {
                this._animationLife = value;
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
        public AnimatedSprite Life
        {
            get
            {
                return this._life;
            }

            set
            {
                this._life = value;
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

            _positionFond = new Vector2(0, 0);
            _graphics.PreferredBackBufferWidth = LARGEURFENTRE;
            _graphics.PreferredBackBufferHeight = HAUTEURFENTRE;
            _graphics.ApplyChanges();
            Scale = new Vector2(GROSSISEMENT,GROSSISEMENT);
            _taillePerso = new Vector2(LARGEUR_PERSO * Scale.X , HAUTEUR_PERSO * Scale.Y);
            _positionPerso = new Vector2(_taillePerso.X-LARGEUR_PERSO, GraphicsDevice.Viewport.Height - _taillePerso.Y - 100) ;
            _rectanglePerso = new Rectangle((int)_positionPerso.X, (int)_positionPerso.Y, (int)_taillePerso.X, (int)_taillePerso.Y);

            _taillePet = new Vector2(TAILLE_PET * Scale.X, TAILLE_PET * Scale.Y);
            _positionPet = new Vector2(200, 200);
            _rPet = new Rectangle((int)_positionPet.X, (int)_positionPet.Y, TAILLE_PET, TAILLE_PET);

            _pasMeteorite = 100;
            _graphics.ApplyChanges();

            _positionMeteorite = new Vector2[10];

            for (int i = 0; i < _positionMeteorite.Length; i++)
            {
                _positionMeteorite[i] = new Vector2(GraphicsDevice.Viewport.Width, r.Next(0, GraphicsDevice.Viewport.Height - HAUTEUR_METEORITE));
                _rectangleMeteorite = new Rectangle((int)_positionMeteorite[i].X, (int)_positionMeteorite[i].Y, LARGEUR_METEORITE, HAUTEUR_METEORITE);

            }

            _posCoeur = new Vector2(-100,-100);
            _chronoCoeur =0;
            _chronoCoeurApp =0;
            _rCoeur = new Rectangle((int)_posCoeur.X, (int)_posCoeur.Y, HAUTEUR_COEUR, HAUTEUR_COEUR);

            _poslife = new Vector2(27,7);

            _countLife = 3;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            SpriteSheet animationPerso = Content.Load<SpriteSheet>("Perso.sf", new JsonContentLoader());
            SpriteSheet animationPet = Content.Load<SpriteSheet>("Pet.sf", new JsonContentLoader());
            SpriteSheet animationMeteor = Content.Load<SpriteSheet>("Meteor.sf", new JsonContentLoader());
            SpriteSheet animationLife = Content.Load<SpriteSheet>("life.sf", new JsonContentLoader());

            Perso = new AnimatedSprite(animationPerso);
            Pet = new AnimatedSprite(animationPet);
            Meteorite = new AnimatedSprite(animationMeteor);
            Life = new AnimatedSprite(animationLife);

            _fond = Content.Load<Texture2D>("Fond");

            _textureCoeur = Content.Load<Texture2D>("coeur");

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

            if (_positionPerso.Y < GraphicsDevice.Viewport.Height - _taillePerso.Y && !(keyboardState.IsKeyDown(Keys.Up)))
            {
                _positionPerso.Y += fallSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.Up) && _positionPerso.Y >= 0)
            {
                AnimationPerso = TypeAnimation.vol;
                _positionPerso.Y = _positionPerso.Y - walkSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.Right) && _positionPerso.X <= GraphicsDevice.Viewport.Width)
            {
                _positionPerso.X = _positionPerso.X + walkSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.Left) && _positionPerso.X >= 0)
            {
                _positionPerso.X = _positionPerso.X - walkSpeed;
            }
            _rectanglePerso = new Rectangle((int)_positionPerso.X, (int)_positionPerso.Y, (int)_taillePerso.X, (int)_taillePerso.Y);


            AnimationMeteor = TypeAnimation.meteorite;

            for (int i = 0; i < _positionMeteorite.Length; i++)
            {
                _positionMeteorite[i].X -= walkSpeed;
                _rectangleMeteorite = new Rectangle((int)_positionMeteorite[i].X, (int)_positionMeteorite[i].Y, LARGEUR_METEORITE, HAUTEUR_METEORITE);

                if (_positionMeteorite[i].X < 0)
                {
                    _positionMeteorite[i] = new Vector2(GraphicsDevice.Viewport.Width, r.Next(0, GraphicsDevice.Viewport.Height - HAUTEUR_METEORITE));

                }
                if (_rectangleMeteorite.Intersects(_rectanglePerso))
                {
                    AnimationMeteor = TypeAnimation.explosion;
                    Meteorite.Play(AnimationMeteor.ToString());
                    Meteorite.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
                    _positionMeteorite[i] = new Vector2(GraphicsDevice.Viewport.Width, r.Next(0, GraphicsDevice.Viewport.Height - HAUTEUR_METEORITE));
                    _countLife--;
                }
            }



            _chronoCoeur += deltaTime;

            if (_chronoCoeur >= 10 || _chronoCoeurApp > 0)
            {
                _posCoeur = new Vector2(posCoeurX, posCoeurY);
                Follow();
                _rCoeur = new Rectangle((int)_posCoeur.X, (int)_posCoeur.Y, HAUTEUR_COEUR, HAUTEUR_COEUR);
                _chronoCoeurApp += deltaTime;
            }
            if (_chronoCoeur >= 10)
                _chronoCoeur = 0;

            if (_chronoCoeurApp > 5)
            {
                _chronoCoeurApp = 0;
                _posCoeur = new Vector2(-100, -100);
                posCoeurX = r.Next(0, GraphicsDevice.Viewport.Width - HAUTEUR_COEUR);
                posCoeurY = r.Next(0, GraphicsDevice.Viewport.Height - HAUTEUR_COEUR);
                _rCoeur = new Rectangle((int)_posCoeur.X, (int)_posCoeur.Y, HAUTEUR_COEUR, HAUTEUR_COEUR);
            }

            _rPet = new Rectangle((int)_positionPet.X, (int)_positionPet.Y, TAILLE_PET, TAILLE_PET);

            if (_rPet.Intersects(_rCoeur))
            {
                _chronoCoeurApp = 0;
                _posCoeur = new Vector2(-100, -100);
                posCoeurX = r.Next(0, GraphicsDevice.Viewport.Width - HAUTEUR_COEUR);
                posCoeurY = r.Next(0, GraphicsDevice.Viewport.Height - HAUTEUR_COEUR);
                _countLife += 1;
            }


            if (_countLife >= 3) {
                _countLife = 3;
                AnimationLife = TypeAnimation.full; }
            else if (_countLife == 2)
                AnimationLife = TypeAnimation.mid;
            else if (_countLife == 1)
                AnimationLife = TypeAnimation.low;



            Perso.Play(AnimationPerso.ToString());
            Pet.Play(AnimationPet.ToString());
            Meteorite.Play(AnimationMeteor.ToString());
            Life.Play(AnimationLife.ToString());
            Perso.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            Pet.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            Meteorite.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            Life.Update((float)gameTime.ElapsedGameTime.TotalSeconds);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            SpriteBatch.Begin();
            SpriteBatch.Draw(_fond, _positionFond, Color.White);
            SpriteBatch.Draw(Perso, _positionPerso, 0, Scale);
            SpriteBatch.Draw(Pet, _positionPet);
            foreach (Vector2 posMeteor in _positionMeteorite)
            { _spriteBatch.Draw(Meteorite, posMeteor); }
            SpriteBatch.Draw(Life, _poslife);
            SpriteBatch.Draw(_textureCoeur, _posCoeur, Color.White);
            SpriteBatch.End();
            base.Draw(gameTime);
        }

        protected void Follow()
        {
            float LinearVelocity = 4f;
            var distanceX = _posCoeur.X - _positionPet.X;
            var distanceY = _posCoeur.Y - _positionPet.Y;
            
            float _rotation = (float)Math.Atan2(distanceY, distanceX);

            Vector2 Direction = new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation));

            var currentDistance = Vector2.Distance(_positionPet, _posCoeur);
            if (currentDistance > 0)
            {
                var t = MathHelper.Min((float)Math.Abs(currentDistance), LinearVelocity);
                var velocity = Direction * t;

                _positionPet += velocity;
            }
        }
    }
}
