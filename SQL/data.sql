create database QLCHTC
go
use QLCHTC
go

create table account(
	user_name varchar(100) NOT NULL,
	password varchar(100) NOT NULL,
	auth nvarchar(20) NOT NULL,
	name nvarchar(100) NOT NULL,
	gender nvarchar(10) NOT NULL,
	phone int NOT NULL,
	address nvarchar(200) NOT NULL,
	primary key(user_name),
);

go

create table customer(
	id varchar(10) NOT NULL,
	name nvarchar(100) NOT NULL,
	gender nvarchar(10) NOT NULL,
	phone int NOT NULL,
	address nvarchar(200) NOT NULL,
	primary key(id),
);

go

create table category(
	id varchar(10) NOT NULL,
	name nvarchar(100) NOT NULL,
	primary key(id), 
);

go

create table product(
	id varchar(10) NOT NULL,
	name nvarchar(100) NOT NULL,
	price float NOT NULL,
	id_category varchar(10) NOT NULL FOREIGN KEY REFERENCES category(id),
	primary key(id),
);

go

go

create table bill(
	id varchar(10) NOT NULL,
	date_create date NOT NULL,
	total_price float NOT NULL,
	id_customer varchar(10)NOT NULL FOREIGN KEY REFERENCES customer(id),
	primary key(id),
);

go

create table bill_detail(
	id_bill varchar(10) NOT NULL FOREIGN KEY REFERENCES bill(id),
	id_product varchar(10) NOT NULL FOREIGN KEY REFERENCES product(id),
	quantity int NOT NULL,
	primary key(id_bill, id_product),
);

go

Insert into account values('admin', '21232f297a57a5a743894a0e4a801fc3', 'Admin','','',0,'')
go