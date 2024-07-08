
-- drop sequence if exist
DROP SEQUENCE APPOINTMENT_ID_SEQ;
DROP SEQUENCE STAFF_ID_SEQ;
DROP SEQUENCE GUEST_ID_SEQ;
DROP SEQUENCE CHARGE_ID_SEQ;
DROP SEQUENCE PAYMENT_ID_SEQ;
DROP SEQUENCE PROMOTION_ID_SEQ;
DROP SEQUENCE ROOM_ID_SEQ;
DROP SEQUENCE AUDIT_ID_SEQ;

-- drop table if exist
drop Table APPOINTMENT CASCADE CONSTRAINTS;
drop Table STAFF CASCADE CONSTRAINTS;
drop Table GUEST CASCADE CONSTRAINTS;
drop Table PAYMENT CASCADE CONSTRAINTS;
drop Table CHARGE CASCADE CONSTRAINTS;
drop Table ROOM CASCADE CONSTRAINTS;
drop Table ROOMTYPE CASCADE CONSTRAINTS;
drop Table PROMOTIONTYPE CASCADE CONSTRAINTS;
drop Table RESERVATION CASCADE CONSTRAINTS;
drop Table AUDITLOG CASCADE CONSTRAINTS;

-- drop index if exist
DROP INDEX GUEST_ID_IDX;
DROP INDEX ROOMNUMBER_IDX;

--------------------------------------------------------
--  DDL for Tables
--------------------------------------------------------
CREATE TABLE GUEST 
(
GUESTID NUMBER NOT NULL, 
FIRSTNAME VARCHAR2(255) NOT NULL, 
LASTNAME VARCHAR2(255) NOT NULL, 
GENDER NUMBER, 
AGE NUMBER, 
PHONENUMBER VARCHAR2(20) NOT NULL, 
EMAIL VARCHAR2(255) NOT NULL, 
COUNTRY VARCHAR2(255) NOT NULL, 
ID VARCHAR2(20) NOT NULL, 
CONSTRAINT GUEST_PK PRIMARY KEY (GUESTID)
);

CREATE TABLE STAFF 
(
STAFFID NUMBER, 
STAFFTITLE VARCHAR2(255) NOT NULL, 
USERNAME VARCHAR2(255) NOT NULL, 
PASSWORD VARCHAR2(255) NOT NULL, 
EMAIL VARCHAR2(255) NOT NULL, 
PHONENUMBER VARCHAR2(255) NOT NULL, 
ADDRESS VARCHAR2(255) NOT NULL, 
REMARK VARCHAR2(255), 
CONSTRAINT STAFF_PK PRIMARY KEY (STAFFID)
);

CREATE TABLE PROMOTIONTYPE 
(
PROMOTIONID NUMBER NOT NULL, 
NAME VARCHAR2(255) NOT NULL, 
DESCRIPTION VARCHAR2(255), 
DISCOUNTRATE FLOAT(126) NOT NULL,
CONSTRAINT PROMOTIONTYPE_PK PRIMARY KEY (PROMOTIONID)
);

CREATE TABLE ROOMTYPE 
(
ROOMTYPE VARCHAR2(20) NOT NULL, 
CAPACITY NUMBER NOT NULL, 
PRICE FLOAT(126) NOT NULL, 
NONSMOKING NUMBER(*,0) DEFAULT 1 NOT NULL, 
DESCRIPTION VARCHAR2(255),
CONSTRAINT ROOMTYPE_PK PRIMARY KEY (ROOMTYPE)
);

CREATE TABLE AUDITLOG 
(
AUDITID NUMBER NOT NULL, 
ACTION VARCHAR2(255) NOT NULL, 
STAFFID NUMBER NOT NULL, 
AUDITDATE VARCHAR2(20) DEFAULT SYSDATE NOT NULL, 
CONSTRAINT AUDITLOG_PK PRIMARY KEY (AUDITID)
);

CREATE TABLE PAYMENT 
(
PAYMENTID NUMBER NOT NULL, 
PAYMENTTYPE VARCHAR2(20) NOT NULL, 
TOTALPAYMENT FLOAT(126) NOT NULL, 
PAYMENTDATE DATE NOT NULL, 
PROMOTIONID NUMBER, 
CONSTRAINT PAYMENT_PK PRIMARY KEY (PAYMENTID),
CONSTRAINT PROMOTION_PAYMENT_FK FOREIGN KEY (PROMOTIONID) REFERENCES PROMOTIONTYPE (PROMOTIONID) ENABLE
);

CREATE TABLE APPOINTMENT 
(
APPOINTMENTID NUMBER NOT NULL, 
STATUS VARCHAR2(10) DEFAULT 'ACTIVE' NOT NULL, 
STAFFID NUMBER NOT NULL, 
GUESTID NUMBER NOT NULL, 
REMARK VARCHAR2(255), 
CHECK_IN DATE NOT NULL, 
CHECK_OUT DATE NOT NULL, 
NUM_ADULT NUMBER NOT NULL, 
NUM_CHILD NUMBER DEFAULT 0 NOT NULL, 
PAYMENT_ID NUMBER, 
CONSTRAINT APPOINTMENT_PK PRIMARY KEY (APPOINTMENTID),
CONSTRAINT GUEST_APPOINTMENT_FK FOREIGN KEY (GUESTID) REFERENCES GUEST (GUESTID) ENABLE,
CONSTRAINT PAYMENT_APPOINTMENT_FK FOREIGN KEY (PAYMENT_ID) REFERENCES PAYMENT (PAYMENTID) ENABLE,
CONSTRAINT STAFF_APPOINTMENT_FK FOREIGN KEY (STAFFID) REFERENCES STAFF (STAFFID) ENABLE
);


CREATE TABLE CHARGE 
(
CHARGEID NUMBER NOT NULL, 
PAYMENTID NUMBER NOT NULL, 
CHARGETYPE VARCHAR2(20) NOT NULL, 
CHARGEAMOUNT FLOAT(126) NOT NULL, 
CONSTRAINT CHARGE_PK PRIMARY KEY (CHARGEID),
CONSTRAINT PAYMENT_CHARGE_FK FOREIGN KEY (PAYMENTID) REFERENCES PAYMENT (PAYMENTID) ENABLE
);

CREATE TABLE ROOM
(
ROOMID NUMBER NOT NULL, 
ROOMNUMBER VARCHAR2(50) NOT NULL, 
ROOMDESC VARCHAR2(255), 
ROOMTYPE VARCHAR2(20) NOT NULL, 
ISCLEAN NUMBER(*,0) DEFAULT 1 NOT NULL, 
CONSTRAINT ROOM_PK PRIMARY KEY (ROOMID),
CONSTRAINT ROOM_TYPE_FK FOREIGN KEY (ROOMTYPE) REFERENCES ROOMTYPE (ROOMTYPE) ENABLE
);




