using System;

namespace FormsWithCocosSharp
{
    public interface IUIDevice
    {
        int ScreenWidth { get; }
        int ScreenHeight { get; }
        float Scale { get; }
    }
}