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
    public enum TypeAnimation { walk, decolage, atterisage, idle };

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private AnimatedSprite _perso;
        private TypeAnimation _animation;
        private Vector2 _positionPerso;
        public const int TAILLE_FENETRE= 800;
        private Vector2 _scale;
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

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _positionPerso = new Vector2(16, 16);
            _graphics.PreferredBackBufferWidth = TAILLE_FENETRE;
            _graphics.PreferredBackBufferHeight = TAILLE_FENETRE;
            _scale = new Vector2(2, 2);



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteSheet animation = Content.Load<SpriteSheet>("Perso.sf", new JsonContentLoader());
            Perso = new AnimatedSprite(animation);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            float walkSpeed = (float)gameTime.ElapsedGameTime.TotalSeconds * 100;
            KeyboardState keyboardState = Keyboard.GetState();

            Animation = TypeAnimation.walk;

            Vector2 deplacement = new Vector2(0, 0);

            Perso.Play(Animation.ToString());
            Perso.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(Perso, new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), 0, new Vector2((float)3, (float)3));
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
