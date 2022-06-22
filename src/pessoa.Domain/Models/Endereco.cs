using core.Types;

namespace pessoa.Domain.Models
{
    public class Endereco : Entity
    {
        public string Nome { get; private set; }
        public string Rua { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Pais { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }

        internal void AdicionarGeolocalizacao(string latitude, string longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
