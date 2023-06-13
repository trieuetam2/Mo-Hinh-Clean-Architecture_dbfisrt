create table Favourite(
	favourite_id int primary key identity,
	component nvarchar(255),
	itemtype nvarchar(255),
	itemid int,
	noidung nvarchar(255),
	lichhoc_id int,
	students_id int
)

ALTER TABLE Favourite
ADD CONSTRAINT FK_LichHocId
FOREIGN KEY (lichhoc_id) REFERENCES LichHoc(Id);

ALTER TABLE Favourite
ADD CONSTRAINT FK_StudentsID
FOREIGN KEY (students_id) REFERENCES Students(Id);
