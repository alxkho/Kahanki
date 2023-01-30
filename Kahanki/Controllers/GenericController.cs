using Kahanki.Data;
using Kahanki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kahanki.Controllers;

public class GenericController<TEntity> : ControllerBase where TEntity : class, IEntity
{
    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    public GenericController(ApplicationDbContext db)
    {
        _dbContext = db;
        _dbSet = _dbContext.Set<TEntity>();
    }

    [HttpPost("Create")]
    public TEntity Create(TEntity entity)
    {
        _dbSet.Add(entity);
        _dbContext.SaveChanges();

        return _dbSet.Single(c => c.Id == entity.Id);
    }

    [HttpGet("Read")]
    public TEntity Read(string id)
    {
        return _dbSet.Single(c => c.Id == id);
    }

    [HttpPut("Update")]
    public TEntity Update([FromBody] TEntity entity)
    {
        _dbSet.Update(entity);
        _dbContext.SaveChanges();

        return _dbSet.Single(c => c.Id == entity.Id);
    }

    [HttpPost("Delete")]
    public void Delete(string id)
    {
        var entity = _dbSet.SingleOrDefault(r => r.Id == id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }
    }

    [HttpGet("GetAll")]
    public IEnumerable<TEntity> GetAll()
    {
        return _dbSet.ToList();
    }
}