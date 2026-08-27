 
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
    public class ParsedBnaCounter
    {
        bool isNewEntity = true;
        bool IsNewEntity
        {
            get { return isNewEntity; }
        }

        public ParsedBnaCounter() { }
        public ParsedBnaCounter(int parsed_bna_counter_id, DateTime last_deposit_at, int atm_id, int task_id)
        {
            this.last_deposit_at = last_deposit_at;
            this.last_deposit_atChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
        }
        public ParsedBnaCounter(int? cassette1_counter_1, int? cassette1_counter_2, int? cassette1_counter_3, int? cassette1_counter_4, int? cassette1_counter_5, int? cassette1_counter_6, int? cassette1_counter_7, int? cassette1_counter_8, int? cassette1_counter_9, int? cassette1_counter_10, int? cassette1_counter_11, int? cassette1_counter_12, int? cassette1_counter_13, int? cassette1_counter_14, int? cassette1_counter_15, int? cassette1_counter_16, int? cassette1_counter_17, int? cassette1_counter_18, int? cassette1_counter_19, int? cassette1_counter_20, int? cassette1_counter_21, int? cassette1_counter_22, int? cassette1_counter_23, int? cassette1_counter_24, int? cassette1_counter_25, int? cassette1_counter_26, int? cassette1_counter_27, int? cassette1_counter_28, int? cassette1_counter_29, int? cassette1_counter_30, int? cassette1_counter_31, int? cassette1_counter_32, int? cassette1_counter_33, int? cassette1_counter_34, int? cassette1_counter_35, int? cassette1_counter_36, int? cassette1_counter_37, int? cassette1_counter_38, int? cassette1_counter_39, int? cassette1_counter_40, int? cassette1_counter_41, int? cassette1_counter_42, int? cassette1_counter_43, int? cassette1_counter_44, int? cassette1_counter_45, int? cassette1_counter_46, int? cassette1_counter_47, int? cassette1_counter_48, int? cassette1_counter_49, int? cassette1_counter_50, int? cassette2_counter_1, int? cassette2_counter_2, int? cassette2_counter_3, int? cassette2_counter_4, int? cassette2_counter_5, int? cassette2_counter_6, int? cassette2_counter_7, int? cassette2_counter_8, int? cassette2_counter_9, int? cassette2_counter_10, int? cassette2_counter_11, int? cassette2_counter_12, int? cassette2_counter_13, int? cassette2_counter_14, int? cassette2_counter_15, int? cassette2_counter_16, int? cassette2_counter_17, int? cassette2_counter_18, int? cassette2_counter_19, int? cassette2_counter_20, int? cassette2_counter_21, int? cassette2_counter_22, int? cassette2_counter_23, int? cassette2_counter_24, int? cassette2_counter_25, int? cassette2_counter_26, int? cassette2_counter_27, int? cassette2_counter_28, int? cassette2_counter_29, int? cassette2_counter_30, int? cassette2_counter_31, int? cassette2_counter_32, int? cassette2_counter_33, int? cassette2_counter_34, int? cassette2_counter_35, int? cassette2_counter_36, int? cassette2_counter_37, int? cassette2_counter_38, int? cassette2_counter_39, int? cassette2_counter_40, int? cassette2_counter_41, int? cassette2_counter_42, int? cassette2_counter_43, int? cassette2_counter_44, int? cassette2_counter_45, int? cassette2_counter_46, int? cassette2_counter_47, int? cassette2_counter_48, int? cassette2_counter_49, int? cassette2_counter_50, int? cassette3_counter_1, int? cassette3_counter_2, int? cassette3_counter_3, int? cassette3_counter_4, int? cassette3_counter_5, int? cassette3_counter_6, int? cassette3_counter_7, int? cassette3_counter_8, int? cassette3_counter_9, int? cassette3_counter_10, int? cassette3_counter_11, int? cassette3_counter_12, int? cassette3_counter_13, int? cassette3_counter_14, int? cassette3_counter_15, int? cassette3_counter_16, int? cassette3_counter_17, int? cassette3_counter_18, int? cassette3_counter_19, int? cassette3_counter_20, int? cassette3_counter_21, int? cassette3_counter_22, int? cassette3_counter_23, int? cassette3_counter_24, int? cassette3_counter_25, int? cassette3_counter_26, int? cassette3_counter_27, int? cassette3_counter_28, int? cassette3_counter_29, int? cassette3_counter_30, int? cassette3_counter_31, int? cassette3_counter_32, int? cassette3_counter_33, int? cassette3_counter_34, int? cassette3_counter_35, int? cassette3_counter_36, int? cassette3_counter_37, int? cassette3_counter_38, int? cassette3_counter_39, int? cassette3_counter_40, int? cassette3_counter_41, int? cassette3_counter_42, int? cassette3_counter_43, int? cassette3_counter_44, int? cassette3_counter_45, int? cassette3_counter_46, int? cassette3_counter_47, int? cassette3_counter_48, int? cassette3_counter_49, int? cassette3_counter_50, int? cassette4_counter_1, int? cassette4_counter_2, int? cassette4_counter_3, int? cassette4_counter_4, int? cassette4_counter_5, int? cassette4_counter_6, int? cassette4_counter_7, int? cassette4_counter_8, int? cassette4_counter_9, int? cassette4_counter_10, int? cassette4_counter_11, int? cassette4_counter_12, int? cassette4_counter_13, int? cassette4_counter_14, int? cassette4_counter_15, int? cassette4_counter_16, int? cassette4_counter_17, int? cassette4_counter_18, int? cassette4_counter_19, int? cassette4_counter_20, int? cassette4_counter_21, int? cassette4_counter_22, int? cassette4_counter_23, int? cassette4_counter_24, int? cassette4_counter_25, int? cassette4_counter_26, int? cassette4_counter_27, int? cassette4_counter_28, int? cassette4_counter_29, int? cassette4_counter_30, int? cassette4_counter_31, int? cassette4_counter_32, int? cassette4_counter_33, int? cassette4_counter_34, int? cassette4_counter_35, int? cassette4_counter_36, int? cassette4_counter_37, int? cassette4_counter_38, int? cassette4_counter_39, int? cassette4_counter_40, int? cassette4_counter_41, int? cassette4_counter_42, int? cassette4_counter_43, int? cassette4_counter_44, int? cassette4_counter_45, int? cassette4_counter_46, int? cassette4_counter_47, int? cassette4_counter_48, int? cassette4_counter_49, int? cassette4_counter_50, int? purge_counter_1, int? purge_counter_2, int? purge_counter_3, int? purge_counter_4, int? purge_counter_5, int? purge_counter_6, int? purge_counter_7, int? purge_counter_8, int? purge_counter_9, int? purge_counter_10, int? purge_counter_11, int? purge_counter_12, int? purge_counter_13, int? purge_counter_14, int? purge_counter_15, int? purge_counter_16, int? purge_counter_17, int? purge_counter_18, int? purge_counter_19, int? purge_counter_20, int? purge_counter_21, int? purge_counter_22, int? purge_counter_23, int? purge_counter_24, int? purge_counter_25, int? purge_counter_26, int? purge_counter_27, int? purge_counter_28, int? purge_counter_29, int? purge_counter_30, int? purge_counter_31, int? purge_counter_32, int? purge_counter_33, int? purge_counter_34, int? purge_counter_35, int? purge_counter_36, int? purge_counter_37, int? purge_counter_38, int? purge_counter_39, int? purge_counter_40, int? purge_counter_41, int? purge_counter_42, int? purge_counter_43, int? purge_counter_44, int? purge_counter_45, int? purge_counter_46, int? purge_counter_47, int? purge_counter_48, int? purge_counter_49, int? purge_counter_50, DateTime last_deposit_at, int atm_id, int task_id, string cassette1_denomination_detail, string cassette2_denomination_detail, string cassette3_denomination_detail, string cassette4_denomination_detail, string purge_denomination_detail)
        {
            this.cassette1_counter_1 = cassette1_counter_1;
            this.cassette1_counter_1Changed = true;
            this.cassette1_counter_2 = cassette1_counter_2;
            this.cassette1_counter_2Changed = true;
            this.cassette1_counter_3 = cassette1_counter_3;
            this.cassette1_counter_3Changed = true;
            this.cassette1_counter_4 = cassette1_counter_4;
            this.cassette1_counter_4Changed = true;
            this.cassette1_counter_5 = cassette1_counter_5;
            this.cassette1_counter_5Changed = true;
            this.cassette1_counter_6 = cassette1_counter_6;
            this.cassette1_counter_6Changed = true;
            this.cassette1_counter_7 = cassette1_counter_7;
            this.cassette1_counter_7Changed = true;
            this.cassette1_counter_8 = cassette1_counter_8;
            this.cassette1_counter_8Changed = true;
            this.cassette1_counter_9 = cassette1_counter_9;
            this.cassette1_counter_9Changed = true;
            this.cassette1_counter_10 = cassette1_counter_10;
            this.cassette1_counter_10Changed = true;
            this.cassette1_counter_11 = cassette1_counter_11;
            this.cassette1_counter_11Changed = true;
            this.cassette1_counter_12 = cassette1_counter_12;
            this.cassette1_counter_12Changed = true;
            this.cassette1_counter_13 = cassette1_counter_13;
            this.cassette1_counter_13Changed = true;
            this.cassette1_counter_14 = cassette1_counter_14;
            this.cassette1_counter_14Changed = true;
            this.cassette1_counter_15 = cassette1_counter_15;
            this.cassette1_counter_15Changed = true;
            this.cassette1_counter_16 = cassette1_counter_16;
            this.cassette1_counter_16Changed = true;
            this.cassette1_counter_17 = cassette1_counter_17;
            this.cassette1_counter_17Changed = true;
            this.cassette1_counter_18 = cassette1_counter_18;
            this.cassette1_counter_18Changed = true;
            this.cassette1_counter_19 = cassette1_counter_19;
            this.cassette1_counter_19Changed = true;
            this.cassette1_counter_20 = cassette1_counter_20;
            this.cassette1_counter_20Changed = true;
            this.cassette1_counter_21 = cassette1_counter_21;
            this.cassette1_counter_21Changed = true;
            this.cassette1_counter_22 = cassette1_counter_22;
            this.cassette1_counter_22Changed = true;
            this.cassette1_counter_23 = cassette1_counter_23;
            this.cassette1_counter_23Changed = true;
            this.cassette1_counter_24 = cassette1_counter_24;
            this.cassette1_counter_24Changed = true;
            this.cassette1_counter_25 = cassette1_counter_25;
            this.cassette1_counter_25Changed = true;
            this.cassette1_counter_26 = cassette1_counter_26;
            this.cassette1_counter_26Changed = true;
            this.cassette1_counter_27 = cassette1_counter_27;
            this.cassette1_counter_27Changed = true;
            this.cassette1_counter_28 = cassette1_counter_28;
            this.cassette1_counter_28Changed = true;
            this.cassette1_counter_29 = cassette1_counter_29;
            this.cassette1_counter_29Changed = true;
            this.cassette1_counter_30 = cassette1_counter_30;
            this.cassette1_counter_30Changed = true;
            this.cassette1_counter_31 = cassette1_counter_31;
            this.cassette1_counter_31Changed = true;
            this.cassette1_counter_32 = cassette1_counter_32;
            this.cassette1_counter_32Changed = true;
            this.cassette1_counter_33 = cassette1_counter_33;
            this.cassette1_counter_33Changed = true;
            this.cassette1_counter_34 = cassette1_counter_34;
            this.cassette1_counter_34Changed = true;
            this.cassette1_counter_35 = cassette1_counter_35;
            this.cassette1_counter_35Changed = true;
            this.cassette1_counter_36 = cassette1_counter_36;
            this.cassette1_counter_36Changed = true;
            this.cassette1_counter_37 = cassette1_counter_37;
            this.cassette1_counter_37Changed = true;
            this.cassette1_counter_38 = cassette1_counter_38;
            this.cassette1_counter_38Changed = true;
            this.cassette1_counter_39 = cassette1_counter_39;
            this.cassette1_counter_39Changed = true;
            this.cassette1_counter_40 = cassette1_counter_40;
            this.cassette1_counter_40Changed = true;
            this.cassette1_counter_41 = cassette1_counter_41;
            this.cassette1_counter_41Changed = true;
            this.cassette1_counter_42 = cassette1_counter_42;
            this.cassette1_counter_42Changed = true;
            this.cassette1_counter_43 = cassette1_counter_43;
            this.cassette1_counter_43Changed = true;
            this.cassette1_counter_44 = cassette1_counter_44;
            this.cassette1_counter_44Changed = true;
            this.cassette1_counter_45 = cassette1_counter_45;
            this.cassette1_counter_45Changed = true;
            this.cassette1_counter_46 = cassette1_counter_46;
            this.cassette1_counter_46Changed = true;
            this.cassette1_counter_47 = cassette1_counter_47;
            this.cassette1_counter_47Changed = true;
            this.cassette1_counter_48 = cassette1_counter_48;
            this.cassette1_counter_48Changed = true;
            this.cassette1_counter_49 = cassette1_counter_49;
            this.cassette1_counter_49Changed = true;
            this.cassette1_counter_50 = cassette1_counter_50;
            this.cassette1_counter_50Changed = true;
            this.cassette2_counter_1 = cassette2_counter_1;
            this.cassette2_counter_1Changed = true;
            this.cassette2_counter_2 = cassette2_counter_2;
            this.cassette2_counter_2Changed = true;
            this.cassette2_counter_3 = cassette2_counter_3;
            this.cassette2_counter_3Changed = true;
            this.cassette2_counter_4 = cassette2_counter_4;
            this.cassette2_counter_4Changed = true;
            this.cassette2_counter_5 = cassette2_counter_5;
            this.cassette2_counter_5Changed = true;
            this.cassette2_counter_6 = cassette2_counter_6;
            this.cassette2_counter_6Changed = true;
            this.cassette2_counter_7 = cassette2_counter_7;
            this.cassette2_counter_7Changed = true;
            this.cassette2_counter_8 = cassette2_counter_8;
            this.cassette2_counter_8Changed = true;
            this.cassette2_counter_9 = cassette2_counter_9;
            this.cassette2_counter_9Changed = true;
            this.cassette2_counter_10 = cassette2_counter_10;
            this.cassette2_counter_10Changed = true;
            this.cassette2_counter_11 = cassette2_counter_11;
            this.cassette2_counter_11Changed = true;
            this.cassette2_counter_12 = cassette2_counter_12;
            this.cassette2_counter_12Changed = true;
            this.cassette2_counter_13 = cassette2_counter_13;
            this.cassette2_counter_13Changed = true;
            this.cassette2_counter_14 = cassette2_counter_14;
            this.cassette2_counter_14Changed = true;
            this.cassette2_counter_15 = cassette2_counter_15;
            this.cassette2_counter_15Changed = true;
            this.cassette2_counter_16 = cassette2_counter_16;
            this.cassette2_counter_16Changed = true;
            this.cassette2_counter_17 = cassette2_counter_17;
            this.cassette2_counter_17Changed = true;
            this.cassette2_counter_18 = cassette2_counter_18;
            this.cassette2_counter_18Changed = true;
            this.cassette2_counter_19 = cassette2_counter_19;
            this.cassette2_counter_19Changed = true;
            this.cassette2_counter_20 = cassette2_counter_20;
            this.cassette2_counter_20Changed = true;
            this.cassette2_counter_21 = cassette2_counter_21;
            this.cassette2_counter_21Changed = true;
            this.cassette2_counter_22 = cassette2_counter_22;
            this.cassette2_counter_22Changed = true;
            this.cassette2_counter_23 = cassette2_counter_23;
            this.cassette2_counter_23Changed = true;
            this.cassette2_counter_24 = cassette2_counter_24;
            this.cassette2_counter_24Changed = true;
            this.cassette2_counter_25 = cassette2_counter_25;
            this.cassette2_counter_25Changed = true;
            this.cassette2_counter_26 = cassette2_counter_26;
            this.cassette2_counter_26Changed = true;
            this.cassette2_counter_27 = cassette2_counter_27;
            this.cassette2_counter_27Changed = true;
            this.cassette2_counter_28 = cassette2_counter_28;
            this.cassette2_counter_28Changed = true;
            this.cassette2_counter_29 = cassette2_counter_29;
            this.cassette2_counter_29Changed = true;
            this.cassette2_counter_30 = cassette2_counter_30;
            this.cassette2_counter_30Changed = true;
            this.cassette2_counter_31 = cassette2_counter_31;
            this.cassette2_counter_31Changed = true;
            this.cassette2_counter_32 = cassette2_counter_32;
            this.cassette2_counter_32Changed = true;
            this.cassette2_counter_33 = cassette2_counter_33;
            this.cassette2_counter_33Changed = true;
            this.cassette2_counter_34 = cassette2_counter_34;
            this.cassette2_counter_34Changed = true;
            this.cassette2_counter_35 = cassette2_counter_35;
            this.cassette2_counter_35Changed = true;
            this.cassette2_counter_36 = cassette2_counter_36;
            this.cassette2_counter_36Changed = true;
            this.cassette2_counter_37 = cassette2_counter_37;
            this.cassette2_counter_37Changed = true;
            this.cassette2_counter_38 = cassette2_counter_38;
            this.cassette2_counter_38Changed = true;
            this.cassette2_counter_39 = cassette2_counter_39;
            this.cassette2_counter_39Changed = true;
            this.cassette2_counter_40 = cassette2_counter_40;
            this.cassette2_counter_40Changed = true;
            this.cassette2_counter_41 = cassette2_counter_41;
            this.cassette2_counter_41Changed = true;
            this.cassette2_counter_42 = cassette2_counter_42;
            this.cassette2_counter_42Changed = true;
            this.cassette2_counter_43 = cassette2_counter_43;
            this.cassette2_counter_43Changed = true;
            this.cassette2_counter_44 = cassette2_counter_44;
            this.cassette2_counter_44Changed = true;
            this.cassette2_counter_45 = cassette2_counter_45;
            this.cassette2_counter_45Changed = true;
            this.cassette2_counter_46 = cassette2_counter_46;
            this.cassette2_counter_46Changed = true;
            this.cassette2_counter_47 = cassette2_counter_47;
            this.cassette2_counter_47Changed = true;
            this.cassette2_counter_48 = cassette2_counter_48;
            this.cassette2_counter_48Changed = true;
            this.cassette2_counter_49 = cassette2_counter_49;
            this.cassette2_counter_49Changed = true;
            this.cassette2_counter_50 = cassette2_counter_50;
            this.cassette2_counter_50Changed = true;
            this.cassette3_counter_1 = cassette3_counter_1;
            this.cassette3_counter_1Changed = true;
            this.cassette3_counter_2 = cassette3_counter_2;
            this.cassette3_counter_2Changed = true;
            this.cassette3_counter_3 = cassette3_counter_3;
            this.cassette3_counter_3Changed = true;
            this.cassette3_counter_4 = cassette3_counter_4;
            this.cassette3_counter_4Changed = true;
            this.cassette3_counter_5 = cassette3_counter_5;
            this.cassette3_counter_5Changed = true;
            this.cassette3_counter_6 = cassette3_counter_6;
            this.cassette3_counter_6Changed = true;
            this.cassette3_counter_7 = cassette3_counter_7;
            this.cassette3_counter_7Changed = true;
            this.cassette3_counter_8 = cassette3_counter_8;
            this.cassette3_counter_8Changed = true;
            this.cassette3_counter_9 = cassette3_counter_9;
            this.cassette3_counter_9Changed = true;
            this.cassette3_counter_10 = cassette3_counter_10;
            this.cassette3_counter_10Changed = true;
            this.cassette3_counter_11 = cassette3_counter_11;
            this.cassette3_counter_11Changed = true;
            this.cassette3_counter_12 = cassette3_counter_12;
            this.cassette3_counter_12Changed = true;
            this.cassette3_counter_13 = cassette3_counter_13;
            this.cassette3_counter_13Changed = true;
            this.cassette3_counter_14 = cassette3_counter_14;
            this.cassette3_counter_14Changed = true;
            this.cassette3_counter_15 = cassette3_counter_15;
            this.cassette3_counter_15Changed = true;
            this.cassette3_counter_16 = cassette3_counter_16;
            this.cassette3_counter_16Changed = true;
            this.cassette3_counter_17 = cassette3_counter_17;
            this.cassette3_counter_17Changed = true;
            this.cassette3_counter_18 = cassette3_counter_18;
            this.cassette3_counter_18Changed = true;
            this.cassette3_counter_19 = cassette3_counter_19;
            this.cassette3_counter_19Changed = true;
            this.cassette3_counter_20 = cassette3_counter_20;
            this.cassette3_counter_20Changed = true;
            this.cassette3_counter_21 = cassette3_counter_21;
            this.cassette3_counter_21Changed = true;
            this.cassette3_counter_22 = cassette3_counter_22;
            this.cassette3_counter_22Changed = true;
            this.cassette3_counter_23 = cassette3_counter_23;
            this.cassette3_counter_23Changed = true;
            this.cassette3_counter_24 = cassette3_counter_24;
            this.cassette3_counter_24Changed = true;
            this.cassette3_counter_25 = cassette3_counter_25;
            this.cassette3_counter_25Changed = true;
            this.cassette3_counter_26 = cassette3_counter_26;
            this.cassette3_counter_26Changed = true;
            this.cassette3_counter_27 = cassette3_counter_27;
            this.cassette3_counter_27Changed = true;
            this.cassette3_counter_28 = cassette3_counter_28;
            this.cassette3_counter_28Changed = true;
            this.cassette3_counter_29 = cassette3_counter_29;
            this.cassette3_counter_29Changed = true;
            this.cassette3_counter_30 = cassette3_counter_30;
            this.cassette3_counter_30Changed = true;
            this.cassette3_counter_31 = cassette3_counter_31;
            this.cassette3_counter_31Changed = true;
            this.cassette3_counter_32 = cassette3_counter_32;
            this.cassette3_counter_32Changed = true;
            this.cassette3_counter_33 = cassette3_counter_33;
            this.cassette3_counter_33Changed = true;
            this.cassette3_counter_34 = cassette3_counter_34;
            this.cassette3_counter_34Changed = true;
            this.cassette3_counter_35 = cassette3_counter_35;
            this.cassette3_counter_35Changed = true;
            this.cassette3_counter_36 = cassette3_counter_36;
            this.cassette3_counter_36Changed = true;
            this.cassette3_counter_37 = cassette3_counter_37;
            this.cassette3_counter_37Changed = true;
            this.cassette3_counter_38 = cassette3_counter_38;
            this.cassette3_counter_38Changed = true;
            this.cassette3_counter_39 = cassette3_counter_39;
            this.cassette3_counter_39Changed = true;
            this.cassette3_counter_40 = cassette3_counter_40;
            this.cassette3_counter_40Changed = true;
            this.cassette3_counter_41 = cassette3_counter_41;
            this.cassette3_counter_41Changed = true;
            this.cassette3_counter_42 = cassette3_counter_42;
            this.cassette3_counter_42Changed = true;
            this.cassette3_counter_43 = cassette3_counter_43;
            this.cassette3_counter_43Changed = true;
            this.cassette3_counter_44 = cassette3_counter_44;
            this.cassette3_counter_44Changed = true;
            this.cassette3_counter_45 = cassette3_counter_45;
            this.cassette3_counter_45Changed = true;
            this.cassette3_counter_46 = cassette3_counter_46;
            this.cassette3_counter_46Changed = true;
            this.cassette3_counter_47 = cassette3_counter_47;
            this.cassette3_counter_47Changed = true;
            this.cassette3_counter_48 = cassette3_counter_48;
            this.cassette3_counter_48Changed = true;
            this.cassette3_counter_49 = cassette3_counter_49;
            this.cassette3_counter_49Changed = true;
            this.cassette3_counter_50 = cassette3_counter_50;
            this.cassette3_counter_50Changed = true;
            this.cassette4_counter_1 = cassette4_counter_1;
            this.cassette4_counter_1Changed = true;
            this.cassette4_counter_2 = cassette4_counter_2;
            this.cassette4_counter_2Changed = true;
            this.cassette4_counter_3 = cassette4_counter_3;
            this.cassette4_counter_3Changed = true;
            this.cassette4_counter_4 = cassette4_counter_4;
            this.cassette4_counter_4Changed = true;
            this.cassette4_counter_5 = cassette4_counter_5;
            this.cassette4_counter_5Changed = true;
            this.cassette4_counter_6 = cassette4_counter_6;
            this.cassette4_counter_6Changed = true;
            this.cassette4_counter_7 = cassette4_counter_7;
            this.cassette4_counter_7Changed = true;
            this.cassette4_counter_8 = cassette4_counter_8;
            this.cassette4_counter_8Changed = true;
            this.cassette4_counter_9 = cassette4_counter_9;
            this.cassette4_counter_9Changed = true;
            this.cassette4_counter_10 = cassette4_counter_10;
            this.cassette4_counter_10Changed = true;
            this.cassette4_counter_11 = cassette4_counter_11;
            this.cassette4_counter_11Changed = true;
            this.cassette4_counter_12 = cassette4_counter_12;
            this.cassette4_counter_12Changed = true;
            this.cassette4_counter_13 = cassette4_counter_13;
            this.cassette4_counter_13Changed = true;
            this.cassette4_counter_14 = cassette4_counter_14;
            this.cassette4_counter_14Changed = true;
            this.cassette4_counter_15 = cassette4_counter_15;
            this.cassette4_counter_15Changed = true;
            this.cassette4_counter_16 = cassette4_counter_16;
            this.cassette4_counter_16Changed = true;
            this.cassette4_counter_17 = cassette4_counter_17;
            this.cassette4_counter_17Changed = true;
            this.cassette4_counter_18 = cassette4_counter_18;
            this.cassette4_counter_18Changed = true;
            this.cassette4_counter_19 = cassette4_counter_19;
            this.cassette4_counter_19Changed = true;
            this.cassette4_counter_20 = cassette4_counter_20;
            this.cassette4_counter_20Changed = true;
            this.cassette4_counter_21 = cassette4_counter_21;
            this.cassette4_counter_21Changed = true;
            this.cassette4_counter_22 = cassette4_counter_22;
            this.cassette4_counter_22Changed = true;
            this.cassette4_counter_23 = cassette4_counter_23;
            this.cassette4_counter_23Changed = true;
            this.cassette4_counter_24 = cassette4_counter_24;
            this.cassette4_counter_24Changed = true;
            this.cassette4_counter_25 = cassette4_counter_25;
            this.cassette4_counter_25Changed = true;
            this.cassette4_counter_26 = cassette4_counter_26;
            this.cassette4_counter_26Changed = true;
            this.cassette4_counter_27 = cassette4_counter_27;
            this.cassette4_counter_27Changed = true;
            this.cassette4_counter_28 = cassette4_counter_28;
            this.cassette4_counter_28Changed = true;
            this.cassette4_counter_29 = cassette4_counter_29;
            this.cassette4_counter_29Changed = true;
            this.cassette4_counter_30 = cassette4_counter_30;
            this.cassette4_counter_30Changed = true;
            this.cassette4_counter_31 = cassette4_counter_31;
            this.cassette4_counter_31Changed = true;
            this.cassette4_counter_32 = cassette4_counter_32;
            this.cassette4_counter_32Changed = true;
            this.cassette4_counter_33 = cassette4_counter_33;
            this.cassette4_counter_33Changed = true;
            this.cassette4_counter_34 = cassette4_counter_34;
            this.cassette4_counter_34Changed = true;
            this.cassette4_counter_35 = cassette4_counter_35;
            this.cassette4_counter_35Changed = true;
            this.cassette4_counter_36 = cassette4_counter_36;
            this.cassette4_counter_36Changed = true;
            this.cassette4_counter_37 = cassette4_counter_37;
            this.cassette4_counter_37Changed = true;
            this.cassette4_counter_38 = cassette4_counter_38;
            this.cassette4_counter_38Changed = true;
            this.cassette4_counter_39 = cassette4_counter_39;
            this.cassette4_counter_39Changed = true;
            this.cassette4_counter_40 = cassette4_counter_40;
            this.cassette4_counter_40Changed = true;
            this.cassette4_counter_41 = cassette4_counter_41;
            this.cassette4_counter_41Changed = true;
            this.cassette4_counter_42 = cassette4_counter_42;
            this.cassette4_counter_42Changed = true;
            this.cassette4_counter_43 = cassette4_counter_43;
            this.cassette4_counter_43Changed = true;
            this.cassette4_counter_44 = cassette4_counter_44;
            this.cassette4_counter_44Changed = true;
            this.cassette4_counter_45 = cassette4_counter_45;
            this.cassette4_counter_45Changed = true;
            this.cassette4_counter_46 = cassette4_counter_46;
            this.cassette4_counter_46Changed = true;
            this.cassette4_counter_47 = cassette4_counter_47;
            this.cassette4_counter_47Changed = true;
            this.cassette4_counter_48 = cassette4_counter_48;
            this.cassette4_counter_48Changed = true;
            this.cassette4_counter_49 = cassette4_counter_49;
            this.cassette4_counter_49Changed = true;
            this.cassette4_counter_50 = cassette4_counter_50;
            this.cassette4_counter_50Changed = true;
            this.purge_counter_1 = purge_counter_1;
            this.purge_counter_1Changed = true;
            this.purge_counter_2 = purge_counter_2;
            this.purge_counter_2Changed = true;
            this.purge_counter_3 = purge_counter_3;
            this.purge_counter_3Changed = true;
            this.purge_counter_4 = purge_counter_4;
            this.purge_counter_4Changed = true;
            this.purge_counter_5 = purge_counter_5;
            this.purge_counter_5Changed = true;
            this.purge_counter_6 = purge_counter_6;
            this.purge_counter_6Changed = true;
            this.purge_counter_7 = purge_counter_7;
            this.purge_counter_7Changed = true;
            this.purge_counter_8 = purge_counter_8;
            this.purge_counter_8Changed = true;
            this.purge_counter_9 = purge_counter_9;
            this.purge_counter_9Changed = true;
            this.purge_counter_10 = purge_counter_10;
            this.purge_counter_10Changed = true;
            this.purge_counter_11 = purge_counter_11;
            this.purge_counter_11Changed = true;
            this.purge_counter_12 = purge_counter_12;
            this.purge_counter_12Changed = true;
            this.purge_counter_13 = purge_counter_13;
            this.purge_counter_13Changed = true;
            this.purge_counter_14 = purge_counter_14;
            this.purge_counter_14Changed = true;
            this.purge_counter_15 = purge_counter_15;
            this.purge_counter_15Changed = true;
            this.purge_counter_16 = purge_counter_16;
            this.purge_counter_16Changed = true;
            this.purge_counter_17 = purge_counter_17;
            this.purge_counter_17Changed = true;
            this.purge_counter_18 = purge_counter_18;
            this.purge_counter_18Changed = true;
            this.purge_counter_19 = purge_counter_19;
            this.purge_counter_19Changed = true;
            this.purge_counter_20 = purge_counter_20;
            this.purge_counter_20Changed = true;
            this.purge_counter_21 = purge_counter_21;
            this.purge_counter_21Changed = true;
            this.purge_counter_22 = purge_counter_22;
            this.purge_counter_22Changed = true;
            this.purge_counter_23 = purge_counter_23;
            this.purge_counter_23Changed = true;
            this.purge_counter_24 = purge_counter_24;
            this.purge_counter_24Changed = true;
            this.purge_counter_25 = purge_counter_25;
            this.purge_counter_25Changed = true;
            this.purge_counter_26 = purge_counter_26;
            this.purge_counter_26Changed = true;
            this.purge_counter_27 = purge_counter_27;
            this.purge_counter_27Changed = true;
            this.purge_counter_28 = purge_counter_28;
            this.purge_counter_28Changed = true;
            this.purge_counter_29 = purge_counter_29;
            this.purge_counter_29Changed = true;
            this.purge_counter_30 = purge_counter_30;
            this.purge_counter_30Changed = true;
            this.purge_counter_31 = purge_counter_31;
            this.purge_counter_31Changed = true;
            this.purge_counter_32 = purge_counter_32;
            this.purge_counter_32Changed = true;
            this.purge_counter_33 = purge_counter_33;
            this.purge_counter_33Changed = true;
            this.purge_counter_34 = purge_counter_34;
            this.purge_counter_34Changed = true;
            this.purge_counter_35 = purge_counter_35;
            this.purge_counter_35Changed = true;
            this.purge_counter_36 = purge_counter_36;
            this.purge_counter_36Changed = true;
            this.purge_counter_37 = purge_counter_37;
            this.purge_counter_37Changed = true;
            this.purge_counter_38 = purge_counter_38;
            this.purge_counter_38Changed = true;
            this.purge_counter_39 = purge_counter_39;
            this.purge_counter_39Changed = true;
            this.purge_counter_40 = purge_counter_40;
            this.purge_counter_40Changed = true;
            this.purge_counter_41 = purge_counter_41;
            this.purge_counter_41Changed = true;
            this.purge_counter_42 = purge_counter_42;
            this.purge_counter_42Changed = true;
            this.purge_counter_43 = purge_counter_43;
            this.purge_counter_43Changed = true;
            this.purge_counter_44 = purge_counter_44;
            this.purge_counter_44Changed = true;
            this.purge_counter_45 = purge_counter_45;
            this.purge_counter_45Changed = true;
            this.purge_counter_46 = purge_counter_46;
            this.purge_counter_46Changed = true;
            this.purge_counter_47 = purge_counter_47;
            this.purge_counter_47Changed = true;
            this.purge_counter_48 = purge_counter_48;
            this.purge_counter_48Changed = true;
            this.purge_counter_49 = purge_counter_49;
            this.purge_counter_49Changed = true;
            this.purge_counter_50 = purge_counter_50;
            this.purge_counter_50Changed = true;
            this.last_deposit_at = last_deposit_at;
            this.last_deposit_atChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.cassette1_denomination_detail = cassette1_denomination_detail;
            this.cassette1_denomination_detailChanged = true;
            this.cassette2_denomination_detail = cassette2_denomination_detail;
            this.cassette2_denomination_detailChanged = true;
            this.cassette3_denomination_detail = cassette3_denomination_detail;
            this.cassette3_denomination_detailChanged = true;
            this.cassette4_denomination_detail = cassette4_denomination_detail;
            this.cassette4_denomination_detailChanged = true;
            this.purge_denomination_detail = purge_denomination_detail;
            this.purge_denomination_detailChanged = true;
        }
        private ParsedBnaCounter(int parsed_bna_counter_id, int? cassette1_counter_1, int? cassette1_counter_2, int? cassette1_counter_3, int? cassette1_counter_4, int? cassette1_counter_5, int? cassette1_counter_6, int? cassette1_counter_7, int? cassette1_counter_8, int? cassette1_counter_9, int? cassette1_counter_10, int? cassette1_counter_11, int? cassette1_counter_12, int? cassette1_counter_13, int? cassette1_counter_14, int? cassette1_counter_15, int? cassette1_counter_16, int? cassette1_counter_17, int? cassette1_counter_18, int? cassette1_counter_19, int? cassette1_counter_20, int? cassette1_counter_21, int? cassette1_counter_22, int? cassette1_counter_23, int? cassette1_counter_24, int? cassette1_counter_25, int? cassette1_counter_26, int? cassette1_counter_27, int? cassette1_counter_28, int? cassette1_counter_29, int? cassette1_counter_30, int? cassette1_counter_31, int? cassette1_counter_32, int? cassette1_counter_33, int? cassette1_counter_34, int? cassette1_counter_35, int? cassette1_counter_36, int? cassette1_counter_37, int? cassette1_counter_38, int? cassette1_counter_39, int? cassette1_counter_40, int? cassette1_counter_41, int? cassette1_counter_42, int? cassette1_counter_43, int? cassette1_counter_44, int? cassette1_counter_45, int? cassette1_counter_46, int? cassette1_counter_47, int? cassette1_counter_48, int? cassette1_counter_49, int? cassette1_counter_50, int? cassette2_counter_1, int? cassette2_counter_2, int? cassette2_counter_3, int? cassette2_counter_4, int? cassette2_counter_5, int? cassette2_counter_6, int? cassette2_counter_7, int? cassette2_counter_8, int? cassette2_counter_9, int? cassette2_counter_10, int? cassette2_counter_11, int? cassette2_counter_12, int? cassette2_counter_13, int? cassette2_counter_14, int? cassette2_counter_15, int? cassette2_counter_16, int? cassette2_counter_17, int? cassette2_counter_18, int? cassette2_counter_19, int? cassette2_counter_20, int? cassette2_counter_21, int? cassette2_counter_22, int? cassette2_counter_23, int? cassette2_counter_24, int? cassette2_counter_25, int? cassette2_counter_26, int? cassette2_counter_27, int? cassette2_counter_28, int? cassette2_counter_29, int? cassette2_counter_30, int? cassette2_counter_31, int? cassette2_counter_32, int? cassette2_counter_33, int? cassette2_counter_34, int? cassette2_counter_35, int? cassette2_counter_36, int? cassette2_counter_37, int? cassette2_counter_38, int? cassette2_counter_39, int? cassette2_counter_40, int? cassette2_counter_41, int? cassette2_counter_42, int? cassette2_counter_43, int? cassette2_counter_44, int? cassette2_counter_45, int? cassette2_counter_46, int? cassette2_counter_47, int? cassette2_counter_48, int? cassette2_counter_49, int? cassette2_counter_50, int? cassette3_counter_1, int? cassette3_counter_2, int? cassette3_counter_3, int? cassette3_counter_4, int? cassette3_counter_5, int? cassette3_counter_6, int? cassette3_counter_7, int? cassette3_counter_8, int? cassette3_counter_9, int? cassette3_counter_10, int? cassette3_counter_11, int? cassette3_counter_12, int? cassette3_counter_13, int? cassette3_counter_14, int? cassette3_counter_15, int? cassette3_counter_16, int? cassette3_counter_17, int? cassette3_counter_18, int? cassette3_counter_19, int? cassette3_counter_20, int? cassette3_counter_21, int? cassette3_counter_22, int? cassette3_counter_23, int? cassette3_counter_24, int? cassette3_counter_25, int? cassette3_counter_26, int? cassette3_counter_27, int? cassette3_counter_28, int? cassette3_counter_29, int? cassette3_counter_30, int? cassette3_counter_31, int? cassette3_counter_32, int? cassette3_counter_33, int? cassette3_counter_34, int? cassette3_counter_35, int? cassette3_counter_36, int? cassette3_counter_37, int? cassette3_counter_38, int? cassette3_counter_39, int? cassette3_counter_40, int? cassette3_counter_41, int? cassette3_counter_42, int? cassette3_counter_43, int? cassette3_counter_44, int? cassette3_counter_45, int? cassette3_counter_46, int? cassette3_counter_47, int? cassette3_counter_48, int? cassette3_counter_49, int? cassette3_counter_50, int? cassette4_counter_1, int? cassette4_counter_2, int? cassette4_counter_3, int? cassette4_counter_4, int? cassette4_counter_5, int? cassette4_counter_6, int? cassette4_counter_7, int? cassette4_counter_8, int? cassette4_counter_9, int? cassette4_counter_10, int? cassette4_counter_11, int? cassette4_counter_12, int? cassette4_counter_13, int? cassette4_counter_14, int? cassette4_counter_15, int? cassette4_counter_16, int? cassette4_counter_17, int? cassette4_counter_18, int? cassette4_counter_19, int? cassette4_counter_20, int? cassette4_counter_21, int? cassette4_counter_22, int? cassette4_counter_23, int? cassette4_counter_24, int? cassette4_counter_25, int? cassette4_counter_26, int? cassette4_counter_27, int? cassette4_counter_28, int? cassette4_counter_29, int? cassette4_counter_30, int? cassette4_counter_31, int? cassette4_counter_32, int? cassette4_counter_33, int? cassette4_counter_34, int? cassette4_counter_35, int? cassette4_counter_36, int? cassette4_counter_37, int? cassette4_counter_38, int? cassette4_counter_39, int? cassette4_counter_40, int? cassette4_counter_41, int? cassette4_counter_42, int? cassette4_counter_43, int? cassette4_counter_44, int? cassette4_counter_45, int? cassette4_counter_46, int? cassette4_counter_47, int? cassette4_counter_48, int? cassette4_counter_49, int? cassette4_counter_50, int? purge_counter_1, int? purge_counter_2, int? purge_counter_3, int? purge_counter_4, int? purge_counter_5, int? purge_counter_6, int? purge_counter_7, int? purge_counter_8, int? purge_counter_9, int? purge_counter_10, int? purge_counter_11, int? purge_counter_12, int? purge_counter_13, int? purge_counter_14, int? purge_counter_15, int? purge_counter_16, int? purge_counter_17, int? purge_counter_18, int? purge_counter_19, int? purge_counter_20, int? purge_counter_21, int? purge_counter_22, int? purge_counter_23, int? purge_counter_24, int? purge_counter_25, int? purge_counter_26, int? purge_counter_27, int? purge_counter_28, int? purge_counter_29, int? purge_counter_30, int? purge_counter_31, int? purge_counter_32, int? purge_counter_33, int? purge_counter_34, int? purge_counter_35, int? purge_counter_36, int? purge_counter_37, int? purge_counter_38, int? purge_counter_39, int? purge_counter_40, int? purge_counter_41, int? purge_counter_42, int? purge_counter_43, int? purge_counter_44, int? purge_counter_45, int? purge_counter_46, int? purge_counter_47, int? purge_counter_48, int? purge_counter_49, int? purge_counter_50, DateTime last_deposit_at, int atm_id, int task_id, string cassette1_denomination_detail, string cassette2_denomination_detail, string cassette3_denomination_detail, string cassette4_denomination_detail, string purge_denomination_detail)
        {
            this.parsed_bna_counter_id = parsed_bna_counter_id;
            this.parsed_bna_counter_idChanged = true;
            this.cassette1_counter_1 = cassette1_counter_1;
            this.cassette1_counter_1Changed = true;
            this.cassette1_counter_2 = cassette1_counter_2;
            this.cassette1_counter_2Changed = true;
            this.cassette1_counter_3 = cassette1_counter_3;
            this.cassette1_counter_3Changed = true;
            this.cassette1_counter_4 = cassette1_counter_4;
            this.cassette1_counter_4Changed = true;
            this.cassette1_counter_5 = cassette1_counter_5;
            this.cassette1_counter_5Changed = true;
            this.cassette1_counter_6 = cassette1_counter_6;
            this.cassette1_counter_6Changed = true;
            this.cassette1_counter_7 = cassette1_counter_7;
            this.cassette1_counter_7Changed = true;
            this.cassette1_counter_8 = cassette1_counter_8;
            this.cassette1_counter_8Changed = true;
            this.cassette1_counter_9 = cassette1_counter_9;
            this.cassette1_counter_9Changed = true;
            this.cassette1_counter_10 = cassette1_counter_10;
            this.cassette1_counter_10Changed = true;
            this.cassette1_counter_11 = cassette1_counter_11;
            this.cassette1_counter_11Changed = true;
            this.cassette1_counter_12 = cassette1_counter_12;
            this.cassette1_counter_12Changed = true;
            this.cassette1_counter_13 = cassette1_counter_13;
            this.cassette1_counter_13Changed = true;
            this.cassette1_counter_14 = cassette1_counter_14;
            this.cassette1_counter_14Changed = true;
            this.cassette1_counter_15 = cassette1_counter_15;
            this.cassette1_counter_15Changed = true;
            this.cassette1_counter_16 = cassette1_counter_16;
            this.cassette1_counter_16Changed = true;
            this.cassette1_counter_17 = cassette1_counter_17;
            this.cassette1_counter_17Changed = true;
            this.cassette1_counter_18 = cassette1_counter_18;
            this.cassette1_counter_18Changed = true;
            this.cassette1_counter_19 = cassette1_counter_19;
            this.cassette1_counter_19Changed = true;
            this.cassette1_counter_20 = cassette1_counter_20;
            this.cassette1_counter_20Changed = true;
            this.cassette1_counter_21 = cassette1_counter_21;
            this.cassette1_counter_21Changed = true;
            this.cassette1_counter_22 = cassette1_counter_22;
            this.cassette1_counter_22Changed = true;
            this.cassette1_counter_23 = cassette1_counter_23;
            this.cassette1_counter_23Changed = true;
            this.cassette1_counter_24 = cassette1_counter_24;
            this.cassette1_counter_24Changed = true;
            this.cassette1_counter_25 = cassette1_counter_25;
            this.cassette1_counter_25Changed = true;
            this.cassette1_counter_26 = cassette1_counter_26;
            this.cassette1_counter_26Changed = true;
            this.cassette1_counter_27 = cassette1_counter_27;
            this.cassette1_counter_27Changed = true;
            this.cassette1_counter_28 = cassette1_counter_28;
            this.cassette1_counter_28Changed = true;
            this.cassette1_counter_29 = cassette1_counter_29;
            this.cassette1_counter_29Changed = true;
            this.cassette1_counter_30 = cassette1_counter_30;
            this.cassette1_counter_30Changed = true;
            this.cassette1_counter_31 = cassette1_counter_31;
            this.cassette1_counter_31Changed = true;
            this.cassette1_counter_32 = cassette1_counter_32;
            this.cassette1_counter_32Changed = true;
            this.cassette1_counter_33 = cassette1_counter_33;
            this.cassette1_counter_33Changed = true;
            this.cassette1_counter_34 = cassette1_counter_34;
            this.cassette1_counter_34Changed = true;
            this.cassette1_counter_35 = cassette1_counter_35;
            this.cassette1_counter_35Changed = true;
            this.cassette1_counter_36 = cassette1_counter_36;
            this.cassette1_counter_36Changed = true;
            this.cassette1_counter_37 = cassette1_counter_37;
            this.cassette1_counter_37Changed = true;
            this.cassette1_counter_38 = cassette1_counter_38;
            this.cassette1_counter_38Changed = true;
            this.cassette1_counter_39 = cassette1_counter_39;
            this.cassette1_counter_39Changed = true;
            this.cassette1_counter_40 = cassette1_counter_40;
            this.cassette1_counter_40Changed = true;
            this.cassette1_counter_41 = cassette1_counter_41;
            this.cassette1_counter_41Changed = true;
            this.cassette1_counter_42 = cassette1_counter_42;
            this.cassette1_counter_42Changed = true;
            this.cassette1_counter_43 = cassette1_counter_43;
            this.cassette1_counter_43Changed = true;
            this.cassette1_counter_44 = cassette1_counter_44;
            this.cassette1_counter_44Changed = true;
            this.cassette1_counter_45 = cassette1_counter_45;
            this.cassette1_counter_45Changed = true;
            this.cassette1_counter_46 = cassette1_counter_46;
            this.cassette1_counter_46Changed = true;
            this.cassette1_counter_47 = cassette1_counter_47;
            this.cassette1_counter_47Changed = true;
            this.cassette1_counter_48 = cassette1_counter_48;
            this.cassette1_counter_48Changed = true;
            this.cassette1_counter_49 = cassette1_counter_49;
            this.cassette1_counter_49Changed = true;
            this.cassette1_counter_50 = cassette1_counter_50;
            this.cassette1_counter_50Changed = true;
            this.cassette2_counter_1 = cassette2_counter_1;
            this.cassette2_counter_1Changed = true;
            this.cassette2_counter_2 = cassette2_counter_2;
            this.cassette2_counter_2Changed = true;
            this.cassette2_counter_3 = cassette2_counter_3;
            this.cassette2_counter_3Changed = true;
            this.cassette2_counter_4 = cassette2_counter_4;
            this.cassette2_counter_4Changed = true;
            this.cassette2_counter_5 = cassette2_counter_5;
            this.cassette2_counter_5Changed = true;
            this.cassette2_counter_6 = cassette2_counter_6;
            this.cassette2_counter_6Changed = true;
            this.cassette2_counter_7 = cassette2_counter_7;
            this.cassette2_counter_7Changed = true;
            this.cassette2_counter_8 = cassette2_counter_8;
            this.cassette2_counter_8Changed = true;
            this.cassette2_counter_9 = cassette2_counter_9;
            this.cassette2_counter_9Changed = true;
            this.cassette2_counter_10 = cassette2_counter_10;
            this.cassette2_counter_10Changed = true;
            this.cassette2_counter_11 = cassette2_counter_11;
            this.cassette2_counter_11Changed = true;
            this.cassette2_counter_12 = cassette2_counter_12;
            this.cassette2_counter_12Changed = true;
            this.cassette2_counter_13 = cassette2_counter_13;
            this.cassette2_counter_13Changed = true;
            this.cassette2_counter_14 = cassette2_counter_14;
            this.cassette2_counter_14Changed = true;
            this.cassette2_counter_15 = cassette2_counter_15;
            this.cassette2_counter_15Changed = true;
            this.cassette2_counter_16 = cassette2_counter_16;
            this.cassette2_counter_16Changed = true;
            this.cassette2_counter_17 = cassette2_counter_17;
            this.cassette2_counter_17Changed = true;
            this.cassette2_counter_18 = cassette2_counter_18;
            this.cassette2_counter_18Changed = true;
            this.cassette2_counter_19 = cassette2_counter_19;
            this.cassette2_counter_19Changed = true;
            this.cassette2_counter_20 = cassette2_counter_20;
            this.cassette2_counter_20Changed = true;
            this.cassette2_counter_21 = cassette2_counter_21;
            this.cassette2_counter_21Changed = true;
            this.cassette2_counter_22 = cassette2_counter_22;
            this.cassette2_counter_22Changed = true;
            this.cassette2_counter_23 = cassette2_counter_23;
            this.cassette2_counter_23Changed = true;
            this.cassette2_counter_24 = cassette2_counter_24;
            this.cassette2_counter_24Changed = true;
            this.cassette2_counter_25 = cassette2_counter_25;
            this.cassette2_counter_25Changed = true;
            this.cassette2_counter_26 = cassette2_counter_26;
            this.cassette2_counter_26Changed = true;
            this.cassette2_counter_27 = cassette2_counter_27;
            this.cassette2_counter_27Changed = true;
            this.cassette2_counter_28 = cassette2_counter_28;
            this.cassette2_counter_28Changed = true;
            this.cassette2_counter_29 = cassette2_counter_29;
            this.cassette2_counter_29Changed = true;
            this.cassette2_counter_30 = cassette2_counter_30;
            this.cassette2_counter_30Changed = true;
            this.cassette2_counter_31 = cassette2_counter_31;
            this.cassette2_counter_31Changed = true;
            this.cassette2_counter_32 = cassette2_counter_32;
            this.cassette2_counter_32Changed = true;
            this.cassette2_counter_33 = cassette2_counter_33;
            this.cassette2_counter_33Changed = true;
            this.cassette2_counter_34 = cassette2_counter_34;
            this.cassette2_counter_34Changed = true;
            this.cassette2_counter_35 = cassette2_counter_35;
            this.cassette2_counter_35Changed = true;
            this.cassette2_counter_36 = cassette2_counter_36;
            this.cassette2_counter_36Changed = true;
            this.cassette2_counter_37 = cassette2_counter_37;
            this.cassette2_counter_37Changed = true;
            this.cassette2_counter_38 = cassette2_counter_38;
            this.cassette2_counter_38Changed = true;
            this.cassette2_counter_39 = cassette2_counter_39;
            this.cassette2_counter_39Changed = true;
            this.cassette2_counter_40 = cassette2_counter_40;
            this.cassette2_counter_40Changed = true;
            this.cassette2_counter_41 = cassette2_counter_41;
            this.cassette2_counter_41Changed = true;
            this.cassette2_counter_42 = cassette2_counter_42;
            this.cassette2_counter_42Changed = true;
            this.cassette2_counter_43 = cassette2_counter_43;
            this.cassette2_counter_43Changed = true;
            this.cassette2_counter_44 = cassette2_counter_44;
            this.cassette2_counter_44Changed = true;
            this.cassette2_counter_45 = cassette2_counter_45;
            this.cassette2_counter_45Changed = true;
            this.cassette2_counter_46 = cassette2_counter_46;
            this.cassette2_counter_46Changed = true;
            this.cassette2_counter_47 = cassette2_counter_47;
            this.cassette2_counter_47Changed = true;
            this.cassette2_counter_48 = cassette2_counter_48;
            this.cassette2_counter_48Changed = true;
            this.cassette2_counter_49 = cassette2_counter_49;
            this.cassette2_counter_49Changed = true;
            this.cassette2_counter_50 = cassette2_counter_50;
            this.cassette2_counter_50Changed = true;
            this.cassette3_counter_1 = cassette3_counter_1;
            this.cassette3_counter_1Changed = true;
            this.cassette3_counter_2 = cassette3_counter_2;
            this.cassette3_counter_2Changed = true;
            this.cassette3_counter_3 = cassette3_counter_3;
            this.cassette3_counter_3Changed = true;
            this.cassette3_counter_4 = cassette3_counter_4;
            this.cassette3_counter_4Changed = true;
            this.cassette3_counter_5 = cassette3_counter_5;
            this.cassette3_counter_5Changed = true;
            this.cassette3_counter_6 = cassette3_counter_6;
            this.cassette3_counter_6Changed = true;
            this.cassette3_counter_7 = cassette3_counter_7;
            this.cassette3_counter_7Changed = true;
            this.cassette3_counter_8 = cassette3_counter_8;
            this.cassette3_counter_8Changed = true;
            this.cassette3_counter_9 = cassette3_counter_9;
            this.cassette3_counter_9Changed = true;
            this.cassette3_counter_10 = cassette3_counter_10;
            this.cassette3_counter_10Changed = true;
            this.cassette3_counter_11 = cassette3_counter_11;
            this.cassette3_counter_11Changed = true;
            this.cassette3_counter_12 = cassette3_counter_12;
            this.cassette3_counter_12Changed = true;
            this.cassette3_counter_13 = cassette3_counter_13;
            this.cassette3_counter_13Changed = true;
            this.cassette3_counter_14 = cassette3_counter_14;
            this.cassette3_counter_14Changed = true;
            this.cassette3_counter_15 = cassette3_counter_15;
            this.cassette3_counter_15Changed = true;
            this.cassette3_counter_16 = cassette3_counter_16;
            this.cassette3_counter_16Changed = true;
            this.cassette3_counter_17 = cassette3_counter_17;
            this.cassette3_counter_17Changed = true;
            this.cassette3_counter_18 = cassette3_counter_18;
            this.cassette3_counter_18Changed = true;
            this.cassette3_counter_19 = cassette3_counter_19;
            this.cassette3_counter_19Changed = true;
            this.cassette3_counter_20 = cassette3_counter_20;
            this.cassette3_counter_20Changed = true;
            this.cassette3_counter_21 = cassette3_counter_21;
            this.cassette3_counter_21Changed = true;
            this.cassette3_counter_22 = cassette3_counter_22;
            this.cassette3_counter_22Changed = true;
            this.cassette3_counter_23 = cassette3_counter_23;
            this.cassette3_counter_23Changed = true;
            this.cassette3_counter_24 = cassette3_counter_24;
            this.cassette3_counter_24Changed = true;
            this.cassette3_counter_25 = cassette3_counter_25;
            this.cassette3_counter_25Changed = true;
            this.cassette3_counter_26 = cassette3_counter_26;
            this.cassette3_counter_26Changed = true;
            this.cassette3_counter_27 = cassette3_counter_27;
            this.cassette3_counter_27Changed = true;
            this.cassette3_counter_28 = cassette3_counter_28;
            this.cassette3_counter_28Changed = true;
            this.cassette3_counter_29 = cassette3_counter_29;
            this.cassette3_counter_29Changed = true;
            this.cassette3_counter_30 = cassette3_counter_30;
            this.cassette3_counter_30Changed = true;
            this.cassette3_counter_31 = cassette3_counter_31;
            this.cassette3_counter_31Changed = true;
            this.cassette3_counter_32 = cassette3_counter_32;
            this.cassette3_counter_32Changed = true;
            this.cassette3_counter_33 = cassette3_counter_33;
            this.cassette3_counter_33Changed = true;
            this.cassette3_counter_34 = cassette3_counter_34;
            this.cassette3_counter_34Changed = true;
            this.cassette3_counter_35 = cassette3_counter_35;
            this.cassette3_counter_35Changed = true;
            this.cassette3_counter_36 = cassette3_counter_36;
            this.cassette3_counter_36Changed = true;
            this.cassette3_counter_37 = cassette3_counter_37;
            this.cassette3_counter_37Changed = true;
            this.cassette3_counter_38 = cassette3_counter_38;
            this.cassette3_counter_38Changed = true;
            this.cassette3_counter_39 = cassette3_counter_39;
            this.cassette3_counter_39Changed = true;
            this.cassette3_counter_40 = cassette3_counter_40;
            this.cassette3_counter_40Changed = true;
            this.cassette3_counter_41 = cassette3_counter_41;
            this.cassette3_counter_41Changed = true;
            this.cassette3_counter_42 = cassette3_counter_42;
            this.cassette3_counter_42Changed = true;
            this.cassette3_counter_43 = cassette3_counter_43;
            this.cassette3_counter_43Changed = true;
            this.cassette3_counter_44 = cassette3_counter_44;
            this.cassette3_counter_44Changed = true;
            this.cassette3_counter_45 = cassette3_counter_45;
            this.cassette3_counter_45Changed = true;
            this.cassette3_counter_46 = cassette3_counter_46;
            this.cassette3_counter_46Changed = true;
            this.cassette3_counter_47 = cassette3_counter_47;
            this.cassette3_counter_47Changed = true;
            this.cassette3_counter_48 = cassette3_counter_48;
            this.cassette3_counter_48Changed = true;
            this.cassette3_counter_49 = cassette3_counter_49;
            this.cassette3_counter_49Changed = true;
            this.cassette3_counter_50 = cassette3_counter_50;
            this.cassette3_counter_50Changed = true;
            this.cassette4_counter_1 = cassette4_counter_1;
            this.cassette4_counter_1Changed = true;
            this.cassette4_counter_2 = cassette4_counter_2;
            this.cassette4_counter_2Changed = true;
            this.cassette4_counter_3 = cassette4_counter_3;
            this.cassette4_counter_3Changed = true;
            this.cassette4_counter_4 = cassette4_counter_4;
            this.cassette4_counter_4Changed = true;
            this.cassette4_counter_5 = cassette4_counter_5;
            this.cassette4_counter_5Changed = true;
            this.cassette4_counter_6 = cassette4_counter_6;
            this.cassette4_counter_6Changed = true;
            this.cassette4_counter_7 = cassette4_counter_7;
            this.cassette4_counter_7Changed = true;
            this.cassette4_counter_8 = cassette4_counter_8;
            this.cassette4_counter_8Changed = true;
            this.cassette4_counter_9 = cassette4_counter_9;
            this.cassette4_counter_9Changed = true;
            this.cassette4_counter_10 = cassette4_counter_10;
            this.cassette4_counter_10Changed = true;
            this.cassette4_counter_11 = cassette4_counter_11;
            this.cassette4_counter_11Changed = true;
            this.cassette4_counter_12 = cassette4_counter_12;
            this.cassette4_counter_12Changed = true;
            this.cassette4_counter_13 = cassette4_counter_13;
            this.cassette4_counter_13Changed = true;
            this.cassette4_counter_14 = cassette4_counter_14;
            this.cassette4_counter_14Changed = true;
            this.cassette4_counter_15 = cassette4_counter_15;
            this.cassette4_counter_15Changed = true;
            this.cassette4_counter_16 = cassette4_counter_16;
            this.cassette4_counter_16Changed = true;
            this.cassette4_counter_17 = cassette4_counter_17;
            this.cassette4_counter_17Changed = true;
            this.cassette4_counter_18 = cassette4_counter_18;
            this.cassette4_counter_18Changed = true;
            this.cassette4_counter_19 = cassette4_counter_19;
            this.cassette4_counter_19Changed = true;
            this.cassette4_counter_20 = cassette4_counter_20;
            this.cassette4_counter_20Changed = true;
            this.cassette4_counter_21 = cassette4_counter_21;
            this.cassette4_counter_21Changed = true;
            this.cassette4_counter_22 = cassette4_counter_22;
            this.cassette4_counter_22Changed = true;
            this.cassette4_counter_23 = cassette4_counter_23;
            this.cassette4_counter_23Changed = true;
            this.cassette4_counter_24 = cassette4_counter_24;
            this.cassette4_counter_24Changed = true;
            this.cassette4_counter_25 = cassette4_counter_25;
            this.cassette4_counter_25Changed = true;
            this.cassette4_counter_26 = cassette4_counter_26;
            this.cassette4_counter_26Changed = true;
            this.cassette4_counter_27 = cassette4_counter_27;
            this.cassette4_counter_27Changed = true;
            this.cassette4_counter_28 = cassette4_counter_28;
            this.cassette4_counter_28Changed = true;
            this.cassette4_counter_29 = cassette4_counter_29;
            this.cassette4_counter_29Changed = true;
            this.cassette4_counter_30 = cassette4_counter_30;
            this.cassette4_counter_30Changed = true;
            this.cassette4_counter_31 = cassette4_counter_31;
            this.cassette4_counter_31Changed = true;
            this.cassette4_counter_32 = cassette4_counter_32;
            this.cassette4_counter_32Changed = true;
            this.cassette4_counter_33 = cassette4_counter_33;
            this.cassette4_counter_33Changed = true;
            this.cassette4_counter_34 = cassette4_counter_34;
            this.cassette4_counter_34Changed = true;
            this.cassette4_counter_35 = cassette4_counter_35;
            this.cassette4_counter_35Changed = true;
            this.cassette4_counter_36 = cassette4_counter_36;
            this.cassette4_counter_36Changed = true;
            this.cassette4_counter_37 = cassette4_counter_37;
            this.cassette4_counter_37Changed = true;
            this.cassette4_counter_38 = cassette4_counter_38;
            this.cassette4_counter_38Changed = true;
            this.cassette4_counter_39 = cassette4_counter_39;
            this.cassette4_counter_39Changed = true;
            this.cassette4_counter_40 = cassette4_counter_40;
            this.cassette4_counter_40Changed = true;
            this.cassette4_counter_41 = cassette4_counter_41;
            this.cassette4_counter_41Changed = true;
            this.cassette4_counter_42 = cassette4_counter_42;
            this.cassette4_counter_42Changed = true;
            this.cassette4_counter_43 = cassette4_counter_43;
            this.cassette4_counter_43Changed = true;
            this.cassette4_counter_44 = cassette4_counter_44;
            this.cassette4_counter_44Changed = true;
            this.cassette4_counter_45 = cassette4_counter_45;
            this.cassette4_counter_45Changed = true;
            this.cassette4_counter_46 = cassette4_counter_46;
            this.cassette4_counter_46Changed = true;
            this.cassette4_counter_47 = cassette4_counter_47;
            this.cassette4_counter_47Changed = true;
            this.cassette4_counter_48 = cassette4_counter_48;
            this.cassette4_counter_48Changed = true;
            this.cassette4_counter_49 = cassette4_counter_49;
            this.cassette4_counter_49Changed = true;
            this.cassette4_counter_50 = cassette4_counter_50;
            this.cassette4_counter_50Changed = true;
            this.purge_counter_1 = purge_counter_1;
            this.purge_counter_1Changed = true;
            this.purge_counter_2 = purge_counter_2;
            this.purge_counter_2Changed = true;
            this.purge_counter_3 = purge_counter_3;
            this.purge_counter_3Changed = true;
            this.purge_counter_4 = purge_counter_4;
            this.purge_counter_4Changed = true;
            this.purge_counter_5 = purge_counter_5;
            this.purge_counter_5Changed = true;
            this.purge_counter_6 = purge_counter_6;
            this.purge_counter_6Changed = true;
            this.purge_counter_7 = purge_counter_7;
            this.purge_counter_7Changed = true;
            this.purge_counter_8 = purge_counter_8;
            this.purge_counter_8Changed = true;
            this.purge_counter_9 = purge_counter_9;
            this.purge_counter_9Changed = true;
            this.purge_counter_10 = purge_counter_10;
            this.purge_counter_10Changed = true;
            this.purge_counter_11 = purge_counter_11;
            this.purge_counter_11Changed = true;
            this.purge_counter_12 = purge_counter_12;
            this.purge_counter_12Changed = true;
            this.purge_counter_13 = purge_counter_13;
            this.purge_counter_13Changed = true;
            this.purge_counter_14 = purge_counter_14;
            this.purge_counter_14Changed = true;
            this.purge_counter_15 = purge_counter_15;
            this.purge_counter_15Changed = true;
            this.purge_counter_16 = purge_counter_16;
            this.purge_counter_16Changed = true;
            this.purge_counter_17 = purge_counter_17;
            this.purge_counter_17Changed = true;
            this.purge_counter_18 = purge_counter_18;
            this.purge_counter_18Changed = true;
            this.purge_counter_19 = purge_counter_19;
            this.purge_counter_19Changed = true;
            this.purge_counter_20 = purge_counter_20;
            this.purge_counter_20Changed = true;
            this.purge_counter_21 = purge_counter_21;
            this.purge_counter_21Changed = true;
            this.purge_counter_22 = purge_counter_22;
            this.purge_counter_22Changed = true;
            this.purge_counter_23 = purge_counter_23;
            this.purge_counter_23Changed = true;
            this.purge_counter_24 = purge_counter_24;
            this.purge_counter_24Changed = true;
            this.purge_counter_25 = purge_counter_25;
            this.purge_counter_25Changed = true;
            this.purge_counter_26 = purge_counter_26;
            this.purge_counter_26Changed = true;
            this.purge_counter_27 = purge_counter_27;
            this.purge_counter_27Changed = true;
            this.purge_counter_28 = purge_counter_28;
            this.purge_counter_28Changed = true;
            this.purge_counter_29 = purge_counter_29;
            this.purge_counter_29Changed = true;
            this.purge_counter_30 = purge_counter_30;
            this.purge_counter_30Changed = true;
            this.purge_counter_31 = purge_counter_31;
            this.purge_counter_31Changed = true;
            this.purge_counter_32 = purge_counter_32;
            this.purge_counter_32Changed = true;
            this.purge_counter_33 = purge_counter_33;
            this.purge_counter_33Changed = true;
            this.purge_counter_34 = purge_counter_34;
            this.purge_counter_34Changed = true;
            this.purge_counter_35 = purge_counter_35;
            this.purge_counter_35Changed = true;
            this.purge_counter_36 = purge_counter_36;
            this.purge_counter_36Changed = true;
            this.purge_counter_37 = purge_counter_37;
            this.purge_counter_37Changed = true;
            this.purge_counter_38 = purge_counter_38;
            this.purge_counter_38Changed = true;
            this.purge_counter_39 = purge_counter_39;
            this.purge_counter_39Changed = true;
            this.purge_counter_40 = purge_counter_40;
            this.purge_counter_40Changed = true;
            this.purge_counter_41 = purge_counter_41;
            this.purge_counter_41Changed = true;
            this.purge_counter_42 = purge_counter_42;
            this.purge_counter_42Changed = true;
            this.purge_counter_43 = purge_counter_43;
            this.purge_counter_43Changed = true;
            this.purge_counter_44 = purge_counter_44;
            this.purge_counter_44Changed = true;
            this.purge_counter_45 = purge_counter_45;
            this.purge_counter_45Changed = true;
            this.purge_counter_46 = purge_counter_46;
            this.purge_counter_46Changed = true;
            this.purge_counter_47 = purge_counter_47;
            this.purge_counter_47Changed = true;
            this.purge_counter_48 = purge_counter_48;
            this.purge_counter_48Changed = true;
            this.purge_counter_49 = purge_counter_49;
            this.purge_counter_49Changed = true;
            this.purge_counter_50 = purge_counter_50;
            this.purge_counter_50Changed = true;
            this.last_deposit_at = last_deposit_at;
            this.last_deposit_atChanged = true;
            this.atm_id = atm_id;
            this.atm_idChanged = true;
            this.task_id = task_id;
            this.task_idChanged = true;
            this.cassette1_denomination_detail = cassette1_denomination_detail;
            this.cassette1_denomination_detailChanged = true;
            this.cassette2_denomination_detail = cassette2_denomination_detail;
            this.cassette2_denomination_detailChanged = true;
            this.cassette3_denomination_detail = cassette3_denomination_detail;
            this.cassette3_denomination_detailChanged = true;
            this.cassette4_denomination_detail = cassette4_denomination_detail;
            this.cassette4_denomination_detailChanged = true;
            this.purge_denomination_detail = purge_denomination_detail;
            this.purge_denomination_detailChanged = true;
        }

        #region members and properties for columns

        #region ParsedBnaCounterId
        private bool parsed_bna_counter_idChanged = false;
        private int parsed_bna_counter_id;
        public int ParsedBnaCounterId
        {
            get { return parsed_bna_counter_id; }
            set
            {
                parsed_bna_counter_id = value;
                parsed_bna_counter_idChanged = true;
            }
        }
        private string parsed_bna_counter_idDbString
        {
            get
            {
                return parsed_bna_counter_id.ToString();
            }
        }
        #endregion
        #region Cassette1Counter1
        private bool cassette1_counter_1Changed = false;
        private int? cassette1_counter_1;
        public int? Cassette1Counter1
        {
            get { return cassette1_counter_1; }
            set
            {
                cassette1_counter_1 = value;
                cassette1_counter_1Changed = true;
            }
        }
        private string cassette1_counter_1DbString
        {
            get
            {
                if (this.cassette1_counter_1.HasValue)
                    return cassette1_counter_1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter2
        private bool cassette1_counter_2Changed = false;
        private int? cassette1_counter_2;
        public int? Cassette1Counter2
        {
            get { return cassette1_counter_2; }
            set
            {
                cassette1_counter_2 = value;
                cassette1_counter_2Changed = true;
            }
        }
        private string cassette1_counter_2DbString
        {
            get
            {
                if (this.cassette1_counter_2.HasValue)
                    return cassette1_counter_2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter3
        private bool cassette1_counter_3Changed = false;
        private int? cassette1_counter_3;
        public int? Cassette1Counter3
        {
            get { return cassette1_counter_3; }
            set
            {
                cassette1_counter_3 = value;
                cassette1_counter_3Changed = true;
            }
        }
        private string cassette1_counter_3DbString
        {
            get
            {
                if (this.cassette1_counter_3.HasValue)
                    return cassette1_counter_3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter4
        private bool cassette1_counter_4Changed = false;
        private int? cassette1_counter_4;
        public int? Cassette1Counter4
        {
            get { return cassette1_counter_4; }
            set
            {
                cassette1_counter_4 = value;
                cassette1_counter_4Changed = true;
            }
        }
        private string cassette1_counter_4DbString
        {
            get
            {
                if (this.cassette1_counter_4.HasValue)
                    return cassette1_counter_4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter5
        private bool cassette1_counter_5Changed = false;
        private int? cassette1_counter_5;
        public int? Cassette1Counter5
        {
            get { return cassette1_counter_5; }
            set
            {
                cassette1_counter_5 = value;
                cassette1_counter_5Changed = true;
            }
        }
        private string cassette1_counter_5DbString
        {
            get
            {
                if (this.cassette1_counter_5.HasValue)
                    return cassette1_counter_5.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter6
        private bool cassette1_counter_6Changed = false;
        private int? cassette1_counter_6;
        public int? Cassette1Counter6
        {
            get { return cassette1_counter_6; }
            set
            {
                cassette1_counter_6 = value;
                cassette1_counter_6Changed = true;
            }
        }
        private string cassette1_counter_6DbString
        {
            get
            {
                if (this.cassette1_counter_6.HasValue)
                    return cassette1_counter_6.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter7
        private bool cassette1_counter_7Changed = false;
        private int? cassette1_counter_7;
        public int? Cassette1Counter7
        {
            get { return cassette1_counter_7; }
            set
            {
                cassette1_counter_7 = value;
                cassette1_counter_7Changed = true;
            }
        }
        private string cassette1_counter_7DbString
        {
            get
            {
                if (this.cassette1_counter_7.HasValue)
                    return cassette1_counter_7.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter8
        private bool cassette1_counter_8Changed = false;
        private int? cassette1_counter_8;
        public int? Cassette1Counter8
        {
            get { return cassette1_counter_8; }
            set
            {
                cassette1_counter_8 = value;
                cassette1_counter_8Changed = true;
            }
        }
        private string cassette1_counter_8DbString
        {
            get
            {
                if (this.cassette1_counter_8.HasValue)
                    return cassette1_counter_8.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter9
        private bool cassette1_counter_9Changed = false;
        private int? cassette1_counter_9;
        public int? Cassette1Counter9
        {
            get { return cassette1_counter_9; }
            set
            {
                cassette1_counter_9 = value;
                cassette1_counter_9Changed = true;
            }
        }
        private string cassette1_counter_9DbString
        {
            get
            {
                if (this.cassette1_counter_9.HasValue)
                    return cassette1_counter_9.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter10
        private bool cassette1_counter_10Changed = false;
        private int? cassette1_counter_10;
        public int? Cassette1Counter10
        {
            get { return cassette1_counter_10; }
            set
            {
                cassette1_counter_10 = value;
                cassette1_counter_10Changed = true;
            }
        }
        private string cassette1_counter_10DbString
        {
            get
            {
                if (this.cassette1_counter_10.HasValue)
                    return cassette1_counter_10.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter11
        private bool cassette1_counter_11Changed = false;
        private int? cassette1_counter_11;
        public int? Cassette1Counter11
        {
            get { return cassette1_counter_11; }
            set
            {
                cassette1_counter_11 = value;
                cassette1_counter_11Changed = true;
            }
        }
        private string cassette1_counter_11DbString
        {
            get
            {
                if (this.cassette1_counter_11.HasValue)
                    return cassette1_counter_11.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter12
        private bool cassette1_counter_12Changed = false;
        private int? cassette1_counter_12;
        public int? Cassette1Counter12
        {
            get { return cassette1_counter_12; }
            set
            {
                cassette1_counter_12 = value;
                cassette1_counter_12Changed = true;
            }
        }
        private string cassette1_counter_12DbString
        {
            get
            {
                if (this.cassette1_counter_12.HasValue)
                    return cassette1_counter_12.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter13
        private bool cassette1_counter_13Changed = false;
        private int? cassette1_counter_13;
        public int? Cassette1Counter13
        {
            get { return cassette1_counter_13; }
            set
            {
                cassette1_counter_13 = value;
                cassette1_counter_13Changed = true;
            }
        }
        private string cassette1_counter_13DbString
        {
            get
            {
                if (this.cassette1_counter_13.HasValue)
                    return cassette1_counter_13.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter14
        private bool cassette1_counter_14Changed = false;
        private int? cassette1_counter_14;
        public int? Cassette1Counter14
        {
            get { return cassette1_counter_14; }
            set
            {
                cassette1_counter_14 = value;
                cassette1_counter_14Changed = true;
            }
        }
        private string cassette1_counter_14DbString
        {
            get
            {
                if (this.cassette1_counter_14.HasValue)
                    return cassette1_counter_14.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter15
        private bool cassette1_counter_15Changed = false;
        private int? cassette1_counter_15;
        public int? Cassette1Counter15
        {
            get { return cassette1_counter_15; }
            set
            {
                cassette1_counter_15 = value;
                cassette1_counter_15Changed = true;
            }
        }
        private string cassette1_counter_15DbString
        {
            get
            {
                if (this.cassette1_counter_15.HasValue)
                    return cassette1_counter_15.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter16
        private bool cassette1_counter_16Changed = false;
        private int? cassette1_counter_16;
        public int? Cassette1Counter16
        {
            get { return cassette1_counter_16; }
            set
            {
                cassette1_counter_16 = value;
                cassette1_counter_16Changed = true;
            }
        }
        private string cassette1_counter_16DbString
        {
            get
            {
                if (this.cassette1_counter_16.HasValue)
                    return cassette1_counter_16.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter17
        private bool cassette1_counter_17Changed = false;
        private int? cassette1_counter_17;
        public int? Cassette1Counter17
        {
            get { return cassette1_counter_17; }
            set
            {
                cassette1_counter_17 = value;
                cassette1_counter_17Changed = true;
            }
        }
        private string cassette1_counter_17DbString
        {
            get
            {
                if (this.cassette1_counter_17.HasValue)
                    return cassette1_counter_17.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter18
        private bool cassette1_counter_18Changed = false;
        private int? cassette1_counter_18;
        public int? Cassette1Counter18
        {
            get { return cassette1_counter_18; }
            set
            {
                cassette1_counter_18 = value;
                cassette1_counter_18Changed = true;
            }
        }
        private string cassette1_counter_18DbString
        {
            get
            {
                if (this.cassette1_counter_18.HasValue)
                    return cassette1_counter_18.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter19
        private bool cassette1_counter_19Changed = false;
        private int? cassette1_counter_19;
        public int? Cassette1Counter19
        {
            get { return cassette1_counter_19; }
            set
            {
                cassette1_counter_19 = value;
                cassette1_counter_19Changed = true;
            }
        }
        private string cassette1_counter_19DbString
        {
            get
            {
                if (this.cassette1_counter_19.HasValue)
                    return cassette1_counter_19.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter20
        private bool cassette1_counter_20Changed = false;
        private int? cassette1_counter_20;
        public int? Cassette1Counter20
        {
            get { return cassette1_counter_20; }
            set
            {
                cassette1_counter_20 = value;
                cassette1_counter_20Changed = true;
            }
        }
        private string cassette1_counter_20DbString
        {
            get
            {
                if (this.cassette1_counter_20.HasValue)
                    return cassette1_counter_20.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter21
        private bool cassette1_counter_21Changed = false;
        private int? cassette1_counter_21;
        public int? Cassette1Counter21
        {
            get { return cassette1_counter_21; }
            set
            {
                cassette1_counter_21 = value;
                cassette1_counter_21Changed = true;
            }
        }
        private string cassette1_counter_21DbString
        {
            get
            {
                if (this.cassette1_counter_21.HasValue)
                    return cassette1_counter_21.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter22
        private bool cassette1_counter_22Changed = false;
        private int? cassette1_counter_22;
        public int? Cassette1Counter22
        {
            get { return cassette1_counter_22; }
            set
            {
                cassette1_counter_22 = value;
                cassette1_counter_22Changed = true;
            }
        }
        private string cassette1_counter_22DbString
        {
            get
            {
                if (this.cassette1_counter_22.HasValue)
                    return cassette1_counter_22.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter23
        private bool cassette1_counter_23Changed = false;
        private int? cassette1_counter_23;
        public int? Cassette1Counter23
        {
            get { return cassette1_counter_23; }
            set
            {
                cassette1_counter_23 = value;
                cassette1_counter_23Changed = true;
            }
        }
        private string cassette1_counter_23DbString
        {
            get
            {
                if (this.cassette1_counter_23.HasValue)
                    return cassette1_counter_23.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter24
        private bool cassette1_counter_24Changed = false;
        private int? cassette1_counter_24;
        public int? Cassette1Counter24
        {
            get { return cassette1_counter_24; }
            set
            {
                cassette1_counter_24 = value;
                cassette1_counter_24Changed = true;
            }
        }
        private string cassette1_counter_24DbString
        {
            get
            {
                if (this.cassette1_counter_24.HasValue)
                    return cassette1_counter_24.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter25
        private bool cassette1_counter_25Changed = false;
        private int? cassette1_counter_25;
        public int? Cassette1Counter25
        {
            get { return cassette1_counter_25; }
            set
            {
                cassette1_counter_25 = value;
                cassette1_counter_25Changed = true;
            }
        }
        private string cassette1_counter_25DbString
        {
            get
            {
                if (this.cassette1_counter_25.HasValue)
                    return cassette1_counter_25.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter26
        private bool cassette1_counter_26Changed = false;
        private int? cassette1_counter_26;
        public int? Cassette1Counter26
        {
            get { return cassette1_counter_26; }
            set
            {
                cassette1_counter_26 = value;
                cassette1_counter_26Changed = true;
            }
        }
        private string cassette1_counter_26DbString
        {
            get
            {
                if (this.cassette1_counter_26.HasValue)
                    return cassette1_counter_26.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter27
        private bool cassette1_counter_27Changed = false;
        private int? cassette1_counter_27;
        public int? Cassette1Counter27
        {
            get { return cassette1_counter_27; }
            set
            {
                cassette1_counter_27 = value;
                cassette1_counter_27Changed = true;
            }
        }
        private string cassette1_counter_27DbString
        {
            get
            {
                if (this.cassette1_counter_27.HasValue)
                    return cassette1_counter_27.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter28
        private bool cassette1_counter_28Changed = false;
        private int? cassette1_counter_28;
        public int? Cassette1Counter28
        {
            get { return cassette1_counter_28; }
            set
            {
                cassette1_counter_28 = value;
                cassette1_counter_28Changed = true;
            }
        }
        private string cassette1_counter_28DbString
        {
            get
            {
                if (this.cassette1_counter_28.HasValue)
                    return cassette1_counter_28.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter29
        private bool cassette1_counter_29Changed = false;
        private int? cassette1_counter_29;
        public int? Cassette1Counter29
        {
            get { return cassette1_counter_29; }
            set
            {
                cassette1_counter_29 = value;
                cassette1_counter_29Changed = true;
            }
        }
        private string cassette1_counter_29DbString
        {
            get
            {
                if (this.cassette1_counter_29.HasValue)
                    return cassette1_counter_29.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter30
        private bool cassette1_counter_30Changed = false;
        private int? cassette1_counter_30;
        public int? Cassette1Counter30
        {
            get { return cassette1_counter_30; }
            set
            {
                cassette1_counter_30 = value;
                cassette1_counter_30Changed = true;
            }
        }
        private string cassette1_counter_30DbString
        {
            get
            {
                if (this.cassette1_counter_30.HasValue)
                    return cassette1_counter_30.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter31
        private bool cassette1_counter_31Changed = false;
        private int? cassette1_counter_31;
        public int? Cassette1Counter31
        {
            get { return cassette1_counter_31; }
            set
            {
                cassette1_counter_31 = value;
                cassette1_counter_31Changed = true;
            }
        }
        private string cassette1_counter_31DbString
        {
            get
            {
                if (this.cassette1_counter_31.HasValue)
                    return cassette1_counter_31.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter32
        private bool cassette1_counter_32Changed = false;
        private int? cassette1_counter_32;
        public int? Cassette1Counter32
        {
            get { return cassette1_counter_32; }
            set
            {
                cassette1_counter_32 = value;
                cassette1_counter_32Changed = true;
            }
        }
        private string cassette1_counter_32DbString
        {
            get
            {
                if (this.cassette1_counter_32.HasValue)
                    return cassette1_counter_32.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter33
        private bool cassette1_counter_33Changed = false;
        private int? cassette1_counter_33;
        public int? Cassette1Counter33
        {
            get { return cassette1_counter_33; }
            set
            {
                cassette1_counter_33 = value;
                cassette1_counter_33Changed = true;
            }
        }
        private string cassette1_counter_33DbString
        {
            get
            {
                if (this.cassette1_counter_33.HasValue)
                    return cassette1_counter_33.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter34
        private bool cassette1_counter_34Changed = false;
        private int? cassette1_counter_34;
        public int? Cassette1Counter34
        {
            get { return cassette1_counter_34; }
            set
            {
                cassette1_counter_34 = value;
                cassette1_counter_34Changed = true;
            }
        }
        private string cassette1_counter_34DbString
        {
            get
            {
                if (this.cassette1_counter_34.HasValue)
                    return cassette1_counter_34.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter35
        private bool cassette1_counter_35Changed = false;
        private int? cassette1_counter_35;
        public int? Cassette1Counter35
        {
            get { return cassette1_counter_35; }
            set
            {
                cassette1_counter_35 = value;
                cassette1_counter_35Changed = true;
            }
        }
        private string cassette1_counter_35DbString
        {
            get
            {
                if (this.cassette1_counter_35.HasValue)
                    return cassette1_counter_35.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter36
        private bool cassette1_counter_36Changed = false;
        private int? cassette1_counter_36;
        public int? Cassette1Counter36
        {
            get { return cassette1_counter_36; }
            set
            {
                cassette1_counter_36 = value;
                cassette1_counter_36Changed = true;
            }
        }
        private string cassette1_counter_36DbString
        {
            get
            {
                if (this.cassette1_counter_36.HasValue)
                    return cassette1_counter_36.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter37
        private bool cassette1_counter_37Changed = false;
        private int? cassette1_counter_37;
        public int? Cassette1Counter37
        {
            get { return cassette1_counter_37; }
            set
            {
                cassette1_counter_37 = value;
                cassette1_counter_37Changed = true;
            }
        }
        private string cassette1_counter_37DbString
        {
            get
            {
                if (this.cassette1_counter_37.HasValue)
                    return cassette1_counter_37.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter38
        private bool cassette1_counter_38Changed = false;
        private int? cassette1_counter_38;
        public int? Cassette1Counter38
        {
            get { return cassette1_counter_38; }
            set
            {
                cassette1_counter_38 = value;
                cassette1_counter_38Changed = true;
            }
        }
        private string cassette1_counter_38DbString
        {
            get
            {
                if (this.cassette1_counter_38.HasValue)
                    return cassette1_counter_38.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter39
        private bool cassette1_counter_39Changed = false;
        private int? cassette1_counter_39;
        public int? Cassette1Counter39
        {
            get { return cassette1_counter_39; }
            set
            {
                cassette1_counter_39 = value;
                cassette1_counter_39Changed = true;
            }
        }
        private string cassette1_counter_39DbString
        {
            get
            {
                if (this.cassette1_counter_39.HasValue)
                    return cassette1_counter_39.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter40
        private bool cassette1_counter_40Changed = false;
        private int? cassette1_counter_40;
        public int? Cassette1Counter40
        {
            get { return cassette1_counter_40; }
            set
            {
                cassette1_counter_40 = value;
                cassette1_counter_40Changed = true;
            }
        }
        private string cassette1_counter_40DbString
        {
            get
            {
                if (this.cassette1_counter_40.HasValue)
                    return cassette1_counter_40.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter41
        private bool cassette1_counter_41Changed = false;
        private int? cassette1_counter_41;
        public int? Cassette1Counter41
        {
            get { return cassette1_counter_41; }
            set
            {
                cassette1_counter_41 = value;
                cassette1_counter_41Changed = true;
            }
        }
        private string cassette1_counter_41DbString
        {
            get
            {
                if (this.cassette1_counter_41.HasValue)
                    return cassette1_counter_41.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter42
        private bool cassette1_counter_42Changed = false;
        private int? cassette1_counter_42;
        public int? Cassette1Counter42
        {
            get { return cassette1_counter_42; }
            set
            {
                cassette1_counter_42 = value;
                cassette1_counter_42Changed = true;
            }
        }
        private string cassette1_counter_42DbString
        {
            get
            {
                if (this.cassette1_counter_42.HasValue)
                    return cassette1_counter_42.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter43
        private bool cassette1_counter_43Changed = false;
        private int? cassette1_counter_43;
        public int? Cassette1Counter43
        {
            get { return cassette1_counter_43; }
            set
            {
                cassette1_counter_43 = value;
                cassette1_counter_43Changed = true;
            }
        }
        private string cassette1_counter_43DbString
        {
            get
            {
                if (this.cassette1_counter_43.HasValue)
                    return cassette1_counter_43.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter44
        private bool cassette1_counter_44Changed = false;
        private int? cassette1_counter_44;
        public int? Cassette1Counter44
        {
            get { return cassette1_counter_44; }
            set
            {
                cassette1_counter_44 = value;
                cassette1_counter_44Changed = true;
            }
        }
        private string cassette1_counter_44DbString
        {
            get
            {
                if (this.cassette1_counter_44.HasValue)
                    return cassette1_counter_44.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter45
        private bool cassette1_counter_45Changed = false;
        private int? cassette1_counter_45;
        public int? Cassette1Counter45
        {
            get { return cassette1_counter_45; }
            set
            {
                cassette1_counter_45 = value;
                cassette1_counter_45Changed = true;
            }
        }
        private string cassette1_counter_45DbString
        {
            get
            {
                if (this.cassette1_counter_45.HasValue)
                    return cassette1_counter_45.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter46
        private bool cassette1_counter_46Changed = false;
        private int? cassette1_counter_46;
        public int? Cassette1Counter46
        {
            get { return cassette1_counter_46; }
            set
            {
                cassette1_counter_46 = value;
                cassette1_counter_46Changed = true;
            }
        }
        private string cassette1_counter_46DbString
        {
            get
            {
                if (this.cassette1_counter_46.HasValue)
                    return cassette1_counter_46.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter47
        private bool cassette1_counter_47Changed = false;
        private int? cassette1_counter_47;
        public int? Cassette1Counter47
        {
            get { return cassette1_counter_47; }
            set
            {
                cassette1_counter_47 = value;
                cassette1_counter_47Changed = true;
            }
        }
        private string cassette1_counter_47DbString
        {
            get
            {
                if (this.cassette1_counter_47.HasValue)
                    return cassette1_counter_47.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter48
        private bool cassette1_counter_48Changed = false;
        private int? cassette1_counter_48;
        public int? Cassette1Counter48
        {
            get { return cassette1_counter_48; }
            set
            {
                cassette1_counter_48 = value;
                cassette1_counter_48Changed = true;
            }
        }
        private string cassette1_counter_48DbString
        {
            get
            {
                if (this.cassette1_counter_48.HasValue)
                    return cassette1_counter_48.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter49
        private bool cassette1_counter_49Changed = false;
        private int? cassette1_counter_49;
        public int? Cassette1Counter49
        {
            get { return cassette1_counter_49; }
            set
            {
                cassette1_counter_49 = value;
                cassette1_counter_49Changed = true;
            }
        }
        private string cassette1_counter_49DbString
        {
            get
            {
                if (this.cassette1_counter_49.HasValue)
                    return cassette1_counter_49.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette1Counter50
        private bool cassette1_counter_50Changed = false;
        private int? cassette1_counter_50;
        public int? Cassette1Counter50
        {
            get { return cassette1_counter_50; }
            set
            {
                cassette1_counter_50 = value;
                cassette1_counter_50Changed = true;
            }
        }
        private string cassette1_counter_50DbString
        {
            get
            {
                if (this.cassette1_counter_50.HasValue)
                    return cassette1_counter_50.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter1
        private bool cassette2_counter_1Changed = false;
        private int? cassette2_counter_1;
        public int? Cassette2Counter1
        {
            get { return cassette2_counter_1; }
            set
            {
                cassette2_counter_1 = value;
                cassette2_counter_1Changed = true;
            }
        }
        private string cassette2_counter_1DbString
        {
            get
            {
                if (this.cassette2_counter_1.HasValue)
                    return cassette2_counter_1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter2
        private bool cassette2_counter_2Changed = false;
        private int? cassette2_counter_2;
        public int? Cassette2Counter2
        {
            get { return cassette2_counter_2; }
            set
            {
                cassette2_counter_2 = value;
                cassette2_counter_2Changed = true;
            }
        }
        private string cassette2_counter_2DbString
        {
            get
            {
                if (this.cassette2_counter_2.HasValue)
                    return cassette2_counter_2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter3
        private bool cassette2_counter_3Changed = false;
        private int? cassette2_counter_3;
        public int? Cassette2Counter3
        {
            get { return cassette2_counter_3; }
            set
            {
                cassette2_counter_3 = value;
                cassette2_counter_3Changed = true;
            }
        }
        private string cassette2_counter_3DbString
        {
            get
            {
                if (this.cassette2_counter_3.HasValue)
                    return cassette2_counter_3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter4
        private bool cassette2_counter_4Changed = false;
        private int? cassette2_counter_4;
        public int? Cassette2Counter4
        {
            get { return cassette2_counter_4; }
            set
            {
                cassette2_counter_4 = value;
                cassette2_counter_4Changed = true;
            }
        }
        private string cassette2_counter_4DbString
        {
            get
            {
                if (this.cassette2_counter_4.HasValue)
                    return cassette2_counter_4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter5
        private bool cassette2_counter_5Changed = false;
        private int? cassette2_counter_5;
        public int? Cassette2Counter5
        {
            get { return cassette2_counter_5; }
            set
            {
                cassette2_counter_5 = value;
                cassette2_counter_5Changed = true;
            }
        }
        private string cassette2_counter_5DbString
        {
            get
            {
                if (this.cassette2_counter_5.HasValue)
                    return cassette2_counter_5.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter6
        private bool cassette2_counter_6Changed = false;
        private int? cassette2_counter_6;
        public int? Cassette2Counter6
        {
            get { return cassette2_counter_6; }
            set
            {
                cassette2_counter_6 = value;
                cassette2_counter_6Changed = true;
            }
        }
        private string cassette2_counter_6DbString
        {
            get
            {
                if (this.cassette2_counter_6.HasValue)
                    return cassette2_counter_6.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter7
        private bool cassette2_counter_7Changed = false;
        private int? cassette2_counter_7;
        public int? Cassette2Counter7
        {
            get { return cassette2_counter_7; }
            set
            {
                cassette2_counter_7 = value;
                cassette2_counter_7Changed = true;
            }
        }
        private string cassette2_counter_7DbString
        {
            get
            {
                if (this.cassette2_counter_7.HasValue)
                    return cassette2_counter_7.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter8
        private bool cassette2_counter_8Changed = false;
        private int? cassette2_counter_8;
        public int? Cassette2Counter8
        {
            get { return cassette2_counter_8; }
            set
            {
                cassette2_counter_8 = value;
                cassette2_counter_8Changed = true;
            }
        }
        private string cassette2_counter_8DbString
        {
            get
            {
                if (this.cassette2_counter_8.HasValue)
                    return cassette2_counter_8.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter9
        private bool cassette2_counter_9Changed = false;
        private int? cassette2_counter_9;
        public int? Cassette2Counter9
        {
            get { return cassette2_counter_9; }
            set
            {
                cassette2_counter_9 = value;
                cassette2_counter_9Changed = true;
            }
        }
        private string cassette2_counter_9DbString
        {
            get
            {
                if (this.cassette2_counter_9.HasValue)
                    return cassette2_counter_9.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter10
        private bool cassette2_counter_10Changed = false;
        private int? cassette2_counter_10;
        public int? Cassette2Counter10
        {
            get { return cassette2_counter_10; }
            set
            {
                cassette2_counter_10 = value;
                cassette2_counter_10Changed = true;
            }
        }
        private string cassette2_counter_10DbString
        {
            get
            {
                if (this.cassette2_counter_10.HasValue)
                    return cassette2_counter_10.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter11
        private bool cassette2_counter_11Changed = false;
        private int? cassette2_counter_11;
        public int? Cassette2Counter11
        {
            get { return cassette2_counter_11; }
            set
            {
                cassette2_counter_11 = value;
                cassette2_counter_11Changed = true;
            }
        }
        private string cassette2_counter_11DbString
        {
            get
            {
                if (this.cassette2_counter_11.HasValue)
                    return cassette2_counter_11.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter12
        private bool cassette2_counter_12Changed = false;
        private int? cassette2_counter_12;
        public int? Cassette2Counter12
        {
            get { return cassette2_counter_12; }
            set
            {
                cassette2_counter_12 = value;
                cassette2_counter_12Changed = true;
            }
        }
        private string cassette2_counter_12DbString
        {
            get
            {
                if (this.cassette2_counter_12.HasValue)
                    return cassette2_counter_12.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter13
        private bool cassette2_counter_13Changed = false;
        private int? cassette2_counter_13;
        public int? Cassette2Counter13
        {
            get { return cassette2_counter_13; }
            set
            {
                cassette2_counter_13 = value;
                cassette2_counter_13Changed = true;
            }
        }
        private string cassette2_counter_13DbString
        {
            get
            {
                if (this.cassette2_counter_13.HasValue)
                    return cassette2_counter_13.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter14
        private bool cassette2_counter_14Changed = false;
        private int? cassette2_counter_14;
        public int? Cassette2Counter14
        {
            get { return cassette2_counter_14; }
            set
            {
                cassette2_counter_14 = value;
                cassette2_counter_14Changed = true;
            }
        }
        private string cassette2_counter_14DbString
        {
            get
            {
                if (this.cassette2_counter_14.HasValue)
                    return cassette2_counter_14.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter15
        private bool cassette2_counter_15Changed = false;
        private int? cassette2_counter_15;
        public int? Cassette2Counter15
        {
            get { return cassette2_counter_15; }
            set
            {
                cassette2_counter_15 = value;
                cassette2_counter_15Changed = true;
            }
        }
        private string cassette2_counter_15DbString
        {
            get
            {
                if (this.cassette2_counter_15.HasValue)
                    return cassette2_counter_15.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter16
        private bool cassette2_counter_16Changed = false;
        private int? cassette2_counter_16;
        public int? Cassette2Counter16
        {
            get { return cassette2_counter_16; }
            set
            {
                cassette2_counter_16 = value;
                cassette2_counter_16Changed = true;
            }
        }
        private string cassette2_counter_16DbString
        {
            get
            {
                if (this.cassette2_counter_16.HasValue)
                    return cassette2_counter_16.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter17
        private bool cassette2_counter_17Changed = false;
        private int? cassette2_counter_17;
        public int? Cassette2Counter17
        {
            get { return cassette2_counter_17; }
            set
            {
                cassette2_counter_17 = value;
                cassette2_counter_17Changed = true;
            }
        }
        private string cassette2_counter_17DbString
        {
            get
            {
                if (this.cassette2_counter_17.HasValue)
                    return cassette2_counter_17.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter18
        private bool cassette2_counter_18Changed = false;
        private int? cassette2_counter_18;
        public int? Cassette2Counter18
        {
            get { return cassette2_counter_18; }
            set
            {
                cassette2_counter_18 = value;
                cassette2_counter_18Changed = true;
            }
        }
        private string cassette2_counter_18DbString
        {
            get
            {
                if (this.cassette2_counter_18.HasValue)
                    return cassette2_counter_18.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter19
        private bool cassette2_counter_19Changed = false;
        private int? cassette2_counter_19;
        public int? Cassette2Counter19
        {
            get { return cassette2_counter_19; }
            set
            {
                cassette2_counter_19 = value;
                cassette2_counter_19Changed = true;
            }
        }
        private string cassette2_counter_19DbString
        {
            get
            {
                if (this.cassette2_counter_19.HasValue)
                    return cassette2_counter_19.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter20
        private bool cassette2_counter_20Changed = false;
        private int? cassette2_counter_20;
        public int? Cassette2Counter20
        {
            get { return cassette2_counter_20; }
            set
            {
                cassette2_counter_20 = value;
                cassette2_counter_20Changed = true;
            }
        }
        private string cassette2_counter_20DbString
        {
            get
            {
                if (this.cassette2_counter_20.HasValue)
                    return cassette2_counter_20.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter21
        private bool cassette2_counter_21Changed = false;
        private int? cassette2_counter_21;
        public int? Cassette2Counter21
        {
            get { return cassette2_counter_21; }
            set
            {
                cassette2_counter_21 = value;
                cassette2_counter_21Changed = true;
            }
        }
        private string cassette2_counter_21DbString
        {
            get
            {
                if (this.cassette2_counter_21.HasValue)
                    return cassette2_counter_21.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter22
        private bool cassette2_counter_22Changed = false;
        private int? cassette2_counter_22;
        public int? Cassette2Counter22
        {
            get { return cassette2_counter_22; }
            set
            {
                cassette2_counter_22 = value;
                cassette2_counter_22Changed = true;
            }
        }
        private string cassette2_counter_22DbString
        {
            get
            {
                if (this.cassette2_counter_22.HasValue)
                    return cassette2_counter_22.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter23
        private bool cassette2_counter_23Changed = false;
        private int? cassette2_counter_23;
        public int? Cassette2Counter23
        {
            get { return cassette2_counter_23; }
            set
            {
                cassette2_counter_23 = value;
                cassette2_counter_23Changed = true;
            }
        }
        private string cassette2_counter_23DbString
        {
            get
            {
                if (this.cassette2_counter_23.HasValue)
                    return cassette2_counter_23.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter24
        private bool cassette2_counter_24Changed = false;
        private int? cassette2_counter_24;
        public int? Cassette2Counter24
        {
            get { return cassette2_counter_24; }
            set
            {
                cassette2_counter_24 = value;
                cassette2_counter_24Changed = true;
            }
        }
        private string cassette2_counter_24DbString
        {
            get
            {
                if (this.cassette2_counter_24.HasValue)
                    return cassette2_counter_24.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter25
        private bool cassette2_counter_25Changed = false;
        private int? cassette2_counter_25;
        public int? Cassette2Counter25
        {
            get { return cassette2_counter_25; }
            set
            {
                cassette2_counter_25 = value;
                cassette2_counter_25Changed = true;
            }
        }
        private string cassette2_counter_25DbString
        {
            get
            {
                if (this.cassette2_counter_25.HasValue)
                    return cassette2_counter_25.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter26
        private bool cassette2_counter_26Changed = false;
        private int? cassette2_counter_26;
        public int? Cassette2Counter26
        {
            get { return cassette2_counter_26; }
            set
            {
                cassette2_counter_26 = value;
                cassette2_counter_26Changed = true;
            }
        }
        private string cassette2_counter_26DbString
        {
            get
            {
                if (this.cassette2_counter_26.HasValue)
                    return cassette2_counter_26.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter27
        private bool cassette2_counter_27Changed = false;
        private int? cassette2_counter_27;
        public int? Cassette2Counter27
        {
            get { return cassette2_counter_27; }
            set
            {
                cassette2_counter_27 = value;
                cassette2_counter_27Changed = true;
            }
        }
        private string cassette2_counter_27DbString
        {
            get
            {
                if (this.cassette2_counter_27.HasValue)
                    return cassette2_counter_27.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter28
        private bool cassette2_counter_28Changed = false;
        private int? cassette2_counter_28;
        public int? Cassette2Counter28
        {
            get { return cassette2_counter_28; }
            set
            {
                cassette2_counter_28 = value;
                cassette2_counter_28Changed = true;
            }
        }
        private string cassette2_counter_28DbString
        {
            get
            {
                if (this.cassette2_counter_28.HasValue)
                    return cassette2_counter_28.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter29
        private bool cassette2_counter_29Changed = false;
        private int? cassette2_counter_29;
        public int? Cassette2Counter29
        {
            get { return cassette2_counter_29; }
            set
            {
                cassette2_counter_29 = value;
                cassette2_counter_29Changed = true;
            }
        }
        private string cassette2_counter_29DbString
        {
            get
            {
                if (this.cassette2_counter_29.HasValue)
                    return cassette2_counter_29.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter30
        private bool cassette2_counter_30Changed = false;
        private int? cassette2_counter_30;
        public int? Cassette2Counter30
        {
            get { return cassette2_counter_30; }
            set
            {
                cassette2_counter_30 = value;
                cassette2_counter_30Changed = true;
            }
        }
        private string cassette2_counter_30DbString
        {
            get
            {
                if (this.cassette2_counter_30.HasValue)
                    return cassette2_counter_30.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter31
        private bool cassette2_counter_31Changed = false;
        private int? cassette2_counter_31;
        public int? Cassette2Counter31
        {
            get { return cassette2_counter_31; }
            set
            {
                cassette2_counter_31 = value;
                cassette2_counter_31Changed = true;
            }
        }
        private string cassette2_counter_31DbString
        {
            get
            {
                if (this.cassette2_counter_31.HasValue)
                    return cassette2_counter_31.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter32
        private bool cassette2_counter_32Changed = false;
        private int? cassette2_counter_32;
        public int? Cassette2Counter32
        {
            get { return cassette2_counter_32; }
            set
            {
                cassette2_counter_32 = value;
                cassette2_counter_32Changed = true;
            }
        }
        private string cassette2_counter_32DbString
        {
            get
            {
                if (this.cassette2_counter_32.HasValue)
                    return cassette2_counter_32.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter33
        private bool cassette2_counter_33Changed = false;
        private int? cassette2_counter_33;
        public int? Cassette2Counter33
        {
            get { return cassette2_counter_33; }
            set
            {
                cassette2_counter_33 = value;
                cassette2_counter_33Changed = true;
            }
        }
        private string cassette2_counter_33DbString
        {
            get
            {
                if (this.cassette2_counter_33.HasValue)
                    return cassette2_counter_33.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter34
        private bool cassette2_counter_34Changed = false;
        private int? cassette2_counter_34;
        public int? Cassette2Counter34
        {
            get { return cassette2_counter_34; }
            set
            {
                cassette2_counter_34 = value;
                cassette2_counter_34Changed = true;
            }
        }
        private string cassette2_counter_34DbString
        {
            get
            {
                if (this.cassette2_counter_34.HasValue)
                    return cassette2_counter_34.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter35
        private bool cassette2_counter_35Changed = false;
        private int? cassette2_counter_35;
        public int? Cassette2Counter35
        {
            get { return cassette2_counter_35; }
            set
            {
                cassette2_counter_35 = value;
                cassette2_counter_35Changed = true;
            }
        }
        private string cassette2_counter_35DbString
        {
            get
            {
                if (this.cassette2_counter_35.HasValue)
                    return cassette2_counter_35.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter36
        private bool cassette2_counter_36Changed = false;
        private int? cassette2_counter_36;
        public int? Cassette2Counter36
        {
            get { return cassette2_counter_36; }
            set
            {
                cassette2_counter_36 = value;
                cassette2_counter_36Changed = true;
            }
        }
        private string cassette2_counter_36DbString
        {
            get
            {
                if (this.cassette2_counter_36.HasValue)
                    return cassette2_counter_36.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter37
        private bool cassette2_counter_37Changed = false;
        private int? cassette2_counter_37;
        public int? Cassette2Counter37
        {
            get { return cassette2_counter_37; }
            set
            {
                cassette2_counter_37 = value;
                cassette2_counter_37Changed = true;
            }
        }
        private string cassette2_counter_37DbString
        {
            get
            {
                if (this.cassette2_counter_37.HasValue)
                    return cassette2_counter_37.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter38
        private bool cassette2_counter_38Changed = false;
        private int? cassette2_counter_38;
        public int? Cassette2Counter38
        {
            get { return cassette2_counter_38; }
            set
            {
                cassette2_counter_38 = value;
                cassette2_counter_38Changed = true;
            }
        }
        private string cassette2_counter_38DbString
        {
            get
            {
                if (this.cassette2_counter_38.HasValue)
                    return cassette2_counter_38.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter39
        private bool cassette2_counter_39Changed = false;
        private int? cassette2_counter_39;
        public int? Cassette2Counter39
        {
            get { return cassette2_counter_39; }
            set
            {
                cassette2_counter_39 = value;
                cassette2_counter_39Changed = true;
            }
        }
        private string cassette2_counter_39DbString
        {
            get
            {
                if (this.cassette2_counter_39.HasValue)
                    return cassette2_counter_39.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter40
        private bool cassette2_counter_40Changed = false;
        private int? cassette2_counter_40;
        public int? Cassette2Counter40
        {
            get { return cassette2_counter_40; }
            set
            {
                cassette2_counter_40 = value;
                cassette2_counter_40Changed = true;
            }
        }
        private string cassette2_counter_40DbString
        {
            get
            {
                if (this.cassette2_counter_40.HasValue)
                    return cassette2_counter_40.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter41
        private bool cassette2_counter_41Changed = false;
        private int? cassette2_counter_41;
        public int? Cassette2Counter41
        {
            get { return cassette2_counter_41; }
            set
            {
                cassette2_counter_41 = value;
                cassette2_counter_41Changed = true;
            }
        }
        private string cassette2_counter_41DbString
        {
            get
            {
                if (this.cassette2_counter_41.HasValue)
                    return cassette2_counter_41.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter42
        private bool cassette2_counter_42Changed = false;
        private int? cassette2_counter_42;
        public int? Cassette2Counter42
        {
            get { return cassette2_counter_42; }
            set
            {
                cassette2_counter_42 = value;
                cassette2_counter_42Changed = true;
            }
        }
        private string cassette2_counter_42DbString
        {
            get
            {
                if (this.cassette2_counter_42.HasValue)
                    return cassette2_counter_42.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter43
        private bool cassette2_counter_43Changed = false;
        private int? cassette2_counter_43;
        public int? Cassette2Counter43
        {
            get { return cassette2_counter_43; }
            set
            {
                cassette2_counter_43 = value;
                cassette2_counter_43Changed = true;
            }
        }
        private string cassette2_counter_43DbString
        {
            get
            {
                if (this.cassette2_counter_43.HasValue)
                    return cassette2_counter_43.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter44
        private bool cassette2_counter_44Changed = false;
        private int? cassette2_counter_44;
        public int? Cassette2Counter44
        {
            get { return cassette2_counter_44; }
            set
            {
                cassette2_counter_44 = value;
                cassette2_counter_44Changed = true;
            }
        }
        private string cassette2_counter_44DbString
        {
            get
            {
                if (this.cassette2_counter_44.HasValue)
                    return cassette2_counter_44.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter45
        private bool cassette2_counter_45Changed = false;
        private int? cassette2_counter_45;
        public int? Cassette2Counter45
        {
            get { return cassette2_counter_45; }
            set
            {
                cassette2_counter_45 = value;
                cassette2_counter_45Changed = true;
            }
        }
        private string cassette2_counter_45DbString
        {
            get
            {
                if (this.cassette2_counter_45.HasValue)
                    return cassette2_counter_45.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter46
        private bool cassette2_counter_46Changed = false;
        private int? cassette2_counter_46;
        public int? Cassette2Counter46
        {
            get { return cassette2_counter_46; }
            set
            {
                cassette2_counter_46 = value;
                cassette2_counter_46Changed = true;
            }
        }
        private string cassette2_counter_46DbString
        {
            get
            {
                if (this.cassette2_counter_46.HasValue)
                    return cassette2_counter_46.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter47
        private bool cassette2_counter_47Changed = false;
        private int? cassette2_counter_47;
        public int? Cassette2Counter47
        {
            get { return cassette2_counter_47; }
            set
            {
                cassette2_counter_47 = value;
                cassette2_counter_47Changed = true;
            }
        }
        private string cassette2_counter_47DbString
        {
            get
            {
                if (this.cassette2_counter_47.HasValue)
                    return cassette2_counter_47.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter48
        private bool cassette2_counter_48Changed = false;
        private int? cassette2_counter_48;
        public int? Cassette2Counter48
        {
            get { return cassette2_counter_48; }
            set
            {
                cassette2_counter_48 = value;
                cassette2_counter_48Changed = true;
            }
        }
        private string cassette2_counter_48DbString
        {
            get
            {
                if (this.cassette2_counter_48.HasValue)
                    return cassette2_counter_48.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter49
        private bool cassette2_counter_49Changed = false;
        private int? cassette2_counter_49;
        public int? Cassette2Counter49
        {
            get { return cassette2_counter_49; }
            set
            {
                cassette2_counter_49 = value;
                cassette2_counter_49Changed = true;
            }
        }
        private string cassette2_counter_49DbString
        {
            get
            {
                if (this.cassette2_counter_49.HasValue)
                    return cassette2_counter_49.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2Counter50
        private bool cassette2_counter_50Changed = false;
        private int? cassette2_counter_50;
        public int? Cassette2Counter50
        {
            get { return cassette2_counter_50; }
            set
            {
                cassette2_counter_50 = value;
                cassette2_counter_50Changed = true;
            }
        }
        private string cassette2_counter_50DbString
        {
            get
            {
                if (this.cassette2_counter_50.HasValue)
                    return cassette2_counter_50.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter1
        private bool cassette3_counter_1Changed = false;
        private int? cassette3_counter_1;
        public int? Cassette3Counter1
        {
            get { return cassette3_counter_1; }
            set
            {
                cassette3_counter_1 = value;
                cassette3_counter_1Changed = true;
            }
        }
        private string cassette3_counter_1DbString
        {
            get
            {
                if (this.cassette3_counter_1.HasValue)
                    return cassette3_counter_1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter2
        private bool cassette3_counter_2Changed = false;
        private int? cassette3_counter_2;
        public int? Cassette3Counter2
        {
            get { return cassette3_counter_2; }
            set
            {
                cassette3_counter_2 = value;
                cassette3_counter_2Changed = true;
            }
        }
        private string cassette3_counter_2DbString
        {
            get
            {
                if (this.cassette3_counter_2.HasValue)
                    return cassette3_counter_2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter3
        private bool cassette3_counter_3Changed = false;
        private int? cassette3_counter_3;
        public int? Cassette3Counter3
        {
            get { return cassette3_counter_3; }
            set
            {
                cassette3_counter_3 = value;
                cassette3_counter_3Changed = true;
            }
        }
        private string cassette3_counter_3DbString
        {
            get
            {
                if (this.cassette3_counter_3.HasValue)
                    return cassette3_counter_3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter4
        private bool cassette3_counter_4Changed = false;
        private int? cassette3_counter_4;
        public int? Cassette3Counter4
        {
            get { return cassette3_counter_4; }
            set
            {
                cassette3_counter_4 = value;
                cassette3_counter_4Changed = true;
            }
        }
        private string cassette3_counter_4DbString
        {
            get
            {
                if (this.cassette3_counter_4.HasValue)
                    return cassette3_counter_4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter5
        private bool cassette3_counter_5Changed = false;
        private int? cassette3_counter_5;
        public int? Cassette3Counter5
        {
            get { return cassette3_counter_5; }
            set
            {
                cassette3_counter_5 = value;
                cassette3_counter_5Changed = true;
            }
        }
        private string cassette3_counter_5DbString
        {
            get
            {
                if (this.cassette3_counter_5.HasValue)
                    return cassette3_counter_5.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter6
        private bool cassette3_counter_6Changed = false;
        private int? cassette3_counter_6;
        public int? Cassette3Counter6
        {
            get { return cassette3_counter_6; }
            set
            {
                cassette3_counter_6 = value;
                cassette3_counter_6Changed = true;
            }
        }
        private string cassette3_counter_6DbString
        {
            get
            {
                if (this.cassette3_counter_6.HasValue)
                    return cassette3_counter_6.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter7
        private bool cassette3_counter_7Changed = false;
        private int? cassette3_counter_7;
        public int? Cassette3Counter7
        {
            get { return cassette3_counter_7; }
            set
            {
                cassette3_counter_7 = value;
                cassette3_counter_7Changed = true;
            }
        }
        private string cassette3_counter_7DbString
        {
            get
            {
                if (this.cassette3_counter_7.HasValue)
                    return cassette3_counter_7.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter8
        private bool cassette3_counter_8Changed = false;
        private int? cassette3_counter_8;
        public int? Cassette3Counter8
        {
            get { return cassette3_counter_8; }
            set
            {
                cassette3_counter_8 = value;
                cassette3_counter_8Changed = true;
            }
        }
        private string cassette3_counter_8DbString
        {
            get
            {
                if (this.cassette3_counter_8.HasValue)
                    return cassette3_counter_8.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter9
        private bool cassette3_counter_9Changed = false;
        private int? cassette3_counter_9;
        public int? Cassette3Counter9
        {
            get { return cassette3_counter_9; }
            set
            {
                cassette3_counter_9 = value;
                cassette3_counter_9Changed = true;
            }
        }
        private string cassette3_counter_9DbString
        {
            get
            {
                if (this.cassette3_counter_9.HasValue)
                    return cassette3_counter_9.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter10
        private bool cassette3_counter_10Changed = false;
        private int? cassette3_counter_10;
        public int? Cassette3Counter10
        {
            get { return cassette3_counter_10; }
            set
            {
                cassette3_counter_10 = value;
                cassette3_counter_10Changed = true;
            }
        }
        private string cassette3_counter_10DbString
        {
            get
            {
                if (this.cassette3_counter_10.HasValue)
                    return cassette3_counter_10.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter11
        private bool cassette3_counter_11Changed = false;
        private int? cassette3_counter_11;
        public int? Cassette3Counter11
        {
            get { return cassette3_counter_11; }
            set
            {
                cassette3_counter_11 = value;
                cassette3_counter_11Changed = true;
            }
        }
        private string cassette3_counter_11DbString
        {
            get
            {
                if (this.cassette3_counter_11.HasValue)
                    return cassette3_counter_11.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter12
        private bool cassette3_counter_12Changed = false;
        private int? cassette3_counter_12;
        public int? Cassette3Counter12
        {
            get { return cassette3_counter_12; }
            set
            {
                cassette3_counter_12 = value;
                cassette3_counter_12Changed = true;
            }
        }
        private string cassette3_counter_12DbString
        {
            get
            {
                if (this.cassette3_counter_12.HasValue)
                    return cassette3_counter_12.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter13
        private bool cassette3_counter_13Changed = false;
        private int? cassette3_counter_13;
        public int? Cassette3Counter13
        {
            get { return cassette3_counter_13; }
            set
            {
                cassette3_counter_13 = value;
                cassette3_counter_13Changed = true;
            }
        }
        private string cassette3_counter_13DbString
        {
            get
            {
                if (this.cassette3_counter_13.HasValue)
                    return cassette3_counter_13.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter14
        private bool cassette3_counter_14Changed = false;
        private int? cassette3_counter_14;
        public int? Cassette3Counter14
        {
            get { return cassette3_counter_14; }
            set
            {
                cassette3_counter_14 = value;
                cassette3_counter_14Changed = true;
            }
        }
        private string cassette3_counter_14DbString
        {
            get
            {
                if (this.cassette3_counter_14.HasValue)
                    return cassette3_counter_14.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter15
        private bool cassette3_counter_15Changed = false;
        private int? cassette3_counter_15;
        public int? Cassette3Counter15
        {
            get { return cassette3_counter_15; }
            set
            {
                cassette3_counter_15 = value;
                cassette3_counter_15Changed = true;
            }
        }
        private string cassette3_counter_15DbString
        {
            get
            {
                if (this.cassette3_counter_15.HasValue)
                    return cassette3_counter_15.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter16
        private bool cassette3_counter_16Changed = false;
        private int? cassette3_counter_16;
        public int? Cassette3Counter16
        {
            get { return cassette3_counter_16; }
            set
            {
                cassette3_counter_16 = value;
                cassette3_counter_16Changed = true;
            }
        }
        private string cassette3_counter_16DbString
        {
            get
            {
                if (this.cassette3_counter_16.HasValue)
                    return cassette3_counter_16.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter17
        private bool cassette3_counter_17Changed = false;
        private int? cassette3_counter_17;
        public int? Cassette3Counter17
        {
            get { return cassette3_counter_17; }
            set
            {
                cassette3_counter_17 = value;
                cassette3_counter_17Changed = true;
            }
        }
        private string cassette3_counter_17DbString
        {
            get
            {
                if (this.cassette3_counter_17.HasValue)
                    return cassette3_counter_17.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter18
        private bool cassette3_counter_18Changed = false;
        private int? cassette3_counter_18;
        public int? Cassette3Counter18
        {
            get { return cassette3_counter_18; }
            set
            {
                cassette3_counter_18 = value;
                cassette3_counter_18Changed = true;
            }
        }
        private string cassette3_counter_18DbString
        {
            get
            {
                if (this.cassette3_counter_18.HasValue)
                    return cassette3_counter_18.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter19
        private bool cassette3_counter_19Changed = false;
        private int? cassette3_counter_19;
        public int? Cassette3Counter19
        {
            get { return cassette3_counter_19; }
            set
            {
                cassette3_counter_19 = value;
                cassette3_counter_19Changed = true;
            }
        }
        private string cassette3_counter_19DbString
        {
            get
            {
                if (this.cassette3_counter_19.HasValue)
                    return cassette3_counter_19.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter20
        private bool cassette3_counter_20Changed = false;
        private int? cassette3_counter_20;
        public int? Cassette3Counter20
        {
            get { return cassette3_counter_20; }
            set
            {
                cassette3_counter_20 = value;
                cassette3_counter_20Changed = true;
            }
        }
        private string cassette3_counter_20DbString
        {
            get
            {
                if (this.cassette3_counter_20.HasValue)
                    return cassette3_counter_20.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter21
        private bool cassette3_counter_21Changed = false;
        private int? cassette3_counter_21;
        public int? Cassette3Counter21
        {
            get { return cassette3_counter_21; }
            set
            {
                cassette3_counter_21 = value;
                cassette3_counter_21Changed = true;
            }
        }
        private string cassette3_counter_21DbString
        {
            get
            {
                if (this.cassette3_counter_21.HasValue)
                    return cassette3_counter_21.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter22
        private bool cassette3_counter_22Changed = false;
        private int? cassette3_counter_22;
        public int? Cassette3Counter22
        {
            get { return cassette3_counter_22; }
            set
            {
                cassette3_counter_22 = value;
                cassette3_counter_22Changed = true;
            }
        }
        private string cassette3_counter_22DbString
        {
            get
            {
                if (this.cassette3_counter_22.HasValue)
                    return cassette3_counter_22.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter23
        private bool cassette3_counter_23Changed = false;
        private int? cassette3_counter_23;
        public int? Cassette3Counter23
        {
            get { return cassette3_counter_23; }
            set
            {
                cassette3_counter_23 = value;
                cassette3_counter_23Changed = true;
            }
        }
        private string cassette3_counter_23DbString
        {
            get
            {
                if (this.cassette3_counter_23.HasValue)
                    return cassette3_counter_23.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter24
        private bool cassette3_counter_24Changed = false;
        private int? cassette3_counter_24;
        public int? Cassette3Counter24
        {
            get { return cassette3_counter_24; }
            set
            {
                cassette3_counter_24 = value;
                cassette3_counter_24Changed = true;
            }
        }
        private string cassette3_counter_24DbString
        {
            get
            {
                if (this.cassette3_counter_24.HasValue)
                    return cassette3_counter_24.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter25
        private bool cassette3_counter_25Changed = false;
        private int? cassette3_counter_25;
        public int? Cassette3Counter25
        {
            get { return cassette3_counter_25; }
            set
            {
                cassette3_counter_25 = value;
                cassette3_counter_25Changed = true;
            }
        }
        private string cassette3_counter_25DbString
        {
            get
            {
                if (this.cassette3_counter_25.HasValue)
                    return cassette3_counter_25.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter26
        private bool cassette3_counter_26Changed = false;
        private int? cassette3_counter_26;
        public int? Cassette3Counter26
        {
            get { return cassette3_counter_26; }
            set
            {
                cassette3_counter_26 = value;
                cassette3_counter_26Changed = true;
            }
        }
        private string cassette3_counter_26DbString
        {
            get
            {
                if (this.cassette3_counter_26.HasValue)
                    return cassette3_counter_26.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter27
        private bool cassette3_counter_27Changed = false;
        private int? cassette3_counter_27;
        public int? Cassette3Counter27
        {
            get { return cassette3_counter_27; }
            set
            {
                cassette3_counter_27 = value;
                cassette3_counter_27Changed = true;
            }
        }
        private string cassette3_counter_27DbString
        {
            get
            {
                if (this.cassette3_counter_27.HasValue)
                    return cassette3_counter_27.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter28
        private bool cassette3_counter_28Changed = false;
        private int? cassette3_counter_28;
        public int? Cassette3Counter28
        {
            get { return cassette3_counter_28; }
            set
            {
                cassette3_counter_28 = value;
                cassette3_counter_28Changed = true;
            }
        }
        private string cassette3_counter_28DbString
        {
            get
            {
                if (this.cassette3_counter_28.HasValue)
                    return cassette3_counter_28.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter29
        private bool cassette3_counter_29Changed = false;
        private int? cassette3_counter_29;
        public int? Cassette3Counter29
        {
            get { return cassette3_counter_29; }
            set
            {
                cassette3_counter_29 = value;
                cassette3_counter_29Changed = true;
            }
        }
        private string cassette3_counter_29DbString
        {
            get
            {
                if (this.cassette3_counter_29.HasValue)
                    return cassette3_counter_29.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter30
        private bool cassette3_counter_30Changed = false;
        private int? cassette3_counter_30;
        public int? Cassette3Counter30
        {
            get { return cassette3_counter_30; }
            set
            {
                cassette3_counter_30 = value;
                cassette3_counter_30Changed = true;
            }
        }
        private string cassette3_counter_30DbString
        {
            get
            {
                if (this.cassette3_counter_30.HasValue)
                    return cassette3_counter_30.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter31
        private bool cassette3_counter_31Changed = false;
        private int? cassette3_counter_31;
        public int? Cassette3Counter31
        {
            get { return cassette3_counter_31; }
            set
            {
                cassette3_counter_31 = value;
                cassette3_counter_31Changed = true;
            }
        }
        private string cassette3_counter_31DbString
        {
            get
            {
                if (this.cassette3_counter_31.HasValue)
                    return cassette3_counter_31.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter32
        private bool cassette3_counter_32Changed = false;
        private int? cassette3_counter_32;
        public int? Cassette3Counter32
        {
            get { return cassette3_counter_32; }
            set
            {
                cassette3_counter_32 = value;
                cassette3_counter_32Changed = true;
            }
        }
        private string cassette3_counter_32DbString
        {
            get
            {
                if (this.cassette3_counter_32.HasValue)
                    return cassette3_counter_32.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter33
        private bool cassette3_counter_33Changed = false;
        private int? cassette3_counter_33;
        public int? Cassette3Counter33
        {
            get { return cassette3_counter_33; }
            set
            {
                cassette3_counter_33 = value;
                cassette3_counter_33Changed = true;
            }
        }
        private string cassette3_counter_33DbString
        {
            get
            {
                if (this.cassette3_counter_33.HasValue)
                    return cassette3_counter_33.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter34
        private bool cassette3_counter_34Changed = false;
        private int? cassette3_counter_34;
        public int? Cassette3Counter34
        {
            get { return cassette3_counter_34; }
            set
            {
                cassette3_counter_34 = value;
                cassette3_counter_34Changed = true;
            }
        }
        private string cassette3_counter_34DbString
        {
            get
            {
                if (this.cassette3_counter_34.HasValue)
                    return cassette3_counter_34.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter35
        private bool cassette3_counter_35Changed = false;
        private int? cassette3_counter_35;
        public int? Cassette3Counter35
        {
            get { return cassette3_counter_35; }
            set
            {
                cassette3_counter_35 = value;
                cassette3_counter_35Changed = true;
            }
        }
        private string cassette3_counter_35DbString
        {
            get
            {
                if (this.cassette3_counter_35.HasValue)
                    return cassette3_counter_35.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter36
        private bool cassette3_counter_36Changed = false;
        private int? cassette3_counter_36;
        public int? Cassette3Counter36
        {
            get { return cassette3_counter_36; }
            set
            {
                cassette3_counter_36 = value;
                cassette3_counter_36Changed = true;
            }
        }
        private string cassette3_counter_36DbString
        {
            get
            {
                if (this.cassette3_counter_36.HasValue)
                    return cassette3_counter_36.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter37
        private bool cassette3_counter_37Changed = false;
        private int? cassette3_counter_37;
        public int? Cassette3Counter37
        {
            get { return cassette3_counter_37; }
            set
            {
                cassette3_counter_37 = value;
                cassette3_counter_37Changed = true;
            }
        }
        private string cassette3_counter_37DbString
        {
            get
            {
                if (this.cassette3_counter_37.HasValue)
                    return cassette3_counter_37.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter38
        private bool cassette3_counter_38Changed = false;
        private int? cassette3_counter_38;
        public int? Cassette3Counter38
        {
            get { return cassette3_counter_38; }
            set
            {
                cassette3_counter_38 = value;
                cassette3_counter_38Changed = true;
            }
        }
        private string cassette3_counter_38DbString
        {
            get
            {
                if (this.cassette3_counter_38.HasValue)
                    return cassette3_counter_38.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter39
        private bool cassette3_counter_39Changed = false;
        private int? cassette3_counter_39;
        public int? Cassette3Counter39
        {
            get { return cassette3_counter_39; }
            set
            {
                cassette3_counter_39 = value;
                cassette3_counter_39Changed = true;
            }
        }
        private string cassette3_counter_39DbString
        {
            get
            {
                if (this.cassette3_counter_39.HasValue)
                    return cassette3_counter_39.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter40
        private bool cassette3_counter_40Changed = false;
        private int? cassette3_counter_40;
        public int? Cassette3Counter40
        {
            get { return cassette3_counter_40; }
            set
            {
                cassette3_counter_40 = value;
                cassette3_counter_40Changed = true;
            }
        }
        private string cassette3_counter_40DbString
        {
            get
            {
                if (this.cassette3_counter_40.HasValue)
                    return cassette3_counter_40.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter41
        private bool cassette3_counter_41Changed = false;
        private int? cassette3_counter_41;
        public int? Cassette3Counter41
        {
            get { return cassette3_counter_41; }
            set
            {
                cassette3_counter_41 = value;
                cassette3_counter_41Changed = true;
            }
        }
        private string cassette3_counter_41DbString
        {
            get
            {
                if (this.cassette3_counter_41.HasValue)
                    return cassette3_counter_41.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter42
        private bool cassette3_counter_42Changed = false;
        private int? cassette3_counter_42;
        public int? Cassette3Counter42
        {
            get { return cassette3_counter_42; }
            set
            {
                cassette3_counter_42 = value;
                cassette3_counter_42Changed = true;
            }
        }
        private string cassette3_counter_42DbString
        {
            get
            {
                if (this.cassette3_counter_42.HasValue)
                    return cassette3_counter_42.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter43
        private bool cassette3_counter_43Changed = false;
        private int? cassette3_counter_43;
        public int? Cassette3Counter43
        {
            get { return cassette3_counter_43; }
            set
            {
                cassette3_counter_43 = value;
                cassette3_counter_43Changed = true;
            }
        }
        private string cassette3_counter_43DbString
        {
            get
            {
                if (this.cassette3_counter_43.HasValue)
                    return cassette3_counter_43.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter44
        private bool cassette3_counter_44Changed = false;
        private int? cassette3_counter_44;
        public int? Cassette3Counter44
        {
            get { return cassette3_counter_44; }
            set
            {
                cassette3_counter_44 = value;
                cassette3_counter_44Changed = true;
            }
        }
        private string cassette3_counter_44DbString
        {
            get
            {
                if (this.cassette3_counter_44.HasValue)
                    return cassette3_counter_44.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter45
        private bool cassette3_counter_45Changed = false;
        private int? cassette3_counter_45;
        public int? Cassette3Counter45
        {
            get { return cassette3_counter_45; }
            set
            {
                cassette3_counter_45 = value;
                cassette3_counter_45Changed = true;
            }
        }
        private string cassette3_counter_45DbString
        {
            get
            {
                if (this.cassette3_counter_45.HasValue)
                    return cassette3_counter_45.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter46
        private bool cassette3_counter_46Changed = false;
        private int? cassette3_counter_46;
        public int? Cassette3Counter46
        {
            get { return cassette3_counter_46; }
            set
            {
                cassette3_counter_46 = value;
                cassette3_counter_46Changed = true;
            }
        }
        private string cassette3_counter_46DbString
        {
            get
            {
                if (this.cassette3_counter_46.HasValue)
                    return cassette3_counter_46.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter47
        private bool cassette3_counter_47Changed = false;
        private int? cassette3_counter_47;
        public int? Cassette3Counter47
        {
            get { return cassette3_counter_47; }
            set
            {
                cassette3_counter_47 = value;
                cassette3_counter_47Changed = true;
            }
        }
        private string cassette3_counter_47DbString
        {
            get
            {
                if (this.cassette3_counter_47.HasValue)
                    return cassette3_counter_47.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter48
        private bool cassette3_counter_48Changed = false;
        private int? cassette3_counter_48;
        public int? Cassette3Counter48
        {
            get { return cassette3_counter_48; }
            set
            {
                cassette3_counter_48 = value;
                cassette3_counter_48Changed = true;
            }
        }
        private string cassette3_counter_48DbString
        {
            get
            {
                if (this.cassette3_counter_48.HasValue)
                    return cassette3_counter_48.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter49
        private bool cassette3_counter_49Changed = false;
        private int? cassette3_counter_49;
        public int? Cassette3Counter49
        {
            get { return cassette3_counter_49; }
            set
            {
                cassette3_counter_49 = value;
                cassette3_counter_49Changed = true;
            }
        }
        private string cassette3_counter_49DbString
        {
            get
            {
                if (this.cassette3_counter_49.HasValue)
                    return cassette3_counter_49.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3Counter50
        private bool cassette3_counter_50Changed = false;
        private int? cassette3_counter_50;
        public int? Cassette3Counter50
        {
            get { return cassette3_counter_50; }
            set
            {
                cassette3_counter_50 = value;
                cassette3_counter_50Changed = true;
            }
        }
        private string cassette3_counter_50DbString
        {
            get
            {
                if (this.cassette3_counter_50.HasValue)
                    return cassette3_counter_50.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter1
        private bool cassette4_counter_1Changed = false;
        private int? cassette4_counter_1;
        public int? Cassette4Counter1
        {
            get { return cassette4_counter_1; }
            set
            {
                cassette4_counter_1 = value;
                cassette4_counter_1Changed = true;
            }
        }
        private string cassette4_counter_1DbString
        {
            get
            {
                if (this.cassette4_counter_1.HasValue)
                    return cassette4_counter_1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter2
        private bool cassette4_counter_2Changed = false;
        private int? cassette4_counter_2;
        public int? Cassette4Counter2
        {
            get { return cassette4_counter_2; }
            set
            {
                cassette4_counter_2 = value;
                cassette4_counter_2Changed = true;
            }
        }
        private string cassette4_counter_2DbString
        {
            get
            {
                if (this.cassette4_counter_2.HasValue)
                    return cassette4_counter_2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter3
        private bool cassette4_counter_3Changed = false;
        private int? cassette4_counter_3;
        public int? Cassette4Counter3
        {
            get { return cassette4_counter_3; }
            set
            {
                cassette4_counter_3 = value;
                cassette4_counter_3Changed = true;
            }
        }
        private string cassette4_counter_3DbString
        {
            get
            {
                if (this.cassette4_counter_3.HasValue)
                    return cassette4_counter_3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter4
        private bool cassette4_counter_4Changed = false;
        private int? cassette4_counter_4;
        public int? Cassette4Counter4
        {
            get { return cassette4_counter_4; }
            set
            {
                cassette4_counter_4 = value;
                cassette4_counter_4Changed = true;
            }
        }
        private string cassette4_counter_4DbString
        {
            get
            {
                if (this.cassette4_counter_4.HasValue)
                    return cassette4_counter_4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter5
        private bool cassette4_counter_5Changed = false;
        private int? cassette4_counter_5;
        public int? Cassette4Counter5
        {
            get { return cassette4_counter_5; }
            set
            {
                cassette4_counter_5 = value;
                cassette4_counter_5Changed = true;
            }
        }
        private string cassette4_counter_5DbString
        {
            get
            {
                if (this.cassette4_counter_5.HasValue)
                    return cassette4_counter_5.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter6
        private bool cassette4_counter_6Changed = false;
        private int? cassette4_counter_6;
        public int? Cassette4Counter6
        {
            get { return cassette4_counter_6; }
            set
            {
                cassette4_counter_6 = value;
                cassette4_counter_6Changed = true;
            }
        }
        private string cassette4_counter_6DbString
        {
            get
            {
                if (this.cassette4_counter_6.HasValue)
                    return cassette4_counter_6.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter7
        private bool cassette4_counter_7Changed = false;
        private int? cassette4_counter_7;
        public int? Cassette4Counter7
        {
            get { return cassette4_counter_7; }
            set
            {
                cassette4_counter_7 = value;
                cassette4_counter_7Changed = true;
            }
        }
        private string cassette4_counter_7DbString
        {
            get
            {
                if (this.cassette4_counter_7.HasValue)
                    return cassette4_counter_7.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter8
        private bool cassette4_counter_8Changed = false;
        private int? cassette4_counter_8;
        public int? Cassette4Counter8
        {
            get { return cassette4_counter_8; }
            set
            {
                cassette4_counter_8 = value;
                cassette4_counter_8Changed = true;
            }
        }
        private string cassette4_counter_8DbString
        {
            get
            {
                if (this.cassette4_counter_8.HasValue)
                    return cassette4_counter_8.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter9
        private bool cassette4_counter_9Changed = false;
        private int? cassette4_counter_9;
        public int? Cassette4Counter9
        {
            get { return cassette4_counter_9; }
            set
            {
                cassette4_counter_9 = value;
                cassette4_counter_9Changed = true;
            }
        }
        private string cassette4_counter_9DbString
        {
            get
            {
                if (this.cassette4_counter_9.HasValue)
                    return cassette4_counter_9.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter10
        private bool cassette4_counter_10Changed = false;
        private int? cassette4_counter_10;
        public int? Cassette4Counter10
        {
            get { return cassette4_counter_10; }
            set
            {
                cassette4_counter_10 = value;
                cassette4_counter_10Changed = true;
            }
        }
        private string cassette4_counter_10DbString
        {
            get
            {
                if (this.cassette4_counter_10.HasValue)
                    return cassette4_counter_10.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter11
        private bool cassette4_counter_11Changed = false;
        private int? cassette4_counter_11;
        public int? Cassette4Counter11
        {
            get { return cassette4_counter_11; }
            set
            {
                cassette4_counter_11 = value;
                cassette4_counter_11Changed = true;
            }
        }
        private string cassette4_counter_11DbString
        {
            get
            {
                if (this.cassette4_counter_11.HasValue)
                    return cassette4_counter_11.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter12
        private bool cassette4_counter_12Changed = false;
        private int? cassette4_counter_12;
        public int? Cassette4Counter12
        {
            get { return cassette4_counter_12; }
            set
            {
                cassette4_counter_12 = value;
                cassette4_counter_12Changed = true;
            }
        }
        private string cassette4_counter_12DbString
        {
            get
            {
                if (this.cassette4_counter_12.HasValue)
                    return cassette4_counter_12.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter13
        private bool cassette4_counter_13Changed = false;
        private int? cassette4_counter_13;
        public int? Cassette4Counter13
        {
            get { return cassette4_counter_13; }
            set
            {
                cassette4_counter_13 = value;
                cassette4_counter_13Changed = true;
            }
        }
        private string cassette4_counter_13DbString
        {
            get
            {
                if (this.cassette4_counter_13.HasValue)
                    return cassette4_counter_13.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter14
        private bool cassette4_counter_14Changed = false;
        private int? cassette4_counter_14;
        public int? Cassette4Counter14
        {
            get { return cassette4_counter_14; }
            set
            {
                cassette4_counter_14 = value;
                cassette4_counter_14Changed = true;
            }
        }
        private string cassette4_counter_14DbString
        {
            get
            {
                if (this.cassette4_counter_14.HasValue)
                    return cassette4_counter_14.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter15
        private bool cassette4_counter_15Changed = false;
        private int? cassette4_counter_15;
        public int? Cassette4Counter15
        {
            get { return cassette4_counter_15; }
            set
            {
                cassette4_counter_15 = value;
                cassette4_counter_15Changed = true;
            }
        }
        private string cassette4_counter_15DbString
        {
            get
            {
                if (this.cassette4_counter_15.HasValue)
                    return cassette4_counter_15.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter16
        private bool cassette4_counter_16Changed = false;
        private int? cassette4_counter_16;
        public int? Cassette4Counter16
        {
            get { return cassette4_counter_16; }
            set
            {
                cassette4_counter_16 = value;
                cassette4_counter_16Changed = true;
            }
        }
        private string cassette4_counter_16DbString
        {
            get
            {
                if (this.cassette4_counter_16.HasValue)
                    return cassette4_counter_16.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter17
        private bool cassette4_counter_17Changed = false;
        private int? cassette4_counter_17;
        public int? Cassette4Counter17
        {
            get { return cassette4_counter_17; }
            set
            {
                cassette4_counter_17 = value;
                cassette4_counter_17Changed = true;
            }
        }
        private string cassette4_counter_17DbString
        {
            get
            {
                if (this.cassette4_counter_17.HasValue)
                    return cassette4_counter_17.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter18
        private bool cassette4_counter_18Changed = false;
        private int? cassette4_counter_18;
        public int? Cassette4Counter18
        {
            get { return cassette4_counter_18; }
            set
            {
                cassette4_counter_18 = value;
                cassette4_counter_18Changed = true;
            }
        }
        private string cassette4_counter_18DbString
        {
            get
            {
                if (this.cassette4_counter_18.HasValue)
                    return cassette4_counter_18.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter19
        private bool cassette4_counter_19Changed = false;
        private int? cassette4_counter_19;
        public int? Cassette4Counter19
        {
            get { return cassette4_counter_19; }
            set
            {
                cassette4_counter_19 = value;
                cassette4_counter_19Changed = true;
            }
        }
        private string cassette4_counter_19DbString
        {
            get
            {
                if (this.cassette4_counter_19.HasValue)
                    return cassette4_counter_19.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter20
        private bool cassette4_counter_20Changed = false;
        private int? cassette4_counter_20;
        public int? Cassette4Counter20
        {
            get { return cassette4_counter_20; }
            set
            {
                cassette4_counter_20 = value;
                cassette4_counter_20Changed = true;
            }
        }
        private string cassette4_counter_20DbString
        {
            get
            {
                if (this.cassette4_counter_20.HasValue)
                    return cassette4_counter_20.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter21
        private bool cassette4_counter_21Changed = false;
        private int? cassette4_counter_21;
        public int? Cassette4Counter21
        {
            get { return cassette4_counter_21; }
            set
            {
                cassette4_counter_21 = value;
                cassette4_counter_21Changed = true;
            }
        }
        private string cassette4_counter_21DbString
        {
            get
            {
                if (this.cassette4_counter_21.HasValue)
                    return cassette4_counter_21.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter22
        private bool cassette4_counter_22Changed = false;
        private int? cassette4_counter_22;
        public int? Cassette4Counter22
        {
            get { return cassette4_counter_22; }
            set
            {
                cassette4_counter_22 = value;
                cassette4_counter_22Changed = true;
            }
        }
        private string cassette4_counter_22DbString
        {
            get
            {
                if (this.cassette4_counter_22.HasValue)
                    return cassette4_counter_22.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter23
        private bool cassette4_counter_23Changed = false;
        private int? cassette4_counter_23;
        public int? Cassette4Counter23
        {
            get { return cassette4_counter_23; }
            set
            {
                cassette4_counter_23 = value;
                cassette4_counter_23Changed = true;
            }
        }
        private string cassette4_counter_23DbString
        {
            get
            {
                if (this.cassette4_counter_23.HasValue)
                    return cassette4_counter_23.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter24
        private bool cassette4_counter_24Changed = false;
        private int? cassette4_counter_24;
        public int? Cassette4Counter24
        {
            get { return cassette4_counter_24; }
            set
            {
                cassette4_counter_24 = value;
                cassette4_counter_24Changed = true;
            }
        }
        private string cassette4_counter_24DbString
        {
            get
            {
                if (this.cassette4_counter_24.HasValue)
                    return cassette4_counter_24.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter25
        private bool cassette4_counter_25Changed = false;
        private int? cassette4_counter_25;
        public int? Cassette4Counter25
        {
            get { return cassette4_counter_25; }
            set
            {
                cassette4_counter_25 = value;
                cassette4_counter_25Changed = true;
            }
        }
        private string cassette4_counter_25DbString
        {
            get
            {
                if (this.cassette4_counter_25.HasValue)
                    return cassette4_counter_25.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter26
        private bool cassette4_counter_26Changed = false;
        private int? cassette4_counter_26;
        public int? Cassette4Counter26
        {
            get { return cassette4_counter_26; }
            set
            {
                cassette4_counter_26 = value;
                cassette4_counter_26Changed = true;
            }
        }
        private string cassette4_counter_26DbString
        {
            get
            {
                if (this.cassette4_counter_26.HasValue)
                    return cassette4_counter_26.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter27
        private bool cassette4_counter_27Changed = false;
        private int? cassette4_counter_27;
        public int? Cassette4Counter27
        {
            get { return cassette4_counter_27; }
            set
            {
                cassette4_counter_27 = value;
                cassette4_counter_27Changed = true;
            }
        }
        private string cassette4_counter_27DbString
        {
            get
            {
                if (this.cassette4_counter_27.HasValue)
                    return cassette4_counter_27.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter28
        private bool cassette4_counter_28Changed = false;
        private int? cassette4_counter_28;
        public int? Cassette4Counter28
        {
            get { return cassette4_counter_28; }
            set
            {
                cassette4_counter_28 = value;
                cassette4_counter_28Changed = true;
            }
        }
        private string cassette4_counter_28DbString
        {
            get
            {
                if (this.cassette4_counter_28.HasValue)
                    return cassette4_counter_28.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter29
        private bool cassette4_counter_29Changed = false;
        private int? cassette4_counter_29;
        public int? Cassette4Counter29
        {
            get { return cassette4_counter_29; }
            set
            {
                cassette4_counter_29 = value;
                cassette4_counter_29Changed = true;
            }
        }
        private string cassette4_counter_29DbString
        {
            get
            {
                if (this.cassette4_counter_29.HasValue)
                    return cassette4_counter_29.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter30
        private bool cassette4_counter_30Changed = false;
        private int? cassette4_counter_30;
        public int? Cassette4Counter30
        {
            get { return cassette4_counter_30; }
            set
            {
                cassette4_counter_30 = value;
                cassette4_counter_30Changed = true;
            }
        }
        private string cassette4_counter_30DbString
        {
            get
            {
                if (this.cassette4_counter_30.HasValue)
                    return cassette4_counter_30.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter31
        private bool cassette4_counter_31Changed = false;
        private int? cassette4_counter_31;
        public int? Cassette4Counter31
        {
            get { return cassette4_counter_31; }
            set
            {
                cassette4_counter_31 = value;
                cassette4_counter_31Changed = true;
            }
        }
        private string cassette4_counter_31DbString
        {
            get
            {
                if (this.cassette4_counter_31.HasValue)
                    return cassette4_counter_31.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter32
        private bool cassette4_counter_32Changed = false;
        private int? cassette4_counter_32;
        public int? Cassette4Counter32
        {
            get { return cassette4_counter_32; }
            set
            {
                cassette4_counter_32 = value;
                cassette4_counter_32Changed = true;
            }
        }
        private string cassette4_counter_32DbString
        {
            get
            {
                if (this.cassette4_counter_32.HasValue)
                    return cassette4_counter_32.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter33
        private bool cassette4_counter_33Changed = false;
        private int? cassette4_counter_33;
        public int? Cassette4Counter33
        {
            get { return cassette4_counter_33; }
            set
            {
                cassette4_counter_33 = value;
                cassette4_counter_33Changed = true;
            }
        }
        private string cassette4_counter_33DbString
        {
            get
            {
                if (this.cassette4_counter_33.HasValue)
                    return cassette4_counter_33.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter34
        private bool cassette4_counter_34Changed = false;
        private int? cassette4_counter_34;
        public int? Cassette4Counter34
        {
            get { return cassette4_counter_34; }
            set
            {
                cassette4_counter_34 = value;
                cassette4_counter_34Changed = true;
            }
        }
        private string cassette4_counter_34DbString
        {
            get
            {
                if (this.cassette4_counter_34.HasValue)
                    return cassette4_counter_34.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter35
        private bool cassette4_counter_35Changed = false;
        private int? cassette4_counter_35;
        public int? Cassette4Counter35
        {
            get { return cassette4_counter_35; }
            set
            {
                cassette4_counter_35 = value;
                cassette4_counter_35Changed = true;
            }
        }
        private string cassette4_counter_35DbString
        {
            get
            {
                if (this.cassette4_counter_35.HasValue)
                    return cassette4_counter_35.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter36
        private bool cassette4_counter_36Changed = false;
        private int? cassette4_counter_36;
        public int? Cassette4Counter36
        {
            get { return cassette4_counter_36; }
            set
            {
                cassette4_counter_36 = value;
                cassette4_counter_36Changed = true;
            }
        }
        private string cassette4_counter_36DbString
        {
            get
            {
                if (this.cassette4_counter_36.HasValue)
                    return cassette4_counter_36.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter37
        private bool cassette4_counter_37Changed = false;
        private int? cassette4_counter_37;
        public int? Cassette4Counter37
        {
            get { return cassette4_counter_37; }
            set
            {
                cassette4_counter_37 = value;
                cassette4_counter_37Changed = true;
            }
        }
        private string cassette4_counter_37DbString
        {
            get
            {
                if (this.cassette4_counter_37.HasValue)
                    return cassette4_counter_37.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter38
        private bool cassette4_counter_38Changed = false;
        private int? cassette4_counter_38;
        public int? Cassette4Counter38
        {
            get { return cassette4_counter_38; }
            set
            {
                cassette4_counter_38 = value;
                cassette4_counter_38Changed = true;
            }
        }
        private string cassette4_counter_38DbString
        {
            get
            {
                if (this.cassette4_counter_38.HasValue)
                    return cassette4_counter_38.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter39
        private bool cassette4_counter_39Changed = false;
        private int? cassette4_counter_39;
        public int? Cassette4Counter39
        {
            get { return cassette4_counter_39; }
            set
            {
                cassette4_counter_39 = value;
                cassette4_counter_39Changed = true;
            }
        }
        private string cassette4_counter_39DbString
        {
            get
            {
                if (this.cassette4_counter_39.HasValue)
                    return cassette4_counter_39.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter40
        private bool cassette4_counter_40Changed = false;
        private int? cassette4_counter_40;
        public int? Cassette4Counter40
        {
            get { return cassette4_counter_40; }
            set
            {
                cassette4_counter_40 = value;
                cassette4_counter_40Changed = true;
            }
        }
        private string cassette4_counter_40DbString
        {
            get
            {
                if (this.cassette4_counter_40.HasValue)
                    return cassette4_counter_40.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter41
        private bool cassette4_counter_41Changed = false;
        private int? cassette4_counter_41;
        public int? Cassette4Counter41
        {
            get { return cassette4_counter_41; }
            set
            {
                cassette4_counter_41 = value;
                cassette4_counter_41Changed = true;
            }
        }
        private string cassette4_counter_41DbString
        {
            get
            {
                if (this.cassette4_counter_41.HasValue)
                    return cassette4_counter_41.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter42
        private bool cassette4_counter_42Changed = false;
        private int? cassette4_counter_42;
        public int? Cassette4Counter42
        {
            get { return cassette4_counter_42; }
            set
            {
                cassette4_counter_42 = value;
                cassette4_counter_42Changed = true;
            }
        }
        private string cassette4_counter_42DbString
        {
            get
            {
                if (this.cassette4_counter_42.HasValue)
                    return cassette4_counter_42.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter43
        private bool cassette4_counter_43Changed = false;
        private int? cassette4_counter_43;
        public int? Cassette4Counter43
        {
            get { return cassette4_counter_43; }
            set
            {
                cassette4_counter_43 = value;
                cassette4_counter_43Changed = true;
            }
        }
        private string cassette4_counter_43DbString
        {
            get
            {
                if (this.cassette4_counter_43.HasValue)
                    return cassette4_counter_43.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter44
        private bool cassette4_counter_44Changed = false;
        private int? cassette4_counter_44;
        public int? Cassette4Counter44
        {
            get { return cassette4_counter_44; }
            set
            {
                cassette4_counter_44 = value;
                cassette4_counter_44Changed = true;
            }
        }
        private string cassette4_counter_44DbString
        {
            get
            {
                if (this.cassette4_counter_44.HasValue)
                    return cassette4_counter_44.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter45
        private bool cassette4_counter_45Changed = false;
        private int? cassette4_counter_45;
        public int? Cassette4Counter45
        {
            get { return cassette4_counter_45; }
            set
            {
                cassette4_counter_45 = value;
                cassette4_counter_45Changed = true;
            }
        }
        private string cassette4_counter_45DbString
        {
            get
            {
                if (this.cassette4_counter_45.HasValue)
                    return cassette4_counter_45.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter46
        private bool cassette4_counter_46Changed = false;
        private int? cassette4_counter_46;
        public int? Cassette4Counter46
        {
            get { return cassette4_counter_46; }
            set
            {
                cassette4_counter_46 = value;
                cassette4_counter_46Changed = true;
            }
        }
        private string cassette4_counter_46DbString
        {
            get
            {
                if (this.cassette4_counter_46.HasValue)
                    return cassette4_counter_46.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter47
        private bool cassette4_counter_47Changed = false;
        private int? cassette4_counter_47;
        public int? Cassette4Counter47
        {
            get { return cassette4_counter_47; }
            set
            {
                cassette4_counter_47 = value;
                cassette4_counter_47Changed = true;
            }
        }
        private string cassette4_counter_47DbString
        {
            get
            {
                if (this.cassette4_counter_47.HasValue)
                    return cassette4_counter_47.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter48
        private bool cassette4_counter_48Changed = false;
        private int? cassette4_counter_48;
        public int? Cassette4Counter48
        {
            get { return cassette4_counter_48; }
            set
            {
                cassette4_counter_48 = value;
                cassette4_counter_48Changed = true;
            }
        }
        private string cassette4_counter_48DbString
        {
            get
            {
                if (this.cassette4_counter_48.HasValue)
                    return cassette4_counter_48.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter49
        private bool cassette4_counter_49Changed = false;
        private int? cassette4_counter_49;
        public int? Cassette4Counter49
        {
            get { return cassette4_counter_49; }
            set
            {
                cassette4_counter_49 = value;
                cassette4_counter_49Changed = true;
            }
        }
        private string cassette4_counter_49DbString
        {
            get
            {
                if (this.cassette4_counter_49.HasValue)
                    return cassette4_counter_49.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4Counter50
        private bool cassette4_counter_50Changed = false;
        private int? cassette4_counter_50;
        public int? Cassette4Counter50
        {
            get { return cassette4_counter_50; }
            set
            {
                cassette4_counter_50 = value;
                cassette4_counter_50Changed = true;
            }
        }
        private string cassette4_counter_50DbString
        {
            get
            {
                if (this.cassette4_counter_50.HasValue)
                    return cassette4_counter_50.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter1
        private bool purge_counter_1Changed = false;
        private int? purge_counter_1;
        public int? PurgeCounter1
        {
            get { return purge_counter_1; }
            set
            {
                purge_counter_1 = value;
                purge_counter_1Changed = true;
            }
        }
        private string purge_counter_1DbString
        {
            get
            {
                if (this.purge_counter_1.HasValue)
                    return purge_counter_1.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter2
        private bool purge_counter_2Changed = false;
        private int? purge_counter_2;
        public int? PurgeCounter2
        {
            get { return purge_counter_2; }
            set
            {
                purge_counter_2 = value;
                purge_counter_2Changed = true;
            }
        }
        private string purge_counter_2DbString
        {
            get
            {
                if (this.purge_counter_2.HasValue)
                    return purge_counter_2.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter3
        private bool purge_counter_3Changed = false;
        private int? purge_counter_3;
        public int? PurgeCounter3
        {
            get { return purge_counter_3; }
            set
            {
                purge_counter_3 = value;
                purge_counter_3Changed = true;
            }
        }
        private string purge_counter_3DbString
        {
            get
            {
                if (this.purge_counter_3.HasValue)
                    return purge_counter_3.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter4
        private bool purge_counter_4Changed = false;
        private int? purge_counter_4;
        public int? PurgeCounter4
        {
            get { return purge_counter_4; }
            set
            {
                purge_counter_4 = value;
                purge_counter_4Changed = true;
            }
        }
        private string purge_counter_4DbString
        {
            get
            {
                if (this.purge_counter_4.HasValue)
                    return purge_counter_4.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter5
        private bool purge_counter_5Changed = false;
        private int? purge_counter_5;
        public int? PurgeCounter5
        {
            get { return purge_counter_5; }
            set
            {
                purge_counter_5 = value;
                purge_counter_5Changed = true;
            }
        }
        private string purge_counter_5DbString
        {
            get
            {
                if (this.purge_counter_5.HasValue)
                    return purge_counter_5.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter6
        private bool purge_counter_6Changed = false;
        private int? purge_counter_6;
        public int? PurgeCounter6
        {
            get { return purge_counter_6; }
            set
            {
                purge_counter_6 = value;
                purge_counter_6Changed = true;
            }
        }
        private string purge_counter_6DbString
        {
            get
            {
                if (this.purge_counter_6.HasValue)
                    return purge_counter_6.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter7
        private bool purge_counter_7Changed = false;
        private int? purge_counter_7;
        public int? PurgeCounter7
        {
            get { return purge_counter_7; }
            set
            {
                purge_counter_7 = value;
                purge_counter_7Changed = true;
            }
        }
        private string purge_counter_7DbString
        {
            get
            {
                if (this.purge_counter_7.HasValue)
                    return purge_counter_7.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter8
        private bool purge_counter_8Changed = false;
        private int? purge_counter_8;
        public int? PurgeCounter8
        {
            get { return purge_counter_8; }
            set
            {
                purge_counter_8 = value;
                purge_counter_8Changed = true;
            }
        }
        private string purge_counter_8DbString
        {
            get
            {
                if (this.purge_counter_8.HasValue)
                    return purge_counter_8.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter9
        private bool purge_counter_9Changed = false;
        private int? purge_counter_9;
        public int? PurgeCounter9
        {
            get { return purge_counter_9; }
            set
            {
                purge_counter_9 = value;
                purge_counter_9Changed = true;
            }
        }
        private string purge_counter_9DbString
        {
            get
            {
                if (this.purge_counter_9.HasValue)
                    return purge_counter_9.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter10
        private bool purge_counter_10Changed = false;
        private int? purge_counter_10;
        public int? PurgeCounter10
        {
            get { return purge_counter_10; }
            set
            {
                purge_counter_10 = value;
                purge_counter_10Changed = true;
            }
        }
        private string purge_counter_10DbString
        {
            get
            {
                if (this.purge_counter_10.HasValue)
                    return purge_counter_10.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter11
        private bool purge_counter_11Changed = false;
        private int? purge_counter_11;
        public int? PurgeCounter11
        {
            get { return purge_counter_11; }
            set
            {
                purge_counter_11 = value;
                purge_counter_11Changed = true;
            }
        }
        private string purge_counter_11DbString
        {
            get
            {
                if (this.purge_counter_11.HasValue)
                    return purge_counter_11.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter12
        private bool purge_counter_12Changed = false;
        private int? purge_counter_12;
        public int? PurgeCounter12
        {
            get { return purge_counter_12; }
            set
            {
                purge_counter_12 = value;
                purge_counter_12Changed = true;
            }
        }
        private string purge_counter_12DbString
        {
            get
            {
                if (this.purge_counter_12.HasValue)
                    return purge_counter_12.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter13
        private bool purge_counter_13Changed = false;
        private int? purge_counter_13;
        public int? PurgeCounter13
        {
            get { return purge_counter_13; }
            set
            {
                purge_counter_13 = value;
                purge_counter_13Changed = true;
            }
        }
        private string purge_counter_13DbString
        {
            get
            {
                if (this.purge_counter_13.HasValue)
                    return purge_counter_13.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter14
        private bool purge_counter_14Changed = false;
        private int? purge_counter_14;
        public int? PurgeCounter14
        {
            get { return purge_counter_14; }
            set
            {
                purge_counter_14 = value;
                purge_counter_14Changed = true;
            }
        }
        private string purge_counter_14DbString
        {
            get
            {
                if (this.purge_counter_14.HasValue)
                    return purge_counter_14.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter15
        private bool purge_counter_15Changed = false;
        private int? purge_counter_15;
        public int? PurgeCounter15
        {
            get { return purge_counter_15; }
            set
            {
                purge_counter_15 = value;
                purge_counter_15Changed = true;
            }
        }
        private string purge_counter_15DbString
        {
            get
            {
                if (this.purge_counter_15.HasValue)
                    return purge_counter_15.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter16
        private bool purge_counter_16Changed = false;
        private int? purge_counter_16;
        public int? PurgeCounter16
        {
            get { return purge_counter_16; }
            set
            {
                purge_counter_16 = value;
                purge_counter_16Changed = true;
            }
        }
        private string purge_counter_16DbString
        {
            get
            {
                if (this.purge_counter_16.HasValue)
                    return purge_counter_16.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter17
        private bool purge_counter_17Changed = false;
        private int? purge_counter_17;
        public int? PurgeCounter17
        {
            get { return purge_counter_17; }
            set
            {
                purge_counter_17 = value;
                purge_counter_17Changed = true;
            }
        }
        private string purge_counter_17DbString
        {
            get
            {
                if (this.purge_counter_17.HasValue)
                    return purge_counter_17.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter18
        private bool purge_counter_18Changed = false;
        private int? purge_counter_18;
        public int? PurgeCounter18
        {
            get { return purge_counter_18; }
            set
            {
                purge_counter_18 = value;
                purge_counter_18Changed = true;
            }
        }
        private string purge_counter_18DbString
        {
            get
            {
                if (this.purge_counter_18.HasValue)
                    return purge_counter_18.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter19
        private bool purge_counter_19Changed = false;
        private int? purge_counter_19;
        public int? PurgeCounter19
        {
            get { return purge_counter_19; }
            set
            {
                purge_counter_19 = value;
                purge_counter_19Changed = true;
            }
        }
        private string purge_counter_19DbString
        {
            get
            {
                if (this.purge_counter_19.HasValue)
                    return purge_counter_19.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter20
        private bool purge_counter_20Changed = false;
        private int? purge_counter_20;
        public int? PurgeCounter20
        {
            get { return purge_counter_20; }
            set
            {
                purge_counter_20 = value;
                purge_counter_20Changed = true;
            }
        }
        private string purge_counter_20DbString
        {
            get
            {
                if (this.purge_counter_20.HasValue)
                    return purge_counter_20.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter21
        private bool purge_counter_21Changed = false;
        private int? purge_counter_21;
        public int? PurgeCounter21
        {
            get { return purge_counter_21; }
            set
            {
                purge_counter_21 = value;
                purge_counter_21Changed = true;
            }
        }
        private string purge_counter_21DbString
        {
            get
            {
                if (this.purge_counter_21.HasValue)
                    return purge_counter_21.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter22
        private bool purge_counter_22Changed = false;
        private int? purge_counter_22;
        public int? PurgeCounter22
        {
            get { return purge_counter_22; }
            set
            {
                purge_counter_22 = value;
                purge_counter_22Changed = true;
            }
        }
        private string purge_counter_22DbString
        {
            get
            {
                if (this.purge_counter_22.HasValue)
                    return purge_counter_22.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter23
        private bool purge_counter_23Changed = false;
        private int? purge_counter_23;
        public int? PurgeCounter23
        {
            get { return purge_counter_23; }
            set
            {
                purge_counter_23 = value;
                purge_counter_23Changed = true;
            }
        }
        private string purge_counter_23DbString
        {
            get
            {
                if (this.purge_counter_23.HasValue)
                    return purge_counter_23.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter24
        private bool purge_counter_24Changed = false;
        private int? purge_counter_24;
        public int? PurgeCounter24
        {
            get { return purge_counter_24; }
            set
            {
                purge_counter_24 = value;
                purge_counter_24Changed = true;
            }
        }
        private string purge_counter_24DbString
        {
            get
            {
                if (this.purge_counter_24.HasValue)
                    return purge_counter_24.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter25
        private bool purge_counter_25Changed = false;
        private int? purge_counter_25;
        public int? PurgeCounter25
        {
            get { return purge_counter_25; }
            set
            {
                purge_counter_25 = value;
                purge_counter_25Changed = true;
            }
        }
        private string purge_counter_25DbString
        {
            get
            {
                if (this.purge_counter_25.HasValue)
                    return purge_counter_25.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter26
        private bool purge_counter_26Changed = false;
        private int? purge_counter_26;
        public int? PurgeCounter26
        {
            get { return purge_counter_26; }
            set
            {
                purge_counter_26 = value;
                purge_counter_26Changed = true;
            }
        }
        private string purge_counter_26DbString
        {
            get
            {
                if (this.purge_counter_26.HasValue)
                    return purge_counter_26.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter27
        private bool purge_counter_27Changed = false;
        private int? purge_counter_27;
        public int? PurgeCounter27
        {
            get { return purge_counter_27; }
            set
            {
                purge_counter_27 = value;
                purge_counter_27Changed = true;
            }
        }
        private string purge_counter_27DbString
        {
            get
            {
                if (this.purge_counter_27.HasValue)
                    return purge_counter_27.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter28
        private bool purge_counter_28Changed = false;
        private int? purge_counter_28;
        public int? PurgeCounter28
        {
            get { return purge_counter_28; }
            set
            {
                purge_counter_28 = value;
                purge_counter_28Changed = true;
            }
        }
        private string purge_counter_28DbString
        {
            get
            {
                if (this.purge_counter_28.HasValue)
                    return purge_counter_28.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter29
        private bool purge_counter_29Changed = false;
        private int? purge_counter_29;
        public int? PurgeCounter29
        {
            get { return purge_counter_29; }
            set
            {
                purge_counter_29 = value;
                purge_counter_29Changed = true;
            }
        }
        private string purge_counter_29DbString
        {
            get
            {
                if (this.purge_counter_29.HasValue)
                    return purge_counter_29.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter30
        private bool purge_counter_30Changed = false;
        private int? purge_counter_30;
        public int? PurgeCounter30
        {
            get { return purge_counter_30; }
            set
            {
                purge_counter_30 = value;
                purge_counter_30Changed = true;
            }
        }
        private string purge_counter_30DbString
        {
            get
            {
                if (this.purge_counter_30.HasValue)
                    return purge_counter_30.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter31
        private bool purge_counter_31Changed = false;
        private int? purge_counter_31;
        public int? PurgeCounter31
        {
            get { return purge_counter_31; }
            set
            {
                purge_counter_31 = value;
                purge_counter_31Changed = true;
            }
        }
        private string purge_counter_31DbString
        {
            get
            {
                if (this.purge_counter_31.HasValue)
                    return purge_counter_31.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter32
        private bool purge_counter_32Changed = false;
        private int? purge_counter_32;
        public int? PurgeCounter32
        {
            get { return purge_counter_32; }
            set
            {
                purge_counter_32 = value;
                purge_counter_32Changed = true;
            }
        }
        private string purge_counter_32DbString
        {
            get
            {
                if (this.purge_counter_32.HasValue)
                    return purge_counter_32.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter33
        private bool purge_counter_33Changed = false;
        private int? purge_counter_33;
        public int? PurgeCounter33
        {
            get { return purge_counter_33; }
            set
            {
                purge_counter_33 = value;
                purge_counter_33Changed = true;
            }
        }
        private string purge_counter_33DbString
        {
            get
            {
                if (this.purge_counter_33.HasValue)
                    return purge_counter_33.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter34
        private bool purge_counter_34Changed = false;
        private int? purge_counter_34;
        public int? PurgeCounter34
        {
            get { return purge_counter_34; }
            set
            {
                purge_counter_34 = value;
                purge_counter_34Changed = true;
            }
        }
        private string purge_counter_34DbString
        {
            get
            {
                if (this.purge_counter_34.HasValue)
                    return purge_counter_34.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter35
        private bool purge_counter_35Changed = false;
        private int? purge_counter_35;
        public int? PurgeCounter35
        {
            get { return purge_counter_35; }
            set
            {
                purge_counter_35 = value;
                purge_counter_35Changed = true;
            }
        }
        private string purge_counter_35DbString
        {
            get
            {
                if (this.purge_counter_35.HasValue)
                    return purge_counter_35.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter36
        private bool purge_counter_36Changed = false;
        private int? purge_counter_36;
        public int? PurgeCounter36
        {
            get { return purge_counter_36; }
            set
            {
                purge_counter_36 = value;
                purge_counter_36Changed = true;
            }
        }
        private string purge_counter_36DbString
        {
            get
            {
                if (this.purge_counter_36.HasValue)
                    return purge_counter_36.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter37
        private bool purge_counter_37Changed = false;
        private int? purge_counter_37;
        public int? PurgeCounter37
        {
            get { return purge_counter_37; }
            set
            {
                purge_counter_37 = value;
                purge_counter_37Changed = true;
            }
        }
        private string purge_counter_37DbString
        {
            get
            {
                if (this.purge_counter_37.HasValue)
                    return purge_counter_37.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter38
        private bool purge_counter_38Changed = false;
        private int? purge_counter_38;
        public int? PurgeCounter38
        {
            get { return purge_counter_38; }
            set
            {
                purge_counter_38 = value;
                purge_counter_38Changed = true;
            }
        }
        private string purge_counter_38DbString
        {
            get
            {
                if (this.purge_counter_38.HasValue)
                    return purge_counter_38.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter39
        private bool purge_counter_39Changed = false;
        private int? purge_counter_39;
        public int? PurgeCounter39
        {
            get { return purge_counter_39; }
            set
            {
                purge_counter_39 = value;
                purge_counter_39Changed = true;
            }
        }
        private string purge_counter_39DbString
        {
            get
            {
                if (this.purge_counter_39.HasValue)
                    return purge_counter_39.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter40
        private bool purge_counter_40Changed = false;
        private int? purge_counter_40;
        public int? PurgeCounter40
        {
            get { return purge_counter_40; }
            set
            {
                purge_counter_40 = value;
                purge_counter_40Changed = true;
            }
        }
        private string purge_counter_40DbString
        {
            get
            {
                if (this.purge_counter_40.HasValue)
                    return purge_counter_40.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter41
        private bool purge_counter_41Changed = false;
        private int? purge_counter_41;
        public int? PurgeCounter41
        {
            get { return purge_counter_41; }
            set
            {
                purge_counter_41 = value;
                purge_counter_41Changed = true;
            }
        }
        private string purge_counter_41DbString
        {
            get
            {
                if (this.purge_counter_41.HasValue)
                    return purge_counter_41.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter42
        private bool purge_counter_42Changed = false;
        private int? purge_counter_42;
        public int? PurgeCounter42
        {
            get { return purge_counter_42; }
            set
            {
                purge_counter_42 = value;
                purge_counter_42Changed = true;
            }
        }
        private string purge_counter_42DbString
        {
            get
            {
                if (this.purge_counter_42.HasValue)
                    return purge_counter_42.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter43
        private bool purge_counter_43Changed = false;
        private int? purge_counter_43;
        public int? PurgeCounter43
        {
            get { return purge_counter_43; }
            set
            {
                purge_counter_43 = value;
                purge_counter_43Changed = true;
            }
        }
        private string purge_counter_43DbString
        {
            get
            {
                if (this.purge_counter_43.HasValue)
                    return purge_counter_43.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter44
        private bool purge_counter_44Changed = false;
        private int? purge_counter_44;
        public int? PurgeCounter44
        {
            get { return purge_counter_44; }
            set
            {
                purge_counter_44 = value;
                purge_counter_44Changed = true;
            }
        }
        private string purge_counter_44DbString
        {
            get
            {
                if (this.purge_counter_44.HasValue)
                    return purge_counter_44.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter45
        private bool purge_counter_45Changed = false;
        private int? purge_counter_45;
        public int? PurgeCounter45
        {
            get { return purge_counter_45; }
            set
            {
                purge_counter_45 = value;
                purge_counter_45Changed = true;
            }
        }
        private string purge_counter_45DbString
        {
            get
            {
                if (this.purge_counter_45.HasValue)
                    return purge_counter_45.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter46
        private bool purge_counter_46Changed = false;
        private int? purge_counter_46;
        public int? PurgeCounter46
        {
            get { return purge_counter_46; }
            set
            {
                purge_counter_46 = value;
                purge_counter_46Changed = true;
            }
        }
        private string purge_counter_46DbString
        {
            get
            {
                if (this.purge_counter_46.HasValue)
                    return purge_counter_46.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter47
        private bool purge_counter_47Changed = false;
        private int? purge_counter_47;
        public int? PurgeCounter47
        {
            get { return purge_counter_47; }
            set
            {
                purge_counter_47 = value;
                purge_counter_47Changed = true;
            }
        }
        private string purge_counter_47DbString
        {
            get
            {
                if (this.purge_counter_47.HasValue)
                    return purge_counter_47.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter48
        private bool purge_counter_48Changed = false;
        private int? purge_counter_48;
        public int? PurgeCounter48
        {
            get { return purge_counter_48; }
            set
            {
                purge_counter_48 = value;
                purge_counter_48Changed = true;
            }
        }
        private string purge_counter_48DbString
        {
            get
            {
                if (this.purge_counter_48.HasValue)
                    return purge_counter_48.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter49
        private bool purge_counter_49Changed = false;
        private int? purge_counter_49;
        public int? PurgeCounter49
        {
            get { return purge_counter_49; }
            set
            {
                purge_counter_49 = value;
                purge_counter_49Changed = true;
            }
        }
        private string purge_counter_49DbString
        {
            get
            {
                if (this.purge_counter_49.HasValue)
                    return purge_counter_49.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeCounter50
        private bool purge_counter_50Changed = false;
        private int? purge_counter_50;
        public int? PurgeCounter50
        {
            get { return purge_counter_50; }
            set
            {
                purge_counter_50 = value;
                purge_counter_50Changed = true;
            }
        }
        private string purge_counter_50DbString
        {
            get
            {
                if (this.purge_counter_50.HasValue)
                    return purge_counter_50.ToString();
                else
                    return "null";
            }
        }
        #endregion
        #region LastDepositAt
        private bool last_deposit_atChanged = false;
        private DateTime last_deposit_at;
        public DateTime LastDepositAt
        {
            get { return last_deposit_at; }
            set
            {
                last_deposit_at = value;
                last_deposit_atChanged = true;
            }
        }
        private string last_deposit_atDbString
        {
            get
            {
                return string.Format("Convert(datetime,'{0}',121)", last_deposit_at.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }
        #endregion
        #region AtmId
        private bool atm_idChanged = false;
        private int atm_id;
        public int AtmId
        {
            get { return atm_id; }
            set
            {
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
        #region TaskId
        private bool task_idChanged = false;
        private int task_id;
        public int TaskId
        {
            get { return task_id; }
            set
            {
                task_id = value;
                task_idChanged = true;
            }
        }
        private string task_idDbString
        {
            get
            {
                return task_id.ToString();
            }
        }
        #endregion
        #region Cassette1DenominationDetail
        private bool cassette1_denomination_detailChanged = false;
        private string cassette1_denomination_detail;
        public string Cassette1DenominationDetail
        {
            get { return cassette1_denomination_detail; }
            set
            {
                cassette1_denomination_detail = value;
                cassette1_denomination_detailChanged = true;
            }
        }
        private string cassette1_denomination_detailDbString
        {
            get
            {
                if (this.cassette1_denomination_detail != null)
                    return string.Format("'{0}'", cassette1_denomination_detail);
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette2DenominationDetail
        private bool cassette2_denomination_detailChanged = false;
        private string cassette2_denomination_detail;
        public string Cassette2DenominationDetail
        {
            get { return cassette2_denomination_detail; }
            set
            {
                cassette2_denomination_detail = value;
                cassette2_denomination_detailChanged = true;
            }
        }
        private string cassette2_denomination_detailDbString
        {
            get
            {
                if (this.cassette2_denomination_detail != null)
                    return string.Format("'{0}'", cassette2_denomination_detail);
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette3DenominationDetail
        private bool cassette3_denomination_detailChanged = false;
        private string cassette3_denomination_detail;
        public string Cassette3DenominationDetail
        {
            get { return cassette3_denomination_detail; }
            set
            {
                cassette3_denomination_detail = value;
                cassette3_denomination_detailChanged = true;
            }
        }
        private string cassette3_denomination_detailDbString
        {
            get
            {
                if (this.cassette3_denomination_detail != null)
                    return string.Format("'{0}'", cassette3_denomination_detail);
                else
                    return "null";
            }
        }
        #endregion
        #region Cassette4DenominationDetail
        private bool cassette4_denomination_detailChanged = false;
        private string cassette4_denomination_detail;
        public string Cassette4DenominationDetail
        {
            get { return cassette4_denomination_detail; }
            set
            {
                cassette4_denomination_detail = value;
                cassette4_denomination_detailChanged = true;
            }
        }
        private string cassette4_denomination_detailDbString
        {
            get
            {
                if (this.cassette4_denomination_detail != null)
                    return string.Format("'{0}'", cassette4_denomination_detail);
                else
                    return "null";
            }
        }
        #endregion
        #region PurgeDenominationDetail
        private bool purge_denomination_detailChanged = false;
        private string purge_denomination_detail;
        public string PurgeDenominationDetail
        {
            get { return purge_denomination_detail; }
            set
            {
                purge_denomination_detail = value;
                purge_denomination_detailChanged = true;
            }
        }
        private string purge_denomination_detailDbString
        {
            get
            {
                if (this.purge_denomination_detail != null)
                    return string.Format("'{0}'", purge_denomination_detail);
                else
                    return "null";
            }
        }
        #endregion
        #endregion

        #region ParsedBnaCounterReader
        public class ParsedBnaCounterReader : IEntityReader, IEnumerator, IEnumerable
        {
            IDataReader reader;
            IDbConnection conn;
            ParsedBnaCounter currentParsedBnaCounter;
            Columns columns;
            bool partialRead = false;
            private ParsedBnaCounterReader() { }
            /// 
            ///
            ///

            /// 
            /// so that it can close connection on ATMReader.Close()
            public ParsedBnaCounterReader(IDataReader reader, IDbConnection conn)
            {
                this.reader = reader;
                this.conn = conn;
            }
            public ParsedBnaCounterReader(IDataReader reader, IDbConnection conn, Columns columns)
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
                get { return currentParsedBnaCounter; }

            }
            public void Close()
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
                    currentParsedBnaCounter = new ParsedBnaCounter();
                    {
                        if (reader["parsed_bna_counter_id"] != DBNull.Value)
                            currentParsedBnaCounter.parsed_bna_counter_id = (int)reader["parsed_bna_counter_id"];
                        if (reader["cassette1_counter_1"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_1 = (int?)reader["cassette1_counter_1"];
                        if (reader["cassette1_counter_2"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_2 = (int?)reader["cassette1_counter_2"];
                        if (reader["cassette1_counter_3"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_3 = (int?)reader["cassette1_counter_3"];
                        if (reader["cassette1_counter_4"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_4 = (int?)reader["cassette1_counter_4"];
                        if (reader["cassette1_counter_5"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_5 = (int?)reader["cassette1_counter_5"];
                        if (reader["cassette1_counter_6"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_6 = (int?)reader["cassette1_counter_6"];
                        if (reader["cassette1_counter_7"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_7 = (int?)reader["cassette1_counter_7"];
                        if (reader["cassette1_counter_8"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_8 = (int?)reader["cassette1_counter_8"];
                        if (reader["cassette1_counter_9"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_9 = (int?)reader["cassette1_counter_9"];
                        if (reader["cassette1_counter_10"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_10 = (int?)reader["cassette1_counter_10"];
                        if (reader["cassette1_counter_11"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_11 = (int?)reader["cassette1_counter_11"];
                        if (reader["cassette1_counter_12"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_12 = (int?)reader["cassette1_counter_12"];
                        if (reader["cassette1_counter_13"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_13 = (int?)reader["cassette1_counter_13"];
                        if (reader["cassette1_counter_14"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_14 = (int?)reader["cassette1_counter_14"];
                        if (reader["cassette1_counter_15"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_15 = (int?)reader["cassette1_counter_15"];
                        if (reader["cassette1_counter_16"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_16 = (int?)reader["cassette1_counter_16"];
                        if (reader["cassette1_counter_17"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_17 = (int?)reader["cassette1_counter_17"];
                        if (reader["cassette1_counter_18"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_18 = (int?)reader["cassette1_counter_18"];
                        if (reader["cassette1_counter_19"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_19 = (int?)reader["cassette1_counter_19"];
                        if (reader["cassette1_counter_20"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_20 = (int?)reader["cassette1_counter_20"];
                        if (reader["cassette1_counter_21"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_21 = (int?)reader["cassette1_counter_21"];
                        if (reader["cassette1_counter_22"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_22 = (int?)reader["cassette1_counter_22"];
                        if (reader["cassette1_counter_23"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_23 = (int?)reader["cassette1_counter_23"];
                        if (reader["cassette1_counter_24"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_24 = (int?)reader["cassette1_counter_24"];
                        if (reader["cassette1_counter_25"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_25 = (int?)reader["cassette1_counter_25"];
                        if (reader["cassette1_counter_26"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_26 = (int?)reader["cassette1_counter_26"];
                        if (reader["cassette1_counter_27"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_27 = (int?)reader["cassette1_counter_27"];
                        if (reader["cassette1_counter_28"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_28 = (int?)reader["cassette1_counter_28"];
                        if (reader["cassette1_counter_29"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_29 = (int?)reader["cassette1_counter_29"];
                        if (reader["cassette1_counter_30"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_30 = (int?)reader["cassette1_counter_30"];
                        if (reader["cassette1_counter_31"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_31 = (int?)reader["cassette1_counter_31"];
                        if (reader["cassette1_counter_32"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_32 = (int?)reader["cassette1_counter_32"];
                        if (reader["cassette1_counter_33"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_33 = (int?)reader["cassette1_counter_33"];
                        if (reader["cassette1_counter_34"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_34 = (int?)reader["cassette1_counter_34"];
                        if (reader["cassette1_counter_35"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_35 = (int?)reader["cassette1_counter_35"];
                        if (reader["cassette1_counter_36"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_36 = (int?)reader["cassette1_counter_36"];
                        if (reader["cassette1_counter_37"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_37 = (int?)reader["cassette1_counter_37"];
                        if (reader["cassette1_counter_38"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_38 = (int?)reader["cassette1_counter_38"];
                        if (reader["cassette1_counter_39"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_39 = (int?)reader["cassette1_counter_39"];
                        if (reader["cassette1_counter_40"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_40 = (int?)reader["cassette1_counter_40"];
                        if (reader["cassette1_counter_41"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_41 = (int?)reader["cassette1_counter_41"];
                        if (reader["cassette1_counter_42"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_42 = (int?)reader["cassette1_counter_42"];
                        if (reader["cassette1_counter_43"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_43 = (int?)reader["cassette1_counter_43"];
                        if (reader["cassette1_counter_44"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_44 = (int?)reader["cassette1_counter_44"];
                        if (reader["cassette1_counter_45"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_45 = (int?)reader["cassette1_counter_45"];
                        if (reader["cassette1_counter_46"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_46 = (int?)reader["cassette1_counter_46"];
                        if (reader["cassette1_counter_47"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_47 = (int?)reader["cassette1_counter_47"];
                        if (reader["cassette1_counter_48"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_48 = (int?)reader["cassette1_counter_48"];
                        if (reader["cassette1_counter_49"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_49 = (int?)reader["cassette1_counter_49"];
                        if (reader["cassette1_counter_50"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_counter_50 = (int?)reader["cassette1_counter_50"];
                        if (reader["cassette2_counter_1"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_1 = (int?)reader["cassette2_counter_1"];
                        if (reader["cassette2_counter_2"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_2 = (int?)reader["cassette2_counter_2"];
                        if (reader["cassette2_counter_3"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_3 = (int?)reader["cassette2_counter_3"];
                        if (reader["cassette2_counter_4"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_4 = (int?)reader["cassette2_counter_4"];
                        if (reader["cassette2_counter_5"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_5 = (int?)reader["cassette2_counter_5"];
                        if (reader["cassette2_counter_6"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_6 = (int?)reader["cassette2_counter_6"];
                        if (reader["cassette2_counter_7"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_7 = (int?)reader["cassette2_counter_7"];
                        if (reader["cassette2_counter_8"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_8 = (int?)reader["cassette2_counter_8"];
                        if (reader["cassette2_counter_9"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_9 = (int?)reader["cassette2_counter_9"];
                        if (reader["cassette2_counter_10"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_10 = (int?)reader["cassette2_counter_10"];
                        if (reader["cassette2_counter_11"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_11 = (int?)reader["cassette2_counter_11"];
                        if (reader["cassette2_counter_12"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_12 = (int?)reader["cassette2_counter_12"];
                        if (reader["cassette2_counter_13"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_13 = (int?)reader["cassette2_counter_13"];
                        if (reader["cassette2_counter_14"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_14 = (int?)reader["cassette2_counter_14"];
                        if (reader["cassette2_counter_15"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_15 = (int?)reader["cassette2_counter_15"];
                        if (reader["cassette2_counter_16"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_16 = (int?)reader["cassette2_counter_16"];
                        if (reader["cassette2_counter_17"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_17 = (int?)reader["cassette2_counter_17"];
                        if (reader["cassette2_counter_18"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_18 = (int?)reader["cassette2_counter_18"];
                        if (reader["cassette2_counter_19"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_19 = (int?)reader["cassette2_counter_19"];
                        if (reader["cassette2_counter_20"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_20 = (int?)reader["cassette2_counter_20"];
                        if (reader["cassette2_counter_21"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_21 = (int?)reader["cassette2_counter_21"];
                        if (reader["cassette2_counter_22"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_22 = (int?)reader["cassette2_counter_22"];
                        if (reader["cassette2_counter_23"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_23 = (int?)reader["cassette2_counter_23"];
                        if (reader["cassette2_counter_24"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_24 = (int?)reader["cassette2_counter_24"];
                        if (reader["cassette2_counter_25"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_25 = (int?)reader["cassette2_counter_25"];
                        if (reader["cassette2_counter_26"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_26 = (int?)reader["cassette2_counter_26"];
                        if (reader["cassette2_counter_27"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_27 = (int?)reader["cassette2_counter_27"];
                        if (reader["cassette2_counter_28"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_28 = (int?)reader["cassette2_counter_28"];
                        if (reader["cassette2_counter_29"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_29 = (int?)reader["cassette2_counter_29"];
                        if (reader["cassette2_counter_30"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_30 = (int?)reader["cassette2_counter_30"];
                        if (reader["cassette2_counter_31"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_31 = (int?)reader["cassette2_counter_31"];
                        if (reader["cassette2_counter_32"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_32 = (int?)reader["cassette2_counter_32"];
                        if (reader["cassette2_counter_33"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_33 = (int?)reader["cassette2_counter_33"];
                        if (reader["cassette2_counter_34"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_34 = (int?)reader["cassette2_counter_34"];
                        if (reader["cassette2_counter_35"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_35 = (int?)reader["cassette2_counter_35"];
                        if (reader["cassette2_counter_36"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_36 = (int?)reader["cassette2_counter_36"];
                        if (reader["cassette2_counter_37"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_37 = (int?)reader["cassette2_counter_37"];
                        if (reader["cassette2_counter_38"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_38 = (int?)reader["cassette2_counter_38"];
                        if (reader["cassette2_counter_39"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_39 = (int?)reader["cassette2_counter_39"];
                        if (reader["cassette2_counter_40"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_40 = (int?)reader["cassette2_counter_40"];
                        if (reader["cassette2_counter_41"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_41 = (int?)reader["cassette2_counter_41"];
                        if (reader["cassette2_counter_42"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_42 = (int?)reader["cassette2_counter_42"];
                        if (reader["cassette2_counter_43"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_43 = (int?)reader["cassette2_counter_43"];
                        if (reader["cassette2_counter_44"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_44 = (int?)reader["cassette2_counter_44"];
                        if (reader["cassette2_counter_45"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_45 = (int?)reader["cassette2_counter_45"];
                        if (reader["cassette2_counter_46"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_46 = (int?)reader["cassette2_counter_46"];
                        if (reader["cassette2_counter_47"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_47 = (int?)reader["cassette2_counter_47"];
                        if (reader["cassette2_counter_48"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_48 = (int?)reader["cassette2_counter_48"];
                        if (reader["cassette2_counter_49"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_49 = (int?)reader["cassette2_counter_49"];
                        if (reader["cassette2_counter_50"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_counter_50 = (int?)reader["cassette2_counter_50"];
                        if (reader["cassette3_counter_1"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_1 = (int?)reader["cassette3_counter_1"];
                        if (reader["cassette3_counter_2"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_2 = (int?)reader["cassette3_counter_2"];
                        if (reader["cassette3_counter_3"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_3 = (int?)reader["cassette3_counter_3"];
                        if (reader["cassette3_counter_4"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_4 = (int?)reader["cassette3_counter_4"];
                        if (reader["cassette3_counter_5"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_5 = (int?)reader["cassette3_counter_5"];
                        if (reader["cassette3_counter_6"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_6 = (int?)reader["cassette3_counter_6"];
                        if (reader["cassette3_counter_7"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_7 = (int?)reader["cassette3_counter_7"];
                        if (reader["cassette3_counter_8"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_8 = (int?)reader["cassette3_counter_8"];
                        if (reader["cassette3_counter_9"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_9 = (int?)reader["cassette3_counter_9"];
                        if (reader["cassette3_counter_10"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_10 = (int?)reader["cassette3_counter_10"];
                        if (reader["cassette3_counter_11"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_11 = (int?)reader["cassette3_counter_11"];
                        if (reader["cassette3_counter_12"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_12 = (int?)reader["cassette3_counter_12"];
                        if (reader["cassette3_counter_13"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_13 = (int?)reader["cassette3_counter_13"];
                        if (reader["cassette3_counter_14"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_14 = (int?)reader["cassette3_counter_14"];
                        if (reader["cassette3_counter_15"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_15 = (int?)reader["cassette3_counter_15"];
                        if (reader["cassette3_counter_16"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_16 = (int?)reader["cassette3_counter_16"];
                        if (reader["cassette3_counter_17"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_17 = (int?)reader["cassette3_counter_17"];
                        if (reader["cassette3_counter_18"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_18 = (int?)reader["cassette3_counter_18"];
                        if (reader["cassette3_counter_19"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_19 = (int?)reader["cassette3_counter_19"];
                        if (reader["cassette3_counter_20"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_20 = (int?)reader["cassette3_counter_20"];
                        if (reader["cassette3_counter_21"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_21 = (int?)reader["cassette3_counter_21"];
                        if (reader["cassette3_counter_22"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_22 = (int?)reader["cassette3_counter_22"];
                        if (reader["cassette3_counter_23"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_23 = (int?)reader["cassette3_counter_23"];
                        if (reader["cassette3_counter_24"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_24 = (int?)reader["cassette3_counter_24"];
                        if (reader["cassette3_counter_25"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_25 = (int?)reader["cassette3_counter_25"];
                        if (reader["cassette3_counter_26"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_26 = (int?)reader["cassette3_counter_26"];
                        if (reader["cassette3_counter_27"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_27 = (int?)reader["cassette3_counter_27"];
                        if (reader["cassette3_counter_28"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_28 = (int?)reader["cassette3_counter_28"];
                        if (reader["cassette3_counter_29"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_29 = (int?)reader["cassette3_counter_29"];
                        if (reader["cassette3_counter_30"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_30 = (int?)reader["cassette3_counter_30"];
                        if (reader["cassette3_counter_31"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_31 = (int?)reader["cassette3_counter_31"];
                        if (reader["cassette3_counter_32"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_32 = (int?)reader["cassette3_counter_32"];
                        if (reader["cassette3_counter_33"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_33 = (int?)reader["cassette3_counter_33"];
                        if (reader["cassette3_counter_34"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_34 = (int?)reader["cassette3_counter_34"];
                        if (reader["cassette3_counter_35"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_35 = (int?)reader["cassette3_counter_35"];
                        if (reader["cassette3_counter_36"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_36 = (int?)reader["cassette3_counter_36"];
                        if (reader["cassette3_counter_37"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_37 = (int?)reader["cassette3_counter_37"];
                        if (reader["cassette3_counter_38"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_38 = (int?)reader["cassette3_counter_38"];
                        if (reader["cassette3_counter_39"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_39 = (int?)reader["cassette3_counter_39"];
                        if (reader["cassette3_counter_40"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_40 = (int?)reader["cassette3_counter_40"];
                        if (reader["cassette3_counter_41"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_41 = (int?)reader["cassette3_counter_41"];
                        if (reader["cassette3_counter_42"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_42 = (int?)reader["cassette3_counter_42"];
                        if (reader["cassette3_counter_43"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_43 = (int?)reader["cassette3_counter_43"];
                        if (reader["cassette3_counter_44"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_44 = (int?)reader["cassette3_counter_44"];
                        if (reader["cassette3_counter_45"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_45 = (int?)reader["cassette3_counter_45"];
                        if (reader["cassette3_counter_46"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_46 = (int?)reader["cassette3_counter_46"];
                        if (reader["cassette3_counter_47"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_47 = (int?)reader["cassette3_counter_47"];
                        if (reader["cassette3_counter_48"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_48 = (int?)reader["cassette3_counter_48"];
                        if (reader["cassette3_counter_49"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_49 = (int?)reader["cassette3_counter_49"];
                        if (reader["cassette3_counter_50"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_counter_50 = (int?)reader["cassette3_counter_50"];
                        if (reader["cassette4_counter_1"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_1 = (int?)reader["cassette4_counter_1"];
                        if (reader["cassette4_counter_2"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_2 = (int?)reader["cassette4_counter_2"];
                        if (reader["cassette4_counter_3"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_3 = (int?)reader["cassette4_counter_3"];
                        if (reader["cassette4_counter_4"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_4 = (int?)reader["cassette4_counter_4"];
                        if (reader["cassette4_counter_5"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_5 = (int?)reader["cassette4_counter_5"];
                        if (reader["cassette4_counter_6"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_6 = (int?)reader["cassette4_counter_6"];
                        if (reader["cassette4_counter_7"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_7 = (int?)reader["cassette4_counter_7"];
                        if (reader["cassette4_counter_8"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_8 = (int?)reader["cassette4_counter_8"];
                        if (reader["cassette4_counter_9"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_9 = (int?)reader["cassette4_counter_9"];
                        if (reader["cassette4_counter_10"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_10 = (int?)reader["cassette4_counter_10"];
                        if (reader["cassette4_counter_11"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_11 = (int?)reader["cassette4_counter_11"];
                        if (reader["cassette4_counter_12"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_12 = (int?)reader["cassette4_counter_12"];
                        if (reader["cassette4_counter_13"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_13 = (int?)reader["cassette4_counter_13"];
                        if (reader["cassette4_counter_14"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_14 = (int?)reader["cassette4_counter_14"];
                        if (reader["cassette4_counter_15"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_15 = (int?)reader["cassette4_counter_15"];
                        if (reader["cassette4_counter_16"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_16 = (int?)reader["cassette4_counter_16"];
                        if (reader["cassette4_counter_17"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_17 = (int?)reader["cassette4_counter_17"];
                        if (reader["cassette4_counter_18"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_18 = (int?)reader["cassette4_counter_18"];
                        if (reader["cassette4_counter_19"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_19 = (int?)reader["cassette4_counter_19"];
                        if (reader["cassette4_counter_20"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_20 = (int?)reader["cassette4_counter_20"];
                        if (reader["cassette4_counter_21"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_21 = (int?)reader["cassette4_counter_21"];
                        if (reader["cassette4_counter_22"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_22 = (int?)reader["cassette4_counter_22"];
                        if (reader["cassette4_counter_23"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_23 = (int?)reader["cassette4_counter_23"];
                        if (reader["cassette4_counter_24"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_24 = (int?)reader["cassette4_counter_24"];
                        if (reader["cassette4_counter_25"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_25 = (int?)reader["cassette4_counter_25"];
                        if (reader["cassette4_counter_26"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_26 = (int?)reader["cassette4_counter_26"];
                        if (reader["cassette4_counter_27"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_27 = (int?)reader["cassette4_counter_27"];
                        if (reader["cassette4_counter_28"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_28 = (int?)reader["cassette4_counter_28"];
                        if (reader["cassette4_counter_29"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_29 = (int?)reader["cassette4_counter_29"];
                        if (reader["cassette4_counter_30"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_30 = (int?)reader["cassette4_counter_30"];
                        if (reader["cassette4_counter_31"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_31 = (int?)reader["cassette4_counter_31"];
                        if (reader["cassette4_counter_32"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_32 = (int?)reader["cassette4_counter_32"];
                        if (reader["cassette4_counter_33"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_33 = (int?)reader["cassette4_counter_33"];
                        if (reader["cassette4_counter_34"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_34 = (int?)reader["cassette4_counter_34"];
                        if (reader["cassette4_counter_35"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_35 = (int?)reader["cassette4_counter_35"];
                        if (reader["cassette4_counter_36"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_36 = (int?)reader["cassette4_counter_36"];
                        if (reader["cassette4_counter_37"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_37 = (int?)reader["cassette4_counter_37"];
                        if (reader["cassette4_counter_38"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_38 = (int?)reader["cassette4_counter_38"];
                        if (reader["cassette4_counter_39"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_39 = (int?)reader["cassette4_counter_39"];
                        if (reader["cassette4_counter_40"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_40 = (int?)reader["cassette4_counter_40"];
                        if (reader["cassette4_counter_41"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_41 = (int?)reader["cassette4_counter_41"];
                        if (reader["cassette4_counter_42"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_42 = (int?)reader["cassette4_counter_42"];
                        if (reader["cassette4_counter_43"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_43 = (int?)reader["cassette4_counter_43"];
                        if (reader["cassette4_counter_44"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_44 = (int?)reader["cassette4_counter_44"];
                        if (reader["cassette4_counter_45"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_45 = (int?)reader["cassette4_counter_45"];
                        if (reader["cassette4_counter_46"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_46 = (int?)reader["cassette4_counter_46"];
                        if (reader["cassette4_counter_47"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_47 = (int?)reader["cassette4_counter_47"];
                        if (reader["cassette4_counter_48"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_48 = (int?)reader["cassette4_counter_48"];
                        if (reader["cassette4_counter_49"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_49 = (int?)reader["cassette4_counter_49"];
                        if (reader["cassette4_counter_50"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_counter_50 = (int?)reader["cassette4_counter_50"];
                        if (reader["purge_counter_1"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_1 = (int?)reader["purge_counter_1"];
                        if (reader["purge_counter_2"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_2 = (int?)reader["purge_counter_2"];
                        if (reader["purge_counter_3"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_3 = (int?)reader["purge_counter_3"];
                        if (reader["purge_counter_4"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_4 = (int?)reader["purge_counter_4"];
                        if (reader["purge_counter_5"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_5 = (int?)reader["purge_counter_5"];
                        if (reader["purge_counter_6"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_6 = (int?)reader["purge_counter_6"];
                        if (reader["purge_counter_7"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_7 = (int?)reader["purge_counter_7"];
                        if (reader["purge_counter_8"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_8 = (int?)reader["purge_counter_8"];
                        if (reader["purge_counter_9"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_9 = (int?)reader["purge_counter_9"];
                        if (reader["purge_counter_10"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_10 = (int?)reader["purge_counter_10"];
                        if (reader["purge_counter_11"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_11 = (int?)reader["purge_counter_11"];
                        if (reader["purge_counter_12"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_12 = (int?)reader["purge_counter_12"];
                        if (reader["purge_counter_13"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_13 = (int?)reader["purge_counter_13"];
                        if (reader["purge_counter_14"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_14 = (int?)reader["purge_counter_14"];
                        if (reader["purge_counter_15"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_15 = (int?)reader["purge_counter_15"];
                        if (reader["purge_counter_16"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_16 = (int?)reader["purge_counter_16"];
                        if (reader["purge_counter_17"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_17 = (int?)reader["purge_counter_17"];
                        if (reader["purge_counter_18"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_18 = (int?)reader["purge_counter_18"];
                        if (reader["purge_counter_19"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_19 = (int?)reader["purge_counter_19"];
                        if (reader["purge_counter_20"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_20 = (int?)reader["purge_counter_20"];
                        if (reader["purge_counter_21"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_21 = (int?)reader["purge_counter_21"];
                        if (reader["purge_counter_22"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_22 = (int?)reader["purge_counter_22"];
                        if (reader["purge_counter_23"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_23 = (int?)reader["purge_counter_23"];
                        if (reader["purge_counter_24"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_24 = (int?)reader["purge_counter_24"];
                        if (reader["purge_counter_25"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_25 = (int?)reader["purge_counter_25"];
                        if (reader["purge_counter_26"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_26 = (int?)reader["purge_counter_26"];
                        if (reader["purge_counter_27"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_27 = (int?)reader["purge_counter_27"];
                        if (reader["purge_counter_28"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_28 = (int?)reader["purge_counter_28"];
                        if (reader["purge_counter_29"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_29 = (int?)reader["purge_counter_29"];
                        if (reader["purge_counter_30"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_30 = (int?)reader["purge_counter_30"];
                        if (reader["purge_counter_31"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_31 = (int?)reader["purge_counter_31"];
                        if (reader["purge_counter_32"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_32 = (int?)reader["purge_counter_32"];
                        if (reader["purge_counter_33"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_33 = (int?)reader["purge_counter_33"];
                        if (reader["purge_counter_34"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_34 = (int?)reader["purge_counter_34"];
                        if (reader["purge_counter_35"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_35 = (int?)reader["purge_counter_35"];
                        if (reader["purge_counter_36"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_36 = (int?)reader["purge_counter_36"];
                        if (reader["purge_counter_37"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_37 = (int?)reader["purge_counter_37"];
                        if (reader["purge_counter_38"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_38 = (int?)reader["purge_counter_38"];
                        if (reader["purge_counter_39"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_39 = (int?)reader["purge_counter_39"];
                        if (reader["purge_counter_40"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_40 = (int?)reader["purge_counter_40"];
                        if (reader["purge_counter_41"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_41 = (int?)reader["purge_counter_41"];
                        if (reader["purge_counter_42"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_42 = (int?)reader["purge_counter_42"];
                        if (reader["purge_counter_43"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_43 = (int?)reader["purge_counter_43"];
                        if (reader["purge_counter_44"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_44 = (int?)reader["purge_counter_44"];
                        if (reader["purge_counter_45"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_45 = (int?)reader["purge_counter_45"];
                        if (reader["purge_counter_46"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_46 = (int?)reader["purge_counter_46"];
                        if (reader["purge_counter_47"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_47 = (int?)reader["purge_counter_47"];
                        if (reader["purge_counter_48"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_48 = (int?)reader["purge_counter_48"];
                        if (reader["purge_counter_49"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_49 = (int?)reader["purge_counter_49"];
                        if (reader["purge_counter_50"] != DBNull.Value)
                            currentParsedBnaCounter.purge_counter_50 = (int?)reader["purge_counter_50"];
                        if (reader["last_deposit_at"] != DBNull.Value)
                            currentParsedBnaCounter.last_deposit_at = (DateTime)reader["last_deposit_at"];
                        if (reader["atm_id"] != DBNull.Value)
                            currentParsedBnaCounter.atm_id = (int)reader["atm_id"];
                        if (reader["task_id"] != DBNull.Value)
                            currentParsedBnaCounter.task_id = (int)reader["task_id"];
                        if (reader["cassette1_denomination_detail"] != DBNull.Value)
                            currentParsedBnaCounter.cassette1_denomination_detail = (string)reader["cassette1_denomination_detail"];
                        if (reader["cassette2_denomination_detail"] != DBNull.Value)
                            currentParsedBnaCounter.cassette2_denomination_detail = (string)reader["cassette2_denomination_detail"];
                        if (reader["cassette3_denomination_detail"] != DBNull.Value)
                            currentParsedBnaCounter.cassette3_denomination_detail = (string)reader["cassette3_denomination_detail"];
                        if (reader["cassette4_denomination_detail"] != DBNull.Value)
                            currentParsedBnaCounter.cassette4_denomination_detail = (string)reader["cassette4_denomination_detail"];
                        if (reader["purge_denomination_detail"] != DBNull.Value)
                            currentParsedBnaCounter.purge_denomination_detail = (string)reader["purge_denomination_detail"];
                    }

                    currentParsedBnaCounter.isNewEntity = false;
                    return true;
                }
                else
                    return false;
            }
            #region IEnumerable Members

            public IEnumerator GetEnumerator()
            {
                return this;
            }
            #endregion


            #region IEnumerator Members

            public ParsedBnaCounter CurrentParsedBnaCounter
            {
                get { return currentParsedBnaCounter; }
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


        #region ParsedBnaCounter functions

        public static ParsedBnaCounterReader ExecuteReader(string where, IDbConnection conn, Columns columns)
        {
            StringBuilder qry = new StringBuilder(200);
            qry.Append("select ");
            if (Columns.parsed_bna_counter_id == (Columns.parsed_bna_counter_id & columns))
                qry.Append("parsed_bna_counter_id,");
            if (Columns.cassette1_counter_1 == (Columns.cassette1_counter_1 & columns))
                qry.Append("cassette1_counter_1,");
            if (Columns.cassette1_counter_2 == (Columns.cassette1_counter_2 & columns))
                qry.Append("cassette1_counter_2,");
            if (Columns.cassette1_counter_3 == (Columns.cassette1_counter_3 & columns))
                qry.Append("cassette1_counter_3,");
            if (Columns.cassette1_counter_4 == (Columns.cassette1_counter_4 & columns))
                qry.Append("cassette1_counter_4,");
            if (Columns.cassette1_counter_5 == (Columns.cassette1_counter_5 & columns))
                qry.Append("cassette1_counter_5,");
            if (Columns.cassette1_counter_6 == (Columns.cassette1_counter_6 & columns))
                qry.Append("cassette1_counter_6,");
            if (Columns.cassette1_counter_7 == (Columns.cassette1_counter_7 & columns))
                qry.Append("cassette1_counter_7,");
            if (Columns.cassette1_counter_8 == (Columns.cassette1_counter_8 & columns))
                qry.Append("cassette1_counter_8,");
            if (Columns.cassette1_counter_9 == (Columns.cassette1_counter_9 & columns))
                qry.Append("cassette1_counter_9,");
            if (Columns.cassette1_counter_10 == (Columns.cassette1_counter_10 & columns))
                qry.Append("cassette1_counter_10,");
            if (Columns.cassette1_counter_11 == (Columns.cassette1_counter_11 & columns))
                qry.Append("cassette1_counter_11,");
            if (Columns.cassette1_counter_12 == (Columns.cassette1_counter_12 & columns))
                qry.Append("cassette1_counter_12,");
            if (Columns.cassette1_counter_13 == (Columns.cassette1_counter_13 & columns))
                qry.Append("cassette1_counter_13,");
            if (Columns.cassette1_counter_14 == (Columns.cassette1_counter_14 & columns))
                qry.Append("cassette1_counter_14,");
            if (Columns.cassette1_counter_15 == (Columns.cassette1_counter_15 & columns))
                qry.Append("cassette1_counter_15,");
            if (Columns.cassette1_counter_16 == (Columns.cassette1_counter_16 & columns))
                qry.Append("cassette1_counter_16,");
            if (Columns.cassette1_counter_17 == (Columns.cassette1_counter_17 & columns))
                qry.Append("cassette1_counter_17,");
            if (Columns.cassette1_counter_18 == (Columns.cassette1_counter_18 & columns))
                qry.Append("cassette1_counter_18,");
            if (Columns.cassette1_counter_19 == (Columns.cassette1_counter_19 & columns))
                qry.Append("cassette1_counter_19,");
            if (Columns.cassette1_counter_20 == (Columns.cassette1_counter_20 & columns))
                qry.Append("cassette1_counter_20,");
            if (Columns.cassette1_counter_21 == (Columns.cassette1_counter_21 & columns))
                qry.Append("cassette1_counter_21,");
            if (Columns.cassette1_counter_22 == (Columns.cassette1_counter_22 & columns))
                qry.Append("cassette1_counter_22,");
            if (Columns.cassette1_counter_23 == (Columns.cassette1_counter_23 & columns))
                qry.Append("cassette1_counter_23,");
            if (Columns.cassette1_counter_24 == (Columns.cassette1_counter_24 & columns))
                qry.Append("cassette1_counter_24,");
            if (Columns.cassette1_counter_25 == (Columns.cassette1_counter_25 & columns))
                qry.Append("cassette1_counter_25,");
            if (Columns.cassette1_counter_26 == (Columns.cassette1_counter_26 & columns))
                qry.Append("cassette1_counter_26,");
            if (Columns.cassette1_counter_27 == (Columns.cassette1_counter_27 & columns))
                qry.Append("cassette1_counter_27,");
            if (Columns.cassette1_counter_28 == (Columns.cassette1_counter_28 & columns))
                qry.Append("cassette1_counter_28,");
            if (Columns.cassette1_counter_29 == (Columns.cassette1_counter_29 & columns))
                qry.Append("cassette1_counter_29,");
            if (Columns.cassette1_counter_30 == (Columns.cassette1_counter_30 & columns))
                qry.Append("cassette1_counter_30,");
            if (Columns.cassette1_counter_31 == (Columns.cassette1_counter_31 & columns))
                qry.Append("cassette1_counter_31,");
            if (Columns.cassette1_counter_32 == (Columns.cassette1_counter_32 & columns))
                qry.Append("cassette1_counter_32,");
            if (Columns.cassette1_counter_33 == (Columns.cassette1_counter_33 & columns))
                qry.Append("cassette1_counter_33,");
            if (Columns.cassette1_counter_34 == (Columns.cassette1_counter_34 & columns))
                qry.Append("cassette1_counter_34,");
            if (Columns.cassette1_counter_35 == (Columns.cassette1_counter_35 & columns))
                qry.Append("cassette1_counter_35,");
            if (Columns.cassette1_counter_36 == (Columns.cassette1_counter_36 & columns))
                qry.Append("cassette1_counter_36,");
            if (Columns.cassette1_counter_37 == (Columns.cassette1_counter_37 & columns))
                qry.Append("cassette1_counter_37,");
            if (Columns.cassette1_counter_38 == (Columns.cassette1_counter_38 & columns))
                qry.Append("cassette1_counter_38,");
            if (Columns.cassette1_counter_39 == (Columns.cassette1_counter_39 & columns))
                qry.Append("cassette1_counter_39,");
            if (Columns.cassette1_counter_40 == (Columns.cassette1_counter_40 & columns))
                qry.Append("cassette1_counter_40,");
            if (Columns.cassette1_counter_41 == (Columns.cassette1_counter_41 & columns))
                qry.Append("cassette1_counter_41,");
            if (Columns.cassette1_counter_42 == (Columns.cassette1_counter_42 & columns))
                qry.Append("cassette1_counter_42,");
            if (Columns.cassette1_counter_43 == (Columns.cassette1_counter_43 & columns))
                qry.Append("cassette1_counter_43,");
            if (Columns.cassette1_counter_44 == (Columns.cassette1_counter_44 & columns))
                qry.Append("cassette1_counter_44,");
            if (Columns.cassette1_counter_45 == (Columns.cassette1_counter_45 & columns))
                qry.Append("cassette1_counter_45,");
            if (Columns.cassette1_counter_46 == (Columns.cassette1_counter_46 & columns))
                qry.Append("cassette1_counter_46,");
            if (Columns.cassette1_counter_47 == (Columns.cassette1_counter_47 & columns))
                qry.Append("cassette1_counter_47,");
            if (Columns.cassette1_counter_48 == (Columns.cassette1_counter_48 & columns))
                qry.Append("cassette1_counter_48,");
            if (Columns.cassette1_counter_49 == (Columns.cassette1_counter_49 & columns))
                qry.Append("cassette1_counter_49,");
            if (Columns.cassette1_counter_50 == (Columns.cassette1_counter_50 & columns))
                qry.Append("cassette1_counter_50,");
            if (Columns.cassette2_counter_1 == (Columns.cassette2_counter_1 & columns))
                qry.Append("cassette2_counter_1,");
            if (Columns.cassette2_counter_2 == (Columns.cassette2_counter_2 & columns))
                qry.Append("cassette2_counter_2,");
            if (Columns.cassette2_counter_3 == (Columns.cassette2_counter_3 & columns))
                qry.Append("cassette2_counter_3,");
            if (Columns.cassette2_counter_4 == (Columns.cassette2_counter_4 & columns))
                qry.Append("cassette2_counter_4,");
            if (Columns.cassette2_counter_5 == (Columns.cassette2_counter_5 & columns))
                qry.Append("cassette2_counter_5,");
            if (Columns.cassette2_counter_6 == (Columns.cassette2_counter_6 & columns))
                qry.Append("cassette2_counter_6,");
            if (Columns.cassette2_counter_7 == (Columns.cassette2_counter_7 & columns))
                qry.Append("cassette2_counter_7,");
            if (Columns.cassette2_counter_8 == (Columns.cassette2_counter_8 & columns))
                qry.Append("cassette2_counter_8,");
            if (Columns.cassette2_counter_9 == (Columns.cassette2_counter_9 & columns))
                qry.Append("cassette2_counter_9,");
            if (Columns.cassette2_counter_10 == (Columns.cassette2_counter_10 & columns))
                qry.Append("cassette2_counter_10,");
            if (Columns.cassette2_counter_11 == (Columns.cassette2_counter_11 & columns))
                qry.Append("cassette2_counter_11,");
            if (Columns.cassette2_counter_12 == (Columns.cassette2_counter_12 & columns))
                qry.Append("cassette2_counter_12,");
            if (Columns.cassette2_counter_13 == (Columns.cassette2_counter_13 & columns))
                qry.Append("cassette2_counter_13,");
            if (Columns.cassette2_counter_14 == (Columns.cassette2_counter_14 & columns))
                qry.Append("cassette2_counter_14,");
            if (Columns.cassette2_counter_15 == (Columns.cassette2_counter_15 & columns))
                qry.Append("cassette2_counter_15,");
            if (Columns.cassette2_counter_16 == (Columns.cassette2_counter_16 & columns))
                qry.Append("cassette2_counter_16,");
            if (Columns.cassette2_counter_17 == (Columns.cassette2_counter_17 & columns))
                qry.Append("cassette2_counter_17,");
            if (Columns.cassette2_counter_18 == (Columns.cassette2_counter_18 & columns))
                qry.Append("cassette2_counter_18,");
            if (Columns.cassette2_counter_19 == (Columns.cassette2_counter_19 & columns))
                qry.Append("cassette2_counter_19,");
            if (Columns.cassette2_counter_20 == (Columns.cassette2_counter_20 & columns))
                qry.Append("cassette2_counter_20,");
            if (Columns.cassette2_counter_21 == (Columns.cassette2_counter_21 & columns))
                qry.Append("cassette2_counter_21,");
            if (Columns.cassette2_counter_22 == (Columns.cassette2_counter_22 & columns))
                qry.Append("cassette2_counter_22,");
            if (Columns.cassette2_counter_23 == (Columns.cassette2_counter_23 & columns))
                qry.Append("cassette2_counter_23,");
            if (Columns.cassette2_counter_24 == (Columns.cassette2_counter_24 & columns))
                qry.Append("cassette2_counter_24,");
            if (Columns.cassette2_counter_25 == (Columns.cassette2_counter_25 & columns))
                qry.Append("cassette2_counter_25,");
            if (Columns.cassette2_counter_26 == (Columns.cassette2_counter_26 & columns))
                qry.Append("cassette2_counter_26,");
            if (Columns.cassette2_counter_27 == (Columns.cassette2_counter_27 & columns))
                qry.Append("cassette2_counter_27,");
            if (Columns.cassette2_counter_28 == (Columns.cassette2_counter_28 & columns))
                qry.Append("cassette2_counter_28,");
            if (Columns.cassette2_counter_29 == (Columns.cassette2_counter_29 & columns))
                qry.Append("cassette2_counter_29,");
            if (Columns.cassette2_counter_30 == (Columns.cassette2_counter_30 & columns))
                qry.Append("cassette2_counter_30,");
            if (Columns.cassette2_counter_31 == (Columns.cassette2_counter_31 & columns))
                qry.Append("cassette2_counter_31,");
            if (Columns.cassette2_counter_32 == (Columns.cassette2_counter_32 & columns))
                qry.Append("cassette2_counter_32,");
            if (Columns.cassette2_counter_33 == (Columns.cassette2_counter_33 & columns))
                qry.Append("cassette2_counter_33,");
            if (Columns.cassette2_counter_34 == (Columns.cassette2_counter_34 & columns))
                qry.Append("cassette2_counter_34,");
            if (Columns.cassette2_counter_35 == (Columns.cassette2_counter_35 & columns))
                qry.Append("cassette2_counter_35,");
            if (Columns.cassette2_counter_36 == (Columns.cassette2_counter_36 & columns))
                qry.Append("cassette2_counter_36,");
            if (Columns.cassette2_counter_37 == (Columns.cassette2_counter_37 & columns))
                qry.Append("cassette2_counter_37,");
            if (Columns.cassette2_counter_38 == (Columns.cassette2_counter_38 & columns))
                qry.Append("cassette2_counter_38,");
            if (Columns.cassette2_counter_39 == (Columns.cassette2_counter_39 & columns))
                qry.Append("cassette2_counter_39,");
            if (Columns.cassette2_counter_40 == (Columns.cassette2_counter_40 & columns))
                qry.Append("cassette2_counter_40,");
            if (Columns.cassette2_counter_41 == (Columns.cassette2_counter_41 & columns))
                qry.Append("cassette2_counter_41,");
            if (Columns.cassette2_counter_42 == (Columns.cassette2_counter_42 & columns))
                qry.Append("cassette2_counter_42,");
            if (Columns.cassette2_counter_43 == (Columns.cassette2_counter_43 & columns))
                qry.Append("cassette2_counter_43,");
            if (Columns.cassette2_counter_44 == (Columns.cassette2_counter_44 & columns))
                qry.Append("cassette2_counter_44,");
            if (Columns.cassette2_counter_45 == (Columns.cassette2_counter_45 & columns))
                qry.Append("cassette2_counter_45,");
            if (Columns.cassette2_counter_46 == (Columns.cassette2_counter_46 & columns))
                qry.Append("cassette2_counter_46,");
            if (Columns.cassette2_counter_47 == (Columns.cassette2_counter_47 & columns))
                qry.Append("cassette2_counter_47,");
            if (Columns.cassette2_counter_48 == (Columns.cassette2_counter_48 & columns))
                qry.Append("cassette2_counter_48,");
            if (Columns.cassette2_counter_49 == (Columns.cassette2_counter_49 & columns))
                qry.Append("cassette2_counter_49,");
            if (Columns.cassette2_counter_50 == (Columns.cassette2_counter_50 & columns))
                qry.Append("cassette2_counter_50,");
            if (Columns.cassette3_counter_1 == (Columns.cassette3_counter_1 & columns))
                qry.Append("cassette3_counter_1,");
            if (Columns.cassette3_counter_2 == (Columns.cassette3_counter_2 & columns))
                qry.Append("cassette3_counter_2,");
            if (Columns.cassette3_counter_3 == (Columns.cassette3_counter_3 & columns))
                qry.Append("cassette3_counter_3,");
            if (Columns.cassette3_counter_4 == (Columns.cassette3_counter_4 & columns))
                qry.Append("cassette3_counter_4,");
            if (Columns.cassette3_counter_5 == (Columns.cassette3_counter_5 & columns))
                qry.Append("cassette3_counter_5,");
            if (Columns.cassette3_counter_6 == (Columns.cassette3_counter_6 & columns))
                qry.Append("cassette3_counter_6,");
            if (Columns.cassette3_counter_7 == (Columns.cassette3_counter_7 & columns))
                qry.Append("cassette3_counter_7,");
            if (Columns.cassette3_counter_8 == (Columns.cassette3_counter_8 & columns))
                qry.Append("cassette3_counter_8,");
            if (Columns.cassette3_counter_9 == (Columns.cassette3_counter_9 & columns))
                qry.Append("cassette3_counter_9,");
            if (Columns.cassette3_counter_10 == (Columns.cassette3_counter_10 & columns))
                qry.Append("cassette3_counter_10,");
            if (Columns.cassette3_counter_11 == (Columns.cassette3_counter_11 & columns))
                qry.Append("cassette3_counter_11,");
            if (Columns.cassette3_counter_12 == (Columns.cassette3_counter_12 & columns))
                qry.Append("cassette3_counter_12,");
            if (Columns.cassette3_counter_13 == (Columns.cassette3_counter_13 & columns))
                qry.Append("cassette3_counter_13,");
            if (Columns.cassette3_counter_14 == (Columns.cassette3_counter_14 & columns))
                qry.Append("cassette3_counter_14,");
            if (Columns.cassette3_counter_15 == (Columns.cassette3_counter_15 & columns))
                qry.Append("cassette3_counter_15,");
            if (Columns.cassette3_counter_16 == (Columns.cassette3_counter_16 & columns))
                qry.Append("cassette3_counter_16,");
            if (Columns.cassette3_counter_17 == (Columns.cassette3_counter_17 & columns))
                qry.Append("cassette3_counter_17,");
            if (Columns.cassette3_counter_18 == (Columns.cassette3_counter_18 & columns))
                qry.Append("cassette3_counter_18,");
            if (Columns.cassette3_counter_19 == (Columns.cassette3_counter_19 & columns))
                qry.Append("cassette3_counter_19,");
            if (Columns.cassette3_counter_20 == (Columns.cassette3_counter_20 & columns))
                qry.Append("cassette3_counter_20,");
            if (Columns.cassette3_counter_21 == (Columns.cassette3_counter_21 & columns))
                qry.Append("cassette3_counter_21,");
            if (Columns.cassette3_counter_22 == (Columns.cassette3_counter_22 & columns))
                qry.Append("cassette3_counter_22,");
            if (Columns.cassette3_counter_23 == (Columns.cassette3_counter_23 & columns))
                qry.Append("cassette3_counter_23,");
            if (Columns.cassette3_counter_24 == (Columns.cassette3_counter_24 & columns))
                qry.Append("cassette3_counter_24,");
            if (Columns.cassette3_counter_25 == (Columns.cassette3_counter_25 & columns))
                qry.Append("cassette3_counter_25,");
            if (Columns.cassette3_counter_26 == (Columns.cassette3_counter_26 & columns))
                qry.Append("cassette3_counter_26,");
            if (Columns.cassette3_counter_27 == (Columns.cassette3_counter_27 & columns))
                qry.Append("cassette3_counter_27,");
            if (Columns.cassette3_counter_28 == (Columns.cassette3_counter_28 & columns))
                qry.Append("cassette3_counter_28,");
            if (Columns.cassette3_counter_29 == (Columns.cassette3_counter_29 & columns))
                qry.Append("cassette3_counter_29,");
            if (Columns.cassette3_counter_30 == (Columns.cassette3_counter_30 & columns))
                qry.Append("cassette3_counter_30,");
            if (Columns.cassette3_counter_31 == (Columns.cassette3_counter_31 & columns))
                qry.Append("cassette3_counter_31,");
            if (Columns.cassette3_counter_32 == (Columns.cassette3_counter_32 & columns))
                qry.Append("cassette3_counter_32,");
            if (Columns.cassette3_counter_33 == (Columns.cassette3_counter_33 & columns))
                qry.Append("cassette3_counter_33,");
            if (Columns.cassette3_counter_34 == (Columns.cassette3_counter_34 & columns))
                qry.Append("cassette3_counter_34,");
            if (Columns.cassette3_counter_35 == (Columns.cassette3_counter_35 & columns))
                qry.Append("cassette3_counter_35,");
            if (Columns.cassette3_counter_36 == (Columns.cassette3_counter_36 & columns))
                qry.Append("cassette3_counter_36,");
            if (Columns.cassette3_counter_37 == (Columns.cassette3_counter_37 & columns))
                qry.Append("cassette3_counter_37,");
            if (Columns.cassette3_counter_38 == (Columns.cassette3_counter_38 & columns))
                qry.Append("cassette3_counter_38,");
            if (Columns.cassette3_counter_39 == (Columns.cassette3_counter_39 & columns))
                qry.Append("cassette3_counter_39,");
            if (Columns.cassette3_counter_40 == (Columns.cassette3_counter_40 & columns))
                qry.Append("cassette3_counter_40,");
            if (Columns.cassette3_counter_41 == (Columns.cassette3_counter_41 & columns))
                qry.Append("cassette3_counter_41,");
            if (Columns.cassette3_counter_42 == (Columns.cassette3_counter_42 & columns))
                qry.Append("cassette3_counter_42,");
            if (Columns.cassette3_counter_43 == (Columns.cassette3_counter_43 & columns))
                qry.Append("cassette3_counter_43,");
            if (Columns.cassette3_counter_44 == (Columns.cassette3_counter_44 & columns))
                qry.Append("cassette3_counter_44,");
            if (Columns.cassette3_counter_45 == (Columns.cassette3_counter_45 & columns))
                qry.Append("cassette3_counter_45,");
            if (Columns.cassette3_counter_46 == (Columns.cassette3_counter_46 & columns))
                qry.Append("cassette3_counter_46,");
            if (Columns.cassette3_counter_47 == (Columns.cassette3_counter_47 & columns))
                qry.Append("cassette3_counter_47,");
            if (Columns.cassette3_counter_48 == (Columns.cassette3_counter_48 & columns))
                qry.Append("cassette3_counter_48,");
            if (Columns.cassette3_counter_49 == (Columns.cassette3_counter_49 & columns))
                qry.Append("cassette3_counter_49,");
            if (Columns.cassette3_counter_50 == (Columns.cassette3_counter_50 & columns))
                qry.Append("cassette3_counter_50,");
            if (Columns.cassette4_counter_1 == (Columns.cassette4_counter_1 & columns))
                qry.Append("cassette4_counter_1,");
            if (Columns.cassette4_counter_2 == (Columns.cassette4_counter_2 & columns))
                qry.Append("cassette4_counter_2,");
            if (Columns.cassette4_counter_3 == (Columns.cassette4_counter_3 & columns))
                qry.Append("cassette4_counter_3,");
            if (Columns.cassette4_counter_4 == (Columns.cassette4_counter_4 & columns))
                qry.Append("cassette4_counter_4,");
            if (Columns.cassette4_counter_5 == (Columns.cassette4_counter_5 & columns))
                qry.Append("cassette4_counter_5,");
            if (Columns.cassette4_counter_6 == (Columns.cassette4_counter_6 & columns))
                qry.Append("cassette4_counter_6,");
            if (Columns.cassette4_counter_7 == (Columns.cassette4_counter_7 & columns))
                qry.Append("cassette4_counter_7,");
            if (Columns.cassette4_counter_8 == (Columns.cassette4_counter_8 & columns))
                qry.Append("cassette4_counter_8,");
            if (Columns.cassette4_counter_9 == (Columns.cassette4_counter_9 & columns))
                qry.Append("cassette4_counter_9,");
            if (Columns.cassette4_counter_10 == (Columns.cassette4_counter_10 & columns))
                qry.Append("cassette4_counter_10,");
            if (Columns.cassette4_counter_11 == (Columns.cassette4_counter_11 & columns))
                qry.Append("cassette4_counter_11,");
            if (Columns.cassette4_counter_12 == (Columns.cassette4_counter_12 & columns))
                qry.Append("cassette4_counter_12,");
            if (Columns.cassette4_counter_13 == (Columns.cassette4_counter_13 & columns))
                qry.Append("cassette4_counter_13,");
            if (Columns.cassette4_counter_14 == (Columns.cassette4_counter_14 & columns))
                qry.Append("cassette4_counter_14,");
            if (Columns.cassette4_counter_15 == (Columns.cassette4_counter_15 & columns))
                qry.Append("cassette4_counter_15,");
            if (Columns.cassette4_counter_16 == (Columns.cassette4_counter_16 & columns))
                qry.Append("cassette4_counter_16,");
            if (Columns.cassette4_counter_17 == (Columns.cassette4_counter_17 & columns))
                qry.Append("cassette4_counter_17,");
            if (Columns.cassette4_counter_18 == (Columns.cassette4_counter_18 & columns))
                qry.Append("cassette4_counter_18,");
            if (Columns.cassette4_counter_19 == (Columns.cassette4_counter_19 & columns))
                qry.Append("cassette4_counter_19,");
            if (Columns.cassette4_counter_20 == (Columns.cassette4_counter_20 & columns))
                qry.Append("cassette4_counter_20,");
            if (Columns.cassette4_counter_21 == (Columns.cassette4_counter_21 & columns))
                qry.Append("cassette4_counter_21,");
            if (Columns.cassette4_counter_22 == (Columns.cassette4_counter_22 & columns))
                qry.Append("cassette4_counter_22,");
            if (Columns.cassette4_counter_23 == (Columns.cassette4_counter_23 & columns))
                qry.Append("cassette4_counter_23,");
            if (Columns.cassette4_counter_24 == (Columns.cassette4_counter_24 & columns))
                qry.Append("cassette4_counter_24,");
            if (Columns.cassette4_counter_25 == (Columns.cassette4_counter_25 & columns))
                qry.Append("cassette4_counter_25,");
            if (Columns.cassette4_counter_26 == (Columns.cassette4_counter_26 & columns))
                qry.Append("cassette4_counter_26,");
            if (Columns.cassette4_counter_27 == (Columns.cassette4_counter_27 & columns))
                qry.Append("cassette4_counter_27,");
            if (Columns.cassette4_counter_28 == (Columns.cassette4_counter_28 & columns))
                qry.Append("cassette4_counter_28,");
            if (Columns.cassette4_counter_29 == (Columns.cassette4_counter_29 & columns))
                qry.Append("cassette4_counter_29,");
            if (Columns.cassette4_counter_30 == (Columns.cassette4_counter_30 & columns))
                qry.Append("cassette4_counter_30,");
            if (Columns.cassette4_counter_31 == (Columns.cassette4_counter_31 & columns))
                qry.Append("cassette4_counter_31,");
            if (Columns.cassette4_counter_32 == (Columns.cassette4_counter_32 & columns))
                qry.Append("cassette4_counter_32,");
            if (Columns.cassette4_counter_33 == (Columns.cassette4_counter_33 & columns))
                qry.Append("cassette4_counter_33,");
            if (Columns.cassette4_counter_34 == (Columns.cassette4_counter_34 & columns))
                qry.Append("cassette4_counter_34,");
            if (Columns.cassette4_counter_35 == (Columns.cassette4_counter_35 & columns))
                qry.Append("cassette4_counter_35,");
            if (Columns.cassette4_counter_36 == (Columns.cassette4_counter_36 & columns))
                qry.Append("cassette4_counter_36,");
            if (Columns.cassette4_counter_37 == (Columns.cassette4_counter_37 & columns))
                qry.Append("cassette4_counter_37,");
            if (Columns.cassette4_counter_38 == (Columns.cassette4_counter_38 & columns))
                qry.Append("cassette4_counter_38,");
            if (Columns.cassette4_counter_39 == (Columns.cassette4_counter_39 & columns))
                qry.Append("cassette4_counter_39,");
            if (Columns.cassette4_counter_40 == (Columns.cassette4_counter_40 & columns))
                qry.Append("cassette4_counter_40,");
            if (Columns.cassette4_counter_41 == (Columns.cassette4_counter_41 & columns))
                qry.Append("cassette4_counter_41,");
            if (Columns.cassette4_counter_42 == (Columns.cassette4_counter_42 & columns))
                qry.Append("cassette4_counter_42,");
            if (Columns.cassette4_counter_43 == (Columns.cassette4_counter_43 & columns))
                qry.Append("cassette4_counter_43,");
            if (Columns.cassette4_counter_44 == (Columns.cassette4_counter_44 & columns))
                qry.Append("cassette4_counter_44,");
            if (Columns.cassette4_counter_45 == (Columns.cassette4_counter_45 & columns))
                qry.Append("cassette4_counter_45,");
            if (Columns.cassette4_counter_46 == (Columns.cassette4_counter_46 & columns))
                qry.Append("cassette4_counter_46,");
            if (Columns.cassette4_counter_47 == (Columns.cassette4_counter_47 & columns))
                qry.Append("cassette4_counter_47,");
            if (Columns.cassette4_counter_48 == (Columns.cassette4_counter_48 & columns))
                qry.Append("cassette4_counter_48,");
            if (Columns.cassette4_counter_49 == (Columns.cassette4_counter_49 & columns))
                qry.Append("cassette4_counter_49,");
            if (Columns.cassette4_counter_50 == (Columns.cassette4_counter_50 & columns))
                qry.Append("cassette4_counter_50,");
            if (Columns.purge_counter_1 == (Columns.purge_counter_1 & columns))
                qry.Append("purge_counter_1,");
            if (Columns.purge_counter_2 == (Columns.purge_counter_2 & columns))
                qry.Append("purge_counter_2,");
            if (Columns.purge_counter_3 == (Columns.purge_counter_3 & columns))
                qry.Append("purge_counter_3,");
            if (Columns.purge_counter_4 == (Columns.purge_counter_4 & columns))
                qry.Append("purge_counter_4,");
            if (Columns.purge_counter_5 == (Columns.purge_counter_5 & columns))
                qry.Append("purge_counter_5,");
            if (Columns.purge_counter_6 == (Columns.purge_counter_6 & columns))
                qry.Append("purge_counter_6,");
            if (Columns.purge_counter_7 == (Columns.purge_counter_7 & columns))
                qry.Append("purge_counter_7,");
            if (Columns.purge_counter_8 == (Columns.purge_counter_8 & columns))
                qry.Append("purge_counter_8,");
            if (Columns.purge_counter_9 == (Columns.purge_counter_9 & columns))
                qry.Append("purge_counter_9,");
            if (Columns.purge_counter_10 == (Columns.purge_counter_10 & columns))
                qry.Append("purge_counter_10,");
            if (Columns.purge_counter_11 == (Columns.purge_counter_11 & columns))
                qry.Append("purge_counter_11,");
            if (Columns.purge_counter_12 == (Columns.purge_counter_12 & columns))
                qry.Append("purge_counter_12,");
            if (Columns.purge_counter_13 == (Columns.purge_counter_13 & columns))
                qry.Append("purge_counter_13,");
            if (Columns.purge_counter_14 == (Columns.purge_counter_14 & columns))
                qry.Append("purge_counter_14,");
            if (Columns.purge_counter_15 == (Columns.purge_counter_15 & columns))
                qry.Append("purge_counter_15,");
            if (Columns.purge_counter_16 == (Columns.purge_counter_16 & columns))
                qry.Append("purge_counter_16,");
            if (Columns.purge_counter_17 == (Columns.purge_counter_17 & columns))
                qry.Append("purge_counter_17,");
            if (Columns.purge_counter_18 == (Columns.purge_counter_18 & columns))
                qry.Append("purge_counter_18,");
            if (Columns.purge_counter_19 == (Columns.purge_counter_19 & columns))
                qry.Append("purge_counter_19,");
            if (Columns.purge_counter_20 == (Columns.purge_counter_20 & columns))
                qry.Append("purge_counter_20,");
            if (Columns.purge_counter_21 == (Columns.purge_counter_21 & columns))
                qry.Append("purge_counter_21,");
            if (Columns.purge_counter_22 == (Columns.purge_counter_22 & columns))
                qry.Append("purge_counter_22,");
            if (Columns.purge_counter_23 == (Columns.purge_counter_23 & columns))
                qry.Append("purge_counter_23,");
            if (Columns.purge_counter_24 == (Columns.purge_counter_24 & columns))
                qry.Append("purge_counter_24,");
            if (Columns.purge_counter_25 == (Columns.purge_counter_25 & columns))
                qry.Append("purge_counter_25,");
            if (Columns.purge_counter_26 == (Columns.purge_counter_26 & columns))
                qry.Append("purge_counter_26,");
            if (Columns.purge_counter_27 == (Columns.purge_counter_27 & columns))
                qry.Append("purge_counter_27,");
            if (Columns.purge_counter_28 == (Columns.purge_counter_28 & columns))
                qry.Append("purge_counter_28,");
            if (Columns.purge_counter_29 == (Columns.purge_counter_29 & columns))
                qry.Append("purge_counter_29,");
            if (Columns.purge_counter_30 == (Columns.purge_counter_30 & columns))
                qry.Append("purge_counter_30,");
            if (Columns.purge_counter_31 == (Columns.purge_counter_31 & columns))
                qry.Append("purge_counter_31,");
            if (Columns.purge_counter_32 == (Columns.purge_counter_32 & columns))
                qry.Append("purge_counter_32,");
            if (Columns.purge_counter_33 == (Columns.purge_counter_33 & columns))
                qry.Append("purge_counter_33,");
            if (Columns.purge_counter_34 == (Columns.purge_counter_34 & columns))
                qry.Append("purge_counter_34,");
            if (Columns.purge_counter_35 == (Columns.purge_counter_35 & columns))
                qry.Append("purge_counter_35,");
            if (Columns.purge_counter_36 == (Columns.purge_counter_36 & columns))
                qry.Append("purge_counter_36,");
            if (Columns.purge_counter_37 == (Columns.purge_counter_37 & columns))
                qry.Append("purge_counter_37,");
            if (Columns.purge_counter_38 == (Columns.purge_counter_38 & columns))
                qry.Append("purge_counter_38,");
            if (Columns.purge_counter_39 == (Columns.purge_counter_39 & columns))
                qry.Append("purge_counter_39,");
            if (Columns.purge_counter_40 == (Columns.purge_counter_40 & columns))
                qry.Append("purge_counter_40,");
            if (Columns.purge_counter_41 == (Columns.purge_counter_41 & columns))
                qry.Append("purge_counter_41,");
            if (Columns.purge_counter_42 == (Columns.purge_counter_42 & columns))
                qry.Append("purge_counter_42,");
            if (Columns.purge_counter_43 == (Columns.purge_counter_43 & columns))
                qry.Append("purge_counter_43,");
            if (Columns.purge_counter_44 == (Columns.purge_counter_44 & columns))
                qry.Append("purge_counter_44,");
            if (Columns.purge_counter_45 == (Columns.purge_counter_45 & columns))
                qry.Append("purge_counter_45,");
            if (Columns.purge_counter_46 == (Columns.purge_counter_46 & columns))
                qry.Append("purge_counter_46,");
            if (Columns.purge_counter_47 == (Columns.purge_counter_47 & columns))
                qry.Append("purge_counter_47,");
            if (Columns.purge_counter_48 == (Columns.purge_counter_48 & columns))
                qry.Append("purge_counter_48,");
            if (Columns.purge_counter_49 == (Columns.purge_counter_49 & columns))
                qry.Append("purge_counter_49,");
            if (Columns.purge_counter_50 == (Columns.purge_counter_50 & columns))
                qry.Append("purge_counter_50,");
            if (Columns.last_deposit_at == (Columns.last_deposit_at & columns))
                qry.Append("last_deposit_at,");
            if (Columns.atm_id == (Columns.atm_id & columns))
                qry.Append("atm_id,");
            if (Columns.task_id == (Columns.task_id & columns))
                qry.Append("task_id,");
            if (Columns.cassette1_denomination_detail == (Columns.cassette1_denomination_detail & columns))
                qry.Append("cassette1_denomination_detail,");
            if (Columns.cassette2_denomination_detail == (Columns.cassette2_denomination_detail & columns))
                qry.Append("cassette2_denomination_detail,");
            if (Columns.cassette3_denomination_detail == (Columns.cassette3_denomination_detail & columns))
                qry.Append("cassette3_denomination_detail,");
            if (Columns.cassette4_denomination_detail == (Columns.cassette4_denomination_detail & columns))
                qry.Append("cassette4_denomination_detail,");
            if (Columns.purge_denomination_detail == (Columns.purge_denomination_detail & columns))
                qry.Append("purge_denomination_detail,");
            qry.Replace(',', ' ', qry.Length - 1, 1);
            qry.Append("from Parsed_bna_counter ");

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
            return new ParsedBnaCounterReader(cmd.ExecuteReader(), conn, columns);
        }

        static public ParsedBnaCounterReader ExecuteReader(string where, Columns columns)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection(), columns);
        }

        /// 
        /// should be used when u have connection like in case of transaction

        /// 
        /// 
        /// 
        public static ParsedBnaCounterReader ExecuteReader(string where, IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Selectparsed_bna_counter_id,cassette1_counter_1,cassette1_counter_2,cassette1_counter_3,cassette1_counter_4,cassette1_counter_5,cassette1_counter_6,cassette1_counter_7,cassette1_counter_8,cassette1_counter_9,cassette1_counter_10,cassette1_counter_11,cassette1_counter_12,cassette1_counter_13,cassette1_counter_14,cassette1_counter_15,cassette1_counter_16,cassette1_counter_17,cassette1_counter_18,cassette1_counter_19,cassette1_counter_20,cassette1_counter_21,cassette1_counter_22,cassette1_counter_23,cassette1_counter_24,cassette1_counter_25,cassette1_counter_26,cassette1_counter_27,cassette1_counter_28,cassette1_counter_29,cassette1_counter_30,cassette1_counter_31,cassette1_counter_32,cassette1_counter_33,cassette1_counter_34,cassette1_counter_35,cassette1_counter_36,cassette1_counter_37,cassette1_counter_38,cassette1_counter_39,cassette1_counter_40,cassette1_counter_41,cassette1_counter_42,cassette1_counter_43,cassette1_counter_44,cassette1_counter_45,cassette1_counter_46,cassette1_counter_47,cassette1_counter_48,cassette1_counter_49,cassette1_counter_50,cassette2_counter_1,cassette2_counter_2,cassette2_counter_3,cassette2_counter_4,cassette2_counter_5,cassette2_counter_6,cassette2_counter_7,cassette2_counter_8,cassette2_counter_9,cassette2_counter_10,cassette2_counter_11,cassette2_counter_12,cassette2_counter_13,cassette2_counter_14,cassette2_counter_15,cassette2_counter_16,cassette2_counter_17,cassette2_counter_18,cassette2_counter_19,cassette2_counter_20,cassette2_counter_21,cassette2_counter_22,cassette2_counter_23,cassette2_counter_24,cassette2_counter_25,cassette2_counter_26,cassette2_counter_27,cassette2_counter_28,cassette2_counter_29,cassette2_counter_30,cassette2_counter_31,cassette2_counter_32,cassette2_counter_33,cassette2_counter_34,cassette2_counter_35,cassette2_counter_36,cassette2_counter_37,cassette2_counter_38,cassette2_counter_39,cassette2_counter_40,cassette2_counter_41,cassette2_counter_42,cassette2_counter_43,cassette2_counter_44,cassette2_counter_45,cassette2_counter_46,cassette2_counter_47,cassette2_counter_48,cassette2_counter_49,cassette2_counter_50,cassette3_counter_1,cassette3_counter_2,cassette3_counter_3,cassette3_counter_4,cassette3_counter_5,cassette3_counter_6,cassette3_counter_7,cassette3_counter_8,cassette3_counter_9,cassette3_counter_10,cassette3_counter_11,cassette3_counter_12,cassette3_counter_13,cassette3_counter_14,cassette3_counter_15,cassette3_counter_16,cassette3_counter_17,cassette3_counter_18,cassette3_counter_19,cassette3_counter_20,cassette3_counter_21,cassette3_counter_22,cassette3_counter_23,cassette3_counter_24,cassette3_counter_25,cassette3_counter_26,cassette3_counter_27,cassette3_counter_28,cassette3_counter_29,cassette3_counter_30,cassette3_counter_31,cassette3_counter_32,cassette3_counter_33,cassette3_counter_34,cassette3_counter_35,cassette3_counter_36,cassette3_counter_37,cassette3_counter_38,cassette3_counter_39,cassette3_counter_40,cassette3_counter_41,cassette3_counter_42,cassette3_counter_43,cassette3_counter_44,cassette3_counter_45,cassette3_counter_46,cassette3_counter_47,cassette3_counter_48,cassette3_counter_49,cassette3_counter_50,cassette4_counter_1,cassette4_counter_2,cassette4_counter_3,cassette4_counter_4,cassette4_counter_5,cassette4_counter_6,cassette4_counter_7,cassette4_counter_8,cassette4_counter_9,cassette4_counter_10,cassette4_counter_11,cassette4_counter_12,cassette4_counter_13,cassette4_counter_14,cassette4_counter_15,cassette4_counter_16,cassette4_counter_17,cassette4_counter_18,cassette4_counter_19,cassette4_counter_20,cassette4_counter_21,cassette4_counter_22,cassette4_counter_23,cassette4_counter_24,cassette4_counter_25,cassette4_counter_26,cassette4_counter_27,cassette4_counter_28,cassette4_counter_29,cassette4_counter_30,cassette4_counter_31,cassette4_counter_32,cassette4_counter_33,cassette4_counter_34,cassette4_counter_35,cassette4_counter_36,cassette4_counter_37,cassette4_counter_38,cassette4_counter_39,cassette4_counter_40,cassette4_counter_41,cassette4_counter_42,cassette4_counter_43,cassette4_counter_44,cassette4_counter_45,cassette4_counter_46,cassette4_counter_47,cassette4_counter_48,cassette4_counter_49,cassette4_counter_50,purge_counter_1,purge_counter_2,purge_counter_3,purge_counter_4,purge_counter_5,purge_counter_6,purge_counter_7,purge_counter_8,purge_counter_9,purge_counter_10,purge_counter_11,purge_counter_12,purge_counter_13,purge_counter_14,purge_counter_15,purge_counter_16,purge_counter_17,purge_counter_18,purge_counter_19,purge_counter_20,purge_counter_21,purge_counter_22,purge_counter_23,purge_counter_24,purge_counter_25,purge_counter_26,purge_counter_27,purge_counter_28,purge_counter_29,purge_counter_30,purge_counter_31,purge_counter_32,purge_counter_33,purge_counter_34,purge_counter_35,purge_counter_36,purge_counter_37,purge_counter_38,purge_counter_39,purge_counter_40,purge_counter_41,purge_counter_42,purge_counter_43,purge_counter_44,purge_counter_45,purge_counter_46,purge_counter_47,purge_counter_48,purge_counter_49,purge_counter_50,last_deposit_at,atm_id,task_id,cassette1_denomination_detail,cassette2_denomination_detail,cassette3_denomination_detail,cassette4_denomination_detail,purge_denomination_detailfrom Parsed_bna_counter ";
            if (where != null && where.Trim().Length > 0)
                cmd.CommandText = string.Format("{0} where {1}", cmd.CommandText, where);

            return new ParsedBnaCounterReader(cmd.ExecuteReader(), conn);
        }

        static public ParsedBnaCounterReader ExecuteReader(string where)
        {
            return ExecuteReader(where, ConnectionFactory.GetNewConnection());
        }

        public static ParsedBnaCounter LoadParsedBnaCounter(string where)
        {
            ParsedBnaCounterReader reader = ParsedBnaCounter.ExecuteReader(where);
            ParsedBnaCounter _parsedbnacounter = null;
            if (reader.Read())
                _parsedbnacounter = reader.CurrentParsedBnaCounter;
            reader.Close();
            return _parsedbnacounter;
        }

        public static ParsedBnaCounter LoadParsedBnaCounter(string where, IDbConnection conn)
        {
            ParsedBnaCounterReader reader = ParsedBnaCounter.ExecuteReader(where, conn);
            ParsedBnaCounter _parsedbnacounter = null;
            if (reader.Read())
                _parsedbnacounter = reader.CurrentParsedBnaCounter;
            reader.Close(false);
            return _parsedbnacounter;
        }

        public static ParsedBnaCounter LoadParsedBnaCounterByPk(int parsed_bna_counter_id)
        {
            return LoadParsedBnaCounter("parsed_bna_counter_id=" + parsed_bna_counter_id);
        }

        public static ParsedBnaCounter LoadParsedBnaCounterByPk(int parsed_bna_counter_id, IDbConnection conn)
        {
            return LoadParsedBnaCounter(" parsed_bna_counter_id=" + parsed_bna_counter_id, conn);
        }

        public void Save()
        {
            if (parsed_bna_counter_idChanged || cassette1_counter_1Changed || cassette1_counter_2Changed || cassette1_counter_3Changed || cassette1_counter_4Changed || cassette1_counter_5Changed || cassette1_counter_6Changed || cassette1_counter_7Changed || cassette1_counter_8Changed || cassette1_counter_9Changed || cassette1_counter_10Changed || cassette1_counter_11Changed || cassette1_counter_12Changed || cassette1_counter_13Changed || cassette1_counter_14Changed || cassette1_counter_15Changed || cassette1_counter_16Changed || cassette1_counter_17Changed || cassette1_counter_18Changed || cassette1_counter_19Changed || cassette1_counter_20Changed || cassette1_counter_21Changed || cassette1_counter_22Changed || cassette1_counter_23Changed || cassette1_counter_24Changed || cassette1_counter_25Changed || cassette1_counter_26Changed || cassette1_counter_27Changed || cassette1_counter_28Changed || cassette1_counter_29Changed || cassette1_counter_30Changed || cassette1_counter_31Changed || cassette1_counter_32Changed || cassette1_counter_33Changed || cassette1_counter_34Changed || cassette1_counter_35Changed || cassette1_counter_36Changed || cassette1_counter_37Changed || cassette1_counter_38Changed || cassette1_counter_39Changed || cassette1_counter_40Changed || cassette1_counter_41Changed || cassette1_counter_42Changed || cassette1_counter_43Changed || cassette1_counter_44Changed || cassette1_counter_45Changed || cassette1_counter_46Changed || cassette1_counter_47Changed || cassette1_counter_48Changed || cassette1_counter_49Changed || cassette1_counter_50Changed || cassette2_counter_1Changed || cassette2_counter_2Changed || cassette2_counter_3Changed || cassette2_counter_4Changed || cassette2_counter_5Changed || cassette2_counter_6Changed || cassette2_counter_7Changed || cassette2_counter_8Changed || cassette2_counter_9Changed || cassette2_counter_10Changed || cassette2_counter_11Changed || cassette2_counter_12Changed || cassette2_counter_13Changed || cassette2_counter_14Changed || cassette2_counter_15Changed || cassette2_counter_16Changed || cassette2_counter_17Changed || cassette2_counter_18Changed || cassette2_counter_19Changed || cassette2_counter_20Changed || cassette2_counter_21Changed || cassette2_counter_22Changed || cassette2_counter_23Changed || cassette2_counter_24Changed || cassette2_counter_25Changed || cassette2_counter_26Changed || cassette2_counter_27Changed || cassette2_counter_28Changed || cassette2_counter_29Changed || cassette2_counter_30Changed || cassette2_counter_31Changed || cassette2_counter_32Changed || cassette2_counter_33Changed || cassette2_counter_34Changed || cassette2_counter_35Changed || cassette2_counter_36Changed || cassette2_counter_37Changed || cassette2_counter_38Changed || cassette2_counter_39Changed || cassette2_counter_40Changed || cassette2_counter_41Changed || cassette2_counter_42Changed || cassette2_counter_43Changed || cassette2_counter_44Changed || cassette2_counter_45Changed || cassette2_counter_46Changed || cassette2_counter_47Changed || cassette2_counter_48Changed || cassette2_counter_49Changed || cassette2_counter_50Changed || cassette3_counter_1Changed || cassette3_counter_2Changed || cassette3_counter_3Changed || cassette3_counter_4Changed || cassette3_counter_5Changed || cassette3_counter_6Changed || cassette3_counter_7Changed || cassette3_counter_8Changed || cassette3_counter_9Changed || cassette3_counter_10Changed || cassette3_counter_11Changed || cassette3_counter_12Changed || cassette3_counter_13Changed || cassette3_counter_14Changed || cassette3_counter_15Changed || cassette3_counter_16Changed || cassette3_counter_17Changed || cassette3_counter_18Changed || cassette3_counter_19Changed || cassette3_counter_20Changed || cassette3_counter_21Changed || cassette3_counter_22Changed || cassette3_counter_23Changed || cassette3_counter_24Changed || cassette3_counter_25Changed || cassette3_counter_26Changed || cassette3_counter_27Changed || cassette3_counter_28Changed || cassette3_counter_29Changed || cassette3_counter_30Changed || cassette3_counter_31Changed || cassette3_counter_32Changed || cassette3_counter_33Changed || cassette3_counter_34Changed || cassette3_counter_35Changed || cassette3_counter_36Changed || cassette3_counter_37Changed || cassette3_counter_38Changed || cassette3_counter_39Changed || cassette3_counter_40Changed || cassette3_counter_41Changed || cassette3_counter_42Changed || cassette3_counter_43Changed || cassette3_counter_44Changed || cassette3_counter_45Changed || cassette3_counter_46Changed || cassette3_counter_47Changed || cassette3_counter_48Changed || cassette3_counter_49Changed || cassette3_counter_50Changed || cassette4_counter_1Changed || cassette4_counter_2Changed || cassette4_counter_3Changed || cassette4_counter_4Changed || cassette4_counter_5Changed || cassette4_counter_6Changed || cassette4_counter_7Changed || cassette4_counter_8Changed || cassette4_counter_9Changed || cassette4_counter_10Changed || cassette4_counter_11Changed || cassette4_counter_12Changed || cassette4_counter_13Changed || cassette4_counter_14Changed || cassette4_counter_15Changed || cassette4_counter_16Changed || cassette4_counter_17Changed || cassette4_counter_18Changed || cassette4_counter_19Changed || cassette4_counter_20Changed || cassette4_counter_21Changed || cassette4_counter_22Changed || cassette4_counter_23Changed || cassette4_counter_24Changed || cassette4_counter_25Changed || cassette4_counter_26Changed || cassette4_counter_27Changed || cassette4_counter_28Changed || cassette4_counter_29Changed || cassette4_counter_30Changed || cassette4_counter_31Changed || cassette4_counter_32Changed || cassette4_counter_33Changed || cassette4_counter_34Changed || cassette4_counter_35Changed || cassette4_counter_36Changed || cassette4_counter_37Changed || cassette4_counter_38Changed || cassette4_counter_39Changed || cassette4_counter_40Changed || cassette4_counter_41Changed || cassette4_counter_42Changed || cassette4_counter_43Changed || cassette4_counter_44Changed || cassette4_counter_45Changed || cassette4_counter_46Changed || cassette4_counter_47Changed || cassette4_counter_48Changed || cassette4_counter_49Changed || cassette4_counter_50Changed || purge_counter_1Changed || purge_counter_2Changed || purge_counter_3Changed || purge_counter_4Changed || purge_counter_5Changed || purge_counter_6Changed || purge_counter_7Changed || purge_counter_8Changed || purge_counter_9Changed || purge_counter_10Changed || purge_counter_11Changed || purge_counter_12Changed || purge_counter_13Changed || purge_counter_14Changed || purge_counter_15Changed || purge_counter_16Changed || purge_counter_17Changed || purge_counter_18Changed || purge_counter_19Changed || purge_counter_20Changed || purge_counter_21Changed || purge_counter_22Changed || purge_counter_23Changed || purge_counter_24Changed || purge_counter_25Changed || purge_counter_26Changed || purge_counter_27Changed || purge_counter_28Changed || purge_counter_29Changed || purge_counter_30Changed || purge_counter_31Changed || purge_counter_32Changed || purge_counter_33Changed || purge_counter_34Changed || purge_counter_35Changed || purge_counter_36Changed || purge_counter_37Changed || purge_counter_38Changed || purge_counter_39Changed || purge_counter_40Changed || purge_counter_41Changed || purge_counter_42Changed || purge_counter_43Changed || purge_counter_44Changed || purge_counter_45Changed || purge_counter_46Changed || purge_counter_47Changed || purge_counter_48Changed || purge_counter_49Changed || purge_counter_50Changed || last_deposit_atChanged || atm_idChanged || task_idChanged || cassette1_denomination_detailChanged || cassette2_denomination_detailChanged || cassette3_denomination_detailChanged || cassette4_denomination_detailChanged || purge_denomination_detailChanged)
                ExcuteSave(ConnectionFactory.GetNewConnection().CreateCommand());
        }

        public void Save(IDbConnection conn, IDbTransaction trx)
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
        private void ExcuteSave(IDbCommand cmd)
        {
            if (parsed_bna_counter_idChanged || cassette1_counter_1Changed || cassette1_counter_2Changed || cassette1_counter_3Changed || cassette1_counter_4Changed || cassette1_counter_5Changed || cassette1_counter_6Changed || cassette1_counter_7Changed || cassette1_counter_8Changed || cassette1_counter_9Changed || cassette1_counter_10Changed || cassette1_counter_11Changed || cassette1_counter_12Changed || cassette1_counter_13Changed || cassette1_counter_14Changed || cassette1_counter_15Changed || cassette1_counter_16Changed || cassette1_counter_17Changed || cassette1_counter_18Changed || cassette1_counter_19Changed || cassette1_counter_20Changed || cassette1_counter_21Changed || cassette1_counter_22Changed || cassette1_counter_23Changed || cassette1_counter_24Changed || cassette1_counter_25Changed || cassette1_counter_26Changed || cassette1_counter_27Changed || cassette1_counter_28Changed || cassette1_counter_29Changed || cassette1_counter_30Changed || cassette1_counter_31Changed || cassette1_counter_32Changed || cassette1_counter_33Changed || cassette1_counter_34Changed || cassette1_counter_35Changed || cassette1_counter_36Changed || cassette1_counter_37Changed || cassette1_counter_38Changed || cassette1_counter_39Changed || cassette1_counter_40Changed || cassette1_counter_41Changed || cassette1_counter_42Changed || cassette1_counter_43Changed || cassette1_counter_44Changed || cassette1_counter_45Changed || cassette1_counter_46Changed || cassette1_counter_47Changed || cassette1_counter_48Changed || cassette1_counter_49Changed || cassette1_counter_50Changed || cassette2_counter_1Changed || cassette2_counter_2Changed || cassette2_counter_3Changed || cassette2_counter_4Changed || cassette2_counter_5Changed || cassette2_counter_6Changed || cassette2_counter_7Changed || cassette2_counter_8Changed || cassette2_counter_9Changed || cassette2_counter_10Changed || cassette2_counter_11Changed || cassette2_counter_12Changed || cassette2_counter_13Changed || cassette2_counter_14Changed || cassette2_counter_15Changed || cassette2_counter_16Changed || cassette2_counter_17Changed || cassette2_counter_18Changed || cassette2_counter_19Changed || cassette2_counter_20Changed || cassette2_counter_21Changed || cassette2_counter_22Changed || cassette2_counter_23Changed || cassette2_counter_24Changed || cassette2_counter_25Changed || cassette2_counter_26Changed || cassette2_counter_27Changed || cassette2_counter_28Changed || cassette2_counter_29Changed || cassette2_counter_30Changed || cassette2_counter_31Changed || cassette2_counter_32Changed || cassette2_counter_33Changed || cassette2_counter_34Changed || cassette2_counter_35Changed || cassette2_counter_36Changed || cassette2_counter_37Changed || cassette2_counter_38Changed || cassette2_counter_39Changed || cassette2_counter_40Changed || cassette2_counter_41Changed || cassette2_counter_42Changed || cassette2_counter_43Changed || cassette2_counter_44Changed || cassette2_counter_45Changed || cassette2_counter_46Changed || cassette2_counter_47Changed || cassette2_counter_48Changed || cassette2_counter_49Changed || cassette2_counter_50Changed || cassette3_counter_1Changed || cassette3_counter_2Changed || cassette3_counter_3Changed || cassette3_counter_4Changed || cassette3_counter_5Changed || cassette3_counter_6Changed || cassette3_counter_7Changed || cassette3_counter_8Changed || cassette3_counter_9Changed || cassette3_counter_10Changed || cassette3_counter_11Changed || cassette3_counter_12Changed || cassette3_counter_13Changed || cassette3_counter_14Changed || cassette3_counter_15Changed || cassette3_counter_16Changed || cassette3_counter_17Changed || cassette3_counter_18Changed || cassette3_counter_19Changed || cassette3_counter_20Changed || cassette3_counter_21Changed || cassette3_counter_22Changed || cassette3_counter_23Changed || cassette3_counter_24Changed || cassette3_counter_25Changed || cassette3_counter_26Changed || cassette3_counter_27Changed || cassette3_counter_28Changed || cassette3_counter_29Changed || cassette3_counter_30Changed || cassette3_counter_31Changed || cassette3_counter_32Changed || cassette3_counter_33Changed || cassette3_counter_34Changed || cassette3_counter_35Changed || cassette3_counter_36Changed || cassette3_counter_37Changed || cassette3_counter_38Changed || cassette3_counter_39Changed || cassette3_counter_40Changed || cassette3_counter_41Changed || cassette3_counter_42Changed || cassette3_counter_43Changed || cassette3_counter_44Changed || cassette3_counter_45Changed || cassette3_counter_46Changed || cassette3_counter_47Changed || cassette3_counter_48Changed || cassette3_counter_49Changed || cassette3_counter_50Changed || cassette4_counter_1Changed || cassette4_counter_2Changed || cassette4_counter_3Changed || cassette4_counter_4Changed || cassette4_counter_5Changed || cassette4_counter_6Changed || cassette4_counter_7Changed || cassette4_counter_8Changed || cassette4_counter_9Changed || cassette4_counter_10Changed || cassette4_counter_11Changed || cassette4_counter_12Changed || cassette4_counter_13Changed || cassette4_counter_14Changed || cassette4_counter_15Changed || cassette4_counter_16Changed || cassette4_counter_17Changed || cassette4_counter_18Changed || cassette4_counter_19Changed || cassette4_counter_20Changed || cassette4_counter_21Changed || cassette4_counter_22Changed || cassette4_counter_23Changed || cassette4_counter_24Changed || cassette4_counter_25Changed || cassette4_counter_26Changed || cassette4_counter_27Changed || cassette4_counter_28Changed || cassette4_counter_29Changed || cassette4_counter_30Changed || cassette4_counter_31Changed || cassette4_counter_32Changed || cassette4_counter_33Changed || cassette4_counter_34Changed || cassette4_counter_35Changed || cassette4_counter_36Changed || cassette4_counter_37Changed || cassette4_counter_38Changed || cassette4_counter_39Changed || cassette4_counter_40Changed || cassette4_counter_41Changed || cassette4_counter_42Changed || cassette4_counter_43Changed || cassette4_counter_44Changed || cassette4_counter_45Changed || cassette4_counter_46Changed || cassette4_counter_47Changed || cassette4_counter_48Changed || cassette4_counter_49Changed || cassette4_counter_50Changed || purge_counter_1Changed || purge_counter_2Changed || purge_counter_3Changed || purge_counter_4Changed || purge_counter_5Changed || purge_counter_6Changed || purge_counter_7Changed || purge_counter_8Changed || purge_counter_9Changed || purge_counter_10Changed || purge_counter_11Changed || purge_counter_12Changed || purge_counter_13Changed || purge_counter_14Changed || purge_counter_15Changed || purge_counter_16Changed || purge_counter_17Changed || purge_counter_18Changed || purge_counter_19Changed || purge_counter_20Changed || purge_counter_21Changed || purge_counter_22Changed || purge_counter_23Changed || purge_counter_24Changed || purge_counter_25Changed || purge_counter_26Changed || purge_counter_27Changed || purge_counter_28Changed || purge_counter_29Changed || purge_counter_30Changed || purge_counter_31Changed || purge_counter_32Changed || purge_counter_33Changed || purge_counter_34Changed || purge_counter_35Changed || purge_counter_36Changed || purge_counter_37Changed || purge_counter_38Changed || purge_counter_39Changed || purge_counter_40Changed || purge_counter_41Changed || purge_counter_42Changed || purge_counter_43Changed || purge_counter_44Changed || purge_counter_45Changed || purge_counter_46Changed || purge_counter_47Changed || purge_counter_48Changed || purge_counter_49Changed || purge_counter_50Changed || last_deposit_atChanged || atm_idChanged || task_idChanged || cassette1_denomination_detailChanged || cassette2_denomination_detailChanged || cassette3_denomination_detailChanged || cassette4_denomination_detailChanged || purge_denomination_detailChanged)
            {
                StringBuilder qry = new StringBuilder(500);

                if (this.isNewEntity)
                {
                    qry.Append(@"insert into Parsed_bna_counter(parsed_bna_counter_id,cassette1_counter_1,cassette1_counter_2,cassette1_counter_3,cassette1_counter_4,cassette1_counter_5,cassette1_counter_6,cassette1_counter_7,cassette1_counter_8,cassette1_counter_9,cassette1_counter_10,cassette1_counter_11,cassette1_counter_12,cassette1_counter_13,cassette1_counter_14,cassette1_counter_15,cassette1_counter_16,cassette1_counter_17,cassette1_counter_18,cassette1_counter_19,cassette1_counter_20,cassette1_counter_21,cassette1_counter_22,cassette1_counter_23,cassette1_counter_24,cassette1_counter_25,cassette1_counter_26,cassette1_counter_27,cassette1_counter_28,cassette1_counter_29,cassette1_counter_30,cassette1_counter_31,cassette1_counter_32,cassette1_counter_33,cassette1_counter_34,cassette1_counter_35,cassette1_counter_36,cassette1_counter_37,cassette1_counter_38,cassette1_counter_39,cassette1_counter_40,cassette1_counter_41,cassette1_counter_42,cassette1_counter_43,cassette1_counter_44,cassette1_counter_45,cassette1_counter_46,cassette1_counter_47,cassette1_counter_48,cassette1_counter_49,cassette1_counter_50,cassette2_counter_1,cassette2_counter_2,cassette2_counter_3,cassette2_counter_4,cassette2_counter_5,cassette2_counter_6,cassette2_counter_7,cassette2_counter_8,cassette2_counter_9,cassette2_counter_10,cassette2_counter_11,cassette2_counter_12,cassette2_counter_13,cassette2_counter_14,cassette2_counter_15,cassette2_counter_16,cassette2_counter_17,cassette2_counter_18,cassette2_counter_19,cassette2_counter_20,cassette2_counter_21,cassette2_counter_22,cassette2_counter_23,cassette2_counter_24,cassette2_counter_25,cassette2_counter_26,cassette2_counter_27,cassette2_counter_28,cassette2_counter_29,cassette2_counter_30,cassette2_counter_31,cassette2_counter_32,cassette2_counter_33,cassette2_counter_34,cassette2_counter_35,cassette2_counter_36,cassette2_counter_37,cassette2_counter_38,cassette2_counter_39,cassette2_counter_40,cassette2_counter_41,cassette2_counter_42,cassette2_counter_43,cassette2_counter_44,cassette2_counter_45,cassette2_counter_46,cassette2_counter_47,cassette2_counter_48,cassette2_counter_49,cassette2_counter_50,cassette3_counter_1,cassette3_counter_2,cassette3_counter_3,cassette3_counter_4,cassette3_counter_5,cassette3_counter_6,cassette3_counter_7,cassette3_counter_8,cassette3_counter_9,cassette3_counter_10,cassette3_counter_11,cassette3_counter_12,cassette3_counter_13,cassette3_counter_14,cassette3_counter_15,cassette3_counter_16,cassette3_counter_17,cassette3_counter_18,cassette3_counter_19,cassette3_counter_20,cassette3_counter_21,cassette3_counter_22,cassette3_counter_23,cassette3_counter_24,cassette3_counter_25,cassette3_counter_26,cassette3_counter_27,cassette3_counter_28,cassette3_counter_29,cassette3_counter_30,cassette3_counter_31,cassette3_counter_32,cassette3_counter_33,cassette3_counter_34,cassette3_counter_35,cassette3_counter_36,cassette3_counter_37,cassette3_counter_38,cassette3_counter_39,cassette3_counter_40,cassette3_counter_41,cassette3_counter_42,cassette3_counter_43,cassette3_counter_44,cassette3_counter_45,cassette3_counter_46,cassette3_counter_47,cassette3_counter_48,cassette3_counter_49,cassette3_counter_50,cassette4_counter_1,cassette4_counter_2,cassette4_counter_3,cassette4_counter_4,cassette4_counter_5,cassette4_counter_6,cassette4_counter_7,cassette4_counter_8,cassette4_counter_9,cassette4_counter_10,cassette4_counter_11,cassette4_counter_12,cassette4_counter_13,cassette4_counter_14,cassette4_counter_15,cassette4_counter_16,cassette4_counter_17,cassette4_counter_18,cassette4_counter_19,cassette4_counter_20,cassette4_counter_21,cassette4_counter_22,cassette4_counter_23,cassette4_counter_24,cassette4_counter_25,cassette4_counter_26,cassette4_counter_27,cassette4_counter_28,cassette4_counter_29,cassette4_counter_30,cassette4_counter_31,cassette4_counter_32,cassette4_counter_33,cassette4_counter_34,cassette4_counter_35,cassette4_counter_36,cassette4_counter_37,cassette4_counter_38,cassette4_counter_39,cassette4_counter_40,cassette4_counter_41,cassette4_counter_42,cassette4_counter_43,cassette4_counter_44,cassette4_counter_45,cassette4_counter_46,cassette4_counter_47,cassette4_counter_48,cassette4_counter_49,cassette4_counter_50,purge_counter_1,purge_counter_2,purge_counter_3,purge_counter_4,purge_counter_5,purge_counter_6,purge_counter_7,purge_counter_8,purge_counter_9,purge_counter_10,purge_counter_11,purge_counter_12,purge_counter_13,purge_counter_14,purge_counter_15,purge_counter_16,purge_counter_17,purge_counter_18,purge_counter_19,purge_counter_20,purge_counter_21,purge_counter_22,purge_counter_23,purge_counter_24,purge_counter_25,purge_counter_26,purge_counter_27,purge_counter_28,purge_counter_29,purge_counter_30,purge_counter_31,purge_counter_32,purge_counter_33,purge_counter_34,purge_counter_35,purge_counter_36,purge_counter_37,purge_counter_38,purge_counter_39,purge_counter_40,purge_counter_41,purge_counter_42,purge_counter_43,purge_counter_44,purge_counter_45,purge_counter_46,purge_counter_47,purge_counter_48,purge_counter_49,purge_counter_50,last_deposit_at,atm_id,task_id,cassette1_denomination_detail,cassette2_denomination_detail,cassette3_denomination_detail,cassette4_denomination_detail,purge_denomination_detail) values(");
                    lock (ConnectionFactory.connectionString)
                    {
                        this.parsed_bna_counter_id = ConnectionFactory.GetNextId();
                        qry.Append(this.parsed_bna_counter_id);
                    }
                    qry.Append(",");
                    qry.Append(cassette1_counter_1DbString + ",");
                    qry.Append(cassette1_counter_2DbString + ",");
                    qry.Append(cassette1_counter_3DbString + ",");
                    qry.Append(cassette1_counter_4DbString + ",");
                    qry.Append(cassette1_counter_5DbString + ",");
                    qry.Append(cassette1_counter_6DbString + ",");
                    qry.Append(cassette1_counter_7DbString + ",");
                    qry.Append(cassette1_counter_8DbString + ",");
                    qry.Append(cassette1_counter_9DbString + ",");
                    qry.Append(cassette1_counter_10DbString + ",");
                    qry.Append(cassette1_counter_11DbString + ",");
                    qry.Append(cassette1_counter_12DbString + ",");
                    qry.Append(cassette1_counter_13DbString + ",");
                    qry.Append(cassette1_counter_14DbString + ",");
                    qry.Append(cassette1_counter_15DbString + ",");
                    qry.Append(cassette1_counter_16DbString + ",");
                    qry.Append(cassette1_counter_17DbString + ",");
                    qry.Append(cassette1_counter_18DbString + ",");
                    qry.Append(cassette1_counter_19DbString + ",");
                    qry.Append(cassette1_counter_20DbString + ",");
                    qry.Append(cassette1_counter_21DbString + ",");
                    qry.Append(cassette1_counter_22DbString + ",");
                    qry.Append(cassette1_counter_23DbString + ",");
                    qry.Append(cassette1_counter_24DbString + ",");
                    qry.Append(cassette1_counter_25DbString + ",");
                    qry.Append(cassette1_counter_26DbString + ",");
                    qry.Append(cassette1_counter_27DbString + ",");
                    qry.Append(cassette1_counter_28DbString + ",");
                    qry.Append(cassette1_counter_29DbString + ",");
                    qry.Append(cassette1_counter_30DbString + ",");
                    qry.Append(cassette1_counter_31DbString + ",");
                    qry.Append(cassette1_counter_32DbString + ",");
                    qry.Append(cassette1_counter_33DbString + ",");
                    qry.Append(cassette1_counter_34DbString + ",");
                    qry.Append(cassette1_counter_35DbString + ",");
                    qry.Append(cassette1_counter_36DbString + ",");
                    qry.Append(cassette1_counter_37DbString + ",");
                    qry.Append(cassette1_counter_38DbString + ",");
                    qry.Append(cassette1_counter_39DbString + ",");
                    qry.Append(cassette1_counter_40DbString + ",");
                    qry.Append(cassette1_counter_41DbString + ",");
                    qry.Append(cassette1_counter_42DbString + ",");
                    qry.Append(cassette1_counter_43DbString + ",");
                    qry.Append(cassette1_counter_44DbString + ",");
                    qry.Append(cassette1_counter_45DbString + ",");
                    qry.Append(cassette1_counter_46DbString + ",");
                    qry.Append(cassette1_counter_47DbString + ",");
                    qry.Append(cassette1_counter_48DbString + ",");
                    qry.Append(cassette1_counter_49DbString + ",");
                    qry.Append(cassette1_counter_50DbString + ",");
                    qry.Append(cassette2_counter_1DbString + ",");
                    qry.Append(cassette2_counter_2DbString + ",");
                    qry.Append(cassette2_counter_3DbString + ",");
                    qry.Append(cassette2_counter_4DbString + ",");
                    qry.Append(cassette2_counter_5DbString + ",");
                    qry.Append(cassette2_counter_6DbString + ",");
                    qry.Append(cassette2_counter_7DbString + ",");
                    qry.Append(cassette2_counter_8DbString + ",");
                    qry.Append(cassette2_counter_9DbString + ",");
                    qry.Append(cassette2_counter_10DbString + ",");
                    qry.Append(cassette2_counter_11DbString + ",");
                    qry.Append(cassette2_counter_12DbString + ",");
                    qry.Append(cassette2_counter_13DbString + ",");
                    qry.Append(cassette2_counter_14DbString + ",");
                    qry.Append(cassette2_counter_15DbString + ",");
                    qry.Append(cassette2_counter_16DbString + ",");
                    qry.Append(cassette2_counter_17DbString + ",");
                    qry.Append(cassette2_counter_18DbString + ",");
                    qry.Append(cassette2_counter_19DbString + ",");
                    qry.Append(cassette2_counter_20DbString + ",");
                    qry.Append(cassette2_counter_21DbString + ",");
                    qry.Append(cassette2_counter_22DbString + ",");
                    qry.Append(cassette2_counter_23DbString + ",");
                    qry.Append(cassette2_counter_24DbString + ",");
                    qry.Append(cassette2_counter_25DbString + ",");
                    qry.Append(cassette2_counter_26DbString + ",");
                    qry.Append(cassette2_counter_27DbString + ",");
                    qry.Append(cassette2_counter_28DbString + ",");
                    qry.Append(cassette2_counter_29DbString + ",");
                    qry.Append(cassette2_counter_30DbString + ",");
                    qry.Append(cassette2_counter_31DbString + ",");
                    qry.Append(cassette2_counter_32DbString + ",");
                    qry.Append(cassette2_counter_33DbString + ",");
                    qry.Append(cassette2_counter_34DbString + ",");
                    qry.Append(cassette2_counter_35DbString + ",");
                    qry.Append(cassette2_counter_36DbString + ",");
                    qry.Append(cassette2_counter_37DbString + ",");
                    qry.Append(cassette2_counter_38DbString + ",");
                    qry.Append(cassette2_counter_39DbString + ",");
                    qry.Append(cassette2_counter_40DbString + ",");
                    qry.Append(cassette2_counter_41DbString + ",");
                    qry.Append(cassette2_counter_42DbString + ",");
                    qry.Append(cassette2_counter_43DbString + ",");
                    qry.Append(cassette2_counter_44DbString + ",");
                    qry.Append(cassette2_counter_45DbString + ",");
                    qry.Append(cassette2_counter_46DbString + ",");
                    qry.Append(cassette2_counter_47DbString + ",");
                    qry.Append(cassette2_counter_48DbString + ",");
                    qry.Append(cassette2_counter_49DbString + ",");
                    qry.Append(cassette2_counter_50DbString + ",");
                    qry.Append(cassette3_counter_1DbString + ",");
                    qry.Append(cassette3_counter_2DbString + ",");
                    qry.Append(cassette3_counter_3DbString + ",");
                    qry.Append(cassette3_counter_4DbString + ",");
                    qry.Append(cassette3_counter_5DbString + ",");
                    qry.Append(cassette3_counter_6DbString + ",");
                    qry.Append(cassette3_counter_7DbString + ",");
                    qry.Append(cassette3_counter_8DbString + ",");
                    qry.Append(cassette3_counter_9DbString + ",");
                    qry.Append(cassette3_counter_10DbString + ",");
                    qry.Append(cassette3_counter_11DbString + ",");
                    qry.Append(cassette3_counter_12DbString + ",");
                    qry.Append(cassette3_counter_13DbString + ",");
                    qry.Append(cassette3_counter_14DbString + ",");
                    qry.Append(cassette3_counter_15DbString + ",");
                    qry.Append(cassette3_counter_16DbString + ",");
                    qry.Append(cassette3_counter_17DbString + ",");
                    qry.Append(cassette3_counter_18DbString + ",");
                    qry.Append(cassette3_counter_19DbString + ",");
                    qry.Append(cassette3_counter_20DbString + ",");
                    qry.Append(cassette3_counter_21DbString + ",");
                    qry.Append(cassette3_counter_22DbString + ",");
                    qry.Append(cassette3_counter_23DbString + ",");
                    qry.Append(cassette3_counter_24DbString + ",");
                    qry.Append(cassette3_counter_25DbString + ",");
                    qry.Append(cassette3_counter_26DbString + ",");
                    qry.Append(cassette3_counter_27DbString + ",");
                    qry.Append(cassette3_counter_28DbString + ",");
                    qry.Append(cassette3_counter_29DbString + ",");
                    qry.Append(cassette3_counter_30DbString + ",");
                    qry.Append(cassette3_counter_31DbString + ",");
                    qry.Append(cassette3_counter_32DbString + ",");
                    qry.Append(cassette3_counter_33DbString + ",");
                    qry.Append(cassette3_counter_34DbString + ",");
                    qry.Append(cassette3_counter_35DbString + ",");
                    qry.Append(cassette3_counter_36DbString + ",");
                    qry.Append(cassette3_counter_37DbString + ",");
                    qry.Append(cassette3_counter_38DbString + ",");
                    qry.Append(cassette3_counter_39DbString + ",");
                    qry.Append(cassette3_counter_40DbString + ",");
                    qry.Append(cassette3_counter_41DbString + ",");
                    qry.Append(cassette3_counter_42DbString + ",");
                    qry.Append(cassette3_counter_43DbString + ",");
                    qry.Append(cassette3_counter_44DbString + ",");
                    qry.Append(cassette3_counter_45DbString + ",");
                    qry.Append(cassette3_counter_46DbString + ",");
                    qry.Append(cassette3_counter_47DbString + ",");
                    qry.Append(cassette3_counter_48DbString + ",");
                    qry.Append(cassette3_counter_49DbString + ",");
                    qry.Append(cassette3_counter_50DbString + ",");
                    qry.Append(cassette4_counter_1DbString + ",");
                    qry.Append(cassette4_counter_2DbString + ",");
                    qry.Append(cassette4_counter_3DbString + ",");
                    qry.Append(cassette4_counter_4DbString + ",");
                    qry.Append(cassette4_counter_5DbString + ",");
                    qry.Append(cassette4_counter_6DbString + ",");
                    qry.Append(cassette4_counter_7DbString + ",");
                    qry.Append(cassette4_counter_8DbString + ",");
                    qry.Append(cassette4_counter_9DbString + ",");
                    qry.Append(cassette4_counter_10DbString + ",");
                    qry.Append(cassette4_counter_11DbString + ",");
                    qry.Append(cassette4_counter_12DbString + ",");
                    qry.Append(cassette4_counter_13DbString + ",");
                    qry.Append(cassette4_counter_14DbString + ",");
                    qry.Append(cassette4_counter_15DbString + ",");
                    qry.Append(cassette4_counter_16DbString + ",");
                    qry.Append(cassette4_counter_17DbString + ",");
                    qry.Append(cassette4_counter_18DbString + ",");
                    qry.Append(cassette4_counter_19DbString + ",");
                    qry.Append(cassette4_counter_20DbString + ",");
                    qry.Append(cassette4_counter_21DbString + ",");
                    qry.Append(cassette4_counter_22DbString + ",");
                    qry.Append(cassette4_counter_23DbString + ",");
                    qry.Append(cassette4_counter_24DbString + ",");
                    qry.Append(cassette4_counter_25DbString + ",");
                    qry.Append(cassette4_counter_26DbString + ",");
                    qry.Append(cassette4_counter_27DbString + ",");
                    qry.Append(cassette4_counter_28DbString + ",");
                    qry.Append(cassette4_counter_29DbString + ",");
                    qry.Append(cassette4_counter_30DbString + ",");
                    qry.Append(cassette4_counter_31DbString + ",");
                    qry.Append(cassette4_counter_32DbString + ",");
                    qry.Append(cassette4_counter_33DbString + ",");
                    qry.Append(cassette4_counter_34DbString + ",");
                    qry.Append(cassette4_counter_35DbString + ",");
                    qry.Append(cassette4_counter_36DbString + ",");
                    qry.Append(cassette4_counter_37DbString + ",");
                    qry.Append(cassette4_counter_38DbString + ",");
                    qry.Append(cassette4_counter_39DbString + ",");
                    qry.Append(cassette4_counter_40DbString + ",");
                    qry.Append(cassette4_counter_41DbString + ",");
                    qry.Append(cassette4_counter_42DbString + ",");
                    qry.Append(cassette4_counter_43DbString + ",");
                    qry.Append(cassette4_counter_44DbString + ",");
                    qry.Append(cassette4_counter_45DbString + ",");
                    qry.Append(cassette4_counter_46DbString + ",");
                    qry.Append(cassette4_counter_47DbString + ",");
                    qry.Append(cassette4_counter_48DbString + ",");
                    qry.Append(cassette4_counter_49DbString + ",");
                    qry.Append(cassette4_counter_50DbString + ",");
                    qry.Append(purge_counter_1DbString + ",");
                    qry.Append(purge_counter_2DbString + ",");
                    qry.Append(purge_counter_3DbString + ",");
                    qry.Append(purge_counter_4DbString + ",");
                    qry.Append(purge_counter_5DbString + ",");
                    qry.Append(purge_counter_6DbString + ",");
                    qry.Append(purge_counter_7DbString + ",");
                    qry.Append(purge_counter_8DbString + ",");
                    qry.Append(purge_counter_9DbString + ",");
                    qry.Append(purge_counter_10DbString + ",");
                    qry.Append(purge_counter_11DbString + ",");
                    qry.Append(purge_counter_12DbString + ",");
                    qry.Append(purge_counter_13DbString + ",");
                    qry.Append(purge_counter_14DbString + ",");
                    qry.Append(purge_counter_15DbString + ",");
                    qry.Append(purge_counter_16DbString + ",");
                    qry.Append(purge_counter_17DbString + ",");
                    qry.Append(purge_counter_18DbString + ",");
                    qry.Append(purge_counter_19DbString + ",");
                    qry.Append(purge_counter_20DbString + ",");
                    qry.Append(purge_counter_21DbString + ",");
                    qry.Append(purge_counter_22DbString + ",");
                    qry.Append(purge_counter_23DbString + ",");
                    qry.Append(purge_counter_24DbString + ",");
                    qry.Append(purge_counter_25DbString + ",");
                    qry.Append(purge_counter_26DbString + ",");
                    qry.Append(purge_counter_27DbString + ",");
                    qry.Append(purge_counter_28DbString + ",");
                    qry.Append(purge_counter_29DbString + ",");
                    qry.Append(purge_counter_30DbString + ",");
                    qry.Append(purge_counter_31DbString + ",");
                    qry.Append(purge_counter_32DbString + ",");
                    qry.Append(purge_counter_33DbString + ",");
                    qry.Append(purge_counter_34DbString + ",");
                    qry.Append(purge_counter_35DbString + ",");
                    qry.Append(purge_counter_36DbString + ",");
                    qry.Append(purge_counter_37DbString + ",");
                    qry.Append(purge_counter_38DbString + ",");
                    qry.Append(purge_counter_39DbString + ",");
                    qry.Append(purge_counter_40DbString + ",");
                    qry.Append(purge_counter_41DbString + ",");
                    qry.Append(purge_counter_42DbString + ",");
                    qry.Append(purge_counter_43DbString + ",");
                    qry.Append(purge_counter_44DbString + ",");
                    qry.Append(purge_counter_45DbString + ",");
                    qry.Append(purge_counter_46DbString + ",");
                    qry.Append(purge_counter_47DbString + ",");
                    qry.Append(purge_counter_48DbString + ",");
                    qry.Append(purge_counter_49DbString + ",");
                    qry.Append(purge_counter_50DbString + ",");
                    qry.Append(last_deposit_atDbString + ",");
                    qry.Append(atm_idDbString + ",");
                    qry.Append(task_idDbString + ",");
                    qry.Append(cassette1_denomination_detailDbString + ",");
                    qry.Append(cassette2_denomination_detailDbString + ",");
                    qry.Append(cassette3_denomination_detailDbString + ",");
                    qry.Append(cassette4_denomination_detailDbString + ",");
                    qry.Append(purge_denomination_detailDbString);
                    qry.Append(");");

                }
                else
                {
                    if (!(parsed_bna_counter_idChanged || cassette1_counter_1Changed || cassette1_counter_2Changed || cassette1_counter_3Changed || cassette1_counter_4Changed || cassette1_counter_5Changed || cassette1_counter_6Changed || cassette1_counter_7Changed || cassette1_counter_8Changed || cassette1_counter_9Changed || cassette1_counter_10Changed || cassette1_counter_11Changed || cassette1_counter_12Changed || cassette1_counter_13Changed || cassette1_counter_14Changed || cassette1_counter_15Changed || cassette1_counter_16Changed || cassette1_counter_17Changed || cassette1_counter_18Changed || cassette1_counter_19Changed || cassette1_counter_20Changed || cassette1_counter_21Changed || cassette1_counter_22Changed || cassette1_counter_23Changed || cassette1_counter_24Changed || cassette1_counter_25Changed || cassette1_counter_26Changed || cassette1_counter_27Changed || cassette1_counter_28Changed || cassette1_counter_29Changed || cassette1_counter_30Changed || cassette1_counter_31Changed || cassette1_counter_32Changed || cassette1_counter_33Changed || cassette1_counter_34Changed || cassette1_counter_35Changed || cassette1_counter_36Changed || cassette1_counter_37Changed || cassette1_counter_38Changed || cassette1_counter_39Changed || cassette1_counter_40Changed || cassette1_counter_41Changed || cassette1_counter_42Changed || cassette1_counter_43Changed || cassette1_counter_44Changed || cassette1_counter_45Changed || cassette1_counter_46Changed || cassette1_counter_47Changed || cassette1_counter_48Changed || cassette1_counter_49Changed || cassette1_counter_50Changed || cassette2_counter_1Changed || cassette2_counter_2Changed || cassette2_counter_3Changed || cassette2_counter_4Changed || cassette2_counter_5Changed || cassette2_counter_6Changed || cassette2_counter_7Changed || cassette2_counter_8Changed || cassette2_counter_9Changed || cassette2_counter_10Changed || cassette2_counter_11Changed || cassette2_counter_12Changed || cassette2_counter_13Changed || cassette2_counter_14Changed || cassette2_counter_15Changed || cassette2_counter_16Changed || cassette2_counter_17Changed || cassette2_counter_18Changed || cassette2_counter_19Changed || cassette2_counter_20Changed || cassette2_counter_21Changed || cassette2_counter_22Changed || cassette2_counter_23Changed || cassette2_counter_24Changed || cassette2_counter_25Changed || cassette2_counter_26Changed || cassette2_counter_27Changed || cassette2_counter_28Changed || cassette2_counter_29Changed || cassette2_counter_30Changed || cassette2_counter_31Changed || cassette2_counter_32Changed || cassette2_counter_33Changed || cassette2_counter_34Changed || cassette2_counter_35Changed || cassette2_counter_36Changed || cassette2_counter_37Changed || cassette2_counter_38Changed || cassette2_counter_39Changed || cassette2_counter_40Changed || cassette2_counter_41Changed || cassette2_counter_42Changed || cassette2_counter_43Changed || cassette2_counter_44Changed || cassette2_counter_45Changed || cassette2_counter_46Changed || cassette2_counter_47Changed || cassette2_counter_48Changed || cassette2_counter_49Changed || cassette2_counter_50Changed || cassette3_counter_1Changed || cassette3_counter_2Changed || cassette3_counter_3Changed || cassette3_counter_4Changed || cassette3_counter_5Changed || cassette3_counter_6Changed || cassette3_counter_7Changed || cassette3_counter_8Changed || cassette3_counter_9Changed || cassette3_counter_10Changed || cassette3_counter_11Changed || cassette3_counter_12Changed || cassette3_counter_13Changed || cassette3_counter_14Changed || cassette3_counter_15Changed || cassette3_counter_16Changed || cassette3_counter_17Changed || cassette3_counter_18Changed || cassette3_counter_19Changed || cassette3_counter_20Changed || cassette3_counter_21Changed || cassette3_counter_22Changed || cassette3_counter_23Changed || cassette3_counter_24Changed || cassette3_counter_25Changed || cassette3_counter_26Changed || cassette3_counter_27Changed || cassette3_counter_28Changed || cassette3_counter_29Changed || cassette3_counter_30Changed || cassette3_counter_31Changed || cassette3_counter_32Changed || cassette3_counter_33Changed || cassette3_counter_34Changed || cassette3_counter_35Changed || cassette3_counter_36Changed || cassette3_counter_37Changed || cassette3_counter_38Changed || cassette3_counter_39Changed || cassette3_counter_40Changed || cassette3_counter_41Changed || cassette3_counter_42Changed || cassette3_counter_43Changed || cassette3_counter_44Changed || cassette3_counter_45Changed || cassette3_counter_46Changed || cassette3_counter_47Changed || cassette3_counter_48Changed || cassette3_counter_49Changed || cassette3_counter_50Changed || cassette4_counter_1Changed || cassette4_counter_2Changed || cassette4_counter_3Changed || cassette4_counter_4Changed || cassette4_counter_5Changed || cassette4_counter_6Changed || cassette4_counter_7Changed || cassette4_counter_8Changed || cassette4_counter_9Changed || cassette4_counter_10Changed || cassette4_counter_11Changed || cassette4_counter_12Changed || cassette4_counter_13Changed || cassette4_counter_14Changed || cassette4_counter_15Changed || cassette4_counter_16Changed || cassette4_counter_17Changed || cassette4_counter_18Changed || cassette4_counter_19Changed || cassette4_counter_20Changed || cassette4_counter_21Changed || cassette4_counter_22Changed || cassette4_counter_23Changed || cassette4_counter_24Changed || cassette4_counter_25Changed || cassette4_counter_26Changed || cassette4_counter_27Changed || cassette4_counter_28Changed || cassette4_counter_29Changed || cassette4_counter_30Changed || cassette4_counter_31Changed || cassette4_counter_32Changed || cassette4_counter_33Changed || cassette4_counter_34Changed || cassette4_counter_35Changed || cassette4_counter_36Changed || cassette4_counter_37Changed || cassette4_counter_38Changed || cassette4_counter_39Changed || cassette4_counter_40Changed || cassette4_counter_41Changed || cassette4_counter_42Changed || cassette4_counter_43Changed || cassette4_counter_44Changed || cassette4_counter_45Changed || cassette4_counter_46Changed || cassette4_counter_47Changed || cassette4_counter_48Changed || cassette4_counter_49Changed || cassette4_counter_50Changed || purge_counter_1Changed || purge_counter_2Changed || purge_counter_3Changed || purge_counter_4Changed || purge_counter_5Changed || purge_counter_6Changed || purge_counter_7Changed || purge_counter_8Changed || purge_counter_9Changed || purge_counter_10Changed || purge_counter_11Changed || purge_counter_12Changed || purge_counter_13Changed || purge_counter_14Changed || purge_counter_15Changed || purge_counter_16Changed || purge_counter_17Changed || purge_counter_18Changed || purge_counter_19Changed || purge_counter_20Changed || purge_counter_21Changed || purge_counter_22Changed || purge_counter_23Changed || purge_counter_24Changed || purge_counter_25Changed || purge_counter_26Changed || purge_counter_27Changed || purge_counter_28Changed || purge_counter_29Changed || purge_counter_30Changed || purge_counter_31Changed || purge_counter_32Changed || purge_counter_33Changed || purge_counter_34Changed || purge_counter_35Changed || purge_counter_36Changed || purge_counter_37Changed || purge_counter_38Changed || purge_counter_39Changed || purge_counter_40Changed || purge_counter_41Changed || purge_counter_42Changed || purge_counter_43Changed || purge_counter_44Changed || purge_counter_45Changed || purge_counter_46Changed || purge_counter_47Changed || purge_counter_48Changed || purge_counter_49Changed || purge_counter_50Changed || last_deposit_atChanged || atm_idChanged || task_idChanged || cassette1_denomination_detailChanged || cassette2_denomination_detailChanged || cassette3_denomination_detailChanged || cassette4_denomination_detailChanged || purge_denomination_detailChanged))
                        return;
                    qry.Append("UPDATE Parsed_bna_counter set "); if (cassette1_counter_1Changed)
                    {
                        qry.Append("cassette1_counter_1 =" + cassette1_counter_1DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_2Changed)
                    {
                        qry.Append("cassette1_counter_2 =" + cassette1_counter_2DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_3Changed)
                    {
                        qry.Append("cassette1_counter_3 =" + cassette1_counter_3DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_4Changed)
                    {
                        qry.Append("cassette1_counter_4 =" + cassette1_counter_4DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_5Changed)
                    {
                        qry.Append("cassette1_counter_5 =" + cassette1_counter_5DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_6Changed)
                    {
                        qry.Append("cassette1_counter_6 =" + cassette1_counter_6DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_7Changed)
                    {
                        qry.Append("cassette1_counter_7 =" + cassette1_counter_7DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_8Changed)
                    {
                        qry.Append("cassette1_counter_8 =" + cassette1_counter_8DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_9Changed)
                    {
                        qry.Append("cassette1_counter_9 =" + cassette1_counter_9DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_10Changed)
                    {
                        qry.Append("cassette1_counter_10 =" + cassette1_counter_10DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_11Changed)
                    {
                        qry.Append("cassette1_counter_11 =" + cassette1_counter_11DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_12Changed)
                    {
                        qry.Append("cassette1_counter_12 =" + cassette1_counter_12DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_13Changed)
                    {
                        qry.Append("cassette1_counter_13 =" + cassette1_counter_13DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_14Changed)
                    {
                        qry.Append("cassette1_counter_14 =" + cassette1_counter_14DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_15Changed)
                    {
                        qry.Append("cassette1_counter_15 =" + cassette1_counter_15DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_16Changed)
                    {
                        qry.Append("cassette1_counter_16 =" + cassette1_counter_16DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_17Changed)
                    {
                        qry.Append("cassette1_counter_17 =" + cassette1_counter_17DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_18Changed)
                    {
                        qry.Append("cassette1_counter_18 =" + cassette1_counter_18DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_19Changed)
                    {
                        qry.Append("cassette1_counter_19 =" + cassette1_counter_19DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_20Changed)
                    {
                        qry.Append("cassette1_counter_20 =" + cassette1_counter_20DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_21Changed)
                    {
                        qry.Append("cassette1_counter_21 =" + cassette1_counter_21DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_22Changed)
                    {
                        qry.Append("cassette1_counter_22 =" + cassette1_counter_22DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_23Changed)
                    {
                        qry.Append("cassette1_counter_23 =" + cassette1_counter_23DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_24Changed)
                    {
                        qry.Append("cassette1_counter_24 =" + cassette1_counter_24DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_25Changed)
                    {
                        qry.Append("cassette1_counter_25 =" + cassette1_counter_25DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_26Changed)
                    {
                        qry.Append("cassette1_counter_26 =" + cassette1_counter_26DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_27Changed)
                    {
                        qry.Append("cassette1_counter_27 =" + cassette1_counter_27DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_28Changed)
                    {
                        qry.Append("cassette1_counter_28 =" + cassette1_counter_28DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_29Changed)
                    {
                        qry.Append("cassette1_counter_29 =" + cassette1_counter_29DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_30Changed)
                    {
                        qry.Append("cassette1_counter_30 =" + cassette1_counter_30DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_31Changed)
                    {
                        qry.Append("cassette1_counter_31 =" + cassette1_counter_31DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_32Changed)
                    {
                        qry.Append("cassette1_counter_32 =" + cassette1_counter_32DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_33Changed)
                    {
                        qry.Append("cassette1_counter_33 =" + cassette1_counter_33DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_34Changed)
                    {
                        qry.Append("cassette1_counter_34 =" + cassette1_counter_34DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_35Changed)
                    {
                        qry.Append("cassette1_counter_35 =" + cassette1_counter_35DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_36Changed)
                    {
                        qry.Append("cassette1_counter_36 =" + cassette1_counter_36DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_37Changed)
                    {
                        qry.Append("cassette1_counter_37 =" + cassette1_counter_37DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_38Changed)
                    {
                        qry.Append("cassette1_counter_38 =" + cassette1_counter_38DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_39Changed)
                    {
                        qry.Append("cassette1_counter_39 =" + cassette1_counter_39DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_40Changed)
                    {
                        qry.Append("cassette1_counter_40 =" + cassette1_counter_40DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_41Changed)
                    {
                        qry.Append("cassette1_counter_41 =" + cassette1_counter_41DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_42Changed)
                    {
                        qry.Append("cassette1_counter_42 =" + cassette1_counter_42DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_43Changed)
                    {
                        qry.Append("cassette1_counter_43 =" + cassette1_counter_43DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_44Changed)
                    {
                        qry.Append("cassette1_counter_44 =" + cassette1_counter_44DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_45Changed)
                    {
                        qry.Append("cassette1_counter_45 =" + cassette1_counter_45DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_46Changed)
                    {
                        qry.Append("cassette1_counter_46 =" + cassette1_counter_46DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_47Changed)
                    {
                        qry.Append("cassette1_counter_47 =" + cassette1_counter_47DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_48Changed)
                    {
                        qry.Append("cassette1_counter_48 =" + cassette1_counter_48DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_49Changed)
                    {
                        qry.Append("cassette1_counter_49 =" + cassette1_counter_49DbString);
                        qry.Append(",");
                    }

                    if (cassette1_counter_50Changed)
                    {
                        qry.Append("cassette1_counter_50 =" + cassette1_counter_50DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_1Changed)
                    {
                        qry.Append("cassette2_counter_1 =" + cassette2_counter_1DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_2Changed)
                    {
                        qry.Append("cassette2_counter_2 =" + cassette2_counter_2DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_3Changed)
                    {
                        qry.Append("cassette2_counter_3 =" + cassette2_counter_3DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_4Changed)
                    {
                        qry.Append("cassette2_counter_4 =" + cassette2_counter_4DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_5Changed)
                    {
                        qry.Append("cassette2_counter_5 =" + cassette2_counter_5DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_6Changed)
                    {
                        qry.Append("cassette2_counter_6 =" + cassette2_counter_6DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_7Changed)
                    {
                        qry.Append("cassette2_counter_7 =" + cassette2_counter_7DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_8Changed)
                    {
                        qry.Append("cassette2_counter_8 =" + cassette2_counter_8DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_9Changed)
                    {
                        qry.Append("cassette2_counter_9 =" + cassette2_counter_9DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_10Changed)
                    {
                        qry.Append("cassette2_counter_10 =" + cassette2_counter_10DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_11Changed)
                    {
                        qry.Append("cassette2_counter_11 =" + cassette2_counter_11DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_12Changed)
                    {
                        qry.Append("cassette2_counter_12 =" + cassette2_counter_12DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_13Changed)
                    {
                        qry.Append("cassette2_counter_13 =" + cassette2_counter_13DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_14Changed)
                    {
                        qry.Append("cassette2_counter_14 =" + cassette2_counter_14DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_15Changed)
                    {
                        qry.Append("cassette2_counter_15 =" + cassette2_counter_15DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_16Changed)
                    {
                        qry.Append("cassette2_counter_16 =" + cassette2_counter_16DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_17Changed)
                    {
                        qry.Append("cassette2_counter_17 =" + cassette2_counter_17DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_18Changed)
                    {
                        qry.Append("cassette2_counter_18 =" + cassette2_counter_18DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_19Changed)
                    {
                        qry.Append("cassette2_counter_19 =" + cassette2_counter_19DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_20Changed)
                    {
                        qry.Append("cassette2_counter_20 =" + cassette2_counter_20DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_21Changed)
                    {
                        qry.Append("cassette2_counter_21 =" + cassette2_counter_21DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_22Changed)
                    {
                        qry.Append("cassette2_counter_22 =" + cassette2_counter_22DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_23Changed)
                    {
                        qry.Append("cassette2_counter_23 =" + cassette2_counter_23DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_24Changed)
                    {
                        qry.Append("cassette2_counter_24 =" + cassette2_counter_24DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_25Changed)
                    {
                        qry.Append("cassette2_counter_25 =" + cassette2_counter_25DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_26Changed)
                    {
                        qry.Append("cassette2_counter_26 =" + cassette2_counter_26DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_27Changed)
                    {
                        qry.Append("cassette2_counter_27 =" + cassette2_counter_27DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_28Changed)
                    {
                        qry.Append("cassette2_counter_28 =" + cassette2_counter_28DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_29Changed)
                    {
                        qry.Append("cassette2_counter_29 =" + cassette2_counter_29DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_30Changed)
                    {
                        qry.Append("cassette2_counter_30 =" + cassette2_counter_30DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_31Changed)
                    {
                        qry.Append("cassette2_counter_31 =" + cassette2_counter_31DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_32Changed)
                    {
                        qry.Append("cassette2_counter_32 =" + cassette2_counter_32DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_33Changed)
                    {
                        qry.Append("cassette2_counter_33 =" + cassette2_counter_33DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_34Changed)
                    {
                        qry.Append("cassette2_counter_34 =" + cassette2_counter_34DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_35Changed)
                    {
                        qry.Append("cassette2_counter_35 =" + cassette2_counter_35DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_36Changed)
                    {
                        qry.Append("cassette2_counter_36 =" + cassette2_counter_36DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_37Changed)
                    {
                        qry.Append("cassette2_counter_37 =" + cassette2_counter_37DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_38Changed)
                    {
                        qry.Append("cassette2_counter_38 =" + cassette2_counter_38DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_39Changed)
                    {
                        qry.Append("cassette2_counter_39 =" + cassette2_counter_39DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_40Changed)
                    {
                        qry.Append("cassette2_counter_40 =" + cassette2_counter_40DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_41Changed)
                    {
                        qry.Append("cassette2_counter_41 =" + cassette2_counter_41DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_42Changed)
                    {
                        qry.Append("cassette2_counter_42 =" + cassette2_counter_42DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_43Changed)
                    {
                        qry.Append("cassette2_counter_43 =" + cassette2_counter_43DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_44Changed)
                    {
                        qry.Append("cassette2_counter_44 =" + cassette2_counter_44DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_45Changed)
                    {
                        qry.Append("cassette2_counter_45 =" + cassette2_counter_45DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_46Changed)
                    {
                        qry.Append("cassette2_counter_46 =" + cassette2_counter_46DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_47Changed)
                    {
                        qry.Append("cassette2_counter_47 =" + cassette2_counter_47DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_48Changed)
                    {
                        qry.Append("cassette2_counter_48 =" + cassette2_counter_48DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_49Changed)
                    {
                        qry.Append("cassette2_counter_49 =" + cassette2_counter_49DbString);
                        qry.Append(",");
                    }

                    if (cassette2_counter_50Changed)
                    {
                        qry.Append("cassette2_counter_50 =" + cassette2_counter_50DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_1Changed)
                    {
                        qry.Append("cassette3_counter_1 =" + cassette3_counter_1DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_2Changed)
                    {
                        qry.Append("cassette3_counter_2 =" + cassette3_counter_2DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_3Changed)
                    {
                        qry.Append("cassette3_counter_3 =" + cassette3_counter_3DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_4Changed)
                    {
                        qry.Append("cassette3_counter_4 =" + cassette3_counter_4DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_5Changed)
                    {
                        qry.Append("cassette3_counter_5 =" + cassette3_counter_5DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_6Changed)
                    {
                        qry.Append("cassette3_counter_6 =" + cassette3_counter_6DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_7Changed)
                    {
                        qry.Append("cassette3_counter_7 =" + cassette3_counter_7DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_8Changed)
                    {
                        qry.Append("cassette3_counter_8 =" + cassette3_counter_8DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_9Changed)
                    {
                        qry.Append("cassette3_counter_9 =" + cassette3_counter_9DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_10Changed)
                    {
                        qry.Append("cassette3_counter_10 =" + cassette3_counter_10DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_11Changed)
                    {
                        qry.Append("cassette3_counter_11 =" + cassette3_counter_11DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_12Changed)
                    {
                        qry.Append("cassette3_counter_12 =" + cassette3_counter_12DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_13Changed)
                    {
                        qry.Append("cassette3_counter_13 =" + cassette3_counter_13DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_14Changed)
                    {
                        qry.Append("cassette3_counter_14 =" + cassette3_counter_14DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_15Changed)
                    {
                        qry.Append("cassette3_counter_15 =" + cassette3_counter_15DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_16Changed)
                    {
                        qry.Append("cassette3_counter_16 =" + cassette3_counter_16DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_17Changed)
                    {
                        qry.Append("cassette3_counter_17 =" + cassette3_counter_17DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_18Changed)
                    {
                        qry.Append("cassette3_counter_18 =" + cassette3_counter_18DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_19Changed)
                    {
                        qry.Append("cassette3_counter_19 =" + cassette3_counter_19DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_20Changed)
                    {
                        qry.Append("cassette3_counter_20 =" + cassette3_counter_20DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_21Changed)
                    {
                        qry.Append("cassette3_counter_21 =" + cassette3_counter_21DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_22Changed)
                    {
                        qry.Append("cassette3_counter_22 =" + cassette3_counter_22DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_23Changed)
                    {
                        qry.Append("cassette3_counter_23 =" + cassette3_counter_23DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_24Changed)
                    {
                        qry.Append("cassette3_counter_24 =" + cassette3_counter_24DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_25Changed)
                    {
                        qry.Append("cassette3_counter_25 =" + cassette3_counter_25DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_26Changed)
                    {
                        qry.Append("cassette3_counter_26 =" + cassette3_counter_26DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_27Changed)
                    {
                        qry.Append("cassette3_counter_27 =" + cassette3_counter_27DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_28Changed)
                    {
                        qry.Append("cassette3_counter_28 =" + cassette3_counter_28DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_29Changed)
                    {
                        qry.Append("cassette3_counter_29 =" + cassette3_counter_29DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_30Changed)
                    {
                        qry.Append("cassette3_counter_30 =" + cassette3_counter_30DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_31Changed)
                    {
                        qry.Append("cassette3_counter_31 =" + cassette3_counter_31DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_32Changed)
                    {
                        qry.Append("cassette3_counter_32 =" + cassette3_counter_32DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_33Changed)
                    {
                        qry.Append("cassette3_counter_33 =" + cassette3_counter_33DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_34Changed)
                    {
                        qry.Append("cassette3_counter_34 =" + cassette3_counter_34DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_35Changed)
                    {
                        qry.Append("cassette3_counter_35 =" + cassette3_counter_35DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_36Changed)
                    {
                        qry.Append("cassette3_counter_36 =" + cassette3_counter_36DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_37Changed)
                    {
                        qry.Append("cassette3_counter_37 =" + cassette3_counter_37DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_38Changed)
                    {
                        qry.Append("cassette3_counter_38 =" + cassette3_counter_38DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_39Changed)
                    {
                        qry.Append("cassette3_counter_39 =" + cassette3_counter_39DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_40Changed)
                    {
                        qry.Append("cassette3_counter_40 =" + cassette3_counter_40DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_41Changed)
                    {
                        qry.Append("cassette3_counter_41 =" + cassette3_counter_41DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_42Changed)
                    {
                        qry.Append("cassette3_counter_42 =" + cassette3_counter_42DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_43Changed)
                    {
                        qry.Append("cassette3_counter_43 =" + cassette3_counter_43DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_44Changed)
                    {
                        qry.Append("cassette3_counter_44 =" + cassette3_counter_44DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_45Changed)
                    {
                        qry.Append("cassette3_counter_45 =" + cassette3_counter_45DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_46Changed)
                    {
                        qry.Append("cassette3_counter_46 =" + cassette3_counter_46DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_47Changed)
                    {
                        qry.Append("cassette3_counter_47 =" + cassette3_counter_47DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_48Changed)
                    {
                        qry.Append("cassette3_counter_48 =" + cassette3_counter_48DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_49Changed)
                    {
                        qry.Append("cassette3_counter_49 =" + cassette3_counter_49DbString);
                        qry.Append(",");
                    }

                    if (cassette3_counter_50Changed)
                    {
                        qry.Append("cassette3_counter_50 =" + cassette3_counter_50DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_1Changed)
                    {
                        qry.Append("cassette4_counter_1 =" + cassette4_counter_1DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_2Changed)
                    {
                        qry.Append("cassette4_counter_2 =" + cassette4_counter_2DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_3Changed)
                    {
                        qry.Append("cassette4_counter_3 =" + cassette4_counter_3DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_4Changed)
                    {
                        qry.Append("cassette4_counter_4 =" + cassette4_counter_4DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_5Changed)
                    {
                        qry.Append("cassette4_counter_5 =" + cassette4_counter_5DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_6Changed)
                    {
                        qry.Append("cassette4_counter_6 =" + cassette4_counter_6DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_7Changed)
                    {
                        qry.Append("cassette4_counter_7 =" + cassette4_counter_7DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_8Changed)
                    {
                        qry.Append("cassette4_counter_8 =" + cassette4_counter_8DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_9Changed)
                    {
                        qry.Append("cassette4_counter_9 =" + cassette4_counter_9DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_10Changed)
                    {
                        qry.Append("cassette4_counter_10 =" + cassette4_counter_10DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_11Changed)
                    {
                        qry.Append("cassette4_counter_11 =" + cassette4_counter_11DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_12Changed)
                    {
                        qry.Append("cassette4_counter_12 =" + cassette4_counter_12DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_13Changed)
                    {
                        qry.Append("cassette4_counter_13 =" + cassette4_counter_13DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_14Changed)
                    {
                        qry.Append("cassette4_counter_14 =" + cassette4_counter_14DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_15Changed)
                    {
                        qry.Append("cassette4_counter_15 =" + cassette4_counter_15DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_16Changed)
                    {
                        qry.Append("cassette4_counter_16 =" + cassette4_counter_16DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_17Changed)
                    {
                        qry.Append("cassette4_counter_17 =" + cassette4_counter_17DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_18Changed)
                    {
                        qry.Append("cassette4_counter_18 =" + cassette4_counter_18DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_19Changed)
                    {
                        qry.Append("cassette4_counter_19 =" + cassette4_counter_19DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_20Changed)
                    {
                        qry.Append("cassette4_counter_20 =" + cassette4_counter_20DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_21Changed)
                    {
                        qry.Append("cassette4_counter_21 =" + cassette4_counter_21DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_22Changed)
                    {
                        qry.Append("cassette4_counter_22 =" + cassette4_counter_22DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_23Changed)
                    {
                        qry.Append("cassette4_counter_23 =" + cassette4_counter_23DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_24Changed)
                    {
                        qry.Append("cassette4_counter_24 =" + cassette4_counter_24DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_25Changed)
                    {
                        qry.Append("cassette4_counter_25 =" + cassette4_counter_25DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_26Changed)
                    {
                        qry.Append("cassette4_counter_26 =" + cassette4_counter_26DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_27Changed)
                    {
                        qry.Append("cassette4_counter_27 =" + cassette4_counter_27DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_28Changed)
                    {
                        qry.Append("cassette4_counter_28 =" + cassette4_counter_28DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_29Changed)
                    {
                        qry.Append("cassette4_counter_29 =" + cassette4_counter_29DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_30Changed)
                    {
                        qry.Append("cassette4_counter_30 =" + cassette4_counter_30DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_31Changed)
                    {
                        qry.Append("cassette4_counter_31 =" + cassette4_counter_31DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_32Changed)
                    {
                        qry.Append("cassette4_counter_32 =" + cassette4_counter_32DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_33Changed)
                    {
                        qry.Append("cassette4_counter_33 =" + cassette4_counter_33DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_34Changed)
                    {
                        qry.Append("cassette4_counter_34 =" + cassette4_counter_34DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_35Changed)
                    {
                        qry.Append("cassette4_counter_35 =" + cassette4_counter_35DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_36Changed)
                    {
                        qry.Append("cassette4_counter_36 =" + cassette4_counter_36DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_37Changed)
                    {
                        qry.Append("cassette4_counter_37 =" + cassette4_counter_37DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_38Changed)
                    {
                        qry.Append("cassette4_counter_38 =" + cassette4_counter_38DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_39Changed)
                    {
                        qry.Append("cassette4_counter_39 =" + cassette4_counter_39DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_40Changed)
                    {
                        qry.Append("cassette4_counter_40 =" + cassette4_counter_40DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_41Changed)
                    {
                        qry.Append("cassette4_counter_41 =" + cassette4_counter_41DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_42Changed)
                    {
                        qry.Append("cassette4_counter_42 =" + cassette4_counter_42DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_43Changed)
                    {
                        qry.Append("cassette4_counter_43 =" + cassette4_counter_43DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_44Changed)
                    {
                        qry.Append("cassette4_counter_44 =" + cassette4_counter_44DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_45Changed)
                    {
                        qry.Append("cassette4_counter_45 =" + cassette4_counter_45DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_46Changed)
                    {
                        qry.Append("cassette4_counter_46 =" + cassette4_counter_46DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_47Changed)
                    {
                        qry.Append("cassette4_counter_47 =" + cassette4_counter_47DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_48Changed)
                    {
                        qry.Append("cassette4_counter_48 =" + cassette4_counter_48DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_49Changed)
                    {
                        qry.Append("cassette4_counter_49 =" + cassette4_counter_49DbString);
                        qry.Append(",");
                    }

                    if (cassette4_counter_50Changed)
                    {
                        qry.Append("cassette4_counter_50 =" + cassette4_counter_50DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_1Changed)
                    {
                        qry.Append("purge_counter_1 =" + purge_counter_1DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_2Changed)
                    {
                        qry.Append("purge_counter_2 =" + purge_counter_2DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_3Changed)
                    {
                        qry.Append("purge_counter_3 =" + purge_counter_3DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_4Changed)
                    {
                        qry.Append("purge_counter_4 =" + purge_counter_4DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_5Changed)
                    {
                        qry.Append("purge_counter_5 =" + purge_counter_5DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_6Changed)
                    {
                        qry.Append("purge_counter_6 =" + purge_counter_6DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_7Changed)
                    {
                        qry.Append("purge_counter_7 =" + purge_counter_7DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_8Changed)
                    {
                        qry.Append("purge_counter_8 =" + purge_counter_8DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_9Changed)
                    {
                        qry.Append("purge_counter_9 =" + purge_counter_9DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_10Changed)
                    {
                        qry.Append("purge_counter_10 =" + purge_counter_10DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_11Changed)
                    {
                        qry.Append("purge_counter_11 =" + purge_counter_11DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_12Changed)
                    {
                        qry.Append("purge_counter_12 =" + purge_counter_12DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_13Changed)
                    {
                        qry.Append("purge_counter_13 =" + purge_counter_13DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_14Changed)
                    {
                        qry.Append("purge_counter_14 =" + purge_counter_14DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_15Changed)
                    {
                        qry.Append("purge_counter_15 =" + purge_counter_15DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_16Changed)
                    {
                        qry.Append("purge_counter_16 =" + purge_counter_16DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_17Changed)
                    {
                        qry.Append("purge_counter_17 =" + purge_counter_17DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_18Changed)
                    {
                        qry.Append("purge_counter_18 =" + purge_counter_18DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_19Changed)
                    {
                        qry.Append("purge_counter_19 =" + purge_counter_19DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_20Changed)
                    {
                        qry.Append("purge_counter_20 =" + purge_counter_20DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_21Changed)
                    {
                        qry.Append("purge_counter_21 =" + purge_counter_21DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_22Changed)
                    {
                        qry.Append("purge_counter_22 =" + purge_counter_22DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_23Changed)
                    {
                        qry.Append("purge_counter_23 =" + purge_counter_23DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_24Changed)
                    {
                        qry.Append("purge_counter_24 =" + purge_counter_24DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_25Changed)
                    {
                        qry.Append("purge_counter_25 =" + purge_counter_25DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_26Changed)
                    {
                        qry.Append("purge_counter_26 =" + purge_counter_26DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_27Changed)
                    {
                        qry.Append("purge_counter_27 =" + purge_counter_27DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_28Changed)
                    {
                        qry.Append("purge_counter_28 =" + purge_counter_28DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_29Changed)
                    {
                        qry.Append("purge_counter_29 =" + purge_counter_29DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_30Changed)
                    {
                        qry.Append("purge_counter_30 =" + purge_counter_30DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_31Changed)
                    {
                        qry.Append("purge_counter_31 =" + purge_counter_31DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_32Changed)
                    {
                        qry.Append("purge_counter_32 =" + purge_counter_32DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_33Changed)
                    {
                        qry.Append("purge_counter_33 =" + purge_counter_33DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_34Changed)
                    {
                        qry.Append("purge_counter_34 =" + purge_counter_34DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_35Changed)
                    {
                        qry.Append("purge_counter_35 =" + purge_counter_35DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_36Changed)
                    {
                        qry.Append("purge_counter_36 =" + purge_counter_36DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_37Changed)
                    {
                        qry.Append("purge_counter_37 =" + purge_counter_37DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_38Changed)
                    {
                        qry.Append("purge_counter_38 =" + purge_counter_38DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_39Changed)
                    {
                        qry.Append("purge_counter_39 =" + purge_counter_39DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_40Changed)
                    {
                        qry.Append("purge_counter_40 =" + purge_counter_40DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_41Changed)
                    {
                        qry.Append("purge_counter_41 =" + purge_counter_41DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_42Changed)
                    {
                        qry.Append("purge_counter_42 =" + purge_counter_42DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_43Changed)
                    {
                        qry.Append("purge_counter_43 =" + purge_counter_43DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_44Changed)
                    {
                        qry.Append("purge_counter_44 =" + purge_counter_44DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_45Changed)
                    {
                        qry.Append("purge_counter_45 =" + purge_counter_45DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_46Changed)
                    {
                        qry.Append("purge_counter_46 =" + purge_counter_46DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_47Changed)
                    {
                        qry.Append("purge_counter_47 =" + purge_counter_47DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_48Changed)
                    {
                        qry.Append("purge_counter_48 =" + purge_counter_48DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_49Changed)
                    {
                        qry.Append("purge_counter_49 =" + purge_counter_49DbString);
                        qry.Append(",");
                    }

                    if (purge_counter_50Changed)
                    {
                        qry.Append("purge_counter_50 =" + purge_counter_50DbString);
                        qry.Append(",");
                    }

                    if (last_deposit_atChanged)
                    {
                        qry.Append("last_deposit_at =" + last_deposit_atDbString);
                        qry.Append(",");
                    }

                    if (atm_idChanged)
                    {
                        qry.Append("atm_id =" + atm_idDbString);
                        qry.Append(",");
                    }

                    if (task_idChanged)
                    {
                        qry.Append("task_id =" + task_idDbString);
                        qry.Append(",");
                    }

                    if (cassette1_denomination_detailChanged)
                    {
                        qry.Append("cassette1_denomination_detail =" + cassette1_denomination_detailDbString);
                        qry.Append(",");
                    }

                    if (cassette2_denomination_detailChanged)
                    {
                        qry.Append("cassette2_denomination_detail =" + cassette2_denomination_detailDbString);
                        qry.Append(",");
                    }

                    if (cassette3_denomination_detailChanged)
                    {
                        qry.Append("cassette3_denomination_detail =" + cassette3_denomination_detailDbString);
                        qry.Append(",");
                    }

                    if (cassette4_denomination_detailChanged)
                    {
                        qry.Append("cassette4_denomination_detail =" + cassette4_denomination_detailDbString);
                        qry.Append(",");
                    }

                    if (purge_denomination_detailChanged)
                    {
                        qry.Append("purge_denomination_detail =" + purge_denomination_detailDbString);
                        qry.Append(",");
                    }


                    qry.Replace(',', ' ', qry.Length - 1, 1);
                    qry.Append(" where ");
                    qry.Append("parsed_bna_counter_id = " + parsed_bna_counter_idDbString);
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
            cmd.CommandText = "DELETE Parsed_bna_counter whereparsed_bna_counter_id= " + parsed_bna_counter_id;
            if (conn.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
                cmd.ExecuteNonQuery();
        }

        public static void DeleteParsedBnaCounters(string where)
        {
            ConnectionFactory.ExecuteQuery("delete Parsed_bna_counter where " + where);
        }

        #endregion
        #region Columns enum
        public enum Columns : ulong
        {
            parsed_bna_counter_id,
            cassette1_counter_1,
            cassette1_counter_2,
            cassette1_counter_3,
            cassette1_counter_4,
            cassette1_counter_5,
            cassette1_counter_6,
            cassette1_counter_7,
            cassette1_counter_8,
            cassette1_counter_9,
            cassette1_counter_10,
            cassette1_counter_11,
            cassette1_counter_12,
            cassette1_counter_13,
            cassette1_counter_14,
            cassette1_counter_15,
            cassette1_counter_16,
            cassette1_counter_17,
            cassette1_counter_18,
            cassette1_counter_19,
            cassette1_counter_20,
            cassette1_counter_21,
            cassette1_counter_22,
            cassette1_counter_23,
            cassette1_counter_24,
            cassette1_counter_25,
            cassette1_counter_26,
            cassette1_counter_27,
            cassette1_counter_28,
            cassette1_counter_29,
            cassette1_counter_30,
            cassette1_counter_31,
            cassette1_counter_32,
            cassette1_counter_33,
            cassette1_counter_34,
            cassette1_counter_35,
            cassette1_counter_36,
            cassette1_counter_37,
            cassette1_counter_38,
            cassette1_counter_39,
            cassette1_counter_40,
            cassette1_counter_41,
            cassette1_counter_42,
            cassette1_counter_43,
            cassette1_counter_44,
            cassette1_counter_45,
            cassette1_counter_46,
            cassette1_counter_47,
            cassette1_counter_48,
            cassette1_counter_49,
            cassette1_counter_50,
            cassette2_counter_1,
            cassette2_counter_2,
            cassette2_counter_3,
            cassette2_counter_4,
            cassette2_counter_5,
            cassette2_counter_6,
            cassette2_counter_7,
            cassette2_counter_8,
            cassette2_counter_9,
            cassette2_counter_10,
            cassette2_counter_11,
            cassette2_counter_12,
            cassette2_counter_13,
            cassette2_counter_14,
            cassette2_counter_15,
            cassette2_counter_16,
            cassette2_counter_17,
            cassette2_counter_18,
            cassette2_counter_19,
            cassette2_counter_20,
            cassette2_counter_21,
            cassette2_counter_22,
            cassette2_counter_23,
            cassette2_counter_24,
            cassette2_counter_25,
            cassette2_counter_26,
            cassette2_counter_27,
            cassette2_counter_28,
            cassette2_counter_29,
            cassette2_counter_30,
            cassette2_counter_31,
            cassette2_counter_32,
            cassette2_counter_33,
            cassette2_counter_34,
            cassette2_counter_35,
            cassette2_counter_36,
            cassette2_counter_37,
            cassette2_counter_38,
            cassette2_counter_39,
            cassette2_counter_40,
            cassette2_counter_41,
            cassette2_counter_42,
            cassette2_counter_43,
            cassette2_counter_44,
            cassette2_counter_45,
            cassette2_counter_46,
            cassette2_counter_47,
            cassette2_counter_48,
            cassette2_counter_49,
            cassette2_counter_50,
            cassette3_counter_1,
            cassette3_counter_2,
            cassette3_counter_3,
            cassette3_counter_4,
            cassette3_counter_5,
            cassette3_counter_6,
            cassette3_counter_7,
            cassette3_counter_8,
            cassette3_counter_9,
            cassette3_counter_10,
            cassette3_counter_11,
            cassette3_counter_12,
            cassette3_counter_13,
            cassette3_counter_14,
            cassette3_counter_15,
            cassette3_counter_16,
            cassette3_counter_17,
            cassette3_counter_18,
            cassette3_counter_19,
            cassette3_counter_20,
            cassette3_counter_21,
            cassette3_counter_22,
            cassette3_counter_23,
            cassette3_counter_24,
            cassette3_counter_25,
            cassette3_counter_26,
            cassette3_counter_27,
            cassette3_counter_28,
            cassette3_counter_29,
            cassette3_counter_30,
            cassette3_counter_31,
            cassette3_counter_32,
            cassette3_counter_33,
            cassette3_counter_34,
            cassette3_counter_35,
            cassette3_counter_36,
            cassette3_counter_37,
            cassette3_counter_38,
            cassette3_counter_39,
            cassette3_counter_40,
            cassette3_counter_41,
            cassette3_counter_42,
            cassette3_counter_43,
            cassette3_counter_44,
            cassette3_counter_45,
            cassette3_counter_46,
            cassette3_counter_47,
            cassette3_counter_48,
            cassette3_counter_49,
            cassette3_counter_50,
            cassette4_counter_1,
            cassette4_counter_2,
            cassette4_counter_3,
            cassette4_counter_4,
            cassette4_counter_5,
            cassette4_counter_6,
            cassette4_counter_7,
            cassette4_counter_8,
            cassette4_counter_9,
            cassette4_counter_10,
            cassette4_counter_11,
            cassette4_counter_12,
            cassette4_counter_13,
            cassette4_counter_14,
            cassette4_counter_15,
            cassette4_counter_16,
            cassette4_counter_17,
            cassette4_counter_18,
            cassette4_counter_19,
            cassette4_counter_20,
            cassette4_counter_21,
            cassette4_counter_22,
            cassette4_counter_23,
            cassette4_counter_24,
            cassette4_counter_25,
            cassette4_counter_26,
            cassette4_counter_27,
            cassette4_counter_28,
            cassette4_counter_29,
            cassette4_counter_30,
            cassette4_counter_31,
            cassette4_counter_32,
            cassette4_counter_33,
            cassette4_counter_34,
            cassette4_counter_35,
            cassette4_counter_36,
            cassette4_counter_37,
            cassette4_counter_38,
            cassette4_counter_39,
            cassette4_counter_40,
            cassette4_counter_41,
            cassette4_counter_42,
            cassette4_counter_43,
            cassette4_counter_44,
            cassette4_counter_45,
            cassette4_counter_46,
            cassette4_counter_47,
            cassette4_counter_48,
            cassette4_counter_49,
            cassette4_counter_50,
            purge_counter_1,
            purge_counter_2,
            purge_counter_3,
            purge_counter_4,
            purge_counter_5,
            purge_counter_6,
            purge_counter_7,
            purge_counter_8,
            purge_counter_9,
            purge_counter_10,
            purge_counter_11,
            purge_counter_12,
            purge_counter_13,
            purge_counter_14,
            purge_counter_15,
            purge_counter_16,
            purge_counter_17,
            purge_counter_18,
            purge_counter_19,
            purge_counter_20,
            purge_counter_21,
            purge_counter_22,
            purge_counter_23,
            purge_counter_24,
            purge_counter_25,
            purge_counter_26,
            purge_counter_27,
            purge_counter_28,
            purge_counter_29,
            purge_counter_30,
            purge_counter_31,
            purge_counter_32,
            purge_counter_33,
            purge_counter_34,
            purge_counter_35,
            purge_counter_36,
            purge_counter_37,
            purge_counter_38,
            purge_counter_39,
            purge_counter_40,
            purge_counter_41,
            purge_counter_42,
            purge_counter_43,
            purge_counter_44,
            purge_counter_45,
            purge_counter_46,
            purge_counter_47,
            purge_counter_48,
            purge_counter_49,
            purge_counter_50,
            last_deposit_at,
            atm_id,
            task_id,
            cassette1_denomination_detail,
            cassette2_denomination_detail,
            cassette3_denomination_detail,
            cassette4_denomination_detail,
            purge_denomination_detail 

        }
        #endregion
        public DataTable BulkSave(List<ParsedBnaCounter> dataArray, SqlTransaction dbTrx)
        {
            DataTable dt = new DataTable();
            CreateDataTable(dt);
            AddToDataTable(dataArray, ref dt);
            SqlBulkCopy bulk = new SqlBulkCopy(dbTrx.Connection, SqlBulkCopyOptions.Default, dbTrx);
            bulk.DestinationTableName = "Parsed_bna_counter";
            bulk.WriteToServer(dt); return dt;
        }
        public void CreateDataTable(DataTable dt)
        {
            string[] colNames = Enum.GetNames(typeof(ParsedBnaCounter.Columns));
            for (int i = 0; i < colNames.Length; i++)
            {
                dt.Columns.Add(colNames[i]);
            }
        }
        public void AddToDataTable(List<ParsedBnaCounter> transList, ref DataTable dt)
        {
            foreach (ParsedBnaCounter tran in transList)
            {
                DataRow Row;
                Row = dt.NewRow();
                Row["parsed_bna_counter_id"] = ConnectionFactory.GetNextId();
                Row["cassette1_counter_1"] = tran.Cassette1Counter1;
                Row["cassette1_counter_2"] = tran.Cassette1Counter2;
                Row["cassette1_counter_3"] = tran.Cassette1Counter3;
                Row["cassette1_counter_4"] = tran.Cassette1Counter4;
                Row["cassette1_counter_5"] = tran.Cassette1Counter5;
                Row["cassette1_counter_6"] = tran.Cassette1Counter6;
                Row["cassette1_counter_7"] = tran.Cassette1Counter7;
                Row["cassette1_counter_8"] = tran.Cassette1Counter8;
                Row["cassette1_counter_9"] = tran.Cassette1Counter9;
                Row["cassette1_counter_10"] = tran.Cassette1Counter10;
                Row["cassette1_counter_11"] = tran.Cassette1Counter11;
                Row["cassette1_counter_12"] = tran.Cassette1Counter12;
                Row["cassette1_counter_13"] = tran.Cassette1Counter13;
                Row["cassette1_counter_14"] = tran.Cassette1Counter14;
                Row["cassette1_counter_15"] = tran.Cassette1Counter15;
                Row["cassette1_counter_16"] = tran.Cassette1Counter16;
                Row["cassette1_counter_17"] = tran.Cassette1Counter17;
                Row["cassette1_counter_18"] = tran.Cassette1Counter18;
                Row["cassette1_counter_19"] = tran.Cassette1Counter19;
                Row["cassette1_counter_20"] = tran.Cassette1Counter20;
                Row["cassette1_counter_21"] = tran.Cassette1Counter21;
                Row["cassette1_counter_22"] = tran.Cassette1Counter22;
                Row["cassette1_counter_23"] = tran.Cassette1Counter23;
                Row["cassette1_counter_24"] = tran.Cassette1Counter24;
                Row["cassette1_counter_25"] = tran.Cassette1Counter25;
                Row["cassette1_counter_26"] = tran.Cassette1Counter26;
                Row["cassette1_counter_27"] = tran.Cassette1Counter27;
                Row["cassette1_counter_28"] = tran.Cassette1Counter28;
                Row["cassette1_counter_29"] = tran.Cassette1Counter29;
                Row["cassette1_counter_30"] = tran.Cassette1Counter30;
                Row["cassette1_counter_31"] = tran.Cassette1Counter31;
                Row["cassette1_counter_32"] = tran.Cassette1Counter32;
                Row["cassette1_counter_33"] = tran.Cassette1Counter33;
                Row["cassette1_counter_34"] = tran.Cassette1Counter34;
                Row["cassette1_counter_35"] = tran.Cassette1Counter35;
                Row["cassette1_counter_36"] = tran.Cassette1Counter36;
                Row["cassette1_counter_37"] = tran.Cassette1Counter37;
                Row["cassette1_counter_38"] = tran.Cassette1Counter38;
                Row["cassette1_counter_39"] = tran.Cassette1Counter39;
                Row["cassette1_counter_40"] = tran.Cassette1Counter40;
                Row["cassette1_counter_41"] = tran.Cassette1Counter41;
                Row["cassette1_counter_42"] = tran.Cassette1Counter42;
                Row["cassette1_counter_43"] = tran.Cassette1Counter43;
                Row["cassette1_counter_44"] = tran.Cassette1Counter44;
                Row["cassette1_counter_45"] = tran.Cassette1Counter45;
                Row["cassette1_counter_46"] = tran.Cassette1Counter46;
                Row["cassette1_counter_47"] = tran.Cassette1Counter47;
                Row["cassette1_counter_48"] = tran.Cassette1Counter48;
                Row["cassette1_counter_49"] = tran.Cassette1Counter49;
                Row["cassette1_counter_50"] = tran.Cassette1Counter50;
                Row["cassette2_counter_1"] = tran.Cassette2Counter1;
                Row["cassette2_counter_2"] = tran.Cassette2Counter2;
                Row["cassette2_counter_3"] = tran.Cassette2Counter3;
                Row["cassette2_counter_4"] = tran.Cassette2Counter4;
                Row["cassette2_counter_5"] = tran.Cassette2Counter5;
                Row["cassette2_counter_6"] = tran.Cassette2Counter6;
                Row["cassette2_counter_7"] = tran.Cassette2Counter7;
                Row["cassette2_counter_8"] = tran.Cassette2Counter8;
                Row["cassette2_counter_9"] = tran.Cassette2Counter9;
                Row["cassette2_counter_10"] = tran.Cassette2Counter10;
                Row["cassette2_counter_11"] = tran.Cassette2Counter11;
                Row["cassette2_counter_12"] = tran.Cassette2Counter12;
                Row["cassette2_counter_13"] = tran.Cassette2Counter13;
                Row["cassette2_counter_14"] = tran.Cassette2Counter14;
                Row["cassette2_counter_15"] = tran.Cassette2Counter15;
                Row["cassette2_counter_16"] = tran.Cassette2Counter16;
                Row["cassette2_counter_17"] = tran.Cassette2Counter17;
                Row["cassette2_counter_18"] = tran.Cassette2Counter18;
                Row["cassette2_counter_19"] = tran.Cassette2Counter19;
                Row["cassette2_counter_20"] = tran.Cassette2Counter20;
                Row["cassette2_counter_21"] = tran.Cassette2Counter21;
                Row["cassette2_counter_22"] = tran.Cassette2Counter22;
                Row["cassette2_counter_23"] = tran.Cassette2Counter23;
                Row["cassette2_counter_24"] = tran.Cassette2Counter24;
                Row["cassette2_counter_25"] = tran.Cassette2Counter25;
                Row["cassette2_counter_26"] = tran.Cassette2Counter26;
                Row["cassette2_counter_27"] = tran.Cassette2Counter27;
                Row["cassette2_counter_28"] = tran.Cassette2Counter28;
                Row["cassette2_counter_29"] = tran.Cassette2Counter29;
                Row["cassette2_counter_30"] = tran.Cassette2Counter30;
                Row["cassette2_counter_31"] = tran.Cassette2Counter31;
                Row["cassette2_counter_32"] = tran.Cassette2Counter32;
                Row["cassette2_counter_33"] = tran.Cassette2Counter33;
                Row["cassette2_counter_34"] = tran.Cassette2Counter34;
                Row["cassette2_counter_35"] = tran.Cassette2Counter35;
                Row["cassette2_counter_36"] = tran.Cassette2Counter36;
                Row["cassette2_counter_37"] = tran.Cassette2Counter37;
                Row["cassette2_counter_38"] = tran.Cassette2Counter38;
                Row["cassette2_counter_39"] = tran.Cassette2Counter39;
                Row["cassette2_counter_40"] = tran.Cassette2Counter40;
                Row["cassette2_counter_41"] = tran.Cassette2Counter41;
                Row["cassette2_counter_42"] = tran.Cassette2Counter42;
                Row["cassette2_counter_43"] = tran.Cassette2Counter43;
                Row["cassette2_counter_44"] = tran.Cassette2Counter44;
                Row["cassette2_counter_45"] = tran.Cassette2Counter45;
                Row["cassette2_counter_46"] = tran.Cassette2Counter46;
                Row["cassette2_counter_47"] = tran.Cassette2Counter47;
                Row["cassette2_counter_48"] = tran.Cassette2Counter48;
                Row["cassette2_counter_49"] = tran.Cassette2Counter49;
                Row["cassette2_counter_50"] = tran.Cassette2Counter50;
                Row["cassette3_counter_1"] = tran.Cassette3Counter1;
                Row["cassette3_counter_2"] = tran.Cassette3Counter2;
                Row["cassette3_counter_3"] = tran.Cassette3Counter3;
                Row["cassette3_counter_4"] = tran.Cassette3Counter4;
                Row["cassette3_counter_5"] = tran.Cassette3Counter5;
                Row["cassette3_counter_6"] = tran.Cassette3Counter6;
                Row["cassette3_counter_7"] = tran.Cassette3Counter7;
                Row["cassette3_counter_8"] = tran.Cassette3Counter8;
                Row["cassette3_counter_9"] = tran.Cassette3Counter9;
                Row["cassette3_counter_10"] = tran.Cassette3Counter10;
                Row["cassette3_counter_11"] = tran.Cassette3Counter11;
                Row["cassette3_counter_12"] = tran.Cassette3Counter12;
                Row["cassette3_counter_13"] = tran.Cassette3Counter13;
                Row["cassette3_counter_14"] = tran.Cassette3Counter14;
                Row["cassette3_counter_15"] = tran.Cassette3Counter15;
                Row["cassette3_counter_16"] = tran.Cassette3Counter16;
                Row["cassette3_counter_17"] = tran.Cassette3Counter17;
                Row["cassette3_counter_18"] = tran.Cassette3Counter18;
                Row["cassette3_counter_19"] = tran.Cassette3Counter19;
                Row["cassette3_counter_20"] = tran.Cassette3Counter20;
                Row["cassette3_counter_21"] = tran.Cassette3Counter21;
                Row["cassette3_counter_22"] = tran.Cassette3Counter22;
                Row["cassette3_counter_23"] = tran.Cassette3Counter23;
                Row["cassette3_counter_24"] = tran.Cassette3Counter24;
                Row["cassette3_counter_25"] = tran.Cassette3Counter25;
                Row["cassette3_counter_26"] = tran.Cassette3Counter26;
                Row["cassette3_counter_27"] = tran.Cassette3Counter27;
                Row["cassette3_counter_28"] = tran.Cassette3Counter28;
                Row["cassette3_counter_29"] = tran.Cassette3Counter29;
                Row["cassette3_counter_30"] = tran.Cassette3Counter30;
                Row["cassette3_counter_31"] = tran.Cassette3Counter31;
                Row["cassette3_counter_32"] = tran.Cassette3Counter32;
                Row["cassette3_counter_33"] = tran.Cassette3Counter33;
                Row["cassette3_counter_34"] = tran.Cassette3Counter34;
                Row["cassette3_counter_35"] = tran.Cassette3Counter35;
                Row["cassette3_counter_36"] = tran.Cassette3Counter36;
                Row["cassette3_counter_37"] = tran.Cassette3Counter37;
                Row["cassette3_counter_38"] = tran.Cassette3Counter38;
                Row["cassette3_counter_39"] = tran.Cassette3Counter39;
                Row["cassette3_counter_40"] = tran.Cassette3Counter40;
                Row["cassette3_counter_41"] = tran.Cassette3Counter41;
                Row["cassette3_counter_42"] = tran.Cassette3Counter42;
                Row["cassette3_counter_43"] = tran.Cassette3Counter43;
                Row["cassette3_counter_44"] = tran.Cassette3Counter44;
                Row["cassette3_counter_45"] = tran.Cassette3Counter45;
                Row["cassette3_counter_46"] = tran.Cassette3Counter46;
                Row["cassette3_counter_47"] = tran.Cassette3Counter47;
                Row["cassette3_counter_48"] = tran.Cassette3Counter48;
                Row["cassette3_counter_49"] = tran.Cassette3Counter49;
                Row["cassette3_counter_50"] = tran.Cassette3Counter50;
                Row["cassette4_counter_1"] = tran.Cassette4Counter1;
                Row["cassette4_counter_2"] = tran.Cassette4Counter2;
                Row["cassette4_counter_3"] = tran.Cassette4Counter3;
                Row["cassette4_counter_4"] = tran.Cassette4Counter4;
                Row["cassette4_counter_5"] = tran.Cassette4Counter5;
                Row["cassette4_counter_6"] = tran.Cassette4Counter6;
                Row["cassette4_counter_7"] = tran.Cassette4Counter7;
                Row["cassette4_counter_8"] = tran.Cassette4Counter8;
                Row["cassette4_counter_9"] = tran.Cassette4Counter9;
                Row["cassette4_counter_10"] = tran.Cassette4Counter10;
                Row["cassette4_counter_11"] = tran.Cassette4Counter11;
                Row["cassette4_counter_12"] = tran.Cassette4Counter12;
                Row["cassette4_counter_13"] = tran.Cassette4Counter13;
                Row["cassette4_counter_14"] = tran.Cassette4Counter14;
                Row["cassette4_counter_15"] = tran.Cassette4Counter15;
                Row["cassette4_counter_16"] = tran.Cassette4Counter16;
                Row["cassette4_counter_17"] = tran.Cassette4Counter17;
                Row["cassette4_counter_18"] = tran.Cassette4Counter18;
                Row["cassette4_counter_19"] = tran.Cassette4Counter19;
                Row["cassette4_counter_20"] = tran.Cassette4Counter20;
                Row["cassette4_counter_21"] = tran.Cassette4Counter21;
                Row["cassette4_counter_22"] = tran.Cassette4Counter22;
                Row["cassette4_counter_23"] = tran.Cassette4Counter23;
                Row["cassette4_counter_24"] = tran.Cassette4Counter24;
                Row["cassette4_counter_25"] = tran.Cassette4Counter25;
                Row["cassette4_counter_26"] = tran.Cassette4Counter26;
                Row["cassette4_counter_27"] = tran.Cassette4Counter27;
                Row["cassette4_counter_28"] = tran.Cassette4Counter28;
                Row["cassette4_counter_29"] = tran.Cassette4Counter29;
                Row["cassette4_counter_30"] = tran.Cassette4Counter30;
                Row["cassette4_counter_31"] = tran.Cassette4Counter31;
                Row["cassette4_counter_32"] = tran.Cassette4Counter32;
                Row["cassette4_counter_33"] = tran.Cassette4Counter33;
                Row["cassette4_counter_34"] = tran.Cassette4Counter34;
                Row["cassette4_counter_35"] = tran.Cassette4Counter35;
                Row["cassette4_counter_36"] = tran.Cassette4Counter36;
                Row["cassette4_counter_37"] = tran.Cassette4Counter37;
                Row["cassette4_counter_38"] = tran.Cassette4Counter38;
                Row["cassette4_counter_39"] = tran.Cassette4Counter39;
                Row["cassette4_counter_40"] = tran.Cassette4Counter40;
                Row["cassette4_counter_41"] = tran.Cassette4Counter41;
                Row["cassette4_counter_42"] = tran.Cassette4Counter42;
                Row["cassette4_counter_43"] = tran.Cassette4Counter43;
                Row["cassette4_counter_44"] = tran.Cassette4Counter44;
                Row["cassette4_counter_45"] = tran.Cassette4Counter45;
                Row["cassette4_counter_46"] = tran.Cassette4Counter46;
                Row["cassette4_counter_47"] = tran.Cassette4Counter47;
                Row["cassette4_counter_48"] = tran.Cassette4Counter48;
                Row["cassette4_counter_49"] = tran.Cassette4Counter49;
                Row["cassette4_counter_50"] = tran.Cassette4Counter50;
                Row["purge_counter_1"] = tran.PurgeCounter1;
                Row["purge_counter_2"] = tran.PurgeCounter2;
                Row["purge_counter_3"] = tran.PurgeCounter3;
                Row["purge_counter_4"] = tran.PurgeCounter4;
                Row["purge_counter_5"] = tran.PurgeCounter5;
                Row["purge_counter_6"] = tran.PurgeCounter6;
                Row["purge_counter_7"] = tran.PurgeCounter7;
                Row["purge_counter_8"] = tran.PurgeCounter8;
                Row["purge_counter_9"] = tran.PurgeCounter9;
                Row["purge_counter_10"] = tran.PurgeCounter10;
                Row["purge_counter_11"] = tran.PurgeCounter11;
                Row["purge_counter_12"] = tran.PurgeCounter12;
                Row["purge_counter_13"] = tran.PurgeCounter13;
                Row["purge_counter_14"] = tran.PurgeCounter14;
                Row["purge_counter_15"] = tran.PurgeCounter15;
                Row["purge_counter_16"] = tran.PurgeCounter16;
                Row["purge_counter_17"] = tran.PurgeCounter17;
                Row["purge_counter_18"] = tran.PurgeCounter18;
                Row["purge_counter_19"] = tran.PurgeCounter19;
                Row["purge_counter_20"] = tran.PurgeCounter20;
                Row["purge_counter_21"] = tran.PurgeCounter21;
                Row["purge_counter_22"] = tran.PurgeCounter22;
                Row["purge_counter_23"] = tran.PurgeCounter23;
                Row["purge_counter_24"] = tran.PurgeCounter24;
                Row["purge_counter_25"] = tran.PurgeCounter25;
                Row["purge_counter_26"] = tran.PurgeCounter26;
                Row["purge_counter_27"] = tran.PurgeCounter27;
                Row["purge_counter_28"] = tran.PurgeCounter28;
                Row["purge_counter_29"] = tran.PurgeCounter29;
                Row["purge_counter_30"] = tran.PurgeCounter30;
                Row["purge_counter_31"] = tran.PurgeCounter31;
                Row["purge_counter_32"] = tran.PurgeCounter32;
                Row["purge_counter_33"] = tran.PurgeCounter33;
                Row["purge_counter_34"] = tran.PurgeCounter34;
                Row["purge_counter_35"] = tran.PurgeCounter35;
                Row["purge_counter_36"] = tran.PurgeCounter36;
                Row["purge_counter_37"] = tran.PurgeCounter37;
                Row["purge_counter_38"] = tran.PurgeCounter38;
                Row["purge_counter_39"] = tran.PurgeCounter39;
                Row["purge_counter_40"] = tran.PurgeCounter40;
                Row["purge_counter_41"] = tran.PurgeCounter41;
                Row["purge_counter_42"] = tran.PurgeCounter42;
                Row["purge_counter_43"] = tran.PurgeCounter43;
                Row["purge_counter_44"] = tran.PurgeCounter44;
                Row["purge_counter_45"] = tran.PurgeCounter45;
                Row["purge_counter_46"] = tran.PurgeCounter46;
                Row["purge_counter_47"] = tran.PurgeCounter47;
                Row["purge_counter_48"] = tran.PurgeCounter48;
                Row["purge_counter_49"] = tran.PurgeCounter49;
                Row["purge_counter_50"] = tran.PurgeCounter50;
                Row["last_deposit_at"] = tran.LastDepositAt;
                Row["atm_id"] = tran.AtmId;
                Row["task_id"] = tran.TaskId;
                Row["cassette1_denomination_detail"] = tran.Cassette1DenominationDetail;
                Row["cassette2_denomination_detail"] = tran.Cassette2DenominationDetail;
                Row["cassette3_denomination_detail"] = tran.Cassette3DenominationDetail;
                Row["cassette4_denomination_detail"] = tran.Cassette4DenominationDetail;
                Row["purge_denomination_detail"] = tran.PurgeDenominationDetail;
                dt.Rows.Add(Row);
            }
        }
    }
}