CREATE TABLE RESERVATION 
(
APPOINTMENTID NUMBER NOT NULL, 
ROOMID NUMBER NOT NULL, 
CONSTRAINT RESERVATION_PK PRIMARY KEY (APPOINTMENTID, ROOMID),
CONSTRAINT APOINTMENT_RESERVATION_FK FOREIGN KEY (APPOINTMENTID) REFERENCES APPOINTMENT (APPOINTMENTID) ENABLE,
CONSTRAINT ROOM_RESERVATION_FK FOREIGN KEY (ROOMID) REFERENCES ROOM (ROOMID) ENABLE
);



--------------------------------------------------------
--  DDL for Sequence
--------------------------------------------------------

CREATE SEQUENCE Appointment_ID_SEQ
INCREMENT BY 1
START WITH 1
MINVALUE 1
MAXVALUE 100000
NOCYCLE
NOCACHE;

CREATE SEQUENCE Staff_ID_SEQ
INCREMENT BY 1
START WITH 1
MINVALUE 1
MAXVALUE 100000
NOCYCLE
NOCACHE;

CREATE SEQUENCE Guest_ID_SEQ
INCREMENT BY 1
START WITH 1
MINVALUE 1
MAXVALUE 100000
NOCYCLE
NOCACHE;

CREATE SEQUENCE Charge_ID_SEQ
INCREMENT BY 1
START WITH 1
MINVALUE 1
MAXVALUE 100000
NOCYCLE
NOCACHE;

CREATE SEQUENCE Payment_ID_SEQ
INCREMENT BY 1
START WITH 1
MINVALUE 1
MAXVALUE 100000
NOCYCLE
NOCACHE;

CREATE SEQUENCE Promotion_ID_SEQ
INCREMENT BY 1
START WITH 1
MINVALUE 1
MAXVALUE 100000
NOCYCLE
NOCACHE;

CREATE SEQUENCE Room_ID_SEQ
INCREMENT BY 1
START WITH 1
MINVALUE 1
MAXVALUE 100000
NOCYCLE
NOCACHE;

CREATE SEQUENCE Audit_ID_SEQ
INCREMENT BY 1
START WITH 1
MINVALUE 1
MAXVALUE 100000
NOCYCLE
NOCACHE;

-- INSERT RECORDS
INSERT INTO STAFF (STAFFID,STAFFTITLE,USERNAME,PASSWORD,EMAIL,PHONENUMBER,ADDRESS,REMARK) VALUES (Staff_ID_SEQ.NEXTVAL, 'General Manager','john.smith','pass123','john.smith@ghotel.com','15551234567','123 Main St, Anytown, CA',NULL);
INSERT INTO STAFF (STAFFID,STAFFTITLE,USERNAME,PASSWORD,EMAIL,PHONENUMBER,ADDRESS,REMARK) VALUES (Staff_ID_SEQ.NEXTVAL, 'Front Desk Manager','sarah.jones','hotel123','sarah.jones@ghotel.com','15552345678','456 Broadway, Anytown, CA',NULL);
INSERT INTO STAFF (STAFFID,STAFFTITLE,USERNAME,PASSWORD,EMAIL,PHONENUMBER,ADDRESS,REMARK) VALUES (Staff_ID_SEQ.NEXTVAL, 'Housekeeping Supervisor','brian.wilson','clean123','brian.wilson@ghotel.com','15553456789','789 Oak St, Anytown, CA',NULL);
INSERT INTO STAFF (STAFFID,STAFFTITLE,USERNAME,PASSWORD,EMAIL,PHONENUMBER,ADDRESS,REMARK) VALUES (Staff_ID_SEQ.NEXTVAL, 'Head Chef','kevin.nguyen','food123','kevin.nguyen@ghotel.com','15554567890','321 Maple Ave, Anytown, CA',NULL);
INSERT INTO STAFF (STAFFID,STAFFTITLE,USERNAME,PASSWORD,EMAIL,PHONENUMBER,ADDRESS,REMARK) VALUES (Staff_ID_SEQ.NEXTVAL, 'Front Desk Assistant','michelle.jessie','mjds123','michelle.jessie@ghotel.com','15553456790','41 Maple Ave, Anytown, CA',NULL);
INSERT INTO STAFF (STAFFID,STAFFTITLE,USERNAME,PASSWORD,EMAIL,PHONENUMBER,ADDRESS,REMARK) VALUES (Staff_ID_SEQ.NEXTVAL, 'Front Desk Assistant','dave.micheal','dmav123','dave.micheal@ghotel.com','15554567891','239 Silver Ave, Anytown, CA',NULL);
INSERT INTO STAFF (STAFFID,STAFFTITLE,USERNAME,PASSWORD,EMAIL,PHONENUMBER,ADDRESS,REMARK) VALUES (Staff_ID_SEQ.NEXTVAL, 'Housekeeping Assistant','nick.smith','nick123','nick.smith@ghotel.com','15553456791','519 Good Ave, Anytown, CA',NULL);
INSERT INTO STAFF (STAFFID,STAFFTITLE,USERNAME,PASSWORD,EMAIL,PHONENUMBER,ADDRESS,REMARK) VALUES (Staff_ID_SEQ.NEXTVAL, 'Housekeeping Assistant','jessie.b','jess123','jessie.b@ghotel.com','15554567892','799 Maple Ave, Anytown, CA',NULL);
INSERT INTO STAFF (STAFFID,STAFFTITLE,USERNAME,PASSWORD,EMAIL,PHONENUMBER,ADDRESS,REMARK) VALUES (Staff_ID_SEQ.NEXTVAL, 'Housekeeping Assistant','bob.s','bobs123','bob.s@ghotel.com','15553456792','1079 Green Ave, Anytown, CA',NULL);
INSERT INTO STAFF (STAFFID,STAFFTITLE,USERNAME,PASSWORD,EMAIL,PHONENUMBER,ADDRESS,REMARK) VALUES (Staff_ID_SEQ.NEXTVAL, 'Chef Assistant','Sally.john','sall123','Sally.john@ghotel.com','15553453215','1 Red Ave, Anytown, CA',NULL);

