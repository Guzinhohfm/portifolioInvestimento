using Microsoft.EntityFrameworkCore;
using portifolioInvestimento.Configuration;
using portifolioInvestimento.Interfaces;
using portifolioInvestimento.Models;

namespace portifolioInvestimento.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly PortifolioDbContext _context;

    public UsuarioRepository(PortifolioDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario> CriarUsuario(Usuario usuario)
    {
        _context.usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario> EditarUsuario(Usuario usuarioEditado)
    {
        _context.Entry(usuarioEditado).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return usuarioEditado;
    }

    public async Task<IEnumerable<Usuario>> ListarUsuarios()
    {
        return await _context.usuarios.OrderBy(x => x.Name).ToListAsync();
    }

    public async Task<Usuario> ListarUsuariosPorId(int id)
    {
        return await _context.usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Usuario> ListarUsuariosPorNome(string nome)
    {
        return await _context.usuarios.Where(x => x.Name == nome).FirstOrDefaultAsync();
    }

    public async Task<Usuario> RemoverUsuario(int id)
    {
       var usuario =  await _context.usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
        _context.usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }
}
