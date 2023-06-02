--Kiem tra xem Oracle da bat Unified Auditing chua
--select value from v$option where parameter  = 'Unified Auditing'
Grant update on group08.qlnv_nhanvien to NV0091;
GRANT SELECT ON GROUP08.QLNV_NHANVIEN TO NV0091;

Grant update on group08.qlnv_PHANCONG to NV0091;
GRANT SELECT ON GROUP08.QLNV_PHANCONG TO NV0091;


ALTER SYSTEM SET AUDIT_TRAIL=TRUE SCOPE=SPFILE;

--Cap quyen audit cho Admin_QLNV_GROUP08
--GRANT AUDIT_ADMIN to GROUP08;
--GRANT AUDIT_VIEWER to GROUP08;

-- Dang nhap vao user DBA
--Kiem tra nhat ky he thong
CREATE OR REPLACE PROCEDURE GetAuditTrail
AS
    c_audit SYS_REFCURSOR;
BEGIN
    OPEN c_audit FOR SELECT dbusername, action_name, object_schema, object_name, event_timestamp, sql_text
    FROM   unified_audit_trail
    ORDER BY event_timestamp ASC;
    DBMS_SQL.RETURN_RESULT(c_audit);
END;
/

--EXECUTE GetAuditTrail;

--Xoa cac audit
--BEGIN
--DBMS_AUDIT_MGMT.CLEAN_AUDIT_TRAIL(
--audit_trail_type => DBMS_AUDIT_MGMT.AUDIT_TRAIL_UNIFIED,
--use_last_arch_timestamp => FALSE);
--END;

--Tao audit
--Luu vet nhung nguoi da cap nhat truong THOIGIAN trong quan he PHANCONG. 
exec DBMS_FGA.DROP_POLICY('GROUP08', 'QLNV_PHANCONG', 'FGA_UPDATE_PHANCONG_THOIGIAN');
BEGIN
  DBMS_FGA.ADD_POLICY(
  object_schema => 'GROUP08'
  , object_name => 'QLNV_PHANCONG'
  , policy_name => 'FGA_UPDATE_PHANCONG_THOIGIAN'
  , audit_condition => NULL
  , audit_column => 'THOIGIAN'
  , handler_schema => NULL
  , handler_module => NULL
  , enable => TRUE
  , statement_types => 'UPDATE'
  );
END;

--SELECT DBUSERNAME ,ACTION_NAME, OBJECT_SCHEMA, OBJECT_NAME, EVENT_TIMESTAMP, SQL_TEXT
--FROM UNIFIED_AUDIT_TRAIL 
--WHERE OBJECT_SCHEMA='C##Admin_QLNV_GROUP08' AND OBJECT_NAME='QLNV_PHANCONG';
--/

--exec DBMS_FGA.DISABLE_POLICY('C##Admin_QLNV_GROUP08', 'QLNV_PHANCONG', 'FGA_PHANCONG_THOIGIAN');

--Luu vet nhung nguoi da doc tren truong LUONG va PHUCAP cua nguoi khac.
exec DBMS_FGA.DROP_POLICY('GROUP08', 'QLNV_NHANVIEN', 'FGA_NHANVIEN_READ_LUONG_PHUCAP');
BEGIN
  DBMS_FGA.ADD_POLICY(
  object_schema => 'GROUP08'--'C##Admin_QLNV_GROUP08'
  , object_name => 'QLNV_NHANVIEN'
  , policy_name => 'FGA_NHANVIEN_READ_LUONG_PHUCAP'
  , audit_condition => 'MANV != SYS_CONTEXT(''USERENV'', ''SESSION_USER'')'
  , audit_column => 'LUONG, PHUCAP'
  , handler_schema => NULL
  , handler_module => NULL
  , enable => TRUE
  , statement_types => 'SELECT'
  );
END;

--SELECT DBUID, OBJ$SCHEMA, OBJ$NAME, LSQLTEXT, NTIMESTAMP# 
--FROM SYS.FGA_LOG$ order by NTIMESTAMP# ASC;

--SELECT SYS_CONTEXT('USERENV', 'SESSION_USER') AS CURRENT_USER FROM DUAL;

--exec DBMS_FGA.DISABLE_POLICY('C##Admin_QLNV_GROUP08', 'QLNV_NHANVIEN', 'FGA_NHANVIEN_READ_LUONG_PHUCAP');

--Luu vet mot nguoi khong thuoc vai tro “Tai chinh” nhung da cap nhat thanh cong tren truong LUONG va PHUCAP.
exec DBMS_FGA.DROP_POLICY('GROUP08', 'QLNV_NHANVIEN', 'FGA_NHANVIEN_UPDATE_LUONG_PHUCAP');
BEGIN
  DBMS_FGA.ADD_POLICY(
    object_schema => 'GROUP08',--'C##Admin_QLNV_GROUP08',
    object_name => 'QLNV_NHANVIEN',
    policy_name => 'FGA_NHANVIEN_UPDATE_LUONG_PHUCAP',
    audit_condition => 'SYS_CONTEXT(''SYS_SESSION_ROLES'', ''TAICHINH'') IN (''FALSE'')',
    audit_column => 'LUONG, PHUCAP',
    handler_schema => NULL,
    handler_module => NULL,
    enable => TRUE,
    statement_types => 'UPDATE',
    audit_trail => DBMS_FGA.DB + DBMS_FGA.EXTENDED,
    audit_column_opts => DBMS_FGA.ANY_COLUMNS
  );
END;
/

--CREATE OR REPLACE FUNCTION is_valid_vaitro(ID IN NUMBER)
--RETURN BOOLEAN
--AS
--  vaitro VARCHAR2(50);
--BEGIN
--  SELECT VAITRO INTO vaitro FROM C##Admin_QLNV_GROUP08.QLNV_NHANVIEN WHERE MANV = ID;
--  RETURN vaitro != 'TC';
--END;
--
--CREATE AUDIT POLICY AUDIT_NHANVIEN_UPDATE_LUONG_PHUCAP
--ACTIONS
--  UPDATE ON C##Admin_QLNV_GROUP08.QLNV_NHANVIEN
--  WHEN 'is_valid_vaitro(SYS_CONTEXT(''USERENV'', ''SESSION_USER'')) = 1'
--  EVALUATE PER SESSION;

SELECT VALUE FROM V$OPTION WHERE PARAMETER = 'Unified Auditing';

AUDIT POLICY AUDIT_NHANVIEN_UPDATE_LUONG_PHUCAP;
SELECT * FROM SYS.FGA_LOG$;
EXECUTE GetAuditTrail;

--CONNECT GROUP08/GROUP08;
--update GROUP08.QLNV_NHANVIEN SET LUONG=12367 WHERE MANV='NV0091';
--UPDATE GROUP08.QLNV_PHANCONG SET THOIGIAN =  to_date('02/23/2022','mm/dd/yyyy');

--SELECT LUONG, PHUCAP FROM GROUP08.QLNV_NHANVIEN WHERE MANV = 'NV0216';
--exec DBMS_FGA.DISABLE_POLICY('C##Admin_QLNV_GROUP08', 'QLNV_NHANVIEN', 'FGA_NHANVIEN_UPDATE_LUONG_PHUCAP');
