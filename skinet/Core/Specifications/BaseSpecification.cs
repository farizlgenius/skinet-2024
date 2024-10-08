using System;
using System.Linq.Expressions;
using Core.Interfaces;

namespace Core.Specifications;

public class BaseSpecification<T>(Expression<Func<T, bool>>? criteria) : ISpecification<T>
{
  protected BaseSpecification() : this(null) { }
  public Expression<Func<T, bool>>? Criteria => criteria;

  public Expression<Func<T, object>>? OrderBy { get; private set; }

  public Expression<Func<T, object>>? OrderByDecending { get; private set; }

  public bool IsDistinct { get; private set; }

  public int Skip { get; private set; }

  public int Take { get; private set; }

  public bool isPaggingEnable { get; private set; }

  public IQueryable<T> ApplyCriteria(IQueryable<T> query)
  {
    if (Criteria != null)
    {
      query = query.Where(criteria);
    }

    return query;
  }

  protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
  {
    OrderBy = orderByExpression;
  }

  protected void AddOrderByDecending(Expression<Func<T, object>> orderByDescExpression)
  {
    OrderByDecending = orderByDescExpression;
  }

  protected void ApplyDistinct()
  {
    IsDistinct = true;
  }

  protected void ApplyPagging(int skip, int take)
  {
    Skip = skip;
    Take = take;
    isPaggingEnable = true;
  }
}

public class BaseSpecification<T, TResult>(Expression<Func<T, bool>> criteria) : BaseSpecification<T>(criteria), ISpecification<T, TResult>
{
  public Expression<Func<T, TResult>>? Select { get; private set; }

  protected BaseSpecification() : this(null!) { }

  protected void AddSelect(Expression<Func<T, TResult>> selectExpression)
  {
    Select = selectExpression;
  }
}
