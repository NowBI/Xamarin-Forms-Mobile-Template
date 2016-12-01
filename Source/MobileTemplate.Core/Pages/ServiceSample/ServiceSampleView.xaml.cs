using System;
using Autofac;
using MobileTemplate.Core.Extensions;
using MobileTemplate.Core.Services;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.ServiceSample
{
    public partial class ServiceSampleView : ScrollView, IDisposable
    {
        public ServiceSampleView()
        {
            InitializeComponent();
            var sampleService = IoC.Container.Resolve<ISampleService>();
            BindingContext = new ServiceSampleViewModel(sampleService);
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
