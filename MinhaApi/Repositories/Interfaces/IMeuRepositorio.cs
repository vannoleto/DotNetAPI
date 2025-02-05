namespace MinhaApi.Repositories.Interfaces
{
    public interface IMeuRepositorio<T>
    {
        void Adicionar(T entidade);
        T BuscarPorId(int id);
        void Atualizar(T entidade);
        void Remover(int id);
        IEnumerable<T> ObterTodos();
    }
}