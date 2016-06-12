using System.Windows.Input;


namespace Gamez2
{
    class Controls
    {
        public static void controls(MultipleUnitBase _playerStats)
        {
            if (Keyboard.IsKeyDown(Key.Up))
            {
                _playerStats.CurrentVectorY = -_playerStats.MovementSpeed;
                _playerStats.AngleChanges = true;
            }

            if (Keyboard.IsKeyDown(Key.Down))
            {
                _playerStats.CurrentVectorY = _playerStats.MovementSpeed;
                _playerStats.AngleChanges = true;
            }

            if (Keyboard.IsKeyDown(Key.Left))
            {
                _playerStats.CurrentVectorX = -_playerStats.MovementSpeed;
                _playerStats.AngleChanges = true;
            }

            if (Keyboard.IsKeyDown(Key.Right))
            {
                _playerStats.CurrentVectorX = _playerStats.MovementSpeed;

                _playerStats.AngleChanges = true;
            }

        }
    }
}
