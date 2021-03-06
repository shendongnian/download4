    [Table("Polygons")]
    public class Polygon
    {
        public int PolygonId { get; set; }
        public String Texture { get; set; }
        [NotMapped]
        public virtual ICollection<Point> Points { get; set; }
        [Column("Points")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string PointsXml
        {
            get
            {
                var serializer = new XmlSerializer(typeof (List<Point>));
                using (var stringWriter = new StringWriter())
                {
                    serializer.Serialize(stringWriter, Points.ToList());
                    stringWriter.Flush();
                    return stringWriter.ToString();
                }
            }
            set
            {
                var serializer = new XmlSerializer(typeof(List<Point>));
                using (var stringReader = new StringReader(value))
                {
                    Points = (List<Point>) serializer.Deserialize(stringReader);
                }
            }
        }
    }
