using System.Xml.Serialization;

namespace PiStudio.Win10.Voice.Srgs
{    
	/// <summary>
	/// Provides example of one possible combination in <see cref="Rule"/>
	/// </summary>
    public class Example
    {
		/// <summary>
		/// Creates new instance of <see cref="Example"/> element.
		/// </summary>
		/// <param name="text">Content of <see cref="Example"/> element</param>
        public Example(string text)
        {
            Text = text;
        }

		/// <summary>
		/// Creates new instance of <see cref="Example"/> element.
		/// </summary>
		public Example()
        {
            Text = " ";
        }

		/// <summary>
		/// Content of <see cref="Example"/> element
		/// </summary>
		[XmlText]
        public string Text { get; set; }
    }
}
