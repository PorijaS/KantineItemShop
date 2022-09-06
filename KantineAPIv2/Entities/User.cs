using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KantineAPIv2.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [ForeignKey("Group")]
        public long GroupId { get; set; }


        public virtual Group Group { get; set; }

        public User(string email, string password, long groupId)
        {
            Email = email;
            Password = password;
            GroupId = groupId;
        }
    }
}
