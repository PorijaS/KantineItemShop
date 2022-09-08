namespace KantineAPIv2.Entities.DataRepository
{
    //User service interface that has an userId
    public interface ICurrentUserService
    {
        long userId { get; }
    }
}
