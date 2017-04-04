using PiStudio.Win10.Voice.Commands;
using PiStudio.Win10.Voice.Srgs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Windows.Storage;

namespace PiStudio.Win10.Voice.Navigation
{
    public static class SpeechRecognitionManager
    {
        // TODO:
        // meta data serialization namespaces I DO NOT KNOW HOW TO DO IT

        /// <summary>
        /// Validates <see cref="VoiceCommands"/>.
        /// </summary>
        /// <param name="commands"><see cref="VoiceCommands"/> to validate.</param>
        /// <returns><see cref="List{string}"/> of errors. If Count of list is 0 then there are no errors.</returns>
        public static List<string> ValidateVoiceCommands(VoiceCommands commands)
        {
            List<string> errors = new List<string>();
            var languages = commands.CommandSets.Select(i => i.Language);
            bool isLangUnique = languages.Distinct().Count() == languages.Count();
            if (!isLangUnique)
                throw new GrammarException("Every CommandSet must have unique language !");

            foreach (var commandSet in commands.CommandSets)
            {
                errors.AddRange(ValidateCommandSet(commandSet));
            }

            return errors;
        }

        /// <summary>
        /// Validates given <see cref="CommandSet"/>.
        /// </summary>
        /// <param name="set"><see cref="CommandSet"/> to validate.</param>
        /// <returns><see cref="List{string}"/> of errors. If Count of list is 0 then there are no errors.</returns>
        public static List<string> ValidateCommandSet(CommandSet set)
        {
            List<string> errors = new List<string>();
            if (string.IsNullOrWhiteSpace(set.Example))
                errors.Add("Example element can not be empty! Please fill CommandSet.Example value...");
            if (string.IsNullOrWhiteSpace(set.Language))
                errors.Add("Language element can not be empty! Please fill CommandSet.Language value...");
            if (string.IsNullOrWhiteSpace(set.Name))
                errors.Add("Name element can not be empty! Please fill CommandSet.Name value...");
            if (set.Prefix == null)
                errors.Add("Prefix missing (is null)! Please fill CommandSet.Prefix value with empty string if you dont want any prefix...");
            if (set.Commands.Count == 0)
                errors.Add("CommandSet must contain at least one command! Please add Commands to CommandSet.Commands...");

            foreach (var command in set.Commands)
            {
                if (string.IsNullOrWhiteSpace(command.Name))
                    errors.Add(string.Format("Name element can not be empty! Please fill Name element of {0}. command", set.Commands.IndexOf(command)));
                if (string.IsNullOrWhiteSpace(command.Example))
                    errors.Add(string.Format("Example element can not be empty! Please fill Example element of {0} command...", command.Name));
                if (command.ListenFor.Count == 0)
                    errors.Add(string.Format("Command must have at least one ListenFor element ! Please add ListenFor to Command.ListenFor list of {0} command...", command.Name));
                if (command.VoiceAction == null)
                    errors.Add(string.Format("VoiceAction can not be null ! Please assign VoiceAction element of {0} command to one of the available actions...", command.Name));

                int i = 0;
                foreach (var listen in command.ListenFor)
                {
                    if (string.IsNullOrWhiteSpace(listen.Content))
                        errors.Add(string.Format("ListenFor element can not be empty ! Please fill ListenFor.Content of {0}th item in {1} command ListenFor list...", i, command.Name));

                    if (listen.RequireAppName == AppNameRequirement.ExplicitlySpecified && !listen.Content.Contains("{builtin:AppName}"))
                        errors.Add(@"ListenFor.RequireAppName is equal to AppNameRequirement.ExplicitlySpecified 
                                                     but ListenFor.Content does not contains {builtin:AppName} phrase! Consider inserting the phrase or changing RequireAppName property.
                                                     Error in " + command.Name + " command, " + i + "th item of Command.ListenFor list...");
                    if (!CheckBrackets(listen.Content))
                    {
                        errors.Add(string.Format(@"Brackets inside content of {0}th item in {1} command ListenFor list are not properly closed, are nested or are not in correct format.
                                                   Correct format is that brackets can not be nested. Brackets types allowed: '{', '}', '[', ']'. '[]' brackets wraps optional words,
                                                   '{}' brackets wraps references to phrase lists or phrase topics."));
                    }
                    i++;
                }
            }

            bool nullLabel = false;
            bool nullItem = false;
            foreach (var list in set.PhraseLists)
            {
                if (string.IsNullOrWhiteSpace(list.Label))
                    nullLabel = true;
                foreach (var item in list.Items)
                    if (string.IsNullOrWhiteSpace(item.Content))
                        nullItem = true;
            }

            if (nullLabel)
                errors.Add("Label of every phrase list can not be null or whitespace !");
            if (nullItem)
                errors.Add("PhraseList can not contains items that are null or empty !");

            nullLabel = false;
            foreach (var topics in set.PhraseTopics)
            {
                if (string.IsNullOrWhiteSpace(topics.Label))
                    nullLabel = true;
            }

            if (nullLabel)
                errors.Add("Label of every phrase topics can not be null or whitespace !");

            return errors;
        }

        // Checks whether are all brackets in correct format
        private static bool CheckBrackets(string input)
        {
            char lastBracket = ' ';
            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] == '{' || input[i] == '['))
                {
                    if (lastBracket != ' ')
                        return false;
                    lastBracket = input[i];

                }
                else if (input[i] == '}' || input[i] == ']')
                {
                    if (lastBracket == ' ')
                        return false;
                    if (input[i] == '}')
                        if (lastBracket != '{')
                            return false;
                    if (input[i] == ']')
                        if (lastBracket != '[')
                            return false;
                    lastBracket = ' ';
                }
            }
            return true;
        }

