using System;
using Autofac;
using MobileTemplate.Core.Extensions;
using MobileTemplate.Core.Services;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.FormSample
{
    public partial class FormSampleView : ScrollView, IDisposable
    {
        public FormSampleView()
        {
            InitializeComponent();
            var navigationService = IoC.Container.Resolve<INavigationService>();
            var viewModel = new FormSampleViewModel(navigationService);
            foreach (var item in viewModel.PickerItems)
            {
                ColorPicker.Items.Add(item.Key);
            }
            BindingContext = viewModel;
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
