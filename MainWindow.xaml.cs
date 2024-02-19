using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.XPath;

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Cell> livingCells = new ObservableCollection<Cell>();

        int height = 12;
        int width = 12;
        int visibleCellsY = 50;
        int visibleCellsX = 50;
        int fromX = 0;
        int fromY = 0;

        Timer timer;

        public MainWindow()
        {
            InitializeComponent();

            itemsControl.ItemsSource = livingCells;

            itemsControl.Height = height * visibleCellsY;
            itemsControl.Width = width * visibleCellsX;

            for (int y = 0; y < visibleCellsY; y++)
            {
                for (int x = 0; x < visibleCellsX; x++)
                {
                    livingCells.Add(new Cell()
                    {
                        X = x,
                        Y = y,
                        IsAlive = false,
                        isEffectiveNow = true
                    });
                }
            }

            DataContext = new { Rows = visibleCellsX, Columns = visibleCellsY };
        }

        private Cell GetCell(double ix, double iy)
        {
            int x = (int)Math.Floor(ix);
            int y = (int)Math.Floor(iy);
            Cell cell = livingCells.FirstOrDefault(c => c.X == x && c.Y == y);
            return cell ?? new Cell() { X = x, Y = y, IsAlive = false, isEffectiveNow = true };
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
                cell.isEffectiveNow = true;
            }

            foreach (Cell cell in livingCells)
            {
                bool alive = IsAlive(cell.X, cell.Y);
                if (alive != cell.IsAlive)
                {
                    cell.isEffectiveNow = false;
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
                    nbAliveCells += neighbor.isEffectiveNow ? neighbor.IsAlive ? 1 : 0 : !neighbor.IsAlive ? 1 : 0;
                }
            }

            return GetCell(ix, iy).IsAlive ? nbAliveCells >= 2 && nbAliveCells <= 3 : nbAliveCells == 3;
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
            for (int y = fromY + 1; y <= fromY + 9; y++)
            {
                for (int x = fromX + 1; x <= fromY + 36; x++)
                {
                    Cell cell = GetCell(x, y);
                    cell.IsAlive = false;

                    if (y == 1)
                    {
                        if (x == 23) cell.IsAlive = true;
                    } else if (y == 2)
                    {
                        if (x == 22 || x == 24) cell.IsAlive = true;
                    }
                    else if (y == 3)
                    {
                        if (x == 12 || x == 13 || x == 20 || x == 21 || x == 25 || x == 35 || x == 36) cell.IsAlive = true;
                    }
                    else if (y == 4)
                    {
                        if (x == 11 || x == 13 || x == 18 || x == 19 || x == 21 || x == 25 || x == 35 || x == 36) cell.IsAlive = true;
                    }
                    else if (y == 5)
                    {
                        if (x == 1 || x == 2 || x == 10 || x == 11 || x == 12 || x == 17 || x == 18 || x == 19 || x == 21 || x == 25) cell.IsAlive = true;
                    }
                    else if (y == 6)
                    {
                        if (x == 1 || x == 2 || x == 9 || x == 10 || x == 11 || x == 16 || x == 19 || x == 20 || x == 22 || x == 24) cell.IsAlive = true;
                    }
                    else if (y == 7)
                    {
                        if (x == 10 || x == 11 || x == 12 || x == 17 || x == 18 || x == 23) cell.IsAlive = true;
                    }
                    else if (y == 8)
                    {
                        if (x == 11 || x == 13) cell.IsAlive = true;
                    }
                    else if (y == 9)
                    {
                        if (x == 12 || x == 13) cell.IsAlive = true;
                    }
                }
            }
        }
    }
}
