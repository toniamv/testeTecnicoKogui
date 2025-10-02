using System.Collections.ObjectModel;
using AplicativoTesteTecnicoKogui.Models;
using AplicativoTesteTecnicoKogui.Services;


namespace AplicativoTesteTecnicoKogui.ViewModels;

public class MainPageViewModel
{
    private readonly IColorApiService _api;

    public ObservableDictionary<string, ChaveCor> Lista { get; } = new();
    public ObservableCollection<ChaveCor> ItensBuscados { get; } = new();

    public List<string> APIEntrada = new List<string> {"#0000FF", "#00FF00", "#FFFFFF", "#FF0000", "#FFA500", "#FFFF00", "#000000"};
    public string APIEntradaUnida => string.Join(" ", APIEntrada);


    public MainPageViewModel(IColorApiService api)
    {
        _api = api;
        //Preenchendo dicionario com cores estabelecidas na lista
        List<ChaveCor> listaInicial = new List<ChaveCor> { new ChaveCor("MagentaFuchsia", ""), new ChaveCor("White", "para"),
                  new ChaveCor("Blue", "Pares"), new ChaveCor("Green", "alterar"), new ChaveCor("Black", "#"),
                  new ChaveCor("WebOrange", "e"), new ChaveCor("Yellow", "impares"), new ChaveCor("Red", "\" \""),
                  new ChaveCor("Coconut", "Busca"), new ChaveCor("CyanAqua", "primos")};

        
        foreach (ChaveCor cor in listaInicial)
        {
            Lista.Add(cor.Cor, cor);
        }
    }
    public async Task BuscarTodosEmOrdemAsync()
    {
        ItensBuscados.Clear();
        foreach (var entrada in APIEntrada)
        {
            await BuscarAsync(entrada); // garante a ordem da lista de entrada
        }
    }

    public async Task BuscarAsync(string InputHex)
    {
        try
        {
            var info = await _api.GetColorByHexAsync(InputHex);
            if (info is null) return;

            var name = info?.Name?.Value;
            var hex = info?.Hex?.Clean ?? info?.Hex?.Value;

            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(hex) && Lista.ContainsKey(name))
            {
                Lista[name].Hex = hex!;
                Lista[name].Background = Color.FromArgb(hex.StartsWith('#') ? hex : $"#{hex}");
                ItensBuscados.Add(Lista[name]);
            }
            else
            {
                Console.WriteLine("Nome/hex não encontrados ou não mapeados.");
            }
        }
        catch (TaskCanceledException)
        {
            // timeout/cancel
            Console.WriteLine("Error: Timeout");
        }
        catch (HttpRequestException)
        {
            // sem internet
            Console.WriteLine("Error: Http Request Failed");
        }
    }
}
