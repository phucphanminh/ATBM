-----------CAP QUYEN CHO ROLE-------------------

CONNECT GROUP08/GROUP08;
-----------------------------XEM BANG---------
select * from qlnv_phancong ORDER BY MANV; --where manv='NV0001'
SELECT * FROM qlnv_dean;
SELECT * FROM qlnv_phongban;
SELECT * FROM qlnv_nhanvien;

-------------CAP QUYEN VIEW -----------------------------------
grant select on xemthongtincanhan to GIAMDOC;
GRANT UPDATE (NGAYSINH,DIACHI,SODT) ON xemthongtincanhan TO GIAMDOC;
GRANT SELECT ON GROUP08.XemThongTinPhanCong TO GIAMDOC;


------------CS1: GRANT QUYEN CHO NHANVIEN----------------------------
--Xem thong tin ca nhan
GRANT SELECT ON xemthongtincanhan to NHANVIEN;
--Cap nhat thong tin ca nhan
GRANT UPDATE (NGAYSINH,DIACHI,SODT) ON xemthongtincanhan to NHANVIEN;

--Xem phan cong
GRANT SELECT ON GROUP08.XemThongTinPhanCong TO NHANVIEN;

--Xem Phong Ban va De An
GRANT SELECT ON GROUP08.QLNV_PHONGBAN TO NHANVIEN;
GRANT SELECT ON GROUP08.QLNV_DEAN TO NHANVIEN;


------------GRANT QUYEN CHO NVQL----------------------------
--Quyen nhu NHANVIEN
Grant Select on xemthongtincanhan to NVQL;
GRANT UPDATE (NGAYSINH,DIACHI,SODT) ON xemthongtincanhan to NVQL;
GRANT SELECT ON GROUP08.XemThongTinPhanCong TO NVQL;
--Xem Phong Ban va De An
GRANT SELECT ON GROUP08.QLNV_PHONGBAN TO NVQL;
GRANT SELECT ON GROUP08.QLNV_DEAN TO NVQL;

--Xem Thong tin nhan vien minh quan ly
GRANT SELECT ON NVQL_XemThongTin_NV TO NVQL;

--Xem thong tin phan cong cua nhan vien minh quan ly
GRANT SELECT ON NVQL_Xem_PC TO NVQL;


------------GRANT QUYEN CHO TRUONGPHONG----------------------------
--Quyen Nhu nhan vien
GRANT SELECT ON xemthongtincanhan to TRUONGPHONG;
GRANT UPDATE (NGAYSINH,DIACHI,SODT) ON xemthongtincanhan to TRUONGPHONG;
GRANT SELECT ON GROUP08.XemThongTinPhanCong TO TRUONGPHONG;

--Xem Phong Ban va De An
GRANT SELECT ON GROUP08.QLNV_PHONGBAN TO TRUONGPHONG;
GRANT SELECT ON GROUP08.QLNV_DEAN TO TRUONGPHONG;

--Xem thong tin phan cong cua nhan vien thuoc phong minh 
GRANT SELECT ON TP_XemThongTin_NV TO TRUONGPHONG;

--Xem va thuc hien Them/Xoa/Sua trong view TP_XemPC_NV
GRANT SELECT ON TP_XemPC_NV TO TRUONGPHONG;
GRANT INSERT,DELETE,UPDATE ON TP_XemPC_NV TO TRUONGPHONG;


------------GRANT QUYEN CHO TAI CHINH----------------------------
--Quyen Nhu nhan vien
GRANT SELECT ON xemthongtincanhan to TAICHINH;
GRANT UPDATE (NGAYSINH,DIACHI,SODT) ON xemthongtincanhan to TAICHINH;
GRANT SELECT ON GROUP08.XemThongTinPhanCong TO TAICHINH;

--Xem Phong Ban va De An
GRANT SELECT ON GROUP08.QLNV_PHONGBAN TO TAICHINH;
GRANT SELECT ON GROUP08.QLNV_DEAN TO TAICHINH;

--Xem toan bo quan he NHANVIEN và PHANCONG
GRANT SELECT ON GROUP08.qlnv_NHANVIEN TO TAICHINH;
GRANT SELECT ON GROUP08.qlnv_PHANCONG TO TAICHINH;

--Sua LUONG, PHUCAP
GRANT UPDATE (LUONG,PHUCAP) ON GROUP08.qlnv_NHANVIEN TO TAICHINH;

------------GRANT QUYEN CHO NHANSU----------------------------
--Quyen Nhu nhan vien
GRANT SELECT on xemthongtincanhan to NHANSU;
GRANT UPDATE (NGAYSINH,DIACHI,SODT) ON xemthongtincanhan to NHANSU;
GRANT SELECT ON GROUP08.XemThongTinPhanCong TO NHANSU;
--Xem Phong Ban va De An
GRANT SELECT ON GROUP08.QLNV_PHONGBAN TO NHANSU;
GRANT SELECT ON GROUP08.QLNV_DEAN TO NHANSU;

--Them PHONGBAN
GRANT INSERT ON GROUP08.QLNV_PHONGBAN TO NHANSU;

--Xem va them, cap nhat du lieu cho NHANVIEN thong qua view
GRANT SELECT ON NS_XemThongTin_NV TO NHANSU;
GRANT INSERT,UPDATE ON NS_XemThongTin_NV TO NHANSU;


------------GRANT QUYEN CHO TRUONG DE AN----------------------------
--Quyen Nhu nhan vien
GRANT SELECT on xemthongtincanhan to TRUONGDEAN;
GRANT UPDATE (NGAYSINH,DIACHI,SODT) ON xemthongtincanhan to TRUONGDEAN;
GRANT SELECT ON GROUP08.XemThongTinPhanCong TO TRUONGDEAN;
--Xem Phong Ban va De An
GRANT SELECT ON GROUP08.QLNV_PHONGBAN TO TRUONGDEAN;
GRANT SELECT ON GROUP08.QLNV_DEAN TO TRUONGDEAN;

--Them, xoa, cap nhat DEAN
GRANT INSERT,UPDATE,DELETE ON GROUP08.qlnv_DEAN TO TRUONGDEAN;





