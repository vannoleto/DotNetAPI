using MinhaApi.Repositories.Interfaces;

namespace MinhaApi.Services
{
    public class MeuServico : IMeuServico
    {
        private readonly IMeuRepositorio _repositorio;

        public MeuServico(IMeuRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Criar(MeuModelo modelo)
        {
            _repositorio.Adicionar(modelo);
        }

        public MeuModelo Obter(int id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public void Atualizar(MeuModelo modelo)
        {
            _repositorio.Atualizar(modelo);
        }

        public void Excluir(int id)
        {
            _repositorio.Remover(id);
        }
    }
}