using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Data;
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
        ObservableCollection<Cell> allCells = new ObservableCollection<Cell>();

        const int VISIBLE_CELL_Y = 50;
        const int VISIBLE_CELL_X = 50;

        List<int> neighborToBorn = new List<int>() { 3 };
        List<int> neighborToStayAlive = new List<int>() { 2, 3 };

        Timer timer;

        public MainWindow()
        {
            InitializeComponent();

            itemsControl.ItemsSource = allCells;

            // Initialize the list with the default cells
            for (int y = 0; y < VISIBLE_CELL_Y; y++)
            {
                for (int x = 0; x < VISIBLE_CELL_X; x++)
                {
                    allCells.Add(new Cell()
                    {
                        X = x,
                        Y = y,
                        IsAlive = false,
                        IsEffectiveNow = true
                    });
                }
            }

            DataContext = new { Rows = VISIBLE_CELL_X, Columns = VISIBLE_CELL_Y };

            ListCollectionView lcv = new ListCollectionView(Structure.Structures);
            lcv.GroupDescriptions.Add(new PropertyGroupDescription("Category"));

            cmbStructures.ItemsSource = lcv;
        }

        private Cell GetCell(double ix, double iy)
        {
            int x = (int)Math.Floor(ix);
            int y = (int)Math.Floor(iy);
            Cell cell = allCells.FirstOrDefault(c => c.X == x && c.Y == y);
            return cell ?? new Cell() { X = x, Y = y, IsAlive = false, IsEffectiveNow = true };
        }

        private void ToggleAlive(object sender, MouseButtonEventArgs e)
        {
            if (timer == default)
            {
                if (sender is Rectangle clickedRect)
                {
                    if (clickedRect.DataContext is Cell cell)
                    {
                        cell.IsAlive = !cell.IsAlive;
                    }
                }
            }
        }

        private void CheckAlive(object state)
        {
            foreach (Cell cell in allCells)
                cell.IsEffectiveNow = true;

            foreach (Cell cell in allCells)
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

        private void GenerateElement(object sender, RoutedEventArgs e)
        {
            Structure structure = cmbStructures.SelectedItem as Structure;

            foreach (Cell cell in allCells)
            {
                Point cellCoordinates = new Point(cell.X, cell.Y);
                cell.IsAlive = structure.SetupLivingCells.Any(point => point.Equals(cellCoordinates));
            }
        }

        private void DisplayCoordinate(object sender, MouseEventArgs e)
        {
            if (sender is Rectangle clickedRect)
            {
                if (clickedRect.DataContext is Cell cell)
                {
                    string state = cell.IsAlive ? "alive" : "dead";
                    tblCoordinates.Text = $"[{cell.X}, {cell.Y}] is {state}";
                }
            }
        }
    }
}
