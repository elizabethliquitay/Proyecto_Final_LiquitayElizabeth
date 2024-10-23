using SistemaGestionEntities;
using Microsoft.AspNetCore.WebUtilities;
using SistemaGestionUI.Components.Pages.Usuarios;

namespace SistemaGestionUI.ClientServices;

public class VentasService
{
    private readonly HttpClient _httpClient;

    public VentasService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Venta?> ObtenerVenta(int id)
    {
        return await _httpClient.GetFromJsonAsync<Venta>($"{id}");
    }

    public async Task<List<Venta>?> ListarVentas()
    {
        return await _httpClient.GetFromJsonAsync<List<Venta>>("");
    }

    public async Task<Venta?> CrearVenta(Venta venta)
    {
        //await _httpClient.PostAsJsonAsync("", venta);

        var response = await _httpClient.PostAsJsonAsync("", venta);

        if (response.IsSuccessStatusCode)
        {
            // Si la respuesta es exitosa, deserializamos el objeto de la respuesta
            return await response.Content.ReadFromJsonAsync<Venta>();
        }

        return null; // Retorna null si hubo un error


    }

    public async Task ModificarVenta(int id, Venta venta)
    {
        await _httpClient.PutAsJsonAsync($"{id}", venta);            
    }

    public async Task EliminarVenta(int id)
    {
        await _httpClient.DeleteAsync($"{id}");
    }
}
