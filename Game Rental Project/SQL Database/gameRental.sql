/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2017                    */
/* Created on:     5/30/2022 6:11:29 PM                         */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('game') and o.name = 'FK_GAME_ADD GAME_ADMIN')
alter table game
   drop constraint "FK_GAME_ADD GAME_ADMIN"
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('game') and o.name = 'FK_GAME_SUPPLY_GA_VENDOR')
alter table game
   drop constraint FK_GAME_SUPPLY_GA_VENDOR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('game') and o.name = 'FK_GAME_UPDATE_ADMIN')
alter table game
   drop constraint FK_GAME_UPDATE_ADMIN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('rent') and o.name = 'FK_RENT_RENT_CLIENT')
alter table rent
   drop constraint FK_RENT_RENT_CLIENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('rent') and o.name = 'FK_RENT_RENT2_GAME')
alter table rent
   drop constraint FK_RENT_RENT2_GAME
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('"return"') and o.name = 'FK_RETURN_RETURN_CLIENT')
alter table "return"
   drop constraint FK_RETURN_RETURN_CLIENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('"return"') and o.name = 'FK_RETURN_RETURN2_GAME')
alter table "return"
   drop constraint FK_RETURN_RETURN2_GAME
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('"update admin"') and o.name = 'FK_UPDATE A_UPD ADMIN_ADMIN')
alter table "update admin"
   drop constraint "FK_UPDATE A_UPD ADMIN_ADMIN"
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('"update admin"') and o.name = 'FK_UPDATE A_UPDATE AD_ADMIN')
alter table "update admin"
   drop constraint "FK_UPDATE A_UPDATE AD_ADMIN"
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('"update clien"') and o.name = 'FK_UPDATE C_UPD CLIEN_CLIENT')
alter table "update clien"
   drop constraint "FK_UPDATE C_UPD CLIEN_CLIENT"
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('"update clien"') and o.name = 'FK_UPDATE C_UPDATE CL_CLIENT')
alter table "update clien"
   drop constraint "FK_UPDATE C_UPDATE CL_CLIENT"
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('"user"') and o.name = 'FK_USER_ADMIN?=''Y_ADMIN')
alter table "user"
   drop constraint "FK_USER_ADMIN?='Y_ADMIN"
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('"user"') and o.name = 'FK_USER_CLIENT?=''_CLIENT')
alter table "user"
   drop constraint "FK_USER_CLIENT?='_CLIENT"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('admin')
            and   type = 'U')
   drop table admin
go

if exists (select 1
            from  sysobjects
           where  id = object_id('client')
            and   type = 'U')
   drop table client
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('game')
            and   name  = 'add_game_FK'
            and   indid > 0
            and   indid < 255)
   drop index game.add_game_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('game')
            and   name  = 'update_FK'
            and   indid > 0
            and   indid < 255)
   drop index game.update_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('game')
            and   name  = 'add game_FK'
            and   indid > 0
            and   indid < 255)
   drop index game."add game_FK"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('game')
            and   type = 'U')
   drop table game
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('rent')
            and   name  = 'rent2_FK'
            and   indid > 0
            and   indid < 255)
   drop index rent.rent2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('rent')
            and   name  = 'rent_FK'
            and   indid > 0
            and   indid < 255)
   drop index rent.rent_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('rent')
            and   type = 'U')
   drop table rent
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"return"')
            and   name  = 'return2_FK'
            and   indid > 0
            and   indid < 255)
   drop index "return".return2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"return"')
            and   name  = 'return_FK'
            and   indid > 0
            and   indid < 255)
   drop index "return".return_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"return"')
            and   type = 'U')
   drop table "return"
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"update admin"')
            and   name  = 'update admin2_FK'
            and   indid > 0
            and   indid < 255)
   drop index "update admin"."update admin2_FK"
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"update admin"')
            and   name  = 'update admin_FK'
            and   indid > 0
            and   indid < 255)
   drop index "update admin"."update admin_FK"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"update admin"')
            and   type = 'U')
   drop table "update admin"
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"update clien"')
            and   name  = 'update clien2_FK'
            and   indid > 0
            and   indid < 255)
   drop index "update clien"."update clien2_FK"
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"update clien"')
            and   name  = 'update clien_FK'
            and   indid > 0
            and   indid < 255)
   drop index "update clien"."update clien_FK"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"update clien"')
            and   type = 'U')
   drop table "update clien"
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"user"')
            and   name  = 'client?=''y''_FK'
            and   indid > 0
            and   indid < 255)
   drop index "user"."client?='y'_FK"
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"user"')
            and   name  = 'admin?=''y''_FK'
            and   indid > 0
            and   indid < 255)
   drop index "user"."admin?='y'_FK"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"user"')
            and   type = 'U')
   drop table "user"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('vendor')
            and   type = 'U')
   drop table vendor