INSERT INTO GUEST (GUESTID,FIRSTNAME,LASTNAME,GENDER,AGE,PHONENUMBER,EMAIL,COUNTRY,ID) VALUES (GUEST_ID_SEQ.NEXTVAL, 'Patrick','Pitts',2,25,'1325667773','Patrick.Pitts@test.com','Canada','X1234567');
INSERT INTO GUEST (GUESTID,FIRSTNAME,LASTNAME,GENDER,AGE,PHONENUMBER,EMAIL,COUNTRY,ID) VALUES (GUEST_ID_SEQ.NEXTVAL, 'Brooke','Jones',1,67,'1123456789','Brooke.Jones@test.com','United State','X2345678');
INSERT INTO GUEST (GUESTID,FIRSTNAME,LASTNAME,GENDER,AGE,PHONENUMBER,EMAIL,COUNTRY,ID) VALUES (GUEST_ID_SEQ.NEXTVAL, 'David','Davis',1,37,'1312345782','David.Davis@test.com','Canada','X3456789');
INSERT INTO GUEST (GUESTID,FIRSTNAME,LASTNAME,GENDER,AGE,PHONENUMBER,EMAIL,COUNTRY,ID) VALUES (GUEST_ID_SEQ.NEXTVAL, 'Anthony','Barrett',1,56,'1354789254','Anthony.Barrett@test.com','Canada','X4567900');
INSERT INTO GUEST (GUESTID,FIRSTNAME,LASTNAME,GENDER,AGE,PHONENUMBER,EMAIL,COUNTRY,ID) VALUES (GUEST_ID_SEQ.NEXTVAL, 'Donna','Palmer',0,39,'1125478945','Donna.Palmer@test.com','United State','X5679011');
INSERT INTO GUEST (GUESTID,FIRSTNAME,LASTNAME,GENDER,AGE,PHONENUMBER,EMAIL,COUNTRY,ID) VALUES (GUEST_ID_SEQ.NEXTVAL, 'Robert','Green',1,45,'1253478983','Robert.Green@test.com','United State','X6790122');
INSERT INTO GUEST (GUESTID,FIRSTNAME,LASTNAME,GENDER,AGE,PHONENUMBER,EMAIL,COUNTRY,ID) VALUES (GUEST_ID_SEQ.NEXTVAL, 'Joshua','Henry',1,26,'1123456789','Joshua.Henry@test.com','Canada','X7901233');
INSERT INTO GUEST (GUESTID,FIRSTNAME,LASTNAME,GENDER,AGE,PHONENUMBER,EMAIL,COUNTRY,ID) VALUES (GUEST_ID_SEQ.NEXTVAL, 'Rhonda','Ruiz',0,57,'1456789012','Rhonda.Ruiz@test.com','Canada','X9012344');
INSERT INTO GUEST (GUESTID,FIRSTNAME,LASTNAME,GENDER,AGE,PHONENUMBER,EMAIL,COUNTRY,ID) VALUES (GUEST_ID_SEQ.NEXTVAL, 'Stacy','Hines',0,54,'1567894563','Stacy.Hines@test.com','United State','X1012345');
INSERT INTO GUEST (GUESTID,FIRSTNAME,LASTNAME,GENDER,AGE,PHONENUMBER,EMAIL,COUNTRY,ID) VALUES (GUEST_ID_SEQ.NEXTVAL, 'Lisa','Davis',0,43,'1456782531','Lisa.Davis@test.com','United State','X1123456');

INSERT INTO ROOMTYPE (ROOMTYPE,CAPACITY,PRICE,NONSMOKING,DESCRIPTION) VALUES ('SINGLE_SMOKE', 2,200,1,'1 twin bed');
INSERT INTO ROOMTYPE (ROOMTYPE,CAPACITY,PRICE,NONSMOKING,DESCRIPTION) VALUES ('SINGLE', 2,200,0,'1 twin bed');
INSERT INTO ROOMTYPE (ROOMTYPE,CAPACITY,PRICE,NONSMOKING,DESCRIPTION) VALUES ('DOUBLE_SMOKE', 2,300,1,'2 twin bed');
INSERT INTO ROOMTYPE (ROOMTYPE,CAPACITY,PRICE,NONSMOKING,DESCRIPTION) VALUES ('DOUBLE', 2,300,0,'2 twin bed');
INSERT INTO ROOMTYPE (ROOMTYPE,CAPACITY,PRICE,NONSMOKING,DESCRIPTION) VALUES ('DOUBLE_DELUX_SMOKE', 2,300,1,'1 double bed');
INSERT INTO ROOMTYPE (ROOMTYPE,CAPACITY,PRICE,NONSMOKING,DESCRIPTION) VALUES ('DOUBLE_DELUX', 2,300,0,'1 double bed');
INSERT INTO ROOMTYPE (ROOMTYPE,CAPACITY,PRICE,NONSMOKING,DESCRIPTION) VALUES ('TRIPLE_SMOKE', 3,400,1,'3 twin bed');
INSERT INTO ROOMTYPE (ROOMTYPE,CAPACITY,PRICE,NONSMOKING,DESCRIPTION) VALUES ('TRIPLE', 3,400,0,'3 twin bed');
INSERT INTO ROOMTYPE (ROOMTYPE,CAPACITY,PRICE,NONSMOKING,DESCRIPTION) VALUES ('QUAD_SMOKE', 4,500,1,'two double beds');
INSERT INTO ROOMTYPE (ROOMTYPE,CAPACITY,PRICE,NONSMOKING,DESCRIPTION) VALUES ('QUAD', 4,500,0,'two double beds');
INSERT INTO ROOMTYPE (ROOMTYPE,CAPACITY,PRICE,NONSMOKING,DESCRIPTION) VALUES ('SUITE', 4,1000,0,'3 king beds');

INSERT INTO PROMOTIONTYPE (PROMOTIONID,NAME,DESCRIPTION,DISCOUNTRATE) VALUES (Promotion_ID_SEQ.NEXTVAL, 'NEW MEMBER', '10%OFF',0.1);
INSERT INTO PROMOTIONTYPE (PROMOTIONID,NAME,DESCRIPTION,DISCOUNTRATE) VALUES (Promotion_ID_SEQ.NEXTVAL, 'N/A', 'Default',0);


INSERT INTO ROOM (ROOMID,ROOMNUMBER,ROOMDESC,ROOMTYPE,ISCLEAN) VALUES (ROOM_ID_SEQ.NEXTVAL, '101A','','SINGLE',1);
INSERT INTO ROOM (ROOMID,ROOMNUMBER,ROOMDESC,ROOMTYPE,ISCLEAN) VALUES (ROOM_ID_SEQ.NEXTVAL, '101B','','SINGLE_SMOKE',1);
INSERT INTO ROOM (ROOMID,ROOMNUMBER,ROOMDESC,ROOMTYPE,ISCLEAN) VALUES (ROOM_ID_SEQ.NEXTVAL, '102C','','DOUBLE',1);
INSERT INTO ROOM (ROOMID,ROOMNUMBER,ROOMDESC,ROOMTYPE,ISCLEAN) VALUES (ROOM_ID_SEQ.NEXTVAL, '102D','','DOUBLE_SMOKE',1);
INSERT INTO ROOM (ROOMID,ROOMNUMBER,ROOMDESC,ROOMTYPE,ISCLEAN) VALUES (ROOM_ID_SEQ.NEXTVAL, '201A','Need cleaning','SINGLE',1);
INSERT INTO ROOM (ROOMID,ROOMNUMBER,ROOMDESC,ROOMTYPE,ISCLEAN) VALUES (ROOM_ID_SEQ.NEXTVAL, '201B','TV broken','SINGLE_SMOKE',1);
INSERT INTO ROOM (ROOMID,ROOMNUMBER,ROOMDESC,ROOMTYPE,ISCLEAN) VALUES (ROOM_ID_SEQ.NEXTVAL, '201C','','DOUBLE_DELUX_SMOKE',0);
INSERT INTO ROOM (ROOMID,ROOMNUMBER,ROOMDESC,ROOMTYPE,ISCLEAN) VALUES (ROOM_ID_SEQ.NEXTVAL, '202D','','DOUBLE_DELUX',1);
INSERT INTO ROOM (ROOMID,ROOMNUMBER,ROOMDESC,ROOMTYPE,ISCLEAN) VALUES (ROOM_ID_SEQ.NEXTVAL, '302A','','TRIPLE_SMOKE',1);
INSERT INTO ROOM (ROOMID,ROOMNUMBER,ROOMDESC,ROOMTYPE,ISCLEAN) VALUES (ROOM_ID_SEQ.NEXTVAL, '302B','','TRIPLE',1);
INSERT INTO ROOM (ROOMID,ROOMNUMBER,ROOMDESC,ROOMTYPE,ISCLEAN) VALUES (ROOM_ID_SEQ.NEXTVAL, '301A','','QUAD_SMOKE',1);
INSERT INTO ROOM (ROOMID,ROOMNUMBER,ROOMDESC,ROOMTYPE,ISCLEAN) VALUES (ROOM_ID_SEQ.NEXTVAL, '302A','','QUAD',1);
INSERT INTO ROOM (ROOMID,ROOMNUMBER,ROOMDESC,ROOMTYPE,ISCLEAN) VALUES (ROOM_ID_SEQ.NEXTVAL, '401A','','SUITE',1);

