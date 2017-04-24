using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Utility
{
	/// <summary>
	/// 스크린샷.
	/// winform 전용 유틸입니다.
	/// </summary>
	public class ScreenShot
	{

		/// <summary>
		/// 주 화면 전체 영역을 캡처 합니다.
		/// </summary>
		/// <returns></returns>
		public Bitmap Capture()
		{
			Rectangle rect = Screen.PrimaryScreen.Bounds;
			return this.Capture(rect.X, rect.Y, rect.Width, rect.Height);
		}

		/// <summary>
		/// 지정한 스크린의 전체 영역을 캡처 합니다.
		/// </summary>
		/// <param name="nScreenNumber"></param>
		/// <returns></returns>
		public Bitmap Capture(int nScreenNumber)
		{
			Rectangle rect = Screen.AllScreens[nScreenNumber].Bounds;
			return this.Capture(rect.X, rect.Y, rect.Width, rect.Height);
		}

		/// <summary>
		/// 지정한 범위를 캡쳐 합니다.
		/// </summary>
		/// <param name="nX"></param>
		/// <param name="nY"></param>
		/// <param name="nWidth"></param>
		/// <param name="nHeight"></param>
		/// <returns></returns>
		public Bitmap Capture(int nX, int nY, int nWidth, int nHeight)
		{
			return this.Capture(new Rectangle(nX, nY, nWidth, nHeight));
		}

		/// <summary>
		/// 지정한 범위를 캡쳐 합니다.
		/// </summary>
		/// <param name="rect"></param>
		/// <returns></returns>
		public Bitmap Capture(Rectangle rect)
		{
			// 픽셀 포맷 정보 얻기 (Optional)
			int nBitsPerPixel = Screen.PrimaryScreen.BitsPerPixel;
			PixelFormat pixelFormat = PixelFormat.Format32bppArgb;
			if (nBitsPerPixel <= 16)
			{
				pixelFormat = PixelFormat.Format16bppRgb565;
			}
			if (nBitsPerPixel == 24)
			{
				pixelFormat = PixelFormat.Format24bppRgb;
			}

			//캡쳐 크기 만큼의 비트맵 생성
			Bitmap bmpReturn = new Bitmap(rect.Width, rect.Height, pixelFormat);

			//화면 캡처를 위해 gdi+ 객체생성
			using (Graphics graphics = Graphics.FromImage(bmpReturn))
			{
				//지정한 범위만큼 비트맵에 저장
				graphics.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);
			}

			return bmpReturn;
		}
	}
}
