namespace SafeHaven.DAL.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; init; }

    public override bool Equals(object? obj)
    {
        if (obj is not BaseEntity other)
        {
            return false;
        }

        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}