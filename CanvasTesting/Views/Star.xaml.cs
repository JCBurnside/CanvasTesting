using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using CanvasTesting.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;

namespace CanvasTesting.Views
{
    public class Star : UserControl
    {
        public Star()
        {
            this.InitializeComponent();
            this.FindControl<DockPanel>("Container").DataContext = this;
        }

        public static readonly StyledProperty<IBrush> StrokeProperty = AvaloniaProperty.Register<Star, IBrush>(nameof(Stroke), Brushes.Silver);
        public IBrush Stroke
        {
            get => GetValue(StrokeProperty);
            set => SetValue(StrokeProperty, value);
        }

        public static readonly DirectProperty<Star, uint> PointsProperty = AvaloniaProperty.RegisterDirect<Star, uint>(
            nameof(Points),
            o => o.Points,
            (o, v) => o.Points = v, unsetValue: 3);

        private uint points = 3;
        public uint Points
        {
            get => points;
            set
            {
                if (value < 3) throw new ArgumentOutOfRangeException(nameof(value), value, "Points Cannot be less than 3. Actual {0}.");
                if (points != value)
                {
                    List<LinePointsViewModel> old = Lines;
                    SetAndRaise(PointsProperty, ref points, value);
                    this.RaisePropertyChanged(LinesProperty, old, Lines);
                }
            }
        }

        public static readonly DirectProperty<Star, DrawModes> DrawModeProperty = AvaloniaProperty.RegisterDirect<Star, DrawModes>(nameof(DrawMode),
            o => o.DrawMode,
            (o, v) => o.DrawMode = v,
            unsetValue: DrawModes.Any);
        private DrawModes drawMode;
        public DrawModes DrawMode
        {
            get => drawMode;
            set
            {
                if (drawMode != value)
                {
                    List<LinePointsViewModel> old = Lines;
                    this.SetAndRaise(DrawModeProperty, ref drawMode, value);
                    this.RaisePropertyChanged(LinesProperty, old, Lines);
                }
            }
        }

        public static readonly DirectProperty<Star, uint> RadiusProperty = AvaloniaProperty.RegisterDirect<Star, uint>(nameof(Radius),
            o => o.Radius,
            (o, v) => o.Radius = v,
            unsetValue: 1);
        private uint radius;
        public uint Radius
        {
            get => radius;
            set
            {
                if (radius != value)
                {
                    List<LinePointsViewModel> old = Lines;
                    this.SetAndRaise(RadiusProperty, ref radius, value);
                    this.RaisePropertyChanged(LinesProperty, old, Lines);
                }
            }
        }

        public static readonly DirectProperty<Star, List<LinePointsViewModel>> LinesProperty = AvaloniaProperty.RegisterDirect<Star, List<LinePointsViewModel>>(nameof(Lines),
            o => o.Lines);

        public List<LinePointsViewModel> Lines
        {
            get
            {
                List<LinePointsViewModel> list = new List<LinePointsViewModel>();
                var listPoints = Enumerable.Range(0, (int)points).Select(i => new Point(GenX(i), GenY(i))).ToList();

                if (points % 4 == 0 && drawMode.HasFlag(DrawModes.Square))
                {
                    foreach (int i in Enumerable.Range(0, (int)points))
                    {
                        list.Add(new LinePointsViewModel
                        {
                            Start = listPoints[i],
                            End = listPoints[(i + (int)points / 4) % (int)points]
                        });
                    }
                }
                else if (points % 3 == 0 && drawMode.HasFlag(DrawModes.Triangle))
                {
                    foreach (int i in Enumerable.Range(0, (int)points))
                    {
                        list.Add(new LinePointsViewModel
                        {
                            Start = listPoints[i],
                            End = listPoints[(int)(i + points / 3) % (int)points]
                        });
                    }
                }
                else if (points % 2 == 0 && drawMode.HasFlag(DrawModes.PassTwo))
                {
                    foreach (int i in Enumerable.Range(0, (int)points))
                    {
                        list.Add(new LinePointsViewModel
                        {
                            Start = listPoints[i],
                            End = listPoints[(i + 3) % (int)points]
                        });
                    }
                }
                else if (drawMode.HasFlag(DrawModes.Oppisite))
                {
                    foreach (int i in Enumerable.Range(0, (int)points))
                    {
                        list.Add(new LinePointsViewModel
                        {
                            Start = listPoints[i],
                            End = listPoints[(i + (int)points / 2) % (int)points]
                        });
                    }
                }
                else if (drawMode.HasFlag(DrawModes.PassTwo))
                {
                    foreach (int i in Enumerable.Range(0, (int)points))
                    {
                        list.Add(new LinePointsViewModel
                        {
                            Start = listPoints[i],
                            End = listPoints[(i + 3) % (int)points]
                        });
                    }
                }
                else if (drawMode.HasFlag(DrawModes.PassOne))
                {
                    foreach (int i in Enumerable.Range(0, (int)points))
                    {
                        list.Add(new LinePointsViewModel
                        {
                            Start = listPoints[i],
                            End = listPoints[(i + 2) % (int)points]
                        });
                    }
                }
                return list;
            }
        }


        private double GenX(int ctr) => radius * Cos(2 * PI * ctr / points) + Bounds.Center.X;
        private double GenY(int ctr) => radius * Sin(2 * PI * ctr / points) + Bounds.Center.Y;

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
