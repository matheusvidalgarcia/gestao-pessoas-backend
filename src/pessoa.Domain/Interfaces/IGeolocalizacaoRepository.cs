using pessoa.Domain.Shared.Geolocalizacao;
using System.Threading.Tasks;

namespace pessoa.Domain.Interfaces
{
    public interface IGeolocalizacaoRepository
    {
        Task<Localizacao> GetLocalizacaoAsync(string rua, string numero, string cidade, string estado, string pais);
    }
}
