/*
 Navicat Premium Data Transfer

 Source Server         : localhost_oracle
 Source Server Type    : Oracle
 Source Server Version : 110200
 Source Host           : localhost:1521
 Source Schema         : JAY

 Target Server Type    : Oracle
 Target Server Version : 110200
 File Encoding         : 65001

 Date: 28/06/2020 12:35:58
*/


-- ----------------------------
-- Table structure for DEAL
-- ----------------------------
DROP TABLE "JAY"."DEAL";
CREATE TABLE "JAY"."DEAL" (
  "MNO" VARCHAR2(10 BYTE) ,
  "DNO" VARCHAR2(10 BYTE) NOT NULL ,
  "DTIME" DATE ,
  "SNO" VARCHAR2(10 BYTE) ,
  "SHNO" VARCHAR2(10 BYTE) ,
  "DNUM" NUMBER(5) ,
  "DONE" VARCHAR2(10 BYTE) 
)
TABLESPACE "USERS"
LOGGING
NOCOMPRESS
PCTFREE 10
INITRANS 1
STORAGE (
  INITIAL 65536 
  NEXT 1048576 
  MINEXTENTS 1
  MAXEXTENTS 2147483645
  BUFFER_POOL DEFAULT
)
PARALLEL 1
NOCACHE
DISABLE ROW MOVEMENT
;

-- ----------------------------
-- Table structure for MENU
-- ----------------------------
DROP TABLE "JAY"."MENU";
CREATE TABLE "JAY"."MENU" (
  "MNO" VARCHAR2(10 BYTE) NOT NULL ,
  "SHNO" VARCHAR2(10 BYTE) ,
  "MNAME" VARCHAR2(10 BYTE) ,
  "MPRICE" NUMBER(5) ,
  "MSALE" NUMBER(5) ,
  "WORKNO" VARCHAR2(10 BYTE) 
)
TABLESPACE "USERS"
LOGGING
NOCOMPRESS
PCTFREE 10
INITRANS 1
STORAGE (
  INITIAL 65536 
  NEXT 1048576 
  MINEXTENTS 1
  MAXEXTENTS 2147483645
  BUFFER_POOL DEFAULT
)
PARALLEL 1
NOCACHE
DISABLE ROW MOVEMENT
;

-- ----------------------------
-- Table structure for SHOP
-- ----------------------------
DROP TABLE "JAY"."SHOP";
CREATE TABLE "JAY"."SHOP" (
  "SHNO" VARCHAR2(10 BYTE) NOT NULL ,
  "SHNAME" VARCHAR2(10 BYTE) NOT NULL 
)
TABLESPACE "USERS"
LOGGING
NOCOMPRESS
PCTFREE 10
INITRANS 1
STORAGE (
  INITIAL 65536 
  NEXT 1048576 
  MINEXTENTS 1
  MAXEXTENTS 2147483645
  BUFFER_POOL DEFAULT
)
PARALLEL 1
NOCACHE
DISABLE ROW MOVEMENT
;

-- ----------------------------
-- Table structure for STUDENT
-- ----------------------------
DROP TABLE "JAY"."STUDENT";
CREATE TABLE "JAY"."STUDENT" (
  "SNO" VARCHAR2(10 BYTE) NOT NULL ,
  "SPASSWORD" VARCHAR2(10 BYTE) NOT NULL ,
  "SBALANCE" NUMBER(8,2) NOT NULL ,
  "SNAME" VARCHAR2(10 BYTE) ,
  "SNUMBER" NUMBER(11) ,
  "COLLEGE" VARCHAR2(10 BYTE) ,
  "SEX" VARCHAR2(10 BYTE) 
)
TABLESPACE "USERS"
LOGGING
NOCOMPRESS
PCTFREE 10
INITRANS 1
STORAGE (
  INITIAL 65536 
  NEXT 1048576 
  MINEXTENTS 1
  MAXEXTENTS 2147483645
  BUFFER_POOL DEFAULT
)
PARALLEL 1
NOCACHE
DISABLE ROW MOVEMENT
;

-- ----------------------------
-- Table structure for WORK
-- ----------------------------
DROP TABLE "JAY"."WORK";
CREATE TABLE "JAY"."WORK" (
  "WORKNO" VARCHAR2(10 BYTE) NOT NULL ,
  "WPASSWORD" VARCHAR2(10 BYTE) NOT NULL ,
  "SHNO" VARCHAR2(10 BYTE) ,
  "WNAME" VARCHAR2(10 BYTE) ,
  "WSEX" VARCHAR2(10 BYTE) ,
  "WNUMBER" NUMBER(11) 
)
TABLESPACE "USERS"
LOGGING
NOCOMPRESS
PCTFREE 10
INITRANS 1
STORAGE (
  INITIAL 65536 
  NEXT 1048576 
  MINEXTENTS 1
  MAXEXTENTS 2147483645
  BUFFER_POOL DEFAULT
)
PARALLEL 1
NOCACHE
DISABLE ROW MOVEMENT
;

