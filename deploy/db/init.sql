CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory"
(
    "MigrationId"
                     character
                         varying(150)      NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY
        (
         "MigrationId"
            )
);

START TRANSACTION;

CREATE TABLE "Customers"
(
    "Id"        uuid        NOT NULL,
    "FirstName" varchar(60) NOT NULL,
    "LastName"  varchar(60) NOT NULL,
    "Cpf"       varchar(11) NOT NULL,
    "BirthDate" date        NOT NULL,
    CONSTRAINT "PK_Customers" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240511160730_InitialDatabase', '8.0.4');

COMMIT;

