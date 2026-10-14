using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MES.Core
{
    public class Enum
    {
        public enum UserType
        {
            Operator = 1,
            LineSupervisor = 2,
            QualityInspector = 3,
            PlantManager = 4,
            SystemAdmin = 5
        }

        public enum DeviceType
        {
            Terminal = 1,
            BarcodeScanner = 2,
            Tablet = 3,
            WebBrowser = 4
        }

        public enum ErrorCode
        {
            InternalServerError = 500,
            AuthticationFailed = 3001,
            NotFound = 4000,
            Validation = 4001,
            NoDataFound = 4003,
            AttemptFailed = 5001,
            UserAlreadyExist = 6001,
            RoleAlreadyExist = 6002,
            RoleAlreadyMaptoUser = 6004,
            InvalidRequest = 104,
            EmptyUsernameOrPassword = 103,
            NoRoleFound = 107,
            UserIsInactiveOrDeleted = 109,
            LoginFailed = 2,
            DB_Connection_Error = 18456,
            No_Internet_Error = 53
        }

        public enum MessageCode
        {
            Sucess = 200,
            CreatedSuccessfully = 201,
            PasswordUpdateSucessfully = 9101,
            StatusUpdatedSuccessfully = 9102
        }

        public enum PageCode
        {
            Sucess = 1,
            Warn = 2,
            Failed = 3
        }

        public enum STATUS_CODE
        {
            Success = 1,
            Warn = 2,
            Failed = 3
        }

        public enum LogEnum
        {
            Information,
            Debug,
            Error
        }
    }
}
