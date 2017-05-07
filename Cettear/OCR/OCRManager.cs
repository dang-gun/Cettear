using Google.Apis.Vision.v1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cettear.OCR
{
	public class OCRManager
	{

		/// <summary>
		/// 화면에 그릴 데이터
		/// </summary>
		public List<OCR_GroupData> GroupList { get; set; }


		public OCRManager()
		{
			//테이블을 생성합니다.
			this.GroupList = new List<OCR_GroupData>();
		}

		/// <summary>
		/// 모든 데이터를 지웁니다.
		/// </summary>
		public void Data_Clear()
		{
			this.GroupList.Clear();
		}

		/// <summary>
		/// 그룹데이터를 텍스트로 만들어 리턴합니다.
		/// </summary>
		/// <returns></returns>
		public string[] GetText()
		{
			List<string> listReturn = new List<string>();

			foreach (OCR_GroupData tempGroup in this.GroupList)
			{
				listReturn.Add(tempGroup.GroupData.OutText);
			}

			return listReturn.ToArray();
		}

		/// <summary>
		/// OCR 데이터를 저장합니다.
		/// </summary>
		/// <param name="arrOCR_Block"></param>
		public void Data_SetOCR(Block[] arrOCR_Block)
		{
			OCR_GroupData drGroup;


			foreach (Block temp in arrOCR_Block)
			{
				drGroup = new OCR_GroupData();

				//바운딩박스 저장
				drGroup.GroupData.Vertex1_X = Convert.ToInt32(temp.BoundingBox.Vertices[0].X);
				drGroup.GroupData.Vertex1_Y = Convert.ToInt32(temp.BoundingBox.Vertices[0].Y);
				drGroup.GroupData.Vertex2_X = Convert.ToInt32(temp.BoundingBox.Vertices[1].X);
				drGroup.GroupData.Vertex2_Y = Convert.ToInt32(temp.BoundingBox.Vertices[1].Y);
				drGroup.GroupData.Vertex3_X = Convert.ToInt32(temp.BoundingBox.Vertices[2].X);
				drGroup.GroupData.Vertex3_Y = Convert.ToInt32(temp.BoundingBox.Vertices[2].Y);
				drGroup.GroupData.Vertex4_X = Convert.ToInt32(temp.BoundingBox.Vertices[3].X);
				drGroup.GroupData.Vertex4_Y = Convert.ToInt32(temp.BoundingBox.Vertices[3].Y);
				drGroup.GroupData.Calculation_Rect();

				StringBuilder sbTemp = new StringBuilder();
				foreach (Word word in temp.Paragraphs[0].Words)
				{
					foreach (Symbol symbol in word.Symbols)
					{
						sbTemp.Append(symbol.Text);
					}
					
					//워드 끝날때 빈공간 추가
					sbTemp.Append(" ");
				}

				
				drGroup.GroupData.OutText = sbTemp.ToString();
				this.GroupList.Add(drGroup);
			}

		}
	}
}
