using System;
using System.Collections.Generic;

using Xamarin.Forms;
using CocosSharp;

namespace FormsWithCocosSharp
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _vm;

        public MainPage()
        {
            this._vm = new MainPageViewModel(Game.Instance);
            this.BindingContext = this._vm;
            InitializeComponent();
        }
    }
}

