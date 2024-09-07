namespace StoneBot.Services;

public interface IUserService
{
    Task Init(long userId, string username, string firstName, string lastName);
}