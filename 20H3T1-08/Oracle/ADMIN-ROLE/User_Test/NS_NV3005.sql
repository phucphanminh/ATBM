CONNECT NV3005/NV3005;

--Xem thong tin ca nhan
SELECT * FROM GROUP08.xemthongtincanhan;

--Chinh sua thong tin ca nhan
UPDATE GROUP08.XemThongTinCaNhan set sodt='+84 1234 56789';

--Xem phan cong ca nhan
SELECT * FROM GROUP08.xemthongtinphancong;

--Xem toan bo Phong ban va De an - PHONGBAN & DEAN
SELECT * fROM GROUP08.qlnv_phongban;
SELECT * FROM GROUP08.qlnv_dean;


--Them PB
INSERT INTO GROUP08.qlnv_phongban(MAPB,TENPB,TRPHG)
VALUES('P111','TEMP','NV12345');

--Xem thong tin nhan vien thong qua view 
SELECT * FROM GROUP08.ns_xemthongtin_nv;


--Them nhan vien
SET SERVEROUTPUT ON FORMAT WRAPPED;
INSERT INTO GROUP08.ns_xemthongtin_nv 
VALUES('NV12345','NGUYEN VAN A','NAM',TO_DATE('12/12/2022','mm/dd/yyyy'),
                                '3170 Chapel Hill Avebbb','1234',1200,12,'NV','NV1001','PB09');
COMMIT;

--Cap nhat cho NV 
SET SERVEROUTPUT ON FORMAT WRAPPED;
UPDATE GROUP08.NS_XEMTHONGTIN_NV SET MANQL='NV5001' WHERE MANV='NV12345';
COMMIT;


                                
