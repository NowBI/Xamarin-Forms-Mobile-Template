using System;
using System.Collections.Generic;
using Autofac;
using MobileTemplate.Core.Extensions;
using MobileTemplate.Core.Services;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Landing
{
    public partial class LandingView : ScrollView, IDisposable
    {
        private readonly IDisposable _subviewSubscription;

        public LandingView()
        {
            InitializeComponent();

            var image = "nbi_logo.png";
            var text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc odio sem, tempor laoreet orci ac, tempor volutpat odio.";

            var menuItemService = IoC.Container.Resolve<IMenuItemService>();
            var navigationService = IoC.Container.Resolve<INavigationService>();
            var viewModel = new LandingPageViewModel(text, image, menuItemService, navigationService);
            _subviewSubscription = viewModel.MenuItems.Subscribe(UpdateSubviews);
            BindingContext = viewModel;
        }
        
        private void UpdateSubviews(IEnumerable<LandingMenuItemViewModel> viewModels)
        {
            NavigationStack.Children.Clear();
            foreach (var viewModel in viewModels)
            {
                var view = new LandingMenuItemButton {BindingContext = viewModel};
                NavigationStack.Children.Add(view);
            }
        }

        public void Dispose()
        {
            _subviewSubscription?.Dispose();
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
