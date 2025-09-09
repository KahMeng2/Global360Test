using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global360Test.Models;
using Global360Test.Pages.Sections;
using Microsoft.Playwright;

namespace Global360Test._pages
{
    internal class CreateAssetPage
    {
        private readonly IPage _page;
        private readonly ILocator _assetTag;
        private readonly ILocator _status;
        private readonly ILocator _statusDropdown;

        private readonly ILocator _checkoutTo;
        private readonly ILocator _checkoutToDropdown;

        private readonly ILocator _model;
        private readonly ILocator _modelDropdown;

        private readonly ILocator _submitBtn;



        public Navbar navbar;

        public CreateAssetPage(IPage page)
        {
            _page = page;
            navbar = new Navbar(page);
            _assetTag = page.Locator("#asset_tag");
            _model = page.Locator("#select2-model_select_id-container");
            _modelDropdown = page.Locator("#select2-model_select_id-results");
            _status = page.Locator("#select2-status_select_id-container");
            _checkoutTo = page.Locator("#select2-assigned_user_select-container");
            _checkoutToDropdown = page.Locator("#select2-assigned_user_select-results");

            _statusDropdown = page.Locator("#select2-status_select_id-results");
            _submitBtn = page.Locator("#submit_button");

        }


        public async Task GoTo()
        {
            await _page.GotoAsync("https://demo.snipeitapp.com/hardware/create");
        }

        public async Task<Asset> FillAssetForm(Asset asset)
        {
            // Fill in the asset tag from page 
            asset.SetAssetTag(await _assetTag.InputValueAsync());

            // Selects the correct model. Abstract this later 


            // Click the Select2 container to open dropdown
            await _model.ClickAsync();
            // Wait for dropdown to appear
            await _modelDropdown.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            // Wait for and click the specific option
            await _modelDropdown.GetByText($"{asset.getModel()}").ClickAsync();

            // Set status of asset
            await _status.ClickAsync();
            await _statusDropdown.WaitForAsync(new() { State = WaitForSelectorState.Visible });

            // Implemented Ready to Deploy for now
            switch (asset.getStatus())
            {
                case assetStatus.Ready_to_Deploy:
                    await _statusDropdown.GetByText("Ready to Deploy").ClickAsync();    
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            // Assign a random user (first user)
            await _checkoutTo.ClickAsync();
            await _checkoutToDropdown.WaitForAsync(new() { State = WaitForSelectorState.Visible });

            // Select the first option (excluding the "Loading more results..." option)
            var firstOptionSelector = ".select2-results__option:not(.select2-results__option--load-more):first-child";

            // Click the first option
            await _page.ClickAsync(firstOptionSelector);
            asset.SetCheckoutTo(parseTitle(await _checkoutTo.GetAttributeAsync("title")));

            // submit form 
            await _submitBtn.ClickAsync();

            return asset;
        }

        private string parseTitle(string title)
        {
            var match = Regex.Match(title, @"^(.+?)\s+\((.+?)\)\s+-\s+#(\d+)$");

            if (match.Success)
            {
                var name = match.Groups[1].Value;     // "Anderson Luciano"
                var username = match.Groups[2].Value; // "savanna.schumm"
                var userId = match.Groups[3].Value;   // "3989"
                Console.WriteLine($"Name: {name}, Username: {username}, UserID: {userId}");
                return name;
            }
            return "";
            
        }
    }
}
