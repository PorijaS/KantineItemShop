using System.Collections.Generic;
using System.Linq;
using KantineAPIv2.Entities.DataRepository;
using KantineAPIv2.Context;
using KantineAPIv2.DataModels;

namespace KantineAPIv2.Entities.DataManager
{
    public class GroupManager : IGroupRepository
    {
        readonly DatabaseContext _dbContext;

        public GroupManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Group> GetAll()
        {
            return _dbContext.Groups.ToList();
        }

        public Group Get(long id)
        {
            return _dbContext.Groups.FirstOrDefault(e => e.GroupId == id);
        }

        public long Add(GroupModel group)
        {
            var groupEntity = new Group(group.GroupName);
            _dbContext.Groups.Add(groupEntity);
            _dbContext.SaveChanges();

            return groupEntity.GroupId;
        }

        public void Update(Group groupToUpdate, GroupModel updatedGroup)
        {
            groupToUpdate.GroupName = updatedGroup.GroupName;
            _dbContext.SaveChanges();
        }

        public void Delete(Group group)
        {
            _dbContext.Groups.Remove(group);
            _dbContext.SaveChanges();
        }
    }
}
