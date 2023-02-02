namespace DAL.Entities.Base
{
    public interface IEntityBase<TId>
    {
        TId Id { get; set; }
    }
}
