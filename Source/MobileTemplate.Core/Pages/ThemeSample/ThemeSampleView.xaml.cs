using System;
using MobileTemplate.Core.Extensions;
using MobileTemplate.Core.Pages.ReactiveSample;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.ThemeSample
{
    public partial class ThemeSampleView : ScrollView, IDisposable
    {
        public ThemeSampleView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
