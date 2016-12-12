using System;
using Reactive.Bindings;
using Xamarin.Forms;

namespace MobileTemplate.Core.Model.Menu
{
    public class MenuItemModel : IDisposable
    {
        public IReactiveProperty<string> ImageSource { get; }
        public IReactiveProperty<string> Title { get; }
        public Func<Page> CreatePage { get; }

        public MenuItemModel(string title, string imageSource, Func<Page> createPage)
        {
            Title = new ReactiveProperty<string>(title);
            ImageSource = new ReactiveProperty<string>(imageSource);
            CreatePage = createPage;
        }

        public void Dispose()
        {
            ImageSource?.Dispose();
            Title?.Dispose();
        }
    }
}
