using System;
using Android.Content.Res;
using FormsWithCocosSharp.Droid;

[assembly: Xamarin.Forms.Dependency (typeof (UIDevice))]
namespace FormsWithCocosSharp.Droid
{
    public class UIDevice : IUIDevice
    {
        #region IUIDevice implementation
        public int ScreenWidth
        {
            get
            {
                return (int)Resources.System.DisplayMetrics.WidthPixels;
            }
        }


        public int ScreenHeight
        {
            get
            {
                return (int)Resources.System.DisplayMetrics.HeightPixels;
            }
        }


        public float Scale
        {
            get
            {
                return this.ScreenWidth / 200;
            }
        }
        #endregion
    }
}