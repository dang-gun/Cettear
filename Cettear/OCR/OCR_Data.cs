using System.Drawing;


namespace Cettear.OCR
{
	public class OCR_Data
	{
		public int Index { get; set; }
		public string OutText { get; set; }

		public int Vertex1_X { get; set; }
		public int Vertex1_Y { get; set; }

		public int Vertex2_X { get; set; }
		public int Vertex2_Y { get; set; }

		public int Vertex3_X { get; set; }
		public int Vertex3_Y { get; set; }

		public int Vertex4_X { get; set; }
		public int Vertex4_Y { get; set; }

		public RectangleF RectF
		{
			get
			{
				return this.m_rectF;
			}
			set
			{
				this.m_rectF = value;
			}
		}
		private RectangleF m_rectF = RectangleF.Empty;


		/// <summary>
		/// 가지고 있는 값을 가지고 랙트를 만듭니다.
		/// </summary>
		public void Calculation_Rect()
		{
			this.m_rectF.X = this.Vertex1_X;
			this.m_rectF.Y = this.Vertex1_Y;
			this.m_rectF.Width = this.Vertex3_X - this.Vertex1_X;
			this.m_rectF.Height = this.Vertex3_Y - this.Vertex1_Y;
		}
	}
}
