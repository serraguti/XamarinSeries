using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinSeries.Base;
using XamarinSeries.Models;
using XamarinSeries.Services;
using XamarinSeries.Views;

namespace XamarinSeries.ViewModels
{
    public class SeriesViewModel: ViewModelBase
    {
        private ServiceSeries service;

        public SeriesViewModel()
        {
            this.service = new ServiceSeries();
            Task.Run(async () =>
            {
                await this.LoadSeriesAsync();
            });
        }

        private ObservableCollection<Serie> _Series;

        public ObservableCollection<Serie> Series
        {
            get { return this._Series; }
            set {
                this._Series = value;
                OnPropertyChanged("Series");
            }
        }

        private async Task LoadSeriesAsync()
        {
            List<Serie> series = await this.service.GetSeriesAsync();
            this.Series = new ObservableCollection<Serie>(series);
        }

        public Command ShowSerieDetails
        {
            get
            {
                return new Command(async(objeto) =>
                {
                    Serie serie = objeto as Serie;
                    SerieDetailsViewModel viewmodel =
                    App.ServiceLocator.SerieDetailsViewModel;
                    viewmodel.Serie = serie;
                    SerieDetailsView view =
                    new SerieDetailsView();
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }
    }
}
