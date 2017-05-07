
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Apis.Vision.v1.Data;

using DGU_GoogleAPI.Vision;
using Global.FixString;

using Cettear.Global;

namespace Cettear.OCR
{
	public class GoogleOCR
	{
		/// <summary>
		/// 구글 OCR요청 타입
		/// </summary>
		public TypeFeatur Featur { get; private set; }
		/// <summary>
		/// 띄어쓰기가 있는 언어인지 여부
		/// </summary>
		public bool SpaceLang { get; private set; }


		/// <summary>
		/// 완성된 리스트
		/// </summary>
		private List<OCR_GroupData> GroupList = new List<OCR_GroupData>();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="typeFeatur"></param>
		/// <param name="bSpaceLang">띄어 쓰기가 있는 언어인지 여부</param>
		/// <returns></returns>
		public List<OCR_GroupData> Start(TypeFeatur typeFeatur, bool bSpaceLang)
		{
			this.Featur = typeFeatur;
			this.SpaceLang = bSpaceLang;


			this.Start();

			return this.GroupList;
		}

		private void Start()
		{
			Annotate annotate
				= new Annotate(Global_Cetterar.OptionMgr.Dir_GoogleServiceFile);
			//감지할 언어 지정
			annotate.Language_Taget = Global_Cetterar.OptionMgr.ProcessLanguage.TranslateGroup.OCR;

			//감지 방식 설정
			//annotate.FeaturType = TypeFeatur.DOCUMENT_TEXT_DETECTION;
			annotate.FeaturType = this.Featur;

			//결과
			AnnotateImageResponse aResponse = annotate.GetText(FileDir.Dir_File);

			//Block[] rest = annotate.GetText(FileDir.Dir_File).FullTextAnnotation.Pages[0].Blocks.ToArray();
			if (null == aResponse.Error)
			{//에러가 없다.

				switch (this.Featur)
				{
					case TypeFeatur.TEXT_DETECTION:
						TEXT_DETECTION(aResponse);
						break;

					case TypeFeatur.DOCUMENT_TEXT_DETECTION:
						DOCUMENT_TEXT_DETECTION(aResponse);
						break;
				}
			}
			else
			{//에러다
				OCR_GroupData temp = new OCR_GroupData();

				temp.Error = true;
				//위치 설정
				temp.GroupData = new OCR_Data();
				temp.GroupData.Vertex1_X = 100;
				temp.GroupData.Vertex1_Y = 100;
				temp.GroupData.Vertex2_X = 400;
				temp.GroupData.Vertex2_Y = 100;
				temp.GroupData.Vertex3_X = 400;
				temp.GroupData.Vertex3_Y = 400;
				temp.GroupData.Vertex4_X = 100;
				temp.GroupData.Vertex4_Y = 400;
				temp.GroupData.Calculation_Rect();

				//에러메시지 표시
				temp.TranslateData = aResponse.Error.Message;

				//내용 리스트에 추가
				this.GroupList.Add(temp);
			}			
		}

		private void TEXT_DETECTION(AnnotateImageResponse aResponse)
		{
			
			OCR_GroupData drGroup;

			//전체 문장은 잘라서 저장한다.
			string[] arrResult = aResponse.FullTextAnnotation.Text.Replace("\r","").Split('\n');


			//그룹 데이터 생성*****************************
			foreach (string sData in arrResult)
			{
				//앞뒤 공백 제거
				string sData0 = sData.Trim();
				if ("" == sData0)
				{//데이터가 없으면 처리하지 않는다.
					continue;
				}

				//그룹데이터 생성
				drGroup = new OCR_GroupData();

				//출력 문장을 저장 한다.
				drGroup.GroupData.OutText = sData0;
				//문장을 잘라 몇개의 맴버가 필요한지 계산한다.
				if (true == this.SpaceLang)
				{//띄어쓰기가 있는 언어
					//이 언어는 띄어쓰기 기준으로 단어를 가지고 오면 된다.
					string[] aaa = drGroup.GroupData.OutText.Split(' ');
					drGroup.MemberCount = aaa.Length;
				}
				else
				{//띄어쓰기가 없는 언어
					//이 언어는 문자 개수로 판단한다.
					drGroup.MemberCount = drGroup.GroupData.OutText.Length;
				}

				this.GroupList.Add(drGroup);
			}


			//그룹 맴버 생성************************
			IList<EntityAnnotation> listOCR = aResponse.TextAnnotations;
			OCR_Data drTemp;
			EntityAnnotation tmepRow;

			int MeberCount = 0;
			int GroupCount = 0;

			for (int i = 1; i < listOCR.Count; ++i)
			{
				drTemp = new OCR_Data();
				tmepRow = listOCR[i];

				if (true == this.SpaceLang)
				{//띄어쓰기가 있는 언어
					++MeberCount;
				}
				else
				{//띄어 쓰기가 없는 언어
					MeberCount += tmepRow.Description.Length;
				}
					

				drTemp.Index = i;
				drTemp.OutText = tmepRow.Description;

				drTemp.Vertex1_X = Convert.ToInt32(tmepRow.BoundingPoly.Vertices[0].X);
				drTemp.Vertex1_Y = Convert.ToInt32(tmepRow.BoundingPoly.Vertices[0].Y);

				drTemp.Vertex2_X = Convert.ToInt32(tmepRow.BoundingPoly.Vertices[1].X);
				drTemp.Vertex2_Y = Convert.ToInt32(tmepRow.BoundingPoly.Vertices[1].Y);

				drTemp.Vertex3_X = Convert.ToInt32(tmepRow.BoundingPoly.Vertices[2].X);
				drTemp.Vertex3_Y = Convert.ToInt32(tmepRow.BoundingPoly.Vertices[2].Y);

				drTemp.Vertex4_X = Convert.ToInt32(tmepRow.BoundingPoly.Vertices[3].X);
				drTemp.Vertex4_Y = Convert.ToInt32(tmepRow.BoundingPoly.Vertices[3].Y);

				//데이터 추가
				this.GroupList[GroupCount].MemberList.Add(drTemp);

				if (this.GroupList[GroupCount].MemberCount <= MeberCount)
				{
					//맴버 입력 완료
					this.GroupList[GroupCount].InputComplete();

					//값초기화
					MeberCount = 0;
					++GroupCount;
				}
			}

		}


		private void DOCUMENT_TEXT_DETECTION(AnnotateImageResponse aResponse)
		{
			Block[] arrOCR_Block = aResponse.FullTextAnnotation.Pages[0].Blocks.ToArray();

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
				GroupList.Add(drGroup);
			}
		}

	}
}
