using Microsoft.AspNetCore.Http;

namespace CozaStore.Infrastructure.Extensions
{
	public static class FileExtension
	{
		public static bool CheckImage(this IFormFile photo)
		{
			return photo.ContentType.Contains("image/");
		}
		public static bool CheckImageSize(this IFormFile photo, int size)
		{
			return photo.Length / 1024 > size;
		}
		public static string SaveFile(this IFormFile photo,params string[]folders)
		{
			var directory = Directory.GetCurrentDirectory();
			var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
			var allPaths = new List<string> { directory, "wwwroot" };
			allPaths.AddRange(folders);
			allPaths.Add(newFileName);     
			string fullPath = Path.Combine(allPaths.ToArray());

			using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
			{
				photo.CopyTo(fileStream);
			};
			return newFileName;
		}
	}
}
