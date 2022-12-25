CREATE TABLE [dbo].[Orders] (
    [OId]      INT        IDENTITY (1, 1) NOT NULL,
    [Sid]      INT        NULL,
    [customer] NCHAR (10) NULL,
    [phone]    NCHAR (12) NULL,
    [number]   INT        NULL,
    PRIMARY KEY CLUSTERED ([OId] ASC)
);

CREATE TABLE [dbo].[Shoes] (
    [SId]       INT        NOT NULL,
    [model]     NCHAR (10) NULL,
    [origin]    NCHAR (10) NULL,
    [prize]     NCHAR (10) NULL,
    [inventory] INT        NULL,
    PRIMARY KEY CLUSTERED ([SId] ASC)
);

insert into Shoes values
(1,'Loafers','Japan','500￥',100);
insert into Shoes values
(2,'Mary Jane','Britain','1200￥',20);
insert into Shoes values
(3,'Platform','France','800￥',12);
insert into Shoes values
(4,'Canvas','America','8200￥',2);

insert into Orders values
(1,'Jan29th','13761570831',2);