using System;
using MobileTemplate.Core.Services;
using Reactive.Bindings;

namespace MobileTemplate.Core.Pages.Landing
{
    public class LandingMenuItemViewModel : IDisposable
    {
        public IReadOnlyReactiveProperty<string> ImageSource { get; }
        public IReadOnlyReactiveProperty<string> Title { get; }
        public ReactiveCommand Tapped { get; }

        private readonly IDisposable _tappedSubscription;

        public LandingMenuItemViewModel(MenuItemViewModel viewModel, INavigationService navigationService)
        {
            Title = viewModel.Title.ToReadOnlyReactiveProperty();
            ImageSource = viewModel.ImageSource.ToReadOnlyReactiveProperty();
            Tapped = new ReactiveCommand();
            _tappedSubscription = Tapped.Subscribe((x) => { navigationService.Push(viewModel.CreatePage.Invoke()); });
        }

        public void Dispose()
        {
            ImageSource?.Dispose();
            Title?.Dispose();
            _tappedSubscription?.Dispose();
            Tapped?.Dispose();
        }
    }
}
