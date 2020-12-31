using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

/// <summary>
/// Modification of the class given at https://stackoverflow.com/questions/904454/how-to-slow-down-or-stop-key-presses-in-xna
/// </summary>
namespace MonoGame.CExtended
{
    /// <summary>
    /// an enum of all available mouse buttons.
    /// </summary>
    public enum MouseButtons
    {
        LeftButton,
        MiddleButton,
        RightButton,
        ExtraButton1,
        ExtraButton2
    }

    public class InputHelper
    {
        private GamePadState[] _lastGamepadState;
        private GamePadState[] _currentGamepadState;
#if (!XBOX)
        private KeyboardState _lastKeyboardState;
        private KeyboardState _currentKeyboardState;
        private MouseState _lastMouseState;
        private MouseState _currentMouseState;
#endif

        private bool refreshData = false;

        private static bool initialized = false;

        /// <summary>
        /// Fetches the latest input states.
        /// </summary>
        public void Update()
        {
            if (!refreshData)
                refreshData = true;
            if (_lastGamepadState == null && _currentGamepadState == null)
            {
                _lastGamepadState = new GamePadState[GamePad.MaximumGamePadCount];
                _currentGamepadState = new GamePadState[GamePad.MaximumGamePadCount];
                for (int i = 0; i < GamePad.MaximumGamePadCount; i++)
                {
                    _lastGamepadState[i] = _currentGamepadState[i] = GamePad.GetState(i);
                }
            }
            else
            {
                for (int i = 0; i < GamePad.MaximumGamePadCount; i++)
                {
                    _lastGamepadState[i] = _currentGamepadState[i];
                    _currentGamepadState[i] = GamePad.GetState(i);
                }
            }
#if (!XBOX)
            if (_lastKeyboardState == null && _currentKeyboardState == null)
            {
                _lastKeyboardState = _currentKeyboardState = Keyboard.GetState();
            }
            else
            {
                _lastKeyboardState = _currentKeyboardState;
                _currentKeyboardState = Keyboard.GetState();
            }
            if (_lastMouseState == null && _currentMouseState == null)
            {
                _lastMouseState = _currentMouseState = Mouse.GetState();
            }
            else
            {
                _lastMouseState = _currentMouseState;
                _currentMouseState = Mouse.GetState();
            }
#endif
        }

        public InputHelper()
        {
            Initialize();
        }

        private static void Initialize()
        {
            if (!initialized)
            {
                Text.UnionWith(Letters);
                Text.UnionWith(Numbers);
                Text.UnionWith(OemSpecial);
                initialized = true;
            }
        }

