﻿using System;
using System.Collections.Generic;
using System.Text;

using DotMaysWind.Data.Command.Condition;
using DotMaysWind.Data.Command.Join;

namespace DotMaysWind.Data.Command
{
    /// <summary>
    /// SQL语句创建类
    /// </summary>
    internal class SqlCommandBuilder
    {
        #region 字段
        private StringBuilder _stringBuilder;
        private DatabaseType _dbType;
        #endregion

        #region 构造方法
        /// <summary>
        /// 初始化SQL语句创建类
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        internal SqlCommandBuilder(DatabaseType dbType)
        {
            this._stringBuilder = new StringBuilder();
            this._dbType = dbType;
        }
        #endregion

        #region 方法
        #region 添加固定字符串
        /*/// <summary>
        /// 添加SQL左括号并返回当前SQL语句创建类
        /// </summary>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendLeftParentheses()
        {
            this._stringBuilder.Append("( ");
            return this;
        }

        /// <summary>
        /// 添加SQL右括号并返回当前SQL语句创建类
        /// </summary>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendRightParentheses()
        {
            this._stringBuilder.Append(") ");
            return this;
        }*/

        /// <summary>
        /// 添加SQL添加语句前缀并返回当前SQL语句创建类
        /// </summary>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendInsertPrefix()
        {
            this._stringBuilder.Append(" INSERT INTO ");
            return this;
        }

        /// <summary>
        /// 添加SQL更新语句前缀并返回当前SQL语句创建类
        /// </summary>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendUpdatePrefix()
        {
            this._stringBuilder.Append(" UPDATE ");
            return this;
        }

        /// <summary>
        /// 添加SQL删除语句前缀并返回当前SQL语句创建类
        /// </summary>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendDeletePrefix()
        {
            this._stringBuilder.Append(" DELETE FROM ");
            return this;
        }

        /// <summary>
        /// 添加SQL选择语句前缀并返回当前SQL语句创建类
        /// </summary>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendSelectPrefix()
        {
            this._stringBuilder.Append(" SELECT ");
            return this;
        }

        /// <summary>
        /// 添加SQL插入语句结果并返回当前SQL语句创建类
        /// </summary>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendInsertValues()
        {
            this._stringBuilder.Append("VALUES ");
            return this;
        }

        /// <summary>
        /// 添加SQL更新语句设置并返回当前SQL语句创建类
        /// </summary>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendUpdateSet()
        {
            this._stringBuilder.Append("SET ");
            return this;
        }
        #endregion

        #region 添加数据字段名或参数名
        /// <summary>
        /// 添加所有数据字段名并返回当前SQL语句创建类
        /// </summary>
        /// <param name="queryFields">数据字段名</param>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendAllColumnNames(List<SqlQueryField> queryFields)
        {
            if (queryFields != null && queryFields.Count > 0)
            {
                StringBuilder names = new StringBuilder();

                for (Int32 i = 0; i < queryFields.Count; i++)
                {
                    if (i > 0) names.Append(",");

                    SqlQueryField queryField = queryFields[i];

                    if (queryField.UseFunction)
                    {
                        names.Append(queryField.Function);
                    }

                    if (!String.IsNullOrEmpty(queryField.FieldName))
                    {
                        if (queryField.UseFunction)
                        {
                            names.Append('(');
                        }

                        if (!String.IsNullOrEmpty(queryField.TableName))
                        {
                            names.Append(queryField.TableName).Append('.');
                        }

                        names.Append(queryField.FieldName);

                        if (queryField.UseFunction)
                        {
                            names.Append(')');
                        }
                    }

                    if (!String.IsNullOrEmpty(queryField.AliasesName))
                    {
                        names.Append(" AS ").Append(queryField.AliasesName);
                    }
                }

                this._stringBuilder.Append(names.ToString()).Append(' ');
            }
            else
            {
                this._stringBuilder.Append("* ");
            }

            return this;
        }

        /// <summary>
        /// 添加所有参数组中数据字段名并返回当前SQL语句创建类
        /// </summary>
        /// <param name="dbParams">参数组列表</param>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendAllColumnNames(List<SqlParameter> dbParams)
        {
            if (dbParams != null && dbParams.Count > 0)
            {
                StringBuilder names = new StringBuilder();

                for (Int32 i = 0; i < dbParams.Count; i++)
                {
                    if (i > 0) names.Append(",");
                    names.Append(dbParams[i].ColumnName);
                }

                this._stringBuilder.Append(names.ToString()).Append(' ');
            }

            return this;
        }

