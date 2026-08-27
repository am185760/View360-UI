using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading;
using Avanza.iSuite.DAL;
using System.Data.SqlClient;

namespace Avanza.CCMS.DAL
{
[Serializable()]
public class VaultAtm
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public VaultAtm() { }
public VaultAtm( int vault_id,int atm_id )
{
this.vault_id = vault_id;
this.vault_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}
private VaultAtm( int vault_atm_id,int vault_id,int atm_id )
{
this.vault_atm_id = vault_atm_id;
this.vault_atm_idChanged = true;
this.vault_id = vault_id;
this.vault_idChanged = true;
this.atm_id = atm_id;
this.atm_idChanged = true;
}

#region members and properties for columns

#region VaultAtmId
private bool vault_atm_idChanged = false;
private int vault_atm_id;
public int VaultAtmId
{
get { return vault_atm_id; }
set { 
vault_atm_id = value;
vault_atm_idChanged = true;
}
}
private string vault_atm_idDbString
{
get
{
return vault_atm_id.ToString();
}
}
#endregion
#region VaultId
private bool vault_idChanged = false;
private int vault_id;
public int VaultId
{
get { return vault_id; }
set { 
vault_id = value;
vault_idChanged = true;
}
}
private string vault_idDbString
{
get
{
return vault_id.ToString();
}
}
#endregion
#region AtmId
private bool atm_idChanged = false;
private int atm_id;
public int AtmId
{
get { return atm_id; }
set { 
atm_id = value;
atm_idChanged = true;
}
}
private string atm_idDbString
{
get
{
return atm_id.ToString();
}
}
#endregion
#endregion

#region VaultAtmReader
public class VaultAtmReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
VaultAtm currentVaultAtm;
Columns columns;
bool partialRead = false;
private VaultAtmReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public VaultAtmReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public VaultAtmReader(IDataReader reader, IDbConnection conn, Columns columns)
{
this.reader = reader;
this.conn = conn;
this.columns = columns;
partialRead = true;
}

public bool IsClosed
{
get { return reader.IsClosed; }
}
public int Depth
{
get { return reader.Depth; }
}
public int FieldCount
{
get { return reader.FieldCount; }
}

public object Current
{
get { return currentVaultAtm; }

} public void Close()
{
reader.Close();
conn.Close();
}
public void Close(bool closeConnection)
{
reader.Close();
if (closeConnection)
conn.Close();
}

public bool Read()
{
if (reader.Read())
{
currentVaultAtm = new VaultAtm();
if (partialRead)
{ if ((columns & Columns.vault_atm_id) == Columns.vault_atm_id && reader["vault_atm_id"]!=DBNull.Value)
currentVaultAtm.vault_atm_id =(int) reader["vault_atm_id"]; 
if ((columns & Columns.vault_id) == Columns.vault_id && reader["vault_id"]!=DBNull.Value)
currentVaultAtm.vault_id =(int) reader["vault_id"]; 
if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
currentVaultAtm.atm_id =(int) reader["atm_id"]; 

} else
{
if (reader["vault_atm_id"] != DBNull.Value)
currentVaultAtm.vault_atm_id = (int) reader["vault_atm_id"]; 
if (reader["vault_id"] != DBNull.Value)
currentVaultAtm.vault_id = (int) reader["vault_id"]; 
if (reader["atm_id"] != DBNull.Value)
currentVaultAtm.atm_id = (int) reader["atm_id"]; 
} 

currentVaultAtm.isNewEntity = false;
return true;
}
else
return false;
}
#region IEnumerable Members

public IEnumerator GetEnumerator()
{ return this;
} 
#endregion


#region IEnumerator Members

public VaultAtm CurrentVaultAtm
{
get{ return currentVaultAtm; }
}

public bool MoveNext()
{
return Read();
}

public void Reset()
{
throw new Exception("The method is not implemented.");
}

#endregion
}

#endregion


#region VaultAtm functions

public static VaultAtmReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.vault_atm_id == (Columns.vault_atm_id & columns))
qry.Append("vault_atm_id,");
if (Columns.vault_id == (Columns.vault_id & columns))
qry.Append("vault_id,");
if (Columns.atm_id == (Columns.atm_id & columns))
qry.Append("atm_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Vault_atm ");

