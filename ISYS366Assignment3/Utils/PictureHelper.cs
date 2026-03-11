namespace ISYS366Assignment4.Utils
{
    public static class PictureHelper
    {
        public static string UploadNewImage(IWebHostEnvironment environment,
        IFormFile file)
        {
            // this creates a random unique id
            string guid = Guid.NewGuid().ToString();

            // we get what the extension of the file we chose was
            // it should proably be a jpeg, png, or gif
            // but we aren't doing any validation of the file type
            string ext = Path.GetExtension(file.FileName);

            // build file name and paths
            string fileName = guid + ext;
            string imagesFolder = Path.Combine("images", "Movies");

            // physical path to save the file
            string physicalPath = Path.Combine(environment.WebRootPath, imagesFolder, fileName);

            // ensure directory exists
            var dir = Path.GetDirectoryName(physicalPath);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            // copy the file to our images folder with the generated file name
            using (var fs = new FileStream(physicalPath, FileMode.Create))
            {
                file.CopyTo(fs);
            }

            // return a URL-friendly path (use forward slashes)
            // leading slash makes it root-relative in the browser
            string urlPath = $"/images/Movies/{fileName}";
            return urlPath;
        }
    }
}
