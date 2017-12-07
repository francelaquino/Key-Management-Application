using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using KeyIssuingAPI.Models;
using Oracle.DataAccess.Client;
using Db_Connection;
using System.Data;
using Newtonsoft.Json;
namespace KeyIssuingAPI.Controllers
{
    public class DataController : ApiController
    {

        [ActionName("saveBuilding")]
        [HttpPost]
        public System.Web.Mvc.JsonResult saveBuilding(mdlBuilding model)
        {
            string response = "";
            clsConnection dbconn = new clsConnection();
            try
            {

                dbconn.openConnection();

                string strSQL = @"SELECT ID FROM BUILDINGS WHERE BUILDINGCODE=:BUILDINGCODE";

                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.BindByName = true;
                cmd.Parameters.Add("BUILDINGCODE", OracleDbType.Varchar2, model.buildingcode, ParameterDirection.Input);
                OracleDataReader dr=cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    response = "Building code already exist";
                }
                else
                {
                    dr.Dispose();
                    cmd.Dispose();
                    strSQL = @"INSERT INTO BUILDINGS(ID,BUILDINGCODE,BUILDINGNAME,CREATEDBY,MODIFIEDBY)
                   VALUES((SELECT NVL(MAX(ID),0)+1 FROM BUILDINGS),:BUILDINGCODE,:BUILDINGNAME,:CREATEDBY,:MODIFIEDBY)";

                    cmd = new OracleCommand(strSQL, dbconn.DbConn);
                    cmd.BindByName = true;
                    cmd.Parameters.Add("BUILDINGCODE", OracleDbType.Varchar2, model.buildingcode, ParameterDirection.Input);
                    cmd.Parameters.Add("BUILDINGNAME", OracleDbType.Varchar2, model.buildingname, ParameterDirection.Input);
                    cmd.Parameters.Add("CREATEDBY", OracleDbType.Varchar2, "currentuser", ParameterDirection.Input);
                    cmd.Parameters.Add("MODIFIEDBY", OracleDbType.Varchar2, "currentuser", ParameterDirection.Input);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    dbconn.closeConnection();
                }
                var result = new System.Web.Mvc.JsonResult { Data = response };
                return result;
            }
            catch (Exception ex)
            {
                var result = new System.Web.Mvc.JsonResult { Data = response };
                return result;

            }
            finally {
                dbconn.closeConnection();
            }
        }


        [ActionName("saveLevel")]
        [HttpPost]
        public System.Web.Mvc.JsonResult saveLevel(mdlLevel model)
        {
            string response = "";
            clsConnection dbconn = new clsConnection();
            try
            {

                dbconn.openConnection();



                string strSQL = @"SELECT ID FROM LEVELS WHERE BUILDING=:BUILDING AND LEVELS=:LEVELS";

                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.BindByName = true;
                cmd.Parameters.Add("BUILDING", OracleDbType.Varchar2, model.building, ParameterDirection.Input);
                cmd.Parameters.Add("LEVELS", OracleDbType.Varchar2, model.level, ParameterDirection.Input);
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    response = "Level already exist";
                }
                else
                {
                    dr.Dispose();
                    cmd.Dispose();
                    strSQL = @"INSERT INTO LEVELS(ID,BUILDING,LEVELS,CREATEDBY,MODIFIEDBY,ACTIVE)
                   VALUES((SELECT NVL(MAX(ID),0)+1 FROM LEVELS),:BUILDING,:LEVELS,:CREATEDBY,:MODIFIEDBY,'A')";

                    cmd = new OracleCommand(strSQL, dbconn.DbConn);
                    cmd.BindByName = true;
                    cmd.Parameters.Add("BUILDING", OracleDbType.Varchar2, model.building, ParameterDirection.Input);
                    cmd.Parameters.Add("LEVELS", OracleDbType.Varchar2, model.level, ParameterDirection.Input);
                    cmd.Parameters.Add("CREATEDBY", OracleDbType.Varchar2, "currentuser", ParameterDirection.Input);
                    cmd.Parameters.Add("MODIFIEDBY", OracleDbType.Varchar2, "currentuser", ParameterDirection.Input);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    dbconn.closeConnection();
                }

                var result = new System.Web.Mvc.JsonResult { Data = response };
                return result;
            }
            catch (Exception ex)
            {
                var result = new System.Web.Mvc.JsonResult { Data = response };
                return result;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }

        [ActionName("saveRoom")]
        [HttpPost]
        public System.Web.Mvc.JsonResult saveRoom(mdlRoom model)
        {
            string response = "";
            clsConnection dbconn = new clsConnection();
            try
            {

                dbconn.openConnection();



                string strSQL = @"SELECT ID FROM ROOMS WHERE ROOM=:ROOM AND BUILDINGID=:BUILDINGID AND LEVELS=:LEVELS";

                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.BindByName = true;
                cmd.Parameters.Add("ROOM", OracleDbType.Varchar2, model.room, ParameterDirection.Input);
                cmd.Parameters.Add("BUILDINGID", OracleDbType.Varchar2, model.buildingid, ParameterDirection.Input);
                cmd.Parameters.Add("LEVELS", OracleDbType.Varchar2, model.level, ParameterDirection.Input);
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    response = "Room already exist";
                }
                else
                {
                    dr.Dispose();
                    cmd.Dispose();
                    strSQL = @"INSERT INTO ROOMS(ID,BUILDINGID,LEVELS,ROOM,CREATEDBY,MODIFIEDBY,ACTIVE)
                   VALUES((SELECT NVL(MAX(ID),0)+1 FROM ROOMS),:BUILDINGID,:LEVELS,:ROOM,:CREATEDBY,:MODIFIEDBY,'A')";

                    cmd = new OracleCommand(strSQL, dbconn.DbConn);
                    cmd.BindByName = true;
                    cmd.Parameters.Add("BUILDINGID", OracleDbType.Varchar2, model.buildingid, ParameterDirection.Input);
                    cmd.Parameters.Add("LEVELS", OracleDbType.Varchar2, model.level, ParameterDirection.Input);
                    cmd.Parameters.Add("ROOM", OracleDbType.Varchar2, model.room, ParameterDirection.Input);
                    cmd.Parameters.Add("CREATEDBY", OracleDbType.Varchar2, "currentuser", ParameterDirection.Input);
                    cmd.Parameters.Add("MODIFIEDBY", OracleDbType.Varchar2, "currentuser", ParameterDirection.Input);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    dbconn.closeConnection();
                }

                var result = new System.Web.Mvc.JsonResult { Data = response };
                return result;
            }
            catch (Exception ex)
            {
                var result = new System.Web.Mvc.JsonResult { Data = response };
                return result;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }


        [ActionName("saveKey")]
        [HttpPost]
        public System.Web.Mvc.JsonResult saveRoom(mdlKey model)
        {
            string response = "";
            clsConnection dbconn = new clsConnection();
            try
            {

                dbconn.openConnection();



                string strSQL = @"SELECT ID FROM KEYS WHERE KEYTYPE=:KEYTYPE AND ROOM=:ROOM AND BUILDING=:BUILDING AND LEVELS=:LEVELS";

                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.BindByName = true;
                cmd.Parameters.Add("KEYTYPE", OracleDbType.Varchar2, model.keytype, ParameterDirection.Input);
                cmd.Parameters.Add("ROOM", OracleDbType.Varchar2, model.room, ParameterDirection.Input);
                cmd.Parameters.Add("BUILDING", OracleDbType.Varchar2, model.buildingid, ParameterDirection.Input);
                cmd.Parameters.Add("LEVELS", OracleDbType.Varchar2, model.level, ParameterDirection.Input);
                
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    response = "Key already exist";
                }
                else
                {
                    dr.Dispose();
                    cmd.Dispose();
                    strSQL = @"INSERT INTO KEYS(ID,BUILDING,LEVELS,ROOM,KEYTYPE,QUANTITY,CREATEDBY,MODIFIEDBY)
                   VALUES((SELECT NVL(MAX(ID),0)+1 FROM KEYS),:BUILDING,:LEVELS,:ROOM,:KEYTYPE,:QUANTITY,:CREATEDBY,:MODIFIEDBY)";

                    cmd = new OracleCommand(strSQL, dbconn.DbConn);
                    cmd.BindByName = true;
                    cmd.Parameters.Add("BUILDING", OracleDbType.Varchar2, model.buildingid, ParameterDirection.Input);
                    cmd.Parameters.Add("LEVELS", OracleDbType.Varchar2, model.level, ParameterDirection.Input);
                    cmd.Parameters.Add("ROOM", OracleDbType.Varchar2, model.room, ParameterDirection.Input);
                    cmd.Parameters.Add("KEYTYPE", OracleDbType.Varchar2, model.keytype, ParameterDirection.Input);
                    cmd.Parameters.Add("QUANTITY", OracleDbType.Varchar2, model.quantity, ParameterDirection.Input);
                    cmd.Parameters.Add("CREATEDBY", OracleDbType.Varchar2, "currentuser", ParameterDirection.Input);
                    cmd.Parameters.Add("MODIFIEDBY", OracleDbType.Varchar2, "currentuser", ParameterDirection.Input);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    dbconn.closeConnection();
                }

                var result = new System.Web.Mvc.JsonResult { Data = response };
                return result;
            }
            catch (Exception ex)
            {
                var result = new System.Web.Mvc.JsonResult { Data = response };
                return result;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }

