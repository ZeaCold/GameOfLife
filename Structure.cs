using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace GameOfLife
{
    public class Structure
    {
        private static List<Structure> structures = new List<Structure>();

        public string Name { get; set; }
        public string Category { get; set; }
        public List<Point> SetupLivingCells { get; set; }

        public static List<Structure> Structures
        {
            get
            {
                if (structures.Count == 0)
                    GenerateStructures();
                return structures;
            }
        }

        public Structure(string name, string category, List<Point> setupLivingCells)
        {
            Name = name + $" - {setupLivingCells.Count}c";
            Category = category;
            SetupLivingCells = setupLivingCells;
        }

        public static void GenerateStructures()
        {
            // Important sources for future
            // https://playgameoflife.com/
            // https://web.archive.org/web/20160611004604/http://www.argentum.freeserve.co.uk/lex_home.htm
            // https://commons.wikimedia.org/wiki/Game_of_Life?uselang=fr

            structures.Clear();

            structures.Add(new Structure("Bloc", "Bloc", new List<Point>
            {
                new Point(1, 1),
                new Point(2, 1),
                new Point(1, 2),
                new Point(2, 2),
            }));

            structures.Add(new Structure("Tube", "Bloc", new List<Point>
            {
                new Point(2, 1),
                new Point(1, 2),
                new Point(3, 2),
                new Point(2, 3),
            }));

            structures.Add(new Structure("Boat", "Bloc", new List<Point>
            {
                new Point(1, 1),
                new Point(2, 1),
                new Point(1, 2),
                new Point(3, 2),
                new Point(2, 3),
            }));

            structures.Add(new Structure("Ship", "Bloc", new List<Point>
            {
                new Point(1, 1),
                new Point(2, 1),
                new Point(1, 2),
                new Point(3, 2),
                new Point(2, 3),
                new Point(3, 3),
            }));

            structures.Add(new Structure("Snake", "Bloc", new List<Point>
            {
                new Point(1, 1),
                new Point(2, 1),
                new Point(4, 1),
                new Point(1, 2),
                new Point(3, 2),
                new Point(4, 2),
            }));

            structures.Add(new Structure("Barge", "Bloc", new List<Point>
            {
                new Point(3, 1),
                new Point(2, 2),
                new Point(4, 2),
                new Point(1, 3),
                new Point(3, 3),
                new Point(2, 4),
            }));

            structures.Add(new Structure("Aircraft-carrier", "Bloc", new List<Point>
            {
                new Point(3, 1),
                new Point(4, 1),
                new Point(1, 2),
                new Point(4, 2),
                new Point(1, 3),
                new Point(2, 3),
            }));

            structures.Add(new Structure("Hive", "Bloc", new List<Point>
            {
                new Point(2, 1),
                new Point(1, 2),
                new Point(3, 2),
                new Point(1, 3),
                new Point(3, 3),
                new Point(2, 4),
            }));

            structures.Add(new Structure("Bread loaf", "Bloc", new List<Point>
            {
                new Point(2, 1),
                new Point(3, 1),
                new Point(1, 2),
                new Point(4, 2),
                new Point(1, 3),
                new Point(3, 3),
                new Point(2, 4),
            }));

            structures.Add(new Structure("Hook / Eater type 1", "Bloc", new List<Point>
            {
                new Point(1, 1),
                new Point(2, 1),
                new Point(2, 2),
                new Point(2, 3),
                new Point(4, 3),
                new Point(3, 4),
                new Point(4, 4),
            }));

            structures.Add(new Structure("Canoe", "Bloc", new List<Point>
            {
                new Point(1, 1),
                new Point(2, 1),
                new Point(1, 2),
                new Point(2, 3),
                new Point(3, 4),
                new Point(5, 4),
                new Point(4, 5),
                new Point(5, 5),
            }));

            structures.Add(new Structure("Long barge", "Bloc", new List<Point>
            {
                new Point(4, 1),
                new Point(3, 2),
                new Point(5, 2),
                new Point(2, 3),
                new Point(4, 3),
                new Point(1, 4),
                new Point(3, 4),
                new Point(2, 5),
            }));

            structures.Add(new Structure("Long ship", "Bloc", new List<Point>
            {
                new Point(3, 1),
                new Point(4, 1),
                new Point(2, 2),
                new Point(4, 2),
                new Point(1, 3),
                new Point(3, 3),
                new Point(1, 4),
                new Point(2, 4),
            }));

            structures.Add(new Structure("Pond", "Bloc", new List<Point>
            {
                new Point(2, 1),
                new Point(3, 1),
                new Point(1, 2),
                new Point(4, 2),
                new Point(1, 3),
                new Point(4, 3),
                new Point(2, 4),
                new Point(3, 4),
            }));

            structures.Add(new Structure("Long canoe", "Bloc", new List<Point>
            {
                new Point(1, 1),
                new Point(2, 1),
                new Point(1, 2),
                new Point(2, 3),
                new Point(3, 4),
                new Point(4, 5),
                new Point(6, 5),
                new Point(5, 6),
                new Point(6, 6),
            }));

            structures.Add(new Structure("Double hook", "Bloc", new List<Point>
            {
                new Point(5, 1),
                new Point(6, 1),
                new Point(4, 2),
                new Point(6, 2),
                new Point(4, 3),
                new Point(2, 4),
                new Point(3, 4),
                new Point(4, 4),
                new Point(1, 5),
                new Point(1, 6),
                new Point(2, 6),
            }));

            structures.Add(new Structure("Eater type 2", "Bloc", new List<Point>
            {
                new Point(3, 1),
                new Point(2, 2),
                new Point(4, 2),
                new Point(2, 3),
                new Point(4, 3),
                new Point(1, 4),
                new Point(2, 4),
                new Point(4, 4),
                new Point(5, 4),
                new Point(6, 4),
                new Point(7, 5),
                new Point(1, 6),
                new Point(2, 6),
                new Point(4, 6),
                new Point(5, 6),
                new Point(6, 6),
                new Point(1, 7),
                new Point(2, 7),
                new Point(4, 7),
            }));

            structures.Add(new Structure("27 cells structure", "Bloc", new List<Point>
            {
                new Point(3, 1),
                new Point(4, 1),
                new Point(3, 2),
                new Point(1, 3),
                new Point(3, 3),
                new Point(1, 4),
                new Point(2, 4),
                new Point(4, 4),
                new Point(5, 4),
                new Point(4, 5),
                new Point(6, 5),
                new Point(4, 6),
                new Point(6, 6),
                new Point(3, 7),
                new Point(4, 7),
                new Point(6, 7),
                new Point(7, 7),
                new Point(8, 7),
                new Point(9, 8),
                new Point(3, 9),
                new Point(4, 9),
                new Point(6, 9),
                new Point(7, 9),
                new Point(8, 9),
                new Point(3, 10),
                new Point(4, 10),
                new Point(6, 10),
            }));

            structures.Add(new Structure("40 cells structure", "Bloc", new List<Point>
            {
                new Point(10, 1),
                new Point(11, 1),
                new Point(11, 2),
                new Point(11, 3),
                new Point(13, 3),
                new Point(9, 4),
                new Point(10, 4),
                new Point(12, 4),
                new Point(13, 4),
                new Point(8, 5),
                new Point(10, 5),
                new Point(8, 6),
                new Point(10, 6),
                new Point(6, 7),
                new Point(7, 7),
                new Point(8, 7),
                new Point(10, 7),
                new Point(11, 7),
                new Point(5, 8),
                new Point(5, 9),
                new Point(7, 9),
                new Point(8, 9),
                new Point(10, 9),
                new Point(11, 9),
                new Point(1, 10),
                new Point(3, 10),
                new Point(4, 10),
                new Point(6, 10),
                new Point(8, 10),
                new Point(10, 10),
                new Point(11, 10),
                new Point(1, 11),
                new Point(2, 11),
                new Point(4, 11),
                new Point(6, 11),
                new Point(6, 12),
                new Point(6, 13),
                new Point(8, 13),
                new Point(7, 14),
                new Point(8, 14),
            }));

            structures.Add(new Structure("Blinker", "Oscillator", new List<Point>
            {
                new Point(1, 1),
                new Point(2, 1),
                new Point(3, 1),
            }));

            structures.Add(new Structure("Oscillator alone", "Oscillator", new List<Point>
            {
                new Point(5, 1),
                new Point(6, 1),
                new Point(7, 1),
                new Point(3, 3),
                new Point(5, 3),
                new Point(7, 3),
                new Point(9, 3),
                new Point(1, 5),
                new Point(3, 5),
                new Point(9, 5),
                new Point(11, 5),
                new Point(1, 6),
                new Point(11, 6),
                new Point(1, 7),
                new Point(3, 7),
                new Point(9, 7),
                new Point(11, 7),
                new Point(3, 9),
                new Point(5, 9),
                new Point(7, 9),
                new Point(9, 9),
                new Point(5, 11),
                new Point(6, 11),
                new Point(7, 11),
            }));

            structures.Add(new Structure("Oscillator with blocks", "Oscillator", new List<Point>
            {
                new Point(1, 1),
                new Point(2, 1),
                new Point(5, 1),
                new Point(6, 1),
                new Point(7, 1),
                new Point(10, 1),
                new Point(11, 1),
                new Point(1, 2),
                new Point(11, 2),
                new Point(3, 3),
                new Point(5, 3),
                new Point(7, 3),
                new Point(9, 3),
                new Point(1, 5),
                new Point(3, 5),
                new Point(9, 5),
                new Point(11, 5),
                new Point(1, 6),
                new Point(11, 6),
                new Point(1, 7),
                new Point(3, 7),
                new Point(9, 7),
                new Point(11, 7),
                new Point(3, 9),
                new Point(5, 9),
                new Point(7, 9),
                new Point(9, 9),
                new Point(1, 10),
                new Point(11, 10),
                new Point(1, 11),
                new Point(2, 11),
                new Point(5, 11),
                new Point(6, 11),
                new Point(7, 11),
                new Point(10, 11),
                new Point(11, 11),
            }));

            structures.Add(new Structure("Cross", "Oscillator", new List<Point>
            {
                new Point(4, 1),
                new Point(7, 1),
                new Point(4, 2),
                new Point(7, 2),
                new Point(3, 3),
                new Point(4, 3),
                new Point(7, 3),
                new Point(8, 3),
                new Point(1, 4),
                new Point(2, 4),
                new Point(3, 4),
                new Point(8, 4),
                new Point(9, 4),
                new Point(10, 4),
                new Point(1, 7),
                new Point(2, 7),
                new Point(3, 7),
                new Point(8, 7),
                new Point(9, 7),
                new Point(10, 7),
                new Point(3, 8),
                new Point(4, 8),
                new Point(7, 8),
                new Point(8, 8),
                new Point(4, 9),
                new Point(7, 9),
                new Point(4, 10),
                new Point(7, 10),
            }));

            structures.Add(new Structure("Diagonal", "Oscillator", new List<Point>
            {
                new Point(8, 1),
                new Point(9, 1),
                new Point(8, 2),
                new Point(5, 3),
                new Point(6, 3),
                new Point(8, 3),
                new Point(4, 4),
                new Point(7, 4),
                new Point(4, 5),
                new Point(6, 6),
                new Point(3, 7),
                new Point(6, 7),
                new Point(2, 8),
                new Point(4, 8),
                new Point(5, 8),
                new Point(2, 9),
                new Point(1, 10),
                new Point(2, 10),
            }));

            structures.Add(new Structure("Clock", "Oscillator", new List<Point>
            {
                new Point(7, 1),
                new Point(8, 1),
                new Point(7, 2),
                new Point(8, 2),
                new Point(5, 4),
                new Point(6, 4),
                new Point(7, 4),
                new Point(8, 4),
                new Point(1, 5),
                new Point(2, 5),
                new Point(4, 5),
                new Point(9, 5),
                new Point(1, 6),
                new Point(2, 6),
                new Point(6, 6),
                new Point(7, 6),
                new Point(4, 6),
                new Point(9, 6),
                new Point(4, 7),
                new Point(8, 7),
                new Point(9, 7),
                new Point(11, 7),
                new Point(12, 7),
                new Point(4, 8),
                new Point(9, 8),
                new Point(11, 8),
                new Point(12, 8),
                new Point(5, 9),
                new Point(6, 9),
                new Point(7, 9),
                new Point(8, 9),
                new Point(5, 11),
                new Point(6, 11),
                new Point(5, 12),
                new Point(6, 12)
            }));

            structures.Add(new Structure("Clock Variant", "Oscillator", new List<Point>
            {
                new Point(7, 1),
                new Point(8, 1),
                new Point(7, 2),
                new Point(8, 2),
                new Point(5, 4),
                new Point(6, 4),
                new Point(7, 4),
                new Point(8, 4),
                new Point(1, 5),
                new Point(2, 5),
                new Point(4, 5),
                new Point(7, 5),
                new Point(9, 5),
                new Point(1, 6),
                new Point(2, 6),
                new Point(4, 6),
                new Point(6, 6),
                new Point(9, 6),
                new Point(4, 7),
                new Point(8, 7),
                new Point(9, 7),
                new Point(11, 7),
                new Point(12, 7),
                new Point(4, 8),
                new Point(9, 8),
                new Point(11, 8),
                new Point(12, 8),
                new Point(5, 9),
                new Point(6, 9),
                new Point(7, 9),
                new Point(8, 9),
                new Point(5, 11),
                new Point(6, 11),
                new Point(5, 12),
                new Point(6, 12)
            }));

            structures.Add(new Structure("Octagon", "Oscillator", new List<Point>
            {
                new Point(3, 2),
                new Point(6, 2),
                new Point(2, 3),
                new Point(4, 3),
                new Point(5, 3),
                new Point(7, 3),
                new Point(3, 4),
                new Point(6, 4),
                new Point(3, 5),
                new Point(6, 5),
                new Point(2, 6),
                new Point(4, 6),
                new Point(5, 6),
                new Point(7, 6),
                new Point(3, 7),
                new Point(6, 7)
            }));

            structures.Add(new Structure("Fountain", "Oscillator", new List<Point>
            {
                new Point(4, 2),
                new Point(5, 2),
                new Point(2, 3),
                new Point(3, 3),
                new Point(6, 3),
                new Point(7, 3),
                new Point(2, 4),
                new Point(7, 4),
                new Point(3, 5),
                new Point(6, 5),
                new Point(1, 6),
                new Point(3, 6),
                new Point(6, 6),
                new Point(8, 6),
                new Point(1, 7),
                new Point(2, 7),
                new Point(7, 7),
                new Point(8, 7),
            }));

            structures.Add(new Structure("Diagonal 5", "Oscillator", new List<Point>
            {
                new Point(12, 1),
                new Point(13, 1),
                new Point(12, 2),
                new Point(9, 3),
                new Point(10, 3),
                new Point(12, 3),
                new Point(7, 4),
                new Point(11, 4),
                new Point(6, 5),
                new Point(6, 6),
                new Point(8, 7),
                new Point(8, 8),
                new Point(3, 9),
                new Point(7, 9),
                new Point(2, 10),
                new Point(4, 10),
                new Point(5, 10),
                new Point(2, 11),
                new Point(1, 12),
                new Point(2, 12),
            }));

            structures.Add(new Structure("Kok's galaxy", "Oscillator", new List<Point>
            {
                new Point(5, 4),
                new Point(7, 4),
                new Point(8, 4),
                new Point(10, 4),
                new Point(11, 4),
                new Point(4, 5),
                new Point(5, 5),
                new Point(7, 5),
                new Point(8, 5),
                new Point(11, 5),
                new Point(12, 5),
                new Point(4, 6),
                new Point(11, 7),
                new Point(12, 7),
                new Point(4, 8),
                new Point(5, 8),
                new Point(11, 8),
                new Point(12, 8),
                new Point(4, 9),
                new Point(5, 9),
                new Point(12, 10),
                new Point(4, 11),
                new Point(5, 11),
                new Point(8, 11),
                new Point(9, 11),
                new Point(11, 11),
                new Point(12, 11),
                new Point(5, 12),
                new Point(6, 12),
                new Point(8, 12),
                new Point(9, 12),
                new Point(11, 12),
            }));

            structures.Add(new Structure("Penta-decathlon", "Oscillator", new List<Point>
            {
                new Point(6, 4),
                new Point(11, 4),
                new Point(4, 5),
                new Point(5, 5),
                new Point(7, 5),
                new Point(8, 5),
                new Point(9, 5),
                new Point(10, 5),
                new Point(12, 5),
                new Point(13, 5),
                new Point(6, 6),
                new Point(11, 6)
            }));

            structures.Add(new Structure("Gosper Glider Gun", "Guns", new List<Point>()
            {
                new Point(25, 1),
                new Point(23, 2),
                new Point(25, 2),
                new Point(13, 3),
                new Point(14, 3),
                new Point(21, 3),
                new Point(22, 3),
                new Point(35, 3),
                new Point(36, 3),
                new Point(12, 4),
                new Point(16, 4),
                new Point(21, 4),
                new Point(22, 4),
                new Point(35, 4),
                new Point(36, 4),
                new Point(1, 5),
                new Point(2, 5),
                new Point(11, 5),
                new Point(17, 5),
                new Point(21, 5),
                new Point(22, 5),
                new Point(1, 6),
                new Point(2, 6),
                new Point(11, 6),
                new Point(15, 6),
                new Point(17, 6),
                new Point(18, 6),
                new Point(23, 6),
                new Point(25, 6),
                new Point(11, 7),
                new Point(17, 7),
                new Point(25, 7),
                new Point(12, 8),
                new Point(16, 8),
                new Point(13, 9),
                new Point(14, 9),
            }));

            structures.Add(new Structure("c/2", "Puffeur", new List<Point>
            {
                new Point(6, 1),
                new Point(7, 2),
                new Point(1, 3),
                new Point(7, 3),
                new Point(2, 4),
                new Point(3, 4),
                new Point(4, 4),
                new Point(5, 4),
                new Point(6, 4),
                new Point(7, 4),
                new Point(1, 7),
                new Point(2, 7),
                new Point(3, 7),
                new Point(1, 8),
                new Point(2, 8),
                new Point(5, 9),
                new Point(5, 10),
                new Point(6, 10),
                new Point(6, 11),
                new Point(7, 11),
                new Point(5, 12),
                new Point(6, 12),
                new Point(5, 16),
                new Point(6, 16),
                new Point(6, 17),
                new Point(7, 17),
                new Point(5, 18),
                new Point(6, 18),
                new Point(5, 19),
                new Point(1, 20),
                new Point(2, 20),
                new Point(1, 21),
                new Point(2, 21),
                new Point(3, 21),
                new Point(2, 24),
                new Point(3, 24),
                new Point(4, 24),
                new Point(5, 24),
                new Point(6, 24),
                new Point(7, 24),
                new Point(1, 25),
                new Point(7, 25),
                new Point(6, 27),
                new Point(7, 26),
            }));

            structures.Add(new Structure("Spatial Rake", "Rake", new List<Point>
            {
                new Point(12, 1),
                new Point(13, 1),
                new Point(19, 1),
                new Point(20, 1),
                new Point(21, 1),
                new Point(22, 1),
                new Point(10, 2),
                new Point(11, 2),
                new Point(13, 2),
                new Point(14, 2),
                new Point(18, 2),
                new Point(22, 2),
                new Point(10, 3),
                new Point(11, 3),
                new Point(12, 3),
                new Point(13, 3),
                new Point(22, 3),
                new Point(11, 4),
                new Point(12, 4),
                new Point(18, 4),
                new Point(21, 4),
                new Point(19, 7),
                new Point(20, 8),
                new Point(20, 9),
                new Point(19, 10),
                new Point(20, 10),
                new Point(18, 11),
                new Point(19, 15),
                new Point(20, 15),
                new Point(21, 15),
                new Point(22, 15),
                new Point(1, 16),
                new Point(4, 16),
                new Point(18, 16),
                new Point(22, 16),
                new Point(5, 17),
                new Point(22, 17),
                new Point(1, 18),
                new Point(5, 18),
                new Point(18, 18),
                new Point(21, 18),
                new Point(2, 19),
                new Point(3, 19),
                new Point(4, 19),
                new Point(5, 19),
            }));

            structures.Add(new Structure("Unstable RM 4x8", "Rotating machine", new List<Point>
            {
                new Point(2, 1),
                new Point(1, 2),
                new Point(3, 2),
                new Point(1, 4),
                new Point(4, 4),
                new Point(3, 5),
                new Point(4, 5),
                new Point(4, 6),
            }));

            structures.Add(new Structure("Tiniest RM 8x6", "Rotating machine", new List<Point>
            {
                new Point(7, 1),
                new Point(5, 2),
                new Point(7, 2),
                new Point(8, 2),
                new Point(5, 3),
                new Point(7 ,3),
                new Point(5, 4),
                new Point(3, 5),
                new Point(1, 6),
                new Point(3, 6),
            }));

            structures.Add(new Structure("RM 5x5", "Rotating machine", new List<Point>
            {
                new Point(1, 1),
                new Point(2, 1),
                new Point(3, 1),
                new Point(5, 1),
                new Point(1, 2),
                new Point(4, 3),
                new Point(5, 3),
                new Point(2, 4),
                new Point(3, 4),
                new Point(5, 4),
                new Point(1, 5),
                new Point(3, 5),
                new Point(5, 5),
            }));

            structures.Add(new Structure("Line RM 1x39", "Rotating machine", new List<Point>
            {
                new Point(2, 2),
                new Point(3, 2),
                new Point(4, 2),
                new Point(5, 2),
                new Point(6, 2),
                new Point(7, 2),
                new Point(8, 2),
                new Point(9, 2),
                new Point(11, 2),
                new Point(12, 2),
                new Point(13, 2),
                new Point(14, 2),
                new Point(15, 2),
                new Point(19, 2),
                new Point(20, 2),
                new Point(21, 2),
                new Point(28, 2),
                new Point(29, 2),
                new Point(30, 2),
                new Point(31, 2),
                new Point(32, 2),
                new Point(33, 2),
                new Point(34, 2),
                new Point(36, 2),
                new Point(37, 2),
                new Point(38, 2),
                new Point(39, 2),
                new Point(40, 2),
            }));

            structures.Add(new Structure("Pentomino R", "Methuselah", new List<Point>
            {
                new Point(2, 1),
                new Point(2, 2),
                new Point(3, 2),
                new Point(1, 3),
                new Point(2, 3),
            }));

            structures.Add(new Structure("Acorn", "Methuselah", new List<Point>
            {
                new Point(2, 1),
                new Point(4, 2),
                new Point(1, 3),
                new Point(2, 3),
                new Point(5, 3),
                new Point(6, 3),
                new Point(7, 3),
            }));

            structures.Add(new Structure("Rabbits", "Methuselah", new List<Point>
            {
                new Point(5, 1),
                new Point(7, 1),
                new Point(1, 2),
                new Point(3, 2),
                new Point(6, 2),
                new Point(2, 3),
                new Point(6, 3),
                new Point(2, 4),
                new Point(8, 4)
            }));

            structures.Add(new Structure("Butterfly", "Methuselah", new List<Point>
            {
                new Point(1, 1),
                new Point(1, 2),
                new Point(2, 2),
                new Point(1, 3),
                new Point(3, 3),
                new Point(2, 4),
                new Point(3, 4),
                new Point(4, 4)
            }));

            // https://upload.wikimedia.org/wikipedia/commons/9/98/Spacefiller.jpg
            structures.Add(new Structure("Spacefiller", "Spacefiller", new List<Point>
            {
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point(),
                new Point()
            }));

            string filePath = "C:\\Users\\cccvs0249\\Desktop\\temp\\lifeStructure.json";
            StreamWriter fileStream = File.CreateText(filePath);
            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Formatting = Formatting.Indented;
            jsonSerializer.Serialize(fileStream, structures);
        }
    }
}
