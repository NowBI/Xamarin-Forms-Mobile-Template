using Xamarin.Forms;

namespace MobileTemplate.Core.Services
{
    public interface ISampleService
    {
        string CommonText { get; }
        string PlatformText { get; }
        void CommonCommand();
        void PlatformCommand();
    }

    public abstract class SampleService : ISampleService
    {
        protected readonly INavigationService NavigationService;

        public string CommonText { get; } = "Open a Page Shared by Both Platforms";
        public abstract string PlatformText { get; }

        protected SampleService(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public void CommonCommand()
        {
            NavigationService.Push(new ContentPage
            {
                Title = "Common Page",
                Content = new Label { Text = "This is a common page popped up by the service!" }
            });
        }

        public abstract void PlatformCommand();
    }
}
