using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace LL.Common.Template
{
    public class TempToHtml
    {
        public static string Regular_Loop = @"\[e:loop={(.*)}\](.*[^\[\/e:loop\]].*)";
        public static string Regular_Info = @"\[info\](.*)\[\/info\]";
        public static string Regular_News = @"\[news\](.*)\[\/news\]";
    }
}

//        order='zcnum desc,plid desc';
//    }
//    elseif(enews==2)//反对
//    {
//        order='fdnum desc,plid desc';
//    }
//    else//发布时间
//    {
//        order='plid desc';
//    }
//    取得模板
//    tr=sys_ReturnBqTemp(tempid);
//    if(empty(tr['tempid']))
//    {return "";}
//    listtemp=tr[temptext];
//    subnews=tr[subnews];
//    listvar=tr[listvar];
//    rownum=tr[rownum];
//    formatdate=tr[showdate];
//    if(empty(rownum))
//    {rownum=1;}
//    列表
//    list_exp="[!--empirenews.listtemp--]";
//    list_r=explode(list_exp,listtemp);
//    listtext=list_r[1];
//    no=1;
//    changerow=1;
//    sql=empire->query("select plid,userid,username,saytext,saytime,id,classid,zcnum,fdnum from {dbtbpre}enewspl where checked=0".a." order by ".order." limit ".line);
//    while(r=empire->fetch(sql))
//    {
//        替换列表变量
//        repvar=ReplaceShowPlVars(no,listvar,r,formatdate,subnews);
//        listtext=str_replace("<!--list.var".changerow."-->",repvar,listtext);
//        changerow+=1;
//        超过行数
//        if(changerow>rownum)
//        {
//            changerow=1;
//            string.=listtext;
//            listtext=list_r[1];
//        }
//        no++;
//    }
//    多余数据
//    if(changerow<=rownum&&listtext<>list_r[1])
//    {
//        string.=listtext;
//    }
//    string=list_r[0].string.list_r[2];
//    echo string;
//}

//替换评论标签
//function ReplaceShowPlVars(no,listtemp,r,formatdate,subnews=0){
//    global public_r,empire,dbtbpre,class_r;
//    标题
//    infor=empire->fetch1("select titleurl,groupid,classid,newspath,filename,id,title from {dbtbpre}ecms_".class_r[r[classid]][tbname]." where id='r[id]' limit 1");
//    r['saytext']=stripSlashes(r['saytext']);
//    if(subnews)
//    {
//        r['saytext']=sub(r['saytext'],0,subnews,false);
//    }
//    if(r['userid'])
//    {
//        r['username']="<a href='".public_r[newsurl]."e/member/ShowInfo/?userid=r[userid]' target='_blank'>r[username]</a>";
//    }
//    if(empty(r['username']))
//    {
//        r['username']='匿名';
//    }
//    titleurl=sys_ReturnBqTitleLink(infor);
//    listtemp=str_replace("[!--titleurl--]",titleurl,listtemp);
//    listtemp=str_replace("[!--title--]",infor['title'],listtemp);
//    listtemp=str_replace("[!--plid--]",r['plid'],listtemp);
//    listtemp=str_replace("[!--pltext--]",r['saytext'],listtemp);
//    listtemp=str_replace("[!--id--]",r['id'],listtemp);
//    listtemp=str_replace("[!--classid--]",r['classid'],listtemp);
//    listtemp=str_replace("[!--pltime--]",format_datetime(r['saytime'],formatdate),listtemp);
//    listtemp=str_replace("[!--username--]",r['username'],listtemp);
//    listtemp=str_replace("[!--zcnum--]",r['zcnum'],listtemp);
//    listtemp=str_replace("[!--fdnum--]",r['fdnum'],listtemp);
//    序号
//    listtemp=str_replace("[!--no--]",no,listtemp);
//    return listtemp;
//}
//?>
//    }
//}
