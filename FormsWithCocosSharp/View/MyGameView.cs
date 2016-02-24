using System;
using CocosSharp;
using Xamarin.Forms;

namespace FormsWithCocosSharp
{
    public class MyGameView : CocosSharpView
    {
        GameStartScene gameScene;
        public static int PageHeight;


        public MyGameView()
        {
            this.ViewCreated = this.HandleViewCreated;
        }


        void HandleViewCreated (object sender, EventArgs e)
        {
            var gameView = sender as CCGameView;

            if (gameView != null)
            {
                // This sets the game "world" resolution to 100x100:
                var device = DependencyService.Get<IUIDevice>();

                PageHeight = device.ScreenHeight * 200 / device.ScreenWidth;
                gameView.DesignResolution = new CCSizeI (200, PageHeight);
                gameView.ResolutionPolicy = CCViewResolutionPolicy.ShowAll; 
                gameView.DepthTesting = true;

                // GameScene is the root of the CocosSharp rendering hierarchy:
                gameScene = new GameStartScene (gameView);
                // Starts CocosSharp:
                gameView.RunWithScene (gameScene);
            }
        }
    }
}