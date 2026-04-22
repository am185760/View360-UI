using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace ServicesDAL
{
    public class Activity
    {
        /// <summary>
        /// time of the Activity,the value is set at the time when constructor is called
        /// </summary>
        public DateTime Time;
        /// <summary>
        /// name of the function in which activity happened
        /// </summary>
        public String FunctionName;
        /// <summary>
        /// message to be logged for the activity
        /// </summary>
        public string msg;
        /// <summary>
        /// stack trace on case of exeption
        /// </summary>
        public string stackTrace;
        /// <summary>
        /// trace level of the activity
        /// </summary>
        public TraceLevel level;
        /// <summary>
        /// not allowed to be used
        /// </summary>
        private Activity() { }
        /// <summary>
        /// public constructor to initialize members, should be used for non-error logging
        /// </summary>
        /// <param name="functionName">name of the function whrer activity happened</param>
        /// <param name="msg">message to be logger</param>
        /// <param name="level">trace level of the activity</param>
        public Activity(string functionName, string msg, TraceLevel level)
        {
            this.Time = DateTime.Now;
            this.FunctionName = functionName;
            this.msg = msg;
            this.level = level;
        }
        /// <summary>
        /// public constructor to initialize members, should be used for exceptions
        /// </summary>
        /// <param name="functionName">name of the function whrer activity happened</param>
        /// <param name="msg">message to be logger</param>
        /// <param name="stackTrace">trave level as provided by the exception object</param>
        /// <param name="level">trace level of the activity</param>
        public Activity(string functionName, string msg, string stackTrace, TraceLevel level)
        {
            this.Time = DateTime.Now;
            this.FunctionName = functionName;
            this.msg = msg;
            this.stackTrace = stackTrace;
            this.level = level;
        }
    }


    /// <summary>
    /// 1. if trace level is set to off no activity is added 
    /// 2. all the activities are added but only those are written which has lower trace level then the
    /// max trace level
    /// 3. if an error occures then all activities are logged except the case when trace level is Off.
    /// </summary>
    public class LogableTask
    {
        /// <summary>
        /// numbers task     from 0 to 1,2,3.. number starts     from zero when first instance is created ,although it 
        /// can be configured with <see cref="SetSerialNo"/> method
        /// </summary>
        static int serialNo = 0;


        /// <summary>
        /// trace level which is used in the overloaded version of the method <see cref="NewTask"/> which does
        /// not take trace level this can be changed as it is public 
        /// </summary>
        static public TraceLevel DefaultTraceLevel = TraceLevel.Info;

        int taskno;
        /// <summary>
        /// serial number that is associated with each task 
        /// </summary>
        public int Taskno
        {
            get { return taskno; }
        }

        /// <summary>
        /// list of activities,Log method adds a activity ,
        /// </summary>
        public ArrayList activities;
        TraceLevel traceLevel;
        /// <summary>
        /// is used to keep track if there is any error in the current task
        /// </summary>
        bool hasError = false;
        /// <summary>
        /// friendly name of the task , can be null
        /// </summary>
        public string TaskName;

        /// <summary>
        /// set to true when end task is called , now no more activities can be added
        /// </summary>
        bool finished = false;

        /// <summary>
        /// trace level to be used for the task
        /// </summary>
        public TraceLevel Tracelevel
        {
            get { return traceLevel; }
        }

        /// <summary>
        /// returns true if there is any error in the task
        /// </summary>
        public bool HasError
        {
            get { return hasError; }
        }

        /// <summary>
        /// can't be called     from out side
        /// </summary>
        private LogableTask() { }
        /// <summary>
        /// factory method
        /// </summary>
        /// <param name="taskName">friendly name of the task</param>
        /// <param name="traceLevel">if off no activity is logger</param>
        /// <returns></returns>
        public static LogableTask NewTask(string taskName, TraceLevel traceLevel)
        {
            LogableTask task = new LogableTask();
            task.TaskName = taskName;
            task.taskno = ++serialNo;
            task.traceLevel = traceLevel;
            if (task.traceLevel != TraceLevel.Off)
                task.activities = new ArrayList(7);
            return task;
        }
        /// <summary>
        /// factory method
        /// </summary>
        /// <param name="taskName">friendly name ,   <see cref="LogableTask.Tracelevel"/> is set to <see cref="DefaultTraceLevel"/></param>
        /// <returns></returns>
        public static LogableTask NewTask(string taskName)
        {
            LogableTask task = new LogableTask();
            task.TaskName = taskName;
            task.taskno = ++serialNo;
            task.traceLevel = LogableTask.DefaultTraceLevel;
            if (task.traceLevel != TraceLevel.Off)
                task.activities = new ArrayList(7);
            return task;
        }

        public static void LogMonoActivityTask(string taskName, MethodBase method, TraceLevel level, string msg)
        {
            LogableTask task = LogableTask.NewTask(taskName);
            task.Log(method, level, msg);
            task.EndTask();
        }

        public static void LogMonoActivityTask(string taskName, MethodBase method, TraceLevel level, Exception ex)
        {
            LogableTask task = LogableTask.NewTask(taskName);
            task.Log(method, level, ex);
            task.EndTask();
        }
        /// <summary>
        /// factory method,sets <see cref="TaskName"/> to null and name element is not written to log file
        /// <see cref="LogableTask.Tracelevel"/> is set to <see cref="DefaultTraceLevel"/>
        /// </summary>
        /// <returns></returns>
        public static LogableTask NewTask()
        {
            LogableTask task = new LogableTask();
            task.TaskName = null;
            task.taskno = ++serialNo;
            task.traceLevel = LogableTask.DefaultTraceLevel;
            if (task.traceLevel != TraceLevel.Off)
                task.activities = new ArrayList(7);
            return task;
        }

        /// <summary>
        /// to make sure that the task is written to the log file
        /// </summary>
        //~LogableTask()
        //{
        //    if (finished==false)
        //        XmlLogWriter.WriteTask(this);
        //}
        ///// <summary>
        /// used to set initial Serial number for each <see cref="LogableTask"/> default is 1
        /// </summary>
        /// <param name="number"></param>
        static public void SetSerialNo(int number)
        { LogableTask.serialNo = number; }

        /// <summary>
        /// use to add and an activity to the task the activity, 
        /// this is not written instantly to the file instead it is written when <see cref="EndTask"/>
        /// meethod is called or task is being garbage collected
        /// </summary>
        /// <param name="method">function where    activity happened</param>
        /// <param name="level">trace level of the activity </param>
        /// <param name="msg">message to be written</param>
        public void Log(MethodBase method, TraceLevel level, string msg)
        {
            if (finished)
                throw new Exception("task was finished");
            if (level == TraceLevel.Error)
                hasError = true;
            if (traceLevel != TraceLevel.Off)
                activities.Add(new Activity(method.DeclaringType.Name + "." + method.Name, msg, level));
        }
        /// <summary>
        /// use to add and an activity to the task the activity [better, in case of error]
        /// this is not written instantly to the file instead it is written when <see cref="EndTask"/>
        /// meethod is called or task is being garbage collected
        /// </summary>
        /// <param name="method">function where    activity happened</param>
        /// <param name="level">trace level of the activity </param>
        /// <param name="exception">used to get message and stack trace</param>
        public void Log(MethodBase method, TraceLevel level, Exception exception)
        {
            if (finished)
                throw new Exception("task was finished");
            if (level == TraceLevel.Error)
                hasError = true;
            if (traceLevel != TraceLevel.Off)
                activities.Add(new Activity(method.DeclaringType.Name + "." + method.Name, exception.Message, exception.StackTrace, level));
        }

        /// <summary>
        /// called when are activities are added and log should be written to file, no more activities can be added 
        /// now and can not be called more than once, if this function is not called and <see cref="LogableTask"/>
        /// object is being garbage collected then this is called
        /// </summary>
        public void EndTask()
        {
            if (finished) throw new Exception("task already ended");
            finished = true;
            XmlLogWriter.WriteTask(this);
        }
    }
    /// <summary>
    /// writes log in form of xml file the name of the file is taken     from the configuration file's key XmlTextWriter_FileName
    /// if key is not present then it defaults to C:\zLog.xml
    /// </summary>	 
    public class XmlLogWriter
    {
        //static  XmlTextWriter xmlWriter ;
        static StreamWriter writer;
        static bool writeEmptyTasks = false;
        static string fileName;
        static readonly object logfilelock = new object();
        static int paddingLength = 20;

        /// <summary>
        /// use file named in config file 's appSetting key XmlTextWriter_FileName if not then defaults to c:\zlog.xml
        /// </summary>
        public static void InitXmlLogWriter(string logFileName)
        {
            fileName = logFileName;
            lock (logfilelock)
            {
                if (writer != null)
                {

                    FileStream stream = writer.BaseStream as FileStream;
                    if (logFileName != stream.Name)
                    {
                        ShutDown();
                    }
                    else
                    {
                        return;
                    }

                }

                if (File.Exists(fileName))
                {
                    writer = new StreamWriter(new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read), System.Text.Encoding.ASCII);
                    writer.BaseStream.Position = writer.BaseStream.Length;
                }
                else
                {

                    writer = new StreamWriter(new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite), System.Text.Encoding.ASCII);

                    //xmlWriter.WriteProcessingInstruction("xml-stylesheet", "type=\"text/xsl\" href=\"LogViewer.xslt\"");
                    //xmlWriter.WriteStartElement("Log");
                    //xmlWriter.WriteElementString("StartRefNo", "1");
                    //xmlWriter.WriteStartElement("Task");
                    //xmlWriter.WriteElementString("RefNo", "0");
                    //xmlWriter.WriteElementString("Name", "Log File Creation");
                    //xmlWriter.WriteStartElement("Activity");

                    //writer.Write("0 ");
                    writer.Write(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss").PadRight(paddingLength));
                    writer.Write(TraceLevel.Info.ToString().PadRight(10));
                    writer.WriteLine("File path " + fileName);
                    //xmlWriter.WriteEndElement();
                    //xmlWriter.WriteEndElement();
                    //xmlWriter.WriteEndElement();
                    writer.Flush();
                }
            }
        }
        /// <summary>
        /// not intended to be used     from ur code
        /// </summary>
        /// <param name="task"></param>
        static public void WriteTask(LogableTask task)
        {
            //if (xmlWriter == null) return;
            lock (logfilelock)
            {
                System.Security.Principal.WindowsIdentity wi = System.Security.Principal.WindowsIdentity.GetCurrent();
                if (task.activities == null || (task.activities.Count == 0 && writeEmptyTasks == false))
                    return;
                //if (xmlWriter.BaseStream == null) return;
                //if (writer.BaseStream.Position > 0)
                //    writer.BaseStream.Position = writer.BaseStream.Position - 6;
                //writer.WriteLine("Task");
                //writer.Write(task.Taskno.ToString().PadRight(paddingLength));
                //if (task.TaskName != null)
                //    writer.Write(task.TaskName.PadRight(paddingLength));

                for (int i = 0; i < task.activities.Count; i++)
                {
                    Activity act = task.activities[i] as Activity;
                    if (task.HasError == false && task.Tracelevel < act.level)
                        continue;

                    //xmlWriter.WriteStartElement("Activity", "");
                    writer.Write(act.Time.ToString("dd/MM/yyyy HH:mm:ss:ff ").PadRight(paddingLength)+"-");
                    //writer.Write(act.level.ToString().PadRight(10));
                    //writer.Write(act.FunctionName.PadRight(45));

                    if (act.level.ToString().Contains("Error"))
                        writer.WriteLine();

                    writer.WriteLine(act.msg);

                    if (act.stackTrace != null)
                    {
                        if (act.level.ToString().Contains("Error"))
                            writer.WriteLine();
                        writer.WriteLine(act.stackTrace);
                    }

                    //xmlWriter.WriteEndElement();
                }
                //xmlWriter.WriteEndElement();
                //xmlWriter.WriteRaw("</Log>");
                writer.Flush();
            }
        }
        static public void ShutDown()
        {
            lock (logfilelock)
            {
                writer.Close();
                writer = null;
            }
        }
    }
}
