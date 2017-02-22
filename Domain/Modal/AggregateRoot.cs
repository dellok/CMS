using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modal
{
    public abstract class AggregateRoot : IAggregateRoot
    {
        protected Guid id;


        /// <summary>
        /// 确定指定的Object 是否等于当前的Object
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {

            if (obj==null)
            {
                return false;

            }

            if (ReferenceEquals(this,obj))
            {
                return true;

            }

            IAggregateRoot ar = obj as IAggregateRoot;

            if (ar==null)
            {
                return false;
            }

            return this.id == ar.ID;
       
        }


        /// <summary>
        /// 用于特定类型的哈希函数
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }
        /// <summary>
        /// 当前领域实体类全局唯一标识
        /// </summary>

        public Guid ID { get { return id; } set { id = value; } }

    }
}
