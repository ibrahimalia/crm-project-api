using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Request.Client
{
   public interface IClientRequest
    {
        Task<List<GetRequestListDTO>> GetRequests(long clientId , PaginationFilterDTO filter);

        Task<GetRequestDTO> GetRequestDetailes(long clientId ,int? id);

        Task AddRequest(long? clientId ,AddRequestDTO addRequestDTO);

        Task UpdateRequest(long clientId ,int id, AddRequestDTO addRequestDTO);

        //Task DeleteRequest(int id);
    }
}