if (where != null && where.Trim().Length > 0)
{
qry.Append(" where ");
qry.Append(where); ;
}

if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED ";
cmd.ExecuteNonQuery();
cmd.CommandText = qry.ToString();
return new VaultAtmReader(cmd.ExecuteReader(), conn, columns);
}

static public VaultAtmReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static VaultAtmReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select vault_atm_id,vault_id,atm_id from Vault_atm ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new VaultAtmReader(cmd.ExecuteReader(), conn);
}

static public VaultAtmReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static VaultAtm LoadVaultAtm(string where)
{
VaultAtmReader reader = VaultAtm.ExecuteReader(where);
VaultAtm _vaultatm = null;
if (reader.Read())
_vaultatm = reader.CurrentVaultAtm;
reader.Close();
return _vaultatm;
}

public static VaultAtm LoadVaultAtm(string where, IDbConnection conn)
{
VaultAtmReader reader = VaultAtm.ExecuteReader(where, conn);
VaultAtm _vaultatm = null;
if (reader.Read())
_vaultatm = reader.CurrentVaultAtm;
reader.Close(false);
return _vaultatm;
}

public static VaultAtm LoadVaultAtmByPk( int vault_atm_id )
{
return LoadVaultAtm( " vault_atm_id="+vault_atm_id );
}

public static VaultAtm LoadVaultAtmByPk( int vault_atm_id , IDbConnection conn)
{
return LoadVaultAtm(" vault_atm_id="+vault_atm_id , conn);
}

public void Save()
{
if (vault_atm_idChanged || vault_idChanged || atm_idChanged )
ExcuteSave(ConnectionFactory.GetNewConnection().CreateCommand());
}

public void Save(IDbConnection conn,IDbTransaction trx)
{
IDbCommand cmd = conn.CreateCommand();
cmd.Transaction = trx;
ExcuteSave(cmd);
}

public void Save(IDbConnection conn)
{
IDbCommand cmd = conn.CreateCommand();
ExcuteSave(cmd);
}

/// an opened connection
private void ExcuteSave(IDbCommand cmd) {
if (vault_atm_idChanged || vault_idChanged || atm_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Vault_atm( vault_atm_id,vault_id,atm_id ) values(");
lock (ConnectionFactory.connectionString) { this.vault_atm_id = ConnectionFactory.GetNextId();
qry.Append(this.vault_atm_id);
} qry.Append(",");
qry.Append(vault_idDbString+",");
qry.Append(atm_idDbString);
qry.Append(");");

}
else
{
if (!(vault_atm_idChanged || vault_idChanged || atm_idChanged ))
return;
qry.Append("UPDATE Vault_atm set "); if ( vault_idChanged )
{
qry.Append("vault_id ="+vault_idDbString);
qry.Append(",");
}

if ( atm_idChanged )
{
qry.Append("atm_id ="+atm_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("vault_atm_id = "+vault_atm_idDbString);
}

cmd.CommandText = qry.ToString();
bool closeConnection = false;
if (cmd.Connection.State == ConnectionState.Closed)
{
cmd.Connection.Open();
closeConnection = true;
}
if (this.isNewEntity)
{
cmd.ExecuteNonQuery();
isNewEntity = false;
}
else
cmd.ExecuteNonQuery();

if (closeConnection)
cmd.Connection.Close();
}
}

public void Delete()
{
Delete(ConnectionFactory.GetNewConnection());
}

public void Delete(IDbConnection conn)
{
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "DELETE Vault_atm where vault_atm_id = "+ vault_atm_id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteVaultAtms(string where)
{
ConnectionFactory.ExecuteQuery("delete Vault_atm where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
vault_atm_id= 1,
vault_id= 2,
atm_id= 4
}
#endregion
public void BulkSave(List<VaultAtm> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Vault_atm";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(VaultAtm.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <VaultAtm> transList,ref DataTable dt)
{
foreach (VaultAtm tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["vault_atm_id"] =ConnectionFactory.GetNextId();
Row["vault_id"] = tran.VaultId;
Row["atm_id"] = tran.AtmId;
dt.Rows.Add(Row);
} }
}
}
