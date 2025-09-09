using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Global360Test.Pages.Sections
{
    enum NavbarItems
    {
        Asset,
        License,
        Accessory,
        Consumable,
        Component,
        User
    }
    internal class Navbar
    {
        public readonly IPage _page;
        public readonly ILocator _createDropdown;

        public Navbar(IPage page)
        {
            _page = page;
            _createDropdown = page.Locator("text=Create New");
        }

        public async Task Create(NavbarItems item)
        {
            await _createDropdown.ClickAsync();
            // Wait for dropdown and click Asset
            await _page.WaitForSelectorAsync(".dropdown-menu", new() { State = WaitForSelectorState.Visible });

            switch (item)
            {
                // Only asset is implemented for now
                case NavbarItems.Asset:
                    await _page.WaitForSelectorAsync("a[href*='/hardware/create']", new() { State = WaitForSelectorState.Visible });
                    await _page.ClickAsync("a[href*='/hardware/create']");
                    await _page.WaitForURLAsync("**/hardware/create");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(item), item, null);
            }
            
        }
    }
}
