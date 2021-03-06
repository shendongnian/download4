    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.CheckCharacters = false;
                XmlReader reader = XmlReader.Create(FILENAME, settings);
                XmlSerializer serializer = new XmlSerializer(typeof(RelationshipDataRelationshipData));
                RelationshipDataRelationshipData relationshipDataRelationshipData = (RelationshipDataRelationshipData)serializer.Deserialize(reader);
            }
        }
        [XmlRoot(ElementName = "RelationshipData", Namespace = "http://www.gleif.org/data/schema/rr/2016")]
        public class RelationshipDataRelationshipData
        {
            [XmlElement("Header")]
            public Header header { get; set; }
            [XmlElement("RelationshipRecords", Namespace = "http://www.gleif.org/data/schema/rr/2016")]
            public RelationshipRecords relationshipRecords { get; set; }
        }
        [XmlRoot(ElementName = "Header", Namespace = "http://www.gleif.org/data/schema/rr/2016")]
        public class Header
        {
            [XmlElement("ContentDate")]
            public DateTime ContentDate { get; set; }
            [XmlElement("FileContent")]
            public string FileContent { get; set;}
            [XmlElement("RecordCount")]
            public int RecordCount { get; set; }
            [XmlElement("Extension", Namespace = "http://www.gleif.org/data/schema/rr/2016")]
            public Extension extension { get; set;}
        }
        [XmlRoot(ElementName = "Extension", Namespace = "http://www.gleif.org/data/schema/rr/2016")]
        public class Extension
        {
            [XmlElement(ElementName = "Sources", Namespace = "http://www.gleif.org/concatenated-file/header-extension/2.0")]
            public Sourses sources { get; set;}
        }
        [XmlRoot(ElementName = "Sources", Namespace = "http://www.gleif.org/concatenated-file/header-extension/2.0")]
        public class Sourses
        {
            [XmlElement("Source")]
            public List<Source> source { get; set;}
        }
        [XmlRoot(ElementName = "Source", Namespace = "http://www.gleif.org/concatenated-file/header-extension/2.0")]
        public class Source
        {
            [XmlElement("ContentDate")]
            public DateTime ContentDate { get; set; }
            [XmlElement("Originator")]
            public string Originator { get; set;}
            [XmlElement("RecordCount")]
            public int RecordCount { get; set; }
        }
        [XmlRoot(ElementName = "RelationshipRecords", Namespace = "http://www.gleif.org/data/schema/rr/2016")]
        public class RelationshipRecords
        {
             [XmlElement("RelationshipRecord")]
            public List<RelationshipRecord> relationshipRecord { get; set; } 
        }
        [XmlRoot(ElementName = "RelationshipRecord", Namespace = "http://www.gleif.org/data/schema/rr/2016")]
        public class RelationshipRecord
        {
            [XmlElement("Relationship")]
            public Relationship relationship { get; set; }
            [XmlElement("Registration")]
            public Registration registration { get; set; }
        }
        [XmlRoot(ElementName = "Relationship", Namespace = "http://www.gleif.org/data/schema/rr/2016")]
        public class Relationship
        {
            [XmlElement("StartNode")]
            public Node StartNode { get; set; }
            [XmlElement("EndNode")]
            public Node EndNode { get; set; }
        }
        [XmlRoot(ElementName = "Node", Namespace = "http://www.gleif.org/data/schema/rr/2016")]
        public class Node
        {
            public string NodeID { get; set; }
            public string NodeIDType { get; set; }
            public string RelationshipType { get; set; }
            public string RelationshipStatus { get; set; }
            public RelationshipQualifiers relationshipQualifiers { get; set; }
        }
        [XmlRoot(ElementName = "class RelationshipQualifiers", Namespace = "http://www.gleif.org/data/schema/rr/2016")]
        public class RelationshipQualifiers
        {
            [XmlElement("RelationshipQualifier")]
            public RelationshipQualifier relationshipQualifier { get; set; }
        }
        [XmlRoot(ElementName = "class RelationshipQualifier", Namespace = "http://www.gleif.org/data/schema/rr/2016")]
        public class RelationshipQualifier
        {
            public string QualifierDimension { get ; set; }
            public string QualifierCategory { get; set; }
        }
        [XmlRoot(ElementName = "Registration", Namespace = "http://www.gleif.org/data/schema/rr/2016")]
        public class Registration
        {
            public DateTime InitialRegistrationDate { get; set; }
            public DateTime LastUpdateDate { get; set; }
            public string RegistrationStatus { get; set; }
            public DateTime NextRenewalDate { get; set; }
            public string ManagingLOU { get; set; }
            public string ValidationSources { get; set; }
            public string ValidationDocuments { get; set; }
        }
    }
