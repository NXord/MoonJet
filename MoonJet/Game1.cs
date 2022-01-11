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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteSheet animation = Content.Load<SpriteSheet>("Perso.sf", new JsonContentLoader());
            _perso = new AnimatedSprite(animation);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            float walkSpeed = (float)gameTime.ElapsedGameTime.TotalSeconds * 100;
            KeyboardState keyboardState = Keyboard.GetState();

            _animation = TypeAnimation.walk;

            Vector2 deplacement = new Vector2(0, 0);
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_perso,_positionPerso);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
