CONNECT NV5001/NV5001;

--Xem thong tin ca nhan
SELECT * FROM GROUP08.xemthongtincanhan;

--Chinh sua thong tin ca nhan
UPDATE GROUP08.XemThongTinCaNhan set sodt='123';

--Xem phan cong ca nhan
SELECT * FROM GROUP08.xemthongtinphancong;

--Xem toan bo Phong ban va De an - PHONGBAN & DEAN
SELECT * fROM GROUP08.qlnv_phongban;
SELECT * FROM GROUP08.qlnv_dean;


--Xem thong tin nhan vien minh quan ly
SELECT * FROM GROUP08.NVQL_XemThongTin_NV;

--Xem phan cong cua nhan vien minh quan ly va cua minh
SELECT * FROM GROUP08.nvql_xem_pc;