using Android.Content;
using Android.Views;
using Android.Views.InputMethods;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Library.Graphics;

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

        private float ScreenWidth => _graphics.PreferredBackBufferWidth;
        private float ScreenHeight => _graphics.PreferredBackBufferHeight;

        public Game1(Context activity1)
        {
            _context = activity1;
            _view = (View)Services.GetService(typeof(View));
            _view.SystemUiVisibility = (StatusBarVisibility)(SystemUiFlags.LayoutStable | SystemUiFlags.LayoutHideNavigation | SystemUiFlags.LayoutFullscreen | SystemUiFlags.HideNavigation | SystemUiFlags.Fullscreen | SystemUiFlags.ImmersiveSticky);
            _inputMethodManager = activity1.GetSystemService(Context.InputMethodService) as InputMethodManager;

            _graphics = new GraphicsDeviceManager(this)
            {
                IsFullScreen = true
            };

            Content.RootDirectory = "Content";

            _joyStick = new VirtualJoyStick(new Vector2(_graphics.PreferredBackBufferWidth * 0.25f, _graphics.PreferredBackBufferHeight * 0.5f),
                                           (_graphics.PreferredBackBufferHeight * 0.8f) / 2f);


        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            DebugDrawer.Init(_spriteBatch, Content, GraphicsDevice);
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

            DebugDrawer.DrawRect(ScreenWidth * 0.1f, ScreenHeight * 0.1f, ScreenWidth * 0.9f, ScreenHeight * 0.9f, Color.DarkOrange);
            DebugDrawer.DrawString("HELLO!!", new Vector2(ScreenWidth * 0.5f, ScreenHeight * 0.5f), Color.White, new Vector2(8, 8));

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
