namespace MinhaApi.Services.Interfaces
{
    public interface IMeuServico
    {
        void Criar(MeuModelo modelo);
        MeuModelo Obter(int id);
        void Atualizar(MeuModelo modelo);
        void Excluir(int id);
    }
}