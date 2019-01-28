using System;

namespace CanvasTesting
{
    [Flags]
    public enum DrawModes
    {
        Oppisite = 0b00001,
        Triangle = 0b00010,
        Square   = 0b00100,
        PassOne  = 0b01000,
        PassTwo  = 0b10000,
        Any      = 0b11111
    }
}
