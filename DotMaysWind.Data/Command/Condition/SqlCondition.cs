﻿using System;
using System.Collections.Generic;
using System.Data;

namespace DotMaysWind.Data.Command.Condition
{
    /// <summary>
    /// Sql条件语句类
    /// </summary>
    public static class SqlCondition
    {
        #region SqlBasicParameterCondition
        #region General
        /// <summary>
        /// 创建新的Sql条件语句
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <param name="op">条件运算符</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition Create(SqlParameter parameter, SqlOperator op)
        {
            return new SqlBasicParameterCondition(parameter, op);
        }

        /// <summary>
        /// 创建新的Sql条件语句
        /// </summary>
        /// <param name="parameterOne">参数一</param>
        /// <param name="parameterTwo">参数二</param>
        /// <param name="op">条件运算符</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition Create(SqlParameter parameterOne, SqlParameter parameterTwo, SqlOperator op)
        {
            return new SqlBasicParameterCondition(parameterOne, parameterTwo, op);
        }

        /// <summary>
        /// 创建新的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="op">条件运算符</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition Create(String columnName, SqlOperator op, Object value)
        {
            return new SqlBasicParameterCondition(SqlParameter.Create(columnName, value), op);
        }

        /// <summary>
        /// 创建新的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="op">条件运算符</param>
        /// <param name="dbType">数据类型</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition Create(String columnName, SqlOperator op, DbType dbType, Object value)
        {
            return new SqlBasicParameterCondition(SqlParameter.Create(columnName, dbType, value), op);
        }

        /// <summary>
        /// 创建新的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="paramName">参数名</param>
        /// <param name="op">条件运算符</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition Create(String columnName, String paramName, SqlOperator op, Object value)
        {
            return new SqlBasicParameterCondition(SqlParameter.Create(columnName, paramName, value), op);
        }

        /// <summary>
        /// 创建新的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="paramName">参数名</param>
        /// <param name="op">条件运算符</param>
        /// <param name="dbType">数据类型</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition Create(String columnName, String paramName, SqlOperator op, DbType dbType, Object value)
        {
            return new SqlBasicParameterCondition(SqlParameter.Create(columnName, paramName, dbType, value), op);
        }

        /// <summary>
        /// 创建新的Sql条件语句
        /// </summary>
        /// <param name="function">合计函数类型</param>
        /// <param name="fieldName">要查询的字段名</param>
        /// <param name="op">条件运算符</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition Create(SqlAggregateFunction function, String fieldName, SqlOperator op, Object value)
        {
            return new SqlBasicParameterCondition(SqlParameter.Create(String.Format("{0}({1})", function.ToString().ToUpperInvariant(), fieldName), value), op);
        }

        /// <summary>
        /// 创建新的Sql条件语句
        /// </summary>
        /// <param name="function">合计函数类型</param>
        /// <param name="op">条件运算符</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition Create(SqlAggregateFunction function, SqlOperator op, Object value)
        {
            return SqlCondition.Create(function, "*", op, value);
        }
        #endregion

        #region IsNull/IsNotNull
        /// <summary>
        /// 创建判断是否为空的Sql条件语句
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition IsNull(SqlParameter parameter)
        {
            return new SqlBasicParameterCondition(parameter, SqlOperator.IsNull);
        }

        /// <summary>
        /// 创建判断是否为空的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition IsNull(String columnName)
        {
            return SqlCondition.IsNull(SqlParameter.Create(columnName, null));
        }

        /// <summary>
        /// 创建判断是否非空的Sql条件语句
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition IsNotNull(SqlParameter parameter)
        {
            return new SqlBasicParameterCondition(parameter, SqlOperator.IsNotNull);
        }

        /// <summary>
        /// 创建判断是否非空的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition IsNotNull(String columnName)
        {
            return SqlCondition.IsNotNull(SqlParameter.Create(columnName, null));
        }
        #endregion

        #region Equal/NotEqual
        /// <summary>
        /// 创建判断是否相等的Sql条件语句
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition Equal(SqlParameter parameter)
        {
            return new SqlBasicParameterCondition(parameter, SqlOperator.Equal);
        }

