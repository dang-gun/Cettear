using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Utility;

using Cettear.OCR;
using Cettear.Option;

namespace Cettear.Global
{
	public static class Global_Cetterar
	{
		/// <summary>
		/// 스크린샷 유틸
		/// </summary>
		public static ScreenShot Util_ScreenShot = new ScreenShot();

		public static globalKeyboardHook Util_KeyHook = new globalKeyboardHook();


		/// <summary>
		/// 전체화면을 감쌀 폼
		/// </summary>
		public static frmScreen FormScreen;

		/// <summary>
		/// 캡처할 범위.
		/// 접근 위치가 너무 단계가 많아서 만듬.
		/// 하지만 변수가 아니여서 하위 요소들 대입이 안된다.
		/// </summary>
		public static Rectangle CaptureRect01
		{
			get
			{
				return OptionMgr.Capture.CaptureRect01;
			}
			set
			{
				OptionMgr.Capture.CaptureRect01 = value;
			}
		}

		/// <summary>
		/// 옵션 메니저.
		/// 파일에 저장될 옵션은 이 클래스에서 관리되어야 합니다.
		/// </summary>
		public static OptionManager OptionMgr = new OptionManager();

		/// <summary>
		/// OCR관리자
		/// </summary>
		public static OCRManager OCRMgr = new OCRManager();

		/// <summary>
		/// 생성자
		/// </summary>
		static Global_Cetterar()
		{
			////스크린폼 초기화
			FormScreen = new frmScreen();
			FormScreen.Bounds = Screen.PrimaryScreen.Bounds;
		}
	}
}