go

/*==============================================================*/
/* Table: admin                                                 */
/*==============================================================*/
create table admin (
   A_ID                 bigint               not null,
   name                 varchar(20)          null,
   phone                varchar(20)          null,
   address              varchar(20)          null,
   email                varchar(20)          null,
   password             varchar(20)          null,
   constraint PK_ADMIN primary key (A_ID)
)
go

/*==============================================================*/
/* Table: client                                                */
/*==============================================================*/
create table client (
   Client_ID            bigint               not null,
   name                 varchar(20)          null,
   phone                varchar(20)          null,
   address              varchar(20)          null,
   email                varchar(20)          null,
   password             varchar(20)          null,
   constraint PK_CLIENT primary key (Client_ID)
)
go

/*==============================================================*/
/* Table: game                                                  */
/*==============================================================*/
create table game (
   vendor_ID            bigint               not null,
   ID_game              bigint               not null,
   A_ID                 bigint               not null,
   adm_A_ID             bigint               not null,
   name                 varchar(20)          null,
   year                 numeric(4)           null,
   category             varchar(10)          null,
   add_date             datetime             null,
   constraint PK_GAME primary key (vendor_ID, ID_game)
)
go

/*==============================================================*/
/* Index: "add game_FK"                                         */
/*==============================================================*/




create nonclustered index "add game_FK" on game (adm_A_ID ASC)
go

/*==============================================================*/
/* Index: update_FK                                             */
/*==============================================================*/




create nonclustered index update_FK on game (A_ID ASC)
go

/*==============================================================*/
/* Index: add_game_FK                                           */
/*==============================================================*/




create nonclustered index add_game_FK on game (vendor_ID ASC)
go

/*==============================================================*/
/* Table: rent                                                  */
/*==============================================================*/
create table rent (
   Client_ID            bigint               not null,
   vendor_ID            bigint               not null,
   ID_game              bigint               not null,
   rent_date            datetime             null,
   constraint PK_RENT primary key (Client_ID, vendor_ID, ID_game)
)
go

/*==============================================================*/
/* Index: rent_FK                                               */
/*==============================================================*/




create nonclustered index rent_FK on rent (Client_ID ASC)
go

/*==============================================================*/
/* Index: rent2_FK                                              */
/*==============================================================*/




create nonclustered index rent2_FK on rent (vendor_ID ASC,
  ID_game ASC)
go

/*==============================================================*/
/* Table: "return"                                              */
/*==============================================================*/
create table "return" (
   Client_ID            bigint               not null,
   vendor_ID            bigint               not null,
   ID_game              bigint               not null,
   return_date          datetime             null,
   constraint PK_RETURN primary key (Client_ID, vendor_ID, ID_game)
)
go

/*==============================================================*/
/* Index: return_FK                                             */
/*==============================================================*/




create nonclustered index return_FK on "return" (Client_ID ASC)
go

/*==============================================================*/
/* Index: return2_FK                                            */
/*==============================================================*/




create nonclustered index return2_FK on "return" (vendor_ID ASC,
  ID_game ASC)
go

/*==============================================================*/
/* Table: "update admin"                                        */
/*==============================================================*/
create table "update admin" (
   A_ID                 bigint               not null,
   adm_A_ID             bigint               not null,
   constraint "PK_UPDATE ADMIN" primary key (A_ID, adm_A_ID)
)
go

