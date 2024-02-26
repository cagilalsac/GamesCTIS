#nullable disable

using DataAccess.Records.Bases;
using System.ComponentModel;

namespace Business.Models
{
    public class RoleModel : Record
    {
        #region Entity Properties
        [DisplayName("Role Name")]
        public string Name { get; set; }
        #endregion

        #region Extra Properties
        [DisplayName("User Count")]
        public int UserCount { get; set; }

        public string Users { get; set; }
        #endregion
    }
}
