using System;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Cettear.Option
{
	[Serializable()]
	public class Option_KeySetting
	{
		[XmlElement("CaptureRange")]
		public Keys CaptureRange { get; set; }

		[XmlElement("CaptureRangeShow")]
		public Keys CaptureRangeShow { get; set; }

		[XmlElement("CaptureOCR")]
		public Keys CaptureOCR { get; set; }

	}
}
