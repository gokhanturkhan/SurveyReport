using DAL.Abstract;
using ENT.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EntityFramework
{
    public class EfEntityRepositoryDal<TEntity> : IEntityRepository<TEntity>
        where TEntity : class,IEntity,new()
    {
        SurveyReportDbContext _surveyReportDbContext;
        public EfEntityRepositoryDal(SurveyReportDbContext surveyReportDbContext)
        {
            _surveyReportDbContext = surveyReportDbContext;
        }
        public void Add(TEntity entity)
        {       
                var addedEntity = _surveyReportDbContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                _surveyReportDbContext.SaveChanges();            
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            
                return _surveyReportDbContext.Set<TEntity>().SingleOrDefault(filter);
            
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {

                return filter == null ? _surveyReportDbContext.Set<TEntity>().ToList() 
                    : _surveyReportDbContext.Set<TEntity>().Where(filter).ToList();         
        }

        public void Remove(TEntity entity)
        {
                var deletedEntity = _surveyReportDbContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                 _surveyReportDbContext.SaveChanges();
            
        }

        public void Update(TEntity entity)
        {
                var updatedEntity = _surveyReportDbContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
             _surveyReportDbContext.SaveChanges();
            
        }
    }
}
