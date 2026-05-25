using MeuSiteEmMVC.Data;
using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _context;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _context = bancoContext;
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return contato;
        }

        public ContatoModel listarPorId(int id)
        {
            return _context.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _context.Contatos.ToList();
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = listarPorId(contato.Id);
            if (contatoDb == null) 
                throw new Exception("Houve um erro na atualização do contato!");

            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;
            _context.Contatos.Update(contatoDb);
            _context.SaveChanges();

            return contatoDb;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDb = listarPorId(id);
            if (contatoDb == null)
                throw new Exception("Houve um erro na atualização do contato!");

            _context.Contatos.Remove(contatoDb);
            _context.SaveChanges();
            return true;
        }

        ContatoModel IContatoRepositorio.Apagar(int id)
        {
            
        }
    }
}
