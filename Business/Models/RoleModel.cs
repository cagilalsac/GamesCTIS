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
    }
}
