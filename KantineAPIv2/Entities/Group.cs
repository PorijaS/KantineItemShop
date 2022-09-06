using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KantineAPIv2.Entities
{
    [Table("Group")]
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long GroupId { get; set; }
        public string GroupName { get; set; }

        public Group(string groupName)
        {
            GroupName = groupName;
        }
    }
}
