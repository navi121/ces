using Microsoft.AspNetCore.Mvc;
using Notes.Model;
using Notes.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes.Controllers
{
    [Route("getdetails")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly DetailsService _detailsService;
        public NotesController(DetailsService detailsService)
        {
            _detailsService = detailsService;
        }

        [HttpGet]
        public async Task<IEnumerable<TODOList>> GetAllDetails()
        {
            return await _detailsService.GetAllDeatils();
        }
        [HttpPost]
        public void Post([FromBody] TODOList newwork)
        {
            _ = _detailsService.AddWork(new TODOList
            {
                name = newwork.name,
                age = newwork.age,
                work = newwork.work,
            });
        }


        /*public void Delete(TODOList removeContent)
        {
            _ = _detailsService.DeleteAllDetails(lists => lists.InternalId == removeContent.InternalId);
        }
        public void Remove(string id)
        {
            _detailsService.DeleteOneAsync(lists => lists.InternalId == id);
        }*/
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _ = _detailsService.DeleteAllDetails(id);
        }
    }
}
