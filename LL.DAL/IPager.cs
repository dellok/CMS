using System;
using System.Collections.Generic;

using System.Text;
using DBUtility;
using System.Data;


    public class IPager
    {

        private int DefaultPageIndex = 1;
        private int DefalultPageSize = 10;
        private string DefaultFields = "*";
        private string DefaultPK = "id";


        private int _pageindex = 1;
        private int _pagesize = 10;
        private string _tablename = "";
        private string _fields = "*";
        private string _orderby = "";
        private string _where = " 1=1";


        public IPager(string tbName, string primarkKey, int pageIndex, int pageSize, string fields, string orderby)
        {
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.PrimaryKeyField = primarkKey;
            this.Fields = fields;
            this.OrderBy = orderby;
            this.TableName = tbName;

        }

        public IPager(string tbName,  int pageIndex, int pageSize, string orderby)
        {
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
         

            this.OrderBy = orderby;
            this.TableName = tbName;

        }
        public IPager(string tbName, int pageIndex, int pageSize)
        {
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
          
            this.TableName = tbName;

        }
        public IPager()
        {
            // TODO: Complete member initialization
        }


        private string pk = "";


        public int PageIndex {
            get {

                return _pageindex>0?_pageindex: DefaultPageIndex;
            
            }
            set { _pageindex = value; }
        }
        public int PageSize
        {
            get
            {

                return _pagesize > 0 ? _pagesize : DefalultPageSize;

            }
            set { _pagesize = value; }
        }
        public string TableName {
            get
            {

                return _tablename;

            }
            set { _tablename = value; }
        
        }


        public string Fields
        {
            get
            {
                if (string.IsNullOrEmpty(_fields))
                {
                    return DefaultFields;
                }
                else
                {
                    return _fields;
                }
            }
            set { _fields = value; }
        }


        public string PrimaryKeyField
        {

            get
            {
                if (string.IsNullOrEmpty(pk))
                {
                    return DefaultPK;
                }
                else
                {
                    return pk;
                }
            }
            set { pk = value; }
        }

        public string OrderBy
        {
            get
            {
                if (string.IsNullOrEmpty(_orderby.Trim()))
                {
                    return PrimaryKeyField + " desc";
                }
                else
                {
                    return _orderby;
                }
            }
            set { _orderby = value; }

        }




        public string Where
        {

            get
            {
                if (string.IsNullOrEmpty(_where))
                {
                    return " 1=1";
                }

                else

                {

                    return _where;
                }

            }
            set { _where = value; }

        }


        /// <summary>
        /// 适用于多表关联操作,速度会有影响
        /// </summary>
        /// <returns></returns>
        public DataSet GetResult()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("  declare  @PageIndex  int   declare  @PageSize int   set @PageIndex={0}  set @PageSize={1}", PageIndex, PageSize);
            sql.AppendFormat("  declare  @RecordCount int      select @RecordCount=count(*) from ({0}) ttt ", TableName);
            sql.AppendFormat("  declare  @TotalPage int        set @TotalPage=ceiling((@RecordCount+0.0)/@PageSize )");
            sql.AppendFormat("  declare  @StartRecord int   declare @EndRecord int ");
            sql.AppendFormat("  if @PageIndex<1  set @PageIndex=1     if @PageIndex>@TotalPage  begin  set @PageIndex=@TotalPage  end");
            sql.AppendFormat("   set  @StartRecord=(@PageIndex-1)*@PageSize+1");
            sql.AppendFormat("  set @EndRecord=@StartRecord+@PageSize-1");
            sql.AppendFormat(" select *   from (select {0},  row_number() over(order by   {1}  ) as TNum  from   ({2}) tt ) RM  where RM.TNum  between @StartRecord and @EndRecord ", Fields, OrderBy, TableName);
          
            
            sql.AppendFormat(" select      @RecordCount  ");
            return DbHelperSQL.Query(sql.ToString());

        }



        public DataSet GetSearchResultBySingleTable()
        {


            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("  declare  @PageIndex  int   declare  @PageSize int   set @PageIndex={0}  set @PageSize={1}", PageIndex, PageSize);
            sql.AppendFormat("  declare  @RecordCount int      select @RecordCount=count(*) from  {0}  where {1} ", TableName, Where);
            sql.AppendFormat("  declare  @TotalPage int        set @TotalPage=ceiling((@RecordCount+0.0)/@PageSize )");
            sql.AppendFormat("  declare  @StartRecord int   declare @EndRecord int ");
            sql.AppendFormat("  if @PageIndex<1  set @PageIndex=1     if @PageIndex>@TotalPage  begin  set @PageIndex=@TotalPage  end");
            sql.AppendFormat("   set  @StartRecord=(@PageIndex-1)*@PageSize+1");
            sql.AppendFormat("  set @EndRecord=@StartRecord+@PageSize-1");


            sql.AppendFormat(" select  {0}   from ( select {0},  row_number() over(order by   {1}  ) as RowNum  from   {2}  where {3} ) RM  where RM.RowNum  between @StartRecord and @EndRecord ", Fields, OrderBy, TableName,Where);


            sql.AppendFormat(" select      @RecordCount  ");

            return DbHelperSQL.Query(sql.ToString());

        }
        public string  GetSearchSql2()
        {


            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("  declare  @PageIndex  int   declare  @PageSize int   set @PageIndex={0}  set @PageSize={1}", PageIndex, PageSize);
            sql.AppendFormat("  declare  @RecordCount int      select @RecordCount=count(*) from  {0}  where {1} ", TableName, Where);
            sql.AppendFormat("  declare  @TotalPage int        set @TotalPage=ceiling((@RecordCount+0.0)/@PageSize )");
            sql.AppendFormat("  declare  @StartRecord int   declare @EndRecord int ");
            sql.AppendFormat("  if @PageIndex<1  set @PageIndex=1     if @PageIndex>@TotalPage  begin  set @PageIndex=@TotalPage  end");
            sql.AppendFormat("   set  @StartRecord=(@PageIndex-1)*@PageSize+1");
            sql.AppendFormat("  set @EndRecord=@StartRecord+@PageSize-1");


            sql.AppendFormat(" select  {0}   from ( select {0},  row_number() over(order by   {1}  ) as RowNum  from   {2}  where {3} ) RM  where RM.RowNum  between @StartRecord and @EndRecord ", Fields, OrderBy, TableName,Where);


            sql.AppendFormat(" select      @RecordCount  ");

          return sql.ToString();

        }
   
        public string GetSearchSql()
        {

            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("  declare  @PageIndex  int   declare  @PageSize int   set @PageIndex={0}  set @PageSize={1}", PageIndex, PageSize);
            sql.AppendFormat("  declare  @RecordCount int      select @RecordCount=count(*) from ({0}) ttt ", TableName);
            sql.AppendFormat("  declare  @TotalPage int        set @TotalPage=ceiling((@RecordCount+0.0)/@PageSize )");
            sql.AppendFormat("  declare  @StartRecord int   declare @EndRecord int ");
            sql.AppendFormat("  if @PageIndex<1  set @PageIndex=1     if @PageIndex>@TotalPage  begin  set @PageIndex=@TotalPage  end");
            sql.AppendFormat("   set  @StartRecord=(@PageIndex-1)*@PageSize+1");
            sql.AppendFormat("  set @EndRecord=@StartRecord+@PageSize-1");
            sql.AppendFormat(" select *   from (select {0},  row_number() over(order by   {1}   ) as RowNum  from   ({2}) tt ) RM  where RM.RowNum  between @StartRecord and @EndRecord ", Fields, OrderBy, TableName);


            sql.AppendFormat(" select      @RecordCount  ");
            return sql.ToString();
        }

        public string GetSearchTotalCountSql()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("  declare  @RecordCount int      select @RecordCount=count(*) from ({0}) ttt ", TableName);
            sql.AppendFormat(" select      @RecordCount  ");

            return sql.ToString();
        }


        ///// <summary> 
        ///// 分页  
        ///// summary> 
        ///// <typeparam name="T">typeparam> 
        ///// <param name="List">实现IEnumerableparam> 
        ///// <param name="FunWhere">delegate检索条件param> 
        ///// <param name="FunOrder">delegate排序param> 
        ///// <param name="PageSize">每页显示数param> 
        ///// <param name="PageIndex">当前页码param> 
        ///// <returns>returns> 
        //internal static IEnumerable<T> GetIenumberable<T>(IEnumerable<T> List, Func<T,
        //     bool> FunWhere, Func<T, string> FunOrder, int PageSize, int PageIndex)
        //{
        //    var rance = List.Where(FunWhere).OrderByDescending(FunOrder).
        //       Select(t => t).Skip((PageIndex - 1) * PageSize).Take(PageSize);
        //    return rance;
        //}


        public  static string  SetSqlWhere(string strWhere)
        {

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {

               bool isH= strWhere.Trim().StartsWith("and", StringComparison.CurrentCultureIgnoreCase);

               if (isH)
               {

                   return  string.Format("  where 1=1 {0}",strWhere);
               }
               else
               {

                   return string.Format("  where  {0}", strWhere);
               }

            }
            else
            {

                return "";
            }


        }
    }
