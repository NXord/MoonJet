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
    public enum Ecran { Menu, Jeux,Dead };

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ScreenJeux _screenJeux;
        private ScreenMenu _screenMenu;
        private ScreenDead _screenDead;
        private Ecran _ecranEncours;
        private readonly ScreenManager _screenManager;
        private MouseState _mouseState;

        private Texture2D _fond;
        private Vector2 _positionFond;
        public const int HAUTEURFENTRE = 827;
        public const int LARGEURFENTRE = 1168;

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

        public GraphicsDeviceManager Graphics
        {
            get
            {
                return this._graphics;
            }

            set
            {
                this._graphics = value;
            }
        }

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _screenManager = new ScreenManager();
            Components.Add(_screenManager);
        }

        protected override void Initialize()
        {
            _positionFond = new Vector2(0, 0);
            _graphics.PreferredBackBufferWidth = LARGEURFENTRE;
            _graphics.PreferredBackBufferHeight = HAUTEURFENTRE;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            _screenJeux = new ScreenJeux(this);
            _screenMenu = new ScreenMenu(this);
            _screenDead = new ScreenDead(this);
            _screenManager.LoadScreen(_screenMenu, new FadeTransition(GraphicsDevice, Color.Black));
            _ecranEncours = Ecran.Menu;
            _fond = Content.Load<Texture2D>("Fond");
        }

        protected override void Update(GameTime gameTime)
        {
            _mouseState = Mouse.GetState();
            if (_ecranEncours == Ecran.Menu && _screenMenu.Test)
            {
                _ecranEncours = Ecran.Jeux;
                _screenManager.LoadScreen(_screenJeux);
            }
            if (_ecranEncours == Ecran.Jeux && _screenJeux.Dead)
            {
                _ecranEncours = Ecran.Dead;
                _screenManager.LoadScreen(_screenDead);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SpriteBatch.Begin();
            SpriteBatch.Draw(_fond, _positionFond, Color.White);
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
