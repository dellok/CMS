using System;
using System.Data;
using LL.Model.Templete;
namespace LL.IDAL.Templete
{
	/// <summary>
	/// �ӿڲ�Iphome_enewsnewstempclass ��ժҪ˵����
	/// </summary>
	public interface Iphome_enewsnewstempclass
	{
		#region  ��Ա����
		/// <summary>
		/// ����һ������
		/// </summary>
		int  Add(phome_enewsnewstempclass model);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Update(phome_enewsnewstempclass model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		int Delete();
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		phome_enewsnewstempclass GetModel();

        DataSet GetList(int pageindex, int pagesize, string where, string orderby);
		#endregion  ��Ա����

        DataSet GetList(string strWhere);
    }
}
