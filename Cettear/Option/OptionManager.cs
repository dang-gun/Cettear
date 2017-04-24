using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DGU_File;
using Global.FixString;
namespace Cettear.Option
{
	public class OptionManager
	{
		private readonly string Dir_Capture;
		private readonly string Dir_Google;
		public readonly string Dir_GoogleServiceFile;

		private readonly string Dir_KeySetting;


		/// <summary>
		/// xml 파일 처리기
		/// </summary>
		private DGU_File_Xml m_Xml = new DGU_File_Xml();

		/// <summary>
		/// 캡쳐 정보
		/// </summary>
		public Option_Capture Capture { get; set; }
		/// <summary>
		/// 구글 정보
		/// </summary>
		public Option_Google Google { get; set;}

		/// <summary>
		/// 키 세팅
		/// </summary>
		public Option_KeySetting KeySetting { get; set; }


		public OptionManager()
		{
			//폴더가 있는지 확인
			Directory.CreateDirectory(FileDir.Dir_Option);

			//파일경로
			this.Dir_Capture = FileDir.Dir_Option + "Capture.xml";
			this.Dir_Google = FileDir.Dir_Option + "Google.xml";
			this.Dir_GoogleServiceFile = FileDir.Dir_Option + "GoogleServiceKey.json";

			this.Dir_KeySetting = FileDir.Dir_Option + "KeySetting.xml";

			//캡쳐 정보 ***********************
			this.Capture = (Option_Capture)this.m_Xml.Load(typeof(Option_Capture)
															, this.Dir_Capture);
			if (null == this.Capture)
			{//옵션 파일이 없다.
			 //파일을 생성해 준다.
				Capture = new Option_Capture();
				this.m_Xml.Save(Capture, this.Dir_Capture);
			}

			//구글 정보 *************************
			this.Google = (Option_Google)this.m_Xml.Load(typeof(Option_Google)
															, this.Dir_Google);
			if (null == this.Google)
			{//옵션 파일이 없다.
			 //파일을 생성해 준다.
				this.Google = new Option_Google();
				this.m_Xml.Save(this.Google, this.Dir_Google);
			}

			//구글 서비스키 확인
			this.Check_GoogleServiceFile();

			//키세팅 정보 *************************
			this.KeySetting = (Option_KeySetting)this.m_Xml.Load(typeof(Option_KeySetting)
															, this.Dir_KeySetting);
			if (null == this.KeySetting)
			{//옵션 파일이 없다.
			 //파일을 생성해 준다.
				this.KeySetting = new Option_KeySetting();
				//기본키 지정
				this.KeySetting.CaptureRange = System.Windows.Forms.Keys.F2;
				this.KeySetting.CaptureRangeShow = System.Windows.Forms.Keys.F3;
				this.KeySetting.CaptureOCR = System.Windows.Forms.Keys.F4;
				//저장
				this.m_Xml.Save(this.KeySetting, this.Dir_KeySetting);
			}
		}

		/// <summary>
		/// 캡쳐 정보 저장
		/// </summary>
		public void Save_Capture()
		{
			this.m_Xml.Save(this.Capture, this.Dir_Capture);
		}

		/// <summary>
		/// 구글 정보 저장
		/// </summary>
		public void Save_Google()
		{
			this.m_Xml.Save(this.Google, this.Dir_Google);
		}

		/// <summary>
		/// 구글 서비스키 파일을 옵션폴더에 복사한다.
		/// </summary>
		/// <param name="sOriDir"></param>
		public void Save_GoogleServiceFile(string sOriDir)
		{
			//파일을 저장한다.
			File.Copy(sOriDir, this.Dir_GoogleServiceFile, true);
		}

		/// <summary>
		/// 구글 서비스키 파일이 있는지 확인
		/// </summary>
		public void Check_GoogleServiceFile()
		{
			this.Google.ServiceKeyFile = File.Exists(this.Dir_GoogleServiceFile);
		}

	}
}
