
create database QLSV

use QLSV

CREATE TABLE LOP(
	id INTEGER PRIMARY KEY IDENTITY(1,1),
	ten_lop VARCHAR(20)
)



CREATE TABLE SINHVIEN(
	id CHAR(8) PRIMARY KEY ,
	ho_ten VARCHAR(40),
	diem_toan Decimal(4,2),
	diem_ly Decimal(4,2),
	diem_hoa Decimal(4,2),
	diem_trung_binh Decimal(4,2),
	ma_lop INTEGER,
	CONSTRAINT fk_malop FOREIGN KEY (ma_lop) REFERENCES LOP(id),
)

SELECT * FROM LOP 
SELECT * FROM SINHVIEN ORDER BY id

 
INSERT INTO LOP (ten_lop)
VALUES 
('KTPM2022.1'),
('KTPM2022.2'),
('KTPM2022.3'),
('KTPM2022.4')

INSERT INTO SINHVIEN (id,ho_ten,diem_toan,diem_ly,diem_hoa,diem_trung_binh,ma_lop)
VALUES
('22524789','Nguyen Thi I',7,8,9,8,1),
('22525344','Tran Van J',6,7,8,7,2),
('22525901','Pham Ngoc K',9,7,6,7.3,3),

('22526458','Le Thi L',10,9,10,9.7,4),
('22527015','Nguyen Minh M',4,5,6,5,1),
('22527572','Hoang Thi N',8,9,7,8,2),
('22528129','Phan Van O',5,6,4,5,3),
('22528686','Tran Anh P',6,5,7,6,4),
('22529243','Ngo Gia Q',10,8,9,9,1),
('22529800','Ly Thuy R',7,8,6,7,2),
('22530357','Duong Van S',4,5,5,4.7,3),
('22530914','Ho Thi T',9,7,8,8,4),

('22531471','Nguyen Van U',6,7,6,6.3,1),
('22532028','Ngo Thi V',8,9,7,8,2),
('22532585','Ly Gia W',5,4,6,5,3),
('22533142','Ho Van X',10,9,10,9.7,4),
('22533699','Nguyen Thi Y',4,3,5,4,1),
('22534256','Tran Ngoc Z',7,9,8,8,2),

('22534813','Le Thuy A1',6,5,7,6,3),
('22535370','Ngo Van B1',9,7,6,7.3,4),
('22535927','Hoang Ngoc C1',5,6,4,5,1),

('22536484','Duong Thi D1',10,8,9,9,2),
('22537041','Pham Van E1',7,8,6,7,3),

('22537598','Mai Thi F1',4,5,5,4.7,4),
('22538155','Tran Anh G1',9,7,8,8,1),
('22538712','Le Thuy H1',6,7,6,6.3,2),
('22539269','Ly Van I1',8,9,7,8,3),
('22539826','Ho Gia J1',5,4,6,5,4),
('22540383','Duong Thi K1',10,9,10,9.7,1),
('22540940','Pham Ngoc L1',4,5,6,5,2),
('22521497','Mai Van M1',8,9,7,8,3),
('22522054','Tran Thi N1',5,6,4,5,4),
('22522611','Le Anh O1',6,5,7,6,1),
('22523168','Ly Thuy P1',10,8,9,9,2),
('22523725','Ho Van Q1',7,8,6,7,3),
('22524282','Duong Ngoc R1',4,5,5,4.7,4),
('22524839','Pham Gia S1',9,7,8,8,1)


SELECT * 
FROM SINHVIEN
WHERE id = '22520457'

DELETE SINHVIEN
output deleted.id
WHERE id = '22540940'


SELECT * 
FROM SINHVIEN 
WHERE id = '22520457' OR ho_ten = 'Cao Văn Hoàng'


SELECT id , ho_ten , ma_lop , diem_toan , diem_ly , diem_hoa , diem_trung_binh
                               FROM SINHVIEN
                               WHERE id = '22520457' OR ho_ten = 'Cao Văn Hoàng' 