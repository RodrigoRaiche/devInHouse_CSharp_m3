using M3S02_4.Data;

namespace M3S02_4;

public class UsuarioService : IUsuarioService
{
    private readonly BasicAuthContext _context;

    public UsuarioService(
        BasicAuthContext context
    )
    {
        _context = context;
    }

    public bool AutenticarUsuario(string nomeUsuario, string senha)
    {
        var usuario = _context.Usuarios.FirstOrDefault(u => u.NomeUsuario == nomeUsuario);

        if (usuario == null)
        {
            return false;
        }

        var check = usuario.Senha.Equals(senha);

        return check;
    }
}