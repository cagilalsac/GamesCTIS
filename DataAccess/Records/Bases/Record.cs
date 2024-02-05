namespace DataAccess.Records.Bases
{
	public abstract class Record
	{
		//private int _id; // field

		//public void SetId(int id) // behaviors, setter
		//{
		//    _id = id;
		//}

		//public int GetId() // behaviors, getter
		//{
		//    return _id;
		//}

		public int Id { get; set; } // property, is required
		public string? Guid { get; set; } // property, is not required
	}
}
