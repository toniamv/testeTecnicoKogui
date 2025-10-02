using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicativoTesteTecnicoKogui.Models;
using AplicativoTesteTecnicoKogui.ViewModels;
using Microsoft.Extensions.DependencyInjection;


namespace AplicativoTesteTecnicoKogui.Services
{ 
    public interface IColorApiService
    {
        Task<ColorInfo?> GetColorByHexAsync(string hex, CancellationToken ct = default);
    }
}
