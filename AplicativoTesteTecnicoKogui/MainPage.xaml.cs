using System.Collections.ObjectModel;

namespace AplicativoTesteTecnicoKogui
{
    //implementando ChaveCor
    public partial class ChaveCor
    {
        public string Hex { get; set; } = "";
        public string Cor { get; set;} = "";
        public string Componente { get; set; } = "";

        public ChaveCor(string cor, string componente)
        {
            this.Cor = cor;
            this.Componente = componente;
        }
    }

    public partial class MainPage : ContentPage
    {
        int count = 0; 
        
        public ObservableCollection<ChaveCor> Lista { get; set; }
        = new ObservableCollection<ChaveCor> { new ChaveCor("MagentaFuchsia", ""), new ChaveCor("White", "para"),
                new ChaveCor("Blue", "Pares"), new ChaveCor("Green", "alterar"), new ChaveCor("Black", "#"),
                new ChaveCor("WebOrange", "e"), new ChaveCor("Yellow", "impares"), new ChaveCor("Red", " "),
                new ChaveCor("Coconut", "Busca"), new ChaveCor("CyanAqua", "primos") };

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
