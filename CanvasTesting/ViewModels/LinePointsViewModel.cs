using ReactiveUI;
using System;
using System.Collections.Generic;
using Avalonia;
using System.Text;

namespace CanvasTesting.ViewModels
{

    public class LinePointsViewModel : ReactiveObject
    {
        public Point Start { get; set; }
        public Point End { get; set; }
    }
}
