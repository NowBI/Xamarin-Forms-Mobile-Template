using System;
using Xamarin.Forms;

namespace MobileTemplate.Core.Extensions
{
    public static class DisposalExtensions
    {
        public static void DisposeBindingContext(this BindableObject bindableObject)
        {
            Dispose(bindableObject.BindingContext);
        }

        public static void DisposeChildren<T>(this IViewContainer<T> container) where T : VisualElement
        {
            Dispose(container.Children);
        }

        public static void DisposeContent(this ScrollView scrollView)
        {
            Dispose(scrollView.Content);
        }

        public static void DisposeContent(this ContentView contentView)
        {
            Dispose(contentView.Content);
        }

        public static void DisposeContent(this ContentPage contentPage)
        {
            Dispose(contentPage.Content);
        }

        private static void Dispose(params object[] items)
        {
            foreach (var item in items)
            {
                (item as IDisposable)?.Dispose();
            }
        }
    }
}