/*==============================================================*/
/* Index: "update admin_FK"                                     */
/*==============================================================*/




create nonclustered index "update admin_FK" on "update admin" (A_ID ASC)
go

/*==============================================================*/
/* Index: "update admin2_FK"                                    */
/*==============================================================*/




create nonclustered index "update admin2_FK" on "update admin" (adm_A_ID ASC)
go

/*==============================================================*/
/* Table: "update clien"                                        */
/*==============================================================*/
create table "update clien" (
   Client_ID            bigint               not null,
   cli_Client_ID        bigint               not null,
   constraint "PK_UPDATE CLIEN" primary key (Client_ID, cli_Client_ID)
)
go

/*==============================================================*/
/* Index: "update clien_FK"                                     */
/*==============================================================*/




create nonclustered index "update clien_FK" on "update clien" (Client_ID ASC)
go

/*==============================================================*/
/* Index: "update clien2_FK"                                    */
/*==============================================================*/




create nonclustered index "update clien2_FK" on "update clien" (cli_Client_ID ASC)
go

/*==============================================================*/
/* Table: "user"                                                */
/*==============================================================*/
create table "user" (
   A_ID                 bigint               not null,
   Client_ID            bigint               not null,
   name                 varchar(20)          null,
   phone                varchar(20)          null,
   address              varchar(20)          null,
   email                varchar(20)          null,
   password             varchar(20)          null,
   type                 char(1)              null,
   constraint PK_USER primary key (A_ID, Client_ID)
)
go

/*==============================================================*/
/* Index: "admin?='y'_FK"                                       */
/*==============================================================*/




create nonclustered index "admin?='y'_FK" on "user" (A_ID ASC)
go

/*==============================================================*/
/* Index: "client?='y'_FK"                                      */
/*==============================================================*/




create nonclustered index "client?='y'_FK" on "user" (Client_ID ASC)
go

/*==============================================================*/
/* Table: vendor                                                */
/*==============================================================*/
create table vendor (
   vendor_ID            bigint               not null,
   name                 varchar(20)          null,
   constraint PK_VENDOR primary key (vendor_ID)
)
go

alter table game
   add constraint "FK_GAME_ADD GAME_ADMIN" foreign key (adm_A_ID)
      references admin (A_ID)
go

alter table game
   add constraint FK_GAME_SUPPLY_GA_VENDOR foreign key (vendor_ID)
      references vendor (vendor_ID)
go

alter table game
   add constraint FK_GAME_UPDATE_ADMIN foreign key (A_ID)
      references admin (A_ID)
go

alter table rent
   add constraint FK_RENT_RENT_CLIENT foreign key (Client_ID)
      references client (Client_ID)
go

alter table rent
   add constraint FK_RENT_RENT2_GAME foreign key (vendor_ID, ID_game)
      references game (vendor_ID, ID_game)
go

alter table "return"
   add constraint FK_RETURN_RETURN_CLIENT foreign key (Client_ID)
      references client (Client_ID)
go

alter table "return"
   add constraint FK_RETURN_RETURN2_GAME foreign key (vendor_ID, ID_game)
      references game (vendor_ID, ID_game)
go

alter table "update admin"
   add constraint "FK_UPDATE A_UPD ADMIN_ADMIN" foreign key (adm_A_ID)
      references admin (A_ID)
go

alter table "update admin"
   add constraint "FK_UPDATE A_UPDATE AD_ADMIN" foreign key (A_ID)
      references admin (A_ID)
go

alter table "update clien"
   add constraint "FK_UPDATE C_UPD CLIEN_CLIENT" foreign key (cli_Client_ID)
      references client (Client_ID)
go

alter table "update clien"
   add constraint "FK_UPDATE C_UPDATE CL_CLIENT" foreign key (Client_ID)
      references client (Client_ID)
go

alter table "user"
   add constraint "FK_USER_ADMIN?='Y_ADMIN" foreign key (A_ID)
      references admin (A_ID)
go

alter table "user"
   add constraint "FK_USER_CLIENT?='_CLIENT" foreign key (Client_ID)
      references client (Client_ID)
go


