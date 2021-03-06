    [DelimitedRecord("|")]
    public class Customer
    {
        public int CustId { get; set; }
        [FieldTrim(TrimMode.Right)]
        public string Name { get; set; }
        [FieldConverter(ConverterKind.Date, "ddMMyyyy")]
        public DateTime AddedDate { get; set; }
        [FieldOptional] // <-- 
        public string OptionalColumn { get; set; }
    }
...
    string data = @"12345|PETE PETERSON                 |01012011";
    var customers = new FileHelperEngine<Customer>().ReadString(data);
