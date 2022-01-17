/*using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Content;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;

namespace MoonJet
{
    public class Pet: GameScreen
    {
        private Game1 _game1;
        private AnimatedSprite _pet;
        private Vector2 _taillePet;
        private Vector2 _positionPet;
        public const int TAILLE_PET = 40;

        public AnimatedSprite SpritePet
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

        public Pet(Game1 game) : base(game)
        {
            _game1 = game;
        }

        public override void Initialize()
        {
            // TODO: Add your initialization logic here
            _taillePet = new Vector2(TAILLE_PET * _game1.Scale.X, TAILLE_PET * _game1.Scale.Y);
            _positionPet = new Vector2(200,200);

            base.Initialize();
        }

        public override void LoadContent()
        {
            _game1.SpriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteSheet animation = Content.Load<SpriteSheet>("Pet.sf", new JsonContentLoader());
            SpritePet = new AnimatedSprite(animation);
            base.LoadContent();

            // TODO: use this.Content to load your game content here
        }

        public override void Update(GameTime gameTime)
        {
            float walkSpeed = (float)gameTime.ElapsedGameTime.TotalSeconds * 100;

            KeyboardState keyboardState = Keyboard.GetState();

            _game1.Animation = TypeAnimation.idle;



            SpritePet.Play(_game1.Animation.ToString());
            SpritePet.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

        }

        public override void Draw(GameTime gameTime)
        {
            _game1.GraphicsDevice.Clear(Color.Red);

            // TODO: Add your drawing code here
            _game1.SpriteBatch.Begin();
            _game1.SpriteBatch.Draw(SpritePet,_positionPet , 0, _game1.Scale );
            _game1.SpriteBatch.End();

        }
    }
}
  */