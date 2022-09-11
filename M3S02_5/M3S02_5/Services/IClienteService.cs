using M3S02_5.Model;

namespace M3S02_5;

public interface IClienteService
{
    Cliente VerificaApiKey(string apiKey);
}