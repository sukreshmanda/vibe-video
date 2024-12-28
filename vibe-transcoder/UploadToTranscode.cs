using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace vibe_transcoder
{
    public class UploadToTranscode
    {
        private readonly ILogger<UploadToTranscode> _logger;

        public UploadToTranscode(ILogger<UploadToTranscode> logger)
        {
            _logger = logger;
        }

        [Function(nameof(UploadToTranscode))]
        public async Task Run([BlobTrigger("small-video/{name}", Connection = "f2289e_STORAGE")] Stream stream, string name)
        {
            using var blobStreamReader = new StreamReader(stream);
            var content = await blobStreamReader.ReadToEndAsync();
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}");
        }
    }
}
