using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Resco.InAppSpeechRecognition.Srgs
{
    /// <summary>
    /// Contains information about the grammar document in a metadata schema.
    /// </summary>
    public class Metadata
    {
        [XmlElement("RDF"/*, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#"*/)]
        public RDF Content { get; set; }
    }

    /// <summary>
    /// Resource Description Format (RDF) schema in conjunction with the general metadata properties 
    /// (for example, Title, Creator, Subject, Description, and Copyrights) defined in the Dublin Core Metadata Initiative.
    /// </summary>
    public class RDF
    {
        [XmlElement(ElementName = "Description", Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public Description Description { get; set; }

       /* [XmlAttribute("rdf", Namespace = "http://www.w3.org/2001/06/grammar")]
        public string Rdf { get; set; }

        [XmlAttribute("rdfs", Namespace = "http://www.w3.org/2001/06/grammar")]
        public string Rdfs { get; set; }

        [XmlAttribute("dc", Namespace = "http://www.w3.org/2001/06/grammar")]
        public string Dc { get; set; }*/

        public RDF()
        {
            /*Rdf = "http://www.w3.org/1999/02/22-rdf-syntax-ns#";
            Rdfs = "http://www.w3.org/TR/1999/PR-rdf-schema-19990303#";
            Dc = "http://purl.org/metadata/dublin_core#";*/
        }
    }

    /// <summary>
    /// Description of the grammar
    /// </summary>
    public class Description
    {
        public Description()
        {
            Creators = new Creator();
            Date = DateTime.Now;
        }

        [XmlAttribute("about")]
        public string About { get; set; }

        [XmlAttribute("Title", Namespace = "http://purl.org/metadata/dublin_core#")]
        public string Title { get; set; }

        [XmlAttribute("Description", Namespace = "http://purl.org/metadata/dublin_core#")]
        public string Descript { get; set; }

        [XmlAttribute("Publisher", Namespace = "http://purl.org/metadata/dublin_core#")]
        public string Publisher { get; set; }

        [XmlAttribute("Language", Namespace = "http://purl.org/metadata/dublin_core#")]
        public string Language { get; set; }

        [XmlAttribute("Date", Namespace = "http://purl.org/metadata/dublin_core#")]
        public DateTime Date { get; set; }

        [XmlAttribute("Rights", Namespace = "http://purl.org/metadata/dublin_core#")]
        public string Rights { get; set; }

        [XmlAttribute("Format", Namespace = "http://purl.org/metadata/dublin_core#")]
        public string Format { get; set; }

        [XmlElement(ElementName = "Creator", Namespace = "http://purl.org/metadata/dublin_core#")]
        public Creator Creators { get; set; }

        private string m_id;
        [XmlIgnore]
        public string ID { get { return m_id; }
            set
            {
                m_id = value;
                Creators.Sequence.ID = value;
            }
        }
        public void AddCreator(string name)
        {
            Creators.Sequence.Names.Add(name);
        }
    }

    public class Creator
    {
        [XmlElement("Seq", Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public Sequence Sequence { get { return m_sequence; } }
        private Sequence m_sequence = new Sequence(); 
    }

    public class Sequence
    {
        private List<string> m_names = new List<string>();

        [XmlArrayItem(ElementName = "li", Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public List<string> Names { get { return m_names; } }

        [XmlAttribute("ID")]
        public string ID { get; set; }
    }
}