INSERT INTO PAYMENT (PAYMENTID,PAYMENTTYPE,TOTALPAYMENT,PAYMENTDATE,PROMOTIONID) VALUES (PAYMENT_ID_SEQ.NEXTVAL, 'CASH', 452,TO_DATE('20211205', 'YYYYMMDD'),NULL);
INSERT INTO PAYMENT (PAYMENTID,PAYMENTTYPE,TOTALPAYMENT,PAYMENTDATE,PROMOTIONID) VALUES (PAYMENT_ID_SEQ.NEXTVAL, 'CREDIT_CARD', 305.1,TO_DATE('20220227', 'YYYYMMDD'),1);
INSERT INTO PAYMENT (PAYMENTID,PAYMENTTYPE,TOTALPAYMENT,PAYMENTDATE,PROMOTIONID) VALUES (PAYMENT_ID_SEQ.NEXTVAL, 'CREDIT_CARD', 339,TO_DATE('20220227', 'YYYYMMDD'),NULL);
INSERT INTO PAYMENT (PAYMENTID,PAYMENTTYPE,TOTALPAYMENT,PAYMENTDATE,PROMOTIONID) VALUES (PAYMENT_ID_SEQ.NEXTVAL, 'DEBIT_CARD', 565,TO_DATE('20220414', 'YYYYMMDD'),NULL);

INSERT INTO CHARGE (CHARGEID,PAYMENTID,CHARGETYPE,CHARGEAMOUNT) VALUES (CHARGE_ID_SEQ.NEXTVAL,1,'ROOM',200);
INSERT INTO CHARGE (CHARGEID,PAYMENTID,CHARGETYPE,CHARGEAMOUNT) VALUES (CHARGE_ID_SEQ.NEXTVAL,1,'ROOM',200);
INSERT INTO CHARGE (CHARGEID,PAYMENTID,CHARGETYPE,CHARGEAMOUNT) VALUES (CHARGE_ID_SEQ.NEXTVAL,1,'GST',52);
INSERT INTO CHARGE (CHARGEID,PAYMENTID,CHARGETYPE,CHARGEAMOUNT) VALUES (CHARGE_ID_SEQ.NEXTVAL,2,'ROOM',300);
INSERT INTO CHARGE (CHARGEID,PAYMENTID,CHARGETYPE,CHARGEAMOUNT) VALUES (CHARGE_ID_SEQ.NEXTVAL,2,'GST',39);
INSERT INTO CHARGE (CHARGEID,PAYMENTID,CHARGETYPE,CHARGEAMOUNT) VALUES (CHARGE_ID_SEQ.NEXTVAL,2,'DISCOUNT',-33.9);
INSERT INTO CHARGE (CHARGEID,PAYMENTID,CHARGETYPE,CHARGEAMOUNT) VALUES (CHARGE_ID_SEQ.NEXTVAL,3,'ROOM',300);
INSERT INTO CHARGE (CHARGEID,PAYMENTID,CHARGETYPE,CHARGEAMOUNT) VALUES (CHARGE_ID_SEQ.NEXTVAL,3,'GST',39);
INSERT INTO CHARGE (CHARGEID,PAYMENTID,CHARGETYPE,CHARGEAMOUNT) VALUES (CHARGE_ID_SEQ.NEXTVAL,4,'ROOM',500);
INSERT INTO CHARGE (CHARGEID,PAYMENTID,CHARGETYPE,CHARGEAMOUNT) VALUES (CHARGE_ID_SEQ.NEXTVAL,4,'GST',65);