-- ----------------------------
-- Primary Key structure for table DEAL
-- ----------------------------
ALTER TABLE "JAY"."DEAL" ADD CONSTRAINT "SYS_C0017249" PRIMARY KEY ("DNO");

-- ----------------------------
-- Primary Key structure for table MENU
-- ----------------------------
ALTER TABLE "JAY"."MENU" ADD CONSTRAINT "SYS_C0017217" PRIMARY KEY ("MNO");

-- ----------------------------
-- Primary Key structure for table SHOP
-- ----------------------------
ALTER TABLE "JAY"."SHOP" ADD CONSTRAINT "SYS_C0017238" PRIMARY KEY ("SHNO");

-- ----------------------------
-- Checks structure for table SHOP
-- ----------------------------
ALTER TABLE "JAY"."SHOP" ADD CONSTRAINT "SYS_C0017242" CHECK ("SHNAME" IS NOT NULL) NOT DEFERRABLE INITIALLY IMMEDIATE NORELY VALIDATE;

-- ----------------------------
-- Primary Key structure for table STUDENT
-- ----------------------------
ALTER TABLE "JAY"."STUDENT" ADD CONSTRAINT "SYS_C0017205" PRIMARY KEY ("SNO");

-- ----------------------------
-- Checks structure for table STUDENT
-- ----------------------------
ALTER TABLE "JAY"."STUDENT" ADD CONSTRAINT "SYS_C0017231" CHECK ("SPASSWORD" IS NOT NULL) NOT DEFERRABLE INITIALLY IMMEDIATE NORELY VALIDATE;
ALTER TABLE "JAY"."STUDENT" ADD CONSTRAINT "SYS_C0017232" CHECK ("SBALANCE" IS NOT NULL) NOT DEFERRABLE INITIALLY IMMEDIATE NORELY VALIDATE;

-- ----------------------------
-- Primary Key structure for table WORK
-- ----------------------------
ALTER TABLE "JAY"."WORK" ADD CONSTRAINT "SYS_C0017233" PRIMARY KEY ("WORKNO");

-- ----------------------------
-- Checks structure for table WORK
-- ----------------------------
ALTER TABLE "JAY"."WORK" ADD CONSTRAINT "SYS_C0017235" CHECK ("WPASSWORD" IS NOT NULL) NOT DEFERRABLE INITIALLY IMMEDIATE NORELY VALIDATE;

-- ----------------------------
-- Foreign Keys structure for table DEAL
-- ----------------------------
ALTER TABLE "JAY"."DEAL" ADD CONSTRAINT "SYS_C0017250" FOREIGN KEY ("MNO") REFERENCES "MENU" ("MNO") NOT DEFERRABLE INITIALLY IMMEDIATE NORELY VALIDATE;
ALTER TABLE "JAY"."DEAL" ADD CONSTRAINT "SYS_C0017251" FOREIGN KEY ("SHNO") REFERENCES "SHOP" ("SHNO") NOT DEFERRABLE INITIALLY IMMEDIATE NORELY VALIDATE;
ALTER TABLE "JAY"."DEAL" ADD CONSTRAINT "SYS_C0017252" FOREIGN KEY ("SNO") REFERENCES "STUDENT" ("SNO") NOT DEFERRABLE INITIALLY IMMEDIATE NORELY VALIDATE;

-- ----------------------------
-- Foreign Keys structure for table MENU
-- ----------------------------
ALTER TABLE "JAY"."MENU" ADD CONSTRAINT "SYS_C0017247" FOREIGN KEY ("SHNO") REFERENCES "SHOP" ("SHNO") NOT DEFERRABLE INITIALLY IMMEDIATE NORELY VALIDATE;
ALTER TABLE "JAY"."MENU" ADD CONSTRAINT "SYS_C0017248" FOREIGN KEY ("WORKNO") REFERENCES "WORK" ("WORKNO") NOT DEFERRABLE INITIALLY IMMEDIATE NORELY VALIDATE;

-- ----------------------------
-- Foreign Keys structure for table WORK
-- ----------------------------
ALTER TABLE "JAY"."WORK" ADD CONSTRAINT "SYS_C0017246" FOREIGN KEY ("SHNO") REFERENCES "SHOP" ("SHNO") NOT DEFERRABLE INITIALLY IMMEDIATE NORELY VALIDATE;