namespace Application.Bases.Dtos.Paginations;

public class PaginationDtoSelect<TEntity>
{
    public List<TEntity> Data { get; set; } = [];
    public int Total { get; set; }
}
