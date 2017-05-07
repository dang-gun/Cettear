using DGU_GoogleAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cettear.Option
{
	/// <summary>
	/// 번역 언어 지정 그룹
	/// </summary>
	public class ProcessLanguageData
	{
		/// <summary>
		/// 감지 언어
		/// </summary>
		public TypeLanguageCode OCR { get; set; }
		/// <summary>
		/// 1차 번역 언어
		/// </summary>
		public TypeLanguageCode Step1 { get; set; }
		/// <summary>
		/// 2차 번역 언어
		/// </summary>
		public TypeLanguageCode Step2 { get; set; }
	}

	[Serializable()]
	public class Option_ProcessLanguage
	{
		/// <summary>
		/// 
		/// </summary>
		[XmlElement("TranslateGroup")]
		public ProcessLanguageData TranslateGroup;

		public Option_ProcessLanguage()
		{
			//기본값 입력
			this.TranslateGroup = new ProcessLanguageData();
			this.TranslateGroup.OCR = TypeLanguageCode.en;
			this.TranslateGroup.Step1 = TypeLanguageCode.ko;
			this.TranslateGroup.Step2 = TypeLanguageCode.None;
		}
	}
}