        [ActionName("saveIssuance")]
        [HttpPost]
        public System.Web.Mvc.JsonResult saveIssuance(mdlRequest model)
        {
            string response = "";
            clsConnection dbconn = new clsConnection();
            try
            {

                dbconn.openConnection();



                string strSQL = @"SELECT (QUANTITY-(SELECT NVL(SUM(QUANTITY),0) FROM REQUESTS WHERE STATUS='I' AND KEYID=:ID)) as QUANTITY FROM KEYS WHERE ID=:ID";

                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.BindByName = true;
                cmd.Parameters.Add("ID", OracleDbType.Varchar2, model.keyid, ParameterDirection.Input);
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    if (Convert.ToDouble(dr["QUANTITY"].ToString()) < Convert.ToDouble(model.quantity))
                    {
                        response = "Not enough key quantity to issue";
                    }
                }

                dr.Dispose();

                cmd.Dispose();
                if (response == "")
                {

                    strSQL = @"UPDATE REQUESTS SET STATUS='I',ISSUANCETYPE=:ISSUANCETYPE,RETURNDATE=:RETURNDATE
                    WHERE ID=:ID";

                    cmd = new OracleCommand(strSQL, dbconn.DbConn);
                    cmd.BindByName = true;
                    cmd.Parameters.Add("ISSUANCETYPE", OracleDbType.Varchar2, model.issuancetype, ParameterDirection.Input);
                    cmd.Parameters.Add("RETURNDATE", OracleDbType.Varchar2, model.returndate, ParameterDirection.Input);
                    cmd.Parameters.Add("ID", OracleDbType.Varchar2, model.id, ParameterDirection.Input);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    dbconn.closeConnection();

                    insertLogs(model.id,model.username,"I");
                }

                var result = new System.Web.Mvc.JsonResult { Data = response };
                return result;
            }
            catch (Exception ex)
            {
                var result = new System.Web.Mvc.JsonResult { Data = response };
                return result;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }


        [ActionName("saveRequest")]
        [HttpPost]
        public System.Web.Mvc.JsonResult saveRequest(mdlRequest model)
        {
            string response = "";

            clsConnection dbconn = new clsConnection();
            try
            {

                dbconn.openConnection();
                string strSQL = @"SELECT ID FROM REQUESTS WHERE EMPLOYEENO=:EMPLOYEENO AND STATUS IN ('I','F') AND KEYID=:KEYID";

                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.BindByName = true;
                cmd.Parameters.Add("EMPLOYEENO", OracleDbType.Varchar2, model.employeeno, ParameterDirection.Input);
                cmd.Parameters.Add("KEYID", OracleDbType.Varchar2, model.keyid, ParameterDirection.Input);
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    response = "The employee already recieved the same key or The employee already have pending request for approval";
                }
                else
                {
                    cmd.Dispose();

                    strSQL = @"INSERT INTO REQUESTS(ID,KEYID,EMPLOYEENO,EMPLOYEENAME,SECTION,EXTENSION,NOTES,STATUS,ENCODEDBY,QUANTITY)
                VALUES((SELECT NVL(MAX(ID),0)+1 FROM REQUESTS),:KEYID,:EMPLOYEENO,:EMPLOYEENAME,:SECTION,:EXTENSION,:NOTES,:STATUS,:ENCODEDBY,:QUANTITY)";

                    cmd = new OracleCommand(strSQL, dbconn.DbConn);
                    cmd.BindByName = true;
                    cmd.Parameters.Add("KEYID", OracleDbType.Varchar2, model.keyid, ParameterDirection.Input);
                    cmd.Parameters.Add("EMPLOYEENO", OracleDbType.Varchar2, model.employeeno, ParameterDirection.Input);
                    cmd.Parameters.Add("EMPLOYEENAME", OracleDbType.Varchar2, model.employeename, ParameterDirection.Input);
                    cmd.Parameters.Add("SECTION", OracleDbType.Varchar2, model.section, ParameterDirection.Input);
                    cmd.Parameters.Add("EXTENSION", OracleDbType.Varchar2, model.extension, ParameterDirection.Input);
                    cmd.Parameters.Add("NOTES", OracleDbType.Varchar2, model.notes, ParameterDirection.Input);
                    cmd.Parameters.Add("STATUS", OracleDbType.Varchar2, "F", ParameterDirection.Input);
                    cmd.Parameters.Add("ENCODEDBY", OracleDbType.Varchar2, model.username, ParameterDirection.Input);
                    cmd.Parameters.Add("QUANTITY", OracleDbType.Varchar2, model.requestquantity, ParameterDirection.Input);

                    cmd.ExecuteNonQuery();
                    response = "";
                }
                cmd.Dispose();
                dbconn.closeConnection();

                var result = new System.Web.Mvc.JsonResult { Data = response };
                return result;
            }
            catch (Exception ex)
            {
                var result = new System.Web.Mvc.JsonResult { Data = response };
                return result;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }


        [ActionName("updateBuilding")]
        [HttpPost]
        public System.Web.Mvc.JsonResult updateBuilding(mdlBuilding model)
        {
            string response = "";
            clsConnection dbconn = new clsConnection();
            try
            {

                dbconn.openConnection();

                string strSQL = @"SELECT ID FROM BUILDINGS  WHERE BUILDINGCODE=:BUILDINGCODE";

                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.BindByName = true;
                cmd.Parameters.Add("BUILDINGCODE", OracleDbType.Varchar2, model.buildingcode, ParameterDirection.Input);
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    if (dr[0].ToString() != model.id)
                    {
                        response = "Building code already exist";
                    }
                }

                dr.Dispose();
                cmd.Dispose();

                if (response == "")
                {
                    strSQL = @"UPDATE BUILDINGS SET BUILDINGCODE=:BUILDINGCODE,BUILDINGNAME=:BUILDINGNAME,
                DATEMODIFIED=SYSDATE,MODIFIEDBY=:MODIFIEDBY WHERE ID=:ID";

                    cmd = new OracleCommand(strSQL, dbconn.DbConn);
                    cmd.BindByName = true;
                    cmd.Parameters.Add("BUILDINGCODE", OracleDbType.Varchar2, model.buildingcode, ParameterDirection.Input);
                    cmd.Parameters.Add("BUILDINGNAME", OracleDbType.Varchar2, model.buildingname, ParameterDirection.Input);
                    cmd.Parameters.Add("MODIFIEDBY", OracleDbType.Varchar2, "currentuser", ParameterDirection.Input);
                    cmd.Parameters.Add("ID", OracleDbType.Varchar2, model.id, ParameterDirection.Input);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    response = "Building information successfully saved";
                }

                dbconn.closeConnection();

                var result = new System.Web.Mvc.JsonResult { Data = response };
                return result;
            }
            catch (Exception ex)
            {
                var result = new System.Web.Mvc.JsonResult { Data = response };
                return result;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }


