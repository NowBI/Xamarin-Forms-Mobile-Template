using System;
using MobileTemplate.Core.Extensions;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.ReactiveSample
{
    public partial class ReactiveSampleView : ScrollView, IDisposable
    {
        public ReactiveSampleView()
        {
            InitializeComponent();
            BindingContext = new ReactiveSampleViewModel();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
