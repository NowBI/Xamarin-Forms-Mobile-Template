using System.Linq;
using System.Threading.Tasks;
using MobileTemplate.Core.Services;
using MobileTemplate.Core.Test.Mocks;
using Xamarin.Forms;
using Xunit;

namespace MobileTemplate.Core.Test.Service
{
    public class NavigationServiceTest
    {
        private readonly INavigationService _navigationService;

        public NavigationServiceTest()
        {
            _navigationService = new MockNavigationService();
        }

        [Fact]
        public async void Push_ShouldPutPageAtTopOfStack()
        {
            var page = new ContentPage { Title = "Test Page" };
            Assert.NotEqual(page, _navigationService.NavigationStack.FirstOrDefault());
            await _navigationService.Push(page);
            Assert.Equal(page, _navigationService.NavigationStack.FirstOrDefault());
        }

        [Fact]
        public async void Pop_ShouldRemoveMostRecentPageFromStackAndReturnIt()
        {
            var pageA = new ContentPage { Title = "Test Page A" };
            Assert.NotEqual(pageA, _navigationService.NavigationStack.FirstOrDefault());
            await _navigationService.Push(pageA);
            Assert.Equal(pageA, _navigationService.NavigationStack.FirstOrDefault());

            var pageB = new ContentPage { Title = "Test Page B" };
            Assert.NotEqual(pageB, _navigationService.NavigationStack.FirstOrDefault());
            await _navigationService.Push(pageB);
            Assert.Equal(pageB, _navigationService.NavigationStack.FirstOrDefault());

            var poppedB = await _navigationService.Pop();
            Assert.Equal(pageB, poppedB);
            Assert.NotEqual(pageB, _navigationService.NavigationStack.FirstOrDefault());

            var poppedA = await _navigationService.Pop();
            Assert.Equal(pageA, poppedA);
            Assert.NotEqual(pageA, _navigationService.NavigationStack.FirstOrDefault());
        }

        [Fact]
        public async void PopToRoute_ShouldRemoveAllButLastPage()
        {
            var pageA = new ContentPage { Title = "Test Page A" };
            Assert.NotEqual(pageA, _navigationService.NavigationStack.FirstOrDefault());
            await _navigationService.Push(pageA);
            Assert.Equal(pageA, _navigationService.NavigationStack.FirstOrDefault());

            var pageB = new ContentPage { Title = "Test Page B" };
            Assert.NotEqual(pageB, _navigationService.NavigationStack.FirstOrDefault());
            await _navigationService.Push(pageB);
            Assert.Equal(pageB, _navigationService.NavigationStack.FirstOrDefault());

            var pageC = new ContentPage { Title = "Test Page C" };
            Assert.NotEqual(pageC, _navigationService.NavigationStack.FirstOrDefault());
            await _navigationService.Push(pageC);
            Assert.Equal(pageC, _navigationService.NavigationStack.FirstOrDefault());

            await _navigationService.PopToRoot();
            Assert.Equal(1, _navigationService.NavigationStack.Count);
            Assert.Equal(pageA, _navigationService.NavigationStack.FirstOrDefault());
        }

        [Fact]
        public async void ResetStackShould_ResetTheStackToThePage()
        {
            var pageA = new ContentPage { Title = "Test Page A" };
            Assert.NotEqual(pageA, _navigationService.NavigationStack.FirstOrDefault());
            await _navigationService.Push(pageA);
            Assert.Equal(pageA, _navigationService.NavigationStack.FirstOrDefault());

            var pageB = new ContentPage { Title = "Test Page B" };
            Assert.NotEqual(pageB, _navigationService.NavigationStack.FirstOrDefault());
            await _navigationService.Push(pageB);
            Assert.Equal(pageB, _navigationService.NavigationStack.FirstOrDefault());

            var pageC = new ContentPage { Title = "Test Page C" };
            Assert.NotEqual(pageC, _navigationService.NavigationStack.FirstOrDefault());
            await _navigationService.Push(pageC);
            Assert.Equal(pageC, _navigationService.NavigationStack.FirstOrDefault());

            var pageD = new ContentPage { Title = "Test Page D" };
            Assert.NotEqual(pageD, _navigationService.NavigationStack.FirstOrDefault());

            _navigationService.ResetStack(pageD);
            Assert.Equal(1, _navigationService.NavigationStack.Count);
            Assert.Equal(pageD, _navigationService.NavigationStack.FirstOrDefault());
        }
    }
}