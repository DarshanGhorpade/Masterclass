using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Masterclass.Revit.SecondButton
{
    public class SecondButtonViewModel : ViewModelBase
    {
        public SecondButtonModel Model { get; set; }

        public RelayCommand<Window> Delete { get; set; }
        public RelayCommand<Window> Close { get; set; }

        private ObservableCollection<SpatialElementWrapper> _spatialObjects;
        public ObservableCollection<SpatialElementWrapper> SpatialObjects
        {
            get { return _spatialObjects; }
            set { _spatialObjects = value; RaisePropertyChanged(() => SpatialObjects); }
        }
         
        public SecondButtonViewModel(SecondButtonModel model)
        {
            Model = model;
            SpatialObjects = Model.CollectSpatialObjects();
            Delete = new RelayCommand<Window>(OnDelete);
            Close = new RelayCommand<Window>(OnClose);
        }

        private void OnDelete(Window win)
        {
            var selected = SpatialObjects.Where(x => x.IsSelected).ToList();
            Model.Delete(selected);
            win.Close();
        }

        private void OnClose(Window win)
        {
            win.Close();
        }
    }
}
