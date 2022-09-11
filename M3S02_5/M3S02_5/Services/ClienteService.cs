using M3S02_5.Data;
using M3S02_5.Model;

namespace M3S02_5;

public class ClienteService : IClienteService
{

    private readonly ApiKeyContext _context;

    public ClienteService(
        ApiKeyContext context
    )
    {
        _context = context;
    }

    public Cliente VerificaApiKey(string apiKey)
    {
        var cliente = _context.Usuarios.FirstOrDefault(u => u.ApiKey == apiKey);

        return cliente;
    }

}