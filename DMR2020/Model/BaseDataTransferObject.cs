using SqlSugar;

namespace DMR2020.Model
{
    /// <summary>
    /// DO gốc luôn có 3 trường id, updated_at, created_at
    /// </summary>
    public abstract class BaseDataTransferObject
    {
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        [SugarColumn(ColumnName = "updated_at", IsOnlyIgnoreInsert = true, UpdateServerTime = true)]
        public DateTime UpdatedAt { get; set; }
        [SugarColumn(ColumnName = "created_at", IsOnlyIgnoreUpdate = true, InsertServerTime = true)]
        public DateTime CreatedAt { get; set; }
    }
}
