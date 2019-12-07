﻿using System;
using System.Collections.Generic;
using System.Media;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Model.Model;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        public Func<string> OpenFileDialog { get; } = BrowseForFile;

        public Action PlaySound { get; } = SystemSounds.Beep.Play;

        public Action<Graph, Path> DrawGraphs => DrawNetworkAndGanttGraphs;

        private static void DrawNetworkAndGanttGraphs(Graph g, Path cp)
        {
           Task.Run(() => Graphs.NetworkDiagram.Draw(g));
           Task.Run(() => Graphs.GanttChart.Draw(g, cp));
        }

        private static string BrowseForFile()
        {
            var dialog = new OpenFileDialog();
            return dialog.ShowDialog().GetValueOrDefault() ? dialog.FileName : null;
        }
    }
}
