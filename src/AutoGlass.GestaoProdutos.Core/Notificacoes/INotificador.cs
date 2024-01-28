using AutoGlass.GestaoProdutos.Core.Notificacoes;

namespace AutoGlass.GestaoProdutos.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
