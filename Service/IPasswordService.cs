namespace Service
{
    public interface IPasswordService
    {
        int CheckPasswordStrength(string password);
    }
}