        /// <summary>
        /// Validates grammar whether is in correct format or have correct content.
        /// </summary>
        /// <param name="grammar"><see cref="Grammar"/> to validate.</param>
        /// <returns><see cref="List{String}"/> of errors. If Count of list is 0 then there are no errors.</returns>
        public static List<string> ValidateGrammar(Grammar grammar)
        {
            if (grammar == null)
                throw new ArgumentNullException();
            m_tmpG = grammar;
            List<string> errors = new List<string>();
            if (!IsUnique(grammar.Rules))
                errors.Add("All rules ids must be unique !");
            if (grammar.RootRule == null)
                errors.Add("Root rule can not be null !");
            if (string.IsNullOrWhiteSpace(grammar.Language))
                errors.Add("Language can not be null or white space !");
            if (grammar.TagFormat != Grammar.Semantics.MicrosoftSemanticTagFormat && grammar.TagFormat != Grammar.Semantics.StandardSemanticTagFormat)
                errors.Add("Semantics is not one of two allowed values !");
            foreach(var rule in grammar.Rules)
            {
                if (!string.IsNullOrWhiteSpace(rule.Content))
                    errors.Add("Warning: It is not recommended to write text directly inside rule element ! This is probably SRG not generated by program... Consider wrapping text into <item> element");
                if (string.IsNullOrWhiteSpace(rule.Id))
                    errors.Add("Rule id can not be null or white space !");
                if (rule.Scope != RuleScope.PrivateScope && rule.Scope != RuleScope.PublicScope && !string.IsNullOrEmpty(rule.Scope))
                    errors.Add("Invalid value in Rule.Scope. Valid values are 'public' and 'private'. If no value is specificated than 'private' is set.");
                ValidateElementsRecursive(rule.Elements, errors);
            }
            return errors;
        }

        private static Grammar m_tmpG;

		//checks whether are all items in collection unique
        private static bool IsUnique(IEnumerable<Rule> collection)
        {
            return collection.Select(i => i.Id).Distinct().Count() == collection.Count();
        }

		//recursively validates all elements
        private static void ValidateElementsRecursive(List<RuleItem> elements, List<string> errors)
        {
            foreach(var element in elements)
            {
                if(element is Token)
                {
                    var token = (Token)element;
                    if (string.IsNullOrWhiteSpace(token.Text))
                        errors.Add("Token element can not be empty. It makes no sense..");                    
                }
                else if(element is OneOf)
                {
                    var oneof = (OneOf)element;
                    ValidateElementsRecursive(oneof.Items.Select(i => (RuleItem)i).ToList(), errors);
                }
                else if(element is RuleRef)
                {
                    var ruleRef = (RuleRef)element;
                    if(ruleRef.Special != RuleRef.SpecialGARBAGE && ruleRef.Special != RuleRef.SpecialNULL && ruleRef.Special != RuleRef.SpecialVOID && !string.IsNullOrEmpty(ruleRef.Special))
                    {
                        errors.Add("RuleRef.Special has incorrect value. Only 'VOID', 'NULL' or 'GARBAGE' are accepted.");
                    }
                    if(string.IsNullOrEmpty(ruleRef.Uri) && string.IsNullOrEmpty(ruleRef.Special))
                    {
                        errors.Add("RuleRef.Uri can be empty only if RuleRef.Special is set...");
                    }
                    if(!m_tmpG.Rules.Contains(ruleRef.Reference) && ruleRef.Reference != null)
                    {
                        errors.Add("Incorrect reference in RuleRef element");
                    }
                }
                else if(element is Tag)
                {
                    var tag = (Tag)element;
                    if (string.IsNullOrWhiteSpace(tag.Content))
                        errors.Add("Tag element can not be empty..");
                }
                else if(element is Item)
                {
                    var item = (Item)element;
                    if (string.IsNullOrEmpty(item.Content) && item.Elements.Count == 0)
                        errors.Add("Content of item can not be empty. It makes no sense ");
                    ValidateElementsRecursive(item.Elements, errors);
                }
            }
        }

