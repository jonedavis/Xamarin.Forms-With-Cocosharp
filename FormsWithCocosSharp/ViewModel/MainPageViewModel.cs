using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FormsWithCocosSharp
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private Game _game;

        public MainPageViewModel(Game scoring)
        {
            this._game = scoring;
            this._game.PropertyChanged += (sender, e) => {
                var sc = sender as Game;

                switch (e.PropertyName)
                {
                    case nameof(sc.BestScore):
                        this.RaisePropertyChanged(nameof(BestScoreStr));
                        break;
                    case nameof(sc.CurrentScore):
                        this.RaisePropertyChanged(nameof(CurrentScore));
                        break;
                    case nameof(sc.Deaths):
                        this.RaisePropertyChanged(nameof(DeathsStr));
                        break;
                    case nameof(sc.Jumps):
                        this.RaisePropertyChanged(nameof(JumpsStr));
                        break;
                    case nameof(sc.IsPlaying):
                        this.RaisePropertyChanged(nameof(ShowAllLabels));
                        break;
                }
            };
        }

        public int CurrentScore
        {
            get
            {
                return this._game.CurrentScore;
            }
        }

        public string DeathsStr
        {
            get
            {
                return string.Format("Deaths: {0}", this._game.Deaths);
            }
        }

        public string BestScoreStr
        {
            get
            {
                return string.Format("Best score: {0}", this._game.BestScore);
            }
        }

        public string JumpsStr
        {
            get
            {
                return string.Format("Jumps: {0}", this._game.Jumps);
            }
        }

        public bool ShowAllLabels
        {
            get
            {
                return !this._game.IsPlaying;
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

