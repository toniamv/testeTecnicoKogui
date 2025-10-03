using AplicativoTesteTecnicoKogui.Models;
using AplicativoTesteTecnicoKogui.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text;


namespace AplicativoTesteTecnicoKogui.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private readonly IColorApiService _api;

    public ObservableDictionary<string, ChaveCor> Lista { get; } = new();
    public ObservableCollection<ChaveCor> ItensBuscados { get; } = new();

    public List<string> APIEntrada = new List<string> {"#0000FF", "#00FF00", "#FFFFFF", "#FF0000", "#FFA500", "#FFFF00", "#000000"};
    public string APIEntradaUnida => string.Join(" ", APIEntrada);

    [ObservableProperty]
    private string fraseDicaFinal = "";

    [ObservableProperty]
    private string matrizRenderizada = "";


    public MainPageViewModel(IColorApiService api)
    {
        _api = api;
        List<ChaveCor> listaInicial = new List<ChaveCor> { new ChaveCor("Magenta Fuchsia", ""), new ChaveCor("White", "para"),
                  new ChaveCor("Blue", "Pares"), new ChaveCor("Green", "alterar"), new ChaveCor("Black", "#"),
                  new ChaveCor("Web Orange", "e"), new ChaveCor("Yellow", "impares"), new ChaveCor("Red", "\" \""),
                  new ChaveCor("Coconut", "Busca"), new ChaveCor("Cyan Aqua", "primos")};

        
        foreach (ChaveCor cor in listaInicial)
        {
            Lista.Add(cor.Cor, cor);
        }

        CarregarMatrizAsync();
    }
    public async Task BuscarTodosEmOrdemAsync()
    {
        ItensBuscados.Clear();
        foreach (var entrada in APIEntrada)
        {
            await BuscarAsync(entrada);
        }
        
        FraseDicaFinal = string.Join(" ", ItensBuscados.Select(i => i.Componente));
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
            Console.WriteLine("Error: Timeout");
        }
        catch (HttpRequestException)
        {
            Console.WriteLine("Error: Http Request Failed");
        }
    }

    public async Task CarregarMatrizAsync()
    {
        try
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("matriz.txt");
            using var reader = new StreamReader(stream);

            string conteudo = await reader.ReadToEndAsync();
            MatrizRenderizada = ProcessarConteudo(conteudo);
        }
        catch (Exception ex)
        {
            MatrizRenderizada = $"Erro ao ler matriz.txt: {ex.Message}";
        }
    }

    // Processa caractere por caractere
    private string ProcessarConteudo(string conteudo)
    {
        var sb = new StringBuilder(conteudo.Length);

        foreach (char ch in conteudo)
        {
            // preserva \r e \n (quebras de linha de Win/Mac/Linux)
            if (ch == '\n' || ch == '\r')
            {
                sb.Append(ch);
                continue;
            }

            if (char.IsDigit(ch))
            {
                int valor = ch - '0';
                sb.Append((valor % 2 == 0) ? ' ' : '#');
            }
            else if (ch == ' ' || ch == '\t')
            {
                sb.Append(ch); // preserva espaços/tabs exatamente
            }
            else
            {
                // Caso entre algum outro caractere, mantém
                sb.Append(ch);
            }
        }

        return sb.ToString();
    }
}
