using UIKit;


[assembly: Xamarin.Forms.Dependency (typeof (FormsWithCocosSharp.iOS.UIDevice))]
namespace FormsWithCocosSharp.iOS
{
    public class UIDevice : IUIDevice
    {
        #region IUIDevice implementation
        public int ScreenWidth
        {
            get
            {
                return (int)(UIScreen.MainScreen.Bounds.Width * UIScreen.MainScreen.Scale);
            }
        }
        public int ScreenHeight
        {
            get
            {
                return (int)(UIScreen.MainScreen.Bounds.Height * UIScreen.MainScreen.Scale);
            }
        }

        public float Scale
        {
            get
            {
                return this.ScreenWidth / 200f;
            }
        }
        #endregion
    }
}

