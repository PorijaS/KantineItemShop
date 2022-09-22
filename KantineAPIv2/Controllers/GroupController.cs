using KantineAPIv2.DataModels;
using KantineAPIv2.Entities;
using KantineAPIv2.Entities.DataRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KantineAPIv2.Controllers
{
    //API Controller for Group

    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        //Creating a _dataRepository reference
        private readonly IGroupRepository _groupRepository;

        //Creating Constructor
        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        // GET: api/groups
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Group> groups = _groupRepository.GetAll();
            return Ok(groups);
        }

        // GET: api/group/1
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(long id)
        {
            Group group = _groupRepository.Get(id);
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

            var groupId = _groupRepository.Add(group);

            var result = _groupRepository.Get(groupId);
            return Ok(result);
        }
        [HttpPut]
        public IActionResult Put(long id, [FromBody] GroupModel group)
        {
            if (group == null)
            {
                return BadRequest("Group is null");
            }
            Group groupToUpdate = _groupRepository.Get(id);

            if (groupToUpdate == null)
            {
                return NotFound("Group was not found");
            }

            _groupRepository.Update(groupToUpdate, group);
            return Ok(group);
        }

        //Delete: api/group/1
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(long id)
        {
            Group group = _groupRepository.Get(id);

            if (group == null)
            {
                return NotFound("The Group was not found");
            }
            _groupRepository.Delete(group);
            return Ok("The Group was deleted");
        }
    }
}
