using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

// Jesli chodzi o funkcjonalność, to jest malutko, bo byłem zasypany przez kolokwia (i do 17 VI się raczej to nie zmieni), 
//ale poruszanie się  po ograniczonym tle działa 

/* No i w sumie musze ogarnąć tworzenie obiektów tak, aby się nie sypało
 * (tworzenie 2 klas i powiązanie ich ze sobą).
 * Potem powinno być już z górki (wykrywanie kolizji pomiędzy obiektami i system tworzenia
 * 
 * No i jakieś GUI (z wynikiem i takimi tam).
 * 
 * 
*/


namespace Gamez2
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //-- collections
        BlockingCollection<Thread> Threads = new BlockingCollection<Thread>();

        //player parameters
        PlayerStats _playerStats = new PlayerStats(50, 50, 30, 5, 3, 30);
        Hero _player = new Hero();


        

        //Area parameters
        double _canvasStartX = 0;
        double _canvasStartY = 0;
        double _canvasHeight = 480;
        double _canvasWidth = 640;

        public MainWindow()
        {
            InitializeComponent();

            // adding hero to canvas
            Canvas.SetLeft(_player, 50);
            Canvas.SetTop(_player, 50);
            _player.RenderTransformOrigin = new Point(0.5, 0.5);

            Main_Area.Children.Add(_player);

            //movement thread
            Thread MoverThread = new Thread(() =>
               {
                   while (true)
                   {
                       Dispatcher.BeginInvoke(new Action(() =>
                       {
                           //default parameters, when hero don't move

                           ResetMovesParametr(_player, _playerStats);

                           //controls
                           Controls.controls(_playerStats);

                           //players charracter moving operations
                           unitMoveOperation(_playerStats, _player);

                           //players charracter rotation operration
                           unitAngleChangingOperation(_playerStats, _player);

                           if (Keyboard.IsKeyDown(Key.Space))
                           {
                              
                           }

                       }), System.Windows.Threading.DispatcherPriority.Normal);
                       Thread.Sleep(10);

                   }
               });
            Threads.Add(MoverThread);

            //units controler
            Thread unitControler = new Thread(() =>
            {
                while (true)
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        
                       
                    }), System.Windows.Threading.DispatcherPriority.Normal);
                    Thread.Sleep(10);
                }
            });
            Threads.Add(unitControler);

            // Threads initialisation

            foreach (Thread thr in Threads)
            {
                thr.IsBackground = true;
                thr.Start();
            }
            
        }


        void ResetMovesParametr(UserControl UnitControl, MultipleUnitBase Unitparameters)
        {

            Unitparameters.AngleChanges = false;
            Unitparameters.CurrentVectorX = 0;
            Unitparameters.CurrentVectorY = 0;
            Unitparameters.CurrentPositionX = Canvas.GetLeft(UnitControl);
            Unitparameters.CurrentPositionY = Canvas.GetTop(UnitControl);
        }


        void unitMoveOperation(MultipleUnitBase _unitStats, UserControl _unit)
        {
            // vertical move
            if (WallCollision.heroCanMove
                    (
                   _unitStats.CurrentPositionY,
                   _canvasStartY,
                   _unitStats.CurrentVectorY,
                   _unitStats.Height,
                   _canvasHeight
                     )
               ) Canvas.SetTop(_unit,
                    (_unitStats.CurrentPositionY + _unitStats.CurrentVectorY));

            //horisontal move
            if (WallCollision.heroCanMove
                    (
                     _unitStats.CurrentPositionX,
                     _canvasStartX,
                     _unitStats.CurrentVectorX,
                     _unitStats.Widht,
                     _canvasWidth
                    )
                ) Canvas.SetLeft(_unit,
                     (_unitStats.CurrentPositionX + _unitStats.CurrentVectorX));
        }


        void unitAngleChangingOperation(MultipleUnitBase _unitStats, UserControl _unit)
        {
            double new_angle = AngleControler.SetPlayerAngle
                (_unitStats.CurrentVectorY,
                _unitStats.CurrentVectorX,
                _unitStats.CurrentAngle,
                _unitStats.AngleChanges);

            RotateTransform rt = new RotateTransform(new_angle);
            _unit.RenderTransform = rt;
            _unitStats.CurrentAngle = new_angle;
        }

    }

}

