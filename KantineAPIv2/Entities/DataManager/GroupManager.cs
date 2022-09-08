using System.Collections.Generic;
using System.Linq;
using KantineAPIv2.Entities.DataRepository;
using KantineAPIv2.Context;
using KantineAPIv2.DataModels;

namespace KantineAPIv2.Entities.DataManager
{
    //DataManager class that handles Request Call Functionality
    public class GroupManager : IGroupRepository
    {
        //Creating a db context
        readonly DatabaseContext _dbContext;

        //Adding a class constructor
        public GroupManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get Function that fetches all Groups and posts them to a list
        public IEnumerable<Group> GetAll()
        {
            return _dbContext.Groups.ToList();
        }

        //Get Function that takes a id and looks in the database for said id in the Group table
        public Group Get(long id)
        {
            return _dbContext.Groups.FirstOrDefault(e => e.GroupId == id);
        }

        //Add function that takes a GroupModel and adds it to the Group table
        public long Add(GroupModel group)
        {
            var groupEntity = new Group(group.GroupName);
            _dbContext.Groups.Add(groupEntity);
            _dbContext.SaveChanges();

            return groupEntity.GroupId;
        }

        //Update function that takes a Group that you want to update and the updated Group
        public void Update(Group groupToUpdate, GroupModel updatedGroup)
        {
            groupToUpdate.GroupName = updatedGroup.GroupName;
            _dbContext.SaveChanges();
        }

        //Delete function that deletes a single Group
        public void Delete(Group group)
        {
            _dbContext.Groups.Remove(group);
            _dbContext.SaveChanges();
        }
    }
}
