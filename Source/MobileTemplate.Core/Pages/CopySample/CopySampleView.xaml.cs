using System;
using MobileTemplate.Core.Extensions;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.CopySample
{
    public partial class CopySampleView : ScrollView, IDisposable
    {
        public CopySampleView()
        {
            InitializeComponent();
            var viewModel = new CopySampleViewModel();
            BindingContext = viewModel;
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
