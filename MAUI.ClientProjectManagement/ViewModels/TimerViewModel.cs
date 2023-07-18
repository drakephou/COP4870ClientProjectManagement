using Library.ClientProjectManagement.Models;
using Library.ClientProjectManagement.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUI.ClientProjectManagement.ViewModels
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        public Project Project { get; set; }
        public string TimerDisplay
        {
            get
            {
                return string.Format("{0:00}:{1:00}:{2:00}",
                    stopwatch.Elapsed.Hours,
                    stopwatch.Elapsed.Minutes,
                    stopwatch.Elapsed.Seconds);
            }
        }

        public string ProjectDisplay
        {
            get
            {
                return Project.ShortName;
            }
        }

        public ICommand StartCommand { get; private set; }
        public void ExecuteStart()
        {
            stopwatch.Start();
            timer.Start();
        }

        public ICommand StopCommand { get; private set; }
        public void ExecuteStop()
        {
            stopwatch.Stop();
        }

        public void SetupCommands()
        {
            StartCommand = new Command(ExecuteStart);
            StopCommand = new Command(ExecuteStop);
        }

        private IDispatcherTimer timer { get; set; }
        private Stopwatch stopwatch {  get; set; }
        public TimerViewModel(int projectId) {
            Project = ProjectService.Current.GetProject(projectId) ?? null;
            stopwatch = new Stopwatch();
            timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.IsRepeating = true;

            timer.Tick += Timer_Tick;
            SetupCommands();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timer.IsRunning)
            {
                NotifyPropertyChanged(nameof(TimerDisplay));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
