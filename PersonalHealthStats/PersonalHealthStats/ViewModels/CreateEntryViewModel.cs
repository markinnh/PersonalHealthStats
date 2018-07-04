using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using PersonalHealthStats.Models;
using Xamarin.Forms;

namespace PersonalHealthStats.ViewModels
{
    public class CreateEntryViewModel : BaseViewModel
    {
        //Interfaces.IPageAlerter pageAlerter;
        public CreateEntryViewModel( )
        {
            SaveRecordCommand = new Command(SaveData, CanSaveData);
            CancelEditCommand = new Command(CancelEdit, CanCancelEdit);
            //pageAlerter = alerter;
            InitDependencies();
            MessagingCenter.Subscribe<BrowseEntryPage, BloodSugarEntry>(this, Constants.SelectedEntryMessage, (sender, arg) =>
            {
                startDate = arg.EntryDateTime.Date;
                startTime = arg.EntryDateTime.TimeOfDay;
                bloodSugar = arg.EntryValue;
                testType = arg.GetReadableName();
                mealInfo = arg.Meal;
                UpdateDependencies(Constants.SelectedEntryMessage);
                //NotifyPropertyChanged(nameof(StartDate));
                //NotifyPropertyChanged(nameof(StartTime));
                //NotifyPropertyChanged(nameof(BloodSugar));
                //NotifyPropertyChanged(nameof(TestType));
                //NotifyPropertyChanged(nameof(MealInfo));
            });

        }

        //private void SelectedEntryChanged(BrowseEntryPage arg1, BloodSugarEntry arg2)
        //{
        //    if(arg2 != null)
        //    {
        //        startDate = arg2.EntryDateTime.Date;
        //        startTime = arg2.EntryDateTime.TimeOfDay;
        //        bloodSugar = arg2.EntryValue;
        //        testType = arg2.GetReadableTestTypeName();
        //        mealInfo = arg2.Meal;
        //        NotifyPropertyChanged(nameof(StartDate));
        //        NotifyPropertyChanged(nameof(StartTime));
        //        NotifyPropertyChanged(nameof(BloodSugar));
        //        NotifyPropertyChanged(nameof(TestType));
        //        NotifyPropertyChanged(nameof(MealInfo));
        //    }
        //}

        private bool CanCancelEdit(object arg)
        {
            return true;
        }

        private void CancelEdit(object obj)
        {
            StartDate = DateTime.Today;
            StartTime = DateTime.Now.TimeOfDay;
            BloodSugar = 0;
            MealInfo = string.Empty;
            TestType = string.Empty;

        }

        private bool CanSaveData(object arg)
        {
            return true;
        }

        private void SaveData(object obj)
        {

            if (BloodSugar == 0 || string.IsNullOrEmpty(testType))
                MessagingCenter.Send(this,Constants.DoMessage,new Payload.OneOptionMessagePayload() { Title = "Alert", Message = "A valid entry requires a Test Type and Blood Sugar value to be defined", CancelText = "Ok" });

            else
            {
                //var newEntry = new Models.BloodSugarEntry()
                //{
                //    EntryDateTime = StartDate + StartTime,
                //    EntryValue = BloodSugar,
                //    EntryOwnerID = ownerViewModel.GetTestData().EntryOwner.EntryOwnerID,
                //    Owner = ownerViewModel.GetTestData().EntryOwner,
                //    EntryType = Models.BloodSugarEntry.GetEntryTypeFromString(TestType),
                //    Meal = MealInfo
                //};
                //ownerViewModel.GetTestData().EntryOwner.BloodSugarEntries.Add(newEntry);
                TestData.MyData.EntryOwner.AddEntry(BloodSugar, StartDate + StartTime, TestType, MealInfo);
            }
            //throw new NotImplementedException();
        }

        protected override void InitDependencies()
        {
            base.InitDependencies();

            var dependencyNames = new string[] { nameof(SaveRecordCommand), nameof(CancelEditCommand) };
            Dependencies.Add(nameof(BloodSugar), dependencyNames);
            Dependencies.Add(nameof(TestType), dependencyNames);
            Dependencies.Add(nameof(StartDate), dependencyNames);
            Dependencies.Add(nameof(StartTime), dependencyNames);
            Dependencies.Add(nameof(MealInfo), dependencyNames);
            Dependencies.Add(Constants.SelectedEntryMessage, new string[] { nameof(BloodSugar), nameof(TestType), nameof(StartDate), nameof(StartTime), nameof(MealInfo) });
            //throw new NotImplementedException();
        }

        protected override void UpdateDependencies(string PropertyName)
        {
            base.UpdateDependencies(PropertyName);
            //throw new NotImplementedException();
        }

        protected void UpdateEntryDateTime(DateTime dateTime)
        {
            UpdateControlsForExistingEntry(dateTime + StartTime);

            Set<DateTime>(ref startDate, dateTime, nameof(StartDate));
        }

        protected void UpdateEntryDateTime(TimeSpan timeSpan)
        {
            UpdateControlsForExistingEntry(StartDate + timeSpan);
            Set<TimeSpan>(ref startTime, timeSpan, nameof(StartTime));
        }

        /// <summary>
        /// Check for an existing entry at the passed datetime
        /// </summary>
        /// <param name="dateTime">datetime to check for an entry</param>
        private void UpdateControlsForExistingEntry(DateTime dateTime)
        {
            var lookup = TestData.MyData.EntryOwner.LookupEntry(dateTime);
            if (lookup != null)
            {
                BloodSugar = lookup.EntryValue;
                TestType = lookup.GetReadableName();
                MealInfo = lookup.Meal;
            }
        }

        public DateTime MaximumDate { get => Constants.MaximumDate; }

        public DateTime MinimumDate { get => Constants.MinimumDate; }

        public string Title { get => "Blood Sugar Entries"; }

        public string EntryDatePrompt { get => "Select the entry date"; }

        public string EntryTimePrompt { get => "Select the entry time"; }

        public string EntryValuePrompt { get => "Enter the blood sugar result"; }

        public string TestTypePrompt { get => "Select the the event for the test"; }

        public string MealInfoPrompt { get => "Enter meal info (optional)"; }

        public string CancelEditPrompt { get => "Cancel Updates"; }

        public string NewRecordPrompt { get => "Save Changes"; }


        private DateTime startDate = DateTime.Today;
        public DateTime StartDate { get => startDate; set => UpdateEntryDateTime(value); }

        private TimeSpan startTime = DateTime.Now.TimeOfDay;
        public TimeSpan StartTime { get => startTime; set => UpdateEntryDateTime(value); }

        private decimal bloodSugar;
        public decimal BloodSugar { get => bloodSugar; set => Set<decimal>(ref bloodSugar, value, nameof(BloodSugar)); }

        public string[] TestNames { get => BloodSugarEntry.GetTestTypeNames(); }

        private string testType = BloodSugarEntry.GetReadableTestTypeName(EntryType.BeforeBreakfast);
        public string TestType { get => testType; set => Set<string>(ref testType, value, nameof(TestType)); }

        private string mealInfo = string.Empty;
        public string MealInfo { get => mealInfo; set => Set<string>(ref mealInfo, value, nameof(MealInfo)); }

        public ICommand SaveRecordCommand { get; protected set; }

        public ICommand CancelEditCommand { get; protected set; }

    }
}
