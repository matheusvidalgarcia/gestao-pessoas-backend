using System;

namespace pessoa.Domain.Shared.Geolocalizacao
{
    [Serializable]
    public class Localizacao
    {
        public Localizacao(string latitude, string longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
    }
}