INSERT INTO APPOINTMENT (APPOINTMENTID,STATUS,STAFFID,GUESTID,REMARK,CHECK_IN,CHECK_OUT,NUM_ADULT,NUM_CHILD,PAYMENT_ID) VALUES (APPOINTMENT_ID_SEQ.NEXTVAL,'ACTIVE',5,1,NULL,TO_DATE('20220106', 'YYYYMMDD'),TO_DATE('20220109', 'YYYYMMDD'),1,2,1);
INSERT INTO APPOINTMENT (APPOINTMENTID,STATUS,STAFFID,GUESTID,REMARK,CHECK_IN,CHECK_OUT,NUM_ADULT,NUM_CHILD,PAYMENT_ID) VALUES (APPOINTMENT_ID_SEQ.NEXTVAL,'ACTIVE',6,2,NULL,TO_DATE('20220304', 'YYYYMMDD'),TO_DATE('20220315', 'YYYYMMDD'),2,1,2);
INSERT INTO APPOINTMENT (APPOINTMENTID,STATUS,STAFFID,GUESTID,REMARK,CHECK_IN,CHECK_OUT,NUM_ADULT,NUM_CHILD,PAYMENT_ID) VALUES (APPOINTMENT_ID_SEQ.NEXTVAL,'ACTIVE',5,3,NULL,TO_DATE('20220401', 'YYYYMMDD'),TO_DATE('20220405', 'YYYYMMDD'),1,0,3);
INSERT INTO APPOINTMENT (APPOINTMENTID,STATUS,STAFFID,GUESTID,REMARK,CHECK_IN,CHECK_OUT,NUM_ADULT,NUM_CHILD,PAYMENT_ID) VALUES (APPOINTMENT_ID_SEQ.NEXTVAL,'ACTIVE',6,4,NULL,TO_DATE('20220502', 'YYYYMMDD'),TO_DATE('20220522', 'YYYYMMDD'),4,0,4);
INSERT INTO APPOINTMENT (APPOINTMENTID,STATUS,STAFFID,GUESTID,REMARK,CHECK_IN,CHECK_OUT,NUM_ADULT,NUM_CHILD,PAYMENT_ID) VALUES (APPOINTMENT_ID_SEQ.NEXTVAL,'ACTIVE',5,5,NULL,TO_DATE('20220606', 'YYYYMMDD'),TO_DATE('20220611', 'YYYYMMDD'),3,1,NULL);
INSERT INTO APPOINTMENT (APPOINTMENTID,STATUS,STAFFID,GUESTID,REMARK,CHECK_IN,CHECK_OUT,NUM_ADULT,NUM_CHILD,PAYMENT_ID) VALUES (APPOINTMENT_ID_SEQ.NEXTVAL,'ACTIVE',6,6,NULL,TO_DATE('20220624', 'YYYYMMDD'),TO_DATE('20220630', 'YYYYMMDD'),1,0,NULL);
INSERT INTO APPOINTMENT (APPOINTMENTID,STATUS,STAFFID,GUESTID,REMARK,CHECK_IN,CHECK_OUT,NUM_ADULT,NUM_CHILD,PAYMENT_ID) VALUES (APPOINTMENT_ID_SEQ.NEXTVAL,'ACTIVE',5,7,NULL,TO_DATE('20220605', 'YYYYMMDD'),TO_DATE('20220608', 'YYYYMMDD'),3,0,NULL);
INSERT INTO APPOINTMENT (APPOINTMENTID,STATUS,STAFFID,GUESTID,REMARK,CHECK_IN,CHECK_OUT,NUM_ADULT,NUM_CHILD,PAYMENT_ID) VALUES (APPOINTMENT_ID_SEQ.NEXTVAL,'ACTIVE',6,8,NULL,TO_DATE('20220802', 'YYYYMMDD'),TO_DATE('20220815', 'YYYYMMDD'),2,0,NULL);
INSERT INTO APPOINTMENT (APPOINTMENTID,STATUS,STAFFID,GUESTID,REMARK,CHECK_IN,CHECK_OUT,NUM_ADULT,NUM_CHILD,PAYMENT_ID) VALUES (APPOINTMENT_ID_SEQ.NEXTVAL,'ACTIVE',5,9,NULL,TO_DATE('20221202', 'YYYYMMDD'),TO_DATE('20221215', 'YYYYMMDD'),1,0,NULL);
INSERT INTO APPOINTMENT (APPOINTMENTID,STATUS,STAFFID,GUESTID,REMARK,CHECK_IN,CHECK_OUT,NUM_ADULT,NUM_CHILD,PAYMENT_ID) VALUES (APPOINTMENT_ID_SEQ.NEXTVAL,'ACTIVE',6,10,NULL,TO_DATE('20230201', 'YYYYMMDD'),TO_DATE('20230213', 'YYYYMMDD'),2,0,NULL);


INSERT INTO RESERVATION (APPOINTMENTID,ROOMID) VALUES (1,1);
INSERT INTO RESERVATION (APPOINTMENTID,ROOMID) VALUES (1,2);
INSERT INTO RESERVATION (APPOINTMENTID,ROOMID) VALUES (2,3);
INSERT INTO RESERVATION (APPOINTMENTID,ROOMID) VALUES (3,4);
INSERT INTO RESERVATION (APPOINTMENTID,ROOMID) VALUES (4,11);
INSERT INTO RESERVATION (APPOINTMENTID,ROOMID) VALUES (5,8);
INSERT INTO RESERVATION (APPOINTMENTID,ROOMID) VALUES (6,9);
INSERT INTO RESERVATION (APPOINTMENTID,ROOMID) VALUES (7,10);
INSERT INTO RESERVATION (APPOINTMENTID,ROOMID) VALUES (8,7);
INSERT INTO RESERVATION (APPOINTMENTID,ROOMID) VALUES (9,12);
INSERT INTO RESERVATION (APPOINTMENTID,ROOMID) VALUES (10,13);


COMMIT;

--------------------------------------------------------
--  DDL for Index GUEST_ID_IDX
--------------------------------------------------------

  CREATE INDEX GUEST_ID_IDX ON GUEST (ID);

--------------------------------------------------------
--  DDL for Index ROOMNUMBER_IDX
--------------------------------------------------------

  CREATE INDEX ROOMNUMBER_IDX ON ROOM (ROOMNUMBER);

--------------------------------------------------------
--  DDL for View APPOINTMENT_VIEW
--------------------------------------------------------

CREATE OR REPLACE VIEW APPOINTMENT_VIEW (STAFFID, APPOINTMENTID, REMARK, CHECK_IN, CHECK_OUT, NUM_ADULT, NUM_CHILD, PAYMENT_ID, FIRSTNAME, LASTNAME, GENDER, AGE, PHONENUMBER, EMAIL, COUNTRY, ID, ROOMNUMBER) AS 
SELECT STAFF.STAFFID, APPOINTMENT.APPOINTMENTID,APPOINTMENT.REMARK, APPOINTMENT.CHECK_IN, 
APPOINTMENT.CHECK_OUT, 
APPOINTMENT.NUM_ADULT, APPOINTMENT.NUM_CHILD, APPOINTMENT.PAYMENT_ID,
GUEST.FIRSTNAME, GUEST.LASTNAME, GUEST.GENDER, GUEST.AGE, GUEST.PHONENUMBER, GUEST.EMAIL, GUEST.COUNTRY, GUEST.ID,
ROOM.ROOMNUMBER
FROM APPOINTMENT, GUEST, STAFF, RESERVATION, ROOM
WHERE 
APPOINTMENT.STAFFID = STAFF.STAFFID
AND APPOINTMENT.GUESTID=GUEST.GUESTID 
AND APPOINTMENT.APPOINTMENTID=RESERVATION.APPOINTMENTID
AND RESERVATION.ROOMID=ROOM.ROOMID
;

set define off;
--------------------------------------------------------
--  DDL for Function IS_PERIOD_COLLIDE_SF
--------------------------------------------------------

CREATE OR REPLACE FUNCTION IS_PERIOD_COLLIDE_SF (
    in_room_numer room.roomnumber%TYPE,
    in_checkin    appointment.check_in%TYPE,
    in_checkout   appointment.check_out%TYPE
) RETURN NUMBER IS

    CURSOR appointment_cur IS
    SELECT
        COUNT(*)
    FROM
        appointment_view
    WHERE
        ( ( check_in > in_checkin
            AND check_in < in_checkout )
          OR ( check_out > in_checkin
               AND check_out < in_checkout )
          OR ( check_out > in_checkout
               AND check_in < in_checkin ) )
        AND roomnumber = in_room_numer;

    l_is_collide NUMBER(1);
BEGIN
    OPEN appointment_cur;
    LOOP
        FETCH appointment_cur INTO l_is_collide;
        EXIT WHEN appointment_cur%notfound;
    END LOOP;
    CLOSE appointment_cur;
    dbms_output.put_line('in_room_numer: '
                         || in_room_numer
                         || ', in_checkin: '
                         || in_checkin
                         || ', in_checkout: '
                         || in_checkout
                         || ', l_is_collide: '
                         || l_is_collide);
	RETURN l_is_collide;
