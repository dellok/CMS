using System;
using System.Data;
using LL.Model.Templete;
namespace LL.IDAL.Templete
{
	/// <summary>
	/// �ӿڲ�Iphome_enewstempvar ��ժҪ˵����
	/// </summary>
	public interface Iphome_enewstempvar
	{
		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(phome_enewstempvar model);
		/// <summary>
		/// ����һ������
		/// </summary>
		int  Update(phome_enewstempvar model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		int  Delete(int varid);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		phome_enewstempvar GetModel(int varid);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  ��Ա����
	}
}
