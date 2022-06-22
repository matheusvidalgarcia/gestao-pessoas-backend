using Newtonsoft.Json;
using pessoa.Domain.Interfaces;
using pessoa.Domain.Shared.Geolocalizacao;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace pessoa.Infra.Data.Http.Geolocalizacao
{
    public class GeolocalizacaoHttpRepository : IGeolocalizacaoRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string URL_HERE_MAPS_GEOCODE = "geocode";
        public GeolocalizacaoHttpRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Localizacao> GetLocalizacaoAsync(string rua, string numero, string cidade, string estado, string pais)
        {
            string API_KEY = "kyv8fvwTnV1JjzuV4hLhzvcIdFRvbwm0QhrF_0RtA1A";

            var queryString = $"{URL_HERE_MAPS_GEOCODE}?q={rua},{numero},{cidade},{estado},{pais}&apiKey={API_KEY}";
            try
            {
                var httpResponse = await _httpClient.GetStringAsync(_httpClient.BaseAddress + queryString);
                var responseDeserialized = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(httpResponse);
                return new Localizacao(responseDeserialized["items"][0]["position"]["lat"].ToString(), responseDeserialized["items"][0]["position"]["lng"].ToString());
            }
            catch (Exception)
            {
              
            }

            return null;
        }
    }
}