        /// <summary>
        /// 创建判断是否相等的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition Equal(String columnName, Object value)
        {
            return SqlCondition.Equal(SqlParameter.Create(columnName, value));
        }

        /// <summary>
        /// 创建判断是否相等的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="paramName">参数名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition Equal(String columnName, String paramName, Object value)
        {
            return SqlCondition.Equal(SqlParameter.Create(columnName, paramName, value));
        }

        /// <summary>
        /// 创建判断是否相等的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="tableNameTwo">数据表名二</param>
        /// <param name="columnNameTwo">字段名二</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition EqualColumn(String columnName, String tableNameTwo, String columnNameTwo)
        {
            return SqlCondition.Equal(SqlParameter.CreateCustomAction(columnName, GetFieldName(tableNameTwo, columnNameTwo)));
        }

        /// <summary>
        /// 创建判断是否不等的Sql条件语句
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition NotEqual(SqlParameter parameter)
        {
            return new SqlBasicParameterCondition(parameter, SqlOperator.NotEqual);
        }

        /// <summary>
        /// 创建判断是否不等的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition NotEqual(String columnName, Object value)
        {
            return SqlCondition.NotEqual(SqlParameter.Create(columnName, value));
        }

        /// <summary>
        /// 创建判断是否不等的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="paramName">参数名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql查询语句类</returns>
        public static SqlBasicParameterCondition NotEqual(String columnName, String paramName, Object value)
        {
            return SqlCondition.NotEqual(SqlParameter.Create(columnName, paramName, value));
        }

        /// <summary>
        /// 创建判断是否不等的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="tableNameTwo">数据表名二</param>
        /// <param name="columnNameTwo">字段名二</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition NotEqualColumn(String columnName, String tableNameTwo, String columnNameTwo)
        {
            return SqlCondition.NotEqual(SqlParameter.CreateCustomAction(columnName, GetFieldName(tableNameTwo, columnNameTwo)));
        }
        #endregion

        #region GreaterThan/LessThan
        /// <summary>
        /// 创建判断是否大于的Sql条件语句
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition GreaterThan(SqlParameter parameter)
        {
            return new SqlBasicParameterCondition(parameter, SqlOperator.GreaterThan);
        }

        /// <summary>
        /// 创建判断是否大于的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition GreaterThan(String columnName, Object value)
        {
            return SqlCondition.GreaterThan(SqlParameter.Create(columnName, value));
        }

        /// <summary>
        /// 创建判断是否大于的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="paramName">参数名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition GreaterThan(String columnName, String paramName, Object value)
        {
            return SqlCondition.GreaterThan(SqlParameter.Create(columnName, paramName, value));
        }

        /// <summary>
        /// 创建判断是否大于的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="tableNameTwo">数据表名二</param>
        /// <param name="columnNameTwo">字段名二</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition GreaterThanColumn(String columnName, String tableNameTwo, String columnNameTwo)
        {
            return SqlCondition.GreaterThan(SqlParameter.CreateCustomAction(columnName, GetFieldName(tableNameTwo, columnNameTwo)));
        }

        /// <summary>
        /// 创建判断是否小于的Sql条件语句
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition LessThan(SqlParameter parameter)
        {
            return new SqlBasicParameterCondition(parameter, SqlOperator.LessThan);
        }

        /// <summary>
        /// 创建判断是否小于的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition LessThan(String columnName, Object value)
        {
            return SqlCondition.LessThan(SqlParameter.Create(columnName, value));
        }

        /// <summary>
        /// 创建判断是否小于的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="paramName">参数名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql查询语句类</returns>
        public static SqlBasicParameterCondition LessThan(String columnName, String paramName, Object value)
        {
            return SqlCondition.LessThan(SqlParameter.Create(columnName, paramName, value));
        }

        /// <summary>
        /// 创建判断是否小于的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="tableNameTwo">数据表名二</param>
        /// <param name="columnNameTwo">字段名二</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition LessThanColumn(String columnName, String tableNameTwo, String columnNameTwo)
        {
            return SqlCondition.LessThan(SqlParameter.CreateCustomAction(columnName, GetFieldName(tableNameTwo, columnNameTwo)));
        }
        #endregion

