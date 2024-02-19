using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Cell> livingCells = new ObservableCollection<Cell>();

        const int HEIGHT = 12;
        const int WIDTH = 12;
        const int VISIBLE_CELL_Y = 50;
        const int VISIBLE_CELL_X = 50;
        const int CANON_PLANE_WIDTH = 36;
        const int CANON_PLANE_HEIGHT = 9;

        int fromX = 0;
        int fromY = 0;
        List<int> neighborToBorn = new List<int>() { 3 };
        List<int> neighborToStayAlive = new List<int>() { 2, 3 };

        Timer timer;

        public MainWindow()
        {
            InitializeComponent();

            itemsControl.ItemsSource = livingCells;

            itemsControl.Height = HEIGHT * VISIBLE_CELL_Y;
            itemsControl.Width = WIDTH * VISIBLE_CELL_X;

            for (int y = 0; y < VISIBLE_CELL_Y; y++)
            {
                for (int x = 0; x < VISIBLE_CELL_X; x++)
                {
                    livingCells.Add(new Cell()
                    {
                        X = x,
                        Y = y,
                        IsAlive = false,
                        IsEffectiveNow = true
                    });
                }
            }

            DataContext = new { Rows = VISIBLE_CELL_X, Columns = VISIBLE_CELL_Y };
        }

        private Cell GetCell(double ix, double iy)
        {
            int x = (int)Math.Floor(ix);
            int y = (int)Math.Floor(iy);
            Cell cell = livingCells.FirstOrDefault(c => c.X == x && c.Y == y);
            return cell ?? new Cell() { X = x, Y = y, IsAlive = false, IsEffectiveNow = true };
        }

        private void ToggleAlive(object sender, MouseButtonEventArgs e)
        {
            if (timer == default)
            {
                Rectangle rect = sender as Rectangle;

                rect.Fill = rect.Fill == Brushes.Black ? Brushes.White : Brushes.Black;

                Point point = (Point)rect.Tag;
                Cell cell = GetCell(point.X, point.Y);
                cell.IsAlive = !cell.IsAlive;
            }
        }

        private void CheckAlive(object state)
        {
            foreach (Cell cell in livingCells)
            {
                cell.IsEffectiveNow = true;
            }

            foreach (Cell cell in livingCells)
            {
                bool alive = IsAlive(cell.X, cell.Y);
                if (alive != cell.IsAlive)
                {
                    cell.IsEffectiveNow = false;
                    cell.IsAlive = alive;
                }
            }
        }

        private bool IsAlive(int ix, int iy)
        {
            int nbAliveCells = 0;

            for (int dy = -1; dy <= 1; dy++)
            {
                for (int dx = -1; dx <= 1; dx++)
                {
                    if (dx == 0 && dy == 0) continue;

                    Cell neighbor = GetCell(ix + dx, iy + dy);
                    nbAliveCells += neighbor.IsEffectiveNow ? neighbor.IsAlive ? 1 : 0 : !neighbor.IsAlive ? 1 : 0;
                }
            }

            return GetCell(ix, iy).IsAlive ? neighborToStayAlive.Contains(nbAliveCells) : neighborToBorn.Contains(nbAliveCells);
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            if (timer != default)
            {
                timer.Dispose();
                timer = default;
                btnStart.Content = "Start";
            }
            else
            {
                timer = new Timer(CheckAlive, default, 0, 500);
                btnStart.Content = "Stop";
            }
        }
        private void BtnCanonPlane_Click(object sender, RoutedEventArgs e)
        {
            if (timer != default) return;

            for (int y = fromY + 1; y <= fromY + CANON_PLANE_HEIGHT; y++)
            {
                for (int x = fromX + 1; x <= fromX + CANON_PLANE_WIDTH; x++)
                {
                    Cell cell = GetCell(x, y);
                    cell.IsAlive = IsCanonPlaneCellAlive(x, y);
                }
            }
        }

        private bool IsCanonPlaneCellAlive(int x, int y)
        {
            if (y == 1 && x == 23)
            {
                return true;
            }
            else if (y == 2 && (x == 22 || x == 24))
            {
                return true;
            }
            else if (y == 3 && (x == 12 || x == 13 || x == 20 || x == 21 || x == 25 || x == 35 || x == 36))
            {
                return true;
            }
            else if (y == 4 && (x == 11 || x == 13 || x == 18 || x == 19 || x == 21 || x == 25 || x == 35 || x == 36))
            {
                return true;
            }
            else if (y == 5 && (x == 1 || x == 2 || x == 10 || x == 11 || x == 12 || x == 17 || x == 18 || x == 19 || x == 21 || x == 25))
            {
                return true;
            }
            else if (y == 6 && (x == 1 || x == 2 || x == 9 || x == 10 || x == 11 || x == 16 || x == 19 || x == 20 || x == 22 || x == 24))
            {
                return true;
            }
            else if (y == 7 && (x == 10 || x == 11 || x == 12 || x == 17 || x == 18 || x == 23))
            {
                return true;
            }
            else if (y == 8 && (x == 11 || x == 13))
            {
                return true;
            }
            else if (y == 9 && (x == 12 || x == 13))
            {
                return true;
            }

            return false;
        }
    }
}