        /// <summary>
        /// 添加所有参数组中数据字段名及小括号并返回当前SQL语句创建类
        /// </summary>
        /// <param name="dbParams">参数组列表</param>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendAllColumnNamesWithParentheses(List<SqlParameter> dbParams)
        {
            if (dbParams != null && dbParams.Count > 0)
            {
                this._stringBuilder.Append("( ");
                this.AppendAllColumnNames(dbParams);
                this._stringBuilder.Append(") ");
            }

            return this;
        }

        /// <summary>
        /// 添加所有参数组中参数名并返回当前SQL语句创建类
        /// </summary>
        /// <param name="dbParams">参数组列表</param>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendAllParameterNames(List<SqlParameter> dbParams)
        {
            if (dbParams != null && dbParams.Count > 0)
            {
                StringBuilder names = new StringBuilder();

                for (Int32 i = 0; i < dbParams.Count; i++)
                {
                    if (i > 0) names.Append(",");
                    names.Append(dbParams[i].ParameterName);
                }

                this._stringBuilder.Append(names.ToString()).Append(' ');
            }

            return this;
        }

        /// <summary>
        /// 添加所有参数组中参数名及小括号并返回当前SQL语句创建类
        /// </summary>
        /// <param name="dbParams">参数组列表</param>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendAllParameterNamesWithParentheses(List<SqlParameter> dbParams)
        {
            if (dbParams != null && dbParams.Count > 0)
            {
                this._stringBuilder.Append("( ");
                this.AppendAllParameterNames(dbParams);
                this._stringBuilder.Append(") ");
            }

            return this;
        }

        /// <summary>
        /// 添加所有参数组等式并返回当前SQL语句创建类
        /// </summary>
        /// <param name="dbParams">参数组列表</param>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendAllParameterEquations(List<SqlParameter> dbParams)
        {
            if (dbParams != null && dbParams.Count > 0)
            {
                StringBuilder names = new StringBuilder();

                for (Int32 i = 0; i < dbParams.Count; i++)
                {
                    if (i > 0) names.Append(",");

                    names.Append(dbParams[i].ColumnName).Append('=');

                    if (dbParams[i].IsUseParameter)
                    {
                        names.Append(dbParams[i].ParameterName);
                    }
                    else
                    {
                        names.Append(dbParams[i].Value.ToString());
                    }
                }

                this._stringBuilder.Append(names.ToString()).Append(' ');
            }

            return this;
        }
        #endregion

        #region 添加数据表名
        /// <summary>
        /// 添加SQL数据表名并返回当前SQL语句创建类
        /// </summary>
        /// <param name="tableName">数据表名</param>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendTableName(String tableName)
        {
            this._stringBuilder.Append(tableName).Append(' ');
            return this;
        }

        /// <summary>
        /// 添加SQL选择语句来自并返回当前SQL语句创建类
        /// </summary>
        /// <param name="from">数据表名或SQL语句</param>
        /// <param name="isFromSql">是否从SQL语句中选择</param>
        /// <param name="joins">Sql连接语句列表</param>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendSelectFromAndJoins(String from, Boolean isFromSql, List<ISqlJoin> joins)
        {
            Boolean hasJoins = (joins != null && joins.Count > 0);

            this._stringBuilder.Append("FROM ");

            if (!hasJoins)
            {
                this._stringBuilder.Append(from).Append(' ');
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(from).Append(' ').Append(joins[0].ToString());

                if (joins.Count > 1)
                {
                    sb.Insert(0, '(').Append(')');

                    for (Int32 i = 1; i < joins.Count; i++)
                    {
                        sb.Append(' ');
                        sb.Append(joins[i].ToString());
                        sb.Insert(0, '(').Append(')');
                    }
                }

                this._stringBuilder.Append(sb.ToString()).Append(' ');
            }

            return this;
        }

        /// <summary>
        /// 添加SQL选择语句来自并返回当前SQL语句创建类
        /// </summary>
        /// <param name="from">数据表名或SQL语句</param>
        /// <param name="isFromSql">是否从SQL语句中选择</param>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendSelectFrom(String from, Boolean isFromSql)
        {
            return this.AppendSelectFromAndJoins(from, isFromSql, null);
        }
        #endregion

