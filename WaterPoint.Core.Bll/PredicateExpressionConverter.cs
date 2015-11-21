using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Bll
{
    public class PredicateExpressionConverter : ExpressionVisitor
    {
        private StringBuilder _sb;

        private string _whereClause;
        private string _parentTable;

        public string Convert(string parentTable, Expression expression)
        {
            _sb = new StringBuilder();
            _parentTable = parentTable;

            Visit(expression);

            _whereClause = _sb.ToString();

            return _whereClause;
        }

        protected override Expression VisitUnary(UnaryExpression u)
        {
            switch (u.NodeType)
            {
                case ExpressionType.Not:
                    _sb.Append(" NOT ");
                    Visit(u.Operand);
                    break;
                case ExpressionType.Convert:
                    Visit(u.Operand);
                    break;
                default:
                    throw new NotSupportedException(
                        $"The unary operator '{u.NodeType}' is not supported");
            }
            return u;
        }

        protected override Expression VisitBinary(BinaryExpression b)
        {
            _sb.Append("(");

            Visit(b.Left);

            switch (b.NodeType)
            {
                case ExpressionType.AndAlso:
                case ExpressionType.And:
                    _sb.Append(" AND ");
                    break;

                case ExpressionType.OrElse:
                case ExpressionType.Or:
                    _sb.Append(" OR ");
                    break;

                case ExpressionType.Equal:
                    _sb.Append(IsNullConstant(b.Right) ? " IS " : " = ");
                    break;

                case ExpressionType.NotEqual:
                    _sb.Append(IsNullConstant(b.Right) ? " IS NOT " : " <> ");
                    break;

                case ExpressionType.LessThan:
                    _sb.Append(" < ");
                    break;

                case ExpressionType.LessThanOrEqual:
                    _sb.Append(" <= ");
                    break;

                case ExpressionType.GreaterThan:
                    _sb.Append(" > ");
                    break;

                case ExpressionType.GreaterThanOrEqual:
                    _sb.Append(" >= ");
                    break;

                default:
                    throw new NotSupportedException(
                        $"The binary operator '{b.NodeType}' is not supported");

            }

            Visit(b.Right);

            _sb.Append(")");

            return b;
        }

        protected override Expression VisitConstant(ConstantExpression c)
        {
            var q = c.Value as IQueryable;

            if (q != null)
                return c;

            if (c.Value == null)
            {
                _sb.Append("NULL");
                return c;
            }

            switch (Type.GetTypeCode(c.Value.GetType()))
            {
                case TypeCode.Boolean:
                    _sb.Append(((bool)c.Value) ? 1 : 0);
                    break;

                case TypeCode.String:
                case TypeCode.DateTime:
                case TypeCode.Object:
                    throw new NotSupportedException($"Please parameterize '{c.Value}'.");

                default:
                    _sb.Append(c.Value);
                    break;
            }

            return c;
        }

        protected override Expression VisitMember(MemberExpression m)
        {
            if (m.Expression != null)
            {
                switch (m.Expression.NodeType)
                {
                    case ExpressionType.Parameter:
                        //add other table's reference here by m.Member.CustomAttributes
                        _sb.Append($"{_parentTable}.[{m.Member.Name}]");
                        return m;

                    case ExpressionType.MemberAccess:
                    case ExpressionType.Constant:
                        _sb.Append($"@{m.Member.Name.ToLower()}");
                        return m;
                }
            }

            throw new NotSupportedException(
                $"{m.Member.Name} value is not supported, please parameterize it.");
        }

        protected bool IsNullConstant(Expression exp)
        {
            return (exp.NodeType == ExpressionType.Constant && ((ConstantExpression)exp).Value == null);
        }

        //protected override Expression VisitMethodCall(MethodCallExpression m)
        //{
        //    if (m.Method.DeclaringType == typeof(Queryable) && m.Method.Name == "Where")
        //    {
        //        Visit(m.Arguments[0]);

        //        var lambda = (LambdaExpression)StripQuotes(m.Arguments[1]);

        //        Visit(lambda.Body);

        //        return m;
        //    }

        //    switch (m.Method.Name)
        //    {
        //        case "Take":
        //            if (ParseTakeExpression(m))
        //            {
        //                var nextExpression = m.Arguments[0];
        //                return Visit(nextExpression);
        //            }
        //            break;
        //        case "Skip":
        //            if (ParseSkipExpression(m))
        //            {
        //                var nextExpression = m.Arguments[0];
        //                return Visit(nextExpression);
        //            }
        //            break;
        //        case "OrderBy":
        //            if (ParseOrderByExpression(m, "ASC"))
        //            {
        //                var nextExpression = m.Arguments[0];
        //                return Visit(nextExpression);
        //            }
        //            break;
        //        case "OrderByDescending":
        //            if (ParseOrderByExpression(m, "DESC"))
        //            {
        //                var nextExpression = m.Arguments[0];
        //                return Visit(nextExpression);
        //            }
        //            break;
        //    }

        //    throw new NotSupportedException($"The method '{m.Method.Name}' is not supported");
        //}


        //private bool ParseOrderByExpression(MethodCallExpression expression, string order)
        //{
        //    var unary = (UnaryExpression)expression.Arguments[1];
        //    var lambdaExpression = (LambdaExpression)unary.Operand;

        //    lambdaExpression = (LambdaExpression)Evaluator.PartialEval(lambdaExpression);

        //    var body = lambdaExpression.Body as MemberExpression;

        //    if (body == null)
        //        return false;

        //    OrderBy = string.IsNullOrEmpty(OrderBy)
        //        ? $"{body.Member.Name} {order}"
        //        : $"{OrderBy}, {body.Member.Name} {order}";

        //    return true;
        //}

        //private bool ParseTakeExpression(MethodCallExpression expression)
        //{
        //    var sizeExpression = (ConstantExpression)expression.Arguments[1];

        //    int size;

        //    if (!int.TryParse(sizeExpression.Value.ToString(), out size))
        //        return false;

        //    Take = size;

        //    return true;
        //}

        //private bool ParseSkipExpression(MethodCallExpression expression)
        //{
        //    var sizeExpression = (ConstantExpression)expression.Arguments[1];

        //    int size;

        //    if (!int.TryParse(sizeExpression.Value.ToString(), out size))
        //        return false;

        //    Skip = size;

        //    return true;
        //}
    }
}
