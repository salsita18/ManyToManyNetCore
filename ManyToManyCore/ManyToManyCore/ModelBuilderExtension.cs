using Microsoft.EntityFrameworkCore;

namespace ManyToManyCore
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder ManyToMany<TDependent, THolder, TIdDep, TIdHold>(this ModelBuilder builder)
            where TDependent : class, IBaseEntity<TIdDep> where THolder : class, IBaseEntity<TIdHold>
        {
            return builder.Entity<MiddleEntity<TDependent, THolder, TIdDep, TIdHold>>(entity =>
            {
                entity.HasKey(e => new { e.IdHolder, e.IdDependent });
                entity.HasOne(e => e.Dependent).WithMany().HasForeignKey(e => e.IdDependent);
                entity.HasOne(e => e.Holder).WithMany().HasForeignKey(e => e.IdHolder);
            });
        }
    }
}