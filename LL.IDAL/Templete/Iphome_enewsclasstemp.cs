using System;
using System.Data;
namespace LL.IDAL.Templete
{
	/// <summary>
	/// �ӿڲ�Iphome_enewsclasstemp ��ժҪ˵����
	/// </summary>
	public interface Iphome_enewsclasstemp
	{
		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(LL.Model.Templete.phome_enewsclasstemp model);
		/// <summary>
		/// ����һ������
		/// </summary>
        int Update(LL.Model.Templete.phome_enewsclasstemp model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
        int Delete(int tempid);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		LL.Model.Templete.phome_enewsclasstemp GetModel(int tempid);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);
		

		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  ��Ա����

        DataSet GetList(int PageIndex, int PageSize, string where, string orderby);

       
    }
}