        #region GreaterThanOrEqual/LessThanOrEqual
        /// <summary>
        /// 创建判断是否大于等于的Sql条件语句
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition GreaterThanOrEqual(SqlParameter parameter)
        {
            return new SqlBasicParameterCondition(parameter, SqlOperator.GreaterThanOrEqual);
        }

        /// <summary>
        /// 创建判断是否大于等于的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition GreaterThanOrEqual(String columnName, Object value)
        {
            return SqlCondition.GreaterThanOrEqual(SqlParameter.Create(columnName, value));
        }

        /// <summary>
        /// 创建判断是否大于等于的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="paramName">参数名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition GreaterThanOrEqual(String columnName, String paramName, Object value)
        {
            return SqlCondition.GreaterThanOrEqual(SqlParameter.Create(columnName, paramName, value));
        }

        /// <summary>
        /// 创建判断是否大于等于的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="tableNameTwo">数据表名二</param>
        /// <param name="columnNameTwo">字段名二</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition GreaterThanOrEqualColumn(String columnName, String tableNameTwo, String columnNameTwo)
        {
            return SqlCondition.GreaterThanOrEqual(SqlParameter.CreateCustomAction(columnName, GetFieldName(tableNameTwo, columnNameTwo)));
        }

        /// <summary>
        /// 创建判断是否小于等于的Sql条件语句
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition LessThanOrEqual(SqlParameter parameter)
        {
            return new SqlBasicParameterCondition(parameter, SqlOperator.LessThanOrEqual);
        }

        /// <summary>
        /// 创建判断是否小于等于的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition LessThanOrEqual(String columnName, Object value)
        {
            return SqlCondition.LessThanOrEqual(SqlParameter.Create(columnName, value));
        }

        /// <summary>
        /// 创建判断是否小于等于的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="paramName">参数名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql查询语句类</returns>
        public static SqlBasicParameterCondition LessThanOrEqual(String columnName, String paramName, Object value)
        {
            return SqlCondition.LessThanOrEqual(SqlParameter.Create(columnName, paramName, value));
        }

        /// <summary>
        /// 创建判断是否小于等于的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="tableNameTwo">数据表名二</param>
        /// <param name="columnNameTwo">字段名二</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition LessThanOrEqualColumn(String columnName, String tableNameTwo, String columnNameTwo)
        {
            return SqlCondition.LessThanOrEqual(SqlParameter.CreateCustomAction(columnName, GetFieldName(tableNameTwo, columnNameTwo)));
        }
        #endregion

        #region Like/NotLike
        #region General
        /// <summary>
        /// 创建判断是否相似的Sql条件语句
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition Like(SqlParameter parameter)
        {
            return new SqlBasicParameterCondition(parameter, SqlOperator.Like);
        }

        /// <summary>
        /// 创建判断是否相似的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition Like(String columnName, String value)
        {
            return SqlCondition.Like(SqlParameter.Create(columnName, value));
        }

        /// <summary>
        /// 创建判断是否相似的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="paramName">参数名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition Like(String columnName, String paramName, String value)
        {
            return SqlCondition.Like(SqlParameter.Create(columnName, paramName, value));
        }

        /// <summary>
        /// 创建判断是否相似的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="tableNameTwo">数据表名二</param>
        /// <param name="columnNameTwo">字段名二</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition LikeColumn(String columnName, String tableNameTwo, String columnNameTwo)
        {
            return SqlCondition.Like(SqlParameter.CreateCustomAction(columnName, GetFieldName(tableNameTwo, columnNameTwo)));
        }

        /// <summary>
        /// 创建判断是否不相似的Sql条件语句
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition NotLike(SqlParameter parameter)
        {
            return new SqlBasicParameterCondition(parameter, SqlOperator.NotLike);
        }

        /// <summary>
        /// 创建判断是否不相似的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition NotLike(String columnName, String value)
        {
            return SqlCondition.NotLike(SqlParameter.Create(columnName, value));
        }

