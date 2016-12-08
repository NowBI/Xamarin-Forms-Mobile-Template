using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileTemplate.Core.Services;
using Xamarin.Forms;

namespace MobileTemplate.Core.Test.Mocks
{
    public class MockNavigationService : INavigationService
    {
        private readonly Stack<Page> _pages;

        public MockNavigationService()
        {
            _pages = new Stack<Page>();
        }

        public IReadOnlyList<Page> NavigationStack => _pages.ToList();

        public async Task Push(Page page, bool animated = true)
        {
            _pages.Push(page);
        }

        public async Task<Page> Pop(bool animated = true)
        {
            return _pages.Pop();
        }

        public async Task PopToRoot(bool animated = true)
        {
            while (_pages.Count > 1)
            {
                _pages.Pop();
            }
        }

        public void ResetStack(Page page)
        {
            _pages.Clear();
            _pages.Push(page);
        }
    }
}
