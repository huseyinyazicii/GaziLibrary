# GaziLibrary
Database Management Systems Project

## Using
- Asp.Net Core
- Oracle
- C#
- MVC
- Bootstrap
- EntityFramework
- Html,Css,Js

## Web UI

### Books

<div>
  <img src="GaziLibrary/wwwroot/image/ReadmeImages/books.PNG" alt="">
</div>

### Edit Profil

<div>
  <img src="GaziLibrary/wwwroot/image/ReadmeImages/editprofil.PNG" alt="">
</div>

### Contact

<div>
  <img src="GaziLibrary/wwwroot/image/ReadmeImages/contact.PNG" alt="">
</div>

### Rules Of Library

<div>
  <img src="GaziLibrary/wwwroot/image/ReadmeImages/rules.PNG" alt="">
</div>

## Database Tables

<details>
  <summary>Details</summary>

### Books

| Name          | Data Type    | Allow Nulls | Default |
| :------------ | :----------- | :---------- | :------ |
| Id            | int          | False       |         |
| AuthorId      | int          | False       |         |
| TypeId        | int          | False       |         |
| Name          | nvarchar(50) | False       |         |
| NumberOfPage  | int          | False       |         |
| Image         | nvarchar(90) | False       |         |
| Status        | bit          | False       |         |

### Types

| Name   | Data Type     | Allow Nulls | Default |
| :----- | :------------ | :---------- | :------ |
| Id     | int           | False       |         |
| Name   | nvarchar(50)  | False       |         |
| Status | bit           | False       |         |

### Authors

| Name       | Data Type     | Allow Nulls | Default |
| :--------- | :------------ | :---------- | :------ |
| Id         | int           | False       |         |
| FirstName  | nvarchar(50)  | False       |         |
| LastName   | nvarchar(50)  | False       |         |
| Status     | bit           | False       |         |

### BorrowedBooks

| Name       | Data Type | Allow Nulls | Default |
| :--------- | :-------- | :---------- | :------ |
| Id         | int       | False       |         |
| UserId     | int       | False       |         |
| BookId     | int       | False       |         |
| BorrowDate | Date      | False       |         |
| ReturnDate | Date      | False       |         |
| Status     | bit       | False       |         |

### Messages

| Name    | Data Type     | Allow Nulls | Default |
| :------ | :------------ | :---------- | :------ |
| Id      | int           | False       |         |
| UserId  | int           | False       |         |
| Message | nvarchar(MAX) | False       |         |
| Date    | Date          | False       |         |

### Users

| Name       | Data Type    | Allow Nulls | Default |
| :--------- | :----------- | :---------- | :------ |
| Id         | int          | False       |         |
| PositionId | int          | False       |         |
| FirstName  | nvarchar(50) | False       |         |
| LastName   | nvarchar(50) | False       |         |
| UserName   | nvarchar(50) | False       |         |
| Email      | nvarchar(50) | False       |         |
| Password   | nvarchar(50) | False       |         |
| Status     | bit          | False       |         |

### Positions

| Name   | Data Type    | Allow Nulls | Default |
| :----- | :----------- | :---------- | :------ |
| Id     | int          | False       |         |
| Name   | varchar(50)  | False       |         |
| Status | bit          | False       |         |

</details><p></p>
