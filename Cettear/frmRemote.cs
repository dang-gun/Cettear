using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DGU_GoogleAPI;
using DGU_GoogleAPI.Vision;

using Google.Apis.Vision.v1.Data;

using Cettear.Global;
using DGU_GoogleAPI.Translate;

namespace Cettear
{
	public partial class frmRemote : Form
	{
		/// <summary>
		/// 포커스가 소속되지 않았음을 표시.
		/// </summary>
		private bool m_bGlobalFocus = true;


		private Translate m_TAPI;

		public frmRemote()
		{
			InitializeComponent();

			this.m_TAPI = new Translate(Global_Cetterar.OptionMgr.Google.APIKey);
			this.m_TAPI.Language_Original = TypeLanguageCode.en;
			this.m_TAPI.Language_Translate = TypeLanguageCode.ja;
			this.m_TAPI.Language_DoubleTranslate = TypeLanguageCode.ko;

			this.txtApiKey.Text = Global_Cetterar.OptionMgr.Google.APIKey;
			this.labApiKeyFileInfo.Text = Global_Cetterar.OptionMgr.Google.ServiceKeyFile.ToString();

			this.txtHotKey_CaptureRange.GotFocus += TxtHotKey_CaptureRange_GotFocus;
			this.txtHotKey_CaptureRange.LostFocus += TxtHotKey_CaptureRange_LostFocus;
			this.txtHotKey_CaptureRangeShow.GotFocus += TxtHotKey_CaptureRange_GotFocus;
			this.txtHotKey_CaptureRangeShow.LostFocus += TxtHotKey_CaptureRange_LostFocus;
			this.txtHotKey_CaptureOCR.GotFocus += TxtHotKey_CaptureRange_GotFocus;
			this.txtHotKey_CaptureOCR.LostFocus += TxtHotKey_CaptureRange_LostFocus;
		}

		private void frmRemote_Load(object sender, EventArgs e)
		{
			//스크린을 띄운다.
			Global_Cetterar.FormScreen.Show();

			//키 세팅 표시
			this.ViewKey_CaptureRange();

			//키보드 훅
			Global_Cetterar.Util_KeyHook.KeyDown += Util_KeyHook_KeyDown;
			Global_Cetterar.Util_KeyHook.HookedKeys.Add(Global_Cetterar.OptionMgr.KeySetting.CaptureRange);
			Global_Cetterar.Util_KeyHook.HookedKeys.Add(Global_Cetterar.OptionMgr.KeySetting.CaptureRangeShow);
			Global_Cetterar.Util_KeyHook.HookedKeys.Add(Global_Cetterar.OptionMgr.KeySetting.CaptureOCR);
		}

		

		

		#region 리모콘
		private void btnCaptureRange_Click(object sender, EventArgs e)
		{
			Global_Cetterar.FormScreen.ShowCaptureRangeInterface();
		}

		private void btnCaptureOCR_Click(object sender, EventArgs e)
		{
			this.StartTranslate();
		}

		
		#endregion

		#region API
		private void btnSelectServiceKeyFile_Click(object sender, EventArgs e)
		{
			//api 키지정
			OpenFileDialog ofdServiceKey = new OpenFileDialog();
			ofdServiceKey.Filter = "Googlge Service Key Json file|*.json";
			ofdServiceKey.Title = "구글 서비스 키 파일을 지정해 주세요.";

			if (DialogResult.OK == ofdServiceKey.ShowDialog())
			{
				//파일 복사.
				Global_Cetterar.OptionMgr.Save_GoogleServiceFile(ofdServiceKey.FileName);
				Global_Cetterar.OptionMgr.Check_GoogleServiceFile();
			}
		}
		#endregion


		/// <summary>
		/// 번역을 시작합니다.
		/// </summary>
		public async void StartTranslate()
		{
			Global_Cetterar.FormScreen.DrawClear();

			//캡쳐 ************************
			Bitmap bitmapCapture = Global_Cetterar.Util_ScreenShot.Capture(
								Global_Cetterar.CaptureRect01.X
								, Global_Cetterar.CaptureRect01.Y
								, Global_Cetterar.CaptureRect01.Width
								, Global_Cetterar.CaptureRect01.Height);

			// 비트맵을 데이터를 파일로 저장
			bitmapCapture.Save(@"temp.png");
			bitmapCapture.Dispose();

			//OCR정보 표시 **********************
			//기존 OCR정보 제거
			Global_Cetterar.OCRMgr.Data_Clear();
			//OCR정보 입력
			this.Google_OCR();

			//번역 *******************************
			await this.TTTT();

			//텍스트 그리기
			Global_Cetterar.FormScreen.DrawText(this.chkOCRView.Checked);
		}


