﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFScadaDashboard.DashboardConfigClasses;
using WPFScadaDashboard.DashboardDataPointClasses;
using WPFScadaDashboard.DashboardUserControls;

namespace WPFScadaDashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DashboardUC DashboardUC_;
        public MainWindow()
        {
            InitializeComponent();
            // load a dashboard in the view space            
            DashboardConfig dashboardConfig = new DashboardConfig("Example Dashboard");
            DashboardUC_ = new DashboardUC(dashboardConfig);
            MainContainer.Content = DashboardUC_;
            this.Title = DashboardUC_.DashboardConfig_.DashboardName_;
            AddSeedCells();
        }

        public void AddSeedCells()
        {
            LinePlotCellConfig linePlotCellConfig = new LinePlotCellConfig
            {
                Name_ = "First Cell Name",
                CellPosition_ = new DashboardCellPosition(0,0,1,2),
                TimeSeriesPoints_ = new List<IDashboardTimeSeriesPoint> { new DashboardScadaTimeSeriesPoint(new ScadaDataPoint("123"), DateTime.Now.AddHours(-10), DateTime.Now) }
            };
            LinePlotCellConfig linePlotCellConfig2 = new LinePlotCellConfig
            {
                Name_ = "Second Cell Name",
                CellPosition_ = new DashboardCellPosition(1, 0)
            };
            LinePlotCellConfig linePlotCellConfig3 = new LinePlotCellConfig
            {
                Name_ = "Third Cell Name",
                CellPosition_ = new DashboardCellPosition(1, 1)
            };
            DashboardUC_.AddDashBoardCells(linePlotCellConfig);
            DashboardUC_.AddDashBoardCells(linePlotCellConfig2);
            DashboardUC_.AddDashBoardCells(linePlotCellConfig3);
        }
    }
}
