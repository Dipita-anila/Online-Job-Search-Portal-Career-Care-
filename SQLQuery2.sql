create database CareerCareDB;
use CareerCareDB;

create table Registration(
	RegId int not null identity primary key,
	Name varchar(100),
	Email varchar(100),
	Passwd varchar(100)
	);
	
select * from Registration


create table JobSeekerProfile(
	JsId int not null identity primary key,
	JsName varchar(50),
	JsEmail varchar(50),
	JsDateOfBirth varchar(50),
	JsPhone int,
	JsGender varchar(50),
	JsAddress varchar(50),
	JsPassword varchar(50),
	JsCurrentPosition varchar(50),
	JsSkills varchar(50),
	JsImagePath varchar(50),
	JsNewPassword varchar(50)
);
	
select * from JobSeekerProfile;


create table CompanyProfile(
		CmpId int not null identity primary key,
		CmpName varchar(50),
		CmpHeadQ varchar(50),
		CmpFounded varchar(50),
		CmpFounders varchar(50),
		CmpCeo varchar(50),
		CmpEmail varchar(50),
		CmpContact varchar(50),
		CmpWebsite varchar(50),
		CmpDescription varchar(100),
		CmpLogo varchar(50),
		CmpPassword varchar(50)
		);
		
delete from CompanyProfile where CmpId=4;

select * from CompanyProfile;

alter table CompanyProfile 
add CmpNewPassword varchar(50);		
		

delete from CompanyProfile;


create table JobPost(
	JobId int not null identity primary key,
	JobTitle varchar(50),
	JobDes  varchar(100),
	JobRequiredSkill varchar(100),
	JobExperience varchar(100),
	JobPostedDate varchar(50),
	JobLocation varchar(50),
	JobVacancy varchar(50),
	JobDeadLine varchar(50),
	JobSalary varchar(50),
	JobNature varchar(50),
	JobTag varchar(50),
	CmpId int,
	CONSTRAINT JobPostFK FOREIGN KEY(CmpId) REFERENCES CompanyProfile(CmpId)
	);
	
	
		Select * from JobPost;
		delete from JobPost where JobId = 3;
		insert into JobPost 
		values('music writer','this is for the music writer ','song skill','Experienced','12-jan-2022','dhaka','yes','22-mar-2022','20k','off-day','music-writer',3);

create table Blog(
	BlogId int not null identity primary key,
	BlogTitle varchar(50),
	BlogDes varchar(100),
	BlogTag varchar(50),
	BlogImgPath varchar(50),
	BlogCatag varchar(50),
	CmpId int,
	CONSTRAINT BlogFK FOREIGN KEY(CmpId) REFERENCES CompanyProfile(CmpId)
	);

select * from Blog;
delete from Blog where BlogId=1;

ALTER TABLE Blog
ALTER COLUMN BlogDes varchar(2000);
ALTER TABLE Blog
ALTER COLUMN BlogTitle varchar(500);



create table BlogComments(
	CommentId int not null identity primary key,
	React int,
	CommenterName varchar(200),
	CommenterPic varchar(100),
	Comment varchar(1000),
	BlogId int,
	
	
	CONSTRAINT BlogCommentsFK FOREIGN KEY(BlogId) REFERENCES Blog(BlogId)
	);
	
select * from BlogComments;
delete from BlogComments;







create table Applications(
	IdApp int not null identity primary key,
	JobTitle varchar(150),
	CmpName varchar(100),
	JsName varchar(150),
	CV varchar(150),
	JobId int,
	JsId int,

	CONSTRAINT JobPostTable FOREIGN KEY(JobId) REFERENCES JobPost(JobId),
	CONSTRAINT JobSeekerTable FOREIGN KEY(JsId) REFERENCES JobSeekerProfile(JsId)
	);
	
	delete from Applications;
	
	ALTER TABLE Applications
	ADD CompanyLogo varchar(150);
	
	select * from Applications;
	



-- Here is the join sql ----------

select CompanyProfile.CmpName ,CompanyProfile.CmpDescription , CompanyProfile.CmpEmail , JobPost.JobTitle, JobPost.JobSalary from CompanyProfile INNER JOIN JobPost ON CompanyProfile.CmpId = JobPost.CmpId where (JobPost.JobLocation='dhaka' or JobPost.JobId=3);