        /// <summary>
        /// The previous state of the gamepad. 
        /// Exposed only for convenience.
        /// </summary>
        public GamePadState[] LastGamepadState
        {
            get { return _lastGamepadState; }
        }
        /// <summary>
        /// the current state of the gamepad.
        /// Exposed only for convenience.
        /// </summary>
        public GamePadState[] CurrentGamepadState
        {
            get { return _currentGamepadState; }
        }
#if (!XBOX)
        /// <summary>
        /// The previous keyboard state.
        /// Exposed only for convenience.
        /// </summary>
        public KeyboardState LastKeyboardState
        {
            get { return _lastKeyboardState; }
        }
        /// <summary>
        /// The current state of the keyboard.
        /// Exposed only for convenience.
        /// </summary>
        public KeyboardState CurrentKeyboardState
        {
            get { return _currentKeyboardState; }
        }
        /// <summary>
        /// The previous mouse state.
        /// Exposed only for convenience.
        /// </summary>
        public MouseState LastMouseState
        {
            get { return _lastMouseState; }
        }
        /// <summary>
        /// The current state of the mouse.
        /// Exposed only for convenience.
        /// </summary>
        public MouseState CurrentMouseState
        {
            get { return _currentMouseState; }
        }
#endif
        /// <summary>
        /// The current position of the left stick. 
        /// Y is automatically reversed for you.
        /// </summary>
        public Vector2 LeftStickPosition(int gamepad)
        {
            return new Vector2(
                    _currentGamepadState[gamepad].ThumbSticks.Left.X,
                    -CurrentGamepadState[gamepad].ThumbSticks.Left.Y);
        }
        /// <summary>
        /// The current position of the right stick.
        /// Y is automatically reversed for you.
        /// </summary>
        public Vector2 RightStickPosition(int gamepad)
        {
            return new Vector2(
                    _currentGamepadState[gamepad].ThumbSticks.Right.X,
                    -CurrentGamepadState[gamepad].ThumbSticks.Right.Y);
        }
        /// <summary>
        /// The current velocity of the left stick.
        /// Y is automatically reversed for you.
        /// expressed as: 
        /// current stick position - last stick position.
        /// </summary>
        public Vector2 LeftStickVelocity(int i)
        {
            Vector2 temp =
                _currentGamepadState[i].ThumbSticks.Left -
                _lastGamepadState[i].ThumbSticks.Left;
            return new Vector2(temp.X, -temp.Y);
        }
        /// <summary>
        /// The current velocity of the right stick.
        /// Y is automatically reversed for you.
        /// expressed as: 
        /// current stick position - last stick position.
        /// </summary>
        public Vector2 RightStickVelocity(int i)
        {

            Vector2 temp =
                _currentGamepadState[i].ThumbSticks.Right -
                _lastGamepadState[i].ThumbSticks.Right;
            return new Vector2(temp.X, -temp.Y);

        }
        /// <summary>
        /// the current position of the left trigger.
        /// </summary>
        public float LeftTriggerPosition(int i)
        {
            return _currentGamepadState[i].Triggers.Left;
        }
        /// <summary>
        /// the current position of the right trigger.
        /// </summary>
        public float RightTriggerPosition(int i)
        {
            return _currentGamepadState[i].Triggers.Right;
        }
        /// <summary>
        /// the velocity of the left trigger.
        /// expressed as: 
        /// current trigger position - last trigger position.
        /// </summary>
        public float LeftTriggerVelocity(int i)
        {
            return
                _currentGamepadState[i].Triggers.Left -
                _lastGamepadState[i].Triggers.Left;

        }
        /// <summary>
        /// the velocity of the right trigger.
        /// expressed as: 
        /// current trigger position - last trigger position.
        /// </summary>
        public float RightTriggerVelocity(int i)
        {

            return _currentGamepadState[i].Triggers.Right -
                _lastGamepadState[i].Triggers.Right;

        }
#if (!XBOX)
        /// <summary>
        /// the current mouse position.
        /// </summary>
        public Vector2 MousePosition
        {
            get { return new Vector2(_currentMouseState.X, _currentMouseState.Y); }
        }
        /// <summary>
        /// the current mouse velocity.
        /// Expressed as: 
        /// current mouse position - last mouse position.
        /// </summary>
        public Vector2 MouseVelocity
        {
            get
            {
                return (
                    new Vector2(_currentMouseState.X, _currentMouseState.Y) -
                    new Vector2(_lastMouseState.X, _lastMouseState.Y)
                    );
            }
        }
        /// <summary>
        /// the current mouse scroll wheel position.
        /// See the Mouse's ScrollWheel property for details.
        /// </summary>
        public float MouseScrollWheelPosition
        {
            get
            {
                return _currentMouseState.ScrollWheelValue;
            }
        }
        /// <summary>
        /// the mouse scroll wheel velocity.
        /// Expressed as:
        /// current scroll wheel position - 
        /// the last scroll wheel position.
        /// </summary>
        public float MouseScrollWheelVelocity
        {
            get
            {
                return (_currentMouseState.ScrollWheelValue - _lastMouseState.ScrollWheelValue);
            }
        }
#endif
        /// <summary>
        /// Used for debug purposes.
        /// Indicates if the user wants to exit immediately.
        /// </summary>
        public bool ExitRequested
        {
            get
            {
                bool r = true;
                for (int i = 0; i < GamePad.MaximumGamePadCount; i++)
                {
                    r &= IsCurPress(i, Buttons.Start) && IsCurPress(i, Buttons.Back);
                }
                return r || IsCurPress(Keys.Escape);
            }
        }
        /// <summary>
        /// Checks if the requested button is a new press.
        /// </summary>
        /// <param name="button">
        /// The button to check.
        /// </param>
        /// <returns>
        /// a bool indicating whether the selected button is being 
        /// pressed in the current state but not the last state.
        /// </returns>
        public bool IsNewPress(int i, Buttons button)
        {
            return (
                _lastGamepadState[i].IsButtonUp(button) &&
                _currentGamepadState[i].IsButtonDown(button));
        }
        /// <summary>
        /// Checks if the requested button is a current press.
        /// </summary>
        /// <param name="button">
        /// the button to check.
        /// </param>
        /// <returns>
        /// a bool indicating whether the selected button is being 
        /// pressed in the current state and in the last state.
        /// </returns>
        public bool IsCurPress(int i, Buttons button)
        {
            return (
                _lastGamepadState[i].IsButtonDown(button) &&
                _currentGamepadState[i].IsButtonDown(button));
        }
        /// <summary>
        /// Checks if the requested button is an old press.
        /// </summary>
        /// <param name="button">
        /// the button to check.
        /// </param>
        /// <returns>
        /// a bool indicating whether the selected button is not being
        /// pressed in the current state and is being pressed in the last state.
        /// </returns>
        public bool IsOldPress(int i, Buttons button)
        {
            return (
                _lastGamepadState[i].IsButtonDown(button) &&
                _currentGamepadState[i].IsButtonUp(button));
        }
#if (!XBOX)
        /// <summary>
        /// Checks if the requested key is a new press.
        /// </summary>
        /// <param name="key">
        /// the key to check.
        /// </param>
        /// <returns>
        /// a bool that indicates whether the selected key is being 
        /// pressed in the current state and not in the last state.
        /// </returns>
        public bool IsNewPress(Keys key)
        {
            return (
                _lastKeyboardState.IsKeyUp(key) &&
                _currentKeyboardState.IsKeyDown(key));
        }
        /// <summary>
        /// Checks if the requested key is a current press.
        /// </summary>
        /// <param name="key">
        /// the key to check.
        /// </param>
        /// <returns>
        /// a bool that indicates whether the selected key is being 
        /// pressed in the current state and in the last state.
        /// </returns>
        public bool IsCurPress(Keys key)
        {
            return (
                _lastKeyboardState.IsKeyDown(key) &&
                _currentKeyboardState.IsKeyDown(key));
        }
        /// <summary>
        /// Checks if the requested button is an old press.
        /// </summary>
        /// <param name="key">
        /// the key to check.
        /// </param>
        /// <returns>
        /// a bool indicating whether the selectde button is not being
        /// pressed in the current state and being pressed in the last state.
        /// </returns>
        public bool IsOldPress(Keys key)
        {
            return (
                _lastKeyboardState.IsKeyDown(key) &&
                _currentKeyboardState.IsKeyUp(key));
        }
        /// <summary>
        /// Checks if the requested mosue button is a new press.
        /// </summary>
        /// <param name="button">
        /// teh mouse button to check.
        /// </param>
        /// <returns>
        /// a bool indicating whether the selected mouse button is being
        /// pressed in the current state but not in the last state.
        /// </returns>
        public bool IsNewPress(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.LeftButton:
                    return (
                        _lastMouseState.LeftButton == ButtonState.Released &&
                        _currentMouseState.LeftButton == ButtonState.Pressed);
                case MouseButtons.MiddleButton:
                    return (
                        _lastMouseState.MiddleButton == ButtonState.Released &&
                        _currentMouseState.MiddleButton == ButtonState.Pressed);
                case MouseButtons.RightButton:
                    return (
                        _lastMouseState.RightButton == ButtonState.Released &&
                        _currentMouseState.RightButton == ButtonState.Pressed);
                case MouseButtons.ExtraButton1:
                    return (
                        _lastMouseState.XButton1 == ButtonState.Released &&
                        _currentMouseState.XButton1 == ButtonState.Pressed);
                case MouseButtons.ExtraButton2:
                    return (
                        _lastMouseState.XButton2 == ButtonState.Released &&
                        _currentMouseState.XButton2 == ButtonState.Pressed);
                default:
                    return false;
            }
        }
        /// <summary>
        /// Checks if the requested mosue button is a current press.
        /// </summary>
        /// <param name="button">
        /// the mouse button to be checked.
        /// </param>
        /// <returns>
        /// a bool indicating whether the selected mouse button is being 
        /// pressed in the current state and in the last state.
        /// </returns>
        public bool IsCurPress(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.LeftButton:
                    return (
                        _lastMouseState.LeftButton == ButtonState.Pressed &&
                        _currentMouseState.LeftButton == ButtonState.Pressed);
                case MouseButtons.MiddleButton:
                    return (
                        _lastMouseState.MiddleButton == ButtonState.Pressed &&
                        _currentMouseState.MiddleButton == ButtonState.Pressed);
                case MouseButtons.RightButton:
                    return (
                        _lastMouseState.RightButton == ButtonState.Pressed &&
                        _currentMouseState.RightButton == ButtonState.Pressed);
                case MouseButtons.ExtraButton1:
                    return (
                        _lastMouseState.XButton1 == ButtonState.Pressed &&
                        _currentMouseState.XButton1 == ButtonState.Pressed);
                case MouseButtons.ExtraButton2:
                    return (
                        _lastMouseState.XButton2 == ButtonState.Pressed &&
                        _currentMouseState.XButton2 == ButtonState.Pressed);
                default:
                    return false;
            }
        }
        /// <summary>
        /// Checks if the requested mosue button is an old press.
        /// </summary>
        /// <param name="button">
        /// the mouse button to check.
        /// </param>
        /// <returns>
        /// a bool indicating whether the selected mouse button is not being 
        /// pressed in the current state and is being pressed in the old state.
        /// </returns>
        public bool IsOldPress(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.LeftButton:
                    return (
                        _lastMouseState.LeftButton == ButtonState.Pressed &&
                        _currentMouseState.LeftButton == ButtonState.Released);
                case MouseButtons.MiddleButton:
                    return (
                        _lastMouseState.MiddleButton == ButtonState.Pressed &&
                        _currentMouseState.MiddleButton == ButtonState.Released);
                case MouseButtons.RightButton:
                    return (
                        _lastMouseState.RightButton == ButtonState.Pressed &&
                        _currentMouseState.RightButton == ButtonState.Released);
                case MouseButtons.ExtraButton1:
                    return (
                        _lastMouseState.XButton1 == ButtonState.Pressed &&
                        _currentMouseState.XButton1 == ButtonState.Released);
                case MouseButtons.ExtraButton2:
                    return (
                        _lastMouseState.XButton2 == ButtonState.Pressed &&
                        _currentMouseState.XButton2 == ButtonState.Released);
                default:
                    return false;
            }
        }
