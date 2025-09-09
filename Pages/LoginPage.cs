using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Global360Test.Pages
{

    internal class LoginPage
    {
        private readonly IPage _page;
        private readonly ILocator _username;
        private readonly ILocator _password;
        private readonly ILocator _btnLogin;

        public LoginPage(IPage page)
        {
            _page = page;
            _username = page.Locator("#username");
            _password = page.Locator("#password");
            _btnLogin = page.Locator("#submit");
        }

        public async Task Login(string username, string password)
        {
            await _username.FillAsync(username);
            await _password.FillAsync(password);
            await _btnLogin.ClickAsync();

        }

        public async Task GoTo()
        {
            await _page.GotoAsync("https://demo.snipeitapp.com/login");
        }

    }
}
