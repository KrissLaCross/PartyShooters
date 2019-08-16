using Android.Content;
using Android.Views;
using Android.Views.InputMethods;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

        private Button _button;
        private bool _flipFlop = false;
        private ButtonContainer _buttonContainer;

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

            _buttonContainer = new ButtonContainer();

            _buttonContainer.Add((int) (_graphics.PreferredBackBufferWidth * 0.75f), (int) (_graphics.PreferredBackBufferHeight * 0.25f),
                                 (int) (_graphics.PreferredBackBufferWidth * 0.95f), (int) (_graphics.PreferredBackBufferHeight * 0.75f),
                                 "Hello!", () => { _flipFlop = !_flipFlop; });
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

            _buttonContainer.Update();

        }

        private void ShowTouchKeyboard()
        {
            _inputMethodManager.ShowSoftInput(_view, ShowFlags.Forced);
            _inputMethodManager.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.ImplicitOnly);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_flipFlop ? Color.CornflowerBlue : Color.Green);

            _spriteBatch.Begin(blendState: BlendState.NonPremultiplied);

            _joyStick.Draw();

            _buttonContainer.Draw();
         
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
