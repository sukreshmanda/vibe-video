namespace vibe_api.Validator;

public interface IValidator <in T>
{
    void Validate(T entity);
}