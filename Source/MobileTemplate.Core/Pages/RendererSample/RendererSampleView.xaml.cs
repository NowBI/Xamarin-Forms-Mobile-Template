using System;
using MobileTemplate.Core.Extensions;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.RendererSample
{
    public partial class RendererSampleView : ScrollView, IDisposable
    {
        public RendererSampleView()
        {
            InitializeComponent();
            var viewModel = new RendererSampleViewModel();
            BindingContext = viewModel;
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
