    public interface IJustWantTheseColumnsInterface
    {
        ...
        IPhone Phone { get; set; }
        ...
    }
    public class SameTableMap : ClassMap<SameTable>
    {
        ...
        Reference(x => x.Phone, "PHONE_ID").Class(typeof(Phone));
        ...
    }
