-------------HAM MA HOA------------
CREATE OR REPLACE FUNCTION encrypt_str(input_str IN VARCHAR2, key_str in varchar2) RETURN VARCHAR2
AS
raw_input RAW(2048) := UTL_RAW.CAST_TO_RAW(CONVERT(input_str,'AL32UTF8','US7ASCII'));
raw_key RAW(2048) := UTL_RAW.CAST_TO_RAW(CONVERT(key_str,'AL32UTF8','US7ASCII'));
BEGIN
    RETURN DBMS_CRYPTO.ENCRYPT(raw_input, DBMS_CRYPTO.DES_CBC_PKCS5, raw_key);
END;

SELECT encrypt_str('123456789','C709EDB539419FEB1817A0FE6AA2DDCD41ABDE24') FROM dual;

-------HAM GIAI MA-------
CREATE OR REPLACE FUNCTION decrypt_str(encrypt_raw in RAW, key_str in varchar2) RETURN VARCHAR2
AS
raw_key RAW(2048) := UTL_RAW.CAST_TO_RAW(CONVERT(key_str,'AL32UTF8','US7ASCII'));
decrypt_raw RAW(2048);
decrypt_string varchar2(2048);
BEGIN
    decrypt_raw := DBMS_CRYPTO.DECRYPT(encrypt_raw, DBMS_CRYPTO.DES_CBC_PKCS5, raw_key);
    decrypt_string := convert(UTL_RAW.CAST_TO_VARCHAR2(decrypt_raw),'AL32UTF8','US7ASCII');
    RETURN decrypt_string;
END;
/
SELECT decrypt_str('F4E87C6769350FEB','C709EDB539419FEB1817A0FE6AA2DDCD41ABDE24') FROM dual; --L? LÀM DB M? 2 L?N NÊN PH?I CH?U KHÓ GI?I 2 L?N :))
select * from group08_plnv WHERE MANV = 'NV99999';
SELECT * FROM QLNV_NHANVIEN WHERE MANV = 'NV99999';
/
--------HAM HASH RA KEY-------
CREATE OR REPLACE PROCEDURE hash_str(key_str in varchar2, kq out varchar2)
as
    key_raw raw(2048):= UTL_RAW.CAST_TO_RAW(CONVERT(key_str,'AL32UTF8','US7ASCII'));
begin
    kq := dbms_crypto.Hash(key_raw,dbms_crypto.HASH_SH1);
end;
/
set serveroutput on
declare kq varchar2(2048);
begin
 hash_str ('hong',kq);
 DBMS_OUTPUT.put_line('Key sau khi hash la: ' || kq);
end;

/
-------TAO TABLE CHUA KEY-------
CREATE TABLE GROUP08_PLNV(
    MANV VARCHAR2(20),
    KEY_STR varchar2(2048) unique
)
/
--------PROC INSERT KEY CUA NHAN VIEN SAN CO TRONG DB VAO BANG KEY 
CREATE OR REPLACE PROCEDURE insertGROUP08_PLNV 
AS  
    CURSOR CUR IS SELECT MANV FROM GROUP08.QLNV_NHANVIEN WHERE MANV NOT IN (SELECT manv FROM GROUP08.GROUP08_PLNV);
    strSQL VARCHAR(2048);
    manv varchar2(2048);
    kq varchar2(2048);
