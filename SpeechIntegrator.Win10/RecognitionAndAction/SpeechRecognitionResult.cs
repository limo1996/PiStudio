using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.SpeechRecognition;

namespace PiStudio.Win10.Voice.Navigation
{
	/// <summary>
	/// Result of speech recognition. Wrapper to <see cref="Windows.Media.SpeechRecognition.SpeechRecognitionResult"/>.
	/// </summary>
	public class SpeechRecognitionResult
	{
		private Windows.Media.SpeechRecognition.SpeechRecognitionResult m_result;
		private Commands.VoiceCommands m_commands;

		/// <summary>
		/// Creates new instance of <see cref="SpeechRecognitionResult"/>
		/// </summary>
		/// <param name="result"><see cref="Windows.Media.SpeechRecognition.SpeechRecognitionResult"/></param>
		/// <param name="set"><see cref="CommandsLayer.VoiceCommands"/> from which was command recognized</param>
		public SpeechRecognitionResult(Windows.Media.SpeechRecognition.SpeechRecognitionResult result, Commands.VoiceCommands commands)
		{
			m_recognizedPhraseListValues = new Dictionary<string, string>();
			m_recognizedPhraseTopicsValues = new Dictionary<string, string>();
			this.m_result = result;
			if (commands != null)
			{
				this.m_commands = commands;
				RecognizedCommand = null;
				Commands.CommandSet selectedSet = null;

				foreach (var set in m_commands.CommandSets)
				{
					RecognizedCommand = set.Commands.Where(i =>
					{
						string cmd;
						if (result.SemanticInterpretation.Properties.ContainsKey("RecognizedCommand"))
							cmd = result.SemanticInterpretation.Properties["RecognizedCommand"].FirstOrDefault();
						else
						{
							cmd = result.RulePath[0];
						}
						if (cmd != null)
							return i.Name == cmd;
						return false;
					}).FirstOrDefault();

					if (RecognizedCommand != null)
					{
						selectedSet = set;
						break;
					}
				}

				if (selectedSet != null)
				{
					foreach (var key in result.SemanticInterpretation.Properties.Keys)
					{
						if (selectedSet.PhraseLists.Where(i => i.Label == key).Count() != 0)
							m_recognizedPhraseListValues.Add(key, result.SemanticInterpretation.Properties[key][0]);
						else if (selectedSet.PhraseTopics.Where(i => i.Label == key).Count() != 0)
							m_recognizedPhraseTopicsValues.Add(key, result.SemanticInterpretation.Properties[key][0]);
					}
				}
			}

			SpokenText = result.Text;
		}

		/// <summary>
		/// Creates new instance of <see cref="SpeechRecognitionResult"/>
		/// </summary>
		/// <param name="result"><see cref="Windows.Media.SpeechRecognition.SpeechRecognitionResult"/></param>
		public SpeechRecognitionResult(Windows.Media.SpeechRecognition.SpeechRecognitionResult result)
		{
			m_recognizedPhraseListValues = new Dictionary<string, string>();
			m_recognizedPhraseTopicsValues = new Dictionary<string, string>();
			this.m_result = result;
			RecognizedCommand = null;
			SpokenText = result.Text;
		}

		/// <summary>
		/// <see cref="Commands.Command"/> that was recognized in recognition.
		/// </summary>
		public Commands.Command RecognizedCommand { get; private set; }

		/// <summary>
		/// Recognized text by the recognizer.
		/// </summary>
		public string SpokenText { get; private set; }

		/// <summary>
		/// Status of the recognition. The recognition was successful only if the status is Success
		/// </summary>
		public SpeechRecognitionResultStatus Status
		{
			get
			{
				return m_result.Status;
			}
		}

		/// <summary>
		/// Raw confidance of the result.
		/// </summary>
		public double RawConfidance
		{
			get
			{
				return m_result.RawConfidence;
			}
		}

		/// <summary>
		/// Time when user starts saying the phrase
		/// </summary>
		public DateTimeOffset PhraseStartTime
		{
			get
			{
				return m_result.PhraseStartTime;
			}
		}

		/// <summary>
		/// Duration of phrase
		/// </summary>
		public TimeSpan PhraseDuration
		{
			get
			{
				return m_result.PhraseDuration;
			}
		}

		/// <summary>
		/// Confidance of the result. Can be High, Low, Medium or Rejected
		/// </summary>
		public SpeechRecognitionConfidence Confidance
		{
			get
			{
				return m_result.Confidence;
			}
		}

		/// <summary>
		/// Constrain of the <see cref="SpeechRecognizer"/>. Types are: List, Topic, Grammar or VCD
		/// </summary>
		public ISpeechRecognitionConstraint Constraint
		{
			get
			{
				return m_result.Constraint;
			}
		}

		private Dictionary<string, string> m_recognizedPhraseListValues;
		private Dictionary<string, string> m_recognizedPhraseTopicsValues;

		/// <summary>
		/// Dictionary where key is the name of the <see cref="Commands.PhraseList"/> and value is recognized item of the <see cref="Commands.PhraseList"/>
		/// </summary>
		public IReadOnlyDictionary<string, string> ReconizedPhraseListsValues
		{
			get
			{
				return m_recognizedPhraseListValues;
			}
		}

		/// <summary>
		/// Dictionary where key is the name of the <see cref="Commands.PhraseTopic"/> and value is recognized phrase that is beforehand unknown.
		/// </summary>
		public IReadOnlyDictionary<string, string> RecognizedPhraseTopicsValues
		{
			get
			{
				return m_recognizedPhraseTopicsValues;
			}
		}

		/// <summary>
		/// Gets the alternates of this command.
		/// </summary>
		/// <param name="maxAlternates">Max number of alternates.</param>
		/// <returns></returns>
		public IReadOnlyList<SpeechRecognitionResult> GetAlternates(uint maxAlternates)
		{
			List<SpeechRecognitionResult> alternates = new List<SpeechRecognitionResult>();
			foreach (var alternate in m_result.GetAlternates(maxAlternates))
			{
				if (this.m_commands != null)
					alternates.Add(new SpeechRecognitionResult(alternate, this.m_commands));
				else alternates.Add(new SpeechRecognitionResult(alternate));

			}
			return alternates;
		}
	}
}
