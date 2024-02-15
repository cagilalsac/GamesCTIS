#nullable disable

using DataAccess.Records.Bases;

namespace Business.Models
{
    public class RoleModel : Record
    {
        #region Entity Properties
        public string Name { get; set; }
        #endregion
    }
}
