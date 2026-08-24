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
public class CcmsTask
{
bool isNewEntity = true;
bool IsNewEntity
{
get { return isNewEntity; }
}

public CcmsTask() { }
public CcmsTask( int id,int organization_id ) 
{
this.organization_id = organization_id;
this.organization_idChanged = true;
}
public CcmsTask( string type,string display_name,string status,int? owner,string description,int? context_id,DateTime? deadline,int? assigned_to,int? parent_id,string priority,int? escalation_id,string reference_no,string result,string parameters,DateTime? created_on,int? created_by,DateTime? modified_on,int? modified_by,string category,int? entity_id,bool? is_deleted,bool? is_assigned_to_group,int organization_id )
{
this.type = type;
this.typeChanged = true;
this.display_name = display_name;
this.display_nameChanged = true;
this.status = status;
this.statusChanged = true;
this.owner = owner;
this.ownerChanged = true;
this.description = description;
this.descriptionChanged = true;
this.context_id = context_id;
this.context_idChanged = true;
this.deadline = deadline;
this.deadlineChanged = true;
this.assigned_to = assigned_to;
this.assigned_toChanged = true;
this.parent_id = parent_id;
this.parent_idChanged = true;
this.priority = priority;
this.priorityChanged = true;
this.escalation_id = escalation_id;
this.escalation_idChanged = true;
this.reference_no = reference_no;
this.reference_noChanged = true;
this.result = result;
this.resultChanged = true;
this.parameters = parameters;
this.parametersChanged = true;
this.created_on = created_on;
this.created_onChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.modified_on = modified_on;
this.modified_onChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.category = category;
this.categoryChanged = true;
this.entity_id = entity_id;
this.entity_idChanged = true;
this.is_deleted = is_deleted;
this.is_deletedChanged = true;
this.is_assigned_to_group = is_assigned_to_group;
this.is_assigned_to_groupChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
}
private CcmsTask( int id,string type,string display_name,string status,int? owner,string description,int? context_id,DateTime? deadline,int? assigned_to,int? parent_id,string priority,int? escalation_id,string reference_no,string result,string parameters,DateTime? created_on,int? created_by,DateTime? modified_on,int? modified_by,string category,int? entity_id,bool? is_deleted,bool? is_assigned_to_group,int organization_id )
{
this.id = id;
this.idChanged = true;
this.type = type;
this.typeChanged = true;
this.display_name = display_name;
this.display_nameChanged = true;
this.status = status;
this.statusChanged = true;
this.owner = owner;
this.ownerChanged = true;
this.description = description;
this.descriptionChanged = true;
this.context_id = context_id;
this.context_idChanged = true;
this.deadline = deadline;
this.deadlineChanged = true;
this.assigned_to = assigned_to;
this.assigned_toChanged = true;
this.parent_id = parent_id;
this.parent_idChanged = true;
this.priority = priority;
this.priorityChanged = true;
this.escalation_id = escalation_id;
this.escalation_idChanged = true;
this.reference_no = reference_no;
this.reference_noChanged = true;
this.result = result;
this.resultChanged = true;
this.parameters = parameters;
this.parametersChanged = true;
this.created_on = created_on;
this.created_onChanged = true;
this.created_by = created_by;
this.created_byChanged = true;
this.modified_on = modified_on;
this.modified_onChanged = true;
this.modified_by = modified_by;
this.modified_byChanged = true;
this.category = category;
this.categoryChanged = true;
this.entity_id = entity_id;
this.entity_idChanged = true;
this.is_deleted = is_deleted;
this.is_deletedChanged = true;
this.is_assigned_to_group = is_assigned_to_group;
this.is_assigned_to_groupChanged = true;
this.organization_id = organization_id;
this.organization_idChanged = true;
}

#region members and properties for columns

#region Id
private bool idChanged = false;
private int id;
public int Id
{
get { return id; }
set { 
id = value;
idChanged = true;
}
}
private string idDbString
{
get
{
return id.ToString();
}
}
#endregion
#region Type
private bool typeChanged = false;
private string type;
public string Type
{
get { return type; }
set { 
type = value;
typeChanged = true;
}
}
private string typeDbString
{
get
{
if (this.type!=null)
return string.Format("'{0}'",type); else
return "null";
}
}
#endregion
#region DisplayName
private bool display_nameChanged = false;
private string display_name;
public string DisplayName
{
get { return display_name; }
set { 
display_name = value;
display_nameChanged = true;
}
}
private string display_nameDbString
{
get
{
if (this.display_name!=null)
return string.Format("'{0}'",display_name); else
return "null";
}
}
#endregion
#region Status
private bool statusChanged = false;
private string status;
public string Status
{
get { return status; }
set { 
status = value;
statusChanged = true;
}
}
private string statusDbString
{
get
{
if (this.status!=null)
return string.Format("'{0}'",status); else
return "null";
}
}
#endregion
#region Owner
private bool ownerChanged = false;
private int? owner;
public int? Owner
{
get { return owner; }
set { 
owner = value;
ownerChanged = true;
}
}
private string ownerDbString
{
get
{
if (this.owner.HasValue)
return owner.ToString();
else
return "null";
}
}
#endregion
#region Description
private bool descriptionChanged = false;
private string description;
public string Description
{
get { return description; }
set { 
description = value;
descriptionChanged = true;
}
}
private string descriptionDbString
{
get
{
if (this.description!=null)
return string.Format("'{0}'",description); else
return "null";
}
}
#endregion
#region ContextId
private bool context_idChanged = false;
private int? context_id;
public int? ContextId
{
get { return context_id; }
set { 
context_id = value;
context_idChanged = true;
}
}
private string context_idDbString
{
get
{
if (this.context_id.HasValue)
return context_id.ToString();
else
return "null";
}
}
#endregion
#region Deadline
private bool deadlineChanged = false;
private DateTime? deadline;
public DateTime? Deadline
{
get { return deadline; }
set { 
deadline = value;
deadlineChanged = true;
}
}
private string deadlineDbString
{
get
{
if (this.deadline.HasValue)
return string.Format("Convert(datetime,'{0}',121)",deadline.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region AssignedTo
private bool assigned_toChanged = false;
private int? assigned_to;
public int? AssignedTo
{
get { return assigned_to; }
set { 
assigned_to = value;
assigned_toChanged = true;
}
}
private string assigned_toDbString
{
get
{
if (this.assigned_to.HasValue)
return assigned_to.ToString();
else
return "null";
}
}
#endregion
#region ParentId
private bool parent_idChanged = false;
private int? parent_id;
public int? ParentId
{
get { return parent_id; }
set { 
parent_id = value;
parent_idChanged = true;
}
}
private string parent_idDbString
{
get
{
if (this.parent_id.HasValue)
return parent_id.ToString();
else
return "null";
}
}
#endregion
#region Priority
private bool priorityChanged = false;
private string priority;
public string Priority
{
get { return priority; }
set { 
priority = value;
priorityChanged = true;
}
}
private string priorityDbString
{
get
{
if (this.priority!=null)
return string.Format("'{0}'",priority); else
return "null";
}
}
#endregion
#region EscalationId
private bool escalation_idChanged = false;
private int? escalation_id;
public int? EscalationId
{
get { return escalation_id; }
set { 
escalation_id = value;
escalation_idChanged = true;
}
}
private string escalation_idDbString
{
get
{
if (this.escalation_id.HasValue)
return escalation_id.ToString();
else
return "null";
}
}
#endregion
#region ReferenceNo
private bool reference_noChanged = false;
private string reference_no;
public string ReferenceNo
{
get { return reference_no; }
set { 
reference_no = value;
reference_noChanged = true;
}
}
private string reference_noDbString
{
get
{
if (this.reference_no!=null)
return string.Format("'{0}'",reference_no); else
return "null";
}
}
#endregion
#region Result
private bool resultChanged = false;
private string result;
public string Result
{
get { return result; }
set { 
result = value;
resultChanged = true;
}
}
private string resultDbString
{
get
{
if (this.result!=null)
return string.Format("'{0}'",result); else
return "null";
}
}
#endregion
#region Parameters
private bool parametersChanged = false;
private string parameters;
public string Parameters
{
get { return parameters; }
set { 
parameters = value;
parametersChanged = true;
}
}
private string parametersDbString
{
get
{
if (this.parameters!=null)
return string.Format("'{0}'",parameters); else
return "null";
}
}
#endregion
#region CreatedOn
private bool created_onChanged = false;
private DateTime? created_on;
public DateTime? CreatedOn
{
get { return created_on; }
set { 
created_on = value;
created_onChanged = true;
}
}
private string created_onDbString
{
get
{
if (this.created_on.HasValue)
return string.Format("Convert(datetime,'{0}',121)",created_on.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region CreatedBy
private bool created_byChanged = false;
private int? created_by;
public int? CreatedBy
{
get { return created_by; }
set { 
created_by = value;
created_byChanged = true;
}
}
private string created_byDbString
{
get
{
if (this.created_by.HasValue)
return created_by.ToString();
else
return "null";
}
}
#endregion
#region ModifiedOn
private bool modified_onChanged = false;
private DateTime? modified_on;
public DateTime? ModifiedOn
{
get { return modified_on; }
set { 
modified_on = value;
modified_onChanged = true;
}
}
private string modified_onDbString
{
get
{
if (this.modified_on.HasValue)
return string.Format("Convert(datetime,'{0}',121)",modified_on.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));
else
return "null";
}
}
#endregion
#region ModifiedBy
private bool modified_byChanged = false;
private int? modified_by;
public int? ModifiedBy
{
get { return modified_by; }
set { 
modified_by = value;
modified_byChanged = true;
}
}
private string modified_byDbString
{
get
{
if (this.modified_by.HasValue)
return modified_by.ToString();
else
return "null";
}
}
#endregion
#region Category
private bool categoryChanged = false;
private string category;
public string Category
{
get { return category; }
set { 
category = value;
categoryChanged = true;
}
}
private string categoryDbString
{
get
{
if (this.category!=null)
return string.Format("'{0}'",category); else
return "null";
}
}
#endregion
#region EntityId
private bool entity_idChanged = false;
private int? entity_id;
public int? EntityId
{
get { return entity_id; }
set { 
entity_id = value;
entity_idChanged = true;
}
}
private string entity_idDbString
{
get
{
if (this.entity_id.HasValue)
return entity_id.ToString();
else
return "null";
}
}
#endregion
#region IsDeleted
private bool is_deletedChanged = false;
private bool? is_deleted;
public bool? IsDeleted
{
get { return is_deleted; }
set { 
is_deleted = value;
is_deletedChanged = true;
}
}
private string is_deletedDbString
{
get
{
if (this.is_deleted.HasValue)
return is_deleted.Value?"1":"0";
else
return "null";
}
}
#endregion
#region IsAssignedToGroup
private bool is_assigned_to_groupChanged = false;
private bool? is_assigned_to_group;
public bool? IsAssignedToGroup
{
get { return is_assigned_to_group; }
set { 
is_assigned_to_group = value;
is_assigned_to_groupChanged = true;
}
}
private string is_assigned_to_groupDbString
{
get
{
if (this.is_assigned_to_group.HasValue)
return is_assigned_to_group.Value?"1":"0";
else
return "null";
}
}
#endregion
#region OrganizationId
private bool organization_idChanged = false;
private int organization_id;
public int OrganizationId
{
get { return organization_id; }
set { 
organization_id = value;
organization_idChanged = true;
}
}
private string organization_idDbString
{
get
{
return organization_id.ToString();
}
}
#endregion
#endregion

#region CcmsTaskReader
public class CcmsTaskReader:IEntityReader, IEnumerator, IEnumerable 
{
IDataReader reader;
IDbConnection conn;
CcmsTask currentCcmsTask;
Columns columns;
bool partialRead = false;
private CcmsTaskReader() { }
/// 
///
///

/// 
/// so that it can close connection on ATMReader.Close()
public CcmsTaskReader(IDataReader reader,IDbConnection conn)
{
this.reader = reader;
this.conn = conn;
}
public CcmsTaskReader(IDataReader reader, IDbConnection conn, Columns columns)
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
get { return currentCcmsTask; }

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
currentCcmsTask = new CcmsTask();
if (partialRead)
{ if ((columns & Columns.id) == Columns.id && reader["id"]!=DBNull.Value)
currentCcmsTask.id =(int) reader["id"]; 
if ((columns & Columns.type) == Columns.type && reader["type"]!=DBNull.Value)
currentCcmsTask.type =(string) reader["type"]; 
if ((columns & Columns.display_name) == Columns.display_name && reader["display_name"]!=DBNull.Value)
currentCcmsTask.display_name =(string) reader["display_name"]; 
if ((columns & Columns.status) == Columns.status && reader["status"]!=DBNull.Value)
currentCcmsTask.status =(string) reader["status"]; 
if ((columns & Columns.owner) == Columns.owner && reader["owner"]!=DBNull.Value)
currentCcmsTask.owner =(int?) reader["owner"]; 
if ((columns & Columns.description) == Columns.description && reader["description"]!=DBNull.Value)
currentCcmsTask.description =(string) reader["description"]; 
if ((columns & Columns.context_id) == Columns.context_id && reader["context_id"]!=DBNull.Value)
currentCcmsTask.context_id =(int?) reader["context_id"]; 
if ((columns & Columns.deadline) == Columns.deadline && reader["deadline"]!=DBNull.Value)
currentCcmsTask.deadline =(DateTime?) reader["deadline"]; 
if ((columns & Columns.assigned_to) == Columns.assigned_to && reader["assigned_to"]!=DBNull.Value)
currentCcmsTask.assigned_to =(int?) reader["assigned_to"]; 
if ((columns & Columns.parent_id) == Columns.parent_id && reader["parent_id"]!=DBNull.Value)
currentCcmsTask.parent_id =(int?) reader["parent_id"]; 
if ((columns & Columns.priority) == Columns.priority && reader["priority"]!=DBNull.Value)
currentCcmsTask.priority =(string) reader["priority"]; 
if ((columns & Columns.escalation_id) == Columns.escalation_id && reader["escalation_id"]!=DBNull.Value)
currentCcmsTask.escalation_id =(int?) reader["escalation_id"]; 
if ((columns & Columns.reference_no) == Columns.reference_no && reader["reference_no"]!=DBNull.Value)
currentCcmsTask.reference_no =(string) reader["reference_no"]; 
if ((columns & Columns.result) == Columns.result && reader["result"]!=DBNull.Value)
currentCcmsTask.result =(string) reader["result"]; 
if ((columns & Columns.parameters) == Columns.parameters && reader["parameters"]!=DBNull.Value)
currentCcmsTask.parameters =(string) reader["parameters"]; 
if ((columns & Columns.created_on) == Columns.created_on && reader["created_on"]!=DBNull.Value)
currentCcmsTask.created_on =(DateTime?) reader["created_on"]; 
if ((columns & Columns.created_by) == Columns.created_by && reader["created_by"]!=DBNull.Value)
currentCcmsTask.created_by =(int?) reader["created_by"]; 
if ((columns & Columns.modified_on) == Columns.modified_on && reader["modified_on"]!=DBNull.Value)
currentCcmsTask.modified_on =(DateTime?) reader["modified_on"]; 
if ((columns & Columns.modified_by) == Columns.modified_by && reader["modified_by"]!=DBNull.Value)
currentCcmsTask.modified_by =(int?) reader["modified_by"]; 
if ((columns & Columns.category) == Columns.category && reader["category"]!=DBNull.Value)
currentCcmsTask.category =(string) reader["category"]; 
if ((columns & Columns.entity_id) == Columns.entity_id && reader["entity_id"]!=DBNull.Value)
currentCcmsTask.entity_id =(int?) reader["entity_id"]; 
if ((columns & Columns.is_deleted) == Columns.is_deleted && reader["is_deleted"]!=DBNull.Value)
currentCcmsTask.is_deleted =(bool?) reader["is_deleted"]; 
if ((columns & Columns.is_assigned_to_group) == Columns.is_assigned_to_group && reader["is_assigned_to_group"]!=DBNull.Value)
currentCcmsTask.is_assigned_to_group =(bool?) reader["is_assigned_to_group"]; 
if ((columns & Columns.organization_id) == Columns.organization_id && reader["organization_id"]!=DBNull.Value)
currentCcmsTask.organization_id =(int) reader["organization_id"]; 

} else
{
if (reader["id"] != DBNull.Value)
currentCcmsTask.id = int.Parse(reader["id"].ToString()); 
if (reader["type"] != DBNull.Value)
currentCcmsTask.type = (string) reader["type"]; 
if (reader["display_name"] != DBNull.Value)
currentCcmsTask.display_name = (string) reader["display_name"]; 
if (reader["status"] != DBNull.Value)
currentCcmsTask.status = (string) reader["status"]; 
if (reader["owner"] != DBNull.Value)
currentCcmsTask.owner = int.Parse(reader["owner"].ToString()); 
if (reader["description"] != DBNull.Value)
currentCcmsTask.description = (string) reader["description"]; 
if (reader["context_id"] != DBNull.Value)
currentCcmsTask.context_id = int.Parse(reader["context_id"].ToString()); 
if (reader["deadline"] != DBNull.Value)
currentCcmsTask.deadline = (DateTime?) reader["deadline"]; 
if (reader["assigned_to"] != DBNull.Value)
currentCcmsTask.assigned_to = int.Parse(reader["assigned_to"].ToString()); 
if (reader["parent_id"] != DBNull.Value)
currentCcmsTask.parent_id = int.Parse(reader["parent_id"].ToString()); 
if (reader["priority"] != DBNull.Value)
currentCcmsTask.priority = (string) reader["priority"]; 
if (reader["escalation_id"] != DBNull.Value)
currentCcmsTask.escalation_id = int.Parse(reader["escalation_id"].ToString()); 
if (reader["reference_no"] != DBNull.Value)
currentCcmsTask.reference_no = (string) reader["reference_no"]; 
if (reader["result"] != DBNull.Value)
currentCcmsTask.result = (string) reader["result"]; 
if (reader["parameters"] != DBNull.Value)
currentCcmsTask.parameters = (string) reader["parameters"]; 
if (reader["created_on"] != DBNull.Value)
currentCcmsTask.created_on = (DateTime?) reader["created_on"]; 
if (reader["created_by"] != DBNull.Value)
currentCcmsTask.created_by = int.Parse(reader["created_by"].ToString()); 
if (reader["modified_on"] != DBNull.Value)
currentCcmsTask.modified_on = (DateTime?) reader["modified_on"]; 
if (reader["modified_by"] != DBNull.Value)
currentCcmsTask.modified_by = int.Parse(reader["modified_by"].ToString()); 
if (reader["category"] != DBNull.Value)
currentCcmsTask.category = (string) reader["category"]; 
if (reader["entity_id"] != DBNull.Value)
currentCcmsTask.entity_id = int.Parse(reader["entity_id"].ToString()); 
if (reader["is_deleted"] != DBNull.Value)
currentCcmsTask.is_deleted = (bool?) reader["is_deleted"]; 
if (reader["is_assigned_to_group"] != DBNull.Value)
currentCcmsTask.is_assigned_to_group = (bool?) reader["is_assigned_to_group"]; 
if (reader["organization_id"] != DBNull.Value)
currentCcmsTask.organization_id = int.Parse(reader["organization_id"].ToString()); 
} 

currentCcmsTask.isNewEntity = false;
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

public CcmsTask CurrentCcmsTask
{
get{ return currentCcmsTask; }
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


#region CcmsTask functions

public static CcmsTaskReader ExecuteReader(string where, IDbConnection conn, Columns columns)
{
StringBuilder qry = new StringBuilder(200);
qry.Append("select ");
if (Columns.id == (Columns.id & columns))
qry.Append("id,");
if (Columns.type == (Columns.type & columns))
qry.Append("type,");
if (Columns.display_name == (Columns.display_name & columns))
qry.Append("display_name,");
if (Columns.status == (Columns.status & columns))
qry.Append("status,");
if (Columns.owner == (Columns.owner & columns))
qry.Append("owner,");
if (Columns.description == (Columns.description & columns))
qry.Append("description,");
if (Columns.context_id == (Columns.context_id & columns))
qry.Append("context_id,");
if (Columns.deadline == (Columns.deadline & columns))
qry.Append("deadline,");
if (Columns.assigned_to == (Columns.assigned_to & columns))
qry.Append("assigned_to,");
if (Columns.parent_id == (Columns.parent_id & columns))
qry.Append("parent_id,");
if (Columns.priority == (Columns.priority & columns))
qry.Append("priority,");
if (Columns.escalation_id == (Columns.escalation_id & columns))
qry.Append("escalation_id,");
if (Columns.reference_no == (Columns.reference_no & columns))
qry.Append("reference_no,");
if (Columns.result == (Columns.result & columns))
qry.Append("result,");
if (Columns.parameters == (Columns.parameters & columns))
qry.Append("parameters,");
if (Columns.created_on == (Columns.created_on & columns))
qry.Append("created_on,");
if (Columns.created_by == (Columns.created_by & columns))
qry.Append("created_by,");
if (Columns.modified_on == (Columns.modified_on & columns))
qry.Append("modified_on,");
if (Columns.modified_by == (Columns.modified_by & columns))
qry.Append("modified_by,");
if (Columns.category == (Columns.category & columns))
qry.Append("category,");
if (Columns.entity_id == (Columns.entity_id & columns))
qry.Append("entity_id,");
if (Columns.is_deleted == (Columns.is_deleted & columns))
qry.Append("is_deleted,");
if (Columns.is_assigned_to_group == (Columns.is_assigned_to_group & columns))
qry.Append("is_assigned_to_group,");
if (Columns.organization_id == (Columns.organization_id & columns))
qry.Append("organization_id,");
qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append("from Ccms_task ");

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
return new CcmsTaskReader(cmd.ExecuteReader(), conn, columns);
}

static public CcmsTaskReader ExecuteReader(string where,Columns columns)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
}

/// 
/// should be used when u have connection like in case of transaction

/// 
/// 
/// 
public static CcmsTaskReader ExecuteReader(string where,IDbConnection conn)
{
if (conn.State != ConnectionState.Open)
conn.Open();
IDbCommand cmd = conn.CreateCommand();
cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
cmd.ExecuteNonQuery();
cmd.CommandText = "Select id,type,display_name,status,owner,description,context_id,deadline,assigned_to,parent_id,priority,escalation_id,reference_no,result,parameters,created_on,created_by,modified_on,modified_by,category,entity_id,is_deleted,is_assigned_to_group,organization_id from Ccms_task ";
if (where != null && where.Trim().Length > 0)
cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

return new CcmsTaskReader(cmd.ExecuteReader(), conn);
}

static public CcmsTaskReader ExecuteReader(string where)
{
return ExecuteReader(where, ConnectionFactory.GetNewConnection());
}

public static CcmsTask LoadCcmsTask(string where)
{
CcmsTaskReader reader = CcmsTask.ExecuteReader(where);
CcmsTask _ccmstask = null;
if (reader.Read())
_ccmstask = reader.CurrentCcmsTask;
reader.Close();
return _ccmstask;
}

public static CcmsTask LoadCcmsTask(string where, IDbConnection conn)
{
CcmsTaskReader reader = CcmsTask.ExecuteReader(where, conn);
CcmsTask _ccmstask = null;
if (reader.Read())
_ccmstask = reader.CurrentCcmsTask;
reader.Close(false);
return _ccmstask;
}

public static CcmsTask LoadCcmsTaskByPk( int id )
{
return LoadCcmsTask( " id="+id );
}

public static CcmsTask LoadCcmsTaskByPk( int id , IDbConnection conn)
{
return LoadCcmsTask(" id="+id , conn);
}

public void Save()
{
if (idChanged || typeChanged || display_nameChanged || statusChanged || ownerChanged || descriptionChanged || context_idChanged || deadlineChanged || assigned_toChanged || parent_idChanged || priorityChanged || escalation_idChanged || reference_noChanged || resultChanged || parametersChanged || created_onChanged || created_byChanged || modified_onChanged || modified_byChanged || categoryChanged || entity_idChanged || is_deletedChanged || is_assigned_to_groupChanged || organization_idChanged )
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
if (idChanged || typeChanged || display_nameChanged || statusChanged || ownerChanged || descriptionChanged || context_idChanged || deadlineChanged || assigned_toChanged || parent_idChanged || priorityChanged || escalation_idChanged || reference_noChanged || resultChanged || parametersChanged || created_onChanged || created_byChanged || modified_onChanged || modified_byChanged || categoryChanged || entity_idChanged || is_deletedChanged || is_assigned_to_groupChanged || organization_idChanged )
{
StringBuilder qry = new StringBuilder(500);

if (this.isNewEntity)
{
qry.Append(@"insert into Ccms_task( type,display_name,status,owner,description,context_id,deadline,assigned_to,parent_id,priority,escalation_id,reference_no,result,parameters,created_on,created_by,modified_on,modified_by,category,entity_id,is_deleted,is_assigned_to_group,organization_id ) values(");
qry.Append(typeDbString+",");
qry.Append(display_nameDbString+",");
qry.Append(statusDbString+",");
qry.Append(ownerDbString+",");
qry.Append(descriptionDbString+",");
qry.Append(context_idDbString+",");
qry.Append(deadlineDbString+",");
qry.Append(assigned_toDbString+",");
qry.Append(parent_idDbString+",");
qry.Append(priorityDbString+",");
qry.Append(escalation_idDbString+",");
qry.Append(reference_noDbString+",");
qry.Append(resultDbString+",");
qry.Append(parametersDbString+",");
qry.Append(created_onDbString+",");
qry.Append(created_byDbString+",");
qry.Append(modified_onDbString+",");
qry.Append(modified_byDbString+",");
qry.Append(categoryDbString+",");
qry.Append(entity_idDbString+",");
qry.Append(is_deletedDbString+",");
qry.Append(is_assigned_to_groupDbString+",");
qry.Append(organization_idDbString);
qry.Append(");SELECT scope_identity()");

}
else
{
if (!(idChanged || typeChanged || display_nameChanged || statusChanged || ownerChanged || descriptionChanged || context_idChanged || deadlineChanged || assigned_toChanged || parent_idChanged || priorityChanged || escalation_idChanged || reference_noChanged || resultChanged || parametersChanged || created_onChanged || created_byChanged || modified_onChanged || modified_byChanged || categoryChanged || entity_idChanged || is_deletedChanged || is_assigned_to_groupChanged || organization_idChanged ))
return;
qry.Append("UPDATE Ccms_task set "); if ( typeChanged )
{
qry.Append("type ="+typeDbString);
qry.Append(",");
}

if ( display_nameChanged )
{
qry.Append("display_name ="+display_nameDbString);
qry.Append(",");
}

if ( statusChanged )
{
qry.Append("status ="+statusDbString);
qry.Append(",");
}

if ( ownerChanged )
{
qry.Append("owner ="+ownerDbString);
qry.Append(",");
}

if ( descriptionChanged )
{
qry.Append("description ="+descriptionDbString);
qry.Append(",");
}

if ( context_idChanged )
{
qry.Append("context_id ="+context_idDbString);
qry.Append(",");
}

if ( deadlineChanged )
{
qry.Append("deadline ="+deadlineDbString);
qry.Append(",");
}

if ( assigned_toChanged )
{
qry.Append("assigned_to ="+assigned_toDbString);
qry.Append(",");
}

if ( parent_idChanged )
{
qry.Append("parent_id ="+parent_idDbString);
qry.Append(",");
}

if ( priorityChanged )
{
qry.Append("priority ="+priorityDbString);
qry.Append(",");
}

if ( escalation_idChanged )
{
qry.Append("escalation_id ="+escalation_idDbString);
qry.Append(",");
}

if ( reference_noChanged )
{
qry.Append("reference_no ="+reference_noDbString);
qry.Append(",");
}

if ( resultChanged )
{
qry.Append("result ="+resultDbString);
qry.Append(",");
}

if ( parametersChanged )
{
qry.Append("parameters ="+parametersDbString);
qry.Append(",");
}

if ( created_onChanged )
{
qry.Append("created_on ="+created_onDbString);
qry.Append(",");
}

if ( created_byChanged )
{
qry.Append("created_by ="+created_byDbString);
qry.Append(",");
}

if ( modified_onChanged )
{
qry.Append("modified_on ="+modified_onDbString);
qry.Append(",");
}

if ( modified_byChanged )
{
qry.Append("modified_by ="+modified_byDbString);
qry.Append(",");
}

if ( categoryChanged )
{
qry.Append("category ="+categoryDbString);
qry.Append(",");
}

if ( entity_idChanged )
{
qry.Append("entity_id ="+entity_idDbString);
qry.Append(",");
}

if ( is_deletedChanged )
{
qry.Append("is_deleted ="+is_deletedDbString);
qry.Append(",");
}

if ( is_assigned_to_groupChanged )
{
qry.Append("is_assigned_to_group ="+is_assigned_to_groupDbString);
qry.Append(",");
}

if ( organization_idChanged )
{
qry.Append("organization_id ="+organization_idDbString);
qry.Append(",");
}


qry.Replace(',', ' ', qry.Length - 1,1);
qry.Append(" where ");
qry.Append("id = "+idDbString);
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
    object res = cmd.ExecuteScalar();
    if (res == DBNull.Value)
        id = 1;
    else
        id = int.Parse(res.ToString());
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
cmd.CommandText = "DELETE Ccms_task where id = "+ id;
if (conn.State == ConnectionState.Closed)
{
cmd.Connection.Open();
cmd.ExecuteNonQuery();
cmd.Connection.Close();
}
else
cmd.ExecuteNonQuery();
}

public static void DeleteCcmsTasks(string where)
{
ConnectionFactory.ExecuteQuery("delete Ccms_task where " + where);
}

#endregion
#region Columns enum
public enum Columns:uint
{
id= 1,
type= 2,
display_name= 4,
status= 8,
owner= 16,
description= 32,
context_id= 64,
deadline= 128,
assigned_to= 256,
parent_id= 512,
priority= 1024,
escalation_id= 2048,
reference_no= 4096,
result= 8192,
parameters= 16384,
created_on= 32768,
created_by= 65536,
modified_on= 131072,
modified_by= 262144,
category= 524288,
entity_id= 1048576,
is_deleted= 2097152,
is_assigned_to_group= 4194304,
organization_id= 8388608
}
#endregion
public void BulkSave(List<CcmsTask> dataArray,SqlTransaction dbTrx)
{
DataTable dt = new DataTable();
CreateDataTable(dt);
AddToDataTable(dataArray, ref dt);
SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
bulk.DestinationTableName = "Ccms_task";
bulk.WriteToServer(dt);
}
public void CreateDataTable(DataTable dt)
{
string[] colNames = Enum.GetNames(typeof(CcmsTask.Columns));
for (int i = 0; i < colNames.Length; i++)
{
dt.Columns.Add(colNames[i]);
}
}
public void AddToDataTable(List <CcmsTask> transList,ref DataTable dt)
{
foreach (CcmsTask tran in transList)
{
DataRow Row;
Row = dt.NewRow();
Row["id"] =ConnectionFactory.GetNextId();
Row["type"] = tran.Type;
Row["display_name"] = tran.DisplayName;
Row["status"] = tran.Status;
Row["owner"] = tran.Owner;
Row["description"] = tran.Description;
Row["context_id"] = tran.ContextId;
Row["deadline"] = tran.Deadline;
Row["assigned_to"] = tran.AssignedTo;
Row["parent_id"] = tran.ParentId;
Row["priority"] = tran.Priority;
Row["escalation_id"] = tran.EscalationId;
Row["reference_no"] = tran.ReferenceNo;
Row["result"] = tran.Result;
Row["parameters"] = tran.Parameters;
Row["created_on"] = tran.CreatedOn;
Row["created_by"] = tran.CreatedBy;
Row["modified_on"] = tran.ModifiedOn;
Row["modified_by"] = tran.ModifiedBy;
Row["category"] = tran.Category;
Row["entity_id"] = tran.EntityId;
Row["is_deleted"] = tran.IsDeleted;
Row["is_assigned_to_group"] = tran.IsAssignedToGroup;
Row["organization_id"] = tran.OrganizationId;
dt.Rows.Add(Row);
} }
}
}