        #region 添加查询语句
        /// <summary>
        /// 添加SQL Where查询语句并返回当前SQL语句创建类
        /// </summary>
        /// <param name="condition">Where条件语句</param>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendWhere(ISqlCondition condition)
        {
            if (condition != null)
            {
                this._stringBuilder.Append("WHERE ").Append(condition.ToString()).Append(' ');
            }

            return this;
        }

        /// <summary>
        /// 添加SQL Having查询语句并返回当前SQL语句创建类
        /// </summary>
        /// <param name="condition">Having条件语句</param>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendHaving(ISqlCondition condition)
        {
            if (condition != null)
            {
                this._stringBuilder.Append("HAVING ").Append(condition.ToString()).Append(' ');
            }

            return this;
        }
        #endregion

        #region 添加选择语句
        /// <summary>
        /// 添加SQL选择页面大小并返回当前SQL语句创建类
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendSelectTop(Int32 pageSize)
        {
            if (pageSize > 0)
            {
                this._stringBuilder.Append("TOP ").Append(pageSize.ToString()).Append(' ');
            }

            return this;
        }

        /// <summary>
        /// 添加SQL选择页面大小并返回当前SQL语句创建类
        /// </summary>
        /// <param name="recordStart">开始记录索引</param>
        /// <param name="pageSize">页面大小</param>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendSelectLimit(Int32 recordStart, Int32 pageSize)
        {
            if (pageSize > 0)
            {
                this._stringBuilder.Append("LIMIT ");
                
                if (recordStart > 0)
                {
                    this._stringBuilder.Append(recordStart.ToString()).Append(',');
                }
                
                this._stringBuilder.Append(pageSize.ToString()).Append(' ');
            }

            return this;
        }

        /// <summary>
        /// 添加SQL选择页面大小并返回当前SQL语句创建类
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendSelectLimit(Int32 pageSize)
        {
            return this.AppendSelectLimit(0, pageSize);
        }

        /// <summary>
        /// 添加SQL选择语句唯一并返回当前SQL语句创建类
        /// </summary>
        /// <param name="isDistinct">是否选择语句唯一</param>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendSelectDistinct(Boolean isDistinct)
        {
            if (isDistinct)
            {
                this._stringBuilder.Append("DISTINCT ");
            }

            return this;
        }

        /// <summary>
        /// 添加SQL分组语句并返回当前SQL语句创建类
        /// </summary>
        /// <param name="groupBys">Group By语句集合</param>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendSelectGroupBys(List<String> groupBys)
        {
            if (groupBys != null && groupBys.Count > 0)
            {
                this._stringBuilder.Append("GROUP BY ");

                StringBuilder names = new StringBuilder();

                for (Int32 i = 0; i < groupBys.Count; i++)
                {
                    if (i > 0) names.Append(",");
                    names.Append(groupBys[i]);
                }

                this._stringBuilder.Append(names.ToString()).Append(' ');
            }

            return this;
        }

        /// <summary>
        /// 添加所有排序并返回当前SQL语句创建类
        /// </summary>
        /// <param name="orders">查询字段名数组</param>
        /// <param name="orderReverse">是否取反</param>
        /// <returns>当前SQL语句创建类</returns>
        internal SqlCommandBuilder AppendSelectOrderBys(List<SqlOrder> orders, Boolean orderReverse)
        {
            if (orders != null && orders.Count > 0)
            {
                this._stringBuilder.Append("ORDER BY ");

                StringBuilder names = new StringBuilder();

                for (Int32 i = 0; i < orders.Count; i++)
                {
                    if (i > 0) names.Append(",");
                    names.Append(orders[i].FieldName);
                    names.Append(orders[i].GetOrderType(orderReverse) == SqlOrderType.Desc ? " DESC" : " ASC");
                }

                this._stringBuilder.Append(names.ToString()).Append(' ');
            }

            return this;
        }
        #endregion

        #region 输出SQL语句结果
        /// <summary>
        /// 输出SQL语句结果
        /// </summary>
        /// <returns>SQL语句结果</returns>
        public override String ToString()
        {
            return this._stringBuilder.ToString();
        }
        #endregion
        #endregion
    }
}