EXCEPTION
    WHEN OTHERS THEN
        l_is_collide := 1;
    RETURN l_is_collide;
END;



--------------------------------------------------------
--  DDL for Function GET_ROOM_NUM_SF
--------------------------------------------------------

CREATE OR REPLACE FUNCTION GET_ROOM_NUM_SF (
    in_room_id room.roomid%TYPE
) RETURN room.roomnumber%TYPE IS
    l_room_number room.roomnumber%TYPE := 0;
BEGIN
    SELECT
        roomnumber
    INTO l_room_number
    FROM
        room
    WHERE
        roomid = in_room_id;

    dbms_output.put_line('in_room_id: '
                         || in_room_id
                         || ', l_room_number: '
                         || l_room_number);
    RETURN l_room_number;
EXCEPTION
    WHEN no_data_found THEN
        l_room_number := 0;
        RETURN l_room_number;
END;

--------------------------------------------------------
--  DDL for Trigger APPOINTMENT_PAYMENT_UPDATE_TRG
--------------------------------------------------------

CREATE OR REPLACE TRIGGER APPOINTMENT_PAYMENT_UPDATE_TRG AFTER
    UPDATE OF payment_id ON appointment
    FOR EACH ROW
     WHEN ( new.payment_id != NULL ) BEGIN
      -- inser record to auditlog
    INSERT INTO auditlog (
        auditid,
        action,
        staffid
    ) VALUES (
        audit_id_seq.NEXTVAL,
        'UPDATE PAYMENT ID OF '
        || :new.appointmentid
        || ' TO '
        || :new.payment_id,
        9999
    );

END;

ALTER TRIGGER APPOINTMENT_PAYMENT_UPDATE_TRG ENABLE;

--------------------------------------------------------
--  DDL for Trigger APPOINTMENT_STATUS_UPDATE_TRG
--------------------------------------------------------

CREATE OR REPLACE TRIGGER APPOINTMENT_STATUS_UPDATE_TRG AFTER
    UPDATE OF status ON appointment
    FOR EACH ROW
     WHEN ( new.status = 'INACTIVE' ) BEGIN
    -- remove record from reservation table when the appointment is cancelled
    DELETE FROM reservation
    WHERE
        appointmentid = :new.appointmentid;
     -- inser record to auditlog
    INSERT INTO auditlog (
        auditid,
        action,
        staffid
    ) VALUES (
        audit_id_seq.NEXTVAL,
        'REMOVE RESERVATION RECORD OF ' || :new.staffid,
        9999
    );

END;

ALTER TRIGGER APPOINTMENT_STATUS_UPDATE_TRG ENABLE;


--------------------------------------------------------
--  DDL for Procedure MAKE_PAYMENT_SP
--------------------------------------------------------


CREATE OR REPLACE PROCEDURE MAKE_PAYMENT_SP (
    in_userid         staff.staffid%TYPE,
    in_appointment_id appointment.appointmentid%TYPE,
    in_payment_type   payment.paymenttype%TYPE,
    in_payment        payment.totalpayment%TYPE,
    in_promotion_id   promotiontype.promotionid%TYPE,
    out_paymentid     OUT payment.paymentid%TYPE
) IS

    l_totalpayment      payment.totalpayment%TYPE;
    l_gst               payment.totalpayment%TYPE;
    l_promotiondiscount payment.totalpayment%TYPE := 0;
    l_promotionrate     promotiontype.discountrate%TYPE := 0;
    l_err_code          NUMBER;
    l_err_msg           VARCHAR2(32000);
BEGIN
    -- get the discount rate of promotion
    IF ( in_promotion_id != NULL ) THEN
        SELECT
            discountrate
        INTO l_promotionrate
        FROM
            promotiontype
        WHERE
            promotionid = in_promotion_id;

    END IF;

    -- calculate the total price after adding gst
    l_gst := round(in_payment * 0.13, 2);
        
    -- calculate the discount
    l_promotiondiscount := round((in_payment + l_gst) * l_promotionrate, 2) * -1;

    -- calculate the total price
    l_totalpayment := l_gst + in_payment + l_promotiondiscount;
    dbms_output.put_line('in_payment: '
                         || in_payment
                         || ', l_promotiondiscount: '
                         || l_promotiondiscount
                         || ', l_totalpayment: '
                         || l_totalpayment);
    
    -- get new payment id
    out_paymentid := payment_id_seq.nextval;
    dbms_output.put_line('out_paymentid: ' || out_paymentid);

    -- insert record to payment table
    INSERT INTO payment (
        paymentid,
        paymenttype,
        totalpayment,
        paymentdate,
        promotionid
    ) VALUES (
        out_paymentid,
        in_payment_type,
        l_totalpayment,
        sysdate,
        in_promotion_id
    );

    dbms_output.put_line('payment record inserted');
    
    -- insert gst, discount, room charges to the charge table
    INSERT INTO charge (
        chargeid,
        paymentid,
        chargetype,
        chargeamount
    ) VALUES (
        charge_id_seq.NEXTVAL,
        out_paymentid,
        'ROOM',
        in_payment
    );

    dbms_output.put_line('ROOM charge record inserted');
    INSERT INTO charge (
        chargeid,
        paymentid,
        chargetype,
        chargeamount
    ) VALUES (
        charge_id_seq.NEXTVAL,
        out_paymentid,
        'GST',
        l_gst
    );

    dbms_output.put_line('GST charge record inserted');
    IF ( l_promotiondiscount != 0 ) THEN
        INSERT INTO charge (
            chargeid,
            paymentid,
            chargetype,
            chargeamount
        ) VALUES (
            charge_id_seq.NEXTVAL,
            out_paymentid,
            'DISCOUNT',
            l_promotiondiscount
        );

        dbms_output.put_line('Discount record inserted');
    END IF;

    COMMIT;
    UPDATE appointment
    SET
        payment_id = out_paymentid
    WHERE
        appointmentid = in_appointment_id;

    dbms_output.put_line('DONE');

    -- insert record to auditlog table
    INSERT INTO auditlog (
        auditid,
        action,
        staffid
    ) VALUES (
        audit_id_seq.NEXTVAL,
        'INSERT PAYMENT ('
        || out_paymentid
        || ')',
        in_userid
    );

    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
         l_err_code := SQLCODE;
         l_err_msg := SQLERRM;
        dbms_output.put_line('SQLCODE '
                             || l_err_code
                             || ' ('
                             || l_err_msg
                             || ')  has happened.');
        ROLLBACK;
END;



--------------------------------------------------------
--  DDL for Procedure GET_ROOM_PRICE_SP
--------------------------------------------------------
CREATE OR REPLACE PROCEDURE GET_ROOM_PRICE_SP (
    in_appointmentid IN appointment.appointmentid%TYPE,
    out_roomprice    OUT NUMBER
) AS
    -- exception section, using cursors
    CURSOR room_price_cur (
        appointment_id appointment.appointmentid%TYPE
    ) IS
    SELECT
        SUM(price)
    FROM
        reservation,
        room,
        roomtype
    WHERE
            reservation.roomid = room.roomid
        AND room.roomtype = roomtype.roomtype
        AND appointmentid = in_appointmentid;

