using System;
using System.Data;
using LL.Model.Templete;
namespace LL.IDAL.Templete
{
	/// <summary>
	/// �ӿڲ�Iphome_enewsmod ��ժҪ˵����
	/// </summary>
	public interface Iphome_enewsmod
	{
		#region  ��Ա����
		
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(phome_enewsmod model);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Update(phome_enewsmod model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		int Delete(int mid);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		phome_enewsmod GetModel(int mid);
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
