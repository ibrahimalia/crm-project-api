using Meta.IntroApp.DTOs.PRJ_Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_Tag.admin
{
   public interface ITagAdmin
    {
        Task<List<GetTagDTO>> GetTags();      

        Task AddTag(int admin ,AddTagDTO tag);

        Task UpdateTag(int admin ,int id, AddTagDTO tag);

        Task DeleteTag(int id);
    }
}
