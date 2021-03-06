	public class XUserMap : ClassMap<XUser>
    {
        public XUserMap()
        {
            Id(x => x.Id, "ID").GeneratedBy.Sequence("SEQ").Column("ID");
            Table("XUSER");
            ...
            HasMany(x => x.XUserHasXFunctions).KeyColumn("XUSER_ID").Cascade.All();
        }
    }
	
	public class XFunctionMap : ClassMap<XFunction>
    {
        public XFunctionMap()
        {
            Id(x => x.Id, "ID").GeneratedBy.Sequence("SEQ").Column("ID");
            Table("XFUNCTION");
			...
            HasMany(x => x.XUserHasXFunctions)KeyColumn("XFUNCTION_ID").Cascade.All();
        }
    }
	
	public class XUserHasXFunctionMap : ClassMap<XUserHasXFunction>
    {
        public XUserHasXFunctionMap()
        {
            Id(x => x.Id, "ID").GeneratedBy.Sequence("SEQ").Column("ID");
            Table("XUSER_HAS_XFUNCTION");
            ...
            Map(x => x.DeployedDate, "DEPLOYED_DATE");
            References(x => x.XUser).Column("XUSER_ID");
            References(x => x.XFunction).Column("XFUNCTION_ID");
        }
    }