        /// <summary>
        /// 创建判断是否不相似的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="paramName">参数名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql查询语句类</returns>
        public static SqlBasicParameterCondition NotLike(String columnName, String paramName, String value)
        {
            return SqlCondition.NotLike(SqlParameter.Create(columnName, paramName, value));
        }

        /// <summary>
        /// 创建判断是否结尾不包含的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="tableNameTwo">数据表名二</param>
        /// <param name="columnNameTwo">字段名二</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition NotLikeColumn(String columnName, String tableNameTwo, String columnNameTwo)
        {
            return SqlCondition.NotLike(SqlParameter.CreateCustomAction(columnName, GetFieldName(tableNameTwo, columnNameTwo)));
        }
        #endregion

        #region LikeAll
        /// <summary>
        /// 创建判断是否包含的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition LikeAll(String columnName, String value)
        {
            return SqlCondition.Like(SqlParameter.Create(columnName, "%" + value + "%"));
        }

        /// <summary>
        /// 创建判断是否包含的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="paramName">参数名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition LikeAll(String columnName, String paramName, String value)
        {
            return SqlCondition.Like(SqlParameter.Create(columnName, paramName, "%" + value + "%"));
        }

        /// <summary>
        /// 创建判断是否不包含的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition NotLikeAll(String columnName, String value)
        {
            return SqlCondition.NotLike(SqlParameter.Create(columnName, "%" + value + "%"));
        }

        /// <summary>
        /// 创建判断是否不包含的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="paramName">参数名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql查询语句类</returns>
        public static SqlBasicParameterCondition NotLikeAll(String columnName, String paramName, String value)
        {
            return SqlCondition.NotLike(SqlParameter.Create(columnName, paramName, "%" + value + "%"));
        }
        #endregion

        #region LikeStartWith
        /// <summary>
        /// 创建判断是否开头包含的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition LikeStartWith(String columnName, String value)
        {
            return SqlCondition.Like(SqlParameter.Create(columnName, "%" + value));
        }

        /// <summary>
        /// 创建判断是否开头包含的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="paramName">参数名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition LikeStartWith(String columnName, String paramName, String value)
        {
            return SqlCondition.Like(SqlParameter.Create(columnName, paramName, "%" + value));
        }

        /// <summary>
        /// 创建判断是否开头不包含的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition NotLikeStartWith(String columnName, String value)
        {
            return SqlCondition.NotLike(SqlParameter.Create(columnName, "%" + value));
        }

        /// <summary>
        /// 创建判断是否开头不包含的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="paramName">参数名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql查询语句类</returns>
        public static SqlBasicParameterCondition NotLikeStartWith(String columnName, String paramName, String value)
        {
            return SqlCondition.NotLike(SqlParameter.Create(columnName, paramName, "%" + value));
        }
        #endregion

        #region LikeEndWith
        /// <summary>
        /// 创建判断是否结尾包含的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition LikeEndWith(String columnName, String value)
        {
            return SqlCondition.Like(SqlParameter.Create(columnName, value + "%"));
        }

        /// <summary>
        /// 创建判断是否结尾包含的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="paramName">参数名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition LikeEndWith(String columnName, String paramName, String value)
        {
            return SqlCondition.Like(SqlParameter.Create(columnName, paramName, value + "%"));
        }

        /// <summary>
        /// 创建判断是否结尾不包含的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition NotLikeEndWith(String columnName, String value)
        {
            return SqlCondition.NotLike(SqlParameter.Create(columnName, value + "%"));
        }

        /// <summary>
        /// 创建判断是否结尾不包含的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="paramName">参数名</param>
        /// <param name="value">数据</param>
        /// <returns>Sql查询语句类</returns>
        public static SqlBasicParameterCondition NotLikeEndWith(String columnName, String paramName, String value)
        {
            return SqlCondition.NotLike(SqlParameter.Create(columnName, paramName, value + "%"));
        }
        #endregion
        #endregion

        #region Between/NotBetween
        /// <summary>
        /// 创建判断是否在范围内的Sql条件语句
        /// </summary>
        /// <param name="parameterOne">参数一</param>
        /// <param name="parameterTwo">参数二</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition Between(SqlParameter parameterOne, SqlParameter parameterTwo)
        {
            return new SqlBasicParameterCondition(parameterOne, parameterTwo, SqlOperator.Between);
        }

