using System;
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
using System.Threading;

namespace MoonJet
{
    public class ScreenDead : GameScreen
    {
        private Game1 _game1;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _text;
        private Vector2 _posText;

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

        public ScreenDead(Game1 game) : base(game)
        {
            _game1 = game;
        }
        public override void Initialize()
        {
            _posText = new Vector2(GraphicsDevice.Viewport.Width / 2 , GraphicsDevice.Viewport.Height / 2);
        }
        public override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            _text = Content.Load<SpriteFont>("Font");
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.DrawString(_text, "RIP", _posText, Color.Black);
            SpriteBatch.End();
        }
    }
}
