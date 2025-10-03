using System.Collections.ObjectModel;
using AplicativoTesteTecnicoKogui.ViewModels;
using AplicativoTesteTecnicoKogui.Services;
using AplicativoTesteTecnicoKogui.Models;

namespace AplicativoTesteTecnicoKogui
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _vm;
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
            BindingContext = vm;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _vm.BuscarTodosEmOrdemAsync();
        }

    }
}
