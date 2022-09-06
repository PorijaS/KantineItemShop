using KantineAPIv2.DataModels;
using KantineAPIv2.Entities;
using KantineAPIv2.Entities.DataRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KantineAPIv2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _dataRepository;

        public GroupController(IGroupRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/groups
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Group> groups = _dataRepository.GetAll();
            return Ok(groups);
        }

        // GET: api/group/1
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(long id)
        {
            Group group = _dataRepository.Get(id);
            if (group == null)
            {
                return NotFound("The Group was not found");
            }
            return Ok(group);
        }

        // POST: api/group
        [HttpPost]
        public IActionResult Post([FromBody] GroupModel group)
        {
            if (group == null)
            {
                return BadRequest("Group is null");
            }

            var groupId = _dataRepository.Add(group);

            var result = _dataRepository.Get(groupId);
            return Ok(result);
        }
        [HttpPut]
        public IActionResult Put(long id, [FromBody] GroupModel group)
        {
            if (group == null)
            {
                return BadRequest("Group is null");
            }
            Group groupToUpdate = _dataRepository.Get(id);

            if (groupToUpdate == null)
            {
                return NotFound("Group was not found");
            }

            _dataRepository.Update(groupToUpdate, group);
            return Ok(group);
        }

        //Delete: api/group/1
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(long id)
        {
            Group group = _dataRepository.Get(id);

            if (group == null)
            {
                return NotFound("The Group was not found");
            }
            _dataRepository.Delete(group);
            return Ok("The Group was deleted");
        }
    }
}
