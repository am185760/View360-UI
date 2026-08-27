using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Avanza.iSuite.DAL;

namespace Avanza.CCMS.DAL
{
    public class CommentSaver
    {

        static System.Collections.Generic.SortedDictionary<string, int> transactionTypes = new SortedDictionary<string, int>();
        static System.Collections.Generic.SortedDictionary<int,string > comments = new SortedDictionary<int, string>();
        static bool transactionTypesLoaded = false;
        static bool commentsLoaded = false;

        public static string GetCommentById(int commentID)
        {
            
            lock (comments)
            {
                if (!commentsLoaded)
                {
                    Comment.CommentReader reader = Comment.ExecuteReader("1=1");
                    while (reader.Read())
                        comments.Add(reader.CurrentComment.CommentId, reader.CurrentComment.CommentText);
                    reader.Close();
                    commentsLoaded = true;
                }

                if (comments.ContainsKey(commentID))
                    return comments[commentID];
                else
                {
                    return Comment.LoadCommentByPk(commentID).CommentText;
                }
            }
        }
        public static int GetTransactionTypeId(string trxType)
        {
            lock (transactionTypes)
            {
                if (!transactionTypesLoaded)
                {
                    TransactionType.TransactionTypeReader reader = TransactionType.ExecuteReader("1=1");
                    while (reader.Read())
                        transactionTypes.Add(reader.CurrentTransactionType.TransactionTypeName.ToLower(), reader.CurrentTransactionType.TransactionTypeId);
                    reader.Close();
                    transactionTypesLoaded = true;
                }

                if (!transactionTypes.ContainsKey(trxType.ToLower()))
                {
                    object o = ConnectionFactory.ExecuteScalar("select max(transaction_type_id)+1 from transaction_type");
                    int i = 1;
                    if (o != null)
                        i = (int)o;

                    ConnectionFactory.ExecuteQuery("insert into transaction_type values (" + i + ",'" + trxType + "')");
                    transactionTypes.Clear();
                    transactionTypesLoaded = false;
                    return GetTransactionTypeId(trxType);
                }

                return transactionTypes[trxType.ToLower()];
            }
        }


        static SortedList commentList = new SortedList(50);
        static bool commenetListLoaded = false;
        public static int SaveComments(ref string comments, LogableTask task)
        {

            if (!commenetListLoaded)
            {
                Comment.CommentReader reader = Comment.ExecuteReader("comment_text is not null");
                while (reader.Read())
                {
                    try
                    {
                        if (!commentList.ContainsKey(Encoding.UTF7.GetString(Encoding.UTF7.GetBytes(reader.CurrentComment.CommentText))))
                            commentList.Add(reader.CurrentComment.CommentText, reader.CurrentComment.CommentId);
                    }
                    catch
                    {
                        commentList.Clear();
                        throw;
                    }
                }
                reader.Close();
                commenetListLoaded = true;
                task.Log(MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Info, "comments list size =" + commentList.Count);
                if (commentList.Count > 200)
                    task.Log(MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Warning, "comments list size =" + commentList.Count + " is large");

            }
            if (commentList.ContainsKey(Encoding.UTF7.GetString(Encoding.UTF7.GetBytes(comments))))
                return (int)commentList[comments];
            else
            {
                Comment new_comment = new Comment(Encoding.UTF7.GetString(Encoding.UTF7.GetBytes(comments.Replace("'", "''"))));
                new_comment.Save();
                commentList.Add(comments, new_comment.CommentId);
                return new_comment.CommentId;
            }
        }
    }
}
