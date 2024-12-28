using Microsoft.AspNetCore.Mvc;
using vibe_api.Entity;
using vibe_api.Entity.SmallVideo;
using vibe_api.Service;

namespace vibe_api.Controller;

[ApiController]
[Route("upload/mini")]
public class SmallVideoUploadController(SmallVideoUploadService smallVideoUploadService)
    : ControllerBase, IVideoUploadController<SmallVideo>
{
    private SmallVideoUploadService SmallVideoUploadService { get; } = smallVideoUploadService;

    [HttpGet("token")]
    public string GetUploadToken()
    {
        return SmallVideoUploadService.GetUploadToken();
    }

    [HttpPut]
    public async Task Upload(IFormFile video, string token)
    {
        await SmallVideoUploadService.Upload(video, token);
    }

    [HttpGet("info")]
    public SmallVideo GetVideoInfo(string token)
    {
        throw new NotImplementedException();
    }
}