using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global360Test.Pages.Sections;
using Microsoft.Playwright;

namespace Global360Test.Pages
{
    internal class DashboardPage
    {
        private readonly IPage _page;
        private readonly ILocator _username;
        private readonly ILocator _password;
        private readonly ILocator _btnLogin;
        public Navbar navbar;

        public DashboardPage(IPage page)
        {
            _page = page;
            _username = page.Locator("#username");
            _password = page.Locator("#password");
            _btnLogin = page.Locator("#submit");
            navbar = new Navbar(page);
        }

        
        public async Task GoTo()
        {
            await _page.GotoAsync("https://demo.snipeitapp.com");
        }
    }
}
