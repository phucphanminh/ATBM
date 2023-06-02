CONNECT NV1001/NV1001;
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
SELECT * FROM GROUP08.tp_xemthongtin_nv;

--Xem thong tin phan cong cua nhan vien thuoc phong minh
SELECT * FROM GROUP08.tp_xempc_nv;


---THEM/XOA/SUA PHANCONG: Nhanvien thuoc phong minh
--THEM
SET SERVEROUTPUT ON FORMAT WRAPPED;
INSERT INTO GROUP08.tp_xemPC_NV(manv,mada,thoigian)
values ('NV0483','DA20',to_date('12/12/2022','mm/dd/yyyy'));
COMMIT;


---XOA
DELETE FROM GROUP08.tp_xemPC_NV where manv='NV0001';
COMMIT;

/
--SUA
UPDATE group08.tp_xempc_nv SET thoigian=TO_DATE('12/23/2030','mm/dd/yyyy')
WHERE manv='NV0483';
COMMIT;




