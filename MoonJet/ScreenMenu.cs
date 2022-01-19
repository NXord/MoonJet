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
    public class ScreenMenu : GameScreen
    {
        private Game1 _game1;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private MouseState _mouseState;

        private Vector2 _posStart;
        private Texture2D _start;
        private Rectangle _rStart;
        public const int HAUTEUR_BUTTON = 40;
        public const int LARGEUR_BUTTON = 160;

        private SpriteFont _text;
        private Vector2 _posText;

        private Vector2 _click;
        private bool test;


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

        public bool Test
        {
            get
            {
                return this.test;
            }

            set
            {
                this.test = value;
            }
        }

        public ScreenMenu(Game1 game) : base(game)
        {
            _game1 = game;
        }
        public override void Initialize()
        {
            _posStart = new Vector2(GraphicsDevice.Viewport.Width / 2- LARGEUR_BUTTON/2, GraphicsDevice.Viewport.Height / 2- HAUTEUR_BUTTON/2);
            _rStart = new Rectangle((int)_posStart.X, (int)_posStart.Y, LARGEUR_BUTTON,HAUTEUR_BUTTON);
            _posText = new Vector2(GraphicsDevice.Viewport.Width / 2 - LARGEUR_BUTTON / 4, GraphicsDevice.Viewport.Height / 2 - HAUTEUR_BUTTON/2 );
            Test = false;
        }
        public override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            _start = Content.Load<Texture2D>("Button");
            _text = Content.Load<SpriteFont>("Font");
            base.LoadContent();
        }
        
        public override void Update(GameTime gameTime)
        {
            Essaie();
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(_start, _posStart, Color.White);
            SpriteBatch.DrawString(_text, "Start", _posText, Color.Black);
            SpriteBatch.End();
        }

        public bool Essaie()
        {
            _mouseState = Mouse.GetState();
            if (_mouseState.LeftButton == ButtonState.Pressed)
            {
                _click = new Vector2(_mouseState.X, _mouseState.Y);
            }
            if (_rStart.Contains(_click))
            {
                this.Test = true;
            }
            return this.Test;
        }
    }
}