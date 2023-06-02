CONNECT NV2001/NV2001;

--Xem thong tin ca nhan
SELECT * FROM GROUP08.xemthongtincanhan;

--Chinh sua thong tin ca nhan
UPDATE GROUP08.XemThongTinCaNhan set sodt='123';

--Xem phan cong ca nhan
SELECT * FROM GROUP08.xemthongtinphancong;

--Xem toan bo Phong ban va De an - PHONGBAN & DEAN
SELECT * fROM GROUP08.qlnv_phongban;
SELECT * FROM GROUP08.qlnv_dean;

--Xem toan bo quan he NHANVIEN
SELECT * FROM GROUP08.QLNV_NHANVIEN;

--Xem toan bo quan he PHANCONG
SELECT * FROM GROUP08.QLNV_PHANCONG;

--Sua LUONG,PHUCAP
UPDATE GROUP08.QLNV_NHANVIEN SET LUONG='123000' WHERE MANV='NV0001';

--Xem lai
SELECT * FROM GROUP08.QLNV_NHANVIEN WHERE MANV='NV0001';