        /// <summary>
        /// 创建判断是否在范围内的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="valueOne">数据一</param>
        /// <param name="valueTwo">数据二</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition Between(String columnName, Object valueOne, Object valueTwo)
        {
            return SqlCondition.Between(SqlParameter.Create(columnName, columnName + "_One", valueOne), SqlParameter.Create(columnName, columnName + "_Two", valueTwo));
        }

        /// <summary>
        /// 创建判断是否在范围内的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="paramName">参数名</param>
        /// <param name="valueOne">数据一</param>
        /// <param name="valueTwo">数据二</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition Between(String columnName, String paramName, Object valueOne, Object valueTwo)
        {
            return SqlCondition.Between(SqlParameter.Create(columnName, paramName + "_One", valueOne), SqlParameter.Create(columnName, paramName + "_Two", valueTwo));
        }

        /// <summary>
        /// 创建判断是否不在范围内的Sql条件语句
        /// </summary>
        /// <param name="parameterOne">参数一</param>
        /// <param name="parameterTwo">参数二</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition NotBetween(SqlParameter parameterOne, SqlParameter parameterTwo)
        {
            return new SqlBasicParameterCondition(parameterOne, parameterTwo, SqlOperator.NotBetween);
        }

        /// <summary>
        /// 创建判断是否不在范围内的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="valueOne">数据一</param>
        /// <param name="valueTwo">数据二</param>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicParameterCondition NotBetween(String columnName, Object valueOne, Object valueTwo)
        {
            return SqlCondition.NotBetween(SqlParameter.Create(columnName, columnName + "_One", valueOne), SqlParameter.Create(columnName, columnName + "_Two", valueTwo));
        }

        /// <summary>
        /// 创建判断是否不在范围内的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="paramName">参数名</param>
        /// <param name="valueOne">数据一</param>
        /// <param name="valueTwo">数据二</param>
        /// <returns>Sql查询语句类</returns>
        public static SqlBasicParameterCondition NotBetween(String columnName, String paramName, Object valueOne, Object valueTwo)
        {
            return SqlCondition.NotBetween(SqlParameter.Create(columnName, paramName + "_One", valueOne), SqlParameter.Create(columnName, paramName + "_Two", valueTwo));
        }
        #endregion
        #endregion

        #region SqlBasicCommandCondition
        /// <summary>
        /// 创建判断是否相等的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名称</param>
        /// <param name="command">选择语句</param>
        /// <exception cref="ArgumentNullException">选择语句不能为空</exception>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicCommandCondition Equal(String columnName, SelectCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            return new SqlBasicCommandCondition(columnName, SqlOperator.Equal, command);
        }