BEGIN
    OPEN room_price_cur(in_appointmentid);
    LOOP
        FETCH room_price_cur INTO out_roomprice;
        EXIT WHEN room_price_cur%notfound;
    END LOOP;
    CLOSE room_price_cur;
    dbms_output.put_line('in_appointmentid: '
                         || in_appointmentid
                         || ', out_roomprice: '
                         || out_roomprice);
EXCEPTION
    WHEN OTHERS THEN
        out_roomprice := 0;
END get_room_price_sp;



--------------------------------------------------------
--  DDL for Procedure GET_REVENUE_SP
--------------------------------------------------------
CREATE OR REPLACE PROCEDURE GET_REVENUE_SP (
    in_year     NUMBER,
    in_month    NUMBER,
    out_revenue OUT NUMBER
) IS
    l_start_date DATE;
    l_end_date   DATE;
BEGIN
    -- get start date (example: 2021,12,1)
    l_start_date := TO_DATE ( in_year
                              || '-'
                              || in_month
                              || '-1', 'YYYY-MM-DD' );
    
    -- get end date (example: 2021,12,31)
    l_end_date := TO_DATE ( (
        CASE
            WHEN in_month = 12 THEN
                in_year + 1
            ELSE
                in_year
        END
    )
                            || '-'
                            || (
        CASE
            WHEN in_month = 12 THEN
                1
            ELSE
                in_month + 1
        END
    )
                            || '-1', 'YYYY-MM-DD' ) - 1;

    dbms_output.put_line('l_start_date: '
                         || l_start_date
                         || ', l_end_date: '
                         || l_end_date);
    SELECT
        nvl(SUM(totalpayment),
            0)
    INTO out_revenue
    FROM
        payment
    WHERE
        paymentdate BETWEEN l_start_date AND l_end_date;

    dbms_output.put_line('totalpayment: ' || out_revenue);
EXCEPTION
    WHEN no_data_found THEN
        out_revenue := 0;
END;


--------------------------------------------------------
--  DDL for Package APPOINTMENT_PKG
--------------------------------------------------------

CREATE OR REPLACE PACKAGE APPOINTMENT_PKG AS 

    FUNCTION IS_GUEST_EXIST_SF(in_passport_id GUEST.ID%TYPE) RETURN NUMBER;
    
    PROCEDURE CREATE_APPOINTMENT_SP(
    in_userid STAFF.STAFFID%TYPE,
    in_guestid GUEST.GUESTID%TYPE,
    in_remark APPOINTMENT.REMARK%TYPE,
    in_check_in APPOINTMENT.CHECK_IN%TYPE,
    in_check_out APPOINTMENT.CHECK_OUT%TYPE,
    in_num_adult APPOINTMENT.NUM_ADULT%TYPE,
    in_num_child APPOINTMENT.NUM_CHILD%TYPE,
    in_room_num ROOM.ROOMNUMBER%TYPE,
    out_appointmentid OUT APPOINTMENT.APPOINTMENTID%TYPE);
    
    PROCEDURE CANCEL_APPOINTMENT_SP(
    in_userid STAFF.STAFFID%TYPE,
    in_appointment_id APPOINTMENT.APPOINTMENTID%TYPE,
    out_affectedRowCnt OUT INTEGER);
    
END APPOINTMENT_PKG;

--------------------------------------------------------
--  DDL for Package Body APPOINTMENT_PKG
--------------------------------------------------------

CREATE OR REPLACE PACKAGE BODY APPOINTMENT_PKG AS
    
    -- private function get_room_id_sf
    FUNCTION get_room_id_sf (
        in_room_number room.roomnumber%TYPE
    ) RETURN NUMBER IS
        l_room_id NUMBER := 0;
    BEGIN
        SELECT
            roomid
        INTO l_room_id
        FROM
            room
        WHERE
            roomnumber = in_room_number;

        dbms_output.put_line('in_room_number: '
                             || in_room_number
                             || ', l_room_id: '
                             || l_room_id);
        RETURN l_room_id;
    EXCEPTION
        WHEN no_data_found THEN
            l_room_id := 0;
            RETURN l_room_id;
    END;

    -- public function is_guest_exist_sf
    FUNCTION is_guest_exist_sf (
        in_passport_id guest.id%TYPE
    ) RETURN NUMBER IS
        l_exist NUMBER(1) := 1;
    BEGIN
        SELECT
            CASE
                WHEN COUNT(1) > 0 THEN
                    1
                ELSE
                    0
            END
        INTO l_exist
        FROM
            guest
        WHERE
            id = in_passport_id;

        dbms_output.put_line('in_passport_id: '
                             || in_passport_id
                             || ', l_exist: '
                             || l_exist);
			RETURN l_exist;
    EXCEPTION
        WHEN no_data_found THEN
            l_exist := 1;
            
            RETURN l_exist;
    END;
    
    -- public stored procedure create_appointment_sp
    PROCEDURE create_appointment_sp (
        in_userid         staff.staffid%TYPE,
        in_guestid        guest.guestid%TYPE,
        in_remark         appointment.remark%TYPE,
        in_check_in       appointment.check_in%TYPE,
        in_check_out      appointment.check_out%TYPE,
        in_num_adult      appointment.num_adult%TYPE,
        in_num_child      appointment.num_child%TYPE,
        in_room_num       room.roomnumber%TYPE,
        out_appointmentid OUT appointment.appointmentid%TYPE
    ) AS
        l_roomid room.roomid%TYPE;
    BEGIN
        -- get new appointment sequence
        out_appointmentid := appointment_id_seq.nextval;
        IF ( is_period_collide_sf(in_room_num, in_check_in, in_check_out) = 1 ) THEN
            raise_application_error(-20002, 'Existing appointment found!');
        ELSE
         -- insert appointment record
            INSERT INTO appointment (
                appointmentid,
                staffid,
                guestid,
                remark,
                check_in,
                check_out,
                num_adult,
                num_child
            ) VALUES (
                out_appointmentid,
                in_userid,
                in_guestid,
                in_remark,
                in_check_in,
                in_check_out,
                in_num_adult,
                in_num_child
            );

            dbms_output.put_line('1. record inserted to appointment table: ' || out_appointmentid);
        -- insert reservation record

            l_roomid := appointment_pkg.get_room_id_sf(in_room_num);
            IF ( l_roomid != 0 ) THEN
                INSERT INTO reservation (
                    appointmentid,
                    roomid
                ) VALUES (
                    out_appointmentid,
                    l_roomid
                );

            END IF;

            dbms_output.put_line('2. record inserted to reservation table: ' || l_roomid);
            COMMIT;
            
        -- insert record to audit log
            INSERT INTO auditlog (
                auditid,
                action,
                staffid
            ) VALUES (
                audit_id_seq.NEXTVAL,
                'INSERT APPOINTMENT ('
                || out_appointmentid
                || ')',
                in_userid
            );

            COMMIT;
        END IF;

    EXCEPTION
        WHEN OTHERS THEN
            out_appointmentid := 0;
            ROLLBACK;
    END create_appointment_sp;

    -- public stored procedure cancel_appointment_sp
    PROCEDURE cancel_appointment_sp (
        in_userid          staff.staffid%TYPE,
        in_appointment_id  appointment.appointmentid%TYPE,
        out_affectedrowcnt OUT INTEGER
    ) AS
    BEGIN
        -- update appointment status to inactive
        UPDATE appointment
        SET
            status = 'INACTIVE'
        WHERE
            appointmentid = in_appointment_id;

        out_affectedrowcnt := SQL%rowcount;
        COMMIT;
        dbms_output.put_line('in_userid: '
                             || in_userid
                             || ', in_appointment_id: '
                             || in_appointment_id
                             || ', out_affectedrowcnt: '
                             || out_affectedrowcnt);
                             
        -- insert action to auditlog table
        INSERT INTO auditlog (
            auditid,
            action,
            staffid
        ) VALUES (
            audit_id_seq.NEXTVAL,
            'CANCEL APPOINTMENT ( '
            || in_appointment_id
            || ')',
            in_userid
        );

        COMMIT;
    EXCEPTION
        WHEN OTHERS THEN
            out_affectedrowcnt := 0;
    END cancel_appointment_sp;

