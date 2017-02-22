namespace System.Runtime.CompilerServices {
    internal class __BlockReflectionAttribute : Attribute { }
}

namespace Microsoft.Xml.Serialization.GeneratedAssembly {


    [System.Runtime.CompilerServices.__BlockReflection]
    public class XmlSerializationWriter1 : System.Xml.Serialization.XmlSerializationWriter {

        public void Write37_VoiceCommands(object o, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs ?? @"http://schemas.microsoft.com/voicecommands/1.2";
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"VoiceCommands", defaultNamespace);
                return;
            }
            TopLevelElement();
            string namespace1 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
            Write21_VoiceCommands(@"VoiceCommands", namespace1, ((global::PiStudio.Win10.Voice.Commands.VoiceCommands)o), true, false, namespace1, @"http://schemas.microsoft.com/voicecommands/1.2");
        }

        public void Write38_grammar(object o, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs ?? @"http://www.w3.org/2001/06/grammar";
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"grammar", defaultNamespace);
                return;
            }
            TopLevelElement();
            string namespace2 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
            Write34_Grammar(@"grammar", namespace2, ((global::PiStudio.Win10.Voice.Srgs.Grammar)o), true, false, namespace2, @"http://www.w3.org/2001/06/grammar");
        }

        public void Write39_AppSettings(object o, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs ?? @"";
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"AppSettings", defaultNamespace);
                return;
            }
            TopLevelElement();
            string namespace3 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            Write36_AppSettings(@"AppSettings", namespace3, ((global::PiStudio.Shared.AppSettings)o), true, false, namespace3, @"");
        }

        void Write36_AppSettings(string n, string ns, global::PiStudio.Shared.AppSettings o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Shared.AppSettings)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"AppSettings", defaultNamespace);
            string namespace4 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            {
                global::System.Collections.Generic.HashSet<global::System.String> a = (global::System.Collections.Generic.HashSet<global::System.String>)((global::System.Collections.Generic.HashSet<global::System.String>)o.@SupportedImageTypes);
                if (a != null){
                    WriteStartElement(@"SupportedImageTypes", namespace4, null, false);
                    System.Collections.IEnumerator e = a.@GetEnumerator();
                    if (e != null)
                    while (e.MoveNext()) {
                        global::System.String ai = (global::System.String)e.Current;
                        string namespace5 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
                        WriteNullableStringLiteral(@"string", namespace5, ((global::System.String)ai));
                    }
                    WriteEndElement();
                }
            }
            string namespace6 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"FirstLaunch", namespace6, System.Xml.XmlConvert.ToString((global::System.Boolean)((global::System.Boolean)o.@FirstLaunch)));
            string namespace7 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"AppLanguage", namespace7, Write35_Language(((global::PiStudio.Shared.Data.Language)o.@AppLanguage)));
            string namespace8 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"AutoSave", namespace8, System.Xml.XmlConvert.ToString((global::System.Boolean)((global::System.Boolean)o.@AutoSave)));
            string namespace9 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"IsDarkTheme", namespace9, System.Xml.XmlConvert.ToString((global::System.Boolean)((global::System.Boolean)o.@IsDarkTheme)));
            string namespace10 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"IsPredefinedTheme", namespace10, System.Xml.XmlConvert.ToString((global::System.Boolean)((global::System.Boolean)o.@IsPredefinedTheme)));
            string namespace11 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"Foreground", namespace11, System.Xml.XmlConvert.ToString((global::System.UInt32)((global::System.UInt32)o.@Foreground)));
            string namespace12 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"Background", namespace12, System.Xml.XmlConvert.ToString((global::System.UInt32)((global::System.UInt32)o.@Background)));
            string namespace13 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"PanelBackground", namespace13, System.Xml.XmlConvert.ToString((global::System.UInt32)((global::System.UInt32)o.@PanelBackground)));
            string namespace14 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"Borders", namespace14, System.Xml.XmlConvert.ToString((global::System.UInt32)((global::System.UInt32)o.@Borders)));
            string namespace15 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"PanelForeground", namespace15, System.Xml.XmlConvert.ToString((global::System.UInt32)((global::System.UInt32)o.@PanelForeground)));
            string namespace16 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"PanelItemFocused", namespace16, System.Xml.XmlConvert.ToString((global::System.UInt32)((global::System.UInt32)o.@PanelItemFocused)));
            string namespace17 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"ClickableForeground", namespace17, System.Xml.XmlConvert.ToString((global::System.UInt32)((global::System.UInt32)o.@ClickableForeground)));
            string namespace18 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"UpperPanelBackground", namespace18, System.Xml.XmlConvert.ToString((global::System.UInt32)((global::System.UInt32)o.@UpperPanelBackground)));
            WriteEndElement(o);
        }

        string Write35_Language(global::PiStudio.Shared.Data.Language v) {
            string s = null;
            switch (v) {
                case global::PiStudio.Shared.Data.Language.@Slovensky: s = @"Slovensky"; break;
                case global::PiStudio.Shared.Data.Language.@English: s = @"English"; break;
                case global::PiStudio.Shared.Data.Language.@German: s = @"German"; break;
                default: throw CreateInvalidEnumValueException(((System.Int64)v).ToString(System.Globalization.CultureInfo.InvariantCulture), @"PiStudio.Shared.Data.Language");
            }
            return s;
        }

        void Write34_Grammar(string n, string ns, global::PiStudio.Win10.Voice.Srgs.Grammar o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Srgs.Grammar)) {
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
            string namespace19 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
            Write25_Metadata(@"Metadata", namespace19, ((global::PiStudio.Win10.Voice.Srgs.Metadata)o.@Metadata), false, false, namespace19, @"http://www.w3.org/2001/06/grammar");
            {
                global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Srgs.Rule> a = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Srgs.Rule>)o.@Rules;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace20 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                        Write33_Rule(@"rule", namespace20, ((global::PiStudio.Win10.Voice.Srgs.Rule)a[ia]), false, false, namespace20, @"http://www.w3.org/2001/06/grammar");
                    }
                }
            }
            WriteEndElement(o);
        }

        void Write33_Rule(string n, string ns, global::PiStudio.Win10.Voice.Srgs.Rule o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Srgs.Rule)) {
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
                global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Srgs.Example> a = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Srgs.Example>)o.@Examples;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace21 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                        Write32_Example(@"example", namespace21, ((global::PiStudio.Win10.Voice.Srgs.Example)a[ia]), false, false, namespace21, @"http://www.w3.org/2001/06/grammar");
                    }
                }
            }
            {
                global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Srgs.RuleItem> a = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Srgs.RuleItem>)o.@Elements;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        global::PiStudio.Win10.Voice.Srgs.RuleItem ai = (global::PiStudio.Win10.Voice.Srgs.RuleItem)a[ia];
                        if ((object)(ai) != null){
                            if (ai is global::PiStudio.Win10.Voice.Srgs.Token) {
                                string namespace22 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                                Write29_Token(@"token", namespace22, ((global::PiStudio.Win10.Voice.Srgs.Token)ai), false, false, namespace22, @"http://www.w3.org/2001/06/grammar");
                            }
                            else if (ai is global::PiStudio.Win10.Voice.Srgs.OneOf) {
                                string namespace23 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                                Write30_OneOf(@"one-of", namespace23, ((global::PiStudio.Win10.Voice.Srgs.OneOf)ai), false, false, namespace23, @"http://www.w3.org/2001/06/grammar");
                            }
                            else if (ai is global::PiStudio.Win10.Voice.Srgs.Tag) {
                                string namespace24 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                                Write28_Tag(@"tag", namespace24, ((global::PiStudio.Win10.Voice.Srgs.Tag)ai), false, false, namespace24, @"http://www.w3.org/2001/06/grammar");
                            }
                            else if (ai is global::PiStudio.Win10.Voice.Srgs.Item) {
                                string namespace25 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                                Write31_Item(@"item", namespace25, ((global::PiStudio.Win10.Voice.Srgs.Item)ai), false, false, namespace25, @"http://www.w3.org/2001/06/grammar");
                            }
                            else if (ai is global::PiStudio.Win10.Voice.Srgs.RuleRef) {
                                string namespace26 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                                Write27_RuleRef(@"ruleref", namespace26, ((global::PiStudio.Win10.Voice.Srgs.RuleRef)ai), false, false, namespace26, @"http://www.w3.org/2001/06/grammar");
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

        void Write27_RuleRef(string n, string ns, global::PiStudio.Win10.Voice.Srgs.RuleRef o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Srgs.RuleRef)) {
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

        void Write31_Item(string n, string ns, global::PiStudio.Win10.Voice.Srgs.Item o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Srgs.Item)) {
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
                global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Srgs.RuleItem> a = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Srgs.RuleItem>)o.@Elements;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        global::PiStudio.Win10.Voice.Srgs.RuleItem ai = (global::PiStudio.Win10.Voice.Srgs.RuleItem)a[ia];
                        if ((object)(ai) != null){
                            if (ai is global::PiStudio.Win10.Voice.Srgs.Token) {
                                string namespace27 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                                Write29_Token(@"token", namespace27, ((global::PiStudio.Win10.Voice.Srgs.Token)ai), false, false, namespace27, @"http://www.w3.org/2001/06/grammar");
                            }
                            else if (ai is global::PiStudio.Win10.Voice.Srgs.OneOf) {
                                string namespace28 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                                Write30_OneOf(@"one-of", namespace28, ((global::PiStudio.Win10.Voice.Srgs.OneOf)ai), false, false, namespace28, @"http://www.w3.org/2001/06/grammar");
                            }
                            else if (ai is global::PiStudio.Win10.Voice.Srgs.Tag) {
                                string namespace29 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                                Write28_Tag(@"tag", namespace29, ((global::PiStudio.Win10.Voice.Srgs.Tag)ai), false, false, namespace29, @"http://www.w3.org/2001/06/grammar");
                            }
                            else if (ai is global::PiStudio.Win10.Voice.Srgs.Item) {
                                string namespace30 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                                Write31_Item(@"item", namespace30, ((global::PiStudio.Win10.Voice.Srgs.Item)ai), false, false, namespace30, @"http://www.w3.org/2001/06/grammar");
                            }
                            else if (ai is global::PiStudio.Win10.Voice.Srgs.RuleRef) {
                                string namespace31 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                                Write27_RuleRef(@"ruleref", namespace31, ((global::PiStudio.Win10.Voice.Srgs.RuleRef)ai), false, false, namespace31, @"http://www.w3.org/2001/06/grammar");
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

        void Write28_Tag(string n, string ns, global::PiStudio.Win10.Voice.Srgs.Tag o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Srgs.Tag)) {
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

        void Write30_OneOf(string n, string ns, global::PiStudio.Win10.Voice.Srgs.OneOf o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Srgs.OneOf)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"OneOf", defaultNamespace);
            {
                global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Srgs.Item> a = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Srgs.Item>)o.@Items;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace32 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
                        Write31_Item(@"item", namespace32, ((global::PiStudio.Win10.Voice.Srgs.Item)a[ia]), false, false, namespace32, @"http://www.w3.org/2001/06/grammar");
                    }
                }
            }
            WriteEndElement(o);
        }

        void Write29_Token(string n, string ns, global::PiStudio.Win10.Voice.Srgs.Token o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Srgs.Token)) {
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

        void Write32_Example(string n, string ns, global::PiStudio.Win10.Voice.Srgs.Example o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Srgs.Example)) {
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

        void Write25_Metadata(string n, string ns, global::PiStudio.Win10.Voice.Srgs.Metadata o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Srgs.Metadata)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Metadata", defaultNamespace);
            string namespace33 = ( parentCompileTimeNs == @"http://www.w3.org/2001/06/grammar" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/2001/06/grammar";
            Write24_RDF(@"RDF", namespace33, ((global::PiStudio.Win10.Voice.Srgs.RDF)o.@Content), false, false, namespace33, @"http://www.w3.org/2001/06/grammar");
            WriteEndElement(o);
        }

        void Write24_RDF(string n, string ns, global::PiStudio.Win10.Voice.Srgs.RDF o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Srgs.RDF)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"RDF", defaultNamespace);
            string namespace34 = ( parentCompileTimeNs == @"http://www.w3.org/1999/02/22-rdf-syntax-ns#" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://www.w3.org/1999/02/22-rdf-syntax-ns#";
            Write23_Description(@"Description", namespace34, ((global::PiStudio.Win10.Voice.Srgs.Description)o.@Description), false, false, namespace34, @"http://www.w3.org/1999/02/22-rdf-syntax-ns#");
            WriteEndElement(o);
        }

        void Write23_Description(string n, string ns, global::PiStudio.Win10.Voice.Srgs.Description o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Srgs.Description)) {
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
            string namespace35 = ( parentCompileTimeNs == @"http://purl.org/metadata/dublin_core#" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://purl.org/metadata/dublin_core#";
            Write22_Creator(@"Creator", namespace35, ((global::PiStudio.Win10.Voice.Srgs.Creator)o.@Creators), false, false, namespace35, @"http://purl.org/metadata/dublin_core#");
            WriteEndElement(o);
        }

        void Write22_Creator(string n, string ns, global::PiStudio.Win10.Voice.Srgs.Creator o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Srgs.Creator)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Creator", defaultNamespace);
            WriteEndElement(o);
        }

        void Write21_VoiceCommands(string n, string ns, global::PiStudio.Win10.Voice.Commands.VoiceCommands o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Commands.VoiceCommands)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"VoiceCommands", defaultNamespace);
            {
                global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.CommandSet> a = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.CommandSet>)o.@CommandSets;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace36 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                        Write20_CommandSet(@"CommandSet", namespace36, ((global::PiStudio.Win10.Voice.Commands.CommandSet)a[ia]), false, false, namespace36, @"http://schemas.microsoft.com/voicecommands/1.2");
                    }
                }
            }
            WriteEndElement(o);
        }

        void Write20_CommandSet(string n, string ns, global::PiStudio.Win10.Voice.Commands.CommandSet o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Commands.CommandSet)) {
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
                if (o.@Prefix is global::PiStudio.Win10.Voice.Commands.AppName) {
                    string namespace37 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                    Write4_AppName(@"AppName", namespace37, ((global::PiStudio.Win10.Voice.Commands.AppName)o.@Prefix), false, false, namespace37, @"http://schemas.microsoft.com/voicecommands/1.2");
                }
                else if (o.@Prefix is global::PiStudio.Win10.Voice.Commands.CommandPrefix) {
                    string namespace38 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                    Write3_CommandPrefix(@"CommandPrefix", namespace38, ((global::PiStudio.Win10.Voice.Commands.CommandPrefix)o.@Prefix), false, false, namespace38, @"http://schemas.microsoft.com/voicecommands/1.2");
                }
                else  if ((object)(o.@Prefix) != null){
                    throw CreateUnknownTypeException(o.@Prefix);
                }
            }
            string namespace39 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
            WriteElementString(@"Example", namespace39, ((global::System.String)o.@Example));
            {
                global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.Command> a = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.Command>)o.@Commands;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace40 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                        Write13_Command(@"Command", namespace40, ((global::PiStudio.Win10.Voice.Commands.Command)a[ia]), false, false, namespace40, @"http://schemas.microsoft.com/voicecommands/1.2");
                    }
                }
            }
            {
                global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.PhraseList> a = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.PhraseList>)o.@PhraseLists;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace41 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                        Write16_PhraseList(@"PhraseList", namespace41, ((global::PiStudio.Win10.Voice.Commands.PhraseList)a[ia]), false, false, namespace41, @"http://schemas.microsoft.com/voicecommands/1.2");
                    }
                }
            }
            {
                global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.PhraseTopic> a = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.PhraseTopic>)o.@PhraseTopics;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace42 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                        Write19_PhraseTopic(@"PhraseTopic", namespace42, ((global::PiStudio.Win10.Voice.Commands.PhraseTopic)a[ia]), false, false, namespace42, @"http://schemas.microsoft.com/voicecommands/1.2");
                    }
                }
            }
            WriteEndElement(o);
        }

        void Write19_PhraseTopic(string n, string ns, global::PiStudio.Win10.Voice.Commands.PhraseTopic o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Commands.PhraseTopic)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"PhraseTopic", defaultNamespace);
            WriteAttribute(@"Label", @"", ((global::System.String)o.@Label));
            WriteAttribute(@"Scenario", @"", Write17_Scenario(((global::PiStudio.Win10.Voice.Commands.Scenario)o.@Scenario)));
            {
                global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.Subjects> a = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.Subjects>)o.@Subjects;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace43 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                        WriteElementString(@"Subject", namespace43, Write18_Subjects(((global::PiStudio.Win10.Voice.Commands.Subjects)a[ia])));
                    }
                }
            }
            WriteEndElement(o);
        }

        string Write18_Subjects(global::PiStudio.Win10.Voice.Commands.Subjects v) {
            string s = null;
            switch (v) {
                case global::PiStudio.Win10.Voice.Commands.Subjects.@DateTime: s = @"Date/Time"; break;
                case global::PiStudio.Win10.Voice.Commands.Subjects.@Addresses: s = @"Addresses"; break;
                case global::PiStudio.Win10.Voice.Commands.Subjects.@CityState: s = @"City/State"; break;
                case global::PiStudio.Win10.Voice.Commands.Subjects.@PersonNames: s = @"Person Names"; break;
                case global::PiStudio.Win10.Voice.Commands.Subjects.@Movies: s = @"Movies"; break;
                case global::PiStudio.Win10.Voice.Commands.Subjects.@Music: s = @"Music"; break;
                case global::PiStudio.Win10.Voice.Commands.Subjects.@PhoneNumber: s = @"Phone Number"; break;
                default: throw CreateInvalidEnumValueException(((System.Int64)v).ToString(System.Globalization.CultureInfo.InvariantCulture), @"PiStudio.Win10.Voice.Commands.Subjects");
            }
            return s;
        }

        string Write17_Scenario(global::PiStudio.Win10.Voice.Commands.Scenario v) {
            string s = null;
            switch (v) {
                case global::PiStudio.Win10.Voice.Commands.Scenario.@NaturalLanguage: s = @"Natural Language"; break;
                case global::PiStudio.Win10.Voice.Commands.Scenario.@Search: s = @"Search"; break;
                case global::PiStudio.Win10.Voice.Commands.Scenario.@ShortMessage: s = @"Short Message"; break;
                case global::PiStudio.Win10.Voice.Commands.Scenario.@Dictation: s = @"Dictation"; break;
                case global::PiStudio.Win10.Voice.Commands.Scenario.@Commands: s = @"Commands"; break;
                case global::PiStudio.Win10.Voice.Commands.Scenario.@FormFilling: s = @"Form Filling"; break;
                default: throw CreateInvalidEnumValueException(((System.Int64)v).ToString(System.Globalization.CultureInfo.InvariantCulture), @"PiStudio.Win10.Voice.Commands.Scenario");
            }
            return s;
        }

        void Write16_PhraseList(string n, string ns, global::PiStudio.Win10.Voice.Commands.PhraseList o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Commands.PhraseList)) {
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
                global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.ListItem> a = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.ListItem>)o.@Items;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace44 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                        Write15_ListItem(@"Item", namespace44, ((global::PiStudio.Win10.Voice.Commands.ListItem)a[ia]), false, false, namespace44, @"http://schemas.microsoft.com/voicecommands/1.2");
                    }
                }
            }
            WriteEndElement(o);
        }

        void Write15_ListItem(string n, string ns, global::PiStudio.Win10.Voice.Commands.ListItem o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Commands.ListItem)) {
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

        void Write13_Command(string n, string ns, global::PiStudio.Win10.Voice.Commands.Command o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Commands.Command)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Command", defaultNamespace);
            WriteAttribute(@"Name", @"", ((global::System.String)o.@Name));
            string namespace45 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
            WriteElementString(@"Example", namespace45, ((global::System.String)o.@Example));
            {
                global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.ListenFor> a = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.ListenFor>)o.@ListenFor;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace46 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                        Write6_ListenFor(@"ListenFor", namespace46, ((global::PiStudio.Win10.Voice.Commands.ListenFor)a[ia]), false, false, namespace46, @"http://schemas.microsoft.com/voicecommands/1.2");
                    }
                }
            }
            string namespace47 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
            Write7_Feedback(@"Feedback", namespace47, ((global::PiStudio.Win10.Voice.Commands.Feedback)o.@Feedback), false, false, namespace47, @"http://schemas.microsoft.com/voicecommands/1.2");
            if ((object)(o.@VoiceAction) != null){
                if (o.@VoiceAction is global::PiStudio.Win10.Voice.Commands.ShowDialog) {
                    string namespace48 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                    Write11_ShowDialog(@"ShowDialog", namespace48, ((global::PiStudio.Win10.Voice.Commands.ShowDialog)o.@VoiceAction), false, false, namespace48, @"http://schemas.microsoft.com/voicecommands/1.2");
                }
                else if (o.@VoiceAction is global::PiStudio.Win10.Voice.Commands.CustomAction) {
                    string namespace49 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                    Write12_CustomAction(@"CustomAction", namespace49, ((global::PiStudio.Win10.Voice.Commands.CustomAction)o.@VoiceAction), false, false, namespace49, @"http://schemas.microsoft.com/voicecommands/1.2");
                }
                else if (o.@VoiceAction is global::PiStudio.Win10.Voice.Commands.Navigate) {
                    string namespace50 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                    Write9_Navigate(@"Navigate", namespace50, ((global::PiStudio.Win10.Voice.Commands.Navigate)o.@VoiceAction), false, false, namespace50, @"http://schemas.microsoft.com/voicecommands/1.2");
                }
                else if (o.@VoiceAction is global::PiStudio.Win10.Voice.Commands.VoiceCommandService) {
                    string namespace51 = ( parentCompileTimeNs == @"http://schemas.microsoft.com/voicecommands/1.2" && parentRuntimeNs != null ) ? parentRuntimeNs : @"http://schemas.microsoft.com/voicecommands/1.2";
                    Write10_VoiceCommandService(@"VoiceCommandService", namespace51, ((global::PiStudio.Win10.Voice.Commands.VoiceCommandService)o.@VoiceAction), false, false, namespace51, @"http://schemas.microsoft.com/voicecommands/1.2");
                }
                else  if ((object)(o.@VoiceAction) != null){
                    throw CreateUnknownTypeException(o.@VoiceAction);
                }
            }
            WriteEndElement(o);
        }

        void Write10_VoiceCommandService(string n, string ns, global::PiStudio.Win10.Voice.Commands.VoiceCommandService o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Commands.VoiceCommandService)) {
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

        void Write9_Navigate(string n, string ns, global::PiStudio.Win10.Voice.Commands.Navigate o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Commands.Navigate)) {
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

        void Write12_CustomAction(string n, string ns, global::PiStudio.Win10.Voice.Commands.CustomAction o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Commands.CustomAction)) {
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

        void Write11_ShowDialog(string n, string ns, global::PiStudio.Win10.Voice.Commands.ShowDialog o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Commands.ShowDialog)) {
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

        void Write7_Feedback(string n, string ns, global::PiStudio.Win10.Voice.Commands.Feedback o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Commands.Feedback)) {
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

        void Write6_ListenFor(string n, string ns, global::PiStudio.Win10.Voice.Commands.ListenFor o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Commands.ListenFor)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"ListenFor", defaultNamespace);
            WriteAttribute(@"RequireAppName", @"", Write5_AppNameRequirement(((global::PiStudio.Win10.Voice.Commands.AppNameRequirement)o.@RequireAppName)));
            if ((object)(o.@Content) != null){
                WriteValue(((global::System.String)o.@Content));
            }
            WriteEndElement(o);
        }

        string Write5_AppNameRequirement(global::PiStudio.Win10.Voice.Commands.AppNameRequirement v) {
            string s = null;
            switch (v) {
                case global::PiStudio.Win10.Voice.Commands.AppNameRequirement.@BeforePhrase: s = @"BeforePhrase"; break;
                case global::PiStudio.Win10.Voice.Commands.AppNameRequirement.@AfterPhrase: s = @"AfterPhrase"; break;
                case global::PiStudio.Win10.Voice.Commands.AppNameRequirement.@BeforeOrAfterPhrase: s = @"BeforeOrAfterPhrase"; break;
                case global::PiStudio.Win10.Voice.Commands.AppNameRequirement.@ExplicitlySpecified: s = @"ExplicitlySpecified"; break;
                default: throw CreateInvalidEnumValueException(((System.Int64)v).ToString(System.Globalization.CultureInfo.InvariantCulture), @"PiStudio.Win10.Voice.Commands.AppNameRequirement");
            }
            return s;
        }

        void Write3_CommandPrefix(string n, string ns, global::PiStudio.Win10.Voice.Commands.CommandPrefix o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Commands.CommandPrefix)) {
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

        void Write4_AppName(string n, string ns, global::PiStudio.Win10.Voice.Commands.AppName o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::PiStudio.Win10.Voice.Commands.AppName)) {
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

        public object Read37_VoiceCommands(string defaultNamespace = null) {
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

        public object Read38_grammar(string defaultNamespace = null) {
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

        public object Read39_AppSettings(string defaultNamespace = null) {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                if (((object) Reader.LocalName == (object)id5_AppSettings && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id6_Item))) {
                    o = Read36_AppSettings(true, true, defaultNamespace);
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

        global::PiStudio.Shared.AppSettings Read36_AppSettings(bool isNullable, bool checkType, string defaultNamespace = null) {
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
            global::PiStudio.Shared.AppSettings o;
            try {
                o = (global::PiStudio.Shared.AppSettings)ActivatorHelper.CreateInstance(typeof(global::PiStudio.Shared.AppSettings));
            }
            catch (System.MissingMemberException) {
                throw CreateInaccessibleConstructorException(@"global::PiStudio.Shared.AppSettings");
            }
            catch (System.Security.SecurityException) {
                throw CreateCtorHasSecurityException(@"global::PiStudio.Shared.AppSettings");
            }
            global::System.Collections.Generic.HashSet<global::System.String> a_0 = (global::System.Collections.Generic.HashSet<global::System.String>)o.@SupportedImageTypes;
            bool[] paramsRead = new bool[14];
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
                    if (((object) Reader.LocalName == (object)id7_SupportedImageTypes && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id6_Item))) {
                        if (!ReadNull()) {
                            global::System.Collections.Generic.HashSet<global::System.String> a_0_0 = (global::System.Collections.Generic.HashSet<global::System.String>)o.@SupportedImageTypes;
                            if (((object)(a_0_0) == null) || (Reader.IsEmptyElement)) {
                                Reader.Skip();
                            }
                            else {
                                Reader.ReadStartElement();
                                Reader.MoveToContent();
                                int whileIterations1 = 0;
                                int readerCount1 = ReaderCount;
                                while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                                    if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                                        if (((object) Reader.LocalName == (object)id8_string && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id6_Item))) {
                                            if (ReadNull()) {
                                                a_0_0.Add(null);
                                            }
                                            else {
                                                a_0_0.Add(Reader.ReadElementContentAsString());
                                            }
                                        }
                                        else {
                                            UnknownNode(null, @":string");
                                        }
                                    }
                                    else {
                                        UnknownNode(null, @":string");
                                    }
                                    Reader.MoveToContent();
                                    CheckReaderCount(ref whileIterations1, ref readerCount1);
                                }
                            ReadEndElement();
                            }
                        }
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id9_FirstLaunch && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id6_Item))) {
                        {
                            o.@FirstLaunch = System.Xml.XmlConvert.ToBoolean(Reader.ReadElementContentAsString());
                        }
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id10_AppLanguage && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id6_Item))) {
                        {
                            o.@AppLanguage = Read35_Language(Reader.ReadElementContentAsString());
                        }
                        paramsRead[2] = true;
                    }
                    else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id11_AutoSave && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id6_Item))) {
                        {
                            o.@AutoSave = System.Xml.XmlConvert.ToBoolean(Reader.ReadElementContentAsString());
                        }
                        paramsRead[3] = true;
                    }
                    else if (!paramsRead[4] && ((object) Reader.LocalName == (object)id12_IsDarkTheme && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id6_Item))) {
                        {
                            o.@IsDarkTheme = System.Xml.XmlConvert.ToBoolean(Reader.ReadElementContentAsString());
                        }
                        paramsRead[4] = true;
                    }
                    else if (!paramsRead[5] && ((object) Reader.LocalName == (object)id13_IsPredefinedTheme && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id6_Item))) {
                        {
                            o.@IsPredefinedTheme = System.Xml.XmlConvert.ToBoolean(Reader.ReadElementContentAsString());
                        }
                        paramsRead[5] = true;
                    }
                    else if (!paramsRead[6] && ((object) Reader.LocalName == (object)id14_Foreground && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id6_Item))) {
                        {
                            o.@Foreground = System.Xml.XmlConvert.ToUInt32(Reader.ReadElementContentAsString());
                        }
                        paramsRead[6] = true;
                    }
                    else if (!paramsRead[7] && ((object) Reader.LocalName == (object)id15_Background && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id6_Item))) {
                        {
                            o.@Background = System.Xml.XmlConvert.ToUInt32(Reader.ReadElementContentAsString());
                        }
                        paramsRead[7] = true;
                    }
                    else if (!paramsRead[8] && ((object) Reader.LocalName == (object)id16_PanelBackground && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id6_Item))) {
                        {
                            o.@PanelBackground = System.Xml.XmlConvert.ToUInt32(Reader.ReadElementContentAsString());
                        }
                        paramsRead[8] = true;
                    }
                    else if (!paramsRead[9] && ((object) Reader.LocalName == (object)id17_Borders && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id6_Item))) {
                        {
                            o.@Borders = System.Xml.XmlConvert.ToUInt32(Reader.ReadElementContentAsString());
                        }
                        paramsRead[9] = true;
                    }
                    else if (!paramsRead[10] && ((object) Reader.LocalName == (object)id18_PanelForeground && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id6_Item))) {
                        {
                            o.@PanelForeground = System.Xml.XmlConvert.ToUInt32(Reader.ReadElementContentAsString());
                        }
                        paramsRead[10] = true;
                    }
                    else if (!paramsRead[11] && ((object) Reader.LocalName == (object)id19_PanelItemFocused && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id6_Item))) {
                        {
                            o.@PanelItemFocused = System.Xml.XmlConvert.ToUInt32(Reader.ReadElementContentAsString());
                        }
                        paramsRead[11] = true;
                    }
                    else if (!paramsRead[12] && ((object) Reader.LocalName == (object)id20_ClickableForeground && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id6_Item))) {
                        {
                            o.@ClickableForeground = System.Xml.XmlConvert.ToUInt32(Reader.ReadElementContentAsString());
                        }
                        paramsRead[12] = true;
                    }
                    else if (!paramsRead[13] && ((object) Reader.LocalName == (object)id21_UpperPanelBackground && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id6_Item))) {
                        {
                            o.@UpperPanelBackground = System.Xml.XmlConvert.ToUInt32(Reader.ReadElementContentAsString());
                        }
                        paramsRead[13] = true;
                    }
                    else {
                        UnknownNode((object)o, @":SupportedImageTypes, :FirstLaunch, :AppLanguage, :AutoSave, :IsDarkTheme, :IsPredefinedTheme, :Foreground, :Background, :PanelBackground, :Borders, :PanelForeground, :PanelItemFocused, :ClickableForeground, :UpperPanelBackground");
                    }
                }
                else {
                    UnknownNode((object)o, @":SupportedImageTypes, :FirstLaunch, :AppLanguage, :AutoSave, :IsDarkTheme, :IsPredefinedTheme, :Foreground, :Background, :PanelBackground, :Borders, :PanelForeground, :PanelItemFocused, :ClickableForeground, :UpperPanelBackground");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations0, ref readerCount0);
            }
            ReadEndElement();
            return o;
        }

        global::PiStudio.Shared.Data.Language Read35_Language(string s) {
            switch (s) {
                case @"Slovensky": return global::PiStudio.Shared.Data.Language.@Slovensky;
                case @"English": return global::PiStudio.Shared.Data.Language.@English;
                case @"German": return global::PiStudio.Shared.Data.Language.@German;
                default: throw CreateUnknownConstantException(s, typeof(global::PiStudio.Shared.Data.Language));
            }
        }

        global::PiStudio.Win10.Voice.Srgs.Grammar Read34_Grammar(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id22_Grammar && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id4_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Srgs.Grammar o;
            o = new global::PiStudio.Win10.Voice.Srgs.Grammar();
            global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Srgs.Rule> a_6 = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Srgs.Rule>)o.@Rules;
            bool[] paramsRead = new bool[7];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id23_lang && string.Equals(Reader.NamespaceURI, id24_Item))) {
                    o.@Language = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id25_tagformat && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@TagFormat = Reader.Value;
                    paramsRead[1] = true;
                }
                else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id26_root && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Root = Reader.Value;
                    paramsRead[2] = true;
                }
                else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id27_version && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Version = Reader.Value;
                    paramsRead[3] = true;
                }
                else if (!paramsRead[5] && ((object) Reader.LocalName == (object)id28_mode && string.Equals(Reader.NamespaceURI, id6_Item))) {
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
            int whileIterations2 = 0;
            int readerCount2 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[4] && ((object) Reader.LocalName == (object)id29_Metadata && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                        o.@Metadata = Read25_Metadata(false, true, defaultNamespace);
                        paramsRead[4] = true;
                    }
                    else if (((object) Reader.LocalName == (object)id30_rule && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
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
                CheckReaderCount(ref whileIterations2, ref readerCount2);
            }
            ReadEndElement();
            return o;
        }

        global::PiStudio.Win10.Voice.Srgs.Rule Read33_Rule(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id31_Rule && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id4_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Srgs.Rule o;
            o = new global::PiStudio.Win10.Voice.Srgs.Rule();
            global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Srgs.Example> a_0 = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Srgs.Example>)o.@Examples;
            global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Srgs.RuleItem> a_1 = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Srgs.RuleItem>)o.@Elements;
            bool[] paramsRead = new bool[5];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[2] && ((object) Reader.LocalName == (object)id32_scope && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Scope = Reader.Value;
                    paramsRead[2] = true;
                }
                else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id33_id && string.Equals(Reader.NamespaceURI, id6_Item))) {
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
            int whileIterations3 = 0;
            int readerCount3 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                string tmp = null;
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    switch (state) {
                    case 0:
                        if (((object) Reader.LocalName == (object)id34_example && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                            if ((object)(a_0) == null) Reader.Skip(); else a_0.Add(Read32_Example(false, true, defaultNamespace));
                        }
                        else {
                            state = 1;
                        }
                        break;
                    case 1:
                        if (((object) Reader.LocalName == (object)id35_item && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                            if ((object)(a_1) == null) Reader.Skip(); else a_1.Add(Read31_Item(false, true, defaultNamespace));
                        }
                        else if (((object) Reader.LocalName == (object)id36_ruleref && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                            if ((object)(a_1) == null) Reader.Skip(); else a_1.Add(Read27_RuleRef(false, true, defaultNamespace));
                        }
                        else if (((object) Reader.LocalName == (object)id37_tag && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                            if ((object)(a_1) == null) Reader.Skip(); else a_1.Add(Read28_Tag(false, true, defaultNamespace));
                        }
                        else if (((object) Reader.LocalName == (object)id38_token && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                            if ((object)(a_1) == null) Reader.Skip(); else a_1.Add(Read29_Token(false, true, defaultNamespace));
                        }
                        else if (((object) Reader.LocalName == (object)id39_oneof && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
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
                CheckReaderCount(ref whileIterations3, ref readerCount3);
            }
            ReadEndElement();
            return o;
        }

        global::PiStudio.Win10.Voice.Srgs.OneOf Read30_OneOf(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id40_OneOf && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id4_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Srgs.OneOf o;
            o = new global::PiStudio.Win10.Voice.Srgs.OneOf();
            global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Srgs.Item> a_0 = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Srgs.Item>)o.@Items;
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
            int whileIterations4 = 0;
            int readerCount4 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (((object) Reader.LocalName == (object)id35_item && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
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
                CheckReaderCount(ref whileIterations4, ref readerCount4);
            }
            ReadEndElement();
            return o;
        }

        global::PiStudio.Win10.Voice.Srgs.Item Read31_Item(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id41_Item && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id4_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Srgs.Item o;
            o = new global::PiStudio.Win10.Voice.Srgs.Item();
            global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Srgs.RuleItem> a_3 = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Srgs.RuleItem>)o.@Elements;
            bool[] paramsRead = new bool[4];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[1] && ((object) Reader.LocalName == (object)id42_weight && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Weight = Reader.Value;
                    paramsRead[1] = true;
                }
                else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id43_repeat && string.Equals(Reader.NamespaceURI, id6_Item))) {
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
            int whileIterations5 = 0;
            int readerCount5 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                string tmp = null;
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (((object) Reader.LocalName == (object)id35_item && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                        if ((object)(a_3) == null) Reader.Skip(); else a_3.Add(Read31_Item(false, true, defaultNamespace));
                    }
                    else if (((object) Reader.LocalName == (object)id36_ruleref && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                        if ((object)(a_3) == null) Reader.Skip(); else a_3.Add(Read27_RuleRef(false, true, defaultNamespace));
                    }
                    else if (((object) Reader.LocalName == (object)id37_tag && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                        if ((object)(a_3) == null) Reader.Skip(); else a_3.Add(Read28_Tag(false, true, defaultNamespace));
                    }
                    else if (((object) Reader.LocalName == (object)id38_token && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
                        if ((object)(a_3) == null) Reader.Skip(); else a_3.Add(Read29_Token(false, true, defaultNamespace));
                    }
                    else if (((object) Reader.LocalName == (object)id39_oneof && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
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
                CheckReaderCount(ref whileIterations5, ref readerCount5);
            }
            ReadEndElement();
            return o;
        }

        global::PiStudio.Win10.Voice.Srgs.Token Read29_Token(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id44_Token && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id4_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Srgs.Token o;
            o = new global::PiStudio.Win10.Voice.Srgs.Token();
            bool[] paramsRead = new bool[3];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id45_display && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Display = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id46_pron && string.Equals(Reader.NamespaceURI, id6_Item))) {
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
                    o.@Text = tmp;
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

        global::PiStudio.Win10.Voice.Srgs.Tag Read28_Tag(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id47_Tag && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id4_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Srgs.Tag o;
            o = new global::PiStudio.Win10.Voice.Srgs.Tag();
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
            int whileIterations7 = 0;
            int readerCount7 = ReaderCount;
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
                CheckReaderCount(ref whileIterations7, ref readerCount7);
            }
            ReadEndElement();
            return o;
        }

        global::PiStudio.Win10.Voice.Srgs.RuleRef Read27_RuleRef(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id48_RuleRef && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id4_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Srgs.RuleRef o;
            o = new global::PiStudio.Win10.Voice.Srgs.RuleRef();
            bool[] paramsRead = new bool[3];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id49_uri && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Uri = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id50_special && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Special = Reader.Value;
                    paramsRead[1] = true;
                }
                else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id51_type && string.Equals(Reader.NamespaceURI, id6_Item))) {
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
            int whileIterations8 = 0;
            int readerCount8 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)o, @"");
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

        global::PiStudio.Win10.Voice.Srgs.Example Read32_Example(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id52_Example && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id4_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Srgs.Example o;
            o = new global::PiStudio.Win10.Voice.Srgs.Example();
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
                CheckReaderCount(ref whileIterations9, ref readerCount9);
            }
            ReadEndElement();
            return o;
        }

        global::PiStudio.Win10.Voice.Srgs.Metadata Read25_Metadata(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id29_Metadata && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id4_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Srgs.Metadata o;
            o = new global::PiStudio.Win10.Voice.Srgs.Metadata();
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
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id53_RDF && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id4_Item))) {
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
                CheckReaderCount(ref whileIterations10, ref readerCount10);
            }
            ReadEndElement();
            return o;
        }

        global::PiStudio.Win10.Voice.Srgs.RDF Read24_RDF(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id53_RDF && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id4_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Srgs.RDF o;
            o = new global::PiStudio.Win10.Voice.Srgs.RDF();
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
            int whileIterations11 = 0;
            int readerCount11 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id54_Description && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id55_Item))) {
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
                CheckReaderCount(ref whileIterations11, ref readerCount11);
            }
            ReadEndElement();
            return o;
        }

        global::PiStudio.Win10.Voice.Srgs.Description Read23_Description(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id54_Description && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id55_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Srgs.Description o;
            o = new global::PiStudio.Win10.Voice.Srgs.Description();
            bool[] paramsRead = new bool[9];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id56_about && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@About = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id57_Title && string.Equals(Reader.NamespaceURI, id58_Item))) {
                    o.@Title = Reader.Value;
                    paramsRead[1] = true;
                }
                else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id54_Description && string.Equals(Reader.NamespaceURI, id58_Item))) {
                    o.@Descript = Reader.Value;
                    paramsRead[2] = true;
                }
                else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id59_Publisher && string.Equals(Reader.NamespaceURI, id58_Item))) {
                    o.@Publisher = Reader.Value;
                    paramsRead[3] = true;
                }
                else if (!paramsRead[4] && ((object) Reader.LocalName == (object)id60_Language && string.Equals(Reader.NamespaceURI, id58_Item))) {
                    o.@Language = Reader.Value;
                    paramsRead[4] = true;
                }
                else if (!paramsRead[5] && ((object) Reader.LocalName == (object)id61_Date && string.Equals(Reader.NamespaceURI, id58_Item))) {
                    o.@Date = ToDateTime(Reader.Value);
                    paramsRead[5] = true;
                }
                else if (!paramsRead[6] && ((object) Reader.LocalName == (object)id62_Rights && string.Equals(Reader.NamespaceURI, id58_Item))) {
                    o.@Rights = Reader.Value;
                    paramsRead[6] = true;
                }
                else if (!paramsRead[7] && ((object) Reader.LocalName == (object)id63_Format && string.Equals(Reader.NamespaceURI, id58_Item))) {
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
            int whileIterations12 = 0;
            int readerCount12 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[8] && ((object) Reader.LocalName == (object)id64_Creator && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id58_Item))) {
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
                CheckReaderCount(ref whileIterations12, ref readerCount12);
            }
            ReadEndElement();
            return o;
        }

        global::PiStudio.Win10.Voice.Srgs.Creator Read22_Creator(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id64_Creator && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id58_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Srgs.Creator o;
            o = new global::PiStudio.Win10.Voice.Srgs.Creator();
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
            int whileIterations13 = 0;
            int readerCount13 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)o, @"");
                }
                else {
                    UnknownNode((object)o, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations13, ref readerCount13);
            }
            ReadEndElement();
            return o;
        }

        global::PiStudio.Win10.Voice.Commands.VoiceCommands Read21_VoiceCommands(bool isNullable, bool checkType, string defaultNamespace = null) {
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
            global::PiStudio.Win10.Voice.Commands.VoiceCommands o;
            o = new global::PiStudio.Win10.Voice.Commands.VoiceCommands();
            global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.CommandSet> a_0 = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.CommandSet>)o.@CommandSets;
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
            int whileIterations14 = 0;
            int readerCount14 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (((object) Reader.LocalName == (object)id65_CommandSet && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
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
                CheckReaderCount(ref whileIterations14, ref readerCount14);
            }
            ReadEndElement();
            return o;
        }

        global::PiStudio.Win10.Voice.Commands.CommandSet Read20_CommandSet(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id65_CommandSet && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Commands.CommandSet o;
            o = new global::PiStudio.Win10.Voice.Commands.CommandSet();
            global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.Command> a_2 = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.Command>)o.@Commands;
            global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.PhraseList> a_3 = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.PhraseList>)o.@PhraseLists;
            global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.PhraseTopic> a_4 = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.PhraseTopic>)o.@PhraseTopics;
            bool[] paramsRead = new bool[7];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[5] && ((object) Reader.LocalName == (object)id23_lang && string.Equals(Reader.NamespaceURI, id24_Item))) {
                    o.@Language = Reader.Value;
                    paramsRead[5] = true;
                }
                else if (!paramsRead[6] && ((object) Reader.LocalName == (object)id66_Name && string.Equals(Reader.NamespaceURI, id6_Item))) {
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
            int whileIterations15 = 0;
            int readerCount15 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    switch (state) {
                    case 0:
                        if (((object) Reader.LocalName == (object)id67_CommandPrefix && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            o.@Prefix = Read3_CommandPrefix(false, true, defaultNamespace);
                        }
                        else if (((object) Reader.LocalName == (object)id68_AppName && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            o.@Prefix = Read4_AppName(false, true, defaultNamespace);
                        }
                        state = 1;
                        break;
                    case 1:
                        if (((object) Reader.LocalName == (object)id52_Example && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            {
                                o.@Example = Reader.ReadElementContentAsString();
                            }
                        }
                        state = 2;
                        break;
                    case 2:
                        if (((object) Reader.LocalName == (object)id69_Command && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            if ((object)(a_2) == null) Reader.Skip(); else a_2.Add(Read13_Command(false, true, defaultNamespace));
                        }
                        else {
                            state = 3;
                        }
                        break;
                    case 3:
                        if (((object) Reader.LocalName == (object)id70_PhraseList && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            if ((object)(a_3) == null) Reader.Skip(); else a_3.Add(Read16_PhraseList(false, true, defaultNamespace));
                        }
                        else {
                            state = 4;
                        }
                        break;
                    case 4:
                        if (((object) Reader.LocalName == (object)id71_PhraseTopic && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
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
                CheckReaderCount(ref whileIterations15, ref readerCount15);
            }
            ReadEndElement();
            return o;
        }

        global::PiStudio.Win10.Voice.Commands.PhraseTopic Read19_PhraseTopic(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id71_PhraseTopic && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Commands.PhraseTopic o;
            o = new global::PiStudio.Win10.Voice.Commands.PhraseTopic();
            global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.Subjects> a_2 = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.Subjects>)o.@Subjects;
            bool[] paramsRead = new bool[3];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id72_Label && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Label = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id73_Scenario && string.Equals(Reader.NamespaceURI, id6_Item))) {
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
            int whileIterations16 = 0;
            int readerCount16 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (((object) Reader.LocalName == (object)id74_Subject && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
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
                CheckReaderCount(ref whileIterations16, ref readerCount16);
            }
            ReadEndElement();
            return o;
        }

        global::PiStudio.Win10.Voice.Commands.Subjects Read18_Subjects(string s) {
            switch (s) {
                case @"Date/Time": return global::PiStudio.Win10.Voice.Commands.Subjects.@DateTime;
                case @"Addresses": return global::PiStudio.Win10.Voice.Commands.Subjects.@Addresses;
                case @"City/State": return global::PiStudio.Win10.Voice.Commands.Subjects.@CityState;
                case @"Person Names": return global::PiStudio.Win10.Voice.Commands.Subjects.@PersonNames;
                case @"Movies": return global::PiStudio.Win10.Voice.Commands.Subjects.@Movies;
                case @"Music": return global::PiStudio.Win10.Voice.Commands.Subjects.@Music;
                case @"Phone Number": return global::PiStudio.Win10.Voice.Commands.Subjects.@PhoneNumber;
                default: throw CreateUnknownConstantException(s, typeof(global::PiStudio.Win10.Voice.Commands.Subjects));
            }
        }

        global::PiStudio.Win10.Voice.Commands.Scenario Read17_Scenario(string s) {
            switch (s) {
                case @"Natural Language": return global::PiStudio.Win10.Voice.Commands.Scenario.@NaturalLanguage;
                case @"Search": return global::PiStudio.Win10.Voice.Commands.Scenario.@Search;
                case @"Short Message": return global::PiStudio.Win10.Voice.Commands.Scenario.@ShortMessage;
                case @"Dictation": return global::PiStudio.Win10.Voice.Commands.Scenario.@Dictation;
                case @"Commands": return global::PiStudio.Win10.Voice.Commands.Scenario.@Commands;
                case @"Form Filling": return global::PiStudio.Win10.Voice.Commands.Scenario.@FormFilling;
                default: throw CreateUnknownConstantException(s, typeof(global::PiStudio.Win10.Voice.Commands.Scenario));
            }
        }

        global::PiStudio.Win10.Voice.Commands.PhraseList Read16_PhraseList(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id70_PhraseList && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Commands.PhraseList o;
            o = new global::PiStudio.Win10.Voice.Commands.PhraseList();
            global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.ListItem> a_2 = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.ListItem>)o.@Items;
            bool[] paramsRead = new bool[3];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id72_Label && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@Label = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id75_Disambiguate && string.Equals(Reader.NamespaceURI, id6_Item))) {
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
            int whileIterations17 = 0;
            int readerCount17 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (((object) Reader.LocalName == (object)id41_Item && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
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
                CheckReaderCount(ref whileIterations17, ref readerCount17);
            }
            ReadEndElement();
            return o;
        }

        global::PiStudio.Win10.Voice.Commands.ListItem Read15_ListItem(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id76_ListItem && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Commands.ListItem o;
            o = new global::PiStudio.Win10.Voice.Commands.ListItem();
            bool[] paramsRead = new bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id77_Display && string.Equals(Reader.NamespaceURI, id6_Item))) {
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
            int whileIterations18 = 0;
            int readerCount18 = ReaderCount;
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
                CheckReaderCount(ref whileIterations18, ref readerCount18);
            }
            ReadEndElement();
            return o;
        }

        global::PiStudio.Win10.Voice.Commands.Command Read13_Command(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id69_Command && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Commands.Command o;
            o = new global::PiStudio.Win10.Voice.Commands.Command();
            global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.ListenFor> a_1 = (global::System.Collections.Generic.List<global::PiStudio.Win10.Voice.Commands.ListenFor>)o.@ListenFor;
            bool[] paramsRead = new bool[5];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[4] && ((object) Reader.LocalName == (object)id66_Name && string.Equals(Reader.NamespaceURI, id6_Item))) {
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
            int whileIterations19 = 0;
            int readerCount19 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    switch (state) {
                    case 0:
                        if (((object) Reader.LocalName == (object)id52_Example && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            {
                                o.@Example = Reader.ReadElementContentAsString();
                            }
                        }
                        state = 1;
                        break;
                    case 1:
                        if (((object) Reader.LocalName == (object)id78_ListenFor && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            if ((object)(a_1) == null) Reader.Skip(); else a_1.Add(Read6_ListenFor(false, true, defaultNamespace));
                        }
                        else {
                            state = 2;
                        }
                        break;
                    case 2:
                        if (((object) Reader.LocalName == (object)id79_Feedback && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            o.@Feedback = Read7_Feedback(false, true, defaultNamespace);
                        }
                        state = 3;
                        break;
                    case 3:
                        if (((object) Reader.LocalName == (object)id80_Navigate && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            o.@VoiceAction = Read9_Navigate(false, true, defaultNamespace);
                        }
                        else if (((object) Reader.LocalName == (object)id81_VoiceCommandService && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            o.@VoiceAction = Read10_VoiceCommandService(false, true, defaultNamespace);
                        }
                        else if (((object) Reader.LocalName == (object)id82_ShowDialog && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            o.@VoiceAction = Read11_ShowDialog(false, true, defaultNamespace);
                        }
                        else if (((object) Reader.LocalName == (object)id83_CustomAction && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
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
                CheckReaderCount(ref whileIterations19, ref readerCount19);
            }
            ReadEndElement();
            return o;
        }

        global::PiStudio.Win10.Voice.Commands.CustomAction Read12_CustomAction(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id83_CustomAction && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Commands.CustomAction o;
            o = new global::PiStudio.Win10.Voice.Commands.CustomAction();
            bool[] paramsRead = new bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id84_Parameter && string.Equals(Reader.NamespaceURI, id6_Item))) {
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
            int whileIterations20 = 0;
            int readerCount20 = ReaderCount;
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
                CheckReaderCount(ref whileIterations20, ref readerCount20);
            }
            ReadEndElement();
            return o;
        }

        global::PiStudio.Win10.Voice.Commands.ShowDialog Read11_ShowDialog(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id82_ShowDialog && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Commands.ShowDialog o;
            o = new global::PiStudio.Win10.Voice.Commands.ShowDialog();
            bool[] paramsRead = new bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id85_TextToDisplay && string.Equals(Reader.NamespaceURI, id6_Item))) {
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

        global::PiStudio.Win10.Voice.Commands.VoiceCommandService Read10_VoiceCommandService(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id81_VoiceCommandService && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Commands.VoiceCommandService o;
            o = new global::PiStudio.Win10.Voice.Commands.VoiceCommandService();
            bool[] paramsRead = new bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id86_Target && string.Equals(Reader.NamespaceURI, id6_Item))) {
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

        global::PiStudio.Win10.Voice.Commands.Navigate Read9_Navigate(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id80_Navigate && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Commands.Navigate o;
            o = new global::PiStudio.Win10.Voice.Commands.Navigate();
            bool[] paramsRead = new bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id87_NavigationParameter && string.Equals(Reader.NamespaceURI, id6_Item))) {
                    o.@NavigationParameter = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id86_Target && string.Equals(Reader.NamespaceURI, id6_Item))) {
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
            int whileIterations23 = 0;
            int readerCount23 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)o, @"");
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

        global::PiStudio.Win10.Voice.Commands.Feedback Read7_Feedback(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id79_Feedback && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Commands.Feedback o;
            o = new global::PiStudio.Win10.Voice.Commands.Feedback();
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

        global::PiStudio.Win10.Voice.Commands.ListenFor Read6_ListenFor(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id78_ListenFor && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Commands.ListenFor o;
            o = new global::PiStudio.Win10.Voice.Commands.ListenFor();
            bool[] paramsRead = new bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[1] && ((object) Reader.LocalName == (object)id88_RequireAppName && string.Equals(Reader.NamespaceURI, id6_Item))) {
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

        global::PiStudio.Win10.Voice.Commands.AppNameRequirement Read5_AppNameRequirement(string s) {
            switch (s) {
                case @"BeforePhrase": return global::PiStudio.Win10.Voice.Commands.AppNameRequirement.@BeforePhrase;
                case @"AfterPhrase": return global::PiStudio.Win10.Voice.Commands.AppNameRequirement.@AfterPhrase;
                case @"BeforeOrAfterPhrase": return global::PiStudio.Win10.Voice.Commands.AppNameRequirement.@BeforeOrAfterPhrase;
                case @"ExplicitlySpecified": return global::PiStudio.Win10.Voice.Commands.AppNameRequirement.@ExplicitlySpecified;
                default: throw CreateUnknownConstantException(s, typeof(global::PiStudio.Win10.Voice.Commands.AppNameRequirement));
            }
        }

        global::PiStudio.Win10.Voice.Commands.AppName Read4_AppName(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id68_AppName && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Commands.AppName o;
            o = new global::PiStudio.Win10.Voice.Commands.AppName();
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

        global::PiStudio.Win10.Voice.Commands.CommandPrefix Read3_CommandPrefix(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id67_CommandPrefix && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::PiStudio.Win10.Voice.Commands.CommandPrefix o;
            o = new global::PiStudio.Win10.Voice.Commands.CommandPrefix();
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
            int whileIterations27 = 0;
            int readerCount27 = ReaderCount;
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
                CheckReaderCount(ref whileIterations27, ref readerCount27);
            }
            ReadEndElement();
            return o;
        }

        protected override void InitCallbacks() {
        }

        string id88_RequireAppName;
        string id56_about;
        string id33_id;
        string id69_Command;
        string id54_Description;
        string id27_version;
        string id79_Feedback;
        string id16_PanelBackground;
        string id68_AppName;
        string id83_CustomAction;
        string id73_Scenario;
        string id7_SupportedImageTypes;
        string id42_weight;
        string id40_OneOf;
        string id75_Disambiguate;
        string id53_RDF;
        string id14_Foreground;
        string id34_example;
        string id23_lang;
        string id10_AppLanguage;
        string id2_Item;
        string id44_Token;
        string id59_Publisher;
        string id36_ruleref;
        string id6_Item;
        string id20_ClickableForeground;
        string id63_Format;
        string id72_Label;
        string id35_item;
        string id12_IsDarkTheme;
        string id8_string;
        string id25_tagformat;
        string id82_ShowDialog;
        string id49_uri;
        string id21_UpperPanelBackground;
        string id11_AutoSave;
        string id76_ListItem;
        string id65_CommandSet;
        string id17_Borders;
        string id84_Parameter;
        string id26_root;
        string id32_scope;
        string id71_PhraseTopic;
        string id74_Subject;
        string id47_Tag;
        string id9_FirstLaunch;
        string id19_PanelItemFocused;
        string id77_Display;
        string id24_Item;
        string id41_Item;
        string id13_IsPredefinedTheme;
        string id86_Target;
        string id18_PanelForeground;
        string id45_display;
        string id50_special;
        string id1_VoiceCommands;
        string id80_Navigate;
        string id87_NavigationParameter;
        string id62_Rights;
        string id5_AppSettings;
        string id48_RuleRef;
        string id37_tag;
        string id67_CommandPrefix;
        string id4_Item;
        string id29_Metadata;
        string id85_TextToDisplay;
        string id15_Background;
        string id28_mode;
        string id66_Name;
        string id22_Grammar;
        string id31_Rule;
        string id38_token;
        string id3_grammar;
        string id70_PhraseList;
        string id51_type;
        string id57_Title;
        string id43_repeat;
        string id61_Date;
        string id78_ListenFor;
        string id58_Item;
        string id52_Example;
        string id60_Language;
        string id64_Creator;
        string id81_VoiceCommandService;
        string id30_rule;
        string id55_Item;
        string id46_pron;
        string id39_oneof;

        protected override void InitIDs() {
            id88_RequireAppName = Reader.NameTable.Add(@"RequireAppName");
            id56_about = Reader.NameTable.Add(@"about");
            id33_id = Reader.NameTable.Add(@"id");
            id69_Command = Reader.NameTable.Add(@"Command");
            id54_Description = Reader.NameTable.Add(@"Description");
            id27_version = Reader.NameTable.Add(@"version");
            id79_Feedback = Reader.NameTable.Add(@"Feedback");
            id16_PanelBackground = Reader.NameTable.Add(@"PanelBackground");
            id68_AppName = Reader.NameTable.Add(@"AppName");
            id83_CustomAction = Reader.NameTable.Add(@"CustomAction");
            id73_Scenario = Reader.NameTable.Add(@"Scenario");
            id7_SupportedImageTypes = Reader.NameTable.Add(@"SupportedImageTypes");
            id42_weight = Reader.NameTable.Add(@"weight");
            id40_OneOf = Reader.NameTable.Add(@"OneOf");
            id75_Disambiguate = Reader.NameTable.Add(@"Disambiguate");
            id53_RDF = Reader.NameTable.Add(@"RDF");
            id14_Foreground = Reader.NameTable.Add(@"Foreground");
            id34_example = Reader.NameTable.Add(@"example");
            id23_lang = Reader.NameTable.Add(@"lang");
            id10_AppLanguage = Reader.NameTable.Add(@"AppLanguage");
            id2_Item = Reader.NameTable.Add(@"http://schemas.microsoft.com/voicecommands/1.2");
            id44_Token = Reader.NameTable.Add(@"Token");
            id59_Publisher = Reader.NameTable.Add(@"Publisher");
            id36_ruleref = Reader.NameTable.Add(@"ruleref");
            id6_Item = Reader.NameTable.Add(@"");
            id20_ClickableForeground = Reader.NameTable.Add(@"ClickableForeground");
            id63_Format = Reader.NameTable.Add(@"Format");
            id72_Label = Reader.NameTable.Add(@"Label");
            id35_item = Reader.NameTable.Add(@"item");
            id12_IsDarkTheme = Reader.NameTable.Add(@"IsDarkTheme");
            id8_string = Reader.NameTable.Add(@"string");
            id25_tagformat = Reader.NameTable.Add(@"tag-format");
            id82_ShowDialog = Reader.NameTable.Add(@"ShowDialog");
            id49_uri = Reader.NameTable.Add(@"uri");
            id21_UpperPanelBackground = Reader.NameTable.Add(@"UpperPanelBackground");
            id11_AutoSave = Reader.NameTable.Add(@"AutoSave");
            id76_ListItem = Reader.NameTable.Add(@"ListItem");
            id65_CommandSet = Reader.NameTable.Add(@"CommandSet");
            id17_Borders = Reader.NameTable.Add(@"Borders");
            id84_Parameter = Reader.NameTable.Add(@"Parameter");
            id26_root = Reader.NameTable.Add(@"root");
            id32_scope = Reader.NameTable.Add(@"scope");
            id71_PhraseTopic = Reader.NameTable.Add(@"PhraseTopic");
            id74_Subject = Reader.NameTable.Add(@"Subject");
            id47_Tag = Reader.NameTable.Add(@"Tag");
            id9_FirstLaunch = Reader.NameTable.Add(@"FirstLaunch");
            id19_PanelItemFocused = Reader.NameTable.Add(@"PanelItemFocused");
            id77_Display = Reader.NameTable.Add(@"Display");
            id24_Item = Reader.NameTable.Add(@"http://www.w3.org/XML/1998/namespace");
            id41_Item = Reader.NameTable.Add(@"Item");
            id13_IsPredefinedTheme = Reader.NameTable.Add(@"IsPredefinedTheme");
            id86_Target = Reader.NameTable.Add(@"Target");
            id18_PanelForeground = Reader.NameTable.Add(@"PanelForeground");
            id45_display = Reader.NameTable.Add(@"display");
            id50_special = Reader.NameTable.Add(@"special");
            id1_VoiceCommands = Reader.NameTable.Add(@"VoiceCommands");
            id80_Navigate = Reader.NameTable.Add(@"Navigate");
            id87_NavigationParameter = Reader.NameTable.Add(@"NavigationParameter");
            id62_Rights = Reader.NameTable.Add(@"Rights");
            id5_AppSettings = Reader.NameTable.Add(@"AppSettings");
            id48_RuleRef = Reader.NameTable.Add(@"RuleRef");
            id37_tag = Reader.NameTable.Add(@"tag");
            id67_CommandPrefix = Reader.NameTable.Add(@"CommandPrefix");
            id4_Item = Reader.NameTable.Add(@"http://www.w3.org/2001/06/grammar");
            id29_Metadata = Reader.NameTable.Add(@"Metadata");
            id85_TextToDisplay = Reader.NameTable.Add(@"TextToDisplay");
            id15_Background = Reader.NameTable.Add(@"Background");
            id28_mode = Reader.NameTable.Add(@"mode");
            id66_Name = Reader.NameTable.Add(@"Name");
            id22_Grammar = Reader.NameTable.Add(@"Grammar");
            id31_Rule = Reader.NameTable.Add(@"Rule");
            id38_token = Reader.NameTable.Add(@"token");
            id3_grammar = Reader.NameTable.Add(@"grammar");
            id70_PhraseList = Reader.NameTable.Add(@"PhraseList");
            id51_type = Reader.NameTable.Add(@"type");
            id57_Title = Reader.NameTable.Add(@"Title");
            id43_repeat = Reader.NameTable.Add(@"repeat");
            id61_Date = Reader.NameTable.Add(@"Date");
            id78_ListenFor = Reader.NameTable.Add(@"ListenFor");
            id58_Item = Reader.NameTable.Add(@"http://purl.org/metadata/dublin_core#");
            id52_Example = Reader.NameTable.Add(@"Example");
            id60_Language = Reader.NameTable.Add(@"Language");
            id64_Creator = Reader.NameTable.Add(@"Creator");
            id81_VoiceCommandService = Reader.NameTable.Add(@"VoiceCommandService");
            id30_rule = Reader.NameTable.Add(@"rule");
            id55_Item = Reader.NameTable.Add(@"http://www.w3.org/1999/02/22-rdf-syntax-ns#");
            id46_pron = Reader.NameTable.Add(@"pron");
            id39_oneof = Reader.NameTable.Add(@"one-of");
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
            ((XmlSerializationWriter1)writer).Write37_VoiceCommands(objectToSerialize, this.DefaultNamespace, @"http://schemas.microsoft.com/voicecommands/1.2");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read37_VoiceCommands(this.DefaultNamespace);
        }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public sealed class GrammarSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"grammar", this.DefaultNamespace ?? @"http://www.w3.org/2001/06/grammar");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write38_grammar(objectToSerialize, this.DefaultNamespace, @"http://www.w3.org/2001/06/grammar");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read38_grammar(this.DefaultNamespace);
        }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public sealed class AppSettingsSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"AppSettings", this.DefaultNamespace ?? @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write39_AppSettings(objectToSerialize, this.DefaultNamespace, @"");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read39_AppSettings(this.DefaultNamespace);
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
                    _tmp[@"PiStudio.Win10.Voice.Commands.VoiceCommands:http://schemas.microsoft.com/voicecommands/1.2:VoiceCommands:True:"] = @"Read37_VoiceCommands";
                    _tmp[@"PiStudio.Win10.Voice.Srgs.Grammar:http://www.w3.org/2001/06/grammar:grammar:True:"] = @"Read38_grammar";
                    _tmp[@"PiStudio.Shared.AppSettings::"] = @"Read39_AppSettings";
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
                    _tmp[@"PiStudio.Win10.Voice.Commands.VoiceCommands:http://schemas.microsoft.com/voicecommands/1.2:VoiceCommands:True:"] = @"Write37_VoiceCommands";
                    _tmp[@"PiStudio.Win10.Voice.Srgs.Grammar:http://www.w3.org/2001/06/grammar:grammar:True:"] = @"Write38_grammar";
                    _tmp[@"PiStudio.Shared.AppSettings::"] = @"Write39_AppSettings";
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
                    _tmp.Add(@"PiStudio.Shared.AppSettings::", new AppSettingsSerializer());
                    _tmp.Add(@"PiStudio.Win10.Voice.Commands.VoiceCommands:http://schemas.microsoft.com/voicecommands/1.2:VoiceCommands:True:", new VoiceCommandsSerializer());
                    _tmp.Add(@"PiStudio.Win10.Voice.Srgs.Grammar:http://www.w3.org/2001/06/grammar:grammar:True:", new GrammarSerializer());
                    if (typedSerializers == null) typedSerializers = _tmp;
                }
                return typedSerializers;
            }
        }
        public override System.Boolean CanSerialize(System.Type type) {
            if (type == typeof(global::PiStudio.Win10.Voice.Commands.VoiceCommands)) return true;
            if (type == typeof(global::PiStudio.Win10.Voice.Srgs.Grammar)) return true;
            if (type == typeof(global::PiStudio.Shared.AppSettings)) return true;
            if (type == typeof(global::System.Reflection.TypeInfo)) return true;
            return false;
        }
        public override System.Xml.Serialization.XmlSerializer GetSerializer(System.Type type) {
            if (type == typeof(global::PiStudio.Win10.Voice.Commands.VoiceCommands)) return new VoiceCommandsSerializer();
            if (type == typeof(global::PiStudio.Win10.Voice.Srgs.Grammar)) return new GrammarSerializer();
            if (type == typeof(global::PiStudio.Shared.AppSettings)) return new AppSettingsSerializer();
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
