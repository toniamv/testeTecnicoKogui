using System.Collections.ObjectModel;
using AplicativoTesteTecnicoKogui.Models;
using AplicativoTesteTecnicoKogui.Services;


namespace AplicativoTesteTecnicoKogui.ViewModels;

public class MainPageViewModel
{
    private readonly IColorApiService _api;

    public ObservableDictionary<string, ChaveCor> Lista { get; } = new();
    public string? InputHex { get; set; }

    public MainPageViewModel(IColorApiService api)
    {
        //Preenchendo dicionario com cores estabelecidas na lista
        List<ChaveCor> listaInicial = new List<ChaveCor> { new ChaveCor("MagentaFuchsia", ""), new ChaveCor("White", "para"),
                  new ChaveCor("Blue", "Pares"), new ChaveCor("Green", "alterar"), new ChaveCor("Black", "#"),
                  new ChaveCor("WebOrange", "e"), new ChaveCor("Yellow", "impares"), new ChaveCor("Red", "\" \""),
                  new ChaveCor("Coconut", "Busca"), new ChaveCor("CyanAqua", "primos")};
        
        foreach(ChaveCor cor in listaInicial)
        {
            Lista.Add(cor.Cor, cor);
        }
        _api = api;
        
    }

    public async Task BuscarAsync()
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
