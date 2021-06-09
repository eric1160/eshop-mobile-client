using System;
using System.Threading.Tasks;
using System.Windows.Input;
using eShopOnContainers.Core.Models.Catalog;
using eShopOnContainers.Core.Services.Catalog;
using eShopOnContainers.Core.ViewModels.Base;
using Xamarin.Forms;

namespace eShopOnContainers.Core.ViewModels
{
    public class CatalogDescriptionViewModel : ViewModelBase
    {
        private CatalogItem _product;

        public CatalogDescriptionViewModel()
        {
        }

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;

            // Get Catalog, Brands and Types
            //Products = await _productsService.GetCatalogAsync();
            //Brands = await _productsService.GetCatalogBrandAsync();
            //Types = await _productsService.GetCatalogTypeAsync();

            if(navigationData != null)
            {
                Product = navigationData as CatalogItem;
            }

            IsBusy = false;
        }

        public CatalogItem Product
        {
            get { return _product; }
            set
            {
                _product = value;
                RaisePropertyChanged(() => Product);
            }
        }

        public ICommand AddCatalogItemCommand => new Command(async () => AddCatalogItem());

        private async Task AddCatalogItem()
        {
            // Add new item to Basket
            MessagingCenter.Send(this, MessageKeys.AddProduct, Product);

            await NavigationService.NavigateToAsync<MainViewModel>();

        }
    }
}
