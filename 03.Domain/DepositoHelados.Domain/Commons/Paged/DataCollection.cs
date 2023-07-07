    namespace DepositoHelados.Domain.Commons.Paged;

    public record DataCollection<T>
    (
        IEnumerable<T> Items,
        int Total,
        int Page,
        int Pages
    );
  