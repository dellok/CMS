using System;
using System.Data;
using LL.Model.Templete;
namespace LL.IDAL.Templete
{
	/// <summary>
	/// �ӿڲ�Iphome_enewsnewstemp ��ժҪ˵����
	/// </summary>
	public interface Iphome_enewsnewstemp
	{
		#region  ��Ա����
		
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(phome_enewsnewstemp model);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Update(phome_enewsnewstemp model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		int Delete(int tempid);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		phome_enewsnewstemp GetModel(int tempid);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);
        DataSet GetList(int pageindex, int pagesize, string where, string oderby);
		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  ��Ա����
	}
}