        /// <summary>
        /// Loads <see cref="VoiceCommands"/> from given <see cref="StorageFile"/> asynchronously.
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Loaded <see cref="VoiceCommands"/></returns>
        public static async Task<VoiceCommands> LoadCommandsFromFileAsync(StorageFile file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(VoiceCommands));

            var stream = await file.OpenStreamForReadAsync();
            XmlReader reader = XmlReader.Create(stream);
            if (serializer.CanDeserialize(reader))
            {
                VoiceCommands commands = (VoiceCommands)serializer.Deserialize(reader);
                return commands;
            }
            return null;
        }

		/// <summary>
		/// Loads <see cref="VoiceCommands"/> from given filepath.
		/// </summary>
		/// <param name="path"></param>
		/// <returns>Loaded <see cref="VoiceCommands"/></returns>
		public static VoiceCommands LoadCommandsFromFile(string path)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(VoiceCommands));

			var stream = File.OpenRead(path);
			XmlReader reader = XmlReader.Create(stream);
			if (serializer.CanDeserialize(reader))
			{
				VoiceCommands commands = (VoiceCommands)serializer.Deserialize(reader);
				return commands;
			}
			return null;
		}

        /// <summary>
        /// Compiles <see cref="CommandSet"/> into <see cref="Grammar"/> object.
        /// </summary>
        /// <param name="commands">Commands to compile.</param>
        /// <param name="useTags">Indicates whether use Tags that will fill SemanticsInterpretation properties.</param>
        /// <param name="createMetadata">Indicates whether creates Metadata that describe authors and this document.</param>
        /// <returns>Compiled <see cref="Grammar"/></returns>
        public static Grammar CompileGrammar(CommandSet commands, bool useTags = true)
        {
            var errorList = ValidateCommandSet(commands);
			if (errorList.Count != 0)
				foreach (var item in errorList)
					throw new GrammarException(item);

            Grammar grammar = new Grammar();
            grammar.Language = commands.Language;
            grammar.TagFormat = Grammar.Semantics.StandardSemanticTagFormat;
            grammar.Encoding = Encoding.UTF8;

            Rule rootRule = new Rule(commands.Name);
            rootRule.Scope = RuleScope.PublicScope;

            OneOf oneOfCommands = new OneOf();

            foreach (var phraseList in commands.PhraseLists)
            {
                Rule listRule = new Rule(phraseList.Label);
                OneOf oneOfList = new OneOf(phraseList.Items.Select(i =>
                {
                    //i.Content = Regex.Replace(i.Content, @"\s+", "");
                    var item = new Item(i.Content);
                    if (useTags)
                    {
                        string display = i.Display == null ? i.Content : i.Display;
                        item.Elements.Add(new Tag(grammar.TagFormat, @"""" + display + @""""));
                    }
                    return item;
                }));
                if (oneOfList.Items.Count == 0)
                    oneOfList.Items.Add(new Item("null"));
                listRule.Elements.Add(oneOfList);
                if (phraseList.Items.Count > 0)
                    listRule.Examples.Add(new Example(phraseList.Items[0].Content));
                
                grammar.Rules.Add(listRule);
            }

            foreach (var command in commands.Commands)
            {
                Rule rule = new Rule(command.Name);
                Item wrapper = new Item();
                Tag returnTag = new Tag(grammar.TagFormat, "RecognizedCommand", @"""" + command.Name + @"""");
                Tag returnTag2 = new Tag(grammar.TagFormat, command.Name, "rules." + command.Name);
                rule.Examples.Add(new Example(command.Example));
                OneOf oneOfListenFor = new OneOf();

                for (int i = 0; i < command.ListenFor.Count; i++)
                {
                    var listenFor = command.ListenFor[i];
                    if (listenFor.RequireAppName == AppNameRequirement.BeforeOrAfterPhrase)
                    {
                        listenFor.RequireAppName = AppNameRequirement.BeforePhrase;
                        command.ListenFor.Add(new ListenFor()
                        {
                            Content = listenFor.Content,
                            RequireAppName = AppNameRequirement.AfterPhrase,
                        });
                    }
                }

                foreach (var listenFor in command.ListenFor)
                {
                    Item listenForItem = new Item();

                    if (listenFor.RequireAppName == AppNameRequirement.BeforePhrase && !string.IsNullOrWhiteSpace(commands.Prefix.Content))
                        listenForItem.Elements.Add(new Item(commands.Prefix.Content));

                    string tmp = listenFor.Content;
                    tmp = tmp.TrimStart(' ');
                    tmp = tmp.TrimEnd(' ');
                    while (tmp.Length > 1 && ((tmp.IndexOf('{') != -1 && tmp.IndexOf('{') + 1 != tmp.Length) || (tmp.IndexOf('[') != -1 && tmp.IndexOf('[') + 1 != tmp.Length)))
                    {
                        int indexOfCurlyBracket = tmp.IndexOf('{');
                        if (indexOfCurlyBracket == -1)
                            indexOfCurlyBracket = int.MaxValue;

                        int indexOfSquareBracket = tmp.IndexOf('[');
                        if (indexOfSquareBracket == -1)
                            indexOfSquareBracket = int.MaxValue;

                        if (indexOfSquareBracket < indexOfCurlyBracket)
                        {
                            string text = tmp.Substring(0, indexOfSquareBracket - 1);
                            tmp = tmp.Substring(indexOfSquareBracket + 1);
                            if (tmp.IndexOf(']') == -1)
                                throw new GrammarException("Deklaration of optional word error. Missing ']'");
                            string optional = tmp.Substring(0, tmp.IndexOf(']'));
                            tmp = tmp.Substring(tmp.IndexOf(']') + 1);
                            if (!string.IsNullOrWhiteSpace(text))
                            {
                                Item mustSayItem = new Item(text);
                                listenForItem.Elements.Add(mustSayItem);
                            }

                            if(optional.Replace(" ", "") == "...")
                            {
                                RuleRef ruleRef = new RuleRef(RuleRef.SpecialGARBAGE);
                                listenForItem.Elements.Add(ruleRef);
                            }
                            else if (!string.IsNullOrWhiteSpace(optional))
                            {
                                Item optionalItem = new Item(optional, Item.ItemRepeat.Optional);
                                listenForItem.Elements.Add(optionalItem);
                            }
                            else
                                throw new GrammarException("Text inside '[ ]' brackets can not be white space");
                        }
                        else
                        {
                            string text = null;
                            if(indexOfCurlyBracket > 0)
                                text = tmp.Substring(0, indexOfCurlyBracket - 1);
                            tmp = tmp.Substring(indexOfCurlyBracket + 1);
                            if (tmp.IndexOf('}') == -1)
                                throw new GrammarException("Phrase topics or list reference was not properly closed. Missing '}'");
                            string optional = tmp.Substring(0, tmp.IndexOf('}'));
                            tmp = tmp.Substring(tmp.IndexOf('}') + 1);
                            if (!string.IsNullOrWhiteSpace(text))
                            {
                                Item mustSayItem = new Item(text);
                                listenForItem.Elements.Add(mustSayItem);
                            }

                            if (optional == "*")
                            {
                                listenForItem.Elements.Add(new RuleRef(RuleRef.SpecialGARBAGE));
                                if (useTags)
                                    listenForItem.Elements.Add(new Tag(grammar.TagFormat, "\"...\""));
                            }
                            else if (optional == "builtin:AppName")
                            {
                                AppName appName = commands.Prefix as AppName;
                                if (appName != null && listenFor.RequireAppName == AppNameRequirement.ExplicitlySpecified && !string.IsNullOrWhiteSpace(commands.Prefix.Content))
                                {
                                    Item appNameItem = new Item(appName.Content);
                                    listenForItem.Elements.Add(appNameItem);
                                }
                                else
                                    throw new GrammarException(@"ListenFor content contains {builtin:AppName} but RequireAppName property is not equal to 'ExplicitlySpecified' 
                                                                 or prefix of CommandSet is not AppName...");
                            }
                            else if (!string.IsNullOrWhiteSpace(optional))
                            {
                                PhraseList list = commands.PhraseLists.Where(i => i.Label == optional).FirstOrDefault();

                                if (list != null)
                                {
                                    Rule listRule = grammar.Rules.Where(i => i.Id == list.Label).FirstOrDefault();
                                    listenForItem.Elements.Add(new RuleRef(listRule));
                                    if (useTags)
                                        listenForItem.Elements.Add(new Tag(grammar.TagFormat, listRule.Id, "rules." + listRule.Id));
                                }
                                else
                                {
                                    PhraseTopic topics = commands.PhraseTopics.Where(i => i.Label == optional).FirstOrDefault();

                                    if (topics != null)
                                    {
                                        throw new GrammarException("PhraseTopics is not supported..");

                                        var ruleref = new RuleRef();
                                        ruleref.Uri = @"sapi:grammar#dictation";
                                        ruleref.Type = "application/srgs+xml";
                                        listenForItem.Elements.Add(ruleref);
                                        if (useTags)
                                            listenForItem.Elements.Add(new Tag(grammar.TagFormat, topics.Label, Tag.Latest));
                                    }
                                    else
                                        throw new GrammarException(string.Format("You are referencing '{0}' but CommandSet does not contains definition for it. Try Define Phrase list or topics first !", optional));
                                }

                            }
                            else
                                throw new GrammarException("Text inside '{ ... }' brackets can not be white space");

                        }
                    }
                    if (listenFor.RequireAppName == AppNameRequirement.AfterPhrase && !string.IsNullOrWhiteSpace(commands.Prefix.Content))
                    {
                        OneOf oneOfAfterPhrase = new OneOf(new Item[]
                        {
                            new Item("In"),
                            new Item("On"),
                            new Item("Using"),
                            new Item("With")
                        });
                        listenForItem.Elements.Add(oneOfAfterPhrase);
                        listenForItem.Elements.Add(new Item(commands.Prefix.Content));
                    }
					if (listenForItem.Elements.Count == 0 && string.IsNullOrWhiteSpace(listenForItem.Content))
						listenForItem.Content = tmp;
                    oneOfListenFor.Items.Add(listenForItem);
                }
                rule.Elements.Add(oneOfListenFor);
                wrapper.Elements.Add(new RuleRef(rule));
                if (useTags)
                {
                    wrapper.Elements.Add(returnTag);
                    wrapper.Elements.Add(returnTag2);
                }
                grammar.Rules.Add(rule);

                oneOfCommands.Items.Add(wrapper);
            }

            rootRule.Examples.Add(new Example(commands.Example));
            rootRule.Elements.Add(oneOfCommands);

            grammar.Rules.Add(rootRule);
            grammar.RootRule = rootRule;

            return grammar;
        }

        /// <summary>
        /// Set options to <see cref="PhraseList"/> saved in given file
        /// </summary>
        /// <param name="file">VCD file that contains CommandSet with <see cref="PhraseList"/> with given name or <see cref="Grammar"/> file</param>
        /// <param name="phraseListName">name of the <see cref="PhraseList"/></param>
        /// <param name="values">values to add to <see cref="PhraseList"/></param>
        /// <param name="clearOldValues">Indicates whether old values will be cleared</param>
        public static async Task SetPhraseListAsync(StorageFile file, string phraseListName, IEnumerable<string> values, SpeechRecognitionType type, bool clearOldValues = true)
        {
            if (type == SpeechRecognitionType.InAppSpeechRecognition)
            {
                Grammar grammar = await LoadGrammarFromFileAsync(file);
				if (grammar == null)
					throw new System.Runtime.Serialization.SerializationException("Given file cound not be deserialized. It contains wrong grammar.");
				SetPhraseList(grammar, phraseListName, values, clearOldValues);
                SaveGrammarToFile(file, grammar);
            }
            else
            {
                VoiceCommands commands = await LoadCommandsFromFileAsync(file);
                if (commands == null)
                    throw new System.Runtime.Serialization.SerializationException("File content is probably incorrect and could not be deserialized.. Check VCD reference for correct format...");
                SetPhraseList(commands, phraseListName, values, clearOldValues);
                SaveVoiceCommandsToFile(file, commands);
            }
        }

        /// <summary>
        /// Serialize given commands to <see cref="StorageFile"/> file
        /// </summary>
        /// <param name="file">file where should be <see cref="VoiceCommands"/> saved.</param>
        /// <param name="commands">Commands that will be serialized</param>
        public static void SaveVoiceCommandsToFile(StorageFile file, VoiceCommands commands)
        {
            FileInfo info = new FileInfo(file.Path);

            using (var streamWriter = new StreamWriter(info.Open(FileMode.Truncate)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(VoiceCommands));
                serializer.Serialize(streamWriter, commands);
            }
        }

        /// <summary>
        /// Adds options to <see cref="PhraseList"/>
        /// </summary>
        /// <param name="grammar"><see cref="Grammar"/> that contains <see cref="Rule"/> with phraseListName </param>
        /// <param name="phraseListName"><see cref="Rule"/> to which will be items add</param>
        /// <param name="values">values to add</param>
        /// <param name="clearOldValues">Indicates whether old values will be cleared</param>
        public static void SetPhraseList(Grammar grammar, string phraseListName, IEnumerable<string> values, bool clearOldValues = true)
        {
            var phraseRule = grammar.Rules.Where(i => i.Id == phraseListName).FirstOrDefault();
            if (phraseRule != null)
            {
                if (phraseRule.Elements.Count == 0)
                    throw new ArgumentException("Grammar was modified or not created by SpeechRecognitionManager...");

                var oneOf = phraseRule.Elements[0] as OneOf;
                if (oneOf != null)
                {
                    var collectionItems = values.Select(i =>
                    {
                        var item = new Item(i);
                        item.Elements.Add(new Tag(grammar.TagFormat, @"""" + i + @""""));
                        return item;
                    });

                    if (clearOldValues)
                        oneOf.Items.Clear();

                    oneOf.Items.AddRange(collectionItems);
                }
                else
                    throw new ArgumentException("Grammar was modified or not created by SpeechRecognitionManager...");
            }
            else
                throw new ArgumentException("Grammar does not contains phrase list with name " + phraseListName + ".");
        }

        /// <summary>
        /// Adds options to <see cref="PhraseList"/>
        /// </summary>
        /// <param name="commandSet"><see cref="VoiceCommands"/> that contains <see cref="PhraseList"/> with phraseListName </param>
        /// <param name="phraseListName"><see cref="PhraseList"/> to which will be items add</param>
        /// <param name="values">values to add</param>
        /// <param name="clearOldValues">Indicates whether old values will be cleared</param>
        public static void SetPhraseList(VoiceCommands voiceCommands, string phraseListName, IEnumerable<string> values, bool clearOldValues = true)
        {
            PhraseList phraseList = null;

            foreach (var commandSet in voiceCommands.CommandSets)
            {
                var tmp = commandSet.PhraseLists.Where(i => i.Label == phraseListName).FirstOrDefault();
                if(tmp != null)
                {
                    phraseList = tmp;
                    break;
                }
            }

            if (phraseList != null)
            {
                if (clearOldValues)
                    phraseList.Items.Clear();
                else
                {
                    var item = phraseList.Items.First(i => i.Content.Contains("null"));
                    if(item != null)
                        phraseList.Items.Remove(item);
                }
                phraseList.Items.AddRange(values.Select(i => new ListItem(i)));
            }
            else
                throw new ArgumentException("CommandSet does not contains phrase list with name " + phraseListName + ".");
        }

        /// <summary>
        /// Serializes grammar into file given as argument
        /// </summary>
        /// <param name="filepath">where should be file stored plus filename</param>
        /// <param name="grammar">grammar that will be serialized</param>
        public static void SaveGrammarToFile(string filepath, Grammar grammar)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Grammar));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            //namespaces.Add("rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");
            //namespaces.Add("dc", "http://purl.org/metadata/dublin_core#");
            namespaces.Add("sapi", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions");
            //namespaces.Add("xds", "http://www.w3.org/2001/06/grammar");

            using (var streamWriter = new System.IO.StreamWriter(File.Create(filepath), grammar.Encoding))
            {
                serializer.Serialize(streamWriter, grammar, namespaces);
            }
        }

        /// <summary>
        /// Saves grammar into file given as argument
        /// </summary>
        /// <param name="file">File where will be grammar stored.</param>
        /// <param name="grammar">grammar that will be serialized into <see cref="StorageFile"/></param>
        /// <returns></returns>
        public static void SaveGrammarToFile(StorageFile file, Grammar grammar)
        {
            FileInfo info = new FileInfo(file.Path);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            //namespaces.Add("rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");
            //namespaces.Add("dc", "http://purl.org/metadata/dublin_core#");
            namespaces.Add("sapi", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions");
            //namespaces.Add("xds", "http://www.w3.org/2001/06/grammar");

            using (var streamWriter = new StreamWriter(info.Open(FileMode.Truncate)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Grammar));
                serializer.Serialize(streamWriter, grammar, namespaces);
            }
        }

        /// <summary>
        /// Creates <see cref="StorageFile"/> from <see cref="Grammar"/> by serializing it
        /// </summary>
        /// <param name="grammar">grammar that will be serialized into <see cref="StorageFile"/></param>
        /// <returns><see cref="StorageFile"/></returns>
        public async static Task<StorageFile> CreateFileFromGrammarAsync(Grammar grammar)
        {
            var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(grammar.RootRule.Id + "_SRGSGrammar.grxml", CreationCollisionOption.ReplaceExisting);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            //namespaces.Add("rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");
            //namespaces.Add("dc", "http://purl.org/metadata/dublin_core#");
            namespaces.Add("sapi", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions");
            //namespaces.Add("xds", "http://www.w3.org/2001/06/grammar");

            using (var streamWriter = new StreamWriter(await file.OpenStreamForWriteAsync()))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Grammar));
                serializer.Serialize(streamWriter, grammar, namespaces);
            }

            return file;
        }

        /// <summary>
        /// Create and SRGS xml in string from given grammar
        /// </summary>
        /// <param name="grammar">grammar that will be serialized</param>
        /// <returns>xml string</returns>
        public async static Task<string> CreateStringFromGrammarAsync(Grammar grammar)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Grammar));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            //namespaces.Add("rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");
            //namespaces.Add("dc", "http://purl.org/metadata/dublin_core#");
            namespaces.Add("sapi", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions");
            //namespaces.Add("xds", "http://www.w3.org/2001/06/grammar");

            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, grammar, namespaces);
                stream.Position = 0;

                var reader = new StreamReader(stream);
                return await reader.ReadToEndAsync();
            }
        }

        /// <summary>
        /// Deserialize file into grammar object
        /// </summary>
        /// <param name="file">File containing Srgs grammar</param>
        /// <returns><see cref="Grammar"/> object representing grxml file. Returns null if can not serialize the object</returns>
        public async static Task<Grammar> LoadGrammarFromFileAsync(StorageFile file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Grammar));

            var stream = await file.OpenStreamForReadAsync();
            XmlReader reader = XmlReader.Create(stream);

            if (serializer.CanDeserialize(reader))
            {
                Grammar grammar = (Grammar)serializer.Deserialize(reader);
                DeserializeGrammar(grammar);
                return grammar;
            }

            return null;
        }

		/// <summary>
		/// Deserialize file into grammar object
		/// </summary>
		/// <param name="path">Path to file containing Srgs grammar</param>
		/// <returns><see cref="Grammar"/> object representing grxml file. Returns null if can not serialize the object</returns>
		public static Grammar LoadGrammarFromFilePath(string path)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Grammar));

			var stream = File.OpenRead(path);
			XmlReader reader = XmlReader.Create(stream);

			if (serializer.CanDeserialize(reader))
			{
				Grammar grammar = (Grammar)serializer.Deserialize(reader);
				DeserializeGrammar(grammar);
				return grammar;
			}

			return null;
		}

        /// <summary>
        /// Creates <see cref="Grammar"/> object from given xml string by deserializing it
        /// </summary>
        /// <param name="srgsString">xml string in srgs format</param>
        /// <param name="encoding">encoding of the string</param>
        /// <returns>null if can not serialize the object</returns>
        public static Grammar LoadGrammarFromString(string srgsString, Encoding encoding)
        {
            byte[] buffer = encoding.GetBytes(srgsString);
            var stream = new MemoryStream(buffer);
            XmlReader reader = XmlReader.Create(stream);
            XmlSerializer serializer = new XmlSerializer(typeof(Grammar));

            if (serializer.CanDeserialize(reader))
            {
                Grammar grammar = (Grammar)serializer.Deserialize(reader);
                DeserializeGrammar(grammar);
                return grammar;
            }

            return null;
        }

        // Do work that serializer can not.
        private static void DeserializeGrammar(Grammar g)
        {
            g.RootRule = g.Rules.Where(i => i.Id == g.Root).FirstOrDefault();
            foreach (var rule in g.Rules)
            {
                SetReferenceRecursive(rule.Elements, g);
            }
        }

        // Sets reference of ruleref to specific rule
        private static void SetReferenceRecursive(List<RuleItem> items, Grammar g)
        {
            foreach (var item in items)
            {
                if (item is RuleRef)
                {
                    var tmp = ((RuleRef)item);
                    if(!string.IsNullOrEmpty(tmp.Uri))
                        tmp.Reference = g.Rules.Where(i => i.Id == tmp.Uri.Substring(1)).FirstOrDefault();
                }
                else if (item is Item)
                {
                    SetReferenceRecursive(((Item)item).Elements, g);
                }
                else if (item is OneOf)
                {
                    foreach (var i in ((OneOf)item).Items)
                        SetReferenceRecursive(i.Elements, g);
                }
            }
        }

	/// <summary>
	/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/// TESTS
	/// </summary>
        public async static Task<StorageFile> Test()
        {
            Grammar g = new Grammar();
            g.Encoding = Encoding.UTF8;
            g.TagFormat = Grammar.Semantics.StandardSemanticTagFormat;

            var Card = new Rule("Card");
            Card.Examples.AddRange(new Example[]
            {
                new Example("Red Queen"),
                new Example("Black Queen"),
                new Example("Jack Of Clubs"),
            });
            Card.Elements.AddRange(new Item[]
            {
                new Item("Red Queen"),
                new Item("Black Queen"),
                new Item("Jack Of Clubs")
            });

            var PlayCard = new Rule("PlayCard");
            PlayCard.Examples.AddRange(new Example[]
            {
                new Example("please play the red queen"),
                new Example("play the ace"),
                new Example("play the five of diamonds please")
            });
            var itemPlease = new Item("please");
            itemPlease.SetRepeat(Item.ItemRepeat.Optional);
            PlayCard.Elements.AddRange(new RuleItem[] { itemPlease, new Item("play the"), new RuleRef(Card), new Tag(Grammar.Semantics.StandardSemanticTagFormat, "rulesCard"),
                new Item("please", Item.ItemRepeat.Optional)});

            var MoveCard = new Rule("MoveCard");
            MoveCard.Examples.AddRange(new Example[] { new Example("move the five of clubs to the six of hearts"),
                                                       new Example("please put the jack of hearts on the ten of clubs") });

            var moveOneOf = new OneOf();
            moveOneOf.Items.AddRange(new Item[] { new Item("move the"), new Item("put the") });
            var moveCardItem = new Item();
            moveCardItem.SetRepeat(Item.ItemRepeat.Optional);
            var moveCardOneOf = new OneOf();
            moveCardOneOf.Items.AddRange(new Item[] { new Item("on the"), new Item("to the") });
            moveCardItem.Elements.AddRange(new RuleItem[] { moveCardOneOf, new RuleRef(Card), new Tag(Grammar.Semantics.StandardSemanticTagFormat, "ToCard", "rules.latest()") });
            MoveCard.Elements.AddRange(new RuleItem[]
            {
                new Item("please", Item.ItemRepeat.Optional),
                moveOneOf,
                new RuleRef(Card),
                new Tag(Grammar.Semantics.StandardSemanticTagFormat, "FromCard", "rules.Card"),
                moveCardItem,

            });


            var topLevel = new Rule("topLevel") { Scope = "public" };
            var oneOf = new OneOf();
            var emptyItem1 = new Item();
            var emptyItem2 = new Item();
            emptyItem1.Elements.AddRange(new RuleItem[] { new RuleRef(PlayCard), new Tag(Grammar.Semantics.StandardSemanticTagFormat) { Content = "out.Card = rules.PlayCard;" } });
            emptyItem2.Elements.AddRange(new RuleItem[] { new RuleRef(MoveCard), new Tag(Grammar.Semantics.StandardSemanticTagFormat) { Content = "out.MoveCard = rules.MoveCard;" } });
            oneOf.Items.Add(emptyItem1);
            oneOf.Items.Add(emptyItem2);

            topLevel.Elements.Add(oneOf);

            g.Rules.Add(topLevel);
            g.Rules.Add(PlayCard);
            g.Rules.Add(MoveCard);
            g.Rules.Add(Card);
            g.RootRule = topLevel;

            StorageFile file = await Windows.Storage.DownloadsFolder.CreateFileAsync("SRGSGrammar.grxml", CreationCollisionOption.GenerateUniqueName);
            SaveGrammarToFile(file, g);
            return file;
        }

        public static async Task Test2()
        {
            StorageFile file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync("Test2.grxml");
            Grammar g = await LoadGrammarFromFileAsync(file);
            DeserializeGrammar(g);
            var x = g;
            StorageFile file2 = await DownloadsFolder.CreateFileAsync("Test2out.grxml", CreationCollisionOption.GenerateUniqueName);
            SaveGrammarToFile(file2, g);
        }

        public static async Task<StorageFile> Test3(StorageFile file2)
        {
            StorageFile file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync("CortanaCustomCommands.xml");
            var voiceCommands = await LoadCommandsFromFileAsync(file);
            var grammar = CompileGrammar(voiceCommands.CommandSets[0], true);
            SaveGrammarToFile(file2, grammar);
            return file2;
        }
    }

	/// <summary>
	/// Exception that is raised after error in Grammar validation or usage
	/// </summary>
    public class GrammarException : Exception
    {
		/// <summary>
		/// Creates new instance of <see cref="GrammarException"/>
		/// </summary>
        public GrammarException()
        {
        }

		/// <summary>
		/// Creates new instance of <see cref="GrammarException"/> 
		/// </summary>
		/// <param name="message">Message displayed by exception.</param>
		public GrammarException(string message)
        : base(message)
        {
        }

		/// <summary>
		/// Creates new instance of <see cref="GrammarException"/> 
		/// </summary>
		/// <param name="message">Message displayed by exception.</param>
		/// <param name="inner">Inner exception.</param>
		public GrammarException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }

	/// <summary>
	/// Type of speech recognition
	/// </summary>
    public enum SpeechRecognitionType
    {
        InAppSpeechRecognition = 0,
        Cortana = 1
    }
}