BEGIN
    OPEN CUR;
   
    LOOP
     FETCH CUR INTO manv;
     EXIT WHEN CUR%NOTFOUND;
     
     begin
         hash_str(manv,kq);
     end;
     strSQL := 'INSERT INTO GROUP08.GROUP08_PLNV(MANV, KEY_STR) VALUES (''' || manv || ''', ''' || kq || ''')';
     EXECUTE IMMEDIATE (strSQL);
    
     END LOOP; 

END;
/
exec insertGROUP08_PLNV;
/

----T?O TRIGGER THÊM KEY M?I KHI THÊM NHÂN VIÊN M?I----
CREATE OR REPLACE TRIGGER insertKeyForNV
AFTER INSERT
   ON GROUP08.QLNV_NHANVIEN
   FOR EACH ROW
DECLARE
   kq varchar2(2048);
BEGIN
    begin
         hash_str(:new.MANV,kq);
     end;
    INSERT INTO GROUP08.GROUP08_PLNV(MANV, KEY_STR) VALUES (:new.MANV, kq);
END;

/
-----PROC MA HOA LUONG VA PHU CAP----
create or replace procedure MaHoaLuongPhuCap
as
    CURSOR CUR1 IS SELECT MANV, LUONG, PHUCAP FROM GROUP08.QLNV_NHANVIEN 
        WHERE MANV IN (SELECT MANV FROM GROUP08.GROUP08_PLNV);
    manv1 varchar2(20);
    manv2 varchar2(20);
    luong varchar2(2048);
    phucap varchar2(2048);
    key_s varchar2(4000);
    luong_ma_hoa varchar2(4000);
    phucap_ma_hoa varchar2(4000);
    strSQL varchar2(2048);
BEGIN
    OPEN CUR1;
    LOOP
     FETCH CUR1 INTO manv1, luong, phucap;
     select KEY_STR INTO key_s from GROUP08.GROUP08_PLNV where MANV = manv1;
     select MANV into manv2 from GROUP08.GROUP08_PLNV where MANV = manv1;
     EXIT WHEN CUR1%NOTFOUND;
     luong_ma_hoa := encrypt_str(luong, key_s);
     phucap_ma_hoa := encrypt_str(phucap, key_s);
     dbms_OUTPUT.put_line('MaNV: '||manv1||' co Luong: '||luong||' duoc ma hoa thanh '||luong_ma_hoa || ' ung voi key ' ||key_s);
     --dbms_OUTPUT.put_line('MaNV: '||manv1||' co Phu cap: '||phucap||' duoc ma hoa thanh '||phucap_ma_hoa || ' ung voi key ' ||key_s);
     strSQL := 'UPDATE GROUP08.QLNV_NHANVIEN SET LUONG = ''' || luong_ma_hoa || ''' where MANV = '''||manv2||'''';
     --dbms_OUTPUT.put_line('here' || strSQL);
     EXECUTE IMMEDIATE (strSQL);
     
     strSQL := 'UPDATE GROUP08.QLNV_NHANVIEN SET PHUCAP = ''' || phucap_ma_hoa || ''' where MANV = '''||manv2||'''';
     --dbms_OUTPUT.put_line('here' || strSQL);
     EXECUTE IMMEDIATE (strSQL);
    END LOOP; 
end;
/
set serveroutput on;
exec GROUP08.MaHoaLuongPhuCap;

/
---PROC GIAI MA LUONG VA PHU CAP------------
create or replace procedure GiaiMaLuongPhuCap
as
    CURSOR CUR1 IS SELECT MANV, LUONG, PHUCAP FROM GROUP08.QLNV_NHANVIEN 
        WHERE MANV IN (SELECT MANV FROM GROUP08.GROUP08_PLNV);
    manv1 varchar2(20);
    manv2 varchar2(20);
    luong varchar2(4000);
    phucap varchar2(4000);
    key_s varchar2(4000);
    luong_giai_ma varchar2(2048);
    phucap_giai_ma varchar2(2048);
    strSQL varchar2(2000);
BEGIN
    OPEN CUR1;
    LOOP
     FETCH CUR1 INTO manv1, luong, phucap;
     select KEY_STR INTO key_s from GROUP08.GROUP08_PLNV where MANV = manv1;
     select MANV into manv2 from GROUP08.GROUP08_PLNV where MANV = manv1;
     EXIT WHEN CUR1%NOTFOUND;
     dbms_OUTPUT.put_line('MaNV: '||manv1||' co Luong: '||luong||' duoc ma hoa thanh ung voi key ' ||key_s);
     luong_giai_ma := decrypt_str(luong, key_s);
     phucap_giai_ma := decrypt_str(phucap, key_s);
     strSQL := 'UPDATE GROUP08.QLNV_NHANVIEN SET LUONG = ''' || luong_giai_ma || ''' where MANV = '''||manv2||'''';
     EXECUTE IMMEDIATE (strSQL);
     
     strSQL := 'UPDATE GROUP08.QLNV_NHANVIEN SET PHUCAP = ''' || phucap_giai_ma || ''' where MANV = '''||manv2||'''';
     EXECUTE IMMEDIATE (strSQL);
    END LOOP; 
end;
/
set serveroutput on;
exec GROUP08.GiaiMaLuongPhuCap;
/

-----TEST TRIGGER----
UPDATE GROUP08.QLNV_NHANVIEN SET PHUCAP = 'B99E23CB3DADEE' where MANV = 'NV99999';
/
SELECT * FROM QLNV_NHANVIEN where MANV = 'NV99999';
/


INSERT INTO GROUP08.QLNV_NHANVIEN(MANV, TENNV, PHAI, NGAYSINH, DIACHI, SODT, LUONG, PHUCAP, VAITRO, MANQL, PHG) VALUES
('NV99999', 'THU VIEN', 'Nam',  to_date('08/05/2023','mm/dd/yyyy'), '227 NGUYEN VAN CU', '+84 09090909','123456789', '1000', 'NV', NULL, 'PB03');
/
delete QLNV_NHANVIEN where MANV = 'NV123456';
delete GROUP08_PLNV where MANV = 'NV123456';
/
select * from QLNV_NHANVIEN where MANV = 'NV123456'
/










