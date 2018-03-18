﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFScadaDashboard.DashboardDataPointClasses;

namespace WPFScadaDashboard.DashboardConfigClasses
{
    public class LinePlotCellConfig : IDashboardCellConfig
    {
        public const string CellType = "Time_Series_Line_Plot";
        public const string AbsoluteWidthMode = "absolute";
        public const string AbsoluteHeightMode = "absolute";
        public const string VariableWidthMode = "variable";
        public const string VariableHeightMode = "variable";

        public string Name_ { get; set; } = "Line Plot Cell";

        public double MinWidth_ { get; set; } = 0;

        public double MinHeight_ { get; set; } = 0;

        public double Width_ { get; set; } = 100;

        public double Height_ { get; set; } = 100;

        public string WidthMode_ = AbsoluteWidthMode;

        public string HeightMode_ = AbsoluteHeightMode;

        // Cell Position
        public DashboardCellPosition CellPosition_ { get; set; } = new DashboardCellPosition();

        // Data Points of the plots that are used for fetching data for line plots
        public List<IDashboardTimeSeriesPoint> TimeSeriesPoints_ { get; set; } = new List<IDashboardTimeSeriesPoint>();

        // constructor
        public LinePlotCellConfig()
        {
        }

        // Implementing Interface
        public string GetName()
        {
            return Name_;
        }

        // Implementing Interface
        public DashboardCellPosition GetCellPosition()
        {
            return CellPosition_;
        }

        // Implementing Interface
        public void SetCellPosition(DashboardCellPosition cellPosition)
        {
            CellPosition_ = cellPosition;
        }

        // Implementing Interface
        public string GetVizType()
        {
            return CellType;
        }

        // Implementing Interface
        public List<IDataPoint> GetCellDataPoints()
        {
            List<IDataPoint> dataPoints = new List<IDataPoint>();
            for (int i = 0; i < TimeSeriesPoints_.Count; i++)
            {
                dataPoints.Add(TimeSeriesPoints_.ElementAt(i).GetDataPoint());
            }
            return dataPoints;
        }

        // Implementing Interface
        public double GetCellWidth()
        {
            return Width_;
        }

        // Implementing Interface
        public double GetCellHeight()
        {
            return Height_;
        }

        // Implementing Interface
        public string GetWidthMode()
        {
            return WidthMode_;
        }

        // Implementing Interface
        public string GetHeightMode()
        {
            return HeightMode_;
        }

        // Implementing Interface
        public void SetCellWidth(double width)
        {
            Width_ = width;
        }

        // Implementing Interface
        public void SetCellHeight(double height)
        {
            Height_ = height;
        }

        // Implementing Interface
        public void SetWidthMode(string mode)
        {
            if (mode != AbsoluteWidthMode && mode != VariableWidthMode)
            {
                WidthMode_ = AbsoluteWidthMode;
            }
            WidthMode_ = mode;
        }

        // Implementing Interface
        public void SetHeightMode(string mode)
        {
            if (mode != AbsoluteHeightMode && mode != VariableWidthMode)
            {
                HeightMode_ = AbsoluteHeightMode;
            }
            HeightMode_ = mode;
        }
    }
}