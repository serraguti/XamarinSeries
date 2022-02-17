using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinSeries.ViewModels;

namespace XamarinSeries.Services
{
    public class ServiceIoC
    {
        private IContainer container;

        public ServiceIoC()
        {
            this.RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<SeriesViewModel>();
            builder.RegisterType<ServiceSeries>();
            builder.RegisterType<SerieDetailsViewModel>();
            this.container = builder.Build();
        }

        public SerieDetailsViewModel SerieDetailsViewModel
        {
            get
            {
                return this.container.Resolve<SerieDetailsViewModel>();
            }
        }

        public SeriesViewModel SeriesViewModel
        {
            get
            {
                return this.container.Resolve<SeriesViewModel>();
            }
        }
    }
}
