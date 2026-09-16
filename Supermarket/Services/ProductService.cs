using Supermarket.DTO;
using System.Net.Http.Headers;
namespace Supermarket.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;

        public ProductService(HttpClient httpClient, AuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        public async Task<List<ProductResponse>> GetProducts() {
            try
            {
                var token = await _authService.GetToken();

                if (string.IsNullOrEmpty(token))
                {
                    throw new InvalidOperationException("El token es nulo o invalido. Iniciar sesión");
                }

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetFromJsonAsync<List<ProductResponse>>("api/products");

                return response;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al obtener productos. Revisar conexión a internet.");
            }
            catch (Exception ex) {
                throw new Exception("Ha ocurrido un error inesperado al obtener productos.");
            }

        }
    }
}
