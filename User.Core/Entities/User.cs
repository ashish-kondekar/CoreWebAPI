using System.ComponentModel.DataAnnotations.Schema;

namespace User.Repo
{
    [Table("User")]
    public class SysUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
    }
}
