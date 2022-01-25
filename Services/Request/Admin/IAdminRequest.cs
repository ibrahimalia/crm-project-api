using Meta.IntroApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Request.Admin
{
   public interface IAdminRequest
    {
        Task<List<AddRequestDTO>> GetRequests();

        Task<AddRequestDTO> GetRequestDetailes(int? id);

        Task AddRequest(AddRequestDTO addRequestDTO);

        Task UpdateRequest(int id, AddRequestDTO addRequestDTO);

        Task DeleteRequest(int id);
    }
}
