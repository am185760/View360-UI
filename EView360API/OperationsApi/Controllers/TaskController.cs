using Common.RequestModel;
using EView360Models.Core;
using EView360Models.RequestModel;
using EView360Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OperationsApi.BusinessLayer;
using System.Collections.Generic;
using System.Dynamic;

namespace OperationsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : Controller
    {        
        private AtmTaskService _taskService { get; set; }
        private readonly CoreContext _context;
        public TaskController(AtmTaskService taskService, CoreContext context)
        {
            _taskService = taskService;
            _context = context;
        }


        [HttpGet("GetTaskTypes")]
        public async Task<IActionResult> GetTaskTypes()
        {
            try
            {
                return Ok(await _context.TaskTypes.ToListAsync());
            }
            catch (Exception ex) { throw; }
        }

        [HttpPost("GetAtmTask")]
        public async Task<IActionResult> GetAtmTask(DateTime fromDate, DateTime toDate, string? filter, int offset, int rowCount, List<string> atmIds, int? archiveYear = null)
        {
            try
            {
                string errorMsg = string.Empty;
                int totalRecord = 0;

                List<AtmTaskViewModel> atmTasks = _taskService.GetAtmTask(ref totalRecord, fromDate, toDate, filter, offset, rowCount, atmIds, ref errorMsg, archiveYear);
                dynamic dynamicObj = new ExpandoObject();
                dynamicObj.AtmTasks = atmTasks;
                dynamicObj.ErrorMsg = errorMsg;
                dynamicObj.TotalRecord = totalRecord;

                return Ok(dynamicObj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost("GetAtmTaskDashboard")]
        public async Task<IActionResult> GetAtmTaskDashboard(string? noteSetTypeFilter, string? filter, List<string> atmIds, int? archiveYear = null)
        {
            try
            {
                string errorMsg = string.Empty;
                List<AtmTaskViewModel> atmTasks = _taskService.GetAtmTaskDashboard(noteSetTypeFilter ?? "", filter ?? "", atmIds, ref errorMsg, archiveYear);
                dynamic dynamicObj = new ExpandoObject();
                dynamicObj.AtmTasks = atmTasks;
                dynamicObj.ErrorMsg = errorMsg;

                return Ok(dynamicObj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetDataFile")]
        public async Task<IActionResult> GetDataFile(string taskId, string fileTypeId, string atmId, string taskTypeId)
        {
            try
            {
                string errorMsg = string.Empty;
                List<string> dataFiles = _taskService.GetDataFile(taskId, fileTypeId, atmId, taskTypeId, ref errorMsg);
                dynamic dynamicObj = new ExpandoObject();
                dynamicObj.DataFiles = dataFiles;
                dynamicObj.ErrorMsg = errorMsg;

                return Ok(dynamicObj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("UpdateTaskStatus")]
        public async Task<IActionResult> UpdateTaskStatus(long taskId, long fileTypeId, string status, List<string> atmIds)
        {
            try
            {
                string response = _taskService.UpdateTaskStatus(taskId, fileTypeId, status, atmIds);
                if (response == "success")
                    return Ok(response);

                throw new Exception(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("ReparseTask")]
        public async Task<IActionResult> ReparseTask(long taskId, List<string> atmIds)
        {
            try
            {
                string response = _taskService.ReparseTask(taskId, atmIds);
                if (response == "success")
                    return Ok(response);

                throw new Exception(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("CheckTaskExistForAtms")]
        public async Task<IActionResult> CheckTaskExistForAtms(string taskTypeId, string fileTypeId, List<string> atmIds)
        {
            try
            {
                string errorMsg = string.Empty;
                List<AtmTaskViewModel> atmTaskViews = _taskService.CheckTaskExistForAtms(taskTypeId, fileTypeId, atmIds, ref errorMsg);
                if (string.IsNullOrEmpty(errorMsg))
                    return Ok(atmTaskViews);

                throw new Exception(errorMsg);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("CreateConfigurationTask")]
        public async Task<IActionResult> CreateConfigurationTask(int createdBy, List<string> atmIds)
        {
            try
            {
                string response = _taskService.CreateConfigurationTask(createdBy, atmIds);
                if (response == "success")
                    return Ok(response);

                throw new Exception(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("CreateDownloadFileTask")]
        public async Task<IActionResult> CreateDownloadFileTask(int createdBy, long fileTypeId, string atmId)
        {
            try
            {
                string response = _taskService.CreateDownloadFileTask(createdBy, fileTypeId, atmId);
                if (response == "success")
                    return Ok(response);

                throw new Exception(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //[HttpPost("GetTaskStatusName")]
        //public async Task<IActionResult> GetTaskStatusName(StatusRequestModel statusRequestModel)
        //{
        //    try
        //    {
        //        var response = _taskService.GetTaskStatusNames(statusRequestModel); ;
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }
}
