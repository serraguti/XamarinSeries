using System;
using System.Collections.Generic;
using System.Text;
using XamarinSeries.Base;
using XamarinSeries.Models;

namespace XamarinSeries.ViewModels
{
    public class SerieDetailsViewModel: ViewModelBase
    {
        private Serie _Serie;

        public Serie Serie
        {
            get { return this._Serie; }
            set {
                this._Serie = value;
                OnPropertyChanged("Serie");
            }
        }
    }
}
