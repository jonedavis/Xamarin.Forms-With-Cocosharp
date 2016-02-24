using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FormsWithCocosSharp
{
    public class Game : INotifyPropertyChanged
    {
        public Game() { }

        private static Game _instance;
       

		public static Game Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Game();
                }
                return _instance;
            }
        }


        private int _currentScore;
      

		public int CurrentScore
        {
            get
            {
                return _currentScore;
            }
            set
            {
                if (this._currentScore == value)
                    return;
                this._currentScore = value;
                if (value > this.BestScore)
                    this.BestScore = value;
                this.RaisePropertyChanged();
            }
        }


        private bool _isPlaying;


        public bool IsPlaying
        {
            get
            {
                return this._isPlaying;
            }
            set
            {
                if (this._isPlaying == value)
                    return;
                this._isPlaying = value;
                this.RaisePropertyChanged();
            }
        }


        private int _deaths;


        public int Deaths
        {
            get
            {
                return this._deaths;
            }
            set
            {
                if (this._deaths == value)
                    return;
                this._deaths = value;
                this.RaisePropertyChanged();
            }
        }


        private int _bestScore;


        public int BestScore
        {
            get
            {
                return this._bestScore;
            }
            set
            {
                if (this._bestScore == value)
                    return;
                this._bestScore = value;
                this.RaisePropertyChanged();
            }
        }
        

        private int _jumps;


        public int Jumps
        {
            get
            {
                return this._jumps;
            }
            set
            {
                if (this._jumps == value)
                    return;
                this._jumps = value;
                this.RaisePropertyChanged();
            }
        }


        #region INotifyPropertyChanged implementation


        public event PropertyChangedEventHandler PropertyChanged;

        
		public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var h = this.PropertyChanged;
            if (h != null)
                h(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}