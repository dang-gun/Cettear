using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cettear.OCR
{
	public class OCR_GroupData
	{
		/// <summary>
		/// 에러 여부
		/// </summary>
		public bool Error { get; set; }

		//이 그룹의 전체 정보
		public OCR_Data GroupData { get; set; }

		/// <summary>
		/// 사용할 맴버의 숫자
		/// </summary>
		public int MemberCount { get; set; }

		/// <summary>
		/// 이 그룹의 맴버 정보
		/// </summary>
		public List<OCR_Data> MemberList { get; set; }

		/// <summary>
		/// 번역된 데이터
		/// </summary>
		public string TranslateData { get; set; }

		public OCR_GroupData()
		{
			this.Error = false;

			this.GroupData = new OCR_Data();
			this.MemberList = new List<OCR_Data>();
		}

		/// <summary>
		/// 맴버정보가 모두입력됐음을 알립니다.
		/// 그룹정보를 완성합니다.
		/// </summary>
		public void InputComplete()
		{
			//int nLastIndex = this.MemberCount - 1;
			int nLastIndex = this.MemberList.Count - 1;
			

			//버택스 시작 위치 계산
			this.GroupData.Vertex1_X = this.MemberList[0].Vertex1_X;
			this.GroupData.Vertex1_Y = this.MemberList[0].Vertex1_Y;

			this.GroupData.Vertex2_X = this.MemberList[nLastIndex].Vertex3_X;
			this.GroupData.Vertex2_Y = this.MemberList[0].Vertex1_Y;

			this.GroupData.Vertex3_X = this.MemberList[nLastIndex].Vertex3_X;
			this.GroupData.Vertex3_Y = this.MemberList[nLastIndex].Vertex3_Y;

			this.GroupData.Vertex4_X = this.MemberList[0].Vertex1_X;
			this.GroupData.Vertex4_Y = this.MemberList[nLastIndex].Vertex3_Y;

			this.GroupData.RectF = new RectangleF(this.GroupData.Vertex1_X
													, this.GroupData.Vertex1_Y
													, this.GroupData.Vertex3_X - this.GroupData.Vertex1_X
													, this.GroupData.Vertex3_Y - this.GroupData.Vertex1_Y);
		}
	}
}
