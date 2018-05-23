using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kantin.Common
{
    public static class Constants
    {
        public const string REMOTE_ADDRESS = "REMOTE_ADDR";


        //Query String
        public const string QS_ACTIONVALUE = "Action";
        public const string QS_USERLOGIN = "UserId";
        public const string QS_REQUESTID = "RequestId";
        public const string QS_STEPLABEL = "StepLabel";
        public const string QS_REVIEWCOMPLETE = "ReviewComplete";
        public const string QS_INCIDENTNO = "IncidentNo";
        public const string QS_REQUESTOR = "Requestor";
        public const string QS_ISREJECT = "IsReject";
        public const string QS_ISREVISE = "IsRevise";
        public const string QS_PROCESSNAME = "ProcessName";
        public const string QS_TASKID = "TaskID";
        public const string QS_TASKSTATUS = "TaskStatus";
        public const string QS_TASKSUBSTATUS = "TaskSubstatus";
        public const string QS_TASKUSER = "TaskUser";

        //Session
        public const string CURRENT_USER = "CurrentUser";
        public const string CURRENT_USER_NAME = "CurrentUserName";
        public const string SESSION_ERROR = "ErrorMessage";
        public const string TICKET_STATUS = "TicketStatusID";
        public const string SIMPLE_LOGIN_USER = "SimpleUserId";
        public const string USERID = "UserID";
        public const string USERNAME = "UserName";
        public const string ROLEID = "RoleId";
        public const string ROLENAME = "RoleName";

        //Format
        public const string DATETIME_FORMAT_STRING = "dd MMM yyyy HH:mm:ss";
        public const string DATE_FORMAT_STRING = "dd MMM yyyy";
        public const string TIME_FORMAT_STRING = "HH:mm:ss";
        public const string REPORT_PARAM_DATE_FORMAT_STRING = "yyyy/MM/dd";

        //Status
        public const string STATUS_INPROGRESS = "IN PROGRESS";
        public const string STATUS_COMPLETED = "COMPLETED";
        public const string STATUS_CREATED = "CREATED";
        public const string STATUS_APPROVED = "APPROVED";
        public const string STATUS_REJECTED = "REJECTED";
        public const string STATUS_REVISED = "REVISED";

        public const int ACTIVE_USER = 1;
        public const int NOT_ACTIVE_USER = 2;

        public const string ACTIVITY_INSERT = "Insert";
        public const string ACTIVITY_UPDATE = "Update";
        public const string ACTIVITY_DELETE = "Delete";


        // Rbac Acces Level Menu
        public const string READACCES = "READACCES";
        public const string CREATEACCES = "CREATEACCES";
        public const string EDITACCES = "EDITACCES";
        public const string DELETEACCES = "DELETEACCES";

        public static class Login
        {
            public const string LOGOUT = "Logout";
        }

        public static class TypeFile
        {
            public const string Image = "Masukkan file *.jpg, *.jpeg, *.png, *.gif";
            public const string Excel = "Masukkan file *.xls";

        }

        public static class PRRequestType
        {
            public const string BAU = "0";
            public const string Project = "1";
        }

        public static class Messages
        {
            public const string INVALID_DATA = "Input data tidak valid";
        }
    }
}
