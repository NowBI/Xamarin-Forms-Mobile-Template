using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileTemplate.Core.Services
{
    public interface INavigationService
    {
        Task Push(Page page, bool animated = true);
        Task<Page> Pop(bool animated = true);
        Task PopToRoot(bool animated = true);
        void ResetStack(Page page);
    }

    public class NavigationService : INavigationService
    {
        public Task Push(Page page, bool animated = true)
        {
            return GetNavigationPage().PushAsync(page, animated);
        }

        public Task<Page> Pop(bool animated = true)
        {
            return GetNavigationPage().PopAsync(animated);
        }

        public Task PopToRoot(bool animated = true)
        {
            return GetNavigationPage().PopToRootAsync(animated);
        }

        public void ResetStack(Page page)
        {
            var masterDetailPage = GetMasterDetailPage();
            masterDetailPage.Detail = new NavigationPage(page);
            masterDetailPage.IsPresented = false;
        }

        private MasterDetailPage GetMasterDetailPage()
        {
            var page = App.Current.MainPage as MasterDetailPage;
            if (page == null)
            {
                throw new Exception("The base page was not a Master Detail Page.");
            }
            return page;
        }

        private NavigationPage GetNavigationPage()
        {
            var page = App.Current.MainPage as NavigationPage;
            if (page == null)
            {
                page = GetMasterDetailPage()?.Detail as NavigationPage;
                if (page == null)
                {
                    throw new Exception("Could not find a Navigation Page amongt the Main Page nor the Master Detail Page.");
                }
            }
            return page;
        }
    }
}
