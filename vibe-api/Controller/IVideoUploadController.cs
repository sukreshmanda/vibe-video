using vibe_api.Entity;

namespace vibe_api.Controller;

/*
 Step 1: Get Video Upload Token
 Step 2: Upload Video with the Token generated
 Step 3: Get Video Info from Token
*/
public interface IVideoUploadController<out T> where T : IVideo
{
    string GetUploadToken();
    Task Upload(IFormFile video, string token);
    T GetVideoInfo(string token);
}   