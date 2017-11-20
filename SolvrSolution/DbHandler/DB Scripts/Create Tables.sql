Use SolvrDB;

create table users	 (
	id int identity(1,1)primary key ,
	name varchar(100),
	email varchar(100),
	username varchar(31),
	password varchar(50),
	isAdmin BIT,
	dateCreated datetime
);

create table categories(
	id int identity(1,1)primary key ,
	category varchar(30)
);

create table tags(
	id varchar(20) primary key
);

create table posts (
	id int identity(1,1)primary key ,
	title varchar(50),
	description varchar(1500),
	bumpTime datetime, 
	dateCreated datetime,

	postype VARCHAR(20),
	isLocked BIT,
	altDescription varchar(1000),
	zipcode varchar (10),
	address varchar(50),

	userid int NOT NULL FOREIGN KEY REFERENCES users(id),
	categoryid int NOT NULL FOREIGN KEY REFERENCES categories(id)
);
	
create table comments (
	id int identity(1,1)primary key ,
	dateCreated datetime,
	text varchar(255),

	commenttype VARCHAR(20),
	timeAccepted datetime,
	isAccepted BIT,

	userid int FOREIGN KEY REFERENCES users(id),
	postid int FOREIGN KEY REFERENCES posts(id)
);

create table votes (
	id int identity(1,1)primary key ,
	isUpvoted BIT,
	userid int FOREIGN KEY REFERENCES users(id),
	commentid int FOREIGN KEY REFERENCES comments(id)
);

create table reports(
	id int identity(1,1)primary key ,
	title varchar(30),
	description varchar(255),
	dateCreated datetime,
	userid int FOREIGN KEY REFERENCES users(id),
	postid int FOREIGN KEY REFERENCES posts(id),
	coomentid int FOREIGN KEY REFERENCES comments(id)
);

create table taglists(
	id int identity(1,1)primary key ,
	postid int FOREIGN KEY REFERENCES posts(id),
	tagsid varchar(20) FOREIGN KEY REFERENCES tags(id)
);



