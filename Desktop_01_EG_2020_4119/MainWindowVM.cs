using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop_01_EG_2020_4119;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;

namespace Desktop_01_EG_2020_4119
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> users;
        [ObservableProperty]
        public Student selectedUser = null;



        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }




        [RelayCommand]
        public void messeag()
        {

            MessageBox.Show($"{selectedUser.FirstName} GPA value must be between 0 and 4.", "Error");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddStudentVM();
            vm.title = "ADD STUDENTS DETAILS";
            AddStudentWindow window = new AddStudentWindow(vm);
            window.ShowDialog();

            if (vm.Student.FirstName != null)
            {
                users.Add(vm.Student);
            }

        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedUser != null)
            {
                string name = selectedUser.FirstName;
                users.Remove(selectedUser);
                MessageBox.Show($" Student {name}'s details are deleted successfully.", "DELETED \a ");

            }
            else
            {
                MessageBox.Show("Plese Select Student before Delete.", "Error");


            }
        }
        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (selectedUser != null)
            {
                var vm = new AddStudentVM(selectedUser);
                vm.title = "EDIT STUDENT DETAILS";
                var window = new AddStudentWindow(vm);

                window.ShowDialog();


                int index = users.IndexOf(selectedUser);
                users.RemoveAt(index);
                users.Insert(index, vm.Student);



            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }

        public MainWindowVM()
        {
            users = new ObservableCollection<Student>();
            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/10.png", UriKind.Relative));
            users.Add(new Student(23, "Praveenan", "Jeevarethinam", "2000.01.05", image1, 4.0));
            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/6.png", UriKind.Relative));
            users.Add(new Student(23, "Neethika", "Hariharasakthy", "2000.09.13", image2, 4.0));
            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/7.png", UriKind.Relative));
            users.Add(new Student(20, "Kithurshika", "Kirushnan", "2003.12.01", image3, 3.5));
            BitmapImage image4 = new BitmapImage(new Uri("/Model/Images/3.png", UriKind.Relative));
            users.Add(new Student(25, "Ranaveerha", "Fernando", "1998.03.23", image4, 3.8));

        }
    }
}
