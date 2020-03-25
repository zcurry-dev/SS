--
USE SceneSwarm01

CREATE TABLE refUserSS.UserStatus(
	UserStatusID INT NOT NULL
		CONSTRAINT PK_UserStatus
		PRIMARY KEY IDENTITY
	,UserStatus NVARCHAR(255)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_UserStatus_CreatedDate
		DEFAULT GETDATE()
)

INSERT INTO refUserSS.UserStatus
VALUES
('Active', GETDATE())
,('Inactive', GETDATE())

CREATE TABLE refUserSS.UserRole(
	UserRoleID INT NOT NULL
		CONSTRAINT PK_UserRole
		PRIMARY KEY IDENTITY
	,UserRole NVARCHAR(255) NOT NULL
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_UserRole_CreatedDate
		DEFAULT GETDATE()
)

INSERT INTO refUserSS.UserRole
VALUES
('UserRole1', GETDATE())
,('UserRole2', GETDATE())

CREATE TABLE UserSS.SSUser(
	UserID INT NOT NULL
		CONSTRAINT PK_UserID
		PRIMARY KEY IDENTITY
	,UserName NVARCHAR(255) NOT NULL
	,FirstName NVARCHAR(255) NOT NULL
	,LastName NVARCHAR(255) NOT NULL
	,Email NVARCHAR(255) NOT NULL
	,DisplayName NVARCHAR(255) NOT NULL
	,UserStatusID INT NOT NULL
		CONSTRAINT FK_User_UserStatusID
		REFERENCES refUserSS.UserStatus(UserStatusID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_User_CreatedDate
		DEFAULT GETDATE()
	,LastActive	DATETIME NOT NULL
		CONSTRAINT DF_User_LastActive
		DEFAULT GETDATE()
	,PwHash VARBINARY(64) NOT NULL
	,PwSalt VARBINARY(128) NOT NULL
)

INSERT INTO UserSS.SSUser
VALUES
('zCurry', 'zach', 'curry', 'admin@ss.com', 'txDukeDog', 1, GETDATE(), GETDATE(), 0, 0)
,('john', 'john', 'doe', 'john@ss.com', 'john', 1, GETDATE(), GETDATE()
	,0xB3F8FA6C46BE5DCE7CCE9987E51BD7D0D4B03D82B7E0A55F242F7A7486EA5B7FA35B927FDF3DE1FDD8090F923A157FF05A3C425E968D998A29AF042229F40E6B
	,0xC04CC4D05ADFECE0C2C7ECFE046CF8887ED450244111E900305DC015103C70EA5E85768E265CE608EFB931C9B64A461F888F09393E45D00E5A8F9545052EC4642CB79D37C39AC0659040AA28514266D83CC1F8B850165544B3155A44A2830F68EB3E0CCE2218B00D226D3EFA790217C97D1F6DE0A61D7367DCEC878533EBE635
)
,('bob', 'bob', 'bobby', 'bob@ss.com', 'bob', 1, GETDATE(), GETDATE()
	,0xB3F8FA6C46BE5DCE7CCE9987E51BD7D0D4B03D82B7E0A55F242F7A7486EA5B7FA35B927FDF3DE1FDD8090F923A157FF05A3C425E968D998A29AF042229F40E6B
	,0xC04CC4D05ADFECE0C2C7ECFE046CF8887ED450244111E900305DC015103C70EA5E85768E265CE608EFB931C9B64A461F888F09393E45D00E5A8F9545052EC4642CB79D37C39AC0659040AA28514266D83CC1F8B850165544B3155A44A2830F68EB3E0CCE2218B00D226D3EFA790217C97D1F6DE0A61D7367DCEC878533EBE635
)

CREATE TABLE hr.UserEmployeeXRef(
	UserEmployeeXRefID INT NOT NULL
		CONSTRAINT PK_UserEmployeeXRef
		PRIMARY KEY IDENTITY
	,UserID INT NOT NULL
		CONSTRAINT FK_UserEmployeeXRef_UserID
		REFERENCES UserSS.SSUser(UserID)
	,EmployeeID INT NOT NULL
		CONSTRAINT FK_UserEmployeeXRef_EmployeeID
		REFERENCES hr.Employee(EmployeeID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_UserEmployeeXRef_CreatedDate
		DEFAULT GETDATE()
	,Zapped BIT
		CONSTRAINT DF_UserEmployeeXRef_Zapped
		DEFAULT 0
)

INSERT INTO hr.UserEmployeeXRef
VALUES
(1, 1, GETDATE(), 0)

CREATE TABLE UserSS.UserRolesXRef(
	UserRoleXRefID INT NOT NULL
		CONSTRAINT PK_UserRolesXRef
		PRIMARY KEY IDENTITY
	,UserID INT NOT NULL
		CONSTRAINT FK_UserRolesXRef_UserID
		REFERENCES UserSS.SSUser(UserID)
	,UserRoles INT NOT NULL
		CONSTRAINT FK_UserRolesXRef_UserRoleID
		REFERENCES refUserSS.UserRole(UserRoleID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_UserRolesXRef_CreatedDate
		DEFAULT GETDATE()
)

INSERT INTO UserSS.UserRolesXRef
VALUES
(1, 1, GETDATE())

CREATE TABLE refAdminSS.AdminRole(
	AdminRoleID INT NOT NULL
		CONSTRAINT PK_AdminRole
		PRIMARY KEY IDENTITY
	,AdminRole NVARCHAR(255)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_AdminRole_CreatedDate
		DEFAULT GETDATE()
)

INSERT INTO refAdminSS.AdminRole
VALUES
('AdminRole1', GETDATE())

CREATE TABLE AdminSS.SSAdmin(
	AdminID INT NOT NULL
		CONSTRAINT PK_AdminID
		PRIMARY KEY IDENTITY
	,UserID INT NOT NULL
		CONSTRAINT FK_Admin_UserID
		REFERENCES UserSS.SSUser(UserID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_Admin_CreatedDate
		DEFAULT GETDATE()
)

INSERT INTO AdminSS.SSAdmin
VALUES
(1, GETDATE())

CREATE TABLE AdminSS.AdminRolesXRef(
	AdminRolesXRefID INT NOT NULL
		CONSTRAINT PK_AdminRolesXRef
		PRIMARY KEY IDENTITY
	,AdminID INT NOT NULL
		CONSTRAINT FK_AdminRolesXRef_AdminID
		REFERENCES AdminSS.SSAdmin(AdminID)
	,UserRoles INT NOT NULL
		CONSTRAINT FK_AdminRolesXRef_AdminRoleID
		REFERENCES refAdminSS.AdminRole(AdminRoleID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_AdminRolesXRef_CreatedDate
		DEFAULT GETDATE()
)

INSERT INTO AdminSS.AdminRolesXRef
VALUES
(1, 1, GETDATE())

/*

DROP TABLE AdminSS.AdminRolesXRef
DROP TABLE AdminSS.SSAdmin
DROP TABLE refAdminSS.AdminRole
DROP TABLE UserSS.UserRolesXRef
DROP TABLE hr.UserEmployeeXRef
DROP TABLE UserSS.SSUser
DROP TABLE refUserSS.UserRole
DROP TABLE refUserSS.UserStatus

*/