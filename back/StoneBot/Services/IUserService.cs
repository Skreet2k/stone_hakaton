namespace StoneBot.Services;

public interface IUserService
{
    Task Init(long userId);
}