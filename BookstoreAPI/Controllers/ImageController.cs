using Microsoft.AspNetCore.Mvc;

using Azure.Storage.Blobs;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private const string _connectionStr = "DefaultEndpointsProtocol=https;AccountName=bookstoreapistorage;AccountKey=B8EeZkV5uDFtW/58/kUyQPBRQafi3u1I2vO28SrdIJNdwfx59XU0cYWRTFw7s3iAj1sLXUZHuuN6+AStiucsdg==;EndpointSuffix=core.windows.net";
        private const string _containerName = "bookimages";

        private string _GenerateFileName(string fileName, string owner)
        {
            try
            {
                string fName = string.Empty;
                string[] name = fileName.Split('.');
                fName = owner + '/' + "preview-" + DateTime.Now.ToUniversalTime().ToString("yyyyMMdd\\THHmmssff") + '.' + name[name.Length - 1];
                return fName;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return fileName;
            }
        }

        [HttpPost("{owner}")]
        public async Task<IActionResult> addImage(string owner, IFormFile image)
        {
            try
            {
                var fileName = _GenerateFileName(image.FileName, owner);
                var fileUrl = string.Empty;

                BlobContainerClient containerClient = new BlobContainerClient(_connectionStr, _containerName);
                try
                {
                    BlobClient client = containerClient.GetBlobClient(fileName);
                    
                    using (Stream stream = image.OpenReadStream())
                    {
                        await client.UploadAsync(stream);
                    }
                    
                    fileUrl = client.Uri.AbsoluteUri;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.ToString());
                }

                return Ok(fileUrl);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{owner}/{url}")]
        public async Task<IActionResult> replaceImage(string owner, string url)
        {
            
            
            return Ok(url);
        }

        [HttpDelete("{url}")]
        public async Task<IActionResult> deleteImage(string url)
        {
            BlobContainerClient containerClient = new BlobContainerClient(_connectionStr, _containerName);
            try
            {
                await containerClient.GetBlobClient(url).DeleteAsync();
                //return Ok($"Image deleted: {url}");
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
