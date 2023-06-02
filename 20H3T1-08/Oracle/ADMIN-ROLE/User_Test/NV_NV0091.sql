CONNECT NV0091/NV0091;
---CS1: 
--1. Xem va chinh sua thong tin ca nhan -NHANVIEN
SELECT * FROM GROUP08.xemthongtincanhan;

--Chinh sua thong tin ca nhan
UPDATE GROUP08.xemthongtincanhan set NGAYSINH=TO_DATE('12/12/2002','mm/dd/yyyy');

--Chay lai de kiem tra
SELECT * FROM GROUP08.xemthongtincanhan;

--2. Xem Phan cong ca nhan - PHANCONG
SELECT * FROM GROUP08.xemthongtinphancong;

--3. Xem toan bo Phong ban va De an - PHONGBAN & DEAN
SELECT * fROM GROUP08.qlnv_phongban;
SELECT * FROM GROUP08.qlnv_dean;
