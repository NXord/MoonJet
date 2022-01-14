using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MoonJet
{
    public class Munition : Game
    {
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        private Texture2D _textureMun;
        private Vector2 _positionMun;
        public const int LARGEUR_MUN = 50;
        public const int HAUTEUR_MUN = 57;
        private Rectangle _rectangleMun;
        private int _pasMun;
        public Random r = new Random();
        private Game1 _game1;

        public Munition()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            _pasMun = 100;

            _positionMun = new Vector2(r.Next(0, GraphicsDevice.Viewport.Width - LARGEUR_MUN), 0);
            _rectangleMun = new Rectangle((int)_positionMun.X, (int)_positionMun.Y, LARGEUR_MUN, HAUTEUR_MUN);

            base.Initialize();
        }
        protected override void LoadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _positionMun.X -= _pasMun * deltaTime;
            _rectangleMun = new Rectangle((int)_positionMun.Y, (int)_positionMun.X, LARGEUR_MUN, HAUTEUR_MUN);

            if (_rectangleMun.Intersects(_game1._rectanglePerso))
            {
                _positionMun = new Vector2(r.Next(0, GraphicsDevice.Viewport.Width - LARGEUR_MUN), 0);

                _spriteBatch.Draw(_textureMun, _positionMun, Color.White);
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(_textureMun, _positionMun, Color.White);
            base.Draw(gameTime);
        }
    }
}
