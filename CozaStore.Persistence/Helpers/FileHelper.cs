using Microsoft.EntityFrameworkCore.Query;

namespace CozaStore.Persistence.Helpers
{
    public static class FileHelper
    {
        public static void DeleteFile(params string[] paths)
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", Path.Combine(paths));
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
        }

    }
}
