using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Views.InputMethods;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace RPGController
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private readonly View _view;
        private readonly Context _context;
        private readonly InputMethodManager _inputMethodManager;

        private readonly VirtualJoyStick _joyStick;

        private Texture2D _pixel;

        public Game1(Context activity1)
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _graphics.IsFullScreen = true;
            _graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
            _graphics.ApplyChanges();

            _joyStick = new VirtualJoyStick(new Vector2(_graphics.PreferredBackBufferWidth * 0.25f, _graphics.PreferredBackBufferHeight * 0.5f),
                                           (_graphics.PreferredBackBufferHeight * 0.8f) / 2f);

            _context = activity1;
            _view = (View)Services.GetService(typeof(View));
            _inputMethodManager = activity1.GetSystemService(Context.InputMethodService) as InputMethodManager;
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _pixel = new Texture2D(GraphicsDevice, 1, 1);
            _pixel.SetData(new[] { Color.White });

            DebugDrawer.Init(_spriteBatch, Content);
        }

        protected override void Update(GameTime gameTime)
        {
            TouchHandler.Update();

            _joyStick.CheckForTouch();
            _joyStick.UpdateDirection();

        }

        private void ShowTouchKeyboard()
        {
            _inputMethodManager.ShowSoftInput(_view, ShowFlags.Forced);
            _inputMethodManager.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.ImplicitOnly);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(blendState: BlendState.NonPremultiplied);

            _joyStick.Draw();

         
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
