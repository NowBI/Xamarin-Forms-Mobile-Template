using MobileTemplate.Core.Services;
using Xamarin.Forms;

namespace MobileTemplate.Droid.Service
{
    public class SampleServiceDroid : SampleService
    {
        public SampleServiceDroid(INavigationService navigationService) : base(navigationService)
        {
        }

        public override string PlatformText { get; } = "Open an Android-specific Page";

        public override void PlatformCommand()
        {
            NavigationService.Push(new ContentPage
            {
                Title = "Droid Page",
                Content = new Label
                {
                    Text = "This is a page popped up for Android!",
                    TextColor = Color.Yellow
                },
                BackgroundColor = Color.Green
            });
        }
    }
}