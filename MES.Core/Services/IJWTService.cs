namespace MES.Core.Services
{
    public interface IJWTService
    {
        string GenerateJwtToken(string name, string userName, int roleId, string employeeId, string email, string terminalId = null);
        string GenerateTerminalToken(string terminalId, int deviceType, int plantId);
    }
}
