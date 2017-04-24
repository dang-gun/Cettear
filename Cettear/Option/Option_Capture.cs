using System;
using System.Drawing;
using System.Xml.Serialization;

namespace Cettear.Option
{
	[Serializable()]
	public class Option_Capture
	{
		/// <summary>
		/// 캡처 시작 위치
		/// </summary>
		[XmlElement("CaptureRect01")]
		public Rectangle CaptureRect01;

		public Option_Capture()
		{
			this.CaptureRect01 = Rectangle.Empty;
		}
	}
}