END appointment_pkg;


--------------------------------------------------------
--  DDL for Package STAFF_PKG
--------------------------------------------------------

CREATE OR REPLACE PACKAGE STAFF_PKG AS
    PROCEDURE update_password_sp (
        in_userid          staff.staffid%TYPE,
        in_staffid         staff.staffid%TYPE,
        in_password        staff.password%TYPE,
        out_affectedrowcnt OUT INTEGER
    );

    PROCEDURE get_user_sp (
        in_username     staff.username%TYPE,
        in_password     staff.password%TYPE,
        out_staffid     OUT staff.staffid%TYPE
    );

END staff_pkg;

--------------------------------------------------------
--  DDL for Package Body STAFF_PKG
--------------------------------------------------------

CREATE OR REPLACE PACKAGE BODY STAFF_PKG AS
    
    -- private variable to store information
    attempt NUMBER := 0;
    
    -- public procedure to update password
    PROCEDURE update_password_sp (
        in_userid          staff.staffid%TYPE,
        in_staffid         staff.staffid%TYPE,
        in_password        staff.password%TYPE,
        out_affectedrowcnt OUT INTEGER
    ) AS
    BEGIN
        UPDATE staff
        SET
            password = in_password
        WHERE
            staffid = in_staffid;

        out_affectedrowcnt := SQL%rowcount;
        COMMIT;
        dbms_output.put_line('Updated password. in_userid: '
                             || in_userid
                             || ', in_staffid: '
                             || in_staffid
                             || ', in_password: '
                             || in_password);
                             
    -- insert record to auditlog table
        INSERT INTO auditlog (
            auditid,
            action,
            staffid
        ) VALUES (
            audit_id_seq.NEXTVAL,
            'UPDATE PASSWORD OF ' || in_staffid,
            in_userid
        );

        COMMIT;
    EXCEPTION
        WHEN OTHERS THEN
            ROLLBACK;
    END update_password_sp;

    -- public procedure to get user by username and password
    PROCEDURE get_user_sp (
        in_username staff.username%TYPE,
        in_password staff.password%TYPE,
        out_staffid OUT staff.staffid%TYPE
    ) AS

        login_over_thrice EXCEPTION;
        PRAGMA exception_init ( login_over_thrice, -20001 );
        
        CURSOR staff_cur IS
        SELECT
            staffid
        FROM
            staff
        WHERE
                username = in_username
            AND password = in_password;

    BEGIN
        IF ( attempt = 3 ) THEN
            RAISE login_over_thrice;
        END IF;
        OPEN staff_cur;
        LOOP
            FETCH staff_cur INTO out_staffid;
            dbms_output.put_line('# record: ' || staff_cur%rowcount);
            IF ( staff_cur%rowcount = 0 ) THEN
                attempt := attempt + 1;
                dbms_output.put_line('Attempt: ' || attempt);
            ELSE
                attempt := 0;
                dbms_output.put_line('out_staffid: ' || out_staffid);
            END IF;

            EXIT WHEN staff_cur%notfound;
        END LOOP;

    END get_user_sp;

END staff_pkg;



--------------------------------------------------------
--  DDL for Procedure CREATE_GUEST_SP
--------------------------------------------------------

CREATE OR REPLACE PROCEDURE CREATE_GUEST_SP (
    in_userid      staff.staffid%TYPE,
    in_firstname   guest.firstname%TYPE,
    in_lastname    guest.lastname%TYPE,
    in_gender      guest.gender%TYPE,
    in_age         guest.age%TYPE,
    in_phonenumber guest.phonenumber%TYPE,
    in_email       guest.email%TYPE,
    in_country     guest.country%TYPE,
    in_id          guest.id%TYPE,
    out_guestid    OUT INTEGER
) IS
BEGIN
    -- check if the guest passport id can be found in table, if no, insert new record
    IF ( appointment_pkg.is_guest_exist_sf(in_id) = 0 ) THEN
        INSERT INTO guest (
            guestid,
            firstname,
            lastname,
            gender,
            age,
            phonenumber,
            email,
            country,
            id
        ) VALUES (
            guest_id_seq.NEXTVAL,
            in_firstname,
            in_lastname,
            in_gender,
            in_age,
            in_phonenumber,
            in_email,
            in_country,
            in_id
        );

        COMMIT;
    
                             
        -- select new questid from database by passport id
        SELECT
            guestid
        INTO out_guestid
        FROM
            guest
        WHERE
            id = in_id;

        dbms_output.put_line('in_userid: '
                             || in_userid
                             || ', in_firstname: '
                             || in_firstname
                             || ', in_lastname: '
                             || in_lastname
                             || ', in_gender: '
                             || in_gender
                             || ', in_age: '
                             || in_age
                             || ', in_phonenumber: '
                             || in_phonenumber
                             || ', in_email: '
                             || in_email
                             || ', in_country: '
                             || in_country
                             || ', in_id: '
                             || in_id);
                             
        -- insert record to auditlog table
        INSERT INTO auditlog (
            auditid,
            action,
            staffid
        ) VALUES (
            audit_id_seq.NEXTVAL,
            'INSERT GUEST ('
            || out_guestid
            || ')',
            in_userid
        );

        COMMIT;
    ELSE
        SELECT
            guestid
        INTO out_guestid
        FROM
            guest
        WHERE
            id = in_id;
    END IF;
    
    dbms_output.put_line('out_guestid: ' || out_guestid);
EXCEPTION
    WHEN OTHERS THEN
        SELECT
            0
        INTO out_guestid
        FROM
            dual;

        ROLLBACK;
END;

