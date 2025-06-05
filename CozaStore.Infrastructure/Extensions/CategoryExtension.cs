

using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Infrastructure.Extensions
{
    public static class CategoryExtension
    {
        public static IEnumerable<Category> GetHeirArchy(this IEnumerable<Category> categories, Category parent)
        {
            if (parent.ParentId != null) yield return parent;
            foreach (var item in categories.Where(c => c.ParentId == parent.Id && c.DeletedAt == null).SelectMany(ch => categories.GetHeirArchy(ch)))
            {
                yield return item;
            }
        }
    }
}
