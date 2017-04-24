using System;
using System.Xml.Serialization;

namespace Cettear.Option
{
	[Serializable()]
	public class Option_Google
	{
		/// <summary>
		/// API 키
		/// </summary>
		[XmlElement("APIKey")]
		public string APIKey { get; set; }

		/// <summary>
		/// 서비스 키 파일 경로
		/// </summary>
		[XmlElement("ServiceKeyFilePath")]
		public string ServiceKeyFilePath { get; set; }

		/// <summary>
		/// 서비스 키 파일 로드 여부
		/// </summary>
		public bool ServiceKeyFile { get; set; }


		public Option_Google()
		{
			this.APIKey = string.Empty;
			this.ServiceKeyFilePath = string.Empty;
		}
	}
}
