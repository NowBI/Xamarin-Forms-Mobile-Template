using System;
using Reactive.Bindings;

namespace MobileTemplate.Core.Pages.Menu
{
    public class MainMenuItemViewModel : IDisposable
    {
        public IReactiveProperty<string> ImageSource { get; }
        public IReactiveProperty<string> Title { get; }
        public ReactiveCommand Tapped { get; }

        private readonly IDisposable _tappedSubscription;

        public MainMenuItemViewModel(string title, string imageSource, Action<object> tapped)
        {
            Title = new ReactiveProperty<string>(title);
            ImageSource = new ReactiveProperty<string>(imageSource);
            Tapped = new ReactiveCommand();
            _tappedSubscription = Tapped.Subscribe(tapped);
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
