using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Styling;
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

        public static readonly StyledProperty<uint> PointsProperty = AvaloniaProperty.Register<Star, uint>(nameof(Points),3);
        public uint Points
        {
            get => GetValue(PointsProperty);
            set
            {
                if (value < 3) throw new ArgumentOutOfRangeException(nameof(value), value, "Points Cannot be less than 3. Actual {0}.");
                if (Points != value)
                {
                    List<LinePointsViewModel> old = Lines;
                    this.SetValue(PointsProperty, value);
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
                var listPoints = Enumerable.Range(0, (int)Points).Select(i => new Point(GenX(i), GenY(i))).ToList();

                if (Points % 4 == 0 && drawMode.HasFlag(DrawModes.Square))
                {
                    foreach (int i in Enumerable.Range(0, (int)Points))
                    {
                        list.Add(new LinePointsViewModel
                        {
                            Start = listPoints[i],
                            End = listPoints[(i + (int)Points / 4) % (int)Points]
                        });
                    }
                }
                else if (Points % 3 == 0 && drawMode.HasFlag(DrawModes.Triangle))
                {
                    foreach (int i in Enumerable.Range(0, (int)Points))
                    {
                        list.Add(new LinePointsViewModel
                        {
                            Start = listPoints[i],
                            End = listPoints[(int)(i + Points / 3) % (int)Points]
                        });
                    }
                }
                else if (Points % 2 == 0 && drawMode.HasFlag(DrawModes.PassTwo))
                {
                    foreach (int i in Enumerable.Range(0, (int)Points))
                    {
                        list.Add(new LinePointsViewModel
                        {
                            Start = listPoints[i],
                            End = listPoints[(i + 3) % (int)Points]
                        });
                    }
                }
                else if (drawMode.HasFlag(DrawModes.Oppisite))
                {
                    foreach (int i in Enumerable.Range(0, (int)Points))
                    {
                        list.Add(new LinePointsViewModel
                        {
                            Start = listPoints[i],
                            End = listPoints[(i + (int)Points / 2) % (int)Points]
                        });
                    }
                }
                else if (drawMode.HasFlag(DrawModes.PassTwo))
                {
                    foreach (int i in Enumerable.Range(0, (int)Points))
                    {
                        list.Add(new LinePointsViewModel
                        {
                            Start = listPoints[i],
                            End = listPoints[(i + 3) % (int)Points]
                        });
                    }
                }
                else if (drawMode.HasFlag(DrawModes.PassOne))
                {
                    foreach (int i in Enumerable.Range(0, (int)Points))
                    {
                        list.Add(new LinePointsViewModel
                        {
                            Start = listPoints[i],
                            End = listPoints[(i + 2) % (int)Points]
                        });
                    }
                }
                return list;
            }
        }


        private double GenX(int ctr) => radius * Cos(2 * PI * ctr / Points) + Bounds.Center.X;
        private double GenY(int ctr) => radius * Sin(2 * PI * ctr / Points) + Bounds.Center.Y;

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