        [ActionName("updateLevel")]
        [HttpPost]
        public System.Web.Mvc.JsonResult updateLevel(mdlLevel model)
        {
            string response = "";
            clsConnection dbconn = new clsConnection();
            try
            {

                dbconn.openConnection();

                string strSQL = @"SELECT ID FROM LEVELS  WHERE BUILDING=:BUILDING AND LEVELS=:LEVELS";

                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.BindByName = true;
                cmd.Parameters.Add("BUILDING", OracleDbType.Varchar2, model.building, ParameterDirection.Input);
                cmd.Parameters.Add("LEVELS", OracleDbType.Varchar2, model.level, ParameterDirection.Input);
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    if (dr[0].ToString() != model.id)
                    {
                        response = "Level already exist";
                    }
                }

                dr.Dispose();
                cmd.Dispose();

                if (response == "")
                {
                    strSQL = @"UPDATE LEVELS SET LEVELS=:LEVELS,ACTIVE=:ACTIVE,
                DATEMODIFIED=SYSDATE,MODIFIEDBY=:MODIFIEDBY WHERE ID=:ID";

                    cmd = new OracleCommand(strSQL, dbconn.DbConn);
                    cmd.BindByName = true;
                    cmd.Parameters.Add("LEVELS", OracleDbType.Varchar2, model.level, ParameterDirection.Input);
                    cmd.Parameters.Add("ACTIVE", OracleDbType.Varchar2, model.active.Substring(0,1), ParameterDirection.Input);
                    cmd.Parameters.Add("MODIFIEDBY", OracleDbType.Varchar2, "currentuser", ParameterDirection.Input);
                    cmd.Parameters.Add("ID", OracleDbType.Varchar2, model.id, ParameterDirection.Input);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    response = "Level information successfully saved";
                }

                dbconn.closeConnection();

                var result = new System.Web.Mvc.JsonResult { Data = response };
                return result;
            }
            catch (Exception ex)
            {
                var result = new System.Web.Mvc.JsonResult { Data = response };
                return result;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }


        [ActionName("updateRoom")]
        [HttpPost]
        public System.Web.Mvc.JsonResult updateRoom(mdlRoom model)
        {
            string response = "";
            clsConnection dbconn = new clsConnection();
            try
            {

                dbconn.openConnection();

                string strSQL = @"SELECT ID FROM ROOMS  WHERE BUILDINGID=:BUILDINGID AND ROOM=:ROOM AND LEVELS=:LEVELS";

                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.BindByName = true;
                cmd.Parameters.Add("BUILDINGID", OracleDbType.Varchar2, model.buildingid, ParameterDirection.Input);
                cmd.Parameters.Add("ROOM", OracleDbType.Varchar2, model.room, ParameterDirection.Input);
                cmd.Parameters.Add("LEVELS", OracleDbType.Varchar2, model.level, ParameterDirection.Input);
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    if (dr[0].ToString() != model.id)
                    {
                        response = "Room already exist";
                    }
                }

                dr.Dispose();
                cmd.Dispose();

                if (response == "")
                {
                    strSQL = @"UPDATE ROOMS SET ROOM=:ROOM,ACTIVE=:ACTIVE,
                DATEMODIFIED=SYSDATE,MODIFIEDBY=:MODIFIEDBY WHERE ID=:ID";

                    cmd = new OracleCommand(strSQL, dbconn.DbConn);
                    cmd.BindByName = true;
                    cmd.Parameters.Add("ROOM", OracleDbType.Varchar2, model.room, ParameterDirection.Input);
                    cmd.Parameters.Add("ACTIVE", OracleDbType.Varchar2, model.active.Substring(0,1), ParameterDirection.Input);
                    cmd.Parameters.Add("MODIFIEDBY", OracleDbType.Varchar2, "currentuser", ParameterDirection.Input);
                    cmd.Parameters.Add("ID", OracleDbType.Varchar2, model.id, ParameterDirection.Input);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    response = "Room information successfully saved";
                }

                dbconn.closeConnection();

                var result = new System.Web.Mvc.JsonResult { Data = response };
                return result;
            }
            catch (Exception ex)
            {
                var result = new System.Web.Mvc.JsonResult { Data = response };
                return result;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }

        [ActionName("updateKeyQuantity")]
        [HttpPost]
        public System.Web.Mvc.JsonResult updateKeyQuantity(mdlKey model)
        {
            string response = "";
            clsConnection dbconn = new clsConnection();
            try
            {

                dbconn.openConnection();

                string strSQL = @"UPDATE KEYS SET QUANTITY=:QUANTITY WHERE ID=:ID";

                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.BindByName = true;
                cmd.Parameters.Add("QUANTITY", OracleDbType.Varchar2, model.quantity, ParameterDirection.Input);
                cmd.Parameters.Add("ID", OracleDbType.Varchar2, model.id, ParameterDirection.Input);
                cmd.ExecuteNonQuery();


                response = "Room information successfully saved";

                dbconn.closeConnection();

                var result = new System.Web.Mvc.JsonResult { Data = response };
                return result;
            }
            catch (Exception ex)
            {
                var result = new System.Web.Mvc.JsonResult { Data = response };
                return result;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }

        [ActionName("getKeyQuantity")]
        [HttpPost]
        public mdlKey getKeyQuantity(mdlKey model)
        {
            clsConnection dbconn = new clsConnection();
            try
            {

                dbconn.openConnection();

                string strSQL = @"SELECT (SELECT NVL(SUM(QUANTITY),0) FROM REQUESTS WHERE STATUS='I' AND KEYID=KEYS.ID) AS ISSUEDQUANTITY,ID,QUANTITY FROM KEYS WHERE BUILDING=:BUILDING AND LEVELS=:LEVELS AND ROOM=:ROOM AND KEYTYPE=:KEYTYPE";

                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.BindByName = true;
                cmd.Parameters.Add("BUILDING", OracleDbType.Varchar2, model.buildingid, ParameterDirection.Input);
                cmd.Parameters.Add("LEVELS", OracleDbType.Varchar2, model.level, ParameterDirection.Input);
                cmd.Parameters.Add("ROOM", OracleDbType.Varchar2, model.room, ParameterDirection.Input);
                cmd.Parameters.Add("KEYTYPE", OracleDbType.Varchar2, model.keytype, ParameterDirection.Input);
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    model.quantity = dr["QUANTITY"].ToString();
                    model.remainingqty = (Convert.ToDouble(dr["QUANTITY"].ToString()) - Convert.ToDouble(dr["ISSUEDQUANTITY"].ToString())).ToString();
                    if (string.IsNullOrEmpty(model.remainingqty))
                    {
                        model.remainingqty = model.quantity;
                    }
                    model.id = dr["ID"].ToString();
                }
                else
                {
                    model.quantity = "0";
                    model.remainingqty = "0";

                }
                dr.Dispose();
                cmd.Dispose();



                dbconn.closeConnection();

                return model;
            }
            catch (Exception ex)
            {
                return model;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }

        [ActionName("getKeyMasterQuantity")]
        [HttpPost]
        public mdlKey getKeyMasterQuantity(mdlKey model)
        {
            clsConnection dbconn = new clsConnection();
            try
            {

                dbconn.openConnection();

                string strSQL = @"SELECT (SELECT NVL(SUM(QUANTITY),0) FROM REQUESTS WHERE STATUS='I' AND KEYID=KEYS.ID) AS ISSUEDQUANTITY,ID,QUANTITY FROM KEYS WHERE BUILDING=:BUILDING AND KEYTYPE=:KEYTYPE";

                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.BindByName = true;
                cmd.Parameters.Add("BUILDING", OracleDbType.Varchar2, model.buildingid, ParameterDirection.Input);
                cmd.Parameters.Add("KEYTYPE", OracleDbType.Varchar2, model.keytype, ParameterDirection.Input);
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    model.quantity = dr["QUANTITY"].ToString();
                    model.remainingqty = (Convert.ToDouble(dr["QUANTITY"].ToString()) - Convert.ToDouble(dr["ISSUEDQUANTITY"].ToString())).ToString();
                    if (string.IsNullOrEmpty(model.remainingqty))
                    {
                        model.remainingqty = model.quantity;
                    }
                    model.id = dr["ID"].ToString();
                }
                else
                {
                    model.quantity = "0";
                    model.remainingqty = "0";

                }
                dr.Dispose();
                cmd.Dispose();



                dbconn.closeConnection();

                return model;
            }
            catch (Exception ex)
            {
                return model;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }


        [ActionName("getLevels")]
        [HttpGet]
        public List<mdlLevel> getLevels()
        {
            DataSet ds = new DataSet();
            clsConnection dbconn = new clsConnection();
            List<mdlLevel> model = new List<mdlLevel>();
            try
            {

                dbconn.openConnection();


                string strSQL = @"SELECT A.ID,A.LEVELS,DECODE(ACTIVE,'A','Active','I','Inactive') AS ACTIVE, A.ID,B.BUILDINGCODE,BUILDINGNAME FROM LEVELS A
                INNER JOIN BUILDINGS B ON A.BUILDING=B.ID ORDER BY B.BUILDINGCODE,A.LEVELS";
                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                cmd.Dispose();
                da.Dispose();
                dbconn.closeConnection();

                model = (from DataRow dr in ds.Tables[0].Rows
                         select new mdlLevel()
                         {
                             id = dr["ID"].ToString(),
                             buildingcode = dr["BUILDINGCODE"].ToString(),
                             buildingname = dr["BUILDINGNAME"].ToString(),
                             level = dr["LEVELS"].ToString(),
                             active = dr["ACTIVE"].ToString(),
                         }).ToList();

                return model;
            }
            catch (Exception ex)
            {
                return model;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }



        [ActionName("rejectRequest")]
        [HttpGet]
        public void rejectRequest(string id)
        {
            clsConnection dbconn = new clsConnection();
            try
            {

                dbconn.openConnection();


                string strSQL = @"UPDATE REQUESTS SET STATUS='2',DATEREJECTED=SYSDATE,REJECTEDBY=:REJECTEDBY WHERE ID=:ID";

                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.Parameters.Add("REJECTEDBY", OracleDbType.Varchar2, "currentuser", ParameterDirection.Input);
                cmd.Parameters.Add("ID", OracleDbType.Varchar2, id, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                dbconn.closeConnection();

            }
            finally
            {
                dbconn.closeConnection();
            }
        }


        [ActionName("approveRequest")]
        [HttpGet]
        public void approveRequest(string id,string gid)
        {
            clsConnection dbconn = new clsConnection();
            string status="A";
            try
            {

                dbconn.openConnection();

                string strSQL = @"SELECT KEYTYPE,STATUS FROM REQUESTS
            INNER JOIN KEYS ON KEYS.ID = REQUESTS.KEYID WHERE REQUESTS.ID=:ID";

                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.Parameters.Add("ID", OracleDbType.Varchar2, id, ParameterDirection.Input);
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    if (dr["KEYTYPE"].ToString() == "Master" && dr["STATUS"].ToString() == "F")
                    {
                        status = "S";
                    }
                }
                cmd.Dispose();

                strSQL = @"UPDATE REQUESTS SET STATUS=:STATUS WHERE ID=:ID";

                cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.Parameters.Add("STATUS", OracleDbType.Varchar2, status, ParameterDirection.Input);
                cmd.Parameters.Add("ID", OracleDbType.Varchar2, id, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                dbconn.closeConnection();

                insertLogs(id, gid, status);

            }
            finally
            {
                dbconn.closeConnection();
            }
        }


        [ActionName("approveLostRequest")]
        [HttpGet]
        public void approveLostRequest(string id, string gid)
        {
            clsConnection dbconn = new clsConnection();
            string keyid = "";
            string quantity = "0";
            try
            {

                dbconn.openConnection();

                string strSQL = @"SELECT KEYID,QUANTITY FROM REQUESTS WHERE ID=:ID";

                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.Parameters.Add("ID", OracleDbType.Varchar2, id, ParameterDirection.Input);
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    keyid = dr["KEYID"].ToString();
                    quantity = dr["QUANTITY"].ToString();
                    cmd.Dispose();
                    strSQL = @"UPDATE LOSTKEYS SET KEYID=:KEYID,STATUS=:STATUS,QUANTITY=:QUANTITY WHERE REQNO=:REQNO";

                    cmd = new OracleCommand(strSQL, dbconn.DbConn);
                    cmd.Parameters.Add("KEYID", OracleDbType.Varchar2, keyid, ParameterDirection.Input);
                    cmd.Parameters.Add("STATUS", OracleDbType.Varchar2, 'A', ParameterDirection.Input);
                    cmd.Parameters.Add("QUANTITY", OracleDbType.Varchar2, quantity, ParameterDirection.Input);
                    cmd.Parameters.Add("REQNO", OracleDbType.Varchar2, id, ParameterDirection.Input);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    strSQL = @"UPDATE KEYS SET QUANTITY=QUANTITY-:QUANTITY  WHERE ID=:ID";

                    cmd = new OracleCommand(strSQL, dbconn.DbConn);
                    cmd.Parameters.Add("QUANTITY", OracleDbType.Varchar2, quantity, ParameterDirection.Input);
                    cmd.Parameters.Add("ID", OracleDbType.Varchar2, keyid, ParameterDirection.Input);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    strSQL = @"UPDATE REQUESTS SET STATUS='L'  WHERE ID=:ID";

                    cmd = new OracleCommand(strSQL, dbconn.DbConn);
                    cmd.Parameters.Add("ID", OracleDbType.Varchar2, id, ParameterDirection.Input);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();


                }
                cmd.Dispose();
                dbconn.closeConnection();
            }
            finally
            {
                dbconn.closeConnection();
            }
        }


        [ActionName("disapproveLostRequest")]
        [HttpGet]
        public void disapproveLostRequest(string id, string gid)
        {
            clsConnection dbconn = new clsConnection();
            string keyid = "";
            string quantity = "0";
            try
            {

                dbconn.openConnection();

                string strSQL = @"SELECT KEYID,QUANTITY FROM REQUESTS WHERE ID=:ID";

                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.Parameters.Add("ID", OracleDbType.Varchar2, id, ParameterDirection.Input);
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    keyid = dr["KEYID"].ToString();
                    quantity = dr["QUANTITY"].ToString();
                    cmd.Dispose();
                    strSQL = @"UPDATE LOSTKEYS SET KEYID=:KEYID,STATUS=:STATUS WHERE REQNO=:REQNO";

                    cmd = new OracleCommand(strSQL, dbconn.DbConn);
                    cmd.Parameters.Add("KEYID", OracleDbType.Varchar2, keyid, ParameterDirection.Input);
                    cmd.Parameters.Add("STATUS", OracleDbType.Varchar2, 'D', ParameterDirection.Input);
                    cmd.Parameters.Add("REQNO", OracleDbType.Varchar2, id, ParameterDirection.Input);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    

                }
                cmd.Dispose();
                dbconn.closeConnection();
            }
            finally
            {
                dbconn.closeConnection();
            }
        }

        [ActionName("disapproveRequest")]
        [HttpGet]
        public void disapproveRequest(string id, string gid)
        {
            clsConnection dbconn = new clsConnection();
            try
            {

                dbconn.openConnection();


                string strSQL = @"UPDATE REQUESTS SET STATUS='D' WHERE ID=:ID";

                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.Parameters.Add("ID", OracleDbType.Varchar2, id, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                dbconn.closeConnection();

                insertLogs(id, gid, "D");

            }
            finally
            {
                dbconn.closeConnection();
            }
        }

        private void insertLogs(string reqno,string username, string status)
        {
            clsConnection dbconn = new clsConnection();
            try
            {

                dbconn.openConnection();
                

                string strSQL = @"INSERT INTO LOGS(ID,USERNAME,STATUS,REQNO)
                VALUES((SELECT NVL(MAX(ID),0)+1 FROM LOGS),:USERNAME,:STATUS,:REQNO)";

                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.Parameters.Add("USERNAME", OracleDbType.Varchar2, username, ParameterDirection.Input);
                cmd.Parameters.Add("STATUS", OracleDbType.Varchar2, status, ParameterDirection.Input);
                cmd.Parameters.Add("REQNO", OracleDbType.Varchar2, reqno, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                dbconn.closeConnection();

            }
            finally
            {
                dbconn.closeConnection();
            }
        }

        [ActionName("returnKey")]
        [HttpGet]
        public void returnKey(string id,string gid)
        {
            clsConnection dbconn = new clsConnection();
            try
            {

                dbconn.openConnection();


                string strSQL = @"UPDATE REQUESTS SET STATUS='R'WHERE ID=:ID";

                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.Parameters.Add("ID", OracleDbType.Varchar2, id, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                dbconn.closeConnection();

                insertLogs(id, gid, "R");

            }
            finally
            {
                dbconn.closeConnection();
            }
        }

        [ActionName("lostKey")]
        [HttpGet]
        public string lostKey(string id, string gid)
        {
            clsConnection dbconn = new clsConnection();
            string result = "";
            try
            {

                dbconn.openConnection();
                string strSQL = @"SELECT ID FROM LOSTKEYS WHERE REQNO=:REQNO AND STATUS='F'";

                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.Parameters.Add("REQNO", OracleDbType.Varchar2, id, ParameterDirection.Input);
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    result = "Key already declared lost and its waiting for approval";

                }
                else
                {
                    dr.Dispose();
                    cmd.Dispose();

                    strSQL = @"INSERT INTO LOSTKEYS(ID,REQNO,ENCODEDBY,STATUS)
                    VALUES((SELECT NVL(MAX(ID),0)+1 FROM LOSTKEYS),:REQNO,:ENCODEDBY,:STATUS)";

                    cmd = new OracleCommand(strSQL, dbconn.DbConn);
                    cmd.Parameters.Add("REQNO", OracleDbType.Varchar2, id, ParameterDirection.Input);
                    cmd.Parameters.Add("ENCODEDBY", OracleDbType.Varchar2, gid, ParameterDirection.Input);
                    cmd.Parameters.Add("STATUS", OracleDbType.Varchar2, "F", ParameterDirection.Input);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    result = "Key successfully declared as lost and its waiting for approval";
                }
                cmd.Dispose();
                dbconn.closeConnection();

                return result;


            }
            finally
            {
                dbconn.closeConnection();
            }
        }

        [ActionName("getLevelsByBuilding")]
        [HttpGet]
        public List<mdlLevel> getLevelsByBuilding(string id)
        {
            DataSet ds = new DataSet();
            clsConnection dbconn = new clsConnection();
            List<mdlLevel> model = new List<mdlLevel>();
            try
            {

                dbconn.openConnection();


                string strSQL = @"SELECT ID,LEVELS FROM LEVELS WHERE ACTIVE='A' AND BUILDING=:BUILDING ORDER BY LEVELS";
                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.Parameters.Add("BUILDING", OracleDbType.Varchar2, id, ParameterDirection.Input);
                OracleDataAdapter da = new OracleDataAdapter(cmd);

                da.Fill(ds);
                cmd.Dispose();
                da.Dispose();
                dbconn.closeConnection();

                model = (from DataRow dr in ds.Tables[0].Rows
                         select new mdlLevel()
                         {
                             id = dr["ID"].ToString(),
                             level = dr["LEVELS"].ToString(),
                         }).ToList();

                return model;
            }
            catch (Exception ex)
            {
                return model;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }

        [ActionName("getBuildings")]
        [HttpGet]
        public List<mdlBuilding> getBuildings()
        {
            DataSet ds = new DataSet();
            clsConnection dbconn = new clsConnection();
            List<mdlBuilding> model = new List<mdlBuilding>();
            try
            {

                dbconn.openConnection();


                string strSQL = "SELECT ID,BUILDINGCODE,BUILDINGNAME FROM BUILDINGS ORDER BY  BUILDINGCODE ASC";
                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                cmd.Dispose();
                da.Dispose();
                dbconn.closeConnection();

                model = (from DataRow dr in ds.Tables[0].Rows
                         select new mdlBuilding()
                         {
                             id = dr["ID"].ToString(),
                             buildingcode = dr["BUILDINGCODE"].ToString(),
                             buildingname = dr["BUILDINGNAME"].ToString(),
                         }).ToList();

                return model;
            }
            catch (Exception ex)
            {
                return model;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }

        [ActionName("getKeys")]
        [HttpGet]
        public List<mdlKey> getKeys(string id,string gid)
        {
            DataSet ds = new DataSet();
            clsConnection dbconn = new clsConnection();
            List<mdlKey> model = new List<mdlKey>();
            try
            {

                dbconn.openConnection();


                string strSQL = @"SELECT (SELECT NVL(SUM(QUANTITY),0) FROM REQUESTS WHERE STATUS='I' AND KEYID=A.ID) AS ISSUEDQUANTITY , A.ID,B.BUILDINGCODE,BUILDINGNAME,D.LEVELS,C.ROOM,A.KEYTYPE,A.QUANTITY FROM KEYS A
                INNER JOIN BUILDINGS B ON A.BUILDING=B.ID
                LEFT JOIN ROOMS C ON A.ROOM=C.ID
                LEFT JOIN LEVELS D ON D.ID=A.LEVELS ";
                string strwhere="";
                if (!string.IsNullOrEmpty(id))
                {
                    strwhere = strwhere + " B.ID=:BUILDINGID AND ";
                }
                if (!string.IsNullOrEmpty(gid))
                {
                    strwhere = strwhere + " D.ID=:LEVELID AND ";
                }
                
                if (strwhere != "")
                {
                    strSQL = strSQL + " WHERE " + strwhere.Substring(0, strwhere.Length - 4) ;
                    if (!string.IsNullOrEmpty(id))
                    {
                        strSQL = strSQL + @" UNION ALL SELECT (SELECT NVL(SUM(QUANTITY),0) FROM REQUESTS WHERE STATUS='I' AND KEYID=A.ID) AS ISSUEDQUANTITY , A.ID,B.BUILDINGCODE,BUILDINGNAME,D.LEVELS,C.ROOM,A.KEYTYPE,A.QUANTITY FROM KEYS A
                    INNER JOIN BUILDINGS B ON A.BUILDING=B.ID
                    LEFT JOIN ROOMS C ON A.ROOM=C.ID
                    LEFT JOIN LEVELS D ON D.ID=A.LEVELS WHERE B.ID=:BUILDINGID AND KEYTYPE='Master'";
                    }

                   
                }

                strSQL = "SELECT * FROM (" + strSQL + ") ORDER BY DECODE(KEYTYPE,'Master',0,'Regular',1),ROOM ASC";


                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                if (!string.IsNullOrEmpty(id))
                {
                    cmd.Parameters.Add("BUILDINGID", OracleDbType.Varchar2, id, ParameterDirection.Input);
                }
                if (!string.IsNullOrEmpty(gid))
                {
                    cmd.Parameters.Add("LEVELID", OracleDbType.Varchar2, gid, ParameterDirection.Input);

                }
                /*
                if (strwhere != "")
                {
                    strSQL = strSQL + strwhere.Substring(0, strwhere.Length - 4);
                }*/
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                cmd.Dispose();
                da.Dispose();
                dbconn.closeConnection();

                model = (from DataRow dr in ds.Tables[0].Rows
                         select new mdlKey()
                         {
                             id = dr["ID"].ToString(),
                             buildingcode = dr["BUILDINGCODE"].ToString(),
                             buildingname = dr["BUILDINGNAME"].ToString(),
                             level = dr["LEVELS"].ToString(),
                             issuedqty=dr["ISSUEDQUANTITY"].ToString(),
                            remainingqty =(Convert.ToDouble(dr["quantity"].ToString())- Convert.ToDouble( dr["ISSUEDQUANTITY"].ToString())).ToString(),
                             room = dr["ROOM"].ToString(),
                             keytype = dr["KEYTYPE"].ToString(),
                             quantity = dr["QUANTITY"].ToString(),
                         }).ToList();

                return model;
            }
            catch (Exception ex)
            {
                return model;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }

        [ActionName("getRooms")]
        [HttpGet]
        public List<mdlRoom> getRooms()
        {
            DataSet ds = new DataSet();
            clsConnection dbconn = new clsConnection();
            List<mdlRoom> model = new List<mdlRoom>();
            try
            {

                dbconn.openConnection();


                string strSQL = @"SELECT A.ID,A.BUILDINGID,B.BUILDINGCODE,B.BUILDINGNAME,C.LEVELS,A.ROOM,DECODE(A.ACTIVE,'A','Active','I','Inactive') as ACTIVE FROM ROOMS A
                INNER JOIN BUILDINGS B ON A.BUILDINGID=B.ID
                INNER JOIN LEVELS C ON C.ID=A.LEVELS ORDER BY B.BUILDINGCODE ASC";
                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                cmd.Dispose();
                da.Dispose();
                dbconn.closeConnection();

                model = (from DataRow dr in ds.Tables[0].Rows
                         select new mdlRoom()
                         {
                             id = dr["ID"].ToString(),
                             buildingcode = dr["BUILDINGCODE"].ToString(),
                             buildingname = dr["BUILDINGNAME"].ToString(),
                             level = dr["LEVELS"].ToString(),
                             room = dr["ROOM"].ToString(),
                             active = dr["ACTIVE"].ToString(),
                         }).ToList();

                return model;
            }
            catch (Exception ex)
            {
                return model;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }

        [ActionName("getBuildingRooms")]
        [HttpGet]
        public List<mdlRoom> getBuildingRooms(string id, string gid)
        {
            DataSet ds = new DataSet();
            clsConnection dbconn = new clsConnection();
            List<mdlRoom> model = new List<mdlRoom>();
            try
            {

                dbconn.openConnection();


                string strSQL = @"SELECT ID,ROOM FROM ROOMS WHERE ACTIVE='A' AND BUILDINGID=:BUILDINGID AND LEVELS=:LEVELS ORDER BY ROOM ASC";
                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.Parameters.Add("BUILDINGID", OracleDbType.Varchar2, id, ParameterDirection.Input);
                cmd.Parameters.Add("LEVELS", OracleDbType.Varchar2, gid, ParameterDirection.Input);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                cmd.Dispose();
                da.Dispose();
                dbconn.closeConnection();

                model = (from DataRow dr in ds.Tables[0].Rows
                         select new mdlRoom()
                         {
                             id = dr["ID"].ToString(),
                             room = dr["ROOM"].ToString(),
                         }).ToList();

                return model;
            }
            catch (Exception ex)
            {
                return model;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }


        [ActionName("getAllKeyRequests")]
        [HttpPost]
        public List<mdlRequest> getAllKeyRequests( mdlRequest search)
        {
            DataSet ds = new DataSet();
            clsConnection dbconn = new clsConnection();
            List<mdlRequest> model = new List<mdlRequest>();
            try
            {

                dbconn.openConnection();


                string strSQL = @"SELECT * FROM (SELECT D.ID AS BUILDINGID,E.ID AS LEVELID,C.ID AS ROOMID,A.ISSUANCETYPE,CASE WHEN A.ISSUANCETYPE='Temporary' then TO_CHAR(RETURNDATE,'DD-Mon-YYYY') else '' end AS RETURNDATE,A.ID,DATEREQUESTED,B.ID AS KEYID,A.QUANTITY,EMPLOYEENO,EMPLOYEENAME,SECTION,
                    EXTENSION,NOTES,B.KEYTYPE,C.ROOM,E.LEVELS,D.BUILDINGCODE,D.BUILDINGNAME,F.STATUS,A.STATUS AS STATUSID
                    FROM REQUESTS A
                    INNER JOIN KEYS B ON A.KEYID=B.ID
                    LEFT JOIN ROOMS C ON C.ID=B.ROOM
                    INNER JOIN BUILDINGS D ON D.ID=B.BUILDING 
                    LEFT JOIN LEVELS E ON E.ID= B.LEVELS
                    INNER JOIN TRANSTATUS F ON F.ID=A.STATUS) ";

                string strWhere="";

                if (!string.IsNullOrEmpty(search.status))
                {
                    strWhere = strWhere + "STATUSID=:STATUSID AND ";
                }

                if (!string.IsNullOrEmpty(search.employeeno))
                {
                    strWhere = strWhere + "EMPLOYEENO=:EMPLOYEENO AND ";
                }

                if (!string.IsNullOrEmpty(search.buildingid))
                {
                    strWhere = strWhere + "BUILDINGID=:BUILDINGID AND ";
                }
                if (!string.IsNullOrEmpty(search.level))
                {
                    strWhere = strWhere + "LEVELID=:LEVELID AND ";
                }
                if (!string.IsNullOrEmpty(search.room))
                {
                    strWhere = strWhere + "ROOMID=:ROOMID AND ";
                }
                if (strWhere != "")
                {
                    strSQL = strSQL + " WHERE " + strWhere.Substring(0,strWhere.Length - 4) ;
                }

                //strSQL = strSQL +  " ORDER BY ID ASC";

               
                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                if (!string.IsNullOrEmpty(search.status))
                {
                    cmd.Parameters.Add("STATUSID", OracleDbType.Varchar2, search.status, ParameterDirection.Input);
                }
                if (!string.IsNullOrEmpty(search.employeeno))
                {
                    cmd.Parameters.Add("EMPLOYEENO", OracleDbType.Varchar2, search.employeeno, ParameterDirection.Input);
                }

                if (!string.IsNullOrEmpty(search.buildingid))
                {
                    cmd.Parameters.Add("BUILDINGID", OracleDbType.Varchar2, search.buildingid, ParameterDirection.Input);
                }
                if (!string.IsNullOrEmpty(search.level))
                {
                    cmd.Parameters.Add("LEVELID", OracleDbType.Varchar2, search.level, ParameterDirection.Input);
                }
                if (!string.IsNullOrEmpty(search.room))
                {
                    cmd.Parameters.Add("ROOMID", OracleDbType.Varchar2, search.room, ParameterDirection.Input);
                }
               
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                cmd.Dispose();
                da.Dispose();
                dbconn.closeConnection();

                model = (from DataRow dr in ds.Tables[0].Rows
                         select new mdlRequest()
                         {
                             id = dr["ID"].ToString(),
                             daterequested = Convert.ToDateTime(dr["DATEREQUESTED"].ToString()).ToString("dd-MMM-yyyy"),
                             employeeno = dr["EMPLOYEENO"].ToString(),
                             employeename =  dr["EMPLOYEENAME"].ToString(),
                             section = dr["SECTION"].ToString(),
                             extension = dr["EXTENSION"].ToString(),
                             statusid = dr["STATUSID"].ToString(),
                             status = dr["STATUS"].ToString(),
                             keycode = dr["BUILDINGCODE"].ToString() + "-" + dr["ROOM"].ToString(),
                             notes = dr["NOTES"].ToString(),
                             keytype = dr["KEYTYPE"].ToString(),
                             issuancetype = dr["ISSUANCETYPE"].ToString(),
                             returndate = dr["RETURNDATE"].ToString(),
                             room = dr["ROOM"].ToString(),
                             requestquantity = dr["QUANTITY"].ToString(),
                             keyid = dr["KEYID"].ToString(),
                             level = dr["LEVELS"].ToString(),
                             building = dr["BUILDINGCODE"].ToString() + "-" + dr["BUILDINGNAME"].ToString(),
                         }).ToList();

                return model;
            }
            catch (Exception ex)
            {
                return model;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }


        [ActionName("getAllKeys")]
        [HttpPost]
        public List<mdlKey> getAllKeys(mdlRequest search)
        {
            DataSet ds = new DataSet();
            clsConnection dbconn = new clsConnection();
            List<mdlKey> model = new List<mdlKey>();
            try
            {

                dbconn.openConnection();


                string strSQL = @"SELECT * FROM (SELECT C.ID AS LEVELID, D.ID AS ROOMID,B.ID AS BUILDINGID,B.BUILDINGCODE,B.BUILDINGNAME,C.LEVELS,D.ROOM,A.QUANTITY,A.KEYTYPE,
                (SELECT NVL(SUM(QUANTITY),0) FROM REQUESTS WHERE STATUS='I' AND KEYID=A.ID) AS ISSUEDQUANTITY,
                CASE WHEN NVL(A.KEYTYPE,'')='Master' THEN '' ELSE BUILDINGCODE||'-'||D.ROOM END AS KEYID FROM KEYS A
                INNER JOIN BUILDINGS B ON B.ID=A.BUILDING
                LEFT JOIN LEVELS C ON C.ID=A.LEVELS
                LEFT JOIN ROOMS D ON D.ID=A.ROOM) ";

                string strWhere = "";
                if (!string.IsNullOrEmpty(search.buildingid))
                {
                    strWhere = strWhere + "BUILDINGID=:BUILDINGID AND ";
                }
                if (!string.IsNullOrEmpty(search.level))
                {
                    strWhere = strWhere + "LEVELID=:LEVELID AND ";
                }
                if (!string.IsNullOrEmpty(search.room))
                {
                    strWhere = strWhere + "ROOMID=:ROOMID AND ";
                }
                if (strWhere != "")
                {
                    strSQL = strSQL + " WHERE " + strWhere.Substring(0, strWhere.Length - 4);
                }

                //strSQL = strSQL +  " ORDER BY ID ASC";


                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);

                if (!string.IsNullOrEmpty(search.buildingid))
                {
                    cmd.Parameters.Add("BUILDINGID", OracleDbType.Varchar2, search.buildingid, ParameterDirection.Input);
                }
                if (!string.IsNullOrEmpty(search.level))
                {
                    cmd.Parameters.Add("LEVELID", OracleDbType.Varchar2, search.level, ParameterDirection.Input);
                }
                if (!string.IsNullOrEmpty(search.room))
                {
                    cmd.Parameters.Add("ROOMID", OracleDbType.Varchar2, search.room, ParameterDirection.Input);
                }

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                cmd.Dispose();
                da.Dispose();
                dbconn.closeConnection();
                model = (from DataRow dr in ds.Tables[0].Rows
                    
                         select new mdlKey()
                         {
                             buildingname = dr["buildingname"].ToString(),
                             room = dr["room"].ToString(),
                             level = dr["levels"].ToString(),
                             quantity = dr["quantity"].ToString(),
                             keytype = dr["KEYTYPE"].ToString(),
                             issuedqty = dr["ISSUEDQUANTITY"].ToString(),
                             remainingqty =(Convert.ToDouble(dr["quantity"].ToString())- Convert.ToDouble( dr["ISSUEDQUANTITY"].ToString())).ToString(),
                             id = dr["KEYID"].ToString(),
                         }).ToList();

                return model;
            }
            catch (Exception ex)
            {
                return model;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }

         [ActionName("getPendingKeyRequests")]
        [HttpGet]
        public List<mdlRequest> getPendingKeyRequests()
        {
            DataSet ds = new DataSet();
            clsConnection dbconn = new clsConnection();
            List<mdlRequest> model = new List<mdlRequest>();
            try
            {

                dbconn.openConnection();


                string strSQL = @"SELECT A.ID,DATEREQUESTED,B.ID AS KEYID,A.QUANTITY,EMPLOYEENO,EMPLOYEENAME,SECTION,EXTENSION,NOTES,B.KEYTYPE,C.ROOM,E.LEVELS,D.BUILDINGCODE,D.BUILDINGNAME,F.STATUS,
                    CASE WHEN NVL(B.KEYTYPE,'')='Master' THEN BUILDINGNAME ELSE BUILDINGCODE||'-'|| C.ROOM END AS KEY 
                    FROM REQUESTS A
                    INNER JOIN KEYS B ON A.KEYID=B.ID
                    LEFT JOIN ROOMS C ON C.ID=B.ROOM
                    INNER JOIN BUILDINGS D ON D.ID=B.BUILDING 
                    LEFT JOIN LEVELS E ON E.ID= B.LEVELS
                    INNER JOIN TRANSTATUS F ON F.ID=A.STATUS
                    WHERE A.STATUS='A'
                    ORDER BY A.ID ASC";
                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                cmd.Dispose();
                da.Dispose();
                dbconn.closeConnection();

                model = (from DataRow dr in ds.Tables[0].Rows
                         select new mdlRequest()
                         {
                             id = dr["ID"].ToString(),
                             daterequested = Convert.ToDateTime(dr["DATEREQUESTED"].ToString()).ToString("dd-MMM-yyyy"),
                             employeeno = dr["EMPLOYEENO"].ToString(),
                             employeename =  dr["EMPLOYEENAME"].ToString(),
                             section = dr["SECTION"].ToString(),
                             extension = dr["EXTENSION"].ToString(),
                             notes = dr["NOTES"].ToString(),
                             keytype = dr["KEYTYPE"].ToString(),
                             room = dr["ROOM"].ToString(),
                             code = dr["KEY"].ToString(),
                             status=dr["STATUS"].ToString(),
                             requestquantity = dr["QUANTITY"].ToString(),
                             keyid = dr["KEYID"].ToString(),
                             level = dr["LEVELS"].ToString(),
                             building = dr["BUILDINGCODE"].ToString() + "-" + dr["BUILDINGNAME"].ToString(),
                         }).ToList();

                return model;
            }
            catch (Exception ex)
            {
                return model;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }

         [ActionName("getForApprovalKeyRequests")]
         [HttpGet]
         public List<mdlRequest> getForApprovalKeyRequests()
         {
             DataSet ds = new DataSet();
             clsConnection dbconn = new clsConnection();
             List<mdlRequest> model = new List<mdlRequest>();
             try
             {

                 dbconn.openConnection();


                 string strSQL = @"SELECT A.ID,DATEREQUESTED,B.ID AS KEYID,A.QUANTITY,EMPLOYEENO,EMPLOYEENAME,SECTION,EXTENSION,NOTES,B.KEYTYPE,C.ROOM,E.LEVELS,D.BUILDINGCODE,D.BUILDINGNAME,F.STATUS,
                    CASE WHEN NVL(B.KEYTYPE,'')='Master' THEN BUILDINGNAME ELSE BUILDINGCODE||'-'|| C.ROOM END AS KEY 
                    FROM REQUESTS A
                    INNER JOIN KEYS B ON A.KEYID=B.ID
                    LEFT JOIN ROOMS C ON C.ID=B.ROOM
                    INNER JOIN BUILDINGS D ON D.ID=B.BUILDING 
                    LEFT JOIN LEVELS E ON E.ID= B.LEVELS
                    INNER JOIN TRANSTATUS F ON F.ID=A.STATUS
                    WHERE A.STATUS='F'
                    ORDER BY A.ID ASC";
                 OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                 OracleDataAdapter da = new OracleDataAdapter(cmd);
                 da.Fill(ds);
                 cmd.Dispose();
                 da.Dispose();
                 dbconn.closeConnection();

                 model = (from DataRow dr in ds.Tables[0].Rows
                          select new mdlRequest()
                          {
                              id = dr["ID"].ToString(),
                              daterequested = Convert.ToDateTime(dr["DATEREQUESTED"].ToString()).ToString("dd-MMM-yyyy"),
                              employeeno = dr["EMPLOYEENO"].ToString(),
                              employeename = dr["EMPLOYEENAME"].ToString(),
                              section = dr["SECTION"].ToString(),
                              extension = dr["EXTENSION"].ToString(),
                              notes = dr["NOTES"].ToString(),
                              status = dr["STATUS"].ToString(),
                              keytype = dr["KEYTYPE"].ToString(),
                              code = dr["KEY"].ToString(),
                              room = dr["ROOM"].ToString(),
                              requestquantity = dr["QUANTITY"].ToString(),
                              keyid = dr["KEYID"].ToString(),
                              level = dr["LEVELS"].ToString(),
                              building = dr["BUILDINGCODE"].ToString() + "-" + dr["BUILDINGNAME"].ToString(),
                          }).ToList();

                 return model;
             }
             catch (Exception ex)
             {
                 return model;

             }
             finally
             {
                 dbconn.closeConnection();
             }
         }

         [ActionName("getForApprovalMasterKeyRequests")]
         [HttpGet]
         public List<mdlRequest> getForApprovalMasterKeyRequests()
         {
             DataSet ds = new DataSet();
             clsConnection dbconn = new clsConnection();
             List<mdlRequest> model = new List<mdlRequest>();
             try
             {

                 dbconn.openConnection();


                 string strSQL = @"SELECT A.ID,DATEREQUESTED,B.ID AS KEYID,A.QUANTITY,EMPLOYEENO,EMPLOYEENAME,SECTION,EXTENSION,NOTES,B.KEYTYPE,C.ROOM,E.LEVELS,D.BUILDINGCODE,D.BUILDINGNAME,F.STATUS,
                    CASE WHEN NVL(B.KEYTYPE,'')='Master' THEN BUILDINGNAME ELSE BUILDINGCODE||'-'|| C.ROOM END AS KEY 
                    FROM REQUESTS A
                    INNER JOIN KEYS B ON A.KEYID=B.ID
                    LEFT JOIN ROOMS C ON C.ID=B.ROOM
                    INNER JOIN BUILDINGS D ON D.ID=B.BUILDING 
                    LEFT JOIN LEVELS E ON E.ID= B.LEVELS
                    INNER JOIN TRANSTATUS F ON F.ID=A.STATUS
                    WHERE A.STATUS='S'
                    ORDER BY A.ID ASC";
                 OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                 OracleDataAdapter da = new OracleDataAdapter(cmd);
                 da.Fill(ds);
                 cmd.Dispose();
                 da.Dispose();
                 dbconn.closeConnection();

                 model = (from DataRow dr in ds.Tables[0].Rows
                          select new mdlRequest()
                          {
                              id = dr["ID"].ToString(),
                              daterequested = Convert.ToDateTime(dr["DATEREQUESTED"].ToString()).ToString("dd-MMM-yyyy"),
                              employeeno = dr["EMPLOYEENO"].ToString(),
                              employeename = dr["EMPLOYEENAME"].ToString(),
                              section = dr["SECTION"].ToString(),
                              extension = dr["EXTENSION"].ToString(),
                              notes = dr["NOTES"].ToString(),
                              status = dr["STATUS"].ToString(),
                              keytype = dr["KEYTYPE"].ToString(),
                              code = dr["KEY"].ToString(),
                              room = dr["ROOM"].ToString(),
                              requestquantity = dr["QUANTITY"].ToString(),
                              keyid = dr["KEYID"].ToString(),
                              level = dr["LEVELS"].ToString(),
                              building = dr["BUILDINGCODE"].ToString() + "-" + dr["BUILDINGNAME"].ToString(),
                          }).ToList();

                 return model;
             }
             catch (Exception ex)
             {
                 return model;

             }
             finally
             {
                 dbconn.closeConnection();
             }
         }


         [ActionName("getForApprovalLostKeyRequests")]
         [HttpGet]
         public List<mdlRequest> getForApprovalLostKeyRequests()
         {
             DataSet ds = new DataSet();
             clsConnection dbconn = new clsConnection();
             List<mdlRequest> model = new List<mdlRequest>();
             try
             {

                 dbconn.openConnection();


                 string strSQL = @"SELECT DATEENCODED,REQNO,B.EMPLOYEENO,B.EMPLOYEENAME,B.QUANTITY,
                F.KEYTYPE,C.ROOM,E.LEVELS,D.BUILDINGCODE,D.BUILDINGNAME FROM LOSTKEYS A
                INNER JOIN REQUESTS B ON B.ID=A.REQNO
                INNER JOIN KEYS F ON F.ID=B.KEYID
                LEFT JOIN ROOMS C ON C.ID=F.ROOM
                INNER JOIN BUILDINGS D ON D.ID=F.BUILDING 
                LEFT JOIN LEVELS E ON E.ID= F.LEVELS
                WHERE A.STATUS='F'";
                 OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                 OracleDataAdapter da = new OracleDataAdapter(cmd);
                 da.Fill(ds);
                 cmd.Dispose();
                 da.Dispose();
                 dbconn.closeConnection();

                 model = (from DataRow dr in ds.Tables[0].Rows
                          select new mdlRequest()
                          {
                              id = dr["REQNO"].ToString(),
                              daterequested = Convert.ToDateTime(dr["DATEENCODED"].ToString()).ToString("dd-MMM-yyyy"),
                              employeeno = dr["EMPLOYEENO"].ToString(),
                              employeename = dr["EMPLOYEENAME"].ToString(),
                              keytype = dr["KEYTYPE"].ToString(),
                              room = dr["ROOM"].ToString(),
                              requestquantity = dr["QUANTITY"].ToString(),
                              level = dr["LEVELS"].ToString(),
                              building = dr["BUILDINGCODE"].ToString() + "-" + dr["BUILDINGNAME"].ToString(),
                          }).ToList();

                 return model;
             }
             catch (Exception ex)
             {
                 return model;

             }
             finally
             {
                 dbconn.closeConnection();
             }
         }


         [ActionName("getLostKeys")]
         [HttpGet]
         public List<mdlRequest> getLostKeys()
         {
             DataSet ds = new DataSet();
             clsConnection dbconn = new clsConnection();
             List<mdlRequest> model = new List<mdlRequest>();
             try
             {

                 dbconn.openConnection();


                 string strSQL = @"SELECT DATEENCODED,REQNO,B.EMPLOYEENO,B.EMPLOYEENAME,B.QUANTITY,
                F.KEYTYPE,C.ROOM,E.LEVELS,D.BUILDINGCODE,D.BUILDINGNAME FROM LOSTKEYS A
                INNER JOIN REQUESTS B ON B.ID=A.REQNO
                INNER JOIN KEYS F ON F.ID=B.KEYID
                LEFT JOIN ROOMS C ON C.ID=F.ROOM
                INNER JOIN BUILDINGS D ON D.ID=F.BUILDING 
                LEFT JOIN LEVELS E ON E.ID= F.LEVELS
                WHERE A.STATUS='A'";
                 OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                 OracleDataAdapter da = new OracleDataAdapter(cmd);
                 da.Fill(ds);
                 cmd.Dispose();
                 da.Dispose();
                 dbconn.closeConnection();

                 model = (from DataRow dr in ds.Tables[0].Rows
                          select new mdlRequest()
                          {
                              id = dr["REQNO"].ToString(),
                              daterequested = Convert.ToDateTime(dr["DATEENCODED"].ToString()).ToString("dd-MMM-yyyy"),
                              employeeno = dr["EMPLOYEENO"].ToString(),
                              employeename = dr["EMPLOYEENAME"].ToString(),
                              keytype = dr["KEYTYPE"].ToString(),
                              room = dr["ROOM"].ToString(),
                              requestquantity = dr["QUANTITY"].ToString(),
                              level = dr["LEVELS"].ToString(),
                              building = dr["BUILDINGCODE"].ToString() + "-" + dr["BUILDINGNAME"].ToString(),
                          }).ToList();

                 return model;
             }
             catch (Exception ex)
             {
                 return model;

             }
             finally
             {
                 dbconn.closeConnection();
             }
         }

        [ActionName("getBuildingInfo")]
        [HttpGet]
        public mdlBuilding getBuildingInfo(string id)
        {
            DataSet ds = new DataSet();
            clsConnection dbconn = new clsConnection();
            mdlBuilding model = new mdlBuilding();
            try
            {

                dbconn.openConnection();


                string strSQL = "SELECT ID,BUILDINGCODE,BUILDINGNAME FROM BUILDINGS WHERE ID=:ID";
                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.BindByName = true;
                cmd.Parameters.Add("ID", OracleDbType.Varchar2, id, ParameterDirection.Input);
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    model.id = id;
                    model.buildingcode = dr["buildingcode"].ToString();
                    model.buildingname = dr["buildingname"].ToString();

                }
                dr.Dispose();
                cmd.Dispose();
                dbconn.closeConnection();

                return model;
            }
            catch (Exception ex)
            {
                return model;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }


        [ActionName("getDashboard")]
        [HttpGet]
        public mdlDashboard getDashboard()
        {
            DataSet ds = new DataSet();
            clsConnection dbconn = new clsConnection();
            mdlDashboard model = new mdlDashboard();
            try
            {

                dbconn.openConnection();


                string strSQL = @"SELECT 
                (SELECT COUNT(ID) FROM REQUESTS WHERE STATUS='F') AS NEWREQUEST,
                (SELECT COUNT(ID) FROM REQUESTS WHERE STATUS='S') AS SECTIONHEADAPP,
                (SELECT COUNT(ID) FROM REQUESTS WHERE STATUS='A') AS PENDINGREQUEST FROM DUAL";
                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.BindByName = true;
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    model.newrequest = dr["NEWREQUEST"].ToString();
                    model.pendingrequest = dr["PENDINGREQUEST"].ToString();
                    model.supervisor = dr["NEWREQUEST"].ToString();
                    model.sectionhead = dr["SECTIONHEADAPP"].ToString();

                }
                dr.Dispose();
                cmd.Dispose();
                dbconn.closeConnection();

                return model;
            }
            catch (Exception ex)
            {
                return model;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }


        [ActionName("getLevelInfo")]
        [HttpGet]
        public mdlLevel getLevelInfo(string id)
        {
            DataSet ds = new DataSet();
            clsConnection dbconn = new clsConnection();
            mdlLevel model = new mdlLevel();
            try
            {

                dbconn.openConnection();


                string strSQL = @"SELECT A.ID,A.LEVELS,ACTIVE,A.BUILDING, A.ID,B.BUILDINGCODE,BUILDINGNAME FROM LEVELS A
                INNER JOIN BUILDINGS B ON A.BUILDING=B.ID WHERE A.ID=:ID";
                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.BindByName = true;
                cmd.Parameters.Add("ID", OracleDbType.Varchar2, id, ParameterDirection.Input);
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    model.id = id;
                    model.buildingcode = dr["buildingcode"].ToString();
                    model.building = dr["BUILDING"].ToString();
                    model.buildingname = dr["buildingname"].ToString();
                    model.level = dr["levels"].ToString();
                    model.active = dr["active"].ToString();

                }
                dr.Dispose();
                cmd.Dispose();
                dbconn.closeConnection();

                return model;
            }
            catch (Exception ex)
            {
                return model;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }


        [ActionName("getRoomInfo")]
        [HttpGet]
        public mdlRoom getRoomInfo(string id)
        {
            DataSet ds = new DataSet();
            clsConnection dbconn = new clsConnection();
            mdlRoom model = new mdlRoom();
            try
            {

                dbconn.openConnection();


                string strSQL = @"SELECT A.ID,A.BUILDINGID,B.BUILDINGCODE,B.BUILDINGNAME,A.LEVELS,A.ROOM,A.ACTIVE FROM ROOMS A
                 INNER JOIN BUILDINGS B ON A.BUILDINGID=B.ID WHERE A.ID=:ID";
                OracleCommand cmd = new OracleCommand(strSQL, dbconn.DbConn);
                cmd.BindByName = true;
                cmd.Parameters.Add("ID", OracleDbType.Varchar2, id, ParameterDirection.Input);
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    model.id = id;
                    model.buildingcode = dr["buildingcode"].ToString();
                    model.buildingname = dr["buildingname"].ToString();
                    model.buildingid = dr["BUILDINGID"].ToString();
                    model.level = dr["levels"].ToString();
                    model.room = dr["room"].ToString();
                    model.active = dr["ACTIVE"].ToString();


                }
                dr.Dispose();
                cmd.Dispose();
                dbconn.closeConnection();

                return model;
            }
            catch (Exception ex)
            {
                return model;

            }
            finally
            {
                dbconn.closeConnection();
            }
        }


    }
}
