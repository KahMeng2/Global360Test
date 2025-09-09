using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global360Test.Pages.Sections;
using Microsoft.Playwright;

namespace Global360Test.Pages
{
    internal class AssetDashboard
    {
        private readonly IPage _page;
        private readonly ILocator _searchBar;
        public Navbar navbar;

        public AssetDashboard(IPage page)
        {
            _page = page;
            _searchBar = page.Locator("input.form-control.search-input");
            navbar = new Navbar(page);
        }


        public async Task GoTo()
        {
            await _page.GotoAsync("https://demo.snipeitapp.com/hardware");
        }

        // Searches asset in asset page.
        public async Task SearchAsset(string assetTag)
        {
            await _searchBar.FillAsync(assetTag);
            await _searchBar.PressAsync("Enter");
            
            // Click on the asset tag link to navigate to asset details
            var assetLink = _page.Locator($"td a:has-text('{assetTag}')");

            // Check if asset exists
            var count = await assetLink.CountAsync();
            if (count == 0)
            {
                throw new AssertionException($"Asset with tag '{assetTag}' was not found in search results");
            }

            await assetLink.ClickAsync();

            // Wait for the search results to load
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }
    }
}
