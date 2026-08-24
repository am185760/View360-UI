

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
 public class CcmsCounterMismatched
 {
 bool isNewEntity = true;
 bool IsNewEntity
 {
 get { return isNewEntity; }
 }

 public CcmsCounterMismatched() { }
 public CcmsCounterMismatched( int last_total_type1,int last_total_type2,int last_total_type3,int last_total_type4,int last_remaining_type1,int last_remaining_type2,int last_remaining_type3,int last_remaining_type4,int last_dispensed_type1,int last_dispensed_type2,int last_dispensed_type3,int last_dispensed_type4,int last_purged_type1,int last_purged_type2,int last_purged_type3,int last_purged_type4,int current_total_type1,int current_total_type2,int current_total_type3,int current_total_type4,int current_remaining_type1,int current_remaining_type2,int current_remaining_type3,int current_remaining_type4,int current_dispensed_type1,int current_dispensed_type2,int current_dispensed_type3,int current_dispensed_type4,int current_purged_type1,int current_purged_type2,int current_purged_type3,int current_purged_type4,DateTime generated_at,DateTime counter_mismatched_datetime,int atm_id )
 {
 this.last_total_type1 = last_total_type1;
 this.last_total_type1Changed = true;
 this.last_total_type2 = last_total_type2;
 this.last_total_type2Changed = true;
 this.last_total_type3 = last_total_type3;
 this.last_total_type3Changed = true;
 this.last_total_type4 = last_total_type4;
 this.last_total_type4Changed = true;
 this.last_remaining_type1 = last_remaining_type1;
 this.last_remaining_type1Changed = true;
 this.last_remaining_type2 = last_remaining_type2;
 this.last_remaining_type2Changed = true;
 this.last_remaining_type3 = last_remaining_type3;
 this.last_remaining_type3Changed = true;
 this.last_remaining_type4 = last_remaining_type4;
 this.last_remaining_type4Changed = true;
 this.last_dispensed_type1 = last_dispensed_type1;
 this.last_dispensed_type1Changed = true;
 this.last_dispensed_type2 = last_dispensed_type2;
 this.last_dispensed_type2Changed = true;
 this.last_dispensed_type3 = last_dispensed_type3;
 this.last_dispensed_type3Changed = true;
 this.last_dispensed_type4 = last_dispensed_type4;
 this.last_dispensed_type4Changed = true;
 this.last_purged_type1 = last_purged_type1;
 this.last_purged_type1Changed = true;
 this.last_purged_type2 = last_purged_type2;
 this.last_purged_type2Changed = true;
 this.last_purged_type3 = last_purged_type3;
 this.last_purged_type3Changed = true;
 this.last_purged_type4 = last_purged_type4;
 this.last_purged_type4Changed = true;
 this.current_total_type1 = current_total_type1;
 this.current_total_type1Changed = true;
 this.current_total_type2 = current_total_type2;
 this.current_total_type2Changed = true;
 this.current_total_type3 = current_total_type3;
 this.current_total_type3Changed = true;
 this.current_total_type4 = current_total_type4;
 this.current_total_type4Changed = true;
 this.current_remaining_type1 = current_remaining_type1;
 this.current_remaining_type1Changed = true;
 this.current_remaining_type2 = current_remaining_type2;
 this.current_remaining_type2Changed = true;
 this.current_remaining_type3 = current_remaining_type3;
 this.current_remaining_type3Changed = true;
 this.current_remaining_type4 = current_remaining_type4;
 this.current_remaining_type4Changed = true;
 this.current_dispensed_type1 = current_dispensed_type1;
 this.current_dispensed_type1Changed = true;
 this.current_dispensed_type2 = current_dispensed_type2;
 this.current_dispensed_type2Changed = true;
 this.current_dispensed_type3 = current_dispensed_type3;
 this.current_dispensed_type3Changed = true;
 this.current_dispensed_type4 = current_dispensed_type4;
 this.current_dispensed_type4Changed = true;
 this.current_purged_type1 = current_purged_type1;
 this.current_purged_type1Changed = true;
 this.current_purged_type2 = current_purged_type2;
 this.current_purged_type2Changed = true;
 this.current_purged_type3 = current_purged_type3;
 this.current_purged_type3Changed = true;
 this.current_purged_type4 = current_purged_type4;
 this.current_purged_type4Changed = true;
 this.generated_at = generated_at;
 this.generated_atChanged = true;
 this.counter_mismatched_datetime = counter_mismatched_datetime;
 this.counter_mismatched_datetimeChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 }
 private CcmsCounterMismatched( int ccms_counter_mismatched_id,int last_total_type1,int last_total_type2,int last_total_type3,int last_total_type4,int last_remaining_type1,int last_remaining_type2,int last_remaining_type3,int last_remaining_type4,int last_dispensed_type1,int last_dispensed_type2,int last_dispensed_type3,int last_dispensed_type4,int last_purged_type1,int last_purged_type2,int last_purged_type3,int last_purged_type4,int current_total_type1,int current_total_type2,int current_total_type3,int current_total_type4,int current_remaining_type1,int current_remaining_type2,int current_remaining_type3,int current_remaining_type4,int current_dispensed_type1,int current_dispensed_type2,int current_dispensed_type3,int current_dispensed_type4,int current_purged_type1,int current_purged_type2,int current_purged_type3,int current_purged_type4,DateTime generated_at,DateTime counter_mismatched_datetime,int atm_id )
 {
 this.ccms_counter_mismatched_id = ccms_counter_mismatched_id;
 this.ccms_counter_mismatched_idChanged = true;
 this.last_total_type1 = last_total_type1;
 this.last_total_type1Changed = true;
 this.last_total_type2 = last_total_type2;
 this.last_total_type2Changed = true;
 this.last_total_type3 = last_total_type3;
 this.last_total_type3Changed = true;
 this.last_total_type4 = last_total_type4;
 this.last_total_type4Changed = true;
 this.last_remaining_type1 = last_remaining_type1;
 this.last_remaining_type1Changed = true;
 this.last_remaining_type2 = last_remaining_type2;
 this.last_remaining_type2Changed = true;
 this.last_remaining_type3 = last_remaining_type3;
 this.last_remaining_type3Changed = true;
 this.last_remaining_type4 = last_remaining_type4;
 this.last_remaining_type4Changed = true;
 this.last_dispensed_type1 = last_dispensed_type1;
 this.last_dispensed_type1Changed = true;
 this.last_dispensed_type2 = last_dispensed_type2;
 this.last_dispensed_type2Changed = true;
 this.last_dispensed_type3 = last_dispensed_type3;
 this.last_dispensed_type3Changed = true;
 this.last_dispensed_type4 = last_dispensed_type4;
 this.last_dispensed_type4Changed = true;
 this.last_purged_type1 = last_purged_type1;
 this.last_purged_type1Changed = true;
 this.last_purged_type2 = last_purged_type2;
 this.last_purged_type2Changed = true;
 this.last_purged_type3 = last_purged_type3;
 this.last_purged_type3Changed = true;
 this.last_purged_type4 = last_purged_type4;
 this.last_purged_type4Changed = true;
 this.current_total_type1 = current_total_type1;
 this.current_total_type1Changed = true;
 this.current_total_type2 = current_total_type2;
 this.current_total_type2Changed = true;
 this.current_total_type3 = current_total_type3;
 this.current_total_type3Changed = true;
 this.current_total_type4 = current_total_type4;
 this.current_total_type4Changed = true;
 this.current_remaining_type1 = current_remaining_type1;
 this.current_remaining_type1Changed = true;
 this.current_remaining_type2 = current_remaining_type2;
 this.current_remaining_type2Changed = true;
 this.current_remaining_type3 = current_remaining_type3;
 this.current_remaining_type3Changed = true;
 this.current_remaining_type4 = current_remaining_type4;
 this.current_remaining_type4Changed = true;
 this.current_dispensed_type1 = current_dispensed_type1;
 this.current_dispensed_type1Changed = true;
 this.current_dispensed_type2 = current_dispensed_type2;
 this.current_dispensed_type2Changed = true;
 this.current_dispensed_type3 = current_dispensed_type3;
 this.current_dispensed_type3Changed = true;
 this.current_dispensed_type4 = current_dispensed_type4;
 this.current_dispensed_type4Changed = true;
 this.current_purged_type1 = current_purged_type1;
 this.current_purged_type1Changed = true;
 this.current_purged_type2 = current_purged_type2;
 this.current_purged_type2Changed = true;
 this.current_purged_type3 = current_purged_type3;
 this.current_purged_type3Changed = true;
 this.current_purged_type4 = current_purged_type4;
 this.current_purged_type4Changed = true;
 this.generated_at = generated_at;
 this.generated_atChanged = true;
 this.counter_mismatched_datetime = counter_mismatched_datetime;
 this.counter_mismatched_datetimeChanged = true;
 this.atm_id = atm_id;
 this.atm_idChanged = true;
 }

 #region members and properties for columns

 #region CcmsCounterMismatchedId
 private bool ccms_counter_mismatched_idChanged = false;
 private int ccms_counter_mismatched_id;
 public int CcmsCounterMismatchedId
 {
 get { return ccms_counter_mismatched_id; }
 set { 
ccms_counter_mismatched_id = value;
ccms_counter_mismatched_idChanged = true;
 }
 }
 private string ccms_counter_mismatched_idDbString
 {
 get
 {
 return ccms_counter_mismatched_id.ToString();
 }
 }
 #endregion
 #region LastTotalType1
 private bool last_total_type1Changed = false;
 private int last_total_type1;
 public int LastTotalType1
 {
 get { return last_total_type1; }
 set { 
last_total_type1 = value;
last_total_type1Changed = true;
 }
 }
 private string last_total_type1DbString
 {
 get
 {
 return last_total_type1.ToString();
 }
 }
 #endregion
 #region LastTotalType2
 private bool last_total_type2Changed = false;
 private int last_total_type2;
 public int LastTotalType2
 {
 get { return last_total_type2; }
 set { 
last_total_type2 = value;
last_total_type2Changed = true;
 }
 }
 private string last_total_type2DbString
 {
 get
 {
 return last_total_type2.ToString();
 }
 }
 #endregion
 #region LastTotalType3
 private bool last_total_type3Changed = false;
 private int last_total_type3;
 public int LastTotalType3
 {
 get { return last_total_type3; }
 set { 
last_total_type3 = value;
last_total_type3Changed = true;
 }
 }
 private string last_total_type3DbString
 {
 get
 {
 return last_total_type3.ToString();
 }
 }
 #endregion
 #region LastTotalType4
 private bool last_total_type4Changed = false;
 private int last_total_type4;
 public int LastTotalType4
 {
 get { return last_total_type4; }
 set { 
last_total_type4 = value;
last_total_type4Changed = true;
 }
 }
 private string last_total_type4DbString
 {
 get
 {
 return last_total_type4.ToString();
 }
 }
 #endregion
 #region LastRemainingType1
 private bool last_remaining_type1Changed = false;
 private int last_remaining_type1;
 public int LastRemainingType1
 {
 get { return last_remaining_type1; }
 set { 
last_remaining_type1 = value;
last_remaining_type1Changed = true;
 }
 }
 private string last_remaining_type1DbString
 {
 get
 {
 return last_remaining_type1.ToString();
 }
 }
 #endregion
 #region LastRemainingType2
 private bool last_remaining_type2Changed = false;
 private int last_remaining_type2;
 public int LastRemainingType2
 {
 get { return last_remaining_type2; }
 set { 
last_remaining_type2 = value;
last_remaining_type2Changed = true;
 }
 }
 private string last_remaining_type2DbString
 {
 get
 {
 return last_remaining_type2.ToString();
 }
 }
 #endregion
 #region LastRemainingType3
 private bool last_remaining_type3Changed = false;
 private int last_remaining_type3;
 public int LastRemainingType3
 {
 get { return last_remaining_type3; }
 set { 
last_remaining_type3 = value;
last_remaining_type3Changed = true;
 }
 }
 private string last_remaining_type3DbString
 {
 get
 {
 return last_remaining_type3.ToString();
 }
 }
 #endregion
 #region LastRemainingType4
 private bool last_remaining_type4Changed = false;
 private int last_remaining_type4;
 public int LastRemainingType4
 {
 get { return last_remaining_type4; }
 set { 
last_remaining_type4 = value;
last_remaining_type4Changed = true;
 }
 }
 private string last_remaining_type4DbString
 {
 get
 {
 return last_remaining_type4.ToString();
 }
 }
 #endregion
 #region LastDispensedType1
 private bool last_dispensed_type1Changed = false;
 private int last_dispensed_type1;
 public int LastDispensedType1
 {
 get { return last_dispensed_type1; }
 set { 
last_dispensed_type1 = value;
last_dispensed_type1Changed = true;
 }
 }
 private string last_dispensed_type1DbString
 {
 get
 {
 return last_dispensed_type1.ToString();
 }
 }
 #endregion
 #region LastDispensedType2
 private bool last_dispensed_type2Changed = false;
 private int last_dispensed_type2;
 public int LastDispensedType2
 {
 get { return last_dispensed_type2; }
 set { 
last_dispensed_type2 = value;
last_dispensed_type2Changed = true;
 }
 }
 private string last_dispensed_type2DbString
 {
 get
 {
 return last_dispensed_type2.ToString();
 }
 }
 #endregion
 #region LastDispensedType3
 private bool last_dispensed_type3Changed = false;
 private int last_dispensed_type3;
 public int LastDispensedType3
 {
 get { return last_dispensed_type3; }
 set { 
last_dispensed_type3 = value;
last_dispensed_type3Changed = true;
 }
 }
 private string last_dispensed_type3DbString
 {
 get
 {
 return last_dispensed_type3.ToString();
 }
 }
 #endregion
 #region LastDispensedType4
 private bool last_dispensed_type4Changed = false;
 private int last_dispensed_type4;
 public int LastDispensedType4
 {
 get { return last_dispensed_type4; }
 set { 
last_dispensed_type4 = value;
last_dispensed_type4Changed = true;
 }
 }
 private string last_dispensed_type4DbString
 {
 get
 {
 return last_dispensed_type4.ToString();
 }
 }
 #endregion
 #region LastPurgedType1
 private bool last_purged_type1Changed = false;
 private int last_purged_type1;
 public int LastPurgedType1
 {
 get { return last_purged_type1; }
 set { 
last_purged_type1 = value;
last_purged_type1Changed = true;
 }
 }
 private string last_purged_type1DbString
 {
 get
 {
 return last_purged_type1.ToString();
 }
 }
 #endregion
 #region LastPurgedType2
 private bool last_purged_type2Changed = false;
 private int last_purged_type2;
 public int LastPurgedType2
 {
 get { return last_purged_type2; }
 set { 
last_purged_type2 = value;
last_purged_type2Changed = true;
 }
 }
 private string last_purged_type2DbString
 {
 get
 {
 return last_purged_type2.ToString();
 }
 }
 #endregion
 #region LastPurgedType3
 private bool last_purged_type3Changed = false;
 private int last_purged_type3;
 public int LastPurgedType3
 {
 get { return last_purged_type3; }
 set { 
last_purged_type3 = value;
last_purged_type3Changed = true;
 }
 }
 private string last_purged_type3DbString
 {
 get
 {
 return last_purged_type3.ToString();
 }
 }
 #endregion
 #region LastPurgedType4
 private bool last_purged_type4Changed = false;
 private int last_purged_type4;
 public int LastPurgedType4
 {
 get { return last_purged_type4; }
 set { 
last_purged_type4 = value;
last_purged_type4Changed = true;
 }
 }
 private string last_purged_type4DbString
 {
 get
 {
 return last_purged_type4.ToString();
 }
 }
 #endregion
 #region CurrentTotalType1
 private bool current_total_type1Changed = false;
 private int current_total_type1;
 public int CurrentTotalType1
 {
 get { return current_total_type1; }
 set { 
current_total_type1 = value;
current_total_type1Changed = true;
 }
 }
 private string current_total_type1DbString
 {
 get
 {
 return current_total_type1.ToString();
 }
 }
 #endregion
 #region CurrentTotalType2
 private bool current_total_type2Changed = false;
 private int current_total_type2;
 public int CurrentTotalType2
 {
 get { return current_total_type2; }
 set { 
current_total_type2 = value;
current_total_type2Changed = true;
 }
 }
 private string current_total_type2DbString
 {
 get
 {
 return current_total_type2.ToString();
 }
 }
 #endregion
 #region CurrentTotalType3
 private bool current_total_type3Changed = false;
 private int current_total_type3;
 public int CurrentTotalType3
 {
 get { return current_total_type3; }
 set { 
current_total_type3 = value;
current_total_type3Changed = true;
 }
 }
 private string current_total_type3DbString
 {
 get
 {
 return current_total_type3.ToString();
 }
 }
 #endregion
 #region CurrentTotalType4
 private bool current_total_type4Changed = false;
 private int current_total_type4;
 public int CurrentTotalType4
 {
 get { return current_total_type4; }
 set { 
current_total_type4 = value;
current_total_type4Changed = true;
 }
 }
 private string current_total_type4DbString
 {
 get
 {
 return current_total_type4.ToString();
 }
 }
 #endregion
 #region CurrentRemainingType1
 private bool current_remaining_type1Changed = false;
 private int current_remaining_type1;
 public int CurrentRemainingType1
 {
 get { return current_remaining_type1; }
 set { 
current_remaining_type1 = value;
current_remaining_type1Changed = true;
 }
 }
 private string current_remaining_type1DbString
 {
 get
 {
 return current_remaining_type1.ToString();
 }
 }
 #endregion
 #region CurrentRemainingType2
 private bool current_remaining_type2Changed = false;
 private int current_remaining_type2;
 public int CurrentRemainingType2
 {
 get { return current_remaining_type2; }
 set { 
current_remaining_type2 = value;
current_remaining_type2Changed = true;
 }
 }
 private string current_remaining_type2DbString
 {
 get
 {
 return current_remaining_type2.ToString();
 }
 }
 #endregion
 #region CurrentRemainingType3
 private bool current_remaining_type3Changed = false;
 private int current_remaining_type3;
 public int CurrentRemainingType3
 {
 get { return current_remaining_type3; }
 set { 
current_remaining_type3 = value;
current_remaining_type3Changed = true;
 }
 }
 private string current_remaining_type3DbString
 {
 get
 {
 return current_remaining_type3.ToString();
 }
 }
 #endregion
 #region CurrentRemainingType4
 private bool current_remaining_type4Changed = false;
 private int current_remaining_type4;
 public int CurrentRemainingType4
 {
 get { return current_remaining_type4; }
 set { 
current_remaining_type4 = value;
current_remaining_type4Changed = true;
 }
 }
 private string current_remaining_type4DbString
 {
 get
 {
 return current_remaining_type4.ToString();
 }
 }
 #endregion
 #region CurrentDispensedType1
 private bool current_dispensed_type1Changed = false;
 private int current_dispensed_type1;
 public int CurrentDispensedType1
 {
 get { return current_dispensed_type1; }
 set { 
current_dispensed_type1 = value;
current_dispensed_type1Changed = true;
 }
 }
 private string current_dispensed_type1DbString
 {
 get
 {
 return current_dispensed_type1.ToString();
 }
 }
 #endregion
 #region CurrentDispensedType2
 private bool current_dispensed_type2Changed = false;
 private int current_dispensed_type2;
 public int CurrentDispensedType2
 {
 get { return current_dispensed_type2; }
 set { 
current_dispensed_type2 = value;
current_dispensed_type2Changed = true;
 }
 }
 private string current_dispensed_type2DbString
 {
 get
 {
 return current_dispensed_type2.ToString();
 }
 }
 #endregion
 #region CurrentDispensedType3
 private bool current_dispensed_type3Changed = false;
 private int current_dispensed_type3;
 public int CurrentDispensedType3
 {
 get { return current_dispensed_type3; }
 set { 
current_dispensed_type3 = value;
current_dispensed_type3Changed = true;
 }
 }
 private string current_dispensed_type3DbString
 {
 get
 {
 return current_dispensed_type3.ToString();
 }
 }
 #endregion
 #region CurrentDispensedType4
 private bool current_dispensed_type4Changed = false;
 private int current_dispensed_type4;
 public int CurrentDispensedType4
 {
 get { return current_dispensed_type4; }
 set { 
current_dispensed_type4 = value;
current_dispensed_type4Changed = true;
 }
 }
 private string current_dispensed_type4DbString
 {
 get
 {
 return current_dispensed_type4.ToString();
 }
 }
 #endregion
 #region CurrentPurgedType1
 private bool current_purged_type1Changed = false;
 private int current_purged_type1;
 public int CurrentPurgedType1
 {
 get { return current_purged_type1; }
 set { 
current_purged_type1 = value;
current_purged_type1Changed = true;
 }
 }
 private string current_purged_type1DbString
 {
 get
 {
 return current_purged_type1.ToString();
 }
 }
 #endregion
 #region CurrentPurgedType2
 private bool current_purged_type2Changed = false;
 private int current_purged_type2;
 public int CurrentPurgedType2
 {
 get { return current_purged_type2; }
 set { 
current_purged_type2 = value;
current_purged_type2Changed = true;
 }
 }
 private string current_purged_type2DbString
 {
 get
 {
 return current_purged_type2.ToString();
 }
 }
 #endregion
 #region CurrentPurgedType3
 private bool current_purged_type3Changed = false;
 private int current_purged_type3;
 public int CurrentPurgedType3
 {
 get { return current_purged_type3; }
 set { 
current_purged_type3 = value;
current_purged_type3Changed = true;
 }
 }
 private string current_purged_type3DbString
 {
 get
 {
 return current_purged_type3.ToString();
 }
 }
 #endregion
 #region CurrentPurgedType4
 private bool current_purged_type4Changed = false;
 private int current_purged_type4;
 public int CurrentPurgedType4
 {
 get { return current_purged_type4; }
 set { 
current_purged_type4 = value;
current_purged_type4Changed = true;
 }
 }
 private string current_purged_type4DbString
 {
 get
 {
 return current_purged_type4.ToString();
 }
 }
 #endregion
 #region GeneratedAt
 private bool generated_atChanged = false;
 private DateTime generated_at;
 public DateTime GeneratedAt
 {
 get { return generated_at; }
 set { 
generated_at = value;
generated_atChanged = true;
 }
 }
 private string generated_atDbString
 {
 get
 {
 return string.Format("Convert(datetime,'{0}',121)",generated_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
 }
 }
 #endregion
 #region CounterMismatchedDatetime
 private bool counter_mismatched_datetimeChanged = false;
 private DateTime counter_mismatched_datetime;
 public DateTime CounterMismatchedDatetime
 {
 get { return counter_mismatched_datetime; }
 set { 
counter_mismatched_datetime = value;
counter_mismatched_datetimeChanged = true;
 }
 }
 private string counter_mismatched_datetimeDbString
 {
 get
 {
 return string.Format("Convert(datetime,'{0}',121)",counter_mismatched_datetime.ToString("yyyy-MM-dd HH:mm:ss:fff"));
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

 #region CcmsCounterMismatchedReader
 public class CcmsCounterMismatchedReader:IEntityReader, IEnumerator, IEnumerable 
 {
 IDataReader reader;
 IDbConnection conn;
CcmsCounterMismatched currentCcmsCounterMismatched;
 Columns columns;
 bool partialRead = false;
 private CcmsCounterMismatchedReader() { }
 /// 
 ///
 ///

 /// 
 /// so that it can close connection on ATMReader.Close()
 public CcmsCounterMismatchedReader(IDataReader reader,IDbConnection conn)
 {
 this.reader = reader;
 this.conn = conn;
 }
 public CcmsCounterMismatchedReader(IDataReader reader, IDbConnection conn, Columns columns)
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
 get { return currentCcmsCounterMismatched; }

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
 currentCcmsCounterMismatched = new CcmsCounterMismatched();
 if (partialRead)
 { if ((columns & Columns.ccms_counter_mismatched_id) == Columns.ccms_counter_mismatched_id && reader["ccms_counter_mismatched_id"]!=DBNull.Value)
 currentCcmsCounterMismatched.ccms_counter_mismatched_id =(int) reader["ccms_counter_mismatched_id"]; 
 if ((columns & Columns.last_total_type1) == Columns.last_total_type1 && reader["last_total_type1"]!=DBNull.Value)
 currentCcmsCounterMismatched.last_total_type1 =(int) reader["last_total_type1"]; 
 if ((columns & Columns.last_total_type2) == Columns.last_total_type2 && reader["last_total_type2"]!=DBNull.Value)
 currentCcmsCounterMismatched.last_total_type2 =(int) reader["last_total_type2"]; 
 if ((columns & Columns.last_total_type3) == Columns.last_total_type3 && reader["last_total_type3"]!=DBNull.Value)
 currentCcmsCounterMismatched.last_total_type3 =(int) reader["last_total_type3"]; 
 if ((columns & Columns.last_total_type4) == Columns.last_total_type4 && reader["last_total_type4"]!=DBNull.Value)
 currentCcmsCounterMismatched.last_total_type4 =(int) reader["last_total_type4"]; 
 if ((columns & Columns.last_remaining_type1) == Columns.last_remaining_type1 && reader["last_remaining_type1"]!=DBNull.Value)
 currentCcmsCounterMismatched.last_remaining_type1 =(int) reader["last_remaining_type1"]; 
 if ((columns & Columns.last_remaining_type2) == Columns.last_remaining_type2 && reader["last_remaining_type2"]!=DBNull.Value)
 currentCcmsCounterMismatched.last_remaining_type2 =(int) reader["last_remaining_type2"]; 
 if ((columns & Columns.last_remaining_type3) == Columns.last_remaining_type3 && reader["last_remaining_type3"]!=DBNull.Value)
 currentCcmsCounterMismatched.last_remaining_type3 =(int) reader["last_remaining_type3"]; 
 if ((columns & Columns.last_remaining_type4) == Columns.last_remaining_type4 && reader["last_remaining_type4"]!=DBNull.Value)
 currentCcmsCounterMismatched.last_remaining_type4 =(int) reader["last_remaining_type4"]; 
 if ((columns & Columns.last_dispensed_type1) == Columns.last_dispensed_type1 && reader["last_dispensed_type1"]!=DBNull.Value)
 currentCcmsCounterMismatched.last_dispensed_type1 =(int) reader["last_dispensed_type1"]; 
 if ((columns & Columns.last_dispensed_type2) == Columns.last_dispensed_type2 && reader["last_dispensed_type2"]!=DBNull.Value)
 currentCcmsCounterMismatched.last_dispensed_type2 =(int) reader["last_dispensed_type2"]; 
 if ((columns & Columns.last_dispensed_type3) == Columns.last_dispensed_type3 && reader["last_dispensed_type3"]!=DBNull.Value)
 currentCcmsCounterMismatched.last_dispensed_type3 =(int) reader["last_dispensed_type3"]; 
 if ((columns & Columns.last_dispensed_type4) == Columns.last_dispensed_type4 && reader["last_dispensed_type4"]!=DBNull.Value)
 currentCcmsCounterMismatched.last_dispensed_type4 =(int) reader["last_dispensed_type4"]; 
 if ((columns & Columns.last_purged_type1) == Columns.last_purged_type1 && reader["last_purged_type1"]!=DBNull.Value)
 currentCcmsCounterMismatched.last_purged_type1 =(int) reader["last_purged_type1"]; 
 if ((columns & Columns.last_purged_type2) == Columns.last_purged_type2 && reader["last_purged_type2"]!=DBNull.Value)
 currentCcmsCounterMismatched.last_purged_type2 =(int) reader["last_purged_type2"]; 
 if ((columns & Columns.last_purged_type3) == Columns.last_purged_type3 && reader["last_purged_type3"]!=DBNull.Value)
 currentCcmsCounterMismatched.last_purged_type3 =(int) reader["last_purged_type3"]; 
 if ((columns & Columns.last_purged_type4) == Columns.last_purged_type4 && reader["last_purged_type4"]!=DBNull.Value)
 currentCcmsCounterMismatched.last_purged_type4 =(int) reader["last_purged_type4"]; 
 if ((columns & Columns.current_total_type1) == Columns.current_total_type1 && reader["current_total_type1"]!=DBNull.Value)
 currentCcmsCounterMismatched.current_total_type1 =(int) reader["current_total_type1"]; 
 if ((columns & Columns.current_total_type2) == Columns.current_total_type2 && reader["current_total_type2"]!=DBNull.Value)
 currentCcmsCounterMismatched.current_total_type2 =(int) reader["current_total_type2"]; 
 if ((columns & Columns.current_total_type3) == Columns.current_total_type3 && reader["current_total_type3"]!=DBNull.Value)
 currentCcmsCounterMismatched.current_total_type3 =(int) reader["current_total_type3"]; 
 if ((columns & Columns.current_total_type4) == Columns.current_total_type4 && reader["current_total_type4"]!=DBNull.Value)
 currentCcmsCounterMismatched.current_total_type4 =(int) reader["current_total_type4"]; 
 if ((columns & Columns.current_remaining_type1) == Columns.current_remaining_type1 && reader["current_remaining_type1"]!=DBNull.Value)
 currentCcmsCounterMismatched.current_remaining_type1 =(int) reader["current_remaining_type1"]; 
 if ((columns & Columns.current_remaining_type2) == Columns.current_remaining_type2 && reader["current_remaining_type2"]!=DBNull.Value)
 currentCcmsCounterMismatched.current_remaining_type2 =(int) reader["current_remaining_type2"]; 
 if ((columns & Columns.current_remaining_type3) == Columns.current_remaining_type3 && reader["current_remaining_type3"]!=DBNull.Value)
 currentCcmsCounterMismatched.current_remaining_type3 =(int) reader["current_remaining_type3"]; 
 if ((columns & Columns.current_remaining_type4) == Columns.current_remaining_type4 && reader["current_remaining_type4"]!=DBNull.Value)
 currentCcmsCounterMismatched.current_remaining_type4 =(int) reader["current_remaining_type4"]; 
 if ((columns & Columns.current_dispensed_type1) == Columns.current_dispensed_type1 && reader["current_dispensed_type1"]!=DBNull.Value)
 currentCcmsCounterMismatched.current_dispensed_type1 =(int) reader["current_dispensed_type1"]; 
 if ((columns & Columns.current_dispensed_type2) == Columns.current_dispensed_type2 && reader["current_dispensed_type2"]!=DBNull.Value)
 currentCcmsCounterMismatched.current_dispensed_type2 =(int) reader["current_dispensed_type2"]; 
 if ((columns & Columns.current_dispensed_type3) == Columns.current_dispensed_type3 && reader["current_dispensed_type3"]!=DBNull.Value)
 currentCcmsCounterMismatched.current_dispensed_type3 =(int) reader["current_dispensed_type3"]; 
 if ((columns & Columns.current_dispensed_type4) == Columns.current_dispensed_type4 && reader["current_dispensed_type4"]!=DBNull.Value)
 currentCcmsCounterMismatched.current_dispensed_type4 =(int) reader["current_dispensed_type4"]; 
 if ((columns & Columns.current_purged_type1) == Columns.current_purged_type1 && reader["current_purged_type1"]!=DBNull.Value)
 currentCcmsCounterMismatched.current_purged_type1 =(int) reader["current_purged_type1"]; 
 if ((columns & Columns.current_purged_type2) == Columns.current_purged_type2 && reader["current_purged_type2"]!=DBNull.Value)
 currentCcmsCounterMismatched.current_purged_type2 =(int) reader["current_purged_type2"]; 
 if ((columns & Columns.current_purged_type3) == Columns.current_purged_type3 && reader["current_purged_type3"]!=DBNull.Value)
 currentCcmsCounterMismatched.current_purged_type3 =(int) reader["current_purged_type3"]; 
 if ((columns & Columns.current_purged_type4) == Columns.current_purged_type4 && reader["current_purged_type4"]!=DBNull.Value)
 currentCcmsCounterMismatched.current_purged_type4 =(int) reader["current_purged_type4"]; 
 if ((columns & Columns.generated_at) == Columns.generated_at && reader["generated_at"]!=DBNull.Value)
 currentCcmsCounterMismatched.generated_at =(DateTime) reader["generated_at"]; 
 if ((columns & Columns.counter_mismatched_datetime) == Columns.counter_mismatched_datetime && reader["counter_mismatched_datetime"]!=DBNull.Value)
 currentCcmsCounterMismatched.counter_mismatched_datetime =(DateTime) reader["counter_mismatched_datetime"]; 
 if ((columns & Columns.atm_id) == Columns.atm_id && reader["atm_id"]!=DBNull.Value)
 currentCcmsCounterMismatched.atm_id =(int) reader["atm_id"]; 

 } else
 {
 if (reader["ccms_counter_mismatched_id"] != DBNull.Value)
 currentCcmsCounterMismatched.ccms_counter_mismatched_id = (int) reader["ccms_counter_mismatched_id"]; 
 if (reader["last_total_type1"] != DBNull.Value)
 currentCcmsCounterMismatched.last_total_type1 = (int) reader["last_total_type1"]; 
 if (reader["last_total_type2"] != DBNull.Value)
 currentCcmsCounterMismatched.last_total_type2 = (int) reader["last_total_type2"]; 
 if (reader["last_total_type3"] != DBNull.Value)
 currentCcmsCounterMismatched.last_total_type3 = (int) reader["last_total_type3"]; 
 if (reader["last_total_type4"] != DBNull.Value)
 currentCcmsCounterMismatched.last_total_type4 = (int) reader["last_total_type4"]; 
 if (reader["last_remaining_type1"] != DBNull.Value)
 currentCcmsCounterMismatched.last_remaining_type1 = (int) reader["last_remaining_type1"]; 
 if (reader["last_remaining_type2"] != DBNull.Value)
 currentCcmsCounterMismatched.last_remaining_type2 = (int) reader["last_remaining_type2"]; 
 if (reader["last_remaining_type3"] != DBNull.Value)
 currentCcmsCounterMismatched.last_remaining_type3 = (int) reader["last_remaining_type3"]; 
 if (reader["last_remaining_type4"] != DBNull.Value)
 currentCcmsCounterMismatched.last_remaining_type4 = (int) reader["last_remaining_type4"]; 
 if (reader["last_dispensed_type1"] != DBNull.Value)
 currentCcmsCounterMismatched.last_dispensed_type1 = (int) reader["last_dispensed_type1"]; 
 if (reader["last_dispensed_type2"] != DBNull.Value)
 currentCcmsCounterMismatched.last_dispensed_type2 = (int) reader["last_dispensed_type2"]; 
 if (reader["last_dispensed_type3"] != DBNull.Value)
 currentCcmsCounterMismatched.last_dispensed_type3 = (int) reader["last_dispensed_type3"]; 
 if (reader["last_dispensed_type4"] != DBNull.Value)
 currentCcmsCounterMismatched.last_dispensed_type4 = (int) reader["last_dispensed_type4"]; 
 if (reader["last_purged_type1"] != DBNull.Value)
 currentCcmsCounterMismatched.last_purged_type1 = (int) reader["last_purged_type1"]; 
 if (reader["last_purged_type2"] != DBNull.Value)
 currentCcmsCounterMismatched.last_purged_type2 = (int) reader["last_purged_type2"]; 
 if (reader["last_purged_type3"] != DBNull.Value)
 currentCcmsCounterMismatched.last_purged_type3 = (int) reader["last_purged_type3"]; 
 if (reader["last_purged_type4"] != DBNull.Value)
 currentCcmsCounterMismatched.last_purged_type4 = (int) reader["last_purged_type4"]; 
 if (reader["current_total_type1"] != DBNull.Value)
 currentCcmsCounterMismatched.current_total_type1 = (int) reader["current_total_type1"]; 
 if (reader["current_total_type2"] != DBNull.Value)
 currentCcmsCounterMismatched.current_total_type2 = (int) reader["current_total_type2"]; 
 if (reader["current_total_type3"] != DBNull.Value)
 currentCcmsCounterMismatched.current_total_type3 = (int) reader["current_total_type3"]; 
 if (reader["current_total_type4"] != DBNull.Value)
 currentCcmsCounterMismatched.current_total_type4 = (int) reader["current_total_type4"]; 
 if (reader["current_remaining_type1"] != DBNull.Value)
 currentCcmsCounterMismatched.current_remaining_type1 = (int) reader["current_remaining_type1"]; 
 if (reader["current_remaining_type2"] != DBNull.Value)
 currentCcmsCounterMismatched.current_remaining_type2 = (int) reader["current_remaining_type2"]; 
 if (reader["current_remaining_type3"] != DBNull.Value)
 currentCcmsCounterMismatched.current_remaining_type3 = (int) reader["current_remaining_type3"]; 
 if (reader["current_remaining_type4"] != DBNull.Value)
 currentCcmsCounterMismatched.current_remaining_type4 = (int) reader["current_remaining_type4"]; 
 if (reader["current_dispensed_type1"] != DBNull.Value)
 currentCcmsCounterMismatched.current_dispensed_type1 = (int) reader["current_dispensed_type1"]; 
 if (reader["current_dispensed_type2"] != DBNull.Value)
 currentCcmsCounterMismatched.current_dispensed_type2 = (int) reader["current_dispensed_type2"]; 
 if (reader["current_dispensed_type3"] != DBNull.Value)
 currentCcmsCounterMismatched.current_dispensed_type3 = (int) reader["current_dispensed_type3"]; 
 if (reader["current_dispensed_type4"] != DBNull.Value)
 currentCcmsCounterMismatched.current_dispensed_type4 = (int) reader["current_dispensed_type4"]; 
 if (reader["current_purged_type1"] != DBNull.Value)
 currentCcmsCounterMismatched.current_purged_type1 = (int) reader["current_purged_type1"]; 
 if (reader["current_purged_type2"] != DBNull.Value)
 currentCcmsCounterMismatched.current_purged_type2 = (int) reader["current_purged_type2"]; 
 if (reader["current_purged_type3"] != DBNull.Value)
 currentCcmsCounterMismatched.current_purged_type3 = (int) reader["current_purged_type3"]; 
 if (reader["current_purged_type4"] != DBNull.Value)
 currentCcmsCounterMismatched.current_purged_type4 = (int) reader["current_purged_type4"]; 
 if (reader["generated_at"] != DBNull.Value)
 currentCcmsCounterMismatched.generated_at = (DateTime) reader["generated_at"]; 
 if (reader["counter_mismatched_datetime"] != DBNull.Value)
 currentCcmsCounterMismatched.counter_mismatched_datetime = (DateTime) reader["counter_mismatched_datetime"]; 
 if (reader["atm_id"] != DBNull.Value)
 currentCcmsCounterMismatched.atm_id = (int) reader["atm_id"]; 
 } 

 currentCcmsCounterMismatched.isNewEntity = false;
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

 public CcmsCounterMismatched CurrentCcmsCounterMismatched
 {
 get{ return currentCcmsCounterMismatched; }
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


 #region CcmsCounterMismatched functions

 public static CcmsCounterMismatchedReader ExecuteReader(string where, IDbConnection conn, Columns columns)
 {
 StringBuilder qry = new StringBuilder(200);
 qry.Append("select ");
 if (Columns.ccms_counter_mismatched_id == (Columns.ccms_counter_mismatched_id & columns))
 qry.Append("ccms_counter_mismatched_id,");
 if (Columns.last_total_type1 == (Columns.last_total_type1 & columns))
 qry.Append("last_total_type1,");
 if (Columns.last_total_type2 == (Columns.last_total_type2 & columns))
 qry.Append("last_total_type2,");
 if (Columns.last_total_type3 == (Columns.last_total_type3 & columns))
 qry.Append("last_total_type3,");
 if (Columns.last_total_type4 == (Columns.last_total_type4 & columns))
 qry.Append("last_total_type4,");
 if (Columns.last_remaining_type1 == (Columns.last_remaining_type1 & columns))
 qry.Append("last_remaining_type1,");
 if (Columns.last_remaining_type2 == (Columns.last_remaining_type2 & columns))
 qry.Append("last_remaining_type2,");
 if (Columns.last_remaining_type3 == (Columns.last_remaining_type3 & columns))
 qry.Append("last_remaining_type3,");
 if (Columns.last_remaining_type4 == (Columns.last_remaining_type4 & columns))
 qry.Append("last_remaining_type4,");
 if (Columns.last_dispensed_type1 == (Columns.last_dispensed_type1 & columns))
 qry.Append("last_dispensed_type1,");
 if (Columns.last_dispensed_type2 == (Columns.last_dispensed_type2 & columns))
 qry.Append("last_dispensed_type2,");
 if (Columns.last_dispensed_type3 == (Columns.last_dispensed_type3 & columns))
 qry.Append("last_dispensed_type3,");
 if (Columns.last_dispensed_type4 == (Columns.last_dispensed_type4 & columns))
 qry.Append("last_dispensed_type4,");
 if (Columns.last_purged_type1 == (Columns.last_purged_type1 & columns))
 qry.Append("last_purged_type1,");
 if (Columns.last_purged_type2 == (Columns.last_purged_type2 & columns))
 qry.Append("last_purged_type2,");
 if (Columns.last_purged_type3 == (Columns.last_purged_type3 & columns))
 qry.Append("last_purged_type3,");
 if (Columns.last_purged_type4 == (Columns.last_purged_type4 & columns))
 qry.Append("last_purged_type4,");
 if (Columns.current_total_type1 == (Columns.current_total_type1 & columns))
 qry.Append("current_total_type1,");
 if (Columns.current_total_type2 == (Columns.current_total_type2 & columns))
 qry.Append("current_total_type2,");
 if (Columns.current_total_type3 == (Columns.current_total_type3 & columns))
 qry.Append("current_total_type3,");
 if (Columns.current_total_type4 == (Columns.current_total_type4 & columns))
 qry.Append("current_total_type4,");
 if (Columns.current_remaining_type1 == (Columns.current_remaining_type1 & columns))
 qry.Append("current_remaining_type1,");
 if (Columns.current_remaining_type2 == (Columns.current_remaining_type2 & columns))
 qry.Append("current_remaining_type2,");
 if (Columns.current_remaining_type3 == (Columns.current_remaining_type3 & columns))
 qry.Append("current_remaining_type3,");
 if (Columns.current_remaining_type4 == (Columns.current_remaining_type4 & columns))
 qry.Append("current_remaining_type4,");
 if (Columns.current_dispensed_type1 == (Columns.current_dispensed_type1 & columns))
 qry.Append("current_dispensed_type1,");
 if (Columns.current_dispensed_type2 == (Columns.current_dispensed_type2 & columns))
 qry.Append("current_dispensed_type2,");
 if (Columns.current_dispensed_type3 == (Columns.current_dispensed_type3 & columns))
 qry.Append("current_dispensed_type3,");
 if (Columns.current_dispensed_type4 == (Columns.current_dispensed_type4 & columns))
 qry.Append("current_dispensed_type4,");
 if (Columns.current_purged_type1 == (Columns.current_purged_type1 & columns))
 qry.Append("current_purged_type1,");
 if (Columns.current_purged_type2 == (Columns.current_purged_type2 & columns))
 qry.Append("current_purged_type2,");
 if (Columns.current_purged_type3 == (Columns.current_purged_type3 & columns))
 qry.Append("current_purged_type3,");
 if (Columns.current_purged_type4 == (Columns.current_purged_type4 & columns))
 qry.Append("current_purged_type4,");
 if (Columns.generated_at == (Columns.generated_at & columns))
 qry.Append("generated_at,");
 if (Columns.counter_mismatched_datetime == (Columns.counter_mismatched_datetime & columns))
 qry.Append("counter_mismatched_datetime,");
 if (Columns.atm_id == (Columns.atm_id & columns))
 qry.Append("atm_id,");
 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append("from Ccms_counter_mismatched ");

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
 return new CcmsCounterMismatchedReader(cmd.ExecuteReader(), conn, columns);
 }

 static public CcmsCounterMismatchedReader ExecuteReader(string where,Columns columns)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection(),columns);
 }

 /// 
 /// should be used when u have connection like in case of transaction

 /// 
 /// 
 /// 
 public static CcmsCounterMismatchedReader ExecuteReader(string where,IDbConnection conn)
 {
 if (conn.State != ConnectionState.Open)
 conn.Open();
 IDbCommand cmd = conn.CreateCommand();
 cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
 cmd.ExecuteNonQuery();
 cmd.CommandText = "Select ccms_counter_mismatched_id,last_total_type1,last_total_type2,last_total_type3,last_total_type4,last_remaining_type1,last_remaining_type2,last_remaining_type3,last_remaining_type4,last_dispensed_type1,last_dispensed_type2,last_dispensed_type3,last_dispensed_type4,last_purged_type1,last_purged_type2,last_purged_type3,last_purged_type4,current_total_type1,current_total_type2,current_total_type3,current_total_type4,current_remaining_type1,current_remaining_type2,current_remaining_type3,current_remaining_type4,current_dispensed_type1,current_dispensed_type2,current_dispensed_type3,current_dispensed_type4,current_purged_type1,current_purged_type2,current_purged_type3,current_purged_type4,generated_at,counter_mismatched_datetime,atm_id from Ccms_counter_mismatched ";
 if (where != null && where.Trim().Length > 0)
 cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

 return new CcmsCounterMismatchedReader(cmd.ExecuteReader(), conn);
 }

 static public CcmsCounterMismatchedReader ExecuteReader(string where)
 {
 return ExecuteReader(where, ConnectionFactory.GetNewConnection());
 }

 public static CcmsCounterMismatched LoadCcmsCounterMismatched(string where)
 {
CcmsCounterMismatchedReader reader = CcmsCounterMismatched.ExecuteReader(where);
CcmsCounterMismatched _ccmscountermismatched = null;
 if (reader.Read())
 _ccmscountermismatched = reader.CurrentCcmsCounterMismatched;
 reader.Close();
 return _ccmscountermismatched;
 }

 public static CcmsCounterMismatched LoadCcmsCounterMismatched(string where, IDbConnection conn)
 {
CcmsCounterMismatchedReader reader = CcmsCounterMismatched.ExecuteReader(where, conn);
CcmsCounterMismatched _ccmscountermismatched = null;
 if (reader.Read())
 _ccmscountermismatched = reader.CurrentCcmsCounterMismatched;
 reader.Close(false);
 return _ccmscountermismatched;
 }

 public static CcmsCounterMismatched LoadCcmsCounterMismatchedByPk( int ccms_counter_mismatched_id )
 {
 return LoadCcmsCounterMismatched( " ccms_counter_mismatched_id="+ccms_counter_mismatched_id );
 }

 public static CcmsCounterMismatched LoadCcmsCounterMismatchedByPk( int ccms_counter_mismatched_id , IDbConnection conn)
 {
 return LoadCcmsCounterMismatched(" ccms_counter_mismatched_id="+ccms_counter_mismatched_id , conn);
 }

 public void Save()
 {
 if (ccms_counter_mismatched_idChanged || last_total_type1Changed || last_total_type2Changed || last_total_type3Changed || last_total_type4Changed || last_remaining_type1Changed || last_remaining_type2Changed || last_remaining_type3Changed || last_remaining_type4Changed || last_dispensed_type1Changed || last_dispensed_type2Changed || last_dispensed_type3Changed || last_dispensed_type4Changed || last_purged_type1Changed || last_purged_type2Changed || last_purged_type3Changed || last_purged_type4Changed || current_total_type1Changed || current_total_type2Changed || current_total_type3Changed || current_total_type4Changed || current_remaining_type1Changed || current_remaining_type2Changed || current_remaining_type3Changed || current_remaining_type4Changed || current_dispensed_type1Changed || current_dispensed_type2Changed || current_dispensed_type3Changed || current_dispensed_type4Changed || current_purged_type1Changed || current_purged_type2Changed || current_purged_type3Changed || current_purged_type4Changed || generated_atChanged || counter_mismatched_datetimeChanged || atm_idChanged )
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
 if (ccms_counter_mismatched_idChanged || last_total_type1Changed || last_total_type2Changed || last_total_type3Changed || last_total_type4Changed || last_remaining_type1Changed || last_remaining_type2Changed || last_remaining_type3Changed || last_remaining_type4Changed || last_dispensed_type1Changed || last_dispensed_type2Changed || last_dispensed_type3Changed || last_dispensed_type4Changed || last_purged_type1Changed || last_purged_type2Changed || last_purged_type3Changed || last_purged_type4Changed || current_total_type1Changed || current_total_type2Changed || current_total_type3Changed || current_total_type4Changed || current_remaining_type1Changed || current_remaining_type2Changed || current_remaining_type3Changed || current_remaining_type4Changed || current_dispensed_type1Changed || current_dispensed_type2Changed || current_dispensed_type3Changed || current_dispensed_type4Changed || current_purged_type1Changed || current_purged_type2Changed || current_purged_type3Changed || current_purged_type4Changed || generated_atChanged || counter_mismatched_datetimeChanged || atm_idChanged )
 {
 StringBuilder qry = new StringBuilder(500);

 if (this.isNewEntity)
 {
 qry.Append(@"insert into Ccms_counter_mismatched( ccms_counter_mismatched_id,last_total_type1,last_total_type2,last_total_type3,last_total_type4,last_remaining_type1,last_remaining_type2,last_remaining_type3,last_remaining_type4,last_dispensed_type1,last_dispensed_type2,last_dispensed_type3,last_dispensed_type4,last_purged_type1,last_purged_type2,last_purged_type3,last_purged_type4,current_total_type1,current_total_type2,current_total_type3,current_total_type4,current_remaining_type1,current_remaining_type2,current_remaining_type3,current_remaining_type4,current_dispensed_type1,current_dispensed_type2,current_dispensed_type3,current_dispensed_type4,current_purged_type1,current_purged_type2,current_purged_type3,current_purged_type4,generated_at,counter_mismatched_datetime,atm_id ) values(");
 lock (ConnectionFactory.connectionString) { this.ccms_counter_mismatched_id = ConnectionFactory.GetNextId();
 qry.Append(this.ccms_counter_mismatched_id);
 } qry.Append(",");
 qry.Append(last_total_type1DbString+",");
 qry.Append(last_total_type2DbString+",");
 qry.Append(last_total_type3DbString+",");
 qry.Append(last_total_type4DbString+",");
 qry.Append(last_remaining_type1DbString+",");
 qry.Append(last_remaining_type2DbString+",");
 qry.Append(last_remaining_type3DbString+",");
 qry.Append(last_remaining_type4DbString+",");
 qry.Append(last_dispensed_type1DbString+",");
 qry.Append(last_dispensed_type2DbString+",");
 qry.Append(last_dispensed_type3DbString+",");
 qry.Append(last_dispensed_type4DbString+",");
 qry.Append(last_purged_type1DbString+",");
 qry.Append(last_purged_type2DbString+",");
 qry.Append(last_purged_type3DbString+",");
 qry.Append(last_purged_type4DbString+",");
 qry.Append(current_total_type1DbString+",");
 qry.Append(current_total_type2DbString+",");
 qry.Append(current_total_type3DbString+",");
 qry.Append(current_total_type4DbString+",");
 qry.Append(current_remaining_type1DbString+",");
 qry.Append(current_remaining_type2DbString+",");
 qry.Append(current_remaining_type3DbString+",");
 qry.Append(current_remaining_type4DbString+",");
 qry.Append(current_dispensed_type1DbString+",");
 qry.Append(current_dispensed_type2DbString+",");
 qry.Append(current_dispensed_type3DbString+",");
 qry.Append(current_dispensed_type4DbString+",");
 qry.Append(current_purged_type1DbString+",");
 qry.Append(current_purged_type2DbString+",");
 qry.Append(current_purged_type3DbString+",");
 qry.Append(current_purged_type4DbString+",");
 qry.Append(generated_atDbString+",");
 qry.Append(counter_mismatched_datetimeDbString+",");
 qry.Append(atm_idDbString);
 qry.Append(");");

 }
 else
 {
 if (!(ccms_counter_mismatched_idChanged || last_total_type1Changed || last_total_type2Changed || last_total_type3Changed || last_total_type4Changed || last_remaining_type1Changed || last_remaining_type2Changed || last_remaining_type3Changed || last_remaining_type4Changed || last_dispensed_type1Changed || last_dispensed_type2Changed || last_dispensed_type3Changed || last_dispensed_type4Changed || last_purged_type1Changed || last_purged_type2Changed || last_purged_type3Changed || last_purged_type4Changed || current_total_type1Changed || current_total_type2Changed || current_total_type3Changed || current_total_type4Changed || current_remaining_type1Changed || current_remaining_type2Changed || current_remaining_type3Changed || current_remaining_type4Changed || current_dispensed_type1Changed || current_dispensed_type2Changed || current_dispensed_type3Changed || current_dispensed_type4Changed || current_purged_type1Changed || current_purged_type2Changed || current_purged_type3Changed || current_purged_type4Changed || generated_atChanged || counter_mismatched_datetimeChanged || atm_idChanged ))
 return;
 qry.Append("UPDATE Ccms_counter_mismatched set "); if ( last_total_type1Changed )
 {
 qry.Append("last_total_type1 ="+last_total_type1DbString);
 qry.Append(",");
 }

 if ( last_total_type2Changed )
 {
 qry.Append("last_total_type2 ="+last_total_type2DbString);
 qry.Append(",");
 }

 if ( last_total_type3Changed )
 {
 qry.Append("last_total_type3 ="+last_total_type3DbString);
 qry.Append(",");
 }

 if ( last_total_type4Changed )
 {
 qry.Append("last_total_type4 ="+last_total_type4DbString);
 qry.Append(",");
 }

 if ( last_remaining_type1Changed )
 {
 qry.Append("last_remaining_type1 ="+last_remaining_type1DbString);
 qry.Append(",");
 }

 if ( last_remaining_type2Changed )
 {
 qry.Append("last_remaining_type2 ="+last_remaining_type2DbString);
 qry.Append(",");
 }

 if ( last_remaining_type3Changed )
 {
 qry.Append("last_remaining_type3 ="+last_remaining_type3DbString);
 qry.Append(",");
 }

 if ( last_remaining_type4Changed )
 {
 qry.Append("last_remaining_type4 ="+last_remaining_type4DbString);
 qry.Append(",");
 }

 if ( last_dispensed_type1Changed )
 {
 qry.Append("last_dispensed_type1 ="+last_dispensed_type1DbString);
 qry.Append(",");
 }

 if ( last_dispensed_type2Changed )
 {
 qry.Append("last_dispensed_type2 ="+last_dispensed_type2DbString);
 qry.Append(",");
 }

 if ( last_dispensed_type3Changed )
 {
 qry.Append("last_dispensed_type3 ="+last_dispensed_type3DbString);
 qry.Append(",");
 }

 if ( last_dispensed_type4Changed )
 {
 qry.Append("last_dispensed_type4 ="+last_dispensed_type4DbString);
 qry.Append(",");
 }

 if ( last_purged_type1Changed )
 {
 qry.Append("last_purged_type1 ="+last_purged_type1DbString);
 qry.Append(",");
 }

 if ( last_purged_type2Changed )
 {
 qry.Append("last_purged_type2 ="+last_purged_type2DbString);
 qry.Append(",");
 }

 if ( last_purged_type3Changed )
 {
 qry.Append("last_purged_type3 ="+last_purged_type3DbString);
 qry.Append(",");
 }

 if ( last_purged_type4Changed )
 {
 qry.Append("last_purged_type4 ="+last_purged_type4DbString);
 qry.Append(",");
 }

 if ( current_total_type1Changed )
 {
 qry.Append("current_total_type1 ="+current_total_type1DbString);
 qry.Append(",");
 }

 if ( current_total_type2Changed )
 {
 qry.Append("current_total_type2 ="+current_total_type2DbString);
 qry.Append(",");
 }

 if ( current_total_type3Changed )
 {
 qry.Append("current_total_type3 ="+current_total_type3DbString);
 qry.Append(",");
 }

 if ( current_total_type4Changed )
 {
 qry.Append("current_total_type4 ="+current_total_type4DbString);
 qry.Append(",");
 }

 if ( current_remaining_type1Changed )
 {
 qry.Append("current_remaining_type1 ="+current_remaining_type1DbString);
 qry.Append(",");
 }

 if ( current_remaining_type2Changed )
 {
 qry.Append("current_remaining_type2 ="+current_remaining_type2DbString);
 qry.Append(",");
 }

 if ( current_remaining_type3Changed )
 {
 qry.Append("current_remaining_type3 ="+current_remaining_type3DbString);
 qry.Append(",");
 }

 if ( current_remaining_type4Changed )
 {
 qry.Append("current_remaining_type4 ="+current_remaining_type4DbString);
 qry.Append(",");
 }

 if ( current_dispensed_type1Changed )
 {
 qry.Append("current_dispensed_type1 ="+current_dispensed_type1DbString);
 qry.Append(",");
 }

 if ( current_dispensed_type2Changed )
 {
 qry.Append("current_dispensed_type2 ="+current_dispensed_type2DbString);
 qry.Append(",");
 }

 if ( current_dispensed_type3Changed )
 {
 qry.Append("current_dispensed_type3 ="+current_dispensed_type3DbString);
 qry.Append(",");
 }

 if ( current_dispensed_type4Changed )
 {
 qry.Append("current_dispensed_type4 ="+current_dispensed_type4DbString);
 qry.Append(",");
 }

 if ( current_purged_type1Changed )
 {
 qry.Append("current_purged_type1 ="+current_purged_type1DbString);
 qry.Append(",");
 }

 if ( current_purged_type2Changed )
 {
 qry.Append("current_purged_type2 ="+current_purged_type2DbString);
 qry.Append(",");
 }

 if ( current_purged_type3Changed )
 {
 qry.Append("current_purged_type3 ="+current_purged_type3DbString);
 qry.Append(",");
 }

 if ( current_purged_type4Changed )
 {
 qry.Append("current_purged_type4 ="+current_purged_type4DbString);
 qry.Append(",");
 }

 if ( generated_atChanged )
 {
 qry.Append("generated_at ="+generated_atDbString);
 qry.Append(",");
 }

 if ( counter_mismatched_datetimeChanged )
 {
 qry.Append("counter_mismatched_datetime ="+counter_mismatched_datetimeDbString);
 qry.Append(",");
 }

 if ( atm_idChanged )
 {
 qry.Append("atm_id ="+atm_idDbString);
 qry.Append(",");
 }


 qry.Replace(',', ' ', qry.Length - 1,1);
 qry.Append(" where ");
 qry.Append("ccms_counter_mismatched_id = "+ccms_counter_mismatched_idDbString);
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
 cmd.CommandText = "DELETE Ccms_counter_mismatched where ccms_counter_mismatched_id = "+ ccms_counter_mismatched_id;
 if (conn.State == ConnectionState.Closed)
 {
 cmd.Connection.Open();
 cmd.ExecuteNonQuery();
 cmd.Connection.Close();
 }
 else
 cmd.ExecuteNonQuery();
 }

 public static void DeleteCcmsCounterMismatcheds(string where)
 {
 ConnectionFactory.ExecuteQuery("delete Ccms_counter_mismatched where " + where);
 }

 #endregion
 #region Columns enum
 public enum Columns:ulong
 {
ccms_counter_mismatched_id= 1,
last_total_type1= 2,
last_total_type2= 4,
last_total_type3= 8,
last_total_type4= 16,
last_remaining_type1= 32,
last_remaining_type2= 64,
last_remaining_type3= 128,
last_remaining_type4= 256,
last_dispensed_type1= 512,
last_dispensed_type2= 1024,
last_dispensed_type3= 2048,
last_dispensed_type4= 4096,
last_purged_type1= 8192,
last_purged_type2= 16384,
last_purged_type3= 32768,
last_purged_type4= 65536,
current_total_type1= 131072,
current_total_type2= 262144,
current_total_type3= 524288,
current_total_type4= 1048576,
current_remaining_type1= 2097152,
current_remaining_type2= 4194304,
current_remaining_type3= 8388608,
current_remaining_type4= 16777216,
current_dispensed_type1= 33554432,
current_dispensed_type2= 67108864,
current_dispensed_type3= 134217728,
current_dispensed_type4= 268435456,
current_purged_type1= 536870912,
current_purged_type2= 1073741824,
current_purged_type3= 2147483648,
current_purged_type4= 4294967296,
generated_at= 8589934592,
counter_mismatched_datetime= 17179869184,
atm_id= 34359738368
 }
 #endregion
 public void BulkSave(List<CcmsCounterMismatched> dataArray,SqlTransaction dbTrx)
 {
 DataTable dt = new DataTable();
 CreateDataTable(dt);
 AddToDataTable(dataArray, ref dt);
 SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
 bulk.DestinationTableName = "Ccms_counter_mismatched";
 bulk.WriteToServer(dt);
 }
 public void CreateDataTable(DataTable dt)
 {
 string[] colNames = Enum.GetNames(typeof(CcmsCounterMismatched.Columns));
 for (int i = 0; i < colNames.Length; i++)
 {
 dt.Columns.Add(colNames[i]);
 }
 }
 public void AddToDataTable(List <CcmsCounterMismatched> transList,ref DataTable dt)
 {
 foreach (CcmsCounterMismatched tran in transList)
 {
 DataRow Row;
 Row = dt.NewRow();
 Row["ccms_counter_mismatched_id"] =ConnectionFactory.GetNextId();
 Row["last_total_type1"] = tran.LastTotalType1;
 Row["last_total_type2"] = tran.LastTotalType2;
 Row["last_total_type3"] = tran.LastTotalType3;
 Row["last_total_type4"] = tran.LastTotalType4;
 Row["last_remaining_type1"] = tran.LastRemainingType1;
 Row["last_remaining_type2"] = tran.LastRemainingType2;
 Row["last_remaining_type3"] = tran.LastRemainingType3;
 Row["last_remaining_type4"] = tran.LastRemainingType4;
 Row["last_dispensed_type1"] = tran.LastDispensedType1;
 Row["last_dispensed_type2"] = tran.LastDispensedType2;
 Row["last_dispensed_type3"] = tran.LastDispensedType3;
 Row["last_dispensed_type4"] = tran.LastDispensedType4;
 Row["last_purged_type1"] = tran.LastPurgedType1;
 Row["last_purged_type2"] = tran.LastPurgedType2;
 Row["last_purged_type3"] = tran.LastPurgedType3;
 Row["last_purged_type4"] = tran.LastPurgedType4;
 Row["current_total_type1"] = tran.CurrentTotalType1;
 Row["current_total_type2"] = tran.CurrentTotalType2;
 Row["current_total_type3"] = tran.CurrentTotalType3;
 Row["current_total_type4"] = tran.CurrentTotalType4;
 Row["current_remaining_type1"] = tran.CurrentRemainingType1;
 Row["current_remaining_type2"] = tran.CurrentRemainingType2;
 Row["current_remaining_type3"] = tran.CurrentRemainingType3;
 Row["current_remaining_type4"] = tran.CurrentRemainingType4;
 Row["current_dispensed_type1"] = tran.CurrentDispensedType1;
 Row["current_dispensed_type2"] = tran.CurrentDispensedType2;
 Row["current_dispensed_type3"] = tran.CurrentDispensedType3;
 Row["current_dispensed_type4"] = tran.CurrentDispensedType4;
 Row["current_purged_type1"] = tran.CurrentPurgedType1;
 Row["current_purged_type2"] = tran.CurrentPurgedType2;
 Row["current_purged_type3"] = tran.CurrentPurgedType3;
 Row["current_purged_type4"] = tran.CurrentPurgedType4;
 Row["generated_at"] = tran.GeneratedAt;
 Row["counter_mismatched_datetime"] = tran.CounterMismatchedDatetime;
 Row["atm_id"] = tran.AtmId;
 dt.Rows.Add(Row);
 } }
 }
 }

 
