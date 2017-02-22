using System.Xml.Serialization;

namespace PiStudio.Win10.Voice.Commands
{
    /// <summary>
    /// Base class for command set prefix
    /// </summary>
    public abstract class Prefix
    {
		/// <summary>
		/// Creates new instance of <see cref="Prefix"/> class.
		/// </summary>
        public Prefix() { }

		/// <summary>
		/// Creates new instance of <see cref="Prefix"/> class.
		/// </summary>
		/// <param name="content">Content of the <see cref="Prefix"/> element.</param>
		public Prefix(string content)
        {
            Content = content;
        }

		/// <summary>
		/// Content of the <see cref="Prefix"/> element.
		/// </summary>
		[XmlText]
        public string Content { get; set; }
    }

    /// <summary>
    /// Optional child element of the CommandSet element. If present, must be the first child element of the CommandSet element.
    /// Specifies a user-friendly name for an app that a user can speak when giving a voice command.This is useful for apps with names that are long or are difficult to pronounce.
    /// Avoid using prefixes that conflict with other voice-enabled experiences.
    /// </summary>
    public class CommandPrefix : Prefix
    {
    }

    /// <summary>
    /// Optional child element of the CommandSet element. If present, must be the first child element of the CommandSet element.
    /// Replaces CommandPrefix and supports the RequireAppName attribute and { builtin:AppName } phrase of the ListenFor element.
    /// Specifies a user-friendly name for an app that a user can speak when giving a voice command.This is useful for apps with names that are long or are difficult to pronounce.
    /// Avoid using prefixes that conflict with other voice-enabled experiences.
    /// </summary>
    public class AppName : Prefix
    {
    }
}