using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global360Test.Models;
using Global360Test.Pages.Sections;
using Microsoft.Playwright;

namespace Global360Test.Pages
{
    internal class AssetPage
    {
        private readonly IPage _page;
        private readonly ILocator _assetTag;
        private readonly ILocator _model;
        private readonly ILocator _status;
        public Navbar navbar;


        public AssetPage(IPage page)
        {
            _page = page;
            navbar = new Navbar(page);
            _assetTag = page.Locator("span.js-copy-assettag");
            _model = page.Locator(".col-md-3:has(strong:text-is('Model')) + .col-md-9 a");
            _status = page.Locator(".col-md-3:has(strong:text-is('Status')) + .col-md-9");
        }



        public async Task GoToHistory()
        {
            await _page.Locator("a[href='#history']").ClickAsync();
        }


        // Verifies asset if its the same as the one created
        public async Task verifyAsset(Asset asset)
        {
            // Check for asset tag
            var assetTagText = await _assetTag.InnerTextAsync();

            // Check for model
            var modelText = await _model.InnerTextAsync();

            // Check for status 
            var statusText = await _status.InnerTextAsync();

            // abstracting status string
            string[] words = statusText.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string status = string.Join(" ", words.Take(3)); // "Ready to Deploy"
            string label = words[3]; // "Deployed"
            string userName = string.Join(" ", words.Skip(4)); // "Abbott Merritt"



            Assert.Multiple(() =>
            {
                Assert.That(assetTagText, Is.EqualTo(asset.getAssetTag()), "Asset tag does not match");
                Assert.That(modelText, Is.EqualTo(asset.getModel()), "Model does not match");
                Assert.That(status, Is.EqualTo(asset.getStatus().ToString().Replace("_", " ")), "Status does not match");
                Assert.That(userName, Is.EqualTo(asset.getCheckoutTo()), "Checkout to does not match");
            });
        }

        public async Task verifyHistory(Asset asset)
        {
            ILocator _userLink = _page.Locator("tr[data-index='1'] td:nth-child(6) a");
            string checkoutTo = await _userLink.TextContentAsync();
            checkoutTo = checkoutTo.Trim();

            ILocator _assetLink = _page.Locator("tr[data-index='1'] td:nth-child(5) a");
            string fullText = await _assetLink.TextContentAsync();

            var parts = fullText.Split(" - ", 2);
            string assetTag = parts[0].Trim('(', ')', ' '); // Remove parentheses and trim
            string model = parts[1].Trim();

            Assert.Multiple(() =>
            {
                Assert.That(assetTag, Is.EqualTo(asset.getAssetTag()), "Asset tag does not match");
                Assert.That(model, Is.EqualTo(asset.getModel()), "Model does not match");
                Assert.That(checkoutTo, Is.EqualTo(asset.getCheckoutTo()), "Checkout to does not match");
            });

        }
    }
}
