using AutoMapper;
using Microsoft.AspNetCore.Components;
using Schools.DTO.DTO;
using Schools.DataStorage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Tttt.Services;
using Blazored.Toast.Services;
using Microsoft.JSInterop;

namespace Tttt.Pages.Subject
{
    public partial class Subjects
    {
        [Parameter]
        public SubjectDto CurrenSubject { get; set; }
        [Inject]
        public IEnumerable<SubjectDto> AllSubject { get; set; }
        [Inject]
        public IEnumerable<TeacherDto> Teachers { get; set; }
        [Inject]
        public ISubjectDataService SubjectDataService { get; set; }
        [Inject]
        public IExamTypeService ExamDataService { get; set; }
        [Inject]
        public ITeacherDataService TeacherDataService { get; set; }
        [Inject]
        public IToastService ToastService { get; set; }
        [Inject]
        public NavigationManager _navigation { get; set; }


        protected string modalTitle { get; set; }
        protected Boolean isDelete = false;
        protected Boolean isAdd = false;
        protected Boolean isModify = false;

        protected override async Task OnInitializedAsync()
        {
            AllSubject = await SubjectDataService.GetAll();
            Teachers = await TeacherDataService.GetAll();

        }
        protected async Task HandleValidSubmitAdding()
        {
            try
            {
                await SubjectDataService.Add(CurrenSubject);
                ToastService.ShowSuccess("Adding New Subject Succefully");


            }
            catch 
            {
                ToastService.ShowError("Adding New Subject Falied !!");

            }
            this.isAdd = false;
            await OnInitializedAsync();
        } 
        protected async Task HandleValidSubmitUpdate()
        {
            try
            {
                await SubjectDataService.Update(CurrenSubject.CodeId, CurrenSubject);
                ToastService.ShowSuccess("Update  Subject Succefully");


            }
            catch 
            {
                ToastService.ShowError("Update Subject Falied !!");

                //ToastService.ShowSuccess("Update  Subject Succefully");

            }
            this.isModify = false;
            await OnInitializedAsync();
        }
        protected async Task DeleteSubject(string CodedId)
        {
            try
            {
                await SubjectDataService.Delete(CodedId);
                ToastService.ShowSuccess("Deleting  Subject Succefully");
            }
            catch
            {
                ToastService.ShowError("Deleting Subject Falied !!");
            }
            this.isDelete = false;
            await OnInitializedAsync();
        }
        protected void AddSub()
        {
            CurrenSubject = new SubjectDto ();
            this.modalTitle = "Add Subject";
            this.isAdd = true;
        } 
        protected async Task  UpdateSub(string CodedId)
        {
            CurrenSubject = await SubjectDataService.Get(CodedId);
            this.modalTitle = "Update Subject";
            this.isModify = true;
        }
        protected async Task DeleteSub(string CodedId)
        {
            CurrenSubject = await SubjectDataService.Get(CodedId);
            this.modalTitle = "Delete Subject";
            this.isDelete = true;
        }
        protected void closeModal()
        {
            this.isAdd = false;
            this.isModify = false;
            this.isDelete = false;
        }



    }
}
