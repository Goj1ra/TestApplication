using System.ComponentModel.DataAnnotations;
namespace DAL.Entities.Base
{
    public abstract class Entity : EntityBase<int>
    {
        public override int Id { get; set; }
    }
}
