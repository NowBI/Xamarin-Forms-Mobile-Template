using System;
using MobileTemplate.Core.Extensions;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.ThemeSample
{
    public partial class DarkThemeSampleView : ScrollView, IDisposable
    {
        public DarkThemeSampleView()
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
