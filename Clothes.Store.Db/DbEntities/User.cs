namespace Clothes.Store.Db.DbEntities
{
    /// <summary>
    /// User (Db Table)
    /// </summary>

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Gender { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }

        public string PhoneNumbers { get; set; }

    }
}
