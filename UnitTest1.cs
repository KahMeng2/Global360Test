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

            // Login 
            await loginPage.GoTo();
            await loginPage.Login("admin", "password");
            await Page.WaitForURLAsync("**/");

            // Navigate through Dashboard to create asset
            await dashboardPage.navbar.Create(NavbarItems.Asset);

            //// TODO: implement a dashboard page, that uses a navbar component. -> video
            //await Page.ClickAsync("text=Create New");

            //// Wait for dropdown and click Asset
            //await Page.WaitForSelectorAsync(".dropdown-menu", new() { State = WaitForSelectorState.Visible });
            //await Page.WaitForSelectorAsync("a[href*='/hardware/create']", new() { State = WaitForSelectorState.Visible });

            //await Page.ClickAsync("a[href*='/hardware/create']");

            //// Verify we're on the create asset page
            //await Page.WaitForURLAsync("**/hardware/create");

            // Asset creation - long block with hardcoded values
            

            // TODO: Build asset model and go from there
            // Obtain asset tag from the page 

            // Selects the correct model. Abstract this later 
            // Click the Select2 container to open dropdown
            await Page.ClickAsync("#select2-model_select_id-container");

            // Wait for dropdown to appear
            await Page.WaitForSelectorAsync(".select2-dropdown", new() { State = WaitForSelectorState.Visible });

            // Type to search for MacBook Pro (Select2 usually has search)
            await Page.TypeAsync(".select2-search__field", "MacBook Pro 13");

            // Wait for and click the specific option
            await Page.ClickAsync("text=MacBook Pro 13");

            // Fill in details like model, status -> ready to deploy, then checkout to a random user (first user)
            // Once it is done, we create an asset model, that will be used to verify later 



        }
    }
}
