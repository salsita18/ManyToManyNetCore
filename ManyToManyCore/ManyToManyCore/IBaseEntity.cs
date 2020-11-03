namespace ManyToManyCore
{
    public interface IBaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}