#endif


        public static HashSet<Keys> Letters = new HashSet<Keys>{
            Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.G, Keys.H, Keys.I,
            Keys.J, Keys.K, Keys.L, Keys.M, Keys.N, Keys.O, Keys.P, Keys.Q, Keys.R,
            Keys.S, Keys.T, Keys.U, Keys.V, Keys.W, Keys.X, Keys.Y, Keys.Z
        };
        public static HashSet<Keys> Numbers = new HashSet<Keys>
        {
            Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9
        };
        public static HashSet<Keys> OemSpecial = new HashSet<Keys>
        {
            Keys.OemTilde, Keys.Subtract, Keys.OemPlus, Keys.OemQuestion, Keys.OemComma, Keys.OemPeriod,
            Keys.OemBackslash, Keys.OemMinus, Keys.OemPipe, Keys.OemSemicolon, Keys.OemOpenBrackets, Keys.OemCloseBrackets
        };
        public static HashSet<Keys> Text = new HashSet<Keys>
        {

        };

        /// <summary>
        /// Converts a key to a char.
        /// </summary>
        /// <param name="Key">They key to convert.</param>
        /// <param name="Shift">Whether or not shift is pressed.</param>
        /// <returns>The key in a char.</returns>
        public static char KeyToChar(Keys Key, bool Shift = false)
        {
            /* It's the space key. */
            if (Key == Keys.Space)
            {
                return ' ';
            }
            else
            {
                string String = Key.ToString();

                /* It's a letter. */
                if (String.Length == 1)
                {
                    Char Character = Char.Parse(String);
                    byte Byte = Convert.ToByte(Character);

                    if (
                        (Byte >= 65 && Byte <= 90) ||
                        (Byte >= 97 && Byte <= 122)
                        )
                    {
                        return (!Shift ? Character.ToString().ToLower() : Character.ToString())[0];
                    }
                }

                /* 
                 * 
                 * The only issue is, if it's a symbol, how do I know which one to take if the user isn't using United States international?
                 * Anyways, thank you, for saving my time
                 * down here
                 * Credits :  http://roy-t.nl/2010/02/11/code-snippet-converting-keyboard-input-to-text-in-xna.html for saving my time.
                 */

                #region 
                switch (Key)
                {
                    case Keys.D0:
                        if (Shift) { return ')'; } else { return '0'; }
                    case Keys.D1:
                        if (Shift) { return '!'; } else { return '1'; }
                    case Keys.D2:
                        if (Shift) { return '@'; } else { return '2'; }
                    case Keys.D3:
                        if (Shift) { return '#'; } else { return '3'; }
                    case Keys.D4:
                        if (Shift) { return '$'; } else { return '4'; }
                    case Keys.D5:
                        if (Shift) { return '%'; } else { return '5'; }
                    case Keys.D6:
                        if (Shift) { return '^'; } else { return '6'; }
                    case Keys.D7:
                        if (Shift) { return '&'; } else { return '7'; }
                    case Keys.D8:
                        if (Shift) { return '*'; } else { return '8'; }
                    case Keys.D9:
                        if (Shift) { return '('; } else { return '9'; }

                    case Keys.NumPad0: return '0';
                    case Keys.NumPad1: return '1';
                    case Keys.NumPad2: return '2';
                    case Keys.NumPad3: return '3';
                    case Keys.NumPad4: return '4';
                    case Keys.NumPad5: return '5';
                    case Keys.NumPad6: return '6';
                    case Keys.NumPad7: return '7'; ;
                    case Keys.NumPad8: return '8';
                    case Keys.NumPad9: return '9';

                    case Keys.OemTilde:
                        if (Shift) { return '~'; } else { return '`'; }
                    case Keys.OemSemicolon:
                        if (Shift) { return ':'; } else { return ';'; }
                    case Keys.OemQuotes:
                        if (Shift) { return '"'; } else { return '\''; }
                    case Keys.OemQuestion:
                        if (Shift) { return '?'; } else { return '/'; }
                    case Keys.OemPlus:
                        if (Shift) { return '+'; } else { return '='; }
                    case Keys.OemPipe:
                        if (Shift) { return '|'; } else { return '\\'; }
                    case Keys.OemPeriod:
                        if (Shift) { return '>'; } else { return '.'; }
                    case Keys.OemOpenBrackets:
                        if (Shift) { return '{'; } else { return '['; }
                    case Keys.OemCloseBrackets:
                        if (Shift) { return '}'; } else { return ']'; }
                    case Keys.OemMinus:
                        if (Shift) { return '_'; } else { return '-'; }
                    case Keys.OemComma:
                        if (Shift) { return '<'; } else { return ','; }
                }
                #endregion

                return (Char)0;

            }
        }
    }
}