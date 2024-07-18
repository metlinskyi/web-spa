namespace TranslationManagement.Data;

public class EntityException : Exception 
{
    public EntityException(string reason) : base(reason)
    {
    }
}


public class EntityException<TEntity> : EntityException 
    where TEntity : Entity
{
    public EntityException(TEntity entity, string reason) : base(reason)
    {
    }
}