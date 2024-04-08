namespace Clothes.Store.Db.DbEntities
{
    /// <summary>
    /// Purchase (Db Table)
    /// </summary>
    public class Purchase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime PurchaseDate { get; set; }

    }
}
