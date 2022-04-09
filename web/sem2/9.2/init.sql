create database task9;
use task9;
create table students(
    id int auto_increment primary key,
    fio varchar(250),
    course int unsigned,
    birthdate date,
    email varchar(250),
    phone varchar(250),
    details text
);