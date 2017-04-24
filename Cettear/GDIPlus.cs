using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cettear.OCR;
using System.Drawing.Drawing2D;

namespace Cettear
{
	public class GDIPlus
	{
		/// <summary>
		/// gdi를 출력할 화면
		/// </summary>
		public Graphics Screen { get; set; }

		/// <summary>
		/// 팬 - 빨간색 굵기2 
		/// </summary>
		private Pen m_penRed2;
		/// <summary>
		/// 브러쉬 - 단색 빨간생
		/// </summary>
		private SolidBrush m_brushRed;
		/// <summary>
		/// 폰트 - 나눔고딕 크기16
		/// </summary>
		private Font m_fontNanum16;

		/// <summary>
		/// 배경색
		/// </summary>
		public Color BackColor { get; set; }


		public GDIPlus(Color colorBack)
		{
			this.BackColor = colorBack;


			m_penRed2 = new Pen(Color.Red);
			m_penRed2.Width = 2;

			m_brushRed = new SolidBrush(Color.Red);
			m_fontNanum16 = new Font("NanumBarunGothic", 16);
		}

		/// <summary>
		/// 화면을 지웁니다.
		/// </summary>
		public void Clear()
		{
			this.Screen.Clear(this.BackColor);
		}

		/// <summary>
		/// 사각형을 그립니다.
		/// </summary>
		/// <param name="nX"></param>
		/// <param name="nY"></param>
		/// <param name="nWidth"></param>
		/// <param name="nHeight"></param>
		public void DrawRectangle(int nX, int nY, int nWidth, int nHeight)
		{
			this.DrawRectangle( new Rectangle(nX, nY, nWidth, nHeight));
		}

		/// <summary>
		/// 사각형을 그립니다.
		/// </summary>
		/// <param name="rect"></param>
		public void DrawRectangle(Rectangle rect)
		{
			//기존 내용을 지우고
			this.Clear();

			//사각형을 그립니다.
			this.Screen.DrawRectangle(this.m_penRed2, rect);
		}

		/// <summary>
		/// 지정된 그룹 리스트의 텍스트를 화면에 그립니다.
		/// </summary>
		/// <param name="arrGroupData">화면에 그릴 그룹 배열</param>
		/// <param name="nWeightX">좌표 가중치 X</param>
		/// <param name="nWeightY">좌표 가중치 Y</param>
		public void DrawTextList(OCR_GroupData[] arrGroupData
								, int nWeightX
								, int nWeightY
								, bool bOCRView)
		{
			string sTemp = "";

			//화면 지우기
			this.Clear();

			foreach (OCR_GroupData tempRow in arrGroupData)
			{
				RectangleF rectF1 = new RectangleF(tempRow.GroupData.RectF.X + nWeightX
													, tempRow.GroupData.RectF.Y + nWeightY
													, tempRow.GroupData.RectF.Width
													, tempRow.GroupData.RectF.Height);
				//출력값
				sTemp = tempRow.TranslateData;
				if (true == bOCRView)
				{
					sTemp += "\n OCR : " + tempRow.GroupData.OutText;
				}

				this.Screen.DrawString(sTemp
									, m_fontNanum16
									, m_brushRed
									, rectF1);
				Form_Paint(sTemp, rectF1);
			}

			

		}

		GraphicsPath GetStringPath(string s, float dpi, RectangleF rect, Font font, StringFormat format)
		{
			GraphicsPath path = new GraphicsPath();
			// Convert font size into appropriate coordinates
			float emSize = dpi * font.SizeInPoints / 72;
			rect.X += 5;
			path.AddString(s, font.FontFamily, (int)font.Style, emSize, rect, format);

			return path;
		}

		private void Form_Paint(string sOutText, RectangleF rect)
		{
			Font font = m_fontNanum16;
			StringFormat format = StringFormat.GenericTypographic;
			float dpi = this.Screen.DpiY;
			using (GraphicsPath path = GetStringPath(sOutText, dpi, rect, font, format))
			{
				


				Pen pen = new Pen(Color.Black);
				pen.Width = 2;
				this.Screen.DrawPath(pen, path);


				SolidBrush bbb = new SolidBrush(Color.Red);
				this.Screen.FillPath(bbb, path);





			}
		}

	}
}