		public void Google_OCR()
		{
			Annotate annotate
				= new Annotate(Global_Cetterar.OptionMgr.Dir_GoogleServiceFile);
			annotate.Language_Taget = TypeLanguageCode.en;
			
			annotate.FeaturType = TypeFeatur.DOCUMENT_TEXT_DETECTION;

			Application.DoEvents();

			Block[] rest = annotate.GetText(@"f:\aaa.png").FullTextAnnotation.Pages[0].Blocks.ToArray();
			if (string.IsNullOrEmpty(annotate.Error) == false)
			{
				//MessageBox.Show("ERROR: " + Annotate.Error);
			}
			else
			{
				//ocr데이터를 입력하고
				Global_Cetterar.OCRMgr.Data_SetOCR(rest);
			}

			return;
		}

		public async Task TTTT()
		{
			string[] result = await this.m_TAPI.TranslateText(Global_Cetterar.OCRMgr.GetText());

			for (int i = 0; i < result.Length; ++i)
			{
				Global_Cetterar.OCRMgr.GroupList[i].TranslateData = result[i];
			}

			return;
		}

		private void btnCaptureRangeShow_Click(object sender, EventArgs e)
		{
			Global_Cetterar.FormScreen.ShowCaptureRange();
		}


		#region 키 세팅 & 키보드 훅
		private void Util_KeyHook_KeyDown(object sender, KeyEventArgs e)
		{
			//
			if (e.KeyCode == Global_Cetterar.OptionMgr.KeySetting.CaptureRange)
			{//캡처 범위키
				this.btnCaptureRange_Click(null, null);
			}
			else if (e.KeyCode == Global_Cetterar.OptionMgr.KeySetting.CaptureRangeShow)
			{// 캡처 범위 확인 키
				Global_Cetterar.FormScreen.ShowCaptureRange();
			}
			else if (e.KeyCode == Global_Cetterar.OptionMgr.KeySetting.CaptureOCR)
			{// 캡처 & 범위 시작 키
				this.StartTranslate();
			}

			e.Handled = true;
		}

		private void TxtHotKey_CaptureRange_GotFocus(object sender, EventArgs e)
		{
			this.m_bGlobalFocus = true;
		}

		private void TxtHotKey_CaptureRange_LostFocus(object sender, EventArgs e)
		{
			this.m_bGlobalFocus = false;
		}

		private void txtHotKey_CaptureRange_KeyDown(object sender, KeyEventArgs e)
		{
			//캡처 범위 설정
			Global_Cetterar.OptionMgr.KeySetting.CaptureRange = e.KeyCode;
			this.ViewKey_CaptureRange();
		}

		private void txtHotKey_CaptureRangeShow_KeyDown(object sender, KeyEventArgs e)
		{
			//캡처 범위 확인
			Global_Cetterar.OptionMgr.KeySetting.CaptureRangeShow = e.KeyCode;
			this.ViewKey_CaptureRange();
		}

		private void txtHotKey_CaptureOCR_KeyDown(object sender, KeyEventArgs e)
		{
			//캡처 범위 설정
			Global_Cetterar.OptionMgr.KeySetting.CaptureOCR = e.KeyCode;
			this.ViewKey_CaptureRange();
		}

		/// <summary>
		/// 키옵션 표시 - 캡쳐 범위
		/// </summary>
		private void ViewKey_CaptureRange()
		{
			this.txtHotKey_CaptureRange.Text
				= Global_Cetterar.OptionMgr.KeySetting.CaptureRange.ToString();
			this.txtHotKey_CaptureRangeShow.Text
				= Global_Cetterar.OptionMgr.KeySetting.CaptureRangeShow.ToString();
			this.txtHotKey_CaptureOCR.Text
				= Global_Cetterar.OptionMgr.KeySetting.CaptureOCR.ToString();
		}

		#endregion

		
	}
}