        /// <summary>
        /// 创建判断是否不等的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名称</param>
        /// <param name="command">选择语句</param>
        /// <exception cref="ArgumentNullException">选择语句不能为空</exception>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicCommandCondition NotEqual(String columnName, SelectCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            return new SqlBasicCommandCondition(columnName, SqlOperator.NotEqual, command);
        }

        /// <summary>
        /// 创建判断是否大于的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名称</param>
        /// <param name="command">选择语句</param>
        /// <exception cref="ArgumentNullException">选择语句不能为空</exception>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicCommandCondition GreaterThan(String columnName, SelectCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            return new SqlBasicCommandCondition(columnName, SqlOperator.GreaterThan, command);
        }

        /// <summary>
        /// 创建判断是否小于的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名称</param>
        /// <param name="command">选择语句</param>
        /// <exception cref="ArgumentNullException">选择语句不能为空</exception>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicCommandCondition LessThan(String columnName, SelectCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            return new SqlBasicCommandCondition(columnName, SqlOperator.LessThan, command);
        }

        /// <summary>
        /// 创建判断是否大于等于的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名称</param>
        /// <param name="command">选择语句</param>
        /// <exception cref="ArgumentNullException">选择语句不能为空</exception>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicCommandCondition GreaterThanOrEqual(String columnName, SelectCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            return new SqlBasicCommandCondition(columnName, SqlOperator.GreaterThanOrEqual, command);
        }

        /// <summary>
        /// 创建判断是否小于等于的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名称</param>
        /// <param name="command">选择语句</param>
        /// <exception cref="ArgumentNullException">选择语句不能为空</exception>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicCommandCondition LessThanOrEqual(String columnName, SelectCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            return new SqlBasicCommandCondition(columnName, SqlOperator.LessThanOrEqual, command);
        }

        /// <summary>
        /// 创建判断是否相似的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名称</param>
        /// <param name="command">选择语句</param>
        /// <exception cref="ArgumentNullException">选择语句不能为空</exception>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicCommandCondition Like(String columnName, SelectCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            return new SqlBasicCommandCondition(columnName, SqlOperator.Like, command);
        }

        /// <summary>
        /// 创建判断是否不相似的Sql条件语句
        /// </summary>
        /// <param name="columnName">字段名称</param>
        /// <param name="command">选择语句</param>
        /// <exception cref="ArgumentNullException">选择语句不能为空</exception>
        /// <returns>Sql条件语句</returns>
        public static SqlBasicCommandCondition NotLike(String columnName, SelectCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            return new SqlBasicCommandCondition(columnName, SqlOperator.NotLike, command);
        }
        #endregion

        #region SqlInsideParametersCondition
        /// <summary>
        /// 创建新的Sql IN条件语句
        /// </summary>
        /// <param name="parameters">参数集合</param>
        /// <exception cref="ArgumentNullException">参数集合不能为空</exception>
        /// <returns>Sql条件语句</returns>
        public static SqlInsideParametersCondition In(List<SqlParameter> parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            return new SqlInsideParametersCondition(parameters);
        }

        /// <summary>
        /// 创建新的Sql IN参数条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="dbType">数据类型</param>
        /// <param name="values">数据集合</param>
        /// <returns>Sql条件语句</returns>
        public static SqlInsideParametersCondition In(String columnName, DbType dbType, params Object[] values)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (values != null)
            {
                for (Int32 i = 0; i < values.Length; i++)
                {
                    parameters.Add(SqlParameter.Create(columnName, columnName + "_" + i.ToString(), dbType, values[i]));
                }
            }

            return new SqlInsideParametersCondition(parameters);
        }

        /// <summary>
        /// 创建新的Sql IN条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="values">数据集合</param>
        /// <returns>Sql条件语句</returns>
        public static SqlInsideParametersCondition In(String columnName, params Object[] values)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (values != null)
            {
                for (Int32 i = 0; i < values.Length; i++)
                {
                    parameters.Add(SqlParameter.Create(columnName, columnName + "_" + i.ToString(), values[i]));
                }
            }

            return new SqlInsideParametersCondition(parameters);
        }

        /// <summary>
        /// 创建新的Sql IN条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="dbType">数据类型</param>
        /// <param name="values">逗号分隔的数据集合</param>
        /// <returns>Sql条件语句</returns>
        public static SqlInsideParametersCondition In(String columnName, DbType dbType, String values)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!String.IsNullOrEmpty(values))
            {
                String[] valuesArray = values.Split(',');

                for (Int32 i = 0; i < valuesArray.Length; i++)
                {
                    parameters.Add(SqlParameter.Create(columnName, columnName + "_" + i.ToString(), dbType, valuesArray[i]));
                }
            }

            return new SqlInsideParametersCondition(parameters);
        }

        /// <summary>
        /// 创建新的Sql IN条件语句
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="columnName">字段名</param>
        /// <param name="dbType">数据类型</param>
        /// <param name="values">逗号分隔的数据集合</param>
        /// <returns>Sql条件语句</returns>
        public static SqlInsideParametersCondition In<T>(String columnName, DbType dbType, String values) where T : IConvertible
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!String.IsNullOrEmpty(values))
            {
                String[] valuesArray = values.Split(',');
                Type t = typeof(T);

                for (Int32 i = 0; i < valuesArray.Length; i++)
                {
                    Object value = Convert.ChangeType(valuesArray[i], t);
                    parameters.Add(SqlParameter.Create(columnName, columnName + "_" + i.ToString(), dbType, value));
                }
            }

            return new SqlInsideParametersCondition(parameters);
        }

        /// <summary>
        /// 创建新的Sql IN条件语句
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="values">逗号分隔的数据集合</param>
        /// <returns>Sql条件语句</returns>
        public static SqlInsideParametersCondition InInt32(String columnName, String values)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!String.IsNullOrEmpty(values))
            {
                String[] valuesArray = values.Split(',');

                for (Int32 i = 0; i < valuesArray.Length; i++)
                {
                    parameters.Add(SqlParameter.Create(columnName, columnName + "_" + i.ToString(), DbType.Int32, Convert.ToInt32(valuesArray[i])));
                }
            }

            return new SqlInsideParametersCondition(parameters);
        }
        #endregion

        #region SqlInsideCommandCondition
        /// <summary>
        /// 创建新的Sql IN条件语句
        /// </summary>
        /// <param name="columnName">字段名称</param>
        /// <param name="command">选择语句</param>
        /// <exception cref="ArgumentNullException">选择语句不能为空</exception>
        /// <returns>Sql条件语句</returns>
        public static SqlInsideCommandCondition In(String columnName, SelectCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            return new SqlInsideCommandCondition(columnName, command);
        }
        #endregion

        #region SqlConditionList
        /// <summary>
        /// 创建新的Sql条件语句集合
        /// </summary>
        /// <param name="concatType">连接类型</param>
        /// <param name="conditions">查询语句集合</param>
        /// <returns>Sql条件语句集合</returns>
        public static SqlConditionList CreateList(SqlWhereConcatType concatType, params ISqlCondition[] conditions)
        {
            SqlConditionList list = new SqlConditionList(concatType);

            if (conditions != null)
            {
                for (Int32 i = 0; i < conditions.Length; i++)
                {
                    list.Add(conditions[i]);
                }
            }
            
            return list;
        }

        /// <summary>
        /// 创建新的Sql条件语句集合
        /// </summary>
        /// <param name="concatType">连接类型</param>
        /// <param name="conditions">查询语句集合</param>
        /// <exception cref="ArgumentNullException">查询语句集合不能为空</exception>
        /// <returns>Sql条件语句集合</returns>
        public static SqlConditionList CreateList(SqlWhereConcatType concatType, List<ISqlCondition> conditions)
        {
            if (conditions == null)
            {
                throw new ArgumentNullException("conditions");
            }

            return SqlCondition.CreateList(SqlWhereConcatType.And, conditions.ToArray());
        }

        /// <summary>
        /// 创建与连接的Sql条件语句集合
        /// </summary>
        /// <param name="conditions">查询语句集合</param>
        /// <returns>Sql条件语句集合</returns>
        public static SqlConditionList And(params ISqlCondition[] conditions)
        {
            return SqlCondition.CreateList(SqlWhereConcatType.And, conditions);
        }

        /// <summary>
        /// 创建与连接的Sql条件语句集合
        /// </summary>
        /// <param name="conditions">查询语句集合</param>
        /// <returns>Sql条件语句集合</returns>
        public static SqlConditionList And(List<ISqlCondition> conditions)
        {
            return SqlCondition.CreateList(SqlWhereConcatType.And, conditions.ToArray());
        }

        /// <summary>
        /// 创建或连接的Sql条件语句集合
        /// </summary>
        /// <param name="conditions">查询语句集合</param>
        /// <returns>Sql条件语句集合</returns>
        public static SqlConditionList Or(params ISqlCondition[] conditions)
        {
            return SqlCondition.CreateList(SqlWhereConcatType.Or, conditions);
        }

        /// <summary>
        /// 创建或连接的Sql条件语句集合
        /// </summary>
        /// <param name="conditions">查询语句集合</param>
        /// <returns>Sql条件语句集合</returns>
        public static SqlConditionList Or(List<ISqlCondition> conditions)
        {
            return SqlCondition.CreateList(SqlWhereConcatType.Or, conditions.ToArray());
        }
        #endregion

        #region 私有方法
        private static String GetFieldName(String tableName, String columnName)
        {
            return (String.IsNullOrEmpty(tableName) ? columnName : tableName + '.' + columnName);
        }
        #endregion
    }
}