﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DotMaysWind.Data.Command.Condition
{
    /// <summary>
    /// Sql条件语句集合类
    /// </summary>
    public class SqlConditionList : AbstractSqlCondition, IEnumerable<ISqlCondition>, ICollection<ISqlCondition>
    {
        #region 字段
        private List<ISqlCondition> _list;
        private SqlWhereConcatType _concatType;
        #endregion

        #region 属性
        /// <summary>
        /// 获取语句类型
        /// </summary>
        public override SqlConditionType ConditionType
        {
            get { return SqlConditionType.ConditionList; }
        }

        /// <summary>
        /// 获取或设置语句连接类型
        /// </summary>
        public SqlWhereConcatType ConcatType
        {
            get { return this._concatType; }
            set { this._concatType = value; }
        }
        #endregion

        #region 索引器
        /// <summary>
        /// 获取或设置指定索引的Sql查询语句
        /// </summary>
        /// <param name="index">指定的索引</param>
        /// <returns>Sql查询语句</returns>
        public ISqlCondition this[Int32 index]
        {
            get { return this._list[index]; }
            set { this._list[index] = value; }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// 初始化Sql查询语句集合类
        /// </summary>
        /// <param name="concatType">连接类型</param>
        internal SqlConditionList(SqlWhereConcatType concatType)
        {
            this._list = new List<ISqlCondition>();
            this._concatType = concatType;
        }
        #endregion

        #region 方法
        /// <summary>
        /// 获取条件语句包含的参数集合
        /// </summary>
        public override SqlParameter[] GetAllParameters()
        {
            List<SqlParameter> result = new List<SqlParameter>();

            for (Int32 i = 0; i < this._list.Count; i++)
            {
                if (this._list[i] == null)
                {
                    continue;
                }

                SqlParameter[] parameters = this._list[i].GetAllParameters();

                if (parameters != null)
                {
                    result.AddRange(parameters);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// 输出条件语句
        /// </summary>
        /// <returns>条件语句</returns>
        public override String ToString()
        {
            if (this._list.Count <= 0)
            {
                return String.Empty;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("(");

            for (Int32 i = 0; i < this._list.Count; i++)
            {
                if (i > 0) sb.Append(' ').Append(this._concatType.ToString().ToUpperInvariant()).Append(' ');
                sb.Append(this._list[i].ToString());
            }

            sb.Append(")");

            return sb.ToString();
        }
        #endregion

        #region 接口方法
        #region IEnumerable
        /// <summary>
        /// 返回一个循环访问Sql查询语句集合的枚举器
        /// </summary>
        /// <returns>枚举器</returns>
        public IEnumerator<ISqlCondition> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        /// <summary>
        /// 返回一个循环访问Sql查询语句集合的枚举器
        /// </summary>
        /// <returns>枚举器</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._list.GetEnumerator();
        }
        #endregion

        #region ICollection
        /// <summary>
        /// 获取Sql查询语句集合的数量
        /// </summary>
        public Int32 Count
        {
            get { return this._list.Count; }
        }

        Boolean ICollection<ISqlCondition>.IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// 添加一个新的Sql查询语句
        /// </summary>
        /// <param name="item">Sql查询语句</param>
        /// <exception cref="NullReferenceException">Sql查询语句不能为空</exception>
        public void Add(ISqlCondition item)
        {
            if (item == null)
            {
                throw new NullReferenceException();
            }

            this._list.Add(item);
        }

        /// <summary>
        /// 清空所有的Sql查询语句
        /// </summary>
        public void Clear()
        {
            this._list.Clear();
        }

        void ICollection<ISqlCondition>.CopyTo(ISqlCondition[] array, Int32 arrayIndex)
        {
            this._list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// 判断是否包含指定的Sql查询语句
        /// </summary>
        /// <param name="item">指定Sql查询语句</param>
        /// <returns>是否包含指定的Sql查询语句</returns>
        public Boolean Contains(ISqlCondition item)
        {
            return this._list.Contains(item);
        }

        Boolean ICollection<ISqlCondition>.Remove(ISqlCondition item)
        {
            return this._list.Remove(item);
        }
        #endregion
        #endregion
    }
}