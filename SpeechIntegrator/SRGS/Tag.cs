﻿using System;
using System.Xml.Serialization;
namespace Resco.InAppSpeechRecognition.Srgs
{
    /// <summary>
    /// Tag is used to return different values 
    /// </summary>
    public class Tag : RuleItem
    {
        /// <summary>
        /// tag> elements are used to convert the result generated by an SRGS speech grammar processor into an ECMAScript object that can be processed by the VoiceXML application. 
        /// For example:
        /// <item> yeah<tag>out="yes";</tag></item>
        /// out="yes"; is an ECMAScript statement assigning the string "yes" to the output variable when the speaker says "yeah.".
        /// </summary>
        /// <param name="semantics">Type of semantics that is used in grammar</param>
        public Tag(string semantics)
        {
            if (semantics == "semantics-ms/1.0")
                tagFormat = "$";
            else if (semantics == "semantics/1.0")
                tagFormat = "out";
            else
                throw new ArgumentException("input string can only be 'semantics-ms/1.0' or 'semantics/1.0'.");
        }

        /// <summary>
        /// Creates new instance of tag with default standard semantics defined by w3c
        /// </summary>
        public Tag()
        {
            tagFormat = Grammar.Semantics.StandardSemanticTagFormat;
        }

        /// <summary>
        /// Creates new instance of tag
        /// </summary>
        /// <param name="semantics">Type of semantics that is used in grammar</param>
        /// <param name="propertyName">for instance $.example (ms semantics) out.example (standard semantics)</param>
        /// <param name="value">value that will be assigned to the property</param>
        public Tag(string semantics, string propertyName, string value) : this(semantics)
        {
            Content = tagFormat + "." + propertyName + "=" + value + ";";
        }

        /// <summary>
        /// Creates new instance of tag
        /// </summary>
        /// <param name="semantics">Type of semantics that is used in grammar</param>
        /// <param name="value">Value that will be assigned directly to the variable for instance: out = 10; $ = 10;</param>
        public Tag(string semantics, string value) : this(semantics)
        {
            Content = tagFormat + "=" + value + ";";
        }
        
        /// <summary>
        /// Inner text of this tag
        /// </summary>
        [XmlText]
        public string Content { get; set; }

        private string tagFormat;

        /// <summary>
        /// Reference the last ruleref element to be used in the rule that matches the utterance.
        /// </summary>
        public static readonly string MicrosoftsLatest = "&&";

        /// <summary>
        /// Reference the last ruleref element to be used in the rule that matches the utterance.
        /// </summary>
        public static readonly string Latest = "rules.latest()";
    }
}
