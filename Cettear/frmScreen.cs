using Cettear.Global;
using Cettear.OCR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cettear
{
	public partial class frmScreen : Form
	{
		/// <summary>
		/// 마우스 다운 여부
		/// </summary>
		private bool m_bMouseDown = false;

		/// <summary>
		/// gdi+를 컬트롤 하기위한 클래스
		/// </summary>
		private GDIPlus m_gdi;


		/// <summary>
		/// 범위 표시 토글
		/// </summary>
		private bool bShowCaptureRange = true;

		public frmScreen()
		{
			InitializeComponent();

			//gdi+ 초기화
			this.m_gdi = new GDIPlus(this.BackColor);
		}

		private void frmScreen_Load(object sender, EventArgs e)
		{
			//화면 설정
			this.m_gdi.Screen = this.CreateGraphics();
		}

		private void frmScreen_MouseDown(object sender, MouseEventArgs e)
		{
			//마우스 다운 시작
			this.m_bMouseDown = true;
			Global_Cetterar.OptionMgr.Capture.CaptureRect01.Location = e.Location;
			this.m_gdi.Clear();
		}

		private void frmScreen_MouseMove(object sender, MouseEventArgs e)
		{
			if (true == this.m_bMouseDown)
			{//마우스 다운일때.
				//화면에 범위를 그려 준다.
				Global_Cetterar.OptionMgr.Capture.CaptureRect01.Size
					= new Size(e.X - Global_Cetterar.CaptureRect01.X
								, e.Y - Global_Cetterar.CaptureRect01.Y);

				this.m_gdi.DrawRectangle(Global_Cetterar.CaptureRect01);
			}
		}

		private void frmScreen_MouseUp(object sender, MouseEventArgs e)
		{
			//마우스 이벤트 종료
			this.m_bMouseDown = false;
		}

		private void btnComplete_Click(object sender, EventArgs e)
		{
			//완료 버튼

			//정보 파일로 저장
			Global_Cetterar.OptionMgr.Save_Capture();

			//화면을 지우고
			this.m_gdi.Clear();

			//완료 버튼 가리기
			this.btnComplete.Visible = false;

			//투명 다시 투명 설정
			this.TransparencyKey = this.BackColor;
			//투명도 조절
			this.Opacity = 1.0;
		}
		
		/// <summary>
		/// 캡처 범위를 지정하는 인터페이스를 표시 합니다.
		/// </summary>
		public void ShowCaptureRangeInterface()
		{
			//완료 버튼 표시
			this.btnComplete.Visible = true;

			//투명 일시 제거
			this.TransparencyKey = Color.Empty;
			//투명도 조절
			this.Opacity = 0.5;
		}

		/// <summary>
		/// 지정된 범위를 표시해줍니다.
		/// </summary>
		public void ShowCaptureRange()
		{
			if (true == this.bShowCaptureRange)
			{
				this.m_gdi.DrawRectangle(Global_Cetterar.CaptureRect01);
				this.bShowCaptureRange = false;
			}
			else
			{
				this.m_gdi.Clear();
				this.bShowCaptureRange = true;
			}
		}

		/// <summary>
		/// 번역된 정보를 표시합니다.
		/// </summary>
		public void DrawText(bool bOCRView)
		{
			this.m_gdi.DrawTextList(Global_Cetterar.OCRMgr.GroupList.ToArray()
										, Global_Cetterar.CaptureRect01.X
										, Global_Cetterar.CaptureRect01.Y
										, bOCRView);
		}

		public void DrawClear()
		{
			this.m_gdi.Clear();
		}

		
	}
}
