namespace System.Runtime.CompilerServices {
    internal class __BlockReflectionAttribute : Attribute { }
}

namespace Microsoft.Xml.Serialization.GeneratedAssembly {


    [System.Runtime.CompilerServices.__BlockReflection]
    public class XmlSerializationWriter1 : System.Xml.Serialization.XmlSerializationWriter {

        public void Write36_VoiceCommands(object o, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs ?? @"http://schemas.microsoft.com/voicecommands/1.2";
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"VoiceCommands", defaultNamespace);
                return;
            }
            TopLevelElement();
            string namespace1 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
            Write21_VoiceCommands(@"VoiceCommands", namespace1, ((global::Resco.InAppSpeechRecognition.Commands.VoiceCommands)o), true, false, namespace1, @"http://schemas.microsoft.com/voicecommands/1.2");
        }

        public void Write37_grammar(object o, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs ?? @"http://www.w3.org/2001/06/grammar";
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"grammar", defaultNamespace);
                return;
            }
            TopLevelElement();
            string namespace2 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
            Write34_Grammar(@"grammar", namespace2, ((global::Resco.InAppSpeechRecognition.Srgs.Grammar)o), true, false, namespace2, @"http://www.w3.org/2001/06/grammar");
        }

        public void Write38_AppSettings(object o, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs ?? @"";
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"AppSettings", defaultNamespace);
                return;
            }
            TopLevelElement();
            string namespace3 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            Write35_AppSettings(@"AppSettings", namespace3, ((global::PiStudio.Shared.Data.AppSettings)o), true, false, namespace3, @"");
        }

        void Write35_AppSettings(string n, string ns, global::PiStudio.Shared.Data.AppSettings o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Shared.Data.AppSettings)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"AppSettings", defaultNamespace);
            string namespace4 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"FirstLaunch", namespace4, System.Xml.XmlConvert.ToString((global::System.Boolean)((global::System.Boolean)o.@FirstLaunch)));
            WriteEndElement(o);
        }

        void Write34_Grammar(string n, string ns, global::Resco.InAppSpeechRecognition.Srgs.Grammar o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Srgs.Grammar)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Grammar", defaultNamespace);
            WriteAttribute(@"lang", @"http://www.w3.org/XML/1998/namespace", ((global::System.String)o.@Language));
            WriteAttribute(@"tag-format", @"", ((global::System.String)o.@TagFormat));
            WriteAttribute(@"root", @"", ((global::System.String)o.@Root));
            WriteAttribute(@"version", @"", ((global::System.String)o.@Version));
            WriteAttribute(@"mode", @"", ((global::System.String)o.@Mode));
            string namespace5 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
            Write25_Metadata(@"Metadata", namespace5, ((global::Resco.InAppSpeechRecognition.Srgs.Metadata)o.@Metadata), false, false, namespace5, @"http://www.w3.org/2001/06/grammar");
            {
                global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Srgs.Rule> a = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Srgs.Rule>)o.@Rules;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace6 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                        Write33_Rule(@"rule", namespace6, ((global::Resco.InAppSpeechRecognition.Srgs.Rule)a[ia]), false, false, namespace6, @"http://www.w3.org/2001/06/grammar");
                    }
                }
            }
            WriteEndElement(o);
        }

        void Write33_Rule(string n, string ns, global::Resco.InAppSpeechRecognition.Srgs.Rule o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Srgs.Rule)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Rule", defaultNamespace);
            WriteAttribute(@"scope", @"", ((global::System.String)o.@Scope));
            WriteAttribute(@"id", @"", ((global::System.String)o.@Id));
            {
                global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Srgs.Example> a = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Srgs.Example>)o.@Examples;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace7 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                        Write32_Example(@"example", namespace7, ((global::Resco.InAppSpeechRecognition.Srgs.Example)a[ia]), false, false, namespace7, @"http://www.w3.org/2001/06/grammar");
                    }
                }
            }
            {
                global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Srgs.RuleItem> a = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Srgs.RuleItem>)o.@Elements;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        global::Resco.InAppSpeechRecognition.Srgs.RuleItem ai = (global::Resco.InAppSpeechRecognition.Srgs.RuleItem)a[ia];
                        if ((object)(ai) != null){
                            if (ai is global::Resco.InAppSpeechRecognition.Srgs.Token) {
                                string namespace8 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                                Write29_Token(@"token", namespace8, ((global::Resco.InAppSpeechRecognition.Srgs.Token)ai), false, false, namespace8, @"http://www.w3.org/2001/06/grammar");
                            }
                            else if (ai is global::Resco.InAppSpeechRecognition.Srgs.OneOf) {
                                string namespace9 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                                Write30_OneOf(@"one-of", namespace9, ((global::Resco.InAppSpeechRecognition.Srgs.OneOf)ai), false, false, namespace9, @"http://www.w3.org/2001/06/grammar");
                            }
                            else if (ai is global::Resco.InAppSpeechRecognition.Srgs.Tag) {
                                string namespace10 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                                Write28_Tag(@"tag", namespace10, ((global::Resco.InAppSpeechRecognition.Srgs.Tag)ai), false, false, namespace10, @"http://www.w3.org/2001/06/grammar");
                            }
                            else if (ai is global::Resco.InAppSpeechRecognition.Srgs.Item) {
                                string namespace11 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                                Write31_Item(@"item", namespace11, ((global::Resco.InAppSpeechRecognition.Srgs.Item)ai), false, false, namespace11, @"http://www.w3.org/2001/06/grammar");
                            }
                            else if (ai is global::Resco.InAppSpeechRecognition.Srgs.RuleRef) {
                                string namespace12 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                                Write27_RuleRef(@"ruleref", namespace12, ((global::Resco.InAppSpeechRecognition.Srgs.RuleRef)ai), false, false, namespace12, @"http://www.w3.org/2001/06/grammar");
                            }
                            else  if ((object)(ai) != null){
                                throw CreateUnknownTypeException(ai);
                            }
                        }
                    }
                }
            }
            if ((object)(o.@Content) != null){
                WriteValue(((global::System.String)o.@Content));
            }
            WriteEndElement(o);
        }

        void Write27_RuleRef(string n, string ns, global::Resco.InAppSpeechRecognition.Srgs.RuleRef o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Srgs.RuleRef)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"RuleRef", defaultNamespace);
            WriteAttribute(@"uri", @"", ((global::System.String)o.@Uri));
            WriteAttribute(@"special", @"", ((global::System.String)o.@Special));
            WriteAttribute(@"type", @"", ((global::System.String)o.@Type));
            WriteEndElement(o);
        }

        void Write31_Item(string n, string ns, global::Resco.InAppSpeechRecognition.Srgs.Item o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Srgs.Item)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Item", defaultNamespace);
            WriteAttribute(@"weight", @"", ((global::System.String)o.@Weight));
            WriteAttribute(@"repeat", @"", ((global::System.String)o.@Repeat));
            if ((object)(o.@Content) != null){
                WriteValue(((global::System.String)o.@Content));
            }
            {
                global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Srgs.RuleItem> a = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Srgs.RuleItem>)o.@Elements;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        global::Resco.InAppSpeechRecognition.Srgs.RuleItem ai = (global::Resco.InAppSpeechRecognition.Srgs.RuleItem)a[ia];
                        if ((object)(ai) != null){
                            if (ai is global::Resco.InAppSpeechRecognition.Srgs.Token) {
                                string namespace13 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                                Write29_Token(@"token", namespace13, ((global::Resco.InAppSpeechRecognition.Srgs.Token)ai), false, false, namespace13, @"http://www.w3.org/2001/06/grammar");
                            }
                            else if (ai is global::Resco.InAppSpeechRecognition.Srgs.OneOf) {
                                string namespace14 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                                Write30_OneOf(@"one-of", namespace14, ((global::Resco.InAppSpeechRecognition.Srgs.OneOf)ai), false, false, namespace14, @"http://www.w3.org/2001/06/grammar");
                            }
                            else if (ai is global::Resco.InAppSpeechRecognition.Srgs.Tag) {
                                string namespace15 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                                Write28_Tag(@"tag", namespace15, ((global::Resco.InAppSpeechRecognition.Srgs.Tag)ai), false, false, namespace15, @"http://www.w3.org/2001/06/grammar");
                            }
                            else if (ai is global::Resco.InAppSpeechRecognition.Srgs.Item) {
                                string namespace16 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                                Write31_Item(@"item", namespace16, ((global::Resco.InAppSpeechRecognition.Srgs.Item)ai), false, false, namespace16, @"http://www.w3.org/2001/06/grammar");
                            }
                            else if (ai is global::Resco.InAppSpeechRecognition.Srgs.RuleRef) {
                                string namespace17 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                                Write27_RuleRef(@"ruleref", namespace17, ((global::Resco.InAppSpeechRecognition.Srgs.RuleRef)ai), false, false, namespace17, @"http://www.w3.org/2001/06/grammar");
                            }
                            else  if ((object)(ai) != null){
                                throw CreateUnknownTypeException(ai);
                            }
                        }
                    }
                }
            }
            WriteEndElement(o);
        }

        void Write28_Tag(string n, string ns, global::Resco.InAppSpeechRecognition.Srgs.Tag o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Srgs.Tag)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Tag", defaultNamespace);
            if ((object)(o.@Content) != null){
                WriteValue(((global::System.String)o.@Content));
            }
            WriteEndElement(o);
        }

        void Write30_OneOf(string n, string ns, global::Resco.InAppSpeechRecognition.Srgs.OneOf o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Srgs.OneOf)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"OneOf", defaultNamespace);
            {
                global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Srgs.Item> a = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Srgs.Item>)o.@Items;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace18 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                        Write31_Item(@"item", namespace18, ((global::Resco.InAppSpeechRecognition.Srgs.Item)a[ia]), false, false, namespace18, @"http://www.w3.org/2001/06/grammar");
                    }
                }
            }
            WriteEndElement(o);
        }

        void Write29_Token(string n, string ns, global::Resco.InAppSpeechRecognition.Srgs.Token o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Srgs.Token)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Token", defaultNamespace);
            WriteAttribute(@"display", @"", ((global::System.String)o.@Display));
            WriteAttribute(@"pron", @"", ((global::System.String)o.@Pronunciation));
            if ((object)(o.@Text) != null){
                WriteValue(((global::System.String)o.@Text));
            }
            WriteEndElement(o);
        }

        void Write32_Example(string n, string ns, global::Resco.InAppSpeechRecognition.Srgs.Example o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Srgs.Example)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Example", defaultNamespace);
            if ((object)(o.@Text) != null){
                WriteValue(((global::System.String)o.@Text));
            }
            WriteEndElement(o);
        }

        void Write25_Metadata(string n, string ns, global::Resco.InAppSpeechRecognition.Srgs.Metadata o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Srgs.Metadata)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Metadata", defaultNamespace);
            string namespace19 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
            Write24_RDF(@"RDF", namespace19, ((global::Resco.InAppSpeechRecognition.Srgs.RDF)o.@Content), false, false, namespace19, @"http://www.w3.org/2001/06/grammar");
            WriteEndElement(o);
        }

        void Write24_RDF(string n, string ns, global::Resco.InAppSpeechRecognition.Srgs.RDF o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Srgs.RDF)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"RDF", defaultNamespace);
            string namespace20 = ( parentCompileTimeNs == @"http://www.w3.org/1999/02/22-rdf-syntax-ns#" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/1999/02/22-rdf-syntax-ns#";
            Write23_Description(@"Description", namespace20, ((global::Resco.InAppSpeechRecognition.Srgs.Description)o.@Description), false, false, namespace20, @"http://www.w3.org/1999/02/22-rdf-syntax-ns#");
            WriteEndElement(o);
        }

        void Write23_Description(string n, string ns, global::Resco.InAppSpeechRecognition.Srgs.Description o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Srgs.Description)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Description", defaultNamespace);
            WriteAttribute(@"about", @"", ((global::System.String)o.@About));
            WriteAttribute(@"Title", @"http://purl.org/metadata/dublin_core#", ((global::System.String)o.@Title));
            WriteAttribute(@"Description", @"http://purl.org/metadata/dublin_core#", ((global::System.String)o.@Descript));
            WriteAttribute(@"Publisher", @"http://purl.org/metadata/dublin_core#", ((global::System.String)o.@Publisher));
            WriteAttribute(@"Language", @"http://purl.org/metadata/dublin_core#", ((global::System.String)o.@Language));
            WriteAttribute(@"Date", @"http://purl.org/metadata/dublin_core#", FromDateTime(((global::System.DateTime)o.@Date)));
            WriteAttribute(@"Rights", @"http://purl.org/metadata/dublin_core#", ((global::System.String)o.@Rights));
            WriteAttribute(@"Format", @"http://purl.org/metadata/dublin_core#", ((global::System.String)o.@Format));
            string namespace21 = ( parentCompileTimeNs == @"http://purl.org/metadata/dublin_core#" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://purl.org/metadata/dublin_core#";
            Write22_Creator(@"Creator", namespace21, ((global::Resco.InAppSpeechRecognition.Srgs.Creator)o.@Creators), false, false, namespace21, @"http://purl.org/metadata/dublin_core#");
            WriteEndElement(o);
        }

        void Write22_Creator(string n, string ns, global::Resco.InAppSpeechRecognition.Srgs.Creator o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Srgs.Creator)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Creator", defaultNamespace);
            WriteEndElement(o);
        }

        void Write21_VoiceCommands(string n, string ns, global::Resco.InAppSpeechRecognition.Commands.VoiceCommands o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Commands.VoiceCommands)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"VoiceCommands", defaultNamespace);
            {
                global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.CommandSet> a = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.CommandSet>)o.@CommandSets;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace22 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                        Write20_CommandSet(@"CommandSet", namespace22, ((global::Resco.InAppSpeechRecognition.Commands.CommandSet)a[ia]), false, false, namespace22, @"http://schemas.microsoft.com/voicecommands/1.2");
                    }
                }
            }
            WriteEndElement(o);
        }

        void Write20_CommandSet(string n, string ns, global::Resco.InAppSpeechRecognition.Commands.CommandSet o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Commands.CommandSet)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"CommandSet", defaultNamespace);
            WriteAttribute(@"lang", @"http://www.w3.org/XML/1998/namespace", ((global::System.String)o.@Language));
            WriteAttribute(@"Name", @"", ((global::System.String)o.@Name));
            if ((object)(o.@Prefix) != null){
                if (o.@Prefix is global::Resco.InAppSpeechRecognition.Commands.AppName) {
                    string namespace23 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                    Write4_AppName(@"AppName", namespace23, ((global::Resco.InAppSpeechRecognition.Commands.AppName)o.@Prefix), false, false, namespace23, @"http://schemas.microsoft.com/voicecommands/1.2");
                }
                else if (o.@Prefix is global::Resco.InAppSpeechRecognition.Commands.CommandPrefix) {
                    string namespace24 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                    Write3_CommandPrefix(@"CommandPrefix", namespace24, ((global::Resco.InAppSpeechRecognition.Commands.CommandPrefix)o.@Prefix), false, false, namespace24, @"http://schemas.microsoft.com/voicecommands/1.2");
                }
                else  if ((object)(o.@Prefix) != null){
                    throw CreateUnknownTypeException(o.@Prefix);
                }
            }
            string namespace25 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
            WriteElementString(@"Example", namespace25, ((global::System.String)o.@Example));
            {
                global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.Command> a = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.Command>)o.@Commands;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace26 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                        Write13_Command(@"Command", namespace26, ((global::Resco.InAppSpeechRecognition.Commands.Command)a[ia]), false, false, namespace26, @"http://schemas.microsoft.com/voicecommands/1.2");
                    }
                }
            }
            {
                global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.PhraseList> a = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.PhraseList>)o.@PhraseLists;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace27 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                        Write16_PhraseList(@"PhraseList", namespace27, ((global::Resco.InAppSpeechRecognition.Commands.PhraseList)a[ia]), false, false, namespace27, @"http://schemas.microsoft.com/voicecommands/1.2");
                    }
                }
            }
            {
                global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.PhraseTopic> a = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.PhraseTopic>)o.@PhraseTopics;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace28 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                        Write19_PhraseTopic(@"PhraseTopic", namespace28, ((global::Resco.InAppSpeechRecognition.Commands.PhraseTopic)a[ia]), false, false, namespace28, @"http://schemas.microsoft.com/voicecommands/1.2");
                    }
                }
            }
            WriteEndElement(o);
        }

        void Write19_PhraseTopic(string n, string ns, global::Resco.InAppSpeechRecognition.Commands.PhraseTopic o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Commands.PhraseTopic)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"PhraseTopic", defaultNamespace);
            WriteAttribute(@"Label", @"", ((global::System.String)o.@Label));
            WriteAttribute(@"Scenario", @"", Write17_Scenario(((global::Resco.InAppSpeechRecognition.Commands.Scenario)o.@Scenario)));
            {
                global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.Subjects> a = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.Subjects>)o.@Subjects;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace29 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                        WriteElementString(@"Subject", namespace29, Write18_Subjects(((global::Resco.InAppSpeechRecognition.Commands.Subjects)a[ia])));
                    }
                }
            }
            WriteEndElement(o);
        }

        string Write18_Subjects(global::Resco.InAppSpeechRecognition.Commands.Subjects v) {
            string s = null;
            switch (v) {
                case global::Resco.InAppSpeechRecognition.Commands.Subjects.@DateTime: s = @"Date/Time"; break;
                case global::Resco.InAppSpeechRecognition.Commands.Subjects.@Addresses: s = @"Addresses"; break;
                case global::Resco.InAppSpeechRecognition.Commands.Subjects.@CityState: s = @"City/State"; break;
                case global::Resco.InAppSpeechRecognition.Commands.Subjects.@PersonNames: s = @"Person Names"; break;
                case global::Resco.InAppSpeechRecognition.Commands.Subjects.@Movies: s = @"Movies"; break;
                case global::Resco.InAppSpeechRecognition.Commands.Subjects.@Music: s = @"Music"; break;
                case global::Resco.InAppSpeechRecognition.Commands.Subjects.@PhoneNumber: s = @"Phone Number"; break;
                default: throw CreateInvalidEnumValueException(((System.Int64)v).ToString(System.Globalization.CultureInfo.InvariantCulture), @"Resco.InAppSpeechRecognition.Commands.Subjects");
            }
            return s;
        }

        string Write17_Scenario(global::Resco.InAppSpeechRecognition.Commands.Scenario v) {
            string s = null;
            switch (v) {
                case global::Resco.InAppSpeechRecognition.Commands.Scenario.@NaturalLanguage: s = @"Natural Language"; break;
                case global::Resco.InAppSpeechRecognition.Commands.Scenario.@Search: s = @"Search"; break;
                case global::Resco.InAppSpeechRecognition.Commands.Scenario.@ShortMessage: s = @"Short Message"; break;
                case global::Resco.InAppSpeechRecognition.Commands.Scenario.@Dictation: s = @"Dictation"; break;
                case global::Resco.InAppSpeechRecognition.Commands.Scenario.@Commands: s = @"Commands"; break;
                case global::Resco.InAppSpeechRecognition.Commands.Scenario.@FormFilling: s = @"Form Filling"; break;
                default: throw CreateInvalidEnumValueException(((System.Int64)v).ToString(System.Globalization.CultureInfo.InvariantCulture), @"Resco.InAppSpeechRecognition.Commands.Scenario");
            }
            return s;
        }

        void Write16_PhraseList(string n, string ns, global::Resco.InAppSpeechRecognition.Commands.PhraseList o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Commands.PhraseList)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"PhraseList", defaultNamespace);
            WriteAttribute(@"Label", @"", ((global::System.String)o.@Label));
            WriteAttribute(@"Disambiguate", @"", System.Xml.XmlConvert.ToString((global::System.Boolean)((global::System.Boolean)o.@Disambiguate)));
            {
                global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.ListItem> a = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.ListItem>)o.@Items;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace30 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                        Write15_ListItem(@"Item", namespace30, ((global::Resco.InAppSpeechRecognition.Commands.ListItem)a[ia]), false, false, namespace30, @"http://schemas.microsoft.com/voicecommands/1.2");
                    }
                }
            }
            WriteEndElement(o);
        }

        void Write15_ListItem(string n, string ns, global::Resco.InAppSpeechRecognition.Commands.ListItem o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Commands.ListItem)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"ListItem", defaultNamespace);
            WriteAttribute(@"Display", @"", ((global::System.String)o.@Display));
            if ((object)(o.@Content) != null){
                WriteValue(((global::System.String)o.@Content));
            }
            WriteEndElement(o);
        }

        void Write13_Command(string n, string ns, global::Resco.InAppSpeechRecognition.Commands.Command o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Commands.Command)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Command", defaultNamespace);
            WriteAttribute(@"Name", @"", ((global::System.String)o.@Name));
            string namespace31 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
            WriteElementString(@"Example", namespace31, ((global::System.String)o.@Example));
            {
                global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.ListenFor> a = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.ListenFor>)o.@ListenFor;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace32 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                        Write6_ListenFor(@"ListenFor", namespace32, ((global::Resco.InAppSpeechRecognition.Commands.ListenFor)a[ia]), false, false, namespace32, @"http://schemas.microsoft.com/voicecommands/1.2");
                    }
                }
            }
            string namespace33 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
            Write7_Feedback(@"Feedback", namespace33, ((global::Resco.InAppSpeechRecognition.Commands.Feedback)o.@Feedback), false, false, namespace33, @"http://schemas.microsoft.com/voicecommands/1.2");
            if ((object)(o.@VoiceAction) != null){
                if (o.@VoiceAction is global::Resco.InAppSpeechRecognition.Commands.ShowDialog) {
                    string namespace34 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                    Write11_ShowDialog(@"ShowDialog", namespace34, ((global::Resco.InAppSpeechRecognition.Commands.ShowDialog)o.@VoiceAction), false, false, namespace34, @"http://schemas.microsoft.com/voicecommands/1.2");
                }
                else if (o.@VoiceAction is global::Resco.InAppSpeechRecognition.Commands.CustomAction) {
                    string namespace35 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                    Write12_CustomAction(@"CustomAction", namespace35, ((global::Resco.InAppSpeechRecognition.Commands.CustomAction)o.@VoiceAction), false, false, namespace35, @"http://schemas.microsoft.com/voicecommands/1.2");
                }
                else if (o.@VoiceAction is global::Resco.InAppSpeechRecognition.Commands.Navigate) {
                    string namespace36 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                    Write9_Navigate(@"Navigate", namespace36, ((global::Resco.InAppSpeechRecognition.Commands.Navigate)o.@VoiceAction), false, false, namespace36, @"http://schemas.microsoft.com/voicecommands/1.2");
                }
                else if (o.@VoiceAction is global::Resco.InAppSpeechRecognition.Commands.VoiceCommandService) {
                    string namespace37 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                    Write10_VoiceCommandService(@"VoiceCommandService", namespace37, ((global::Resco.InAppSpeechRecognition.Commands.VoiceCommandService)o.@VoiceAction), false, false, namespace37, @"http://schemas.microsoft.com/voicecommands/1.2");
                }
                else  if ((object)(o.@VoiceAction) != null){
                    throw CreateUnknownTypeException(o.@VoiceAction);
                }
            }
            WriteEndElement(o);
        }

        void Write10_VoiceCommandService(string n, string ns, global::Resco.InAppSpeechRecognition.Commands.VoiceCommandService o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Commands.VoiceCommandService)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"VoiceCommandService", defaultNamespace);
            WriteAttribute(@"Target", @"", ((global::System.String)o.@Target));
            WriteEndElement(o);
        }

        void Write9_Navigate(string n, string ns, global::Resco.InAppSpeechRecognition.Commands.Navigate o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Commands.Navigate)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Navigate", defaultNamespace);
            WriteAttribute(@"NavigationParameter", @"", ((global::System.String)o.@NavigationParameter));
            WriteAttribute(@"Target", @"", ((global::System.String)o.@Target));
            WriteEndElement(o);
        }

        void Write12_CustomAction(string n, string ns, global::Resco.InAppSpeechRecognition.Commands.CustomAction o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Commands.CustomAction)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"CustomAction", defaultNamespace);
            WriteAttribute(@"Parameter", @"", ((global::System.String)o.@ActionParameter));
            if ((object)(o.@ActionContent) != null){
                WriteValue(((global::System.String)o.@ActionContent));
            }
            WriteEndElement(o);
        }

        void Write11_ShowDialog(string n, string ns, global::Resco.InAppSpeechRecognition.Commands.ShowDialog o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Commands.ShowDialog)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"ShowDialog", defaultNamespace);
            WriteAttribute(@"TextToDisplay", @"", ((global::System.String)o.@TextToDisplay));
            WriteEndElement(o);
        }

        void Write7_Feedback(string n, string ns, global::Resco.InAppSpeechRecognition.Commands.Feedback o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Commands.Feedback)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Feedback", defaultNamespace);
            if ((object)(o.@Content) != null){
                WriteValue(((global::System.String)o.@Content));
            }
            WriteEndElement(o);
        }

        void Write6_ListenFor(string n, string ns, global::Resco.InAppSpeechRecognition.Commands.ListenFor o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Commands.ListenFor)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"ListenFor", defaultNamespace);
            WriteAttribute(@"RequireAppName", @"", Write5_AppNameRequirement(((global::Resco.InAppSpeechRecognition.Commands.AppNameRequirement)o.@RequireAppName)));
            if ((object)(o.@Content) != null){
                WriteValue(((global::System.String)o.@Content));
            }
            WriteEndElement(o);
        }

        string Write5_AppNameRequirement(global::Resco.InAppSpeechRecognition.Commands.AppNameRequirement v) {
            string s = null;
            switch (v) {
                case global::Resco.InAppSpeechRecognition.Commands.AppNameRequirement.@BeforePhrase: s = @"BeforePhrase"; break;
                case global::Resco.InAppSpeechRecognition.Commands.AppNameRequirement.@AfterPhrase: s = @"AfterPhrase"; break;
                case global::Resco.InAppSpeechRecognition.Commands.AppNameRequirement.@BeforeOrAfterPhrase: s = @"BeforeOrAfterPhrase"; break;
                case global::Resco.InAppSpeechRecognition.Commands.AppNameRequirement.@ExplicitlySpecified: s = @"ExplicitlySpecified"; break;
                default: throw CreateInvalidEnumValueException(((System.Int64)v).ToString(System.Globalization.CultureInfo.InvariantCulture), @"Resco.InAppSpeechRecognition.Commands.AppNameRequirement");
            }
            return s;
        }

        void Write3_CommandPrefix(string n, string ns, global::Resco.InAppSpeechRecognition.Commands.CommandPrefix o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Commands.CommandPrefix)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"CommandPrefix", defaultNamespace);
            if ((object)(o.@Content) != null){
                WriteValue(((global::System.String)o.@Content));
            }
            WriteEndElement(o);
        }

        void Write4_AppName(string n, string ns, global::Resco.InAppSpeechRecognition.Commands.AppName o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Resco.InAppSpeechRecognition.Commands.AppName)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"AppName", defaultNamespace);
            if ((object)(o.@Content) != null){
                WriteValue(((global::System.String)o.@Content));
            }
            WriteEndElement(o);
        }

        protected override void InitCallbacks() {
        }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public class XmlSerializationReader1 : System.Xml.Serialization.XmlSerializationReader {

        public object Read36_VoiceCommands(string defaultNamespace = null) {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                if (((object) Reader.LocalName == (object)id1_VoiceCommands && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                    o = Read21_VoiceCommands(true, true, defaultNamespace);
                }
                else {
                    throw CreateUnknownNodeException();
                }
            }
            else {
                UnknownNode(null, defaultNamespace ?? @":VoiceCommands");
            }
            return (object)o;
        }

        public object Read37_grammar(string defaultNamespace = null) {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                if (((object) Reader.LocalName == (object)id3_grammar && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                    o = Read34_Grammar(true, true, defaultNamespace);
                }
                else {
                    throw CreateUnknownNodeException();
                }
            }
            else {
                UnknownNode(null, defaultNamespace ?? @":grammar");
            }
            return (object)o;
        }

        public object Read38_AppSettings(string defaultNamespace = null) {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                if (((object) Reader.LocalName == (object)id5_AppSettings && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id6_Item))) {
                    o = Read35_AppSettings(true, true, defaultNamespace);
                }
                else {
                    throw CreateUnknownNodeException();
                }
            }
            else {
                UnknownNode(null, defaultNamespace ?? @":AppSettings");
            }
            return (object)o;
        }

        global::PiStudio.Shared.Data.AppSettings Read35_AppSettings(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id5_AppSettings && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id6_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Shared.Data.AppSettings o;
            try {
                o = (global::PiStudio.Shared.Data.AppSettings)ActivatorHelper.CreateInstance(typeof(global::PiStudio.Shared.Data.AppSettings));
            }
            catch (System.MissingMemberException) {
                throw CreateInaccessibleConstructorException(@"global::PiStudio.Shared.Data.AppSettings");
            }
            catch (System.Security.SecurityException) {
                throw CreateCtorHasSecurityException(@"global::PiStudio.Shared.Data.AppSettings");
            }
            bool[] paramsRead = new bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations0 = 0;
            int readerCount0 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id7_FirstLaunch && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id6_Item))) {
                        {
                            o.@FirstLaunch = System.Xml.XmlConvert.ToBoolean(Reader.ReadElementContentAsString());
                        }
                        paramsRead[0] = true;
                    }
                    else {
                        UnknownNode((object)o, @":FirstLaunch");
                    }
                }
                else {
                    UnknownNode((object)o, @":FirstLaunch");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations0, ref readerCount0);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Srgs.Grammar Read34_Grammar(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id8_Grammar && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id4_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Srgs.Grammar o;
            o = new global::Resco.InAppSpeechRecognition.Srgs.Grammar();
            global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Srgs.Rule> a_6 = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Srgs.Rule>)o.@Rules;
            bool[] paramsRead = new bool[7];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id9_lang && string.Equals(Reader.NamespaceURI, id10_Item))) {
                    o.@Language = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id11_tagformat && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@TagFormat = Reader.Value;
                    paramsRead[1] = true;
                }
                else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id12_root && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Root = Reader.Value;
                    paramsRead[2] = true;
                }
                else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id13_version && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Version = Reader.Value;
                    paramsRead[3] = true;
                }
                else if (!paramsRead[5] && ((object) Reader.LocalName == (object)id14_mode && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Mode = Reader.Value;
                    paramsRead[5] = true;
                }
                else if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o, @"http://www.w3.org/XML/1998/namespace, :tag-format, :root, :version, :mode");
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations1 = 0;
            int readerCount1 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[4] && ((object) Reader.LocalName == (object)id15_Metadata && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                        o.@Metadata = Read25_Metadata(false, true, defaultNamespace);
                        paramsRead[4] = true;
                    }
                    else if (((object) Reader.LocalName == (object)id16_rule && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                        if ((object)(a_6) == null) Reader.Skip(); else a_6.Add(Read33_Rule(false, true, defaultNamespace));
                    }
                    else {
                        UnknownNode((object)o, @"http://www.w3.org/2001/06/grammar:Metadata, http://www.w3.org/2001/06/grammar:rule");
                    }
                }
                else {
                    UnknownNode((object)o, @"http://www.w3.org/2001/06/grammar:Metadata, http://www.w3.org/2001/06/grammar:rule");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations1, ref readerCount1);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Srgs.Rule Read33_Rule(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id17_Rule && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id4_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Srgs.Rule o;
            o = new global::Resco.InAppSpeechRecognition.Srgs.Rule();
            global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Srgs.Example> a_0 = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Srgs.Example>)o.@Examples;
            global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Srgs.RuleItem> a_1 = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Srgs.RuleItem>)o.@Elements;
            bool[] paramsRead = new bool[5];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[2] && ((object) Reader.LocalName == (object)id18_scope && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Scope = Reader.Value;
                    paramsRead[2] = true;
                }
                else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id19_id && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Id = Reader.Value;
                    paramsRead[3] = true;
                }
                else if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o, @":scope, :id");
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            int state = 0;
            Reader.MoveToContent();
            int whileIterations2 = 0;
            int readerCount2 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                string tmp = null;
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    switch (state) {
                    case 0:
                        if (((object) Reader.LocalName == (object)id20_example && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                            if ((object)(a_0) == null) Reader.Skip(); else a_0.Add(Read32_Example(false, true, defaultNamespace));
                        }
                        else {
                            state = 1;
                        }
                        break;
                    case 1:
                        if (((object) Reader.LocalName == (object)id21_item && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                            if ((object)(a_1) == null) Reader.Skip(); else a_1.Add(Read31_Item(false, true, defaultNamespace));
                        }
                        else if (((object) Reader.LocalName == (object)id22_ruleref && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                            if ((object)(a_1) == null) Reader.Skip(); else a_1.Add(Read27_RuleRef(false, true, defaultNamespace));
                        }
                        else if (((object) Reader.LocalName == (object)id23_tag && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                            if ((object)(a_1) == null) Reader.Skip(); else a_1.Add(Read28_Tag(false, true, defaultNamespace));
                        }
                        else if (((object) Reader.LocalName == (object)id24_token && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                            if ((object)(a_1) == null) Reader.Skip(); else a_1.Add(Read29_Token(false, true, defaultNamespace));
                        }
                        else if (((object) Reader.LocalName == (object)id25_oneof && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                            if ((object)(a_1) == null) Reader.Skip(); else a_1.Add(Read30_OneOf(false, true, defaultNamespace));
                        }
                        else {
                            state = 2;
                        }
                        break;
                    default:
                        UnknownNode((object)o, null);
                        break;
                    }
                }
                else if (Reader.NodeType == System.Xml.XmlNodeType.Text || 
                Reader.NodeType == System.Xml.XmlNodeType.CDATA || 
                Reader.NodeType == System.Xml.XmlNodeType.Whitespace || 
                Reader.NodeType == System.Xml.XmlNodeType.SignificantWhitespace) {
                    tmp = ReadString(tmp, false);
                    o.@Content = tmp;
                }
                else {
                    UnknownNode((object)o, null);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations2, ref readerCount2);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Srgs.OneOf Read30_OneOf(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id26_OneOf && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id4_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Srgs.OneOf o;
            o = new global::Resco.InAppSpeechRecognition.Srgs.OneOf();
            global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Srgs.Item> a_0 = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Srgs.Item>)o.@Items;
            bool[] paramsRead = new bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations3 = 0;
            int readerCount3 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (((object) Reader.LocalName == (object)id21_item && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                        if ((object)(a_0) == null) Reader.Skip(); else a_0.Add(Read31_Item(false, true, defaultNamespace));
                    }
                    else {
                        UnknownNode((object)o, @"http://www.w3.org/2001/06/grammar:item");
                    }
                }
                else {
                    UnknownNode((object)o, @"http://www.w3.org/2001/06/grammar:item");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations3, ref readerCount3);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Srgs.Item Read31_Item(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id27_Item && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id4_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Srgs.Item o;
            o = new global::Resco.InAppSpeechRecognition.Srgs.Item();
            global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Srgs.RuleItem> a_3 = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Srgs.RuleItem>)o.@Elements;
            bool[] paramsRead = new bool[4];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[1] && ((object) Reader.LocalName == (object)id28_weight && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Weight = Reader.Value;
                    paramsRead[1] = true;
                }
                else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id29_repeat && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Repeat = Reader.Value;
                    paramsRead[2] = true;
                }
                else if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o, @":weight, :repeat");
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations4 = 0;
            int readerCount4 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                string tmp = null;
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (((object) Reader.LocalName == (object)id21_item && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                        if ((object)(a_3) == null) Reader.Skip(); else a_3.Add(Read31_Item(false, true, defaultNamespace));
                    }
                    else if (((object) Reader.LocalName == (object)id22_ruleref && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                        if ((object)(a_3) == null) Reader.Skip(); else a_3.Add(Read27_RuleRef(false, true, defaultNamespace));
                    }
                    else if (((object) Reader.LocalName == (object)id23_tag && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                        if ((object)(a_3) == null) Reader.Skip(); else a_3.Add(Read28_Tag(false, true, defaultNamespace));
                    }
                    else if (((object) Reader.LocalName == (object)id24_token && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                        if ((object)(a_3) == null) Reader.Skip(); else a_3.Add(Read29_Token(false, true, defaultNamespace));
                    }
                    else if (((object) Reader.LocalName == (object)id25_oneof && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                        if ((object)(a_3) == null) Reader.Skip(); else a_3.Add(Read30_OneOf(false, true, defaultNamespace));
                    }
                    else {
                        UnknownNode((object)o, @"http://www.w3.org/2001/06/grammar:item, http://www.w3.org/2001/06/grammar:ruleref, http://www.w3.org/2001/06/grammar:tag, http://www.w3.org/2001/06/grammar:token, http://www.w3.org/2001/06/grammar:one-of");
                    }
                }
                else if (Reader.NodeType == System.Xml.XmlNodeType.Text || 
                Reader.NodeType == System.Xml.XmlNodeType.CDATA || 
                Reader.NodeType == System.Xml.XmlNodeType.Whitespace || 
                Reader.NodeType == System.Xml.XmlNodeType.SignificantWhitespace) {
                    tmp = ReadString(tmp, false);
                    o.@Content = tmp;
                }
                else {
                    UnknownNode((object)o, @"http://www.w3.org/2001/06/grammar:item, http://www.w3.org/2001/06/grammar:ruleref, http://www.w3.org/2001/06/grammar:tag, http://www.w3.org/2001/06/grammar:token, http://www.w3.org/2001/06/grammar:one-of");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations4, ref readerCount4);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Srgs.Token Read29_Token(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id30_Token && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id4_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Srgs.Token o;
            o = new global::Resco.InAppSpeechRecognition.Srgs.Token();
            bool[] paramsRead = new bool[3];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id31_display && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Display = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id32_pron && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Pronunciation = Reader.Value;
                    paramsRead[1] = true;
                }
                else if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o, @":display, :pron");
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations5 = 0;
            int readerCount5 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                string tmp = null;
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)o, @"");
                }
                else if (Reader.NodeType == System.Xml.XmlNodeType.Text || 
                Reader.NodeType == System.Xml.XmlNodeType.CDATA || 
                Reader.NodeType == System.Xml.XmlNodeType.Whitespace || 
                Reader.NodeType == System.Xml.XmlNodeType.SignificantWhitespace) {
                    tmp = ReadString(tmp, false);
                    o.@Text = tmp;
                }
                else {
                    UnknownNode((object)o, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations5, ref readerCount5);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Srgs.Tag Read28_Tag(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id33_Tag && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id4_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Srgs.Tag o;
            o = new global::Resco.InAppSpeechRecognition.Srgs.Tag();
            bool[] paramsRead = new bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations6 = 0;
            int readerCount6 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                string tmp = null;
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)o, @"");
                }
                else if (Reader.NodeType == System.Xml.XmlNodeType.Text || 
                Reader.NodeType == System.Xml.XmlNodeType.CDATA || 
                Reader.NodeType == System.Xml.XmlNodeType.Whitespace || 
                Reader.NodeType == System.Xml.XmlNodeType.SignificantWhitespace) {
                    tmp = ReadString(tmp, false);
                    o.@Content = tmp;
                }
                else {
                    UnknownNode((object)o, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations6, ref readerCount6);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Srgs.RuleRef Read27_RuleRef(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id34_RuleRef && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id4_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Srgs.RuleRef o;
            o = new global::Resco.InAppSpeechRecognition.Srgs.RuleRef();
            bool[] paramsRead = new bool[3];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id35_uri && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Uri = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id36_special && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Special = Reader.Value;
                    paramsRead[1] = true;
                }
                else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id37_type && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Type = Reader.Value;
                    paramsRead[2] = true;
                }
                else if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o, @":uri, :special, :type");
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations7 = 0;
            int readerCount7 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)o, @"");
                }
                else {
                    UnknownNode((object)o, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations7, ref readerCount7);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Srgs.Example Read32_Example(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id38_Example && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id4_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Srgs.Example o;
            o = new global::Resco.InAppSpeechRecognition.Srgs.Example();
            bool[] paramsRead = new bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations8 = 0;
            int readerCount8 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                string tmp = null;
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)o, @"");
                }
                else if (Reader.NodeType == System.Xml.XmlNodeType.Text || 
                Reader.NodeType == System.Xml.XmlNodeType.CDATA || 
                Reader.NodeType == System.Xml.XmlNodeType.Whitespace || 
                Reader.NodeType == System.Xml.XmlNodeType.SignificantWhitespace) {
                    tmp = ReadString(tmp, false);
                    o.@Text = tmp;
                }
                else {
                    UnknownNode((object)o, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations8, ref readerCount8);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Srgs.Metadata Read25_Metadata(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id15_Metadata && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id4_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Srgs.Metadata o;
            o = new global::Resco.InAppSpeechRecognition.Srgs.Metadata();
            bool[] paramsRead = new bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations9 = 0;
            int readerCount9 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id39_RDF && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                        o.@Content = Read24_RDF(false, true, defaultNamespace);
                        paramsRead[0] = true;
                    }
                    else {
                        UnknownNode((object)o, @"http://www.w3.org/2001/06/grammar:RDF");
                    }
                }
                else {
                    UnknownNode((object)o, @"http://www.w3.org/2001/06/grammar:RDF");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations9, ref readerCount9);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Srgs.RDF Read24_RDF(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id39_RDF && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id4_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Srgs.RDF o;
            o = new global::Resco.InAppSpeechRecognition.Srgs.RDF();
            bool[] paramsRead = new bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations10 = 0;
            int readerCount10 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id40_Description && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id41_Item))) {
                        o.@Description = Read23_Description(false, true, defaultNamespace);
                        paramsRead[0] = true;
                    }
                    else {
                        UnknownNode((object)o, @"http://www.w3.org/1999/02/22-rdf-syntax-ns#:Description");
                    }
                }
                else {
                    UnknownNode((object)o, @"http://www.w3.org/1999/02/22-rdf-syntax-ns#:Description");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations10, ref readerCount10);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Srgs.Description Read23_Description(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id40_Description && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id41_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Srgs.Description o;
            o = new global::Resco.InAppSpeechRecognition.Srgs.Description();
            bool[] paramsRead = new bool[9];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id42_about && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@About = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id43_Title && string.Equals(Reader.NamespaceURI, id44_Item))) {
                    o.@Title = Reader.Value;
                    paramsRead[1] = true;
                }
                else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id40_Description && string.Equals(Reader.NamespaceURI, id44_Item))) {
                    o.@Descript = Reader.Value;
                    paramsRead[2] = true;
                }
                else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id45_Publisher && string.Equals(Reader.NamespaceURI, id44_Item))) {
                    o.@Publisher = Reader.Value;
                    paramsRead[3] = true;
                }
                else if (!paramsRead[4] && ((object) Reader.LocalName == (object)id46_Language && string.Equals(Reader.NamespaceURI, id44_Item))) {
                    o.@Language = Reader.Value;
                    paramsRead[4] = true;
                }
                else if (!paramsRead[5] && ((object) Reader.LocalName == (object)id47_Date && string.Equals(Reader.NamespaceURI, id44_Item))) {
                    o.@Date = ToDateTime(Reader.Value);
                    paramsRead[5] = true;
                }
                else if (!paramsRead[6] && ((object) Reader.LocalName == (object)id48_Rights && string.Equals(Reader.NamespaceURI, id44_Item))) {
                    o.@Rights = Reader.Value;
                    paramsRead[6] = true;
                }
                else if (!paramsRead[7] && ((object) Reader.LocalName == (object)id49_Format && string.Equals(Reader.NamespaceURI, id44_Item))) {
                    o.@Format = Reader.Value;
                    paramsRead[7] = true;
                }
                else if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o, @":about, http://purl.org/metadata/dublin_core#:Title, http://purl.org/metadata/dublin_core#:Description, http://purl.org/metadata/dublin_core#:Publisher, http://purl.org/metadata/dublin_core#:Language, http://purl.org/metadata/dublin_core#:Date, http://purl.org/metadata/dublin_core#:Rights, http://purl.org/metadata/dublin_core#:Format");
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations11 = 0;
            int readerCount11 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[8] && ((object) Reader.LocalName == (object)id50_Creator && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id44_Item))) {
                        o.@Creators = Read22_Creator(false, true, defaultNamespace);
                        paramsRead[8] = true;
                    }
                    else {
                        UnknownNode((object)o, @"http://purl.org/metadata/dublin_core#:Creator");
                    }
                }
                else {
                    UnknownNode((object)o, @"http://purl.org/metadata/dublin_core#:Creator");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations11, ref readerCount11);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Srgs.Creator Read22_Creator(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id50_Creator && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id44_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Srgs.Creator o;
            o = new global::Resco.InAppSpeechRecognition.Srgs.Creator();
            bool[] paramsRead = new bool[0];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations12 = 0;
            int readerCount12 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)o, @"");
                }
                else {
                    UnknownNode((object)o, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations12, ref readerCount12);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Commands.VoiceCommands Read21_VoiceCommands(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id1_VoiceCommands && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Commands.VoiceCommands o;
            o = new global::Resco.InAppSpeechRecognition.Commands.VoiceCommands();
            global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.CommandSet> a_0 = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.CommandSet>)o.@CommandSets;
            bool[] paramsRead = new bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations13 = 0;
            int readerCount13 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (((object) Reader.LocalName == (object)id51_CommandSet && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        if ((object)(a_0) == null) Reader.Skip(); else a_0.Add(Read20_CommandSet(false, true, defaultNamespace));
                    }
                    else {
                        UnknownNode((object)o, @"http://schemas.microsoft.com/voicecommands/1.2:CommandSet");
                    }
                }
                else {
                    UnknownNode((object)o, @"http://schemas.microsoft.com/voicecommands/1.2:CommandSet");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations13, ref readerCount13);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Commands.CommandSet Read20_CommandSet(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id51_CommandSet && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Commands.CommandSet o;
            o = new global::Resco.InAppSpeechRecognition.Commands.CommandSet();
            global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.Command> a_2 = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.Command>)o.@Commands;
            global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.PhraseList> a_3 = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.PhraseList>)o.@PhraseLists;
            global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.PhraseTopic> a_4 = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.PhraseTopic>)o.@PhraseTopics;
            bool[] paramsRead = new bool[7];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[5] && ((object) Reader.LocalName == (object)id9_lang && string.Equals(Reader.NamespaceURI, id10_Item))) {
                    o.@Language = Reader.Value;
                    paramsRead[5] = true;
                }
                else if (!paramsRead[6] && ((object) Reader.LocalName == (object)id52_Name && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Name = Reader.Value;
                    paramsRead[6] = true;
                }
                else if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o, @"http://www.w3.org/XML/1998/namespace, :Name");
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            int state = 0;
            Reader.MoveToContent();
            int whileIterations14 = 0;
            int readerCount14 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    switch (state) {
                    case 0:
                        if (((object) Reader.LocalName == (object)id53_CommandPrefix && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            o.@Prefix = Read3_CommandPrefix(false, true, defaultNamespace);
                        }
                        else if (((object) Reader.LocalName == (object)id54_AppName && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            o.@Prefix = Read4_AppName(false, true, defaultNamespace);
                        }
                        state = 1;
                        break;
                    case 1:
                        if (((object) Reader.LocalName == (object)id38_Example && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            {
                                o.@Example = Reader.ReadElementContentAsString();
                            }
                        }
                        state = 2;
                        break;
                    case 2:
                        if (((object) Reader.LocalName == (object)id55_Command && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            if ((object)(a_2) == null) Reader.Skip(); else a_2.Add(Read13_Command(false, true, defaultNamespace));
                        }
                        else {
                            state = 3;
                        }
                        break;
                    case 3:
                        if (((object) Reader.LocalName == (object)id56_PhraseList && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            if ((object)(a_3) == null) Reader.Skip(); else a_3.Add(Read16_PhraseList(false, true, defaultNamespace));
                        }
                        else {
                            state = 4;
                        }
                        break;
                    case 4:
                        if (((object) Reader.LocalName == (object)id57_PhraseTopic && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            if ((object)(a_4) == null) Reader.Skip(); else a_4.Add(Read19_PhraseTopic(false, true, defaultNamespace));
                        }
                        else {
                            state = 5;
                        }
                        break;
                    default:
                        UnknownNode((object)o, null);
                        break;
                    }
                }
                else {
                    UnknownNode((object)o, null);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations14, ref readerCount14);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Commands.PhraseTopic Read19_PhraseTopic(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id57_PhraseTopic && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Commands.PhraseTopic o;
            o = new global::Resco.InAppSpeechRecognition.Commands.PhraseTopic();
            global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.Subjects> a_2 = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.Subjects>)o.@Subjects;
            bool[] paramsRead = new bool[3];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id58_Label && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Label = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id59_Scenario && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Scenario = Read17_Scenario(Reader.Value);
                    paramsRead[1] = true;
                }
                else if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o, @":Label, :Scenario");
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations15 = 0;
            int readerCount15 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (((object) Reader.LocalName == (object)id60_Subject && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            a_2.Add(Read18_Subjects(Reader.ReadElementContentAsString()));
                        }
                    }
                    else {
                        UnknownNode((object)o, @"http://schemas.microsoft.com/voicecommands/1.2:Subject");
                    }
                }
                else {
                    UnknownNode((object)o, @"http://schemas.microsoft.com/voicecommands/1.2:Subject");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations15, ref readerCount15);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Commands.Subjects Read18_Subjects(string s) {
            switch (s) {
                case @"Date/Time": return global::Resco.InAppSpeechRecognition.Commands.Subjects.@DateTime;
                case @"Addresses": return global::Resco.InAppSpeechRecognition.Commands.Subjects.@Addresses;
                case @"City/State": return global::Resco.InAppSpeechRecognition.Commands.Subjects.@CityState;
                case @"Person Names": return global::Resco.InAppSpeechRecognition.Commands.Subjects.@PersonNames;
                case @"Movies": return global::Resco.InAppSpeechRecognition.Commands.Subjects.@Movies;
                case @"Music": return global::Resco.InAppSpeechRecognition.Commands.Subjects.@Music;
                case @"Phone Number": return global::Resco.InAppSpeechRecognition.Commands.Subjects.@PhoneNumber;
                default: throw CreateUnknownConstantException(s, typeof(global::Resco.InAppSpeechRecognition.Commands.Subjects));
            }
        }

        global::Resco.InAppSpeechRecognition.Commands.Scenario Read17_Scenario(string s) {
            switch (s) {
                case @"Natural Language": return global::Resco.InAppSpeechRecognition.Commands.Scenario.@NaturalLanguage;
                case @"Search": return global::Resco.InAppSpeechRecognition.Commands.Scenario.@Search;
                case @"Short Message": return global::Resco.InAppSpeechRecognition.Commands.Scenario.@ShortMessage;
                case @"Dictation": return global::Resco.InAppSpeechRecognition.Commands.Scenario.@Dictation;
                case @"Commands": return global::Resco.InAppSpeechRecognition.Commands.Scenario.@Commands;
                case @"Form Filling": return global::Resco.InAppSpeechRecognition.Commands.Scenario.@FormFilling;
                default: throw CreateUnknownConstantException(s, typeof(global::Resco.InAppSpeechRecognition.Commands.Scenario));
            }
        }

        global::Resco.InAppSpeechRecognition.Commands.PhraseList Read16_PhraseList(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id56_PhraseList && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Commands.PhraseList o;
            o = new global::Resco.InAppSpeechRecognition.Commands.PhraseList();
            global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.ListItem> a_2 = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.ListItem>)o.@Items;
            bool[] paramsRead = new bool[3];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id58_Label && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Label = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id61_Disambiguate && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Disambiguate = System.Xml.XmlConvert.ToBoolean(Reader.Value);
                    paramsRead[1] = true;
                }
                else if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o, @":Label, :Disambiguate");
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations16 = 0;
            int readerCount16 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (((object) Reader.LocalName == (object)id27_Item && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        if ((object)(a_2) == null) Reader.Skip(); else a_2.Add(Read15_ListItem(false, true, defaultNamespace));
                    }
                    else {
                        UnknownNode((object)o, @"http://schemas.microsoft.com/voicecommands/1.2:Item");
                    }
                }
                else {
                    UnknownNode((object)o, @"http://schemas.microsoft.com/voicecommands/1.2:Item");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations16, ref readerCount16);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Commands.ListItem Read15_ListItem(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id62_ListItem && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Commands.ListItem o;
            o = new global::Resco.InAppSpeechRecognition.Commands.ListItem();
            bool[] paramsRead = new bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id63_Display && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Display = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o, @":Display");
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations17 = 0;
            int readerCount17 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                string tmp = null;
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)o, @"");
                }
                else if (Reader.NodeType == System.Xml.XmlNodeType.Text || 
                Reader.NodeType == System.Xml.XmlNodeType.CDATA || 
                Reader.NodeType == System.Xml.XmlNodeType.Whitespace || 
                Reader.NodeType == System.Xml.XmlNodeType.SignificantWhitespace) {
                    tmp = ReadString(tmp, false);
                    o.@Content = tmp;
                }
                else {
                    UnknownNode((object)o, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations17, ref readerCount17);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Commands.Command Read13_Command(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id55_Command && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Commands.Command o;
            o = new global::Resco.InAppSpeechRecognition.Commands.Command();
            global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.ListenFor> a_1 = (global::System.Collections.Generic.List<global::Resco.InAppSpeechRecognition.Commands.ListenFor>)o.@ListenFor;
            bool[] paramsRead = new bool[5];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[4] && ((object) Reader.LocalName == (object)id52_Name && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Name = Reader.Value;
                    paramsRead[4] = true;
                }
                else if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o, @":Name");
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            int state = 0;
            Reader.MoveToContent();
            int whileIterations18 = 0;
            int readerCount18 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    switch (state) {
                    case 0:
                        if (((object) Reader.LocalName == (object)id38_Example && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            {
                                o.@Example = Reader.ReadElementContentAsString();
                            }
                        }
                        state = 1;
                        break;
                    case 1:
                        if (((object) Reader.LocalName == (object)id64_ListenFor && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            if ((object)(a_1) == null) Reader.Skip(); else a_1.Add(Read6_ListenFor(false, true, defaultNamespace));
                        }
                        else {
                            state = 2;
                        }
                        break;
                    case 2:
                        if (((object) Reader.LocalName == (object)id65_Feedback && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            o.@Feedback = Read7_Feedback(false, true, defaultNamespace);
                        }
                        state = 3;
                        break;
                    case 3:
                        if (((object) Reader.LocalName == (object)id66_Navigate && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            o.@VoiceAction = Read9_Navigate(false, true, defaultNamespace);
                        }
                        else if (((object) Reader.LocalName == (object)id67_VoiceCommandService && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            o.@VoiceAction = Read10_VoiceCommandService(false, true, defaultNamespace);
                        }
                        else if (((object) Reader.LocalName == (object)id68_ShowDialog && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            o.@VoiceAction = Read11_ShowDialog(false, true, defaultNamespace);
                        }
                        else if (((object) Reader.LocalName == (object)id69_CustomAction && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            o.@VoiceAction = Read12_CustomAction(false, true, defaultNamespace);
                        }
                        state = 4;
                        break;
                    default:
                        UnknownNode((object)o, null);
                        break;
                    }
                }
                else {
                    UnknownNode((object)o, null);
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations18, ref readerCount18);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Commands.CustomAction Read12_CustomAction(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id69_CustomAction && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Commands.CustomAction o;
            o = new global::Resco.InAppSpeechRecognition.Commands.CustomAction();
            bool[] paramsRead = new bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id70_Parameter && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@ActionParameter = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o, @":Parameter");
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations19 = 0;
            int readerCount19 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                string tmp = null;
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)o, @"");
                }
                else if (Reader.NodeType == System.Xml.XmlNodeType.Text || 
                Reader.NodeType == System.Xml.XmlNodeType.CDATA || 
                Reader.NodeType == System.Xml.XmlNodeType.Whitespace || 
                Reader.NodeType == System.Xml.XmlNodeType.SignificantWhitespace) {
                    tmp = ReadString(tmp, false);
                    o.@ActionContent = tmp;
                }
                else {
                    UnknownNode((object)o, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations19, ref readerCount19);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Commands.ShowDialog Read11_ShowDialog(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id68_ShowDialog && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Commands.ShowDialog o;
            o = new global::Resco.InAppSpeechRecognition.Commands.ShowDialog();
            bool[] paramsRead = new bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id71_TextToDisplay && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@TextToDisplay = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o, @":TextToDisplay");
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations20 = 0;
            int readerCount20 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)o, @"");
                }
                else {
                    UnknownNode((object)o, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations20, ref readerCount20);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Commands.VoiceCommandService Read10_VoiceCommandService(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id67_VoiceCommandService && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Commands.VoiceCommandService o;
            o = new global::Resco.InAppSpeechRecognition.Commands.VoiceCommandService();
            bool[] paramsRead = new bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id72_Target && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Target = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o, @":Target");
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations21 = 0;
            int readerCount21 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)o, @"");
                }
                else {
                    UnknownNode((object)o, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations21, ref readerCount21);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Commands.Navigate Read9_Navigate(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id66_Navigate && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Commands.Navigate o;
            o = new global::Resco.InAppSpeechRecognition.Commands.Navigate();
            bool[] paramsRead = new bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id73_NavigationParameter && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@NavigationParameter = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id72_Target && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Target = Reader.Value;
                    paramsRead[1] = true;
                }
                else if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o, @":NavigationParameter, :Target");
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations22 = 0;
            int readerCount22 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)o, @"");
                }
                else {
                    UnknownNode((object)o, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations22, ref readerCount22);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Commands.Feedback Read7_Feedback(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id65_Feedback && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Commands.Feedback o;
            o = new global::Resco.InAppSpeechRecognition.Commands.Feedback();
            bool[] paramsRead = new bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations23 = 0;
            int readerCount23 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                string tmp = null;
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)o, @"");
                }
                else if (Reader.NodeType == System.Xml.XmlNodeType.Text || 
                Reader.NodeType == System.Xml.XmlNodeType.CDATA || 
                Reader.NodeType == System.Xml.XmlNodeType.Whitespace || 
                Reader.NodeType == System.Xml.XmlNodeType.SignificantWhitespace) {
                    tmp = ReadString(tmp, false);
                    o.@Content = tmp;
                }
                else {
                    UnknownNode((object)o, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations23, ref readerCount23);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Commands.ListenFor Read6_ListenFor(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id64_ListenFor && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Commands.ListenFor o;
            o = new global::Resco.InAppSpeechRecognition.Commands.ListenFor();
            bool[] paramsRead = new bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[1] && ((object) Reader.LocalName == (object)id74_RequireAppName && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@RequireAppName = Read5_AppNameRequirement(Reader.Value);
                    paramsRead[1] = true;
                }
                else if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o, @":RequireAppName");
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations24 = 0;
            int readerCount24 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                string tmp = null;
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)o, @"");
                }
                else if (Reader.NodeType == System.Xml.XmlNodeType.Text || 
                Reader.NodeType == System.Xml.XmlNodeType.CDATA || 
                Reader.NodeType == System.Xml.XmlNodeType.Whitespace || 
                Reader.NodeType == System.Xml.XmlNodeType.SignificantWhitespace) {
                    tmp = ReadString(tmp, false);
                    o.@Content = tmp;
                }
                else {
                    UnknownNode((object)o, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations24, ref readerCount24);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Commands.AppNameRequirement Read5_AppNameRequirement(string s) {
            switch (s) {
                case @"BeforePhrase": return global::Resco.InAppSpeechRecognition.Commands.AppNameRequirement.@BeforePhrase;
                case @"AfterPhrase": return global::Resco.InAppSpeechRecognition.Commands.AppNameRequirement.@AfterPhrase;
                case @"BeforeOrAfterPhrase": return global::Resco.InAppSpeechRecognition.Commands.AppNameRequirement.@BeforeOrAfterPhrase;
                case @"ExplicitlySpecified": return global::Resco.InAppSpeechRecognition.Commands.AppNameRequirement.@ExplicitlySpecified;
                default: throw CreateUnknownConstantException(s, typeof(global::Resco.InAppSpeechRecognition.Commands.AppNameRequirement));
            }
        }

        global::Resco.InAppSpeechRecognition.Commands.AppName Read4_AppName(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id54_AppName && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Commands.AppName o;
            o = new global::Resco.InAppSpeechRecognition.Commands.AppName();
            bool[] paramsRead = new bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations25 = 0;
            int readerCount25 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                string tmp = null;
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)o, @"");
                }
                else if (Reader.NodeType == System.Xml.XmlNodeType.Text || 
                Reader.NodeType == System.Xml.XmlNodeType.CDATA || 
                Reader.NodeType == System.Xml.XmlNodeType.Whitespace || 
                Reader.NodeType == System.Xml.XmlNodeType.SignificantWhitespace) {
                    tmp = ReadString(tmp, false);
                    o.@Content = tmp;
                }
                else {
                    UnknownNode((object)o, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations25, ref readerCount25);
            }
            ReadEndElement();
            return o;
        }

        global::Resco.InAppSpeechRecognition.Commands.CommandPrefix Read3_CommandPrefix(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id53_CommandPrefix && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Resco.InAppSpeechRecognition.Commands.CommandPrefix o;
            o = new global::Resco.InAppSpeechRecognition.Commands.CommandPrefix();
            bool[] paramsRead = new bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations26 = 0;
            int readerCount26 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                string tmp = null;
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)o, @"");
                }
                else if (Reader.NodeType == System.Xml.XmlNodeType.Text || 
                Reader.NodeType == System.Xml.XmlNodeType.CDATA || 
                Reader.NodeType == System.Xml.XmlNodeType.Whitespace || 
                Reader.NodeType == System.Xml.XmlNodeType.SignificantWhitespace) {
                    tmp = ReadString(tmp, false);
                    o.@Content = tmp;
                }
                else {
                    UnknownNode((object)o, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations26, ref readerCount26);
            }
            ReadEndElement();
            return o;
        }

        protected override void InitCallbacks() {
        }

        string id42_about;
        string id19_id;
        string id40_Description;
        string id35_uri;
        string id13_version;
        string id60_Subject;
        string id54_AppName;
        string id69_CustomAction;
        string id28_weight;
        string id26_OneOf;
        string id47_Date;
        string id39_RDF;
        string id65_Feedback;
        string id20_example;
        string id9_lang;
        string id2_Item;
        string id45_Publisher;
        string id22_ruleref;
        string id34_RuleRef;
        string id6_Item;
        string id55_Command;
        string id21_item;
        string id73_NavigationParameter;
        string id11_tagformat;
        string id68_ShowDialog;
        string id59_Scenario;
        string id74_RequireAppName;
        string id61_Disambiguate;
        string id62_ListItem;
        string id51_CommandSet;
        string id70_Parameter;
        string id12_root;
        string id18_scope;
        string id57_PhraseTopic;
        string id33_Tag;
        string id7_FirstLaunch;
        string id63_Display;
        string id10_Item;
        string id27_Item;
        string id72_Target;
        string id31_display;
        string id36_special;
        string id1_VoiceCommands;
        string id66_Navigate;
        string id49_Format;
        string id48_Rights;
        string id5_AppSettings;
        string id23_tag;
        string id53_CommandPrefix;
        string id4_Item;
        string id15_Metadata;
        string id71_TextToDisplay;
        string id30_Token;
        string id14_mode;
        string id52_Name;
        string id8_Grammar;
        string id17_Rule;
        string id24_token;
        string id3_grammar;
        string id56_PhraseList;
        string id37_type;
        string id43_Title;
        string id29_repeat;
        string id58_Label;
        string id64_ListenFor;
        string id44_Item;
        string id38_Example;
        string id46_Language;
        string id50_Creator;
        string id67_VoiceCommandService;
        string id16_rule;
        string id41_Item;
        string id32_pron;
        string id25_oneof;

        protected override void InitIDs() {
            id42_about = Reader.NameTable.Add(@"about");
            id19_id = Reader.NameTable.Add(@"id");
            id40_Description = Reader.NameTable.Add(@"Description");
            id35_uri = Reader.NameTable.Add(@"uri");
            id13_version = Reader.NameTable.Add(@"version");
            id60_Subject = Reader.NameTable.Add(@"Subject");
            id54_AppName = Reader.NameTable.Add(@"AppName");
            id69_CustomAction = Reader.NameTable.Add(@"CustomAction");
            id28_weight = Reader.NameTable.Add(@"weight");
            id26_OneOf = Reader.NameTable.Add(@"OneOf");
            id47_Date = Reader.NameTable.Add(@"Date");
            id39_RDF = Reader.NameTable.Add(@"RDF");
            id65_Feedback = Reader.NameTable.Add(@"Feedback");
            id20_example = Reader.NameTable.Add(@"example");
            id9_lang = Reader.NameTable.Add(@"lang");
            id2_Item = Reader.NameTable.Add(@"http://schemas.microsoft.com/voicecommands/1.2");
            id45_Publisher = Reader.NameTable.Add(@"Publisher");
            id22_ruleref = Reader.NameTable.Add(@"ruleref");
            id34_RuleRef = Reader.NameTable.Add(@"RuleRef");
            id6_Item = Reader.NameTable.Add(@"");
            id55_Command = Reader.NameTable.Add(@"Command");
            id21_item = Reader.NameTable.Add(@"item");
            id73_NavigationParameter = Reader.NameTable.Add(@"NavigationParameter");
            id11_tagformat = Reader.NameTable.Add(@"tag-format");
            id68_ShowDialog = Reader.NameTable.Add(@"ShowDialog");
            id59_Scenario = Reader.NameTable.Add(@"Scenario");
            id74_RequireAppName = Reader.NameTable.Add(@"RequireAppName");
            id61_Disambiguate = Reader.NameTable.Add(@"Disambiguate");
            id62_ListItem = Reader.NameTable.Add(@"ListItem");
            id51_CommandSet = Reader.NameTable.Add(@"CommandSet");
            id70_Parameter = Reader.NameTable.Add(@"Parameter");
            id12_root = Reader.NameTable.Add(@"root");
            id18_scope = Reader.NameTable.Add(@"scope");
            id57_PhraseTopic = Reader.NameTable.Add(@"PhraseTopic");
            id33_Tag = Reader.NameTable.Add(@"Tag");
            id7_FirstLaunch = Reader.NameTable.Add(@"FirstLaunch");
            id63_Display = Reader.NameTable.Add(@"Display");
            id10_Item = Reader.NameTable.Add(@"http://www.w3.org/XML/1998/namespace");
            id27_Item = Reader.NameTable.Add(@"Item");
            id72_Target = Reader.NameTable.Add(@"Target");
            id31_display = Reader.NameTable.Add(@"display");
            id36_special = Reader.NameTable.Add(@"special");
            id1_VoiceCommands = Reader.NameTable.Add(@"VoiceCommands");
            id66_Navigate = Reader.NameTable.Add(@"Navigate");
            id49_Format = Reader.NameTable.Add(@"Format");
            id48_Rights = Reader.NameTable.Add(@"Rights");
            id5_AppSettings = Reader.NameTable.Add(@"AppSettings");
            id23_tag = Reader.NameTable.Add(@"tag");
            id53_CommandPrefix = Reader.NameTable.Add(@"CommandPrefix");
            id4_Item = Reader.NameTable.Add(@"http://www.w3.org/2001/06/grammar");
            id15_Metadata = Reader.NameTable.Add(@"Metadata");
            id71_TextToDisplay = Reader.NameTable.Add(@"TextToDisplay");
            id30_Token = Reader.NameTable.Add(@"Token");
            id14_mode = Reader.NameTable.Add(@"mode");
            id52_Name = Reader.NameTable.Add(@"Name");
            id8_Grammar = Reader.NameTable.Add(@"Grammar");
            id17_Rule = Reader.NameTable.Add(@"Rule");
            id24_token = Reader.NameTable.Add(@"token");
            id3_grammar = Reader.NameTable.Add(@"grammar");
            id56_PhraseList = Reader.NameTable.Add(@"PhraseList");
            id37_type = Reader.NameTable.Add(@"type");
            id43_Title = Reader.NameTable.Add(@"Title");
            id29_repeat = Reader.NameTable.Add(@"repeat");
            id58_Label = Reader.NameTable.Add(@"Label");
            id64_ListenFor = Reader.NameTable.Add(@"ListenFor");
            id44_Item = Reader.NameTable.Add(@"http://purl.org/metadata/dublin_core#");
            id38_Example = Reader.NameTable.Add(@"Example");
            id46_Language = Reader.NameTable.Add(@"Language");
            id50_Creator = Reader.NameTable.Add(@"Creator");
            id67_VoiceCommandService = Reader.NameTable.Add(@"VoiceCommandService");
            id16_rule = Reader.NameTable.Add(@"rule");
            id41_Item = Reader.NameTable.Add(@"http://www.w3.org/1999/02/22-rdf-syntax-ns#");
            id32_pron = Reader.NameTable.Add(@"pron");
            id25_oneof = Reader.NameTable.Add(@"one-of");
        }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public abstract class XmlSerializer1 : System.Xml.Serialization.XmlSerializer {
        protected override System.Xml.Serialization.XmlSerializationReader CreateReader() {
            return new XmlSerializationReader1();
        }
        protected override System.Xml.Serialization.XmlSerializationWriter CreateWriter() {
            return new XmlSerializationWriter1();
        }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public sealed class VoiceCommandsSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"VoiceCommands", this.DefaultNamespace ?? @"http://schemas.microsoft.com/voicecommands/1.2");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write36_VoiceCommands(objectToSerialize, this.DefaultNamespace, @"http://schemas.microsoft.com/voicecommands/1.2");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read36_VoiceCommands(this.DefaultNamespace);
        }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public sealed class GrammarSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"grammar", this.DefaultNamespace ?? @"http://www.w3.org/2001/06/grammar");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write37_grammar(objectToSerialize, this.DefaultNamespace, @"http://www.w3.org/2001/06/grammar");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read37_grammar(this.DefaultNamespace);
        }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public sealed class AppSettingsSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"AppSettings", this.DefaultNamespace ?? @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write38_AppSettings(objectToSerialize, this.DefaultNamespace, @"");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read38_AppSettings(this.DefaultNamespace);
        }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public class XmlSerializerContract : global::System.Xml.Serialization.XmlSerializerImplementation {
        public override global::System.Xml.Serialization.XmlSerializationReader Reader { get { return new XmlSerializationReader1(); } }
        public override global::System.Xml.Serialization.XmlSerializationWriter Writer { get { return new XmlSerializationWriter1(); } }
        System.Collections.IDictionary readMethods = null;
        public override System.Collections.IDictionary ReadMethods {
            get {
                if (readMethods == null) {
                    System.Collections.IDictionary _tmp = new System.Collections.Generic.Dictionary<string, string>();
                    _tmp[@"Resco.InAppSpeechRecognition.Commands.VoiceCommands:http://schemas.microsoft.com/voicecommands/1.2:VoiceCommands:True:"] = @"Read36_VoiceCommands";
                    _tmp[@"Resco.InAppSpeechRecognition.Srgs.Grammar:http://www.w3.org/2001/06/grammar:grammar:True:"] = @"Read37_grammar";
                    _tmp[@"PiStudio.Shared.Data.AppSettings::"] = @"Read38_AppSettings";
                    if (readMethods == null) readMethods = _tmp;
                }
                return readMethods;
            }
        }
        System.Collections.IDictionary writeMethods = null;
        public override System.Collections.IDictionary WriteMethods {
            get {
                if (writeMethods == null) {
                    System.Collections.IDictionary _tmp = new System.Collections.Generic.Dictionary<string, string>();
                    _tmp[@"Resco.InAppSpeechRecognition.Commands.VoiceCommands:http://schemas.microsoft.com/voicecommands/1.2:VoiceCommands:True:"] = @"Write36_VoiceCommands";
                    _tmp[@"Resco.InAppSpeechRecognition.Srgs.Grammar:http://www.w3.org/2001/06/grammar:grammar:True:"] = @"Write37_grammar";
                    _tmp[@"PiStudio.Shared.Data.AppSettings::"] = @"Write38_AppSettings";
                    if (writeMethods == null) writeMethods = _tmp;
                }
                return writeMethods;
            }
        }
        System.Collections.IDictionary typedSerializers = null;
        public override System.Collections.IDictionary TypedSerializers {
            get {
                if (typedSerializers == null) {
                    System.Collections.IDictionary _tmp = new System.Collections.Generic.Dictionary<string, System.Xml.Serialization.XmlSerializer>();
                    _tmp.Add(@"PiStudio.Shared.Data.AppSettings::", new AppSettingsSerializer());
                    _tmp.Add(@"Resco.InAppSpeechRecognition.Commands.VoiceCommands:http://schemas.microsoft.com/voicecommands/1.2:VoiceCommands:True:", new VoiceCommandsSerializer());
                    _tmp.Add(@"Resco.InAppSpeechRecognition.Srgs.Grammar:http://www.w3.org/2001/06/grammar:grammar:True:", new GrammarSerializer());
                    if (typedSerializers == null) typedSerializers = _tmp;
                }
                return typedSerializers;
            }
        }
        public override System.Boolean CanSerialize(System.Type type) {
            if (type == typeof(global::Resco.InAppSpeechRecognition.Commands.VoiceCommands)) return true;
            if (type == typeof(global::Resco.InAppSpeechRecognition.Srgs.Grammar)) return true;
            if (type == typeof(global::PiStudio.Shared.Data.AppSettings)) return true;
            if (type == typeof(global::System.Reflection.TypeInfo)) return true;
            return false;
        }
        public override System.Xml.Serialization.XmlSerializer GetSerializer(System.Type type) {
            if (type == typeof(global::Resco.InAppSpeechRecognition.Commands.VoiceCommands)) return new VoiceCommandsSerializer();
            if (type == typeof(global::Resco.InAppSpeechRecognition.Srgs.Grammar)) return new GrammarSerializer();
            if (type == typeof(global::PiStudio.Shared.Data.AppSettings)) return new AppSettingsSerializer();
            return null;
        }
        public static global::System.Xml.Serialization.XmlSerializerImplementation GetXmlSerializerContract() { return new XmlSerializerContract(); }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public static class ActivatorHelper {
        public static object CreateInstance(System.Type type) {
            System.Reflection.TypeInfo ti = System.Reflection.IntrospectionExtensions.GetTypeInfo(type);
            foreach (System.Reflection.ConstructorInfo ci in ti.DeclaredConstructors) {
                if (!ci.IsStatic && ci.GetParameters().Length == 0) {
                    return ci.Invoke(null);
                }
            }
            return System.Activator.CreateInstance(type);
        }
    }
}
