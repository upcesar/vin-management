--Begin Vehicles

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Vehicles' AND TABLE_TYPE = 'BASE TABLE')
	DROP TABLE Vehicles
GO

CREATE TABLE Vehicles (
       Id                             nvarchar(128)        NOT NULL     PRIMARY KEY                  DEFAULT NEWID(),
       CreatedAt                      datetimeoffset(7)    NOT NULL                                  DEFAULT GETUTCDATE(),
       UpdatedAt                      datetimeoffset(7)        NULL,
       ChassisNumber                  varchar(10)          NOT NULL,
	   VehicleType                    int                  NOT NULL,
       Color                          varchar(10)          NOT NULL                                  DEFAULT 0,
	   NumPassengers                  tinyint              NOT NULL
);	

--End Vehicles