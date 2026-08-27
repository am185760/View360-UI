<?xml version='1.0'?>

<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0"
  xmlns:math="xalan://java.lang.Math" extension-element-prefixes="math">

	<xsl:template match="/">
		<xsl:variable name="up" select="'ABCDEFGHIJKLMNOPQRSTUVWXYZ'"/>
		<xsl:variable name="lo" select="'abcdefghijklmnopqrstuvwxyz'"/>


		<HTML>
			<head>
				<script>

					var folderPath ;

					function WriteToFile(filePath, sText)
					{
					var fso = new ActiveXObject("Scripting.FileSystemObject");
					var s = fso.CreateTextFile(filePath, true);
					s.WriteLine(sText);
					s.Close()
					}

					//window.clipboardData.setData("text",key.parentNode.nextSibling.firstChild.innerText);
					function Copy(arg)
					{
					var key = arg;

					arg.innerText = arg.innerText+" Copying....";
					folderPath = window.prompt('Please, enter complete folder name to save files at',folderPath);
					<xsl:for-each select="Database/Table">
						key = key.parentNode.nextSibling;
						//  if (window.confirm('Save <xsl:value-of select="@className"></xsl:value-of> ??'))
						WriteToFile(folderPath +'\\<xsl:value-of select="@className"></xsl:value-of>.cs', key.firstChild.innerText);
						key = key.firstChild;
					</xsl:for-each>
					arg.innerText = arg.innerText+'...Done!';
					alert('Files copied ');
					}

				</script>
			</head>
			<BODY>
				<TABLE BORDER="1">
					<tr >
						<td bgcolor="lightblue" id ="titleBox" onclick="javascript: Copy(this)">
							Click HERE to Copy Code
						</td>
					</tr>

					<xsl:for-each select="Database/Table">

						<tr >
							<td >
								<div style="height:400px;OVERFLOW: auto">
									using System;<br/>
									using System.Collections;<br/>
									using System.Collections.Generic;<br/>
									using System.Text;<br/>
									using System.Data;<br/>
									using System.Threading;<br/>
									using NCR.DAL;<br/>
									using System.Data.SqlClient;<br/>
									<br/>

									namespace <xsl:value-of select="../@namespace"></xsl:value-of><br/>
									{<br/>
									[Serializable()]<br/>
									public class <xsl:value-of select="@className"></xsl:value-of><br/>
									{<br/>
									bool isNewEntity = true;<br/>

									bool IsNewEntity<br/>
									{<br/>
									get { return isNewEntity; }<br/>
									}<br/>
									<br/>

									public <xsl:value-of select="@className"></xsl:value-of>() { }<br/>

									<xsl:if test="count(Column[@isNullable='true' and @autoNumber='false'])>0 and count(Column[@isNullable='false'])>0 ">
										public <xsl:value-of select="@className"></xsl:value-of>(
										<xsl:for-each select="Column[@isNullable='false']">
											<xsl:value-of select="concat(@NullableType, ' ', @name)"/>
											<xsl:if test="position()!=last()">,</xsl:if>
										</xsl:for-each>
										) <br/>
										{<br/>
										<xsl:for-each select="Column[@isNullable='false'  and @autoNumber='false']">
											this.<xsl:value-of select="@name"/> = <xsl:value-of select="@name"/>;<br/>
											this.<xsl:value-of select="@name"/>Changed = true;<br/>
										</xsl:for-each>
										}<br/>
									</xsl:if>
									<xsl:if test="count(Column[@autoNumber='false'])">
										public <xsl:value-of select="@className"></xsl:value-of>(
										<xsl:for-each select="Column[@autoNumber='false']">
											<xsl:value-of select="concat(@NullableType, ' ', @name)"/>
											<xsl:if test="position()!=last()">,</xsl:if>
										</xsl:for-each>
										)<br/>
										{<br/>
										<xsl:for-each select="Column[@autoNumber='false']">
											this.<xsl:value-of select="@name"/> = <xsl:value-of select="@name"/>;<br/>
											this.<xsl:value-of select="@name"/>Changed = true;<br/>
										</xsl:for-each>
										}<br/>
									</xsl:if>

									<xsl:if test="count(Column[@autoNumber='true'])">
										private <xsl:value-of select="@className"></xsl:value-of>(
										<xsl:for-each select="Column">
											<xsl:value-of select="concat(@NullableType, ' ', @name)"/>
											<xsl:if test="position()!=last()">,</xsl:if>
										</xsl:for-each>
										)<br/>
										{<br/>
										<xsl:for-each select="Column">
											this.<xsl:value-of select="@name"/> = <xsl:value-of select="@name"/>;<br/>
											this.<xsl:value-of select="@name"/>Changed = true;<br/>
										</xsl:for-each>
										}<br/>
									</xsl:if>


									<br/>
									#region members and properties for columns<br/>
									<br/>
									<xsl:for-each select="Column">
										#region <xsl:value-of select="@propertyName"/><br/>
										private bool <xsl:value-of select="@name"/>Changed = false;<br/>
										private <xsl:value-of select="concat(@NullableType,' ')"/> <xsl:value-of select="@name"/>;<br/>
										public <xsl:value-of select="concat(@NullableType,' ')"/> <xsl:value-of select="@propertyName"/><br/>
										{<br/>
										get { return <xsl:value-of select="@name"/>; }<br/>
										set { <br/>
										<xsl:value-of select="@name"/> = value;<br/>
										<xsl:value-of select="@name"/>Changed = true;<br/>
										}<br/>
										}<br/>
										private string <xsl:value-of select="@name"/>DbString<br/>
										{<br/>
										get<br/>
										{<br/>
										<xsl:choose>
											<!--test="@dataType = @NullableType and @isNullable='false'"-->
											<xsl:when test="@dataType='string' or @dataType='byte[]'">
												<!--<xsl:if test="@dataType='string'">-->
												if (this.<xsl:value-of select="@name"/>!=null)<br/>
												<!--</xsl:if>-->

											</xsl:when>
											<xsl:otherwise>
												<xsl:if test="@isNullable='true'">
													if (this.<xsl:value-of select="@name"/>.HasValue)<br/>
												</xsl:if>
											</xsl:otherwise>
										</xsl:choose>
										<xsl:choose>
											<xsl:when test="@dataType='byte[]'">
												return "@<xsl:value-of select="@name"/>";<br/>
											</xsl:when>
											<xsl:when test="@dataType='DateTime'">
												<xsl:if test="@NullableType='DateTime?'">
													return string.Format("Convert(datetime,'{0}',121)",<xsl:value-of select="@name"/>.Value.ToString("yyyy-MM-dd HH:mm:ss:fff"));<br/>
												</xsl:if>
												<xsl:if test="@NullableType='DateTime'">
													return string.Format("Convert(datetime,'{0}',121)",<xsl:value-of select="@name"/>.ToString("yyyy-MM-dd HH:mm:ss:fff"));<br/>
												</xsl:if>
											</xsl:when>
											<xsl:when test="@dataType='string'">
												return string.Format("'{0}'",<xsl:value-of select="@name"/>);
											</xsl:when>
											<xsl:when test="@dataType='int' or @dataType='UInt64' or @dataType='long' or  @dataType='decimal' or @dataType='short' or @dataType='byte' or @dataType='float'">
												return <xsl:value-of select="@name"/>.ToString();<br/>
											</xsl:when>
											<xsl:when test="@NullableType='bool'">
												return <xsl:value-of select="@name"/>?"1":"0";<br/>
											</xsl:when>
											<xsl:when test="@NullableType='bool?'">
												return <xsl:value-of select="@name"/>.Value?"1":"0";<br/>
											</xsl:when>
											<xsl:otherwise>
												error while generating code, unknown datatype <xsl:value-of select="@dataType"/><br/>
											</xsl:otherwise>
										</xsl:choose>
										<xsl:choose>
											<xsl:when test="@dataType = @NullableType and @dataType!='string' and @dataType!='byte[]'">
											</xsl:when>
											<xsl:otherwise>
												else<br/>
												return "null";<br/>
											</xsl:otherwise>
										</xsl:choose>
										}<br/>
										}<br/>
										#endregion<br/>
									</xsl:for-each>
									#endregion<br/>
									<br/>

									#region <xsl:value-of select="concat(' ',@className)"/>Reader<br/>

									public class <xsl:value-of select="concat(' ',@className)"/>Reader:IEntityReader, IEnumerator, IEnumerable <br/>
									{<br/>
									IDataReader reader;<br/>
									IDbConnection conn;<br/>
									<xsl:value-of select="@className"/> current<xsl:value-of select="@className"/>;<br/>
									<xsl:if test="not(count(Column)>500)">
										Columns columns;<br/>
									</xsl:if>
									bool partialRead = false;<br/>

									private <xsl:value-of select="concat(' ',@className)"/>Reader() { }<br/>
									/// <summary>
										<br/>
										///<br/>
										///<br/>
									</summary><br/>
									/// <param name="reader"></param><br/>
									/// <param name="conn">so that it can close connection on ATMReader.Close()</param><br/>
									public <xsl:value-of select="concat(' ',@className)"/>Reader(IDataReader reader,IDbConnection conn)<br/>
									{<br/>
									this.reader = reader;<br/>
									this.conn = conn;<br/>
									}<br/>

									<xsl:if test="not(count(Column)>500)">
										public <xsl:value-of select="concat(' ',@className)"/>Reader(IDataReader reader, IDbConnection conn, Columns columns)<br/>
										{<br/>
										this.reader = reader;<br/>
										this.conn = conn;<br/>
										this.columns = columns;<br/>
										partialRead = true;<br/>
										}<br/>
										<br/>
									</xsl:if>
									public bool IsClosed<br/>
									{<br/>
									get { return reader.IsClosed; }<br/>
									}<br/>
									public int Depth<br/>
									{<br/>
									get { return reader.Depth; }<br/>
									}<br/>
									public int FieldCount<br/>
									{<br/>
									get { return reader.FieldCount; }<br/>
									}<br/>
									<br/>
									public object Current<br/>
									{<br/>
									get
									{ return current<xsl:value-of select="@className"/>; }<br/>
									<br/>
									}
									public void Close()<br/>
									{<br/>
									reader.Close();<br/>
									conn.Close();<br/>
									}<br/>
									public void Close(bool closeConnection)<br/>
									{<br/>
									reader.Close();<br/>
									if (closeConnection)<br/>
									conn.Close();<br/>
									}<br/>
									<br/>
									public bool Read()<br/>
									{<br/>
									if (reader.Read())<br/>
									{<br/>
									current<xsl:value-of select="@className"/> = new <xsl:value-of select="concat(' ',@className)"/>();<br/>
									<xsl:if test="not(count(Column) > 64)">
										if (partialRead)<br/>
										{
										<xsl:for-each select="Column">
											if ((columns &amp; Columns.<xsl:value-of select="@columnName"/>) == Columns.<xsl:value-of select="@columnName"/>  &amp;&amp; reader["<xsl:value-of select="@columnName"/>"]!=DBNull.Value)<br/>
											current<xsl:value-of select="../@className" />.<xsl:value-of select="@name"/> =(<xsl:value-of select="@NullableType"/>) reader["<xsl:value-of select="@columnName"/>"];
											<br/>
										</xsl:for-each>
										<br/>
										}
										else<br/>
									</xsl:if>
									{<br/>

									<xsl:for-each select="Column">
										if (reader["<xsl:value-of select="@columnName"/>"] != DBNull.Value)<br/>
										current<xsl:value-of select="../@className"/>.<xsl:value-of select="@name"/> = (<xsl:value-of select="@NullableType"/>) reader["<xsl:value-of select="@columnName"/>"];
										<br/>
									</xsl:for-each>

									} <br/>

									<br/>
									current<xsl:value-of select="@className"/>.isNewEntity = false;<br/>
									return true;<br/>
									}<br/>
									else<br/>
									return false;<br/>
									}<br/>


									#region IEnumerable Members<br/>
									<br/>
									public IEnumerator GetEnumerator()<br/>
									{                  return this;<br/>                  }
									<br/>
									#endregion<br/>
									<br/>                  <br/>

									#region IEnumerator Members<br/><br/>

									public <xsl:value-of select="@className"/> Current<xsl:value-of select="@className"/><br/>
									{<br/>
									get{ return current<xsl:value-of select="@className"/>; }<br/>
									}<br/>
									<br/>
									public bool MoveNext()<br/>
									{<br/>
									return Read();<br/>
									}<br/>
									<br/>
									public void Reset()<br/>
									{<br/>
									throw new Exception("The method is not implemented.");<br/>
									}<br/>
									<br/>
									#endregion<br/>

									}<br/>
									<br/>
									#endregion<br/>
									<br/>


									<br/>
									#region <xsl:value-of select="@className"/> functions<br/>
									<br/>
									<xsl:if test="not(count(Column)>500)">

										public static <xsl:value-of select="@className"/>Reader ExecuteReader(string where, IDbConnection conn, Columns columns)<br/>
										{<br/>
										StringBuilder qry = new StringBuilder(200);<br/>
										qry.Append("select ");<br/>

										<xsl:for-each select="Column">
											if (Columns.<xsl:value-of select="@columnName"/> == (Columns.<xsl:value-of select="@columnName"/> &amp; columns))<br/>
											qry.Append("<xsl:value-of select="@columnName"/>,");<br/>
										</xsl:for-each>

										qry.Replace(',', ' ', qry.Length - 1,1);<br/>
										qry.Append("from <xsl:value-of select="@name"/> ");<br/>
										<br/>
										if (where != null &amp;&amp; where.Trim().Length > 0)<br/>
										{<br/>
										qry.Append(" where ");<br/>
										qry.Append(where); ;<br/>
										}<br/>
										<br/>
										if (conn.State != ConnectionState.Open)<br/>
										conn.Open();<br/>
										IDbCommand cmd = conn.CreateCommand();<br/>
										cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL  READ UNCOMMITTED ";<br/>
										cmd.ExecuteNonQuery();<br/>
										cmd.CommandText = qry.ToString();<br/>

										return new <xsl:value-of select="@className"/>Reader(cmd.ExecuteReader(), conn, columns);<br/>
										}<br/>
										<br/>
										static public <xsl:value-of select="@className"/>Reader ExecuteReader(string where,Columns columns)<br/>
										{<br/>
										return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);<br/>
										}<br/>
										<br/>
									</xsl:if>

									/// <summary>
										<br/>
										/// should be used when u have connection like in case of transaction<br/>
									</summary><br/>
									/// <param name="where"></param><br/>
									/// <param name="conn"></param><br/>
									/// <returns></returns><br/>
									public static <xsl:value-of select="@className"/>Reader ExecuteReader(string where,IDbConnection conn)<br/>
									{<br/>
									if (conn.State != ConnectionState.Open)<br/>
									conn.Open();<br/>

									IDbCommand cmd = conn.CreateCommand();<br/>
									cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL  READ UNCOMMITTED";<br/>
									cmd.ExecuteNonQuery();<br/>

									cmd.CommandText = "Select  
									<xsl:for-each select="Column">
										<xsl:value-of select="@columnName"/>
										<xsl:if test="position()!=last()">,</xsl:if>
									</xsl:for-each>
									   from   <xsl:value-of select="@name"/> ";<br/>
									<![CDATA[if (where != null && where.Trim().Length > 0)]]><br/>
									cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);<br/>
									<br/>

									return new <xsl:value-of select="@className"/>Reader(cmd.ExecuteReader(), conn);<br/>
									}<br/>

									<br/>

									static public <xsl:value-of select="@className"/>Reader ExecuteReader(string where)<br/>
									{<br/>
									return ExecuteReader(where, ConnectionFactory.GetNewConnection());<br/>
									}<br/>
									<br/>
									public static <xsl:value-of select="concat(' ',@className,' ')"/>Load<xsl:value-of select="@className"/>(string where)<br/>
									{<br/>
									<xsl:value-of select="@className"/>Reader reader = <xsl:value-of select="@className"/>.ExecuteReader(where);<br/>
									<xsl:value-of select="concat(@className,' ')"/> _<xsl:value-of select="translate(@className,$up,$lo)"/> = null;<br/>
									if (reader.Read())<br/>
									_<xsl:value-of select="translate(@className,$up,$lo)"/> = reader.Current<xsl:value-of select="@className"/>;<br/>
									reader.Close();<br/>
									return _<xsl:value-of select="translate(@className,$up,$lo)"/>;<br/>
									}<br/>
									<br/>
									public static <xsl:value-of select="concat(' ',@className,' ')"/> Load<xsl:value-of select="@className"/>(string where, IDbConnection conn)<br/>
									{<br/>
									<xsl:value-of select="@className"/>Reader reader = <xsl:value-of select="@className"/>.ExecuteReader(where, conn);<br/>
									<xsl:value-of select="concat(@className,' ')"/> _<xsl:value-of select="translate(@className,$up,$lo)"/> = null;<br/>
									if (reader.Read())<br/>
									_<xsl:value-of select="translate(@className,$up,$lo)"/> = reader.Current<xsl:value-of select="@className"/>;<br/>
									reader.Close(false);<br/>
									return _<xsl:value-of select="translate(@className,$up,$lo)"/>;<br/>
									}<br/>
									<br/>

									<xsl:if test="count(Column[@primaryKey='true']) > 0" >
										public static <xsl:value-of select="concat(' ',@className,' ')"/> Load<xsl:value-of select="@className"/>ByPk(
										<xsl:for-each select="Column[@primaryKey='true']">
											<xsl:value-of select="concat(@dataType,' ',@name)"/>
											<xsl:if test="position()!=last()">,</xsl:if>
										</xsl:for-each>
										)<br/>
										{<br/>
										return Load<xsl:value-of select="@className"/>(
										"
										<xsl:for-each select="Column[@primaryKey='true']">
											<xsl:choose>
												<xsl:when test="@typeName='string'">
													<xsl:value-of select="@columnName"/>='"+<xsl:value-of select="@name"/>+"'"
												</xsl:when>
												<xsl:when test="@dataType='DateTime'">
													<xsl:value-of select="@columnName"/>=Convert(datetime,'"+<xsl:value-of select="@name"/>.ToString("yyyy-MM-dd HH:mm:ss.fff")+"',121)"
												</xsl:when>
												<xsl:otherwise>
													<xsl:value-of select="@columnName"/>="+<xsl:value-of select="@name"/>
												</xsl:otherwise>
											</xsl:choose>
											<xsl:if test="position()!=last()">+" and </xsl:if>
										</xsl:for-each>
										);<br/>
										}<br/>
										<br/>
									</xsl:if>

									<xsl:if test="count(Column[@primaryKey='true']) > 0" >
										public static <xsl:value-of select="concat(' ',@className,' ')"/> Load<xsl:value-of select="@className"/>ByPk(
										<xsl:for-each select="Column[@primaryKey='true']">
											<xsl:value-of select="concat(@dataType,' ',@name)"/>
											<xsl:if test="position()!=last()">,</xsl:if>
										</xsl:for-each>
										, IDbConnection conn)<br/>
										{<br/>
										return Load<xsl:value-of select="@className"/>("          <xsl:for-each select="Column[@primaryKey='true']">
											<xsl:choose>
												<xsl:when test="@typeName='string'">
													<xsl:value-of select="@columnName"/>='"+<xsl:value-of select="@name"/>+"'"
												</xsl:when>
												<xsl:when test="@dataType='DateTime'">
													<xsl:value-of select="@columnName"/>=Convert(datetime,'"+<xsl:value-of select="@name"/>.ToString("yyyy-MM-dd HH:mm:ss.fff")+"',121)"
												</xsl:when>
												<xsl:otherwise>
													<xsl:value-of select="@columnName"/>="+<xsl:value-of select="@name"/>
												</xsl:otherwise>
											</xsl:choose>
											<xsl:if test="position()!=last()">+" and </xsl:if>
										</xsl:for-each>
										, conn);<br/>
										}<br/>
									</xsl:if>

									<br/>
									public void Save()<br/>
									{<br/>
									if (<xsl:for-each select="Column">
										<xsl:value-of select="@name"/>Changed
										<xsl:if test="position()!=last()"> || </xsl:if>
									</xsl:for-each>)<br/>
									ExcuteSave(ConnectionFactory.GetNewConnection().CreateCommand());<br/>
									}<br/>
									<br/>
									public void Save(IDbConnection conn,IDbTransaction trx)<br/>
									{<br/>
									IDbCommand cmd = conn.CreateCommand();<br/>
									cmd.Transaction = trx;<br/>
									ExcuteSave(cmd);<br/>
									}<br/>
									<br/>
									public void Save(IDbConnection conn)<br/>
									{<br/>
									IDbCommand cmd = conn.CreateCommand();<br/>
									ExcuteSave(cmd);<br/>
									}<br/>
									<br/>


									/// an opened connection<br/>
									private void ExcuteSave(IDbCommand cmd)
									{<br/>
									if (<xsl:for-each select="Column">
										<xsl:value-of select="@name"/>Changed
										<xsl:if test="position()!=last()"> || </xsl:if>
									</xsl:for-each> )<br/>
									{<br/>

									StringBuilder qry = new StringBuilder(500);<br/>
									<br/>
									if (this.isNewEntity)<br/>
									{<br/>

									qry.Append(@"insert into <xsl:value-of select="@name"/>(
									<xsl:for-each select="Column">
										<xsl:value-of select="@columnName"/>
										<xsl:if test="position()!=last()">,</xsl:if>
									</xsl:for-each>
									) values(");<br/>
									<xsl:for-each select="Column">
										<xsl:choose>
											<xsl:when test="@autoNumber='true'">
												lock (ConnectionFactory.connectionString)
												{
												this.<xsl:value-of  select="@name"/> =
												<xsl:if test="@dataType='short'">(short)</xsl:if>
												<xsl:if test="@dataType='byte'">(byte)</xsl:if>
												ConnectionFactory.GetNextId();<br/>
												qry.Append(this.<xsl:value-of  select="@name"/>);<br/>
												}
												<xsl:if test="position()!=last()">
													qry.Append(",");<br/>
												</xsl:if>
											</xsl:when>
											<xsl:otherwise>
												<xsl:if test="position()!=last()">
													qry.Append(<xsl:value-of select="@name"/>DbString+",");<br/>
												</xsl:if>
												<xsl:if test="position()=last()">
													qry.Append(<xsl:value-of select="@name"/>DbString);<br/>
												</xsl:if>
											</xsl:otherwise>
										</xsl:choose>
									</xsl:for-each>
									qry.Append(");");<br/>
									<br/>
									}<br/>
									else<br/>
									{<br/>
									<xsl:if test="count(Column[@primaryKey='true'])=0">
										throw new Exception("No primary key is defined, can not update <xsl:value-of select="@name"/>!");<br/>
									</xsl:if>

									<xsl:if test="count(Column[@primaryKey='true'])>0">
										if (!(<xsl:for-each select="Column">
											<xsl:value-of select="@name"/>Changed
											<xsl:if test="position()!=last()"> || </xsl:if>
										</xsl:for-each>))<br/>
										return;<br/>

										qry.Append("UPDATE <xsl:value-of select="@name"/> set ");
										<xsl:for-each select="Column[@primaryKey='false']">
											if (
											<xsl:value-of select="@name"/>Changed
											)<br/>
											{<br/>
											qry.Append("<xsl:value-of select="@columnName"/> ="+<xsl:value-of select="@name"/>DbString);<br/>
											qry.Append(",");<br/>
											}<br/>
											<br/>
										</xsl:for-each>
										<br/>
										qry.Replace(',', ' ', qry.Length - 1,1);<br/>
										qry.Append(" where ");<br/>
									</xsl:if>
									<xsl:for-each select="Column[@primaryKey='true']">
										<xsl:choose>
											<xsl:when test="position()=1">
												qry.Append("<xsl:value-of select="@columnName"/> = "+<xsl:value-of select="@name"/>DbString);<br/>
											</xsl:when>
											<xsl:otherwise>
												qry.Append(" and <xsl:value-of select="@columnName"/> = "+<xsl:value-of select="@name"/>DbString);<br/>
											</xsl:otherwise>
										</xsl:choose>
									</xsl:for-each>
									}<br/>
									<xsl:for-each select="Column[@dataType='byte[]']">
										if (
										<xsl:value-of select="@name"/>Changed
										)<br/>
										{<br/>
										IDbDataParameter dbParam_<xsl:value-of select="@name"/> = cmd.CreateParameter();<br/>
										cmd.Parameters.Add(dbParam_<xsl:value-of select="@name"/>);<br/>
										dbParam_<xsl:value-of select="@name"/>.ParameterName = "@<xsl:value-of select="@name"/>";<br/>
										dbParam_<xsl:value-of select="@name"/>.Value = this.<xsl:value-of select="@name"/>;<br/>
										}<br/>
									</xsl:for-each>
									<br/>
									cmd.CommandText = qry.ToString();<br/>
									bool closeConnection = false;<br/>
									if (cmd.Connection.State == ConnectionState.Closed)<br/>
									{<br/>
									cmd.Connection.Open();<br/>
									closeConnection = true;<br/>
									}<br/>
									if (this.isNewEntity)<br/>
									{<br/>
									cmd.ExecuteNonQuery();<br/>

									isNewEntity = false;<br/>
									}<br/>
									else<br/>
									cmd.ExecuteNonQuery();<br/>
									<br/>
									if (closeConnection)<br/>
									cmd.Connection.Close();<br/>
									}<br/>
									}<br/>
									<br/>
									public void Delete()<br/>
									{<br/>
									Delete(ConnectionFactory.GetNewConnection());<br/>
									}<br/>
									<br/>
									public void Delete(IDbConnection conn)<br/>
									{<br/>
									<xsl:if test="count(Column[@primaryKey='true'])=0">
										throw new Exception("Could not delete because no primary key is defined");<br/>
									</xsl:if>
									<xsl:if test="count(Column[@primaryKey='true'])>0">
										IDbCommand cmd = conn.CreateCommand();<br/>
										cmd.CommandText = "DELETE <xsl:value-of select="concat(' ',@name,' ')"/> where 
										<xsl:for-each select="Column[@primaryKey='true']">
											<xsl:value-of select="@columnName"/>
											= "+ <xsl:value-of select="@name"/>
											<xsl:if test="position()!=last()"> +" and </xsl:if>
										</xsl:for-each>;<br/>

										if (conn.State == ConnectionState.Closed)<br/>
										{<br/>
										cmd.Connection.Open();<br/>
										cmd.ExecuteNonQuery();<br/>
										cmd.Connection.Close();<br/>
										}<br/>
										else<br/>
										cmd.ExecuteNonQuery();<br/>
									</xsl:if>
									}<br/>
									<br/>

									public static void Delete<xsl:value-of select="@className"/>s(string where)<br/>
									{<br/>
									ConnectionFactory.ExecuteQuery("delete <xsl:value-of select="@name"/> where " + where);<br/>
									}<br/>

									<br/>
									#endregion<br/>

									<xsl:if test="not(count(Column) >  500)">
										#region Columns enum<br/>
										public enum Columns<xsl:if test="not(count(Column)>32)">:uint</xsl:if><xsl:if test="count(Column)>32">:ulong</xsl:if><br/>
										{<br/>
										<xsl:for-each select="Column">
											<xsl:value-of select="@columnName"/>= <xsl:value-of select="@columnId" />
											<xsl:if test="position()!=last()">,</xsl:if><br/>
										</xsl:for-each>
										}<br/>
										#endregion<br/>
                    public DataTable BulkSave(List&lt;<xsl:value-of select="@className"/>>
										dataArray,SqlTransaction dbTrx)<br/>
										{<br/>
										DataTable dt = new DataTable();<br/>
										CreateDataTable(dt);<br/>
										AddToDataTable(dataArray, ref dt);<br/>
										SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);<br/>
										bulk.DestinationTableName = "<xsl:value-of select="@name"/>";<br/>
										bulk.WriteToServer(dt);
                    return dt;<br/>

										}<br/>


                    
                    
										public void CreateDataTable(DataTable dt)<br/>
										{<br/>
										string[] colNames = Enum.GetNames(typeof(<xsl:value-of select="@className"/>.Columns));<br/>
										for (int i = 0; i &lt; colNames.Length; i++)<br/>
										{<br/>
										dt.Columns.Add(colNames[i]);<br/>
										}<br/>
										}<br/>

										public void AddToDataTable(List &lt;<xsl:value-of select="@className"/>>
										transList,ref DataTable dt)<br/>
										{<br/>
										foreach (<xsl:value-of select="@className"/> tran in transList)<br/>
										{<br/>
										DataRow Row;<br/>
										Row = dt.NewRow();<br/>
										<xsl:for-each select="Column">
											<xsl:choose>
												<xsl:when test="@autoNumber='true'">
													Row["<xsl:value-of select="@name"/>"] =ConnectionFactory.GetNextId();<br/>
												</xsl:when>
												<xsl:otherwise>
													Row["<xsl:value-of select="@name"/>"] = tran.<xsl:value-of select="@propertyName"/>;<br/>
												</xsl:otherwise>
											</xsl:choose>

										</xsl:for-each>
										dt.Rows.Add(Row);<br/>
										}

									</xsl:if>

									}<br/>
									}<br/>
									}<br/>
								</div>
							</td>
						</tr>

					</xsl:for-each>

				</TABLE>
			</BODY>
		</HTML>
	</xsl:template>
</xsl:stylesheet>