using System.Collections.ObjectModel;
using AplicativoTesteTecnicoKogui.ViewModels;
using AplicativoTesteTecnicoKogui.Services;
using AplicativoTesteTecnicoKogui.Models;

namespace AplicativoTesteTecnicoKogui
{
    // MainPage.xaml.cs
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }


        public async void OnBuscarClicked(object s, EventArgs e)
        {
            if (BindingContext is MainPageViewModel vm)
                await vm.BuscarAsync();
        }

    }
}
//    public partial class MainPage : ContentPage
//    {
//        int count = 0; 

//        public ObservableCollection<ChaveCor> Lista { get; set; }
//        = new ObservableCollection<ChaveCor> { new ChaveCor("MagentaFuchsia", ""), new ChaveCor("White", "para"),
//                new ChaveCor("Blue", "Pares"), new ChaveCor("Green", "alterar"), new ChaveCor("Black", "#"),
//                new ChaveCor("WebOrange", "e"), new ChaveCor("Yellow", "impares"), new ChaveCor("Red", "\" \""),
//                new ChaveCor("Coconut", "Busca"), new ChaveCor("CyanAqua", "primos") };

//        public MainPage()
//        {
//            InitializeComponent();
//            BindingContext = this;
//        }

//        private void OnCounterClicked(object sender, EventArgs e)
//        {
//            count++;

//            if (count == 1)
//                CounterBtn.Text = $"Clicked {count} time";
//            else
//                CounterBtn.Text = $"Clicked {count} times";

//            SemanticScreenReader.Announce(CounterBtn.Text);
//        }
//    }

//}
