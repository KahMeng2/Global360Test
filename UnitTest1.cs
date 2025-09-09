using Global360Test._pages;
using Global360Test.Models;
using Global360Test.Pages;
using Global360Test.Pages.Sections;
using Microsoft.Playwright;
using static System.Net.Mime.MediaTypeNames;

namespace Global360Test
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
     
        [Test]
        public async Task Test1()
        {
            LoginPage loginPage = new LoginPage(Page);
            DashboardPage dashboardPage = new DashboardPage(Page);
            CreateAssetPage createAssetPage = new CreateAssetPage(Page);
            AssetPage assetPage = new AssetPage(Page);

            // Login 
            await loginPage.GoTo();
            await loginPage.Login("admin", "password");
            await Page.WaitForURLAsync("**/");

            // Navigate through Dashboard to create asset
            await dashboardPage.navbar.Create(NavbarItems.Asset);

            // TODO: Build asset model and go from there
            // Obtain asset tag from the page 
            Asset asset = new Asset(assetStatus.Ready_to_Deploy,"random", "MacBook Pro 13");

            asset = await createAssetPage.FillAssetForm(asset);

            await Page.WaitForURLAsync("https://demo.snipeitapp.com/hardware");

            // Search asset in assetpage
            await assetPage.SearchAsset(asset.getAssetTag());

            // 




        }
    }
}
