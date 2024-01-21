using System.Linq.Expressions;
using Framework.Core.Domain.Entities;
using Framework.Core.Domain.ValueObjects;

namespace Framework.Core.Contracts.Data.Commands;
/// <summary>
/// در صورتی که داده‌ها به صورت عادی ذخیره سازی شوند از این Interface جهت تعیین اعمال اصلی موجود در بخش ذخیره سازی داده‌ها استفاده می‌شود.
/// </summary>
/// <typeparam name="TEntity">کلاسی که جهت ذخیره سازی انتخاب می‌شود</typeparam>
public interface ICommandRepository<TEntity,TId> : IUnitOfWork
    where TEntity : AggregateRoot<TId>
     where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{

    /// <summary>
    /// داده‌های جدید را به دیتابیس اضافه می‌کند
    /// </summary>
    /// <param name="entity">نمونه داده‌ای که باید به دیتابیس اضافه شود.</param>
    Task InsertAsync(TEntity entity);
 
}
