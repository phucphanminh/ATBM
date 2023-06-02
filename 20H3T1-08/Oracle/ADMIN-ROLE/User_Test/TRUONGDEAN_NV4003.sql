CONNECT NV4003/NV4003;

--Xem thong tin ca nhan
SELECT * FROM GROUP08.xemthongtincanhan;

--Chinh sua thong tin ca nhan
UPDATE GROUP08.XemThongTinCaNhan set sodt='123';

--Xem phan cong ca nhan
SELECT * FROM GROUP08.xemthongtinphancong;

--Xem toan bo Phong ban va De an - PHONGBAN & DEAN
SELECT * fROM GROUP08.qlnv_phongban;
SELECT * FROM GROUP08.qlnv_dean;

--Them, xoa, cap nhat DEAN
INSERT INTO GROUP08.qlnv_dean(MADA,TENDA,NGAYBD,PHONG)
VALUES ('DA30','De an thu',to_date('12/12/2022','mm/dd/yyyy'),'PB109');

--Xem lai ket qua
SELECT * FROM GROUP08.qlnv_dean WHERE MADA='DA30';

--Cap nhat
UPDATE GROUP08.qlnv_dean SET TENDA='De an ABC' WHERE MADA='DA30';

--Xem lai ket qua
SELECT * FROM GROUP08.qlnv_dean WHERE MADA='DA30';

--Xoa
DELETE FROM GROUP08.qlnv_dean WHERE MADA='DA30';

--Xem lai ket qua
SELECT * FROM GROUP08.qlnv_dean WHERE MADA='DA30';

