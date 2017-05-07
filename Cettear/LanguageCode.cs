using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DGU_Enum;
using DGU_GoogleAPI;

namespace Cettear
{
	public class LanguageCodeManager
	{
		/// <summary>
		/// 
		/// </summary>
		public string[] List { get; private set; }

		private CEnumToClass m_ETC;

		public LanguageCodeManager()
		{
			this.m_ETC = new CEnumToClass(new TypeLanguageCode());
			this.EnumToList();
		}

		/// <summary>
		/// 가지고 있는 데이터를 문자열 리스트로 만든다.
		/// </summary>
		private void EnumToList()
		{
			this.List = this.m_ETC.EnumMember.Select(x => x.Name).ToArray<string>();
		}

		
	}
}
