using Microsoft.AspNetCore.Mvc;

namespace AdFeedBack.Client.Intefaces
{
    public interface IAdFeedBackApiService
    {
        Task<IActionResult> GetAsync(string uri);
        Task<IActionResult> PostAsync(string uri, Object obj);
    }
}
