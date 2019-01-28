using System;
using System.Collections.Generic;
using System.Text;
using Avalonia;
using ReactiveUI;
using System.Linq;
using static System.Math;
using Avalonia.Controls.Shapes;
using Avalonia.Media.Immutable;

namespace CanvasTesting.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private int sides = 5;
        private int radius = 10;
        private double angle = 90;
        public int Sides
        {
            get => sides;
            set => this.RaiseAndSetIfChanged(ref sides, value);
        }

        public int Radius
        {
            get => radius;
            set => this.RaiseAndSetIfChanged(ref radius, value);
        }

        public double Angle
        {
            get => angle;
            set => this.RaiseAndSetIfChanged(ref angle, value);
        }

        //private readonly ImmutableSolidColorBrush brush = new ImmutableSolidColorBrush(0xC0C0C0);
        //public List<LinePointsViewModel> Lines
        //{
        //    get
        //    {
        //        List<LinePointsViewModel> list = new List<LinePointsViewModel>();
        //        var points = Enumerable.Range(0, sides).Select(i => new Point(GenX(i), GenY(i))).ToList();
        //        if (sides % 3 == 0)
        //        {
        //            foreach (int i in Enumerable.Range(0, sides))
        //            {
        //                list.Add(new LinePointsViewModel
        //                {
        //                    Start = points[i],
        //                    End = points[(i + sides / 3) % sides]
        //                });
        //            }
        //        }
        //        else if (sides % 4 == 0)
        //        {
        //            foreach (int i in Enumerable.Range(0, sides))
        //            {
        //                list.Add(new LinePointsViewModel
        //                {
        //                    Start = points[i],
        //                    End = points[(i + sides / 4) % sides]
        //                });
        //            }
        //        }
        //        else if (sides % 2 == 0)
        //        {
        //            foreach (int i in Enumerable.Range(0, sides))
        //            {
        //                list.Add(new LinePointsViewModel
        //                {
        //                    Start = points[i],
        //                    End = points[(i + 3) % sides]
        //                });
        //            }
        //        }
        //        else
        //        {
        //            foreach (int i in Enumerable.Range(0, sides))
        //            {
        //                list.Add(new LinePointsViewModel
        //                {
        //                    Start = points[i],
        //                    End = points[(i + sides / 2) % sides]
        //                });
        //            }
        //        }
        //        return list;
        //    }
        //}

        //private double GenX(int ctr) => radius * Cos(2 * PI * ctr / sides + angle * PI / 180) + (canvasWidth / 2.0);
        //private double GenY(int ctr) => radius * Sin(2 * PI * ctr / sides + angle * PI / 180) + (canvasHeight / 2.0);
    }

}
