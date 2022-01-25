using Meta.IntroApp.DTOs;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.IntroApp.Interfaces
{
    public interface IClientThemeExecution
    {
        Task<List<GalleryImageDTO>> GetSliders();
